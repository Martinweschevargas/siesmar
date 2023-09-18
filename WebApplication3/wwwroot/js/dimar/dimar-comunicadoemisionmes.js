﻿var tblDimarComunicadoEmisionMes;
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
                                url: '/DimarComunicadoEmisionMes/Insertar',
                                data: {
                                    'FechaEmisionComunicado': $('#txtFechaEmisionComunicado').val(),
                                    'NumeroComunicados': $('#txtNumeroNotasProducidas').val(),
                                    'CodigoTipoInformacionEmitida ': $('#cbTipoInformacionEmitida').val(),
                                    'CodigoPublicoObjetivo ': $('#cbPublicoObjetivo').val(), 
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
                                    $('#tblDimarComunicadoEmisionMes').DataTable().ajax.reload();
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
                                url: '/DimarComunicadoEmisionMes/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaEmisionComunicado': $('#txtFechaEmisionComunicadoe').val(),
                                    'NumeroComunicados': $('#txtNumeroNotasProducidase').val(),
                                    'CodigoTipoInformacionEmitida ': $('#cbTipoInformacionEmitidae').val(),
                                    'CodigoPublicoObjetivo ': $('#cbPublicoObjetivoe').val(), 
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
                                    $('#tblDimarComunicadoEmisionMes').DataTable().ajax.reload();
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

        tblDimarComunicadoEmisionMes=  $('#tblDimarComunicadoEmisionMes').DataTable({
        ajax: {
            "url": '/DimarComunicadoEmisionMes/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "comunicadoEmisionMesId" },
            { "data": "fechaEmisionComunicado" },
            { "data": "NumeroComunicados" },
            { "data": "descTipoInformacionEmitida" },
            { "data": "descPublicoObjetivo" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.comunicadoEmisionMesId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.comunicadoEmisionMesId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dimar - Comunicados (N.º de emisión de comunicados por mes)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dimar - Comunicados (N.º de emisión de comunicados por mes)',
                title: 'Dimar - Comunicados (N.º de emisión de comunicados por mes)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dimar - Comunicados (N.º de emisión de comunicados por mes)',
                title: 'Dimar - Comunicados (N.º de emisión de comunicados por mes)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dimar - Comunicados (N.º de emisión de comunicados por mes)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
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
    tblDimarComunicadoEmisionMes.columns(5).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDimarComunicadoEmisionMes.columns(5).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DimarComunicadoEmisionMes/Mostrar?Id=' + Id, [], function (ComunicadoEmisionMesDTO) {
        $('#txtCodigo').val(ComunicadoEmisionMesDTO.comunicadoEmisionMesId);
        $('#txtFechaEmisionComunicadoe').val(ComunicadoEmisionMesDTO.fechaEmisionComunicado);
        $('#txtNumeroNotasProducidase').val(ComunicadoEmisionMesDTO.numeroComunicados);
        $('#cbTipoInformacionEmitidae').val(ComunicadoEmisionMesDTO.codigoTipoInformacionEmitida);
        $('#cbPublicoObjetivoe').val(ComunicadoEmisionMesDTO.codigoPublicoObjetivo); 
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
                url: '/DimarComunicadoEmisionMes/Eliminar',
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
                    $('#tblDimarComunicadoEmisionMes').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDimarComunicadoEmisionMes() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DimarComunicadoEmisionMes/MostrarDatos',
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
                            $("<td>").text(item.fechaEmisionComunicado),
                            $("<td>").text(item.numeroComunicados),
                            $("<td>").text(item.codigoTipoInformacionEmitida),
                            $("<td>").text(item.codigoPublicoObjetivo),
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
    fetch("DimarComunicadoEmisionMes/EnviarDatos", {
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
    $.getJSON('/DimarComunicadoEmisionMes/cargaCombs', [], function (Json) {
        var tipoInformacionEmitida = Json["data1"];
        var publicoObjetivo = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbTipoInformacionEmitida").html("");
        $.each(tipoInformacionEmitida, function () {
            var RowContent = '<option value=' + this.codigoTipoInformacionEmitida + '>' + this.descTipoInformacionEmitida + '</option>'
            $("select#cbTipoInformacionEmitida").append(RowContent);
        });
        $("select#cbTipoInformacionEmitidae").html("");
        $.each(tipoInformacionEmitida, function () {
            var RowContent = '<option value=' + this.codigoTipoInformacionEmitida + '>' + this.descTipoInformacionEmitida + '</option>'
            $("select#cbTipoInformacionEmitidae").append(RowContent);
        });


        $("select#cbPublicoObjetivo").html("");
        $.each(publicoObjetivo, function () {
            var RowContent = '<option value=' + this.codigoPublicoObjetivo + '>' + this.descPublicoObjetivo + '</option>'
            $("select#cbPublicoObjetivo").append(RowContent);
        });
        $("select#cbPublicoObjetivoe").html("");
        $.each(publicoObjetivo, function () {
            var RowContent = '<option value=' + this.codigoPublicoObjetivo + '>' + this.descPublicoObjetivo + '</option>'
            $("select#cbPublicoObjetivoe").append(RowContent);
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
    if (id == 1) {
        reporteSeleccionado = '/DimarComunicadoEmisionMes/ReporteDCEM?idCarga=';
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