var tblDincydetArchivoActividadEjecucion;

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
                                url: '/DincydetArchivoActividadEjecucion/Insertar',
                                data: {
                                    'DenominacionActividadEjecucion': $('#txtDenominacion').val(),
                                    'TipoTrabajoActividadEjecucion': $('#txtTipoTActividad').val(),
                                    'SituacionActualActividadEjecucion': $('#txtSituacionActualA').val(),
                                    'FinanciamientoTPActividadEjecucion': $('#txtFTesoroPublico').val(),
                                    'FinanciamientoRDRActividadEjecucion': $('#txtFRDRInversion').val(),
                                    'FinanciamientoTransferenciaActividadEjecucion': $('#txtFTransferencia').val(),
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
                                    $('#tblDincydetArchivoActividadEjecucion').DataTable().ajax.reload();
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
                                url: '/DincydetArchivoActividadEjecucion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DenominacionActividadEjecucion': $('#txtDenominacione').val(),
                                    'TipoTrabajoActividadEjecucion': $('#txtTipoTActividade').val(),
                                    'SituacionActualActividadEjecucion': $('#txtSituacionActualAe').val(),
                                    'FinanciamientoTPActividadEjecucion': $('#txtFTesoroPublicoe').val(),
                                    'FinanciamientoRDRActividadEjecucion': $('#txtFRDRInversione').val(),
                                    'FinanciamientoTransferenciaActividadEjecucion': $('#txtFTransferenciae').val(),
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
                                    $('#tblDincydetArchivoActividadEjecucion').DataTable().ajax.reload();
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

  tblDincydetArchivoActividadEjecucion =  $('#tblDincydetArchivoActividadEjecucion').DataTable({
        ajax: {
            "url": '/DincydetArchivoActividadEjecucion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "archivoActividadEjecucionId" },
            { "data": "denominacionActividadEjecucion" },
            { "data": "tipoTrabajoActividadEjecucion" },
            { "data": "situacionActualActividadEjecucion" },
            { "data": "financiamientoTPActividadEjecucion" },
            { "data": "financiamientoRDRActividadEjecucion" },
            { "data": "financiamientoTransferenciaActividadEjecucion" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.archivoActividadEjecucionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.archivoActividadEjecucionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            //csv,
            {
                extend: 'csvHtml5',
                text: 'Exportar CSV',
                filename: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación en Ejecución',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación en Ejecución',
                title: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación en Ejecución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación en Ejecución',
                title: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación en Ejecución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación en Ejecución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-print'

            },
            //extra
            'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
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
    tblDincydetArchivoActividadEjecucion.columns(7).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDincydetArchivoActividadEjecucion.columns(7).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DincydetArchivoActividadEjecucion/Mostrar?Id=' + Id, [], function (ArchivoActividadEjecucionDTO) {
        $('#txtCodigo').val(ArchivoActividadEjecucionDTO.archivoActividadEjecucionId);
        $('#txtDenominacione').val(ArchivoActividadEjecucionDTO.denominacionActividadEjecucion);
        $('#txtTipoTActividade').val(ArchivoActividadEjecucionDTO.tipoTrabajoActividadEjecucion);
        $('#txtSituacionActualAe').val(ArchivoActividadEjecucionDTO.situacionActualActividadEjecucion);
        $('#txtFTesoroPublicoe').val(ArchivoActividadEjecucionDTO.financiamientoTPActividadEjecucion);
        $('#txtFRDRInversione').val(ArchivoActividadEjecucionDTO.financiamientoRDRActividadEjecucion);
        $('#txtFTransferenciae').val(ArchivoActividadEjecucionDTO.financiamientoTransferenciaActividadEjecucion);
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
                url: '/DincydetArchivoActividadEjecucion/Eliminar',
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
                    $('#tblDincydetArchivoActividadEjecucion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDincydetArchivoActividadEjecucion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DincydetArchivoActividadEjecucion/MostrarDatos',
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
                            $("<td>").text(item.denominacionActividadEjecucion),
                            $("<td>").text(item.tipoTrabajoActividadEjecucion),
                            $("<td>").text(item.situacionActualActividadEjecucion),
                            $("<td>").text(item.financiamientoTPActividadEjecucion),
                            $("<td>").text(item.financiamientoRDRActividadEjecucion),
                            $("<td>").text(item.financiamientoTransferenciaActividadEjecucion)
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
    fetch("DincydetArchivoActividadEjecucion/EnviarDatos", {
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
                url: '/DincydetArchivoActividadEjecucion/EliminarCarga',
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
                    $('#tblDincydetArchivoActividadEjecucion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DincydetArchivoActividadEjecucion/cargaCombs', [], function (Json) {
        var listaCargas = Json["data1"];

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

    reporteSeleccionado = '/DincydetArchivoActividadEjecucion/ReporteARTR';
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


