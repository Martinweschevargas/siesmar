var tblDincydetArchivoPublicaSuscripRevistas;

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
                                url: '/DincydetArchivoPublicaSuscripRevistas/Insertar',
                                data: {
                                    'NombreArticuloRevista': $('#txtNombreArticulo').val(),
                                    'TipoArticuloRevista': $('#txtTpoArticulo').val(),
                                    'CodigoAreaCT': $('#cbAreasCT').val(),
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
                                    $('#tblDincydetArchivoPublicaSuscripRevistas').DataTable().ajax.reload();
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
                                url: '/DincydetArchivoPublicaSuscripRevistas/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NombreArticuloRevista': $('#txtNombreArticuloe').val(),
                                    'TipoArticuloRevista': $('#txtTpoArticuloe').val(),
                                    'CodigoAreaCT': $('#cbAreasCTe').val(),
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
                                    $('#tblDincydetArchivoPublicaSuscripRevistas').DataTable().ajax.reload();
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

   tblDincydetArchivoPublicaSuscripRevistas = $('#tblDincydetArchivoPublicaSuscripRevistas').DataTable({
        ajax: {
            "url": '/DincydetArchivoPublicaSuscripRevistas/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "archivoPublicaSuscripRevistaId" },
            { "data": "nombreArticuloRevista" },
            { "data": "tipoArticuloRevista" },
            { "data": "descAreaCT" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.archivoPublicaSuscripRevistaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.archivoPublicaSuscripRevistaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dincydet - Archivo para Publicación y Suscripciones de Artículos Científicos de Ciencia y Tecnología en Revistas Especializadas',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dincydet - Archivo para Publicación y Suscripciones de Artículos Científicos de Ciencia y Tecnología en Revistas Especializadas',
                title: 'Dincydet - Archivo para Publicación y Suscripciones de Artículos Científicos de Ciencia y Tecnología en Revistas Especializadas',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dincydet - Archivo para Publicación y Suscripciones de Artículos Científicos de Ciencia y Tecnología en Revistas Especializadas',
                title: 'Dincydet - Archivo para Publicación y Suscripciones de Artículos Científicos de Ciencia y Tecnología en Revistas Especializadas',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dincydet - Archivo para Publicación y Suscripciones de Artículos Científicos de Ciencia y Tecnología en Revistas Especializadas',
                exportOptions: {
                    columns: [0, 1, 2, 3]
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
    tblDincydetArchivoPublicaSuscripRevistas.columns(4).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDincydetArchivoPublicaSuscripRevistas.columns(4).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DincydetArchivoPublicaSuscripRevistas/Mostrar?Id=' + Id, [], function (ArchivoPublicaSuscripRevistasDTO) {
        $('#txtCodigo').val(ArchivoPublicaSuscripRevistasDTO.archivoPublicaSuscripRevistaId);
        $('#txtNombreArticuloe').val(ArchivoPublicaSuscripRevistasDTO.nombreArticuloRevista);
        $('#txtTpoArticuloe').val(ArchivoPublicaSuscripRevistasDTO.tipoArticuloRevista);
        $('#cbAreasCTe').val(ArchivoPublicaSuscripRevistasDTO.codigoAreaCT);
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
                url: '/DincydetArchivoPublicaSuscripRevistas/Eliminar',
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
                    $('#tblDincydetArchivoPublicaSuscripRevistas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDincydetArchivoPublicaSuscripRevistas() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DincydetArchivoPublicaSuscripRevistas/MostrarDatos',
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
                            $("<td>").text(item.nombreArticuloRevista),
                            $("<td>").text(item.tipoArticuloRevista),
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
    fetch("DincydetArchivoPublicaSuscripRevistas/EnviarDatos", {
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
                url: '/DincydetArchivoPublicaSuscripRevistas/EliminarCarga',
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
                    $('#tblDincydetArchivoPublicaSuscripRevistas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DincydetArchivoPublicaSuscripRevistas/cargaCombs', [], function (Json) {
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

    reporteSeleccionado = '/DincydetArchivoPublicaSuscripRevistas/ReporteARTR';
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
