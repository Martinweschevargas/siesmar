var tblDincydetArchivoInversionTecnologica;
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
                                url: '/DincydetArchivoInversionTecnologica/Insertar',
                                data: {
                                    'CodigoAreaCT': $('#cbAreasCT').val(),
                                    'TipoActividadInversionTec': $('#txtTipoActividad').val(),
                                    'FinanciamientoTPInversionTec': $('#txtFTesoroPublico').val(),
                                    'FinanciamientoRDRInversionTec': $('#txtFRDRInversion').val(),
                                    'FinanciamientoTransferenciaInversionTec': $('#txtFTransferencia').val(),
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
                                    $('#tblDincydetArchivoInversionTecnologica').DataTable().ajax.reload();
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
                                url: '/DincydetArchivoInversionTecnologica/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoAreaCT': $('#cbAreasCTe').val(),
                                    'TipoActividadInversionTec': $('#txtTipoActividade').val(),
                                    'FinanciamientoTPInversionTec': $('#txtFTesoroPublicoe').val(),
                                    'FinanciamientoRDRInversionTec': $('#txtFRDRInversione').val(),
                                    'FinanciamientoTransferenciaInversionTec': $('#txtFTransferenciae').val(),
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
                                    $('#tblDincydetArchivoInversionTecnologica').DataTable().ajax.reload();
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

   tblDincydetArchivoInversionTecnologica= $('#tblDincydetArchivoInversionTecnologica').DataTable({
        ajax: {
            "url": '/DincydetArchivoInversionTecnologica/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "archivoInversionTecnologicaId" },
            { "data": "descAreaCT" },
            { "data": "tipoActividadInversionTec" },
            { "data": "financiamientoTPInversionTec" },
            { "data": "financiamientoRDRInversionTec" },
            { "data": "financiamientoTransferenciaInversionTec" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.archivoInversionTecnologicaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.archivoInversionTecnologicaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dincydet - Archivo para Inversión en Investigación, Desarrollo e Innovación Tecnológica',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dincydet - Archivo para Inversión en Investigación, Desarrollo e Innovación Tecnológica',
                title: 'Dincydet - Archivo para Inversión en Investigación, Desarrollo e Innovación Tecnológica',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dincydet - Archivo para Inversión en Investigación, Desarrollo e Innovación Tecnológica',
                title: 'Dincydet - Archivo para Inversión en Investigación, Desarrollo e Innovación Tecnológica',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dincydet - Archivo para Inversión en Investigación, Desarrollo e Innovación Tecnológica',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
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
    tblDincydetArchivoInversionTecnologica.columns(6).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDincydetArchivoInversionTecnologica.columns(6).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DincydetArchivoInversionTecnologica/Mostrar?Id=' + Id, [], function (ArchivoInversionTecnologicaDTO) {
        $('#txtCodigo').val(ArchivoInversionTecnologicaDTO.archivoInversionTecnologicaId);
        $('#cbAreasCTe').val(ArchivoInversionTecnologicaDTO.codigoAreaCT);
        $('#txtTipoActividade').val(ArchivoInversionTecnologicaDTO.tipoActividadInversionTec);
        $('#txtFTesoroPublicoe').val(ArchivoInversionTecnologicaDTO.financiamientoTPInversionTec);
        $('#txtFRDRInversione').val(ArchivoInversionTecnologicaDTO.financiamientoRDRInversionTec);
        $('#txtFTransferenciae').val(ArchivoInversionTecnologicaDTO.financiamientoTransferenciaInversionTec);
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
                url: '/DincydetArchivoInversionTecnologica/Eliminar',
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
                    $('#tblDincydetArchivoInversionTecnologica').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDincydetArchivoInversionTecnologica() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DincydetArchivoInversionTecnologica/MostrarDatos',
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
                            $("<td>").text(item.codigoAreaCT),
                            $("<td>").text(item.tipoActividadInversionTec),
                            $("<td>").text(item.financiamientoTPInversionTec),
                            $("<td>").text(item.financiamientoRDRInversionTec),
                            $("<td>").text(item.financiamientoTransferenciaInversionTec)
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
    fetch("DincydetArchivoInversionTecnologica/EnviarDatos", {
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
                url: '/DincydetArchivoInversionTecnologica/EliminarCarga',
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
                    $('#tblDincydetArchivoInversionTecnologica').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DincydetArchivoInversionTecnologica/cargaCombs', [], function (Json) {
        var AreasCT = Json["data1"];
        var listaCargas = Json["data2"];


        $("select#cbAreasCT").html("");
        $.each(AreasCT, function () {
            var RowContent = '<option value=' + this.codigoAreaCT + '>' + this.descAreaCT + '</option>'
            $("select#cbAreasCT").append(RowContent);
        });
        $("select#cbAreasCTe").html("");
        $.each(AreasCT, function () {
            var RowContent = '<option value=' + this.codigoAreaCT + '>' + this.descAreaCT + '</option>'
            $("select#cbAreasCTe").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    });
}



function optReporte(id) {
    optReporteSelect = id;

    reporteSeleccionado = '/DincydetArchivoInversionTecnologica/ReporteAIT';
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
