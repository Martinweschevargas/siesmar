﻿var tblVentaProductoPanaderia;
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
                                url: '/VentaProductoPanaderia/Insertar',
                                data: {
                                    'FechaVenta': $('#txtFechaVenta').val(),
                                    'CodigoPuntoDistribucionPanificacion': $('#cbPtoDistrib').val(),
                                    'CodigoProductoPanificacion': $('#cbProductoPanificacion').val(),
                                    'CantidadProducidaConsumida': $('#txtCantPordConsu').val(),
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
                                    $('#tblVentaProductoPanaderia').DataTable().ajax.reload();
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
                                url: '/VentaProductoPanaderia/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaVenta': $('#txtFechaVentae').val(),
                                    'CodigoPuntoDistribucionPanificacion': $('#cbPtoDistribe').val(),
                                    'CodigoProductoPanificacion': $('#cbProductoPanificacione').val(),
                                    'CantidadProducidaConsumida': $('#txtCantPordConsue').val(),
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
                                    $('#tblVentaProductoPanaderia').DataTable().ajax.reload();
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

    tblVentaProductoPanaderia = $('#tblVentaProductoPanaderia').DataTable({
        ajax: {
            "url": '/VentaProductoPanaderia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ventaProductoPanaderiaId" },
            { "data": "fechaVenta" },
            { "data": "descPuntoDistribucionPanificacion" },
            { "data": "descProductoPanificacion" },
            { "data": "cantidadProducidaConsumida" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ventaProductoPanaderiaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ventaProductoPanaderiaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diabaste - Venta de Productos de Panadería',
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
                filename: 'Diabaste - Venta de Productos de Panadería',
                title: 'Diabaste - Venta de Productos de Panadería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diabaste - Venta de Productos de Panadería',
                title: 'Diabaste - Venta de Productos de Panadería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diabaste - Venta de Productos de Panadería',
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
    tblVentaProductoPanaderia.columns(5).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblVentaProductoPanaderia.columns(5).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/VentaProductoPanaderia/Mostrar?Id=' + Id, [], function (VentaProductoPanaderiaDTO) {
        $('#txtCodigo').val(VentaProductoPanaderiaDTO.ventaProductoPanaderiaId);
        $('#txtFechaVentae').val(VentaProductoPanaderiaDTO.fechaVenta);
        $('#cbPtoDistribe').val(VentaProductoPanaderiaDTO.codigoPuntoDistribucionPanificacion);
        $('#cbProductoPanificacione').val(VentaProductoPanaderiaDTO.codigoProductoPanificacion);
        $('#txtCantPordConsue').val(VentaProductoPanaderiaDTO.cantidadProducidaConsumida);
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
                url: '/VentaProductoPanaderia/Eliminar',
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
                    $('#tblVentaProductoPanaderia').DataTable().ajax.reload();
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
                url: '/VentaProductoPanaderia/EliminarCarga',
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
                    $('#tblVentaProductoPanaderia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaVentaProductoPanaderia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'VentaProductoPanaderia/MostrarDatos',
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
                            $("<td>").text(item.fechaVenta),
                            $("<td>").text(item.codigoPuntoDistribucionPanificacion),
                            $("<td>").text(item.codigoProductoPanificacion),
                            $("<td>").text(item.cantidadProducidaConsumida)
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
    fetch("VentaProductoPanaderia/EnviarDatos", {
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
    $.getJSON('/VentaProductoPanaderia/cargaCombs', [], function (Json) {
        var ptodistro = Json["data1"];
        var prodpani = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbPtoDistrib").html("");
        $("select#cbPtoDistribe").html("");
        $.each(ptodistro, function () {
            var RowContent = '<option value=' + this.codigoPuntoDistribucionPanificacion + '>' + this.descPuntoDistribucionPanificacion + '</option>'
            $("select#cbPtoDistrib").append(RowContent);
            $("select#cbPtoDistribe").append(RowContent);
        });

        $("select#cbProductoPanificacion").html("");
        $("select#cbProductoPanificacione").html("");
        $.each(prodpani, function () {
            var RowContent = '<option value=' + this.codigoProductoPanificacion + '>' + this.descProductoPanificacion + '</option>'
            $("select#cbProductoPanificacion").append(RowContent);
            $("select#cbProductoPanificacione").append(RowContent);
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

    reporteSeleccionado = '/VentaProductoPanaderia/ReporteARTR';
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

