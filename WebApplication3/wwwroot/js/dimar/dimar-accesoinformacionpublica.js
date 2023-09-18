var tblDimarAccesoInformacionPublica;
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
                                url: '/DimarAccesoInformacionPublica/Insertar',
                                data: {
                                    'FechaRecepcion': $('#txtFechaRecepcion').val(),
                                    'NumeroDocumento': $('#txtNumeroDocumento').val(),
                                    'FechaDocumento': $('#txtFechaDocumento').val(),
                                    'Administrado': $('#txtAdministrado').val(),
                                    'Asunto': $('#txtAsunto').val(),
                                    'DocumentoRespuesta': $('#txtDocumentoRespuesta').val(),
                                    'FechaUsuario': $('#txtFechaUsuario').val(),
                                    'MontoRecaudado': $('#txtMontoRecaudado').val(),
                                    'TiempoRespuestaDias': $('#txtTiempoRespuestaDias').val(), 
                                    'CargaId': $('#cargasR').val(),
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
                                    $('#tblDimarAccesoInformacionPublica').DataTable().ajax.reload();
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
                                url: '/DimarAccesoInformacionPublica/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaRecepcion': $('#txtFechaRecepcione').val(),
                                    'NumeroDocumento': $('#txtNumeroDocumentoe').val(),
                                    'FechaDocumento': $('#txtFechaDocumentoe').val(),
                                    'Administrado': $('#txtAdministradoe').val(),
                                    'Asunto': $('#txtAsuntoe').val(),
                                    'DocumentoRespuesta': $('#txtDocumentoRespuestae').val(),
                                    'FechaUsuario': $('#txtFechaUsuarioe').val(),
                                    'MontoRecaudado': $('#txtMontoRecaudadoe').val(),
                                    'TiempoRespuestaDias': $('#txtTiempoRespuestaDiase').val(), 
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
                                    $('#tblDimarAccesoInformacionPublica').DataTable().ajax.reload();
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

        tblDimarAccesoInformacionPublica=  $('#tblDimarAccesoInformacionPublica').DataTable({
        ajax: {
            "url": '/DimarAccesoInformacionPublica/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "accesoInformacionPublicaId" },
            { "data": "fechaRecepcion" },
            { "data": "numeroDocumento" },
            { "data": "fechaDocumento" },
            { "data": "administrado" },
            { "data": "asunto" },
            { "data": "documentoRespuesta" },
            { "data": "fechaUsuario" },
            { "data": "montoRecaudado" },
            { "data": "tiempoRespuestaDias" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.accesoInformacionPublicaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.accesoInformacionPublicaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dimar - Pedido de Acceso a la información Pública ',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dimar - Pedido de Acceso a la información Pública ',
                title: 'Dimar - Pedido de Acceso a la información Pública ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dimar - Pedido de Acceso a la información Pública ',
                title: 'Dimar - Pedido de Acceso a la información Pública ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dimar - Pedido de Acceso a la información Pública ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
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
    tblDimarAccesoInformacionPublica.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDimarAccesoInformacionPublica.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DimarAccesoInformacionPublica/Mostrar?Id=' + Id, [], function (AccesoInformacionPublicaDTO) {
        $('#txtCodigo').val(AccesoInformacionPublicaDTO.accesoInformacionPublicaId);
        $('#txtFechaRecepcione').val(AccesoInformacionPublicaDTO.fechaRecepcion);
        $('#txtNumeroDocumentoe').val(AccesoInformacionPublicaDTO.numeroDocumento);
        $('#txtFechaDocumentoe').val(AccesoInformacionPublicaDTO.fechaDocumento);
        $('#txtAdministradoe').val(AccesoInformacionPublicaDTO.administrado);
        $('#txtAsuntoe').val(AccesoInformacionPublicaDTO.asunto);
        $('#txtDocumentoRespuestae').val(AccesoInformacionPublicaDTO.documentoRespuesta);
        $('#txtFechaUsuarioe').val(AccesoInformacionPublicaDTO.fechaUsuario);
        $('#txtMontoRecaudadoe').val(AccesoInformacionPublicaDTO.montoRecaudado);
        $('#txtTiempoRespuestaDiase').val(AccesoInformacionPublicaDTO.tiempoRespuestaDias); 
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
                url: '/DimarAccesoInformacionPublica/Eliminar',
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
                    $('#tblDimarAccesoInformacionPublica').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDimarAccesoInformacionPublica() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DimarAccesoInformacionPublica/MostrarDatos',
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
                            $("<td>").text(item.fechaRecepcion),
                            $("<td>").text(item.numeroDocumento),
                            $("<td>").text(item.fechaDocumento),
                            $("<td>").text(item.administrado),
                            $("<td>").text(item.asunto),
                            $("<td>").text(item.documentoRespuesta),
                            $("<td>").text(item.fechaUsuario),
                            $("<td>").text(item.montoRecaudado),
                            $("<td>").text(item.tiempoRespuestaDias),
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
    fetch("DimarAccesoInformacionPublica/EnviarDatos", {
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

function cargaDatos() {
    $.getJSON('/DimarAccesoInformacionPublica/cargaCombs', [], function (Json) {
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
    if (id == 1) {
        reporteSeleccionado = '/DimarAccesoInformacionPublica/ReporteDAIP?idCarga=';
        $('#fecha').hide();
    }
}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect = 1) {
        a.href = reporteSeleccionado + idCarga;
    }
    a.click();
});