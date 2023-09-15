var tblDirecomarRendicionCuentasSBEGastos;
var reporteSeleccionado;
var optReporteSelect;

$(document).ready(function () {
    var forms = document.querySelectorAll('.needs-validation')
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                } else {
                    event.preventDefault();
                    Swal.fire({
                        title: 'Deseas Agregar?',
                        text: "Se agregará a la tabla",
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si, Agregar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/DirecomarRendicionCuentasSBEGastos/Insertar',
                                data: {
                                    'AnioRendicionCuenta': $('#txtAnio').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'CodigoSubunidadEjecutora': $('#cbSUE').val(),
                                    'ClasificacionGenericaGasto': $('#cbClasi').val(),
                                    'Entregado': $('#txtEntregado').val(),
                                    'Rendido': $('#txtRendido').val(),
                                    'Saldo': $('#txtSaldo').val(),
                                    'EncargadoInterno': $('#txtEncargadoInterno').val(),
                                    'GastoEncargo': $('#txtDeGastoEncargovengado').val(), 
                                    'EncargoOtorgado': $('#txtEncargoOtorgado').val(), 
                                    'CargaId': $('#cargasR').val(),
                                    'Fecha': $('#txtFecha').val()
                                },
                                beforeSend: function () {
                                    $('#loader-6').show();
                                },
                                success: function (mensaje) {
                                    if (mensaje == "1") {
                                        Swal.fire(
                                            'Agregado!',
                                            'Se Agregó con éxito.',
                                            'success'
                                        )
                                    } else {
                                        Swal.fire(
                                            'Atención!',
                                            'Ocurrio un problema.',
                                            'error'
                                        )
                                    }
                                    $('#listar').show();
                                    $('#nuevo').hide();
                                    $('#tblDirecomarRendicionCuentasSBEGastos').DataTable().ajax.reload();
                                    $('.needs-validation :input').val('');
                                    $(".needs-validation").find("select").prop("selectedIndex", 0);
                                    form.classList.remove('was-validated')
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });

                            callback(true);
                        }
                    })                  
                }
                form.classList.add('was-validated')
            }, false)
        })

    var forms = document.querySelectorAll('.form-actualizacion')
    Array.prototype.slice.call(forms)
        .forEach(function (form) {
            form.addEventListener('submit', function (event) {
                if (!form.checkValidity()) {
                    event.preventDefault()
                    event.stopPropagation()
                } else {
                    event.preventDefault();
                    Swal.fire({
                        title: 'Deseas Actualizar?',
                        text: "Se guardarán los cambios",
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si, Actualizar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/DirecomarRendicionCuentasSBEGastos/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioRendicionCuenta': $('#txtAnioe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'CodigoSubunidadEjecutora': $('#cbSUEe').val(),
                                    'ClasificacionGenericaGasto': $('#cbClasie').val(),
                                    'Entregado': $('#txtEntregadoe').val(),
                                    'Rendido': $('#txtRendidoe').val(),
                                    'Saldo': $('#txtSaldoe').val(),
                                    'EncargadoInterno': $('#txtEncargadoInternoe').val(),
                                    'GastoEncargo': $('#txtDeGastoEncargovengadoe').val(), 
                                    'EncargoOtorgado': $('#txtEncargoOtorgadoe').val() 
                                },
                                beforeSend: function () {
                                    $('#loader-6').show();
                                },
                                success: function (mensaje) {
                                    if (mensaje == "1") {
                                        Swal.fire(
                                            'Actualizado!',
                                            'Se actualizo con éxito.',
                                            'success'
                                        )
                                    } else {
                                        Swal.fire(
                                            'Atención!',
                                            'Ocurrio un problema.',
                                            'error'
                                        )
                                    }
                                    $('#listar').show();
                                    $('#editar').hide();
                                    $('#tblDirecomarRendicionCuentasSBEGastos').DataTable().ajax.reload();
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });

                            callback(true);
                        }
                    })
                   
                }
                form.classList.add('was-validated')
            }, false)
        })


        tblDirecomarRendicionCuentasSBEGastos=  $('#tblDirecomarRendicionCuentasSBEGastos').DataTable({
        ajax: {
            "url": '/DirecomarRendicionCuentasSBEGastos/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "rendicionCuentaSBEGastoId" },
            { "data": "anioRendicionCuenta" },
            { "data": "descMes" },
            { "data": "descSubUnidadEjecutora" },
            { "data": "descClasificacionGenericaGasto" },
            { "data": "entregado" },
            { "data": "rendido" },
            { "data": "saldo" },
            { "data": "encargadoInterno" },
            { "data": "gastoEncargo" },
            { "data": "encargoOtorgado" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.rendicionCuentaSBEGastoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.rendicionCuentaSBEGastoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
                }
            }
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        dom: 'Bfrtip',
        buttons: [
            //csv,
            {
                extend: 'csvHtml5',
                text: 'Exportar CSV',
                filename: 'Direcomar - Rendición de Cuentas por sub Unidades Ejecutoras y Generica de Gastos',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9,10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Direcomar - Rendición de Cuentas por sub Unidades Ejecutoras y Generica de Gastos',
                title: 'Direcomar - Rendición de Cuentas por sub Unidades Ejecutoras y Generica de Gastos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Direcomar - Rendición de Cuentas por sub Unidades Ejecutoras y Generica de Gastos',
                title: 'Direcomar - Rendición de Cuentas por sub Unidades Ejecutoras y Generica de Gastos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Direcomar - Rendición de Cuentas por sub Unidades Ejecutoras y Generica de Gastos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-print'

            },
            //extra
            'pageLength'
        ],
        columnDefs: [
            {
                "targets": "_all",
                "className": "text-center",
            },
            {
                "targets": "[7,8]",
                "width": "180px",
            }
        ]
    });
    cargaDatos();
    cargaBusqueda();
});

$('#btn_search').click(function () {
    cargaBusqueda();
});

$('#btn_all').click(function () {
    mostrarTodos();
});


function cargaBusqueda() {
    var CodigoCarga = $('#cargas').val();
    tblDirecomarRendicionCuentasSBEGastos.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirecomarRendicionCuentasSBEGastos.columns(11).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirecomarRendicionCuentasSBEGastos/Mostrar?Id=' + Id, [], function (RendicionCuentasSBEGastosDTO) {
        $('#txtCodigo').val(RendicionCuentasSBEGastosDTO.rendicionCuentaSBEGastoId);
        $('#txtAnioe').val(RendicionCuentasSBEGastosDTO.anioRendicionCuenta);
        $('#cbMese').val(RendicionCuentasSBEGastosDTO.numeroMes);
        $('#cbSUEe').val(RendicionCuentasSBEGastosDTO.codigoSubunidadEjecutora);
        $('#cbClasie').val(RendicionCuentasSBEGastosDTO.clasificacionGenericaGasto);
        $('#txtEntregadoe').val(RendicionCuentasSBEGastosDTO.entregado);
        $('#txtRendidoe').val(RendicionCuentasSBEGastosDTO.rendido);
        $('#txtSaldoe').val(RendicionCuentasSBEGastosDTO.saldo);
        $('#txtEncargadoInternoe').val(RendicionCuentasSBEGastosDTO.encargadoInterno);
        $('#txtDeGastoEncargovengadoe').val(RendicionCuentasSBEGastosDTO.gastoEncargo); 
        $('#txtEncargoOtorgadoe').val(RendicionCuentasSBEGastosDTO.encargoOtorgado); 
    });
}

function eliminar(id) {
    Swal.fire({
        title: 'Estas seguro?',
        text: "No podras revertir!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si,borrarlo!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '/DirecomarRendicionCuentasSBEGastos/Eliminar',
                data: {
                    'Id': id
                },
                beforeSend: function () {
                    $('#loader-6').show();
                },
                success: function (mensaje) {
                    if (mensaje == "1") {
                        Swal.fire(
                            'Borrado!',
                            'Se elimino con éxito.',
                            'success'
                        )
                    } else {
                        Swal.fire(
                            'Atención!',
                            'Ocurrio un problema.',
                            'error'
                        )
                    }
                    $('#listar').show();
                    $('#nuevo').hide();
                    $('#tblDirecomarRendicionCuentasSBEGastos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirecomarRendicionCuentasSBEGastos() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirecomarRendicionCuentasSBEGastos/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            console.log(dataJson);
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.anioRendicionCuenta),
                            $("<td>").text(item.numeroMes),
                            $("<td>").text(item.codigoSubunidadEjecutora),
                            $("<td>").text(item.clasificacionGenericaGasto),
                            $("<td>").text(item.entregado),
                            $("<td>").text(item.rendido),
                            $("<td>").text(item.saldo),
                            $("<td>").text(item.encargadoInterno),
                            $("<td>").text(item.gastoEncargo),
                            $("<td>").text(item.encargoOtorgado)
                        )
                    )
                })
                Swal.fire(
                    'Cargado!',
                    'Vista previa con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema.',
                    'error'
                )
            }
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    formData.append("Fecha", $('#txtFecha').val())
    fetch("DirecomarRendicionCuentasSBEGastos/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((mensaje) => {
            if (mensaje == "1") {
                Swal.fire(
                    'Cargado!',
                    'Se Cargo el archivo con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema.',
                    'error'
                )
            }
        })
}

function eliminarCarga() {
    var id = $('select#cargas').val();
    Swal.fire({
        title: 'Estas seguro?',
        text: "No podras revertir!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si,borralo!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '/DirecomarRendicionCuentasSBEGastos/EliminarCarga',
                data: {
                    'Id': id
                },
                beforeSend: function () {
                    $('#loader-6').show();
                },
                success: function (mensaje) {
                    if (mensaje == "1") {
                        Swal.fire(
                            'Borrado!',
                            'Se elimino con éxito.',
                            'success'
                        )
                    } else {
                        Swal.fire(
                            'Atención!',
                            'Ocurrio un problema.',
                            'error'
                        )
                    }
                    $('#listar').show();
                    $('#nuevo').hide();
                    $('#tblDirecomarRendicionCuentasSBEGastos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DirecomarRendicionCuentasSBEGastos/cargaCombs', [], function (Json) {
        var Mes = Json["data1"];
        var SubUnidadEjecutora = Json["data2"];
        var ClasificacionGenericaGasto = Json["data3"];
        var listaCargas = Json["data4"];

        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(Mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
            $("select#cbMese").append(RowContent);
        });

        $("select#cbSUE").html("");
        $("select#cbSUEe").html("");
        $.each(SubUnidadEjecutora, function () {
            var RowContent = '<option value=' + this.codigoSubUnidadEjecutora + '>' + this.descSubUnidadEjecutora + '</option>'
            $("select#cbSUE").append(RowContent);
            $("select#cbSUEe").append(RowContent);
        });

        $("select#cbClasi").html("");
        $("select#cbClasie").html("");
        $.each(ClasificacionGenericaGasto, function () {
            var RowContent = '<option value=' + this.clasificacionGenericaGasto + '>' + this.descClasificacionGenericaGasto + '</option>'
            $("select#cbClasi").append(RowContent);
            var RowContent = '<option value=' + this.clasificacionGenericaGasto + '>' + this.descClasificacionGenericaGasto + '</option>'
            $("select#cbClasie").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');

        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });


    });
}

function optReporte(id) {
    optReporteSelect = id;
  
        reporteSeleccionado = '/DirecomarRendicionCuentasSBEGastos/ReporteDRCG';

}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";

    var numCarga;
    if (idCarga == "0") {
        numCarga = '?CargaId=' + "";
    } else {
        numCarga = '?CargaId=' + idCarga;
    }

    if (optReporteSelect == 1) {
        a.href = reporteSeleccionado + numCarga;
    }
    a.click();
});