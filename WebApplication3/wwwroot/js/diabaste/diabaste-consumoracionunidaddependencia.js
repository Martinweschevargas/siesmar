var tblDiabasteConsumoRacionUnidadDependencia;
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
                                url: '/DiabasteConsumoRacionUnidadDependencia/Insertar',
                                data: {
                                    'Anio': $('#txtAnio').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'CodigoAreaDiperadmon': $('#cbArea').val(),
                                    'CodigoTipoRacion': $('#cbRacion').val(),
                                    'NumeroRacionRequerida': $('#txtRequerida').val(),
                                    'NumeroRacionConsumida': $('#txtConsumida').val(),
                                    'NumeroPersonalSuperior': $('#txtSuperior').val(),
                                    'NumeroPersonaSubalterno': $('#txtSubalterno').val(),
                                    'NumeroPersonalMineria': $('#txtMarineria').val(),
                                    'NumeroPersonalCadete': $('#txtCadete').val(),
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
                                    $('#tblDiabasteConsumoRacionUnidadDependencia').DataTable().ajax.reload();
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
                                url: '/DiabasteConsumoRacionUnidadDependencia/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'Anio': $('#txtAnioe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreae').val(),
                                    'CodigoTipoRacion': $('#cbRacione').val(),
                                    'NumeroRacionRequerida': $('#txtRequeridae').val(),
                                    'NumeroRacionConsumida': $('#txtConsumidae').val(),
                                    'NumeroPersonalSuperior': $('#txtSuperiore').val(),
                                    'NumeroPersonaSubalterno': $('#txtSubalternoe').val(),
                                    'NumeroPersonalMineria': $('#txtMarineriae').val(),
                                    'NumeroPersonalCadete': $('#txtCadetee').val(), 
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
                                    $('#tblDiabasteConsumoRacionUnidadDependencia').DataTable().ajax.reload();
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

    tblDiabasteConsumoRacionUnidadDependencia = $('#tblDiabasteConsumoRacionUnidadDependencia').DataTable({
        ajax: {
            "url": '/DiabasteConsumoRacionUnidadDependencia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "consumoRacionUnidadDependenciaId" },
            { "data": "anio" },
            { "data": "descMes" },
            { "data": "descAreaDiperadmon" },
            { "data": "descTipoRacion" },
            { "data": "numeroRacionRequerida" },
            { "data": "numeroRacionConsumida" },
            { "data": "numeroPersonalSuperior" },
            { "data": "numeroPersonaSubalterno" },
            { "data": "numeroPersonalMineria" },
            { "data": "numeroPersonalCadete" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.consumoRacionUnidadDependenciaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.consumoRacionUnidadDependenciaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diabaste - Consumo de Raciones de las Unidades y Dependencias',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diabaste - Consumo de Raciones de las Unidades y Dependencias',
                title: 'Diabaste - Consumo de Raciones de las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diabaste - Consumo de Raciones de las Unidades y Dependencias',
                title: 'Diabaste - Consumo de Raciones de las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diabaste - Consumo de Raciones de las Unidades y Dependencias',
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
    tblDiabasteConsumoRacionUnidadDependencia.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiabasteConsumoRacionUnidadDependencia.columns(11).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiabasteConsumoRacionUnidadDependencia/Mostrar?Id=' + Id, [], function (ConsumoRacionUnidadDependenciaDTO) {
        $('#txtCodigo').val(ConsumoRacionUnidadDependenciaDTO.consumoRacionUnidadDependenciaId);
        $('#txtAnioe').val(ConsumoRacionUnidadDependenciaDTO.anio);
        $('#cbMese').val(ConsumoRacionUnidadDependenciaDTO.numeroMes);
        $('#cbAreae').val(ConsumoRacionUnidadDependenciaDTO.codigoAreaDiperadmon);
        $('#cbRacione').val(ConsumoRacionUnidadDependenciaDTO.codigoTipoRacion);
        $('#txtRequeridae').val(ConsumoRacionUnidadDependenciaDTO.numeroRacionRequerida);
        $('#txtConsumidae').val(ConsumoRacionUnidadDependenciaDTO.numeroRacionConsumida);
        $('#txtSuperiore').val(ConsumoRacionUnidadDependenciaDTO.numeroPersonalSuperior);
        $('#txtSubalternoe').val(ConsumoRacionUnidadDependenciaDTO.numeroPersonaSubalterno);
        $('#txtMarineriae').val(ConsumoRacionUnidadDependenciaDTO.numeroPersonalMineria);
        $('#txtCadetee').val(ConsumoRacionUnidadDependenciaDTO.numeroPersonalCadete);  
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
                url: '/DiabasteConsumoRacionUnidadDependencia/Eliminar',
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
                    $('#tblDiabasteConsumoRacionUnidadDependencia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
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
                url: '/DiabasteConsumoRacionUnidadDependencia/EliminarCarga',
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
                    cargaDatos();
                    $('#tblDiabasteConsumoRacionUnidadDependencia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiabasteConsumoRacionUnidadDependencia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiabasteConsumoRacionUnidadDependencia/MostrarDatos',
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
                        $("<td>").text(item.anio),
                        $("<td>").text(item.numeroMes),
                        $("<td>").text(item.codigoAreaDiperadmon),
                        $("<td>").text(item.codigoTipoRacion),
                        $("<td>").text(item.numeroRacionRequerida),
                        $("<td>").text(item.numeroRacionConsumida),
                        $("<td>").text(item.numeroPersonalSuperior),
                        $("<td>").text(item.numeroPersonaSubalterno),
                        $("<td>").text(item.numeroPersonalMineria),
                        $("<td>").text(item.numeroPersonalCadete)

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
    fetch("DiabasteConsumoRacionUnidadDependencia/EnviarDatos", {
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
                    'Ocurrio un problema. ' + mensaje,
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/DiabasteConsumoRacionUnidadDependencia/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var areaDiperadmon = Json["data2"];
        var tipoRacion = Json["data3"];
        var listaCargas = Json["data4"];
        
        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
            $("select#cbMese").append(RowContent);
        });

        $("select#cbArea").html("");
        $("select#cbAreae").html("");
        $.each(areaDiperadmon, function () {
            var RowContent = '<option value=' + this.codigoAreaDiperadmon + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbArea").append(RowContent);
            $("select#cbAreae").append(RowContent);
        });

        $("select#cbRacion").html("");
        $("select#cbRacione").html("");
        $.each(tipoRacion, function () {
            var RowContent = '<option value=' + this.codigoTipoRacion + '>' + this.descTipoRacion + '</option>'
            $("select#cbRacion").append(RowContent);
            $("select#cbRacione").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });

    }) 
}

function optReporte(id) {
    optReporteSelect = id;

    reporteSeleccionado = '/DiabasteConsumoRacionUnidadDependencia/ReporteARTR';
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