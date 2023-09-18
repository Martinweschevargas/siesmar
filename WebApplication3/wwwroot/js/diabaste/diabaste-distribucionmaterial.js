var tblDiabasteDistribucionMaterial;
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
                                url: '/DiabasteDistribucionMaterial/Insertar',
                                data: {
                                    'Anio': $('#txtAnio').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'CodigoAreaDiperadmon': $('#cbArea').val(),
                                    'CodigoTipoMaterial': $('#cbMaterial').val(),
                                    'CodigoUnidadMedida': $('#cbUnidad').val(),
                                    'CantidadMaterialEntregado': $('#txtCantidad').val(),
                                    'FechaEntrega': $('#txtFecha').val(),
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
                                    $('#tblDiabasteDistribucionMaterial').DataTable().ajax.reload();
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
                                url: '/DiabasteDistribucionMaterial/Actualizar',
                                data: {
                                    'DistribucionMaterialId': $('#txtCodigo').val(),
                                    'Anio': $('#txtAnioe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreae').val(),
                                    'CodigoTipoMaterial': $('#cbMateriale').val(),
                                    'CodigoUnidadMedida': $('#cbUnidade').val(),
                                    'CantidadMaterialEntregado': $('#txtCantidade').val(),
                                    'FechaEntrega': $('#txtFechae').val(), 
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
                                    $('#tblDiabasteDistribucionMaterial').DataTable().ajax.reload();
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

tblDiabasteDistribucionMaterial = $('#tblDiabasteDistribucionMaterial').DataTable({
        ajax: {
            "url": '/DiabasteDistribucionMaterial/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "distribucionMaterialId" },
            { "data": "anio" },
            { "data": "descMes" },
            { "data": "descAreaDiperadmon" },
            { "data": "descTipoMaterial" },
            { "data": "descUnidadMedida" },
            { "data": "cantidadMaterialEntregado" },
            { "data": "fechaEntrega" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.distribucionMaterialId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.distribucionMaterialId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diabaste - Distribución de Vestuario a las Unidades y Dependencias',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diabaste - Distribución de Vestuario a las Unidades y Dependencias',
                title: 'Diabaste - Distribución de Vestuario a las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diabaste - Distribución de Vestuario a las Unidades y Dependencias',
                title: 'Diabaste - Distribución de Vestuario a las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diabaste - Distribución de Vestuario a las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    tblDiabasteDistribucionMaterial.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiabasteDistribucionMaterial.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiabasteDistribucionMaterial/Mostrar?Id=' + Id, [], function (DistribucionMaterialDTO) {
        $('#txtCodigo').val(DistribucionMaterialDTO.distribucionMaterialId);
        $('#txtAnioe').val(DistribucionMaterialDTO.anio);
        $('#cbMese').val(DistribucionMaterialDTO.numeroMes);
        $('#cbAreae').val(DistribucionMaterialDTO.codigoAreaDiperadmon);
        $('#cbMateriale').val(DistribucionMaterialDTO.codigoTipoMaterial);
        $('#cbUnidade').val(DistribucionMaterialDTO.codigoUnidadMedida);
        $('#txtCantidade').val(DistribucionMaterialDTO.cantidadMaterialEntregado);
        $('#txtFechae').val(DistribucionMaterialDTO.fechaEntrega);  
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
                url: '/DiabasteDistribucionMaterial/Eliminar',
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
                    $('#tblDiabasteDistribucionMaterial').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDiabasteDistribucionMaterial() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiabasteDistribucionMaterial/MostrarDatos',
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
                        $("<td>").text(item.codigoTipoMaterial),
                        $("<td>").text(item.codigoUnidadMedida),
                        $("<td>").text(item.cantidadMaterialEntregado),
                        $("<td>").text(item.fechaEntrega)
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
    fetch("DiabasteDistribucionMaterial/EnviarDatos", {
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
                url: '/DiabasteDistribucionMaterial/EliminarCarga',
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
                    $('#tblDiabasteDistribucionMaterial').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}


function cargaDatos() {
    $.getJSON('/DiabasteDistribucionMaterial/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var areaDiperadmon = Json["data2"];
        var tipoMaterial = Json["data3"];
        var unidadMedida = Json["data4"];
        var listaCargas = Json["data5"];


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


        $("select#cbMaterial").html("");
        $.each(tipoMaterial, function () {
            var RowContent = '<option value=' + this.codigoTipoMaterial + '>' + this.descTipoMaterial + '</option>'
            $("select#cbMaterial").append(RowContent);
        });
        $("select#cbMateriale").html("");
        $.each(tipoMaterial, function () {
            var RowContent = '<option value=' + this.codigoTipoMaterial + '>' + this.descTipoMaterial + '</option>'
            $("select#cbMateriale").append(RowContent);
        });

        $("select#cbUnidad").html("");
        $("select#cbUnidade").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.codigoUnidadMedida + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidad").append(RowContent);
            $("select#cbUnidade").append(RowContent);
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

    reporteSeleccionado = '/DiabasteDistribucionMaterial/ReporteARTR';
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
