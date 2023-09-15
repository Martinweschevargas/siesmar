var tblDincydetArchivoActividadCulminadoExito;
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
                                url: '/DincydetArchivoActividadCulminadoExito/Insertar',
                                data: {
                                    'DenominacionActividadCulminado': $('#txtDenominacion').val(),
                                    'TipoTrabajoActividadCulminado': $('#txtTipo').val(),
                                    'EtapaActividadCulminado': $('#txtEtapa').val(),
                                    'FinanciamientoTPActividadCulminado': $('#txtFTesoroPublico').val(),
                                    'FinanciamientoRDRActividadCulminado': $('#txtFRDRInversion').val(),
                                    'FinanciamientoTransferenciaActividadCulminado': $('#txtFTransferencia').val(),
                                    'CodigoAreaCT': $('#cbAreaCT').val(),
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
                                    $('#tblDincydetArchivoActividadCulminadoExito').DataTable().ajax.reload();
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
                                url: '/DincydetArchivoActividadCulminadoExito/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DenominacionActividadCulminado': $('#txtDenominacione').val(),
                                    'TipoTrabajoActividadCulminado': $('#txtTipoe').val(),
                                    'EtapaActividadCulminado': $('#txtEtapae').val(),
                                    'FinanciamientoTPActividadCulminado': $('#txtFTesoroPublicoe').val(),
                                    'FinanciamientoRDRActividadCulminado': $('#txtFRDRInversione').val(),
                                    'FinanciamientoTransferenciaActividadCulminado': $('#txtFTransferenciae').val(),
                                    'CodigoAreaCT': $('#cbAreaCTe').val(),
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
                                    $('#tblDincydetArchivoActividadCulminadoExito').DataTable().ajax.reload();

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

    tblDincydetArchivoActividadCulminadoExito = $('#tblDincydetArchivoActividadCulminadoExito').DataTable({
        ajax: {
            "url": '/DincydetArchivoActividadCulminadoExito/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "archivoActividadCulminadoExitoId" },
            { "data": "denominacionActividadCulminado" },
            { "data": "tipoTrabajoActividadCulminado" },
            { "data": "etapaActividadCulminado" },
            { "data": "financiamientoTPActividadCulminado" },
            { "data": "financiamientoRDRActividadCulminado" },
            { "data": "financiamientoTransferenciaActividadCulminado" },
            { "data": "descAreaCT" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.archivoActividadCulminadoExitoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.archivoActividadCulminadoExitoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                    filename: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación Culminados con Éxito',
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
                    filename: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación Culminados con Éxito',
                    title: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación Culminados con Éxito',
                    exportOptions: {
                        columns: [0, 1, 2, 3, 4, 5, 6, 7]
                    },
                    className: 'btn-exportar-excel',
                },
                //'pdf',
                {
                    extend: 'pdfHtml5',
                    text: 'Exportar PDF',
                    filename: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación Culminados con Éxito',
                    title: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación Culminados con Éxito',
                    exportOptions: {
                        columns: [0, 1, 2, 3, 4, 5, 6, 7]
                    },
                    className: 'btn-exportar-pdf',
                },
                //'print'
                {
                    extend: 'print',
                    title: 'Dincydet - Archivo para Actividades o Trabajos de Investigación, Desarrollo e Innovación Culminados con Éxito',
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
    tblDincydetArchivoActividadCulminadoExito.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblDincydetArchivoActividadCulminadoExito.columns(8).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DincydetArchivoActividadCulminadoExito/Mostrar?Id=' + Id, [], function (ArchivoActividadCulminadoExitoDTO) {
        $('#txtCodigo').val(ArchivoActividadCulminadoExitoDTO.archivoActividadCulminadoExitoId);
        $('#txtDenominacione').val(ArchivoActividadCulminadoExitoDTO.denominacionActividadCulminado);
        $('#txtTipoe').val(ArchivoActividadCulminadoExitoDTO.tipoTrabajoActividadCulminado);
        $('#txtEtapae').val(ArchivoActividadCulminadoExitoDTO.etapaActividadCulminado);
        $('#txtFTesoroPublicoe').val(ArchivoActividadCulminadoExitoDTO.financiamientoTPActividadCulminado);
        $('#txtFRDRInversione').val(ArchivoActividadCulminadoExitoDTO.financiamientoRDRActividadCulminado);
        $('#txtFTransferenciae').val(ArchivoActividadCulminadoExitoDTO.financiamientoTransferenciaActividadCulminado);
        $('#cbAreaCTe').val(ArchivoActividadCulminadoExitoDTO.codigoAreaCT);
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
                url: '/DincydetArchivoActividadCulminadoExito/Eliminar',
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
                    $('#tblDincydetArchivoActividadCulminadoExito').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDincydetArchivoActividadCulminadoExito() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DincydetArchivoActividadCulminadoExito/MostrarDatos',
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
                            $("<td>").text(item.denominacionActividadCulminado),
                            $("<td>").text(item.tipoTrabajoActividadCulminado),
                            $("<td>").text(item.etapaActividadCulminado),
                            $("<td>").text(item.financiamientoTPActividadCulminado),
                            $("<td>").text(item.financiamientoRDRActividadCulminado),
                            $("<td>").text(item.financiamientoTransferenciaActividadCulminado),
                            $("<td>").text(item.codigoAreaCT)
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
    fetch("DincydetArchivoActividadCulminadoExito/EnviarDatos", {
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
                url: '/DincydetArchivoActividadCulminadoExito/EliminarCarga',
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
                    $('#tblDincydetArchivoActividadCulminadoExito').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DincydetArchivoActividadCulminadoExito/cargaCombs', [], function (Json) {
        var areaCT = Json["data1"];
        var listaCargas = Json["data2"];

        $("select#cbAreaCT").html("");
        $.each(areaCT, function () {
            var RowContent = '<option value=' + this.codigoAreaCT + '>' + this.descAreaCT + '</option>'
            $("select#cbAreaCT").append(RowContent);
        });
        $("select#cbAreaCTe").html("");
        $.each(areaCT, function () {
            var RowContent = '<option value=' + this.codigoAreaCT + '>' + this.descAreaCT + '</option>'
            $("select#cbAreaCTe").append(RowContent);
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

    reporteSeleccionado = '/DincydetArchivoActividadCulminadoExito/ReporteARTR';
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