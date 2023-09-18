var tblDibinfraterActosDisposicionFinal;
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
                                url: '/DibinfraterActosDisposicionFinal/Insertar',
                                data: {
                                    'AnioActoDisposicionFinal': $('#txtAnioActoDisposicionF').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'IdentificacionDisposicionFinal': $('#txtIdentificacionDisposicionF').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreaDiperadmon').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'EstadoTramiteSolicitud': $('#txtEstadoTramiteS').val(),
                                    'CodigoTipoBien': $('#cbTipoBien').val(),
                                    'CodigoMedidaAdaptadaDisposicionFinal': $('#cbMedidaAdaptadaDF').val(),
                                    'CantidadBienes': $('#txtCantidadBienes').val(),
                                    'Monto': $('#txtMonto').val(),
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
                                    $('#tblDibinfraterActosDisposicionFinal').DataTable().ajax.reload();
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
                                url: '/DibinfraterActosDisposicionFinal/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioActoDisposicionFinal': $('#txtAnioActoDisposicionFe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'IdentificacionDisposicionFinal': $('#txtIdentificacionDisposicionFe').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreaDiperadmone').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'EstadoTramiteSolicitud': $('#txtEstadoTramiteSe').val(),
                                    'CodigoTipoBien': $('#cbTipoBiene').val(),
                                    'CodigoMedidaAdaptadaDisposicionFinal': $('#cbMedidaAdaptadaDFe').val(),
                                    'CantidadBienes': $('#txtCantidadBienese').val(),
                                    'Monto': $('#txtMontoe').val(), 
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
                                    $('#tblDibinfraterActosDisposicionFinal').DataTable().ajax.reload();
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

    tblDibinfraterActosDisposicionFinal = $('#tblDibinfraterActosDisposicionFinal').DataTable({
        ajax: {
            "url": '/DibinfraterActosDisposicionFinal/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "actoDisposicionFinalId" },
            { "data": "anioActoDisposicionFinal" },
            { "data": "descMes" },
            { "data": "identificacionDisposicionFinal" },
            { "data": "descAreaDiperadmon" },
            { "data": "descZonaNaval" },
            { "data": "estadoTramiteSolicitud" },
            { "data": "descTipoBien" },
            { "data": "descMedidaAdaptadaDisposicionFinal" },
            { "data": "cantidadBienes" },
            { "data": "monto" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.actoDisposicionFinalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.actoDisposicionFinalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dibinfrater - Actos Disposición Final',
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
                filename: 'Dibinfrater - Actos Disposición Final',
                title: 'Dibinfrater - Actos Disposición Final',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dibinfrater - Actos Disposición Final',
                title: 'Dibinfrater - Actos Disposición Final',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dibinfrater - Actos Disposición Final',
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
    tblDibinfraterActosDisposicionFinal.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblDibinfraterActosDisposicionFinal.columns(11).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DibinfraterActosDisposicionFinal/Mostrar?Id=' + Id, [], function (ActosDisposicionFinalDTO) {
        $('#txtCodigo').val(ActosDisposicionFinalDTO.actoDisposicionFinalId);
        $('#txtAnioActoDisposicionFe').val(ActosDisposicionFinalDTO.anioActoDisposicionFinal);
        $('#cbMese').val(ActosDisposicionFinalDTO.numeroMes);
        $('#txtIdentificacionDisposicionFe').val(ActosDisposicionFinalDTO.identificacionDisposicionFinal);
        $('#cbAreaDiperadmone').val(ActosDisposicionFinalDTO.codigoAreaDiperadmon);
        $('#cbZonaNavale').val(ActosDisposicionFinalDTO.codigoZonaNaval);
        $('#txtEstadoTramiteSe').val(ActosDisposicionFinalDTO.estadoTramiteSolicitud);
        $('#cbTipoBiene').val(ActosDisposicionFinalDTO.codigoTipoBien);
        $('#cbMedidaAdaptadaDFe').val(ActosDisposicionFinalDTO.codigoMedidaAdaptadaDisposicionFinal);
        $('#txtCantidadBienese').val(ActosDisposicionFinalDTO.cantidadBienes);
        $('#txtMontoe').val(ActosDisposicionFinalDTO.monto); 
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
                url: '/DibinfraterActosDisposicionFinal/Eliminar',
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
                    $('#tblDibinfraterActosDisposicionFinal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDibinfraterActosDisposicionFinal() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DibinfraterActosDisposicionFinal/MostrarDatos',
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
                            $("<td>").text(item.anioActoDisposicionFinal),
                            $("<td>").text(item.numeroMes),
                            $("<td>").text(item.identificacionDisposicionFinal),
                            $("<td>").text(item.codigoAreaDiperadmon),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.estadoTramiteSolicitud),
                            $("<td>").text(item.codigoTipoBien),
                            $("<td>").text(item.codigoMedidaAdaptadaDisposicionFinal),
                            $("<td>").text(item.cantidadBienes),
                            $("<td>").text(item.monto)

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
    fetch("DibinfraterActosDisposicionFinal/EnviarDatos", {
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
                url: '/DibinfraterActosDisposicionFinal/EliminarCarga',
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
                    $('#tblDibinfraterActosDisposicionFinal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DibinfraterActosDisposicionFinal/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var areaDiperadmon = Json["data2"];
        var zonaNaval = Json["data3"];
        var tipoBien = Json["data4"];
        var medidaAdaptadaDisposicionFinal = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
            $("select#cbMese").append(RowContent);
        });

        $("select#cbAreaDiperadmon").html("");
        $("select#cbAreaDiperadmone").html("");
        $.each(areaDiperadmon, function () {
            var RowContent = '<option value=' + this.codigoAreaDiperadmon + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbAreaDiperadmon").append(RowContent);
            $("select#cbAreaDiperadmone").append(RowContent);
        });

        $("select#cbZonaNaval").html("");
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
            $("select#cbZonaNavale").append(RowContent);
        });

        $("select#cbTipoBien").html("");
        $("select#cbTipoBiene").html("");
        $.each(tipoBien, function () {
            var RowContent = '<option value=' + this.codigoTipoBien + '>' + this.descTipoBien + '</option>'
            $("select#cbTipoBien").append(RowContent);
            $("select#cbTipoBiene").append(RowContent);
        });

        $("select#cbMedidaAdaptadaDF").html("");
        $("select#cbMedidaAdaptadaDFe").html("");
        $.each(medidaAdaptadaDisposicionFinal, function () {
            var RowContent = '<option value=' + this.codigoMedidaAdaptadaDisposicionFinal + '>' + this.descMedidaAdaptadaDisposicionFinal + '</option>'
            $("select#cbMedidaAdaptadaDF").append(RowContent);
            $("select#cbMedidaAdaptadaDFe").append(RowContent);
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

//function optReporte(id) {
//    optReporteSelect = id;
//    if (id == 1) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCA';
//        $('#accionAnteCiberataque').hide();
//        $('#tipoCiberataque').hide();
//        $('#fechaInicio').hide();
//        $('#fechaTermino').hide();
//    }
//    if (id == 2) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCXSSA';
//        $('#accionAnteCiberataque').show();
//        $('#tipoCiberataque').hide();
//        $('#fechaInicio').show();
//        $('#fechaTermino').show();
//    }
//    if (id == 3) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCATCA';
//        $('#tipoCiberataque').show();
//        $('#accionAnteCiberataque').hide();
//        $('#fechaInicio').show();
//        $('#fechaTermino').show();
//    }
//}

//$('#btnReportView').click(function () {
//    var idCarga = $('select#cargas').val();
//    var numCarga;
//    if (idCarga == "0") {
//        numCarga = "";
//    } else {
//        numCarga = 'CargaId=' + idCarga;
//    }
//    var a = document.createElement('a');
//    a.target = "_blank";
//    if (optReporteSelect == 1) {
//        a.href = reporteSeleccionado + '?' + numCarga;
//    }
//    if (optReporteSelect == 2) {
//        a.href = reporteSeleccionado + '?accionAnteCiberataque=' + $('#txtAccionAnteCiberA').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
//    }
//    if (optReporteSelect == 3) {
//        a.href = reporteSeleccionado + '?tipoCiberataque=' + $('#txtCiberAtaque').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
//    }
//    a.click();
//});