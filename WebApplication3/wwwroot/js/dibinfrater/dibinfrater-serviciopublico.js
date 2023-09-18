var tblDibinfraterServicioPublico;
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
                                url: '/DibinfraterServicioPublico/Insertar',
                                data: {
                                    'AnioPagoServicio': $('#txtAnioPagoServicio').val(),
                                    'NumericoMes': $('#cbMes').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuenteFinanciamiento').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoTipoServicioPublico': $('#cbTipoServicioPublico').val(),
                                    'SuministroUnico': $('#txtSuministroUnico').val(),
                                    'AsignacionMensual': $('#txtAsignacionMensual').val(),
                                    'ConsumoMensual': $('#txtConsumoMensual').val(),
                                    'ConsumoUnidadMedida': $('#txtConsumoUnidadMedida').val(),
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
                                    $('#tblDibinfraterServicioPublico').DataTable().ajax.reload();
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
                                url: '/DibinfraterServicioPublico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioPagoServicio': $('#txtAnioPagoServicioe').val(),
                                    'NumericoMes': $('#cbMese').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuenteFinanciamientoe').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoTipoServicioPublico': $('#cbTipoServicioPublicoe').val(),
                                    'SuministroUnico': $('#txtSuministroUnicoe').val(),
                                    'AsignacionMensual': $('#txtAsignacionMensuale').val(),
                                    'ConsumoMensual': $('#txtConsumoMensuale').val(),
                                    'ConsumoUnidadMedida': $('#txtConsumoUnidadMedidae').val(), 
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
                                    $('#tblDibinfraterServicioPublico').DataTable().ajax.reload();
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

   tblDibinfraterServicioPublico = $('#tblDibinfraterServicioPublico').DataTable({
        ajax: {
            "url": '/DibinfraterServicioPublico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioPublicoId" },
            { "data": "anioPagoServicio" },
            { "data": "descMes" },
            { "data": "descFuenteFinanciamiento" },
            { "data": "descZonaNaval" },
            { "data": "descDependencia" },
            { "data": "descTipoServicioPublico" },
            { "data": "suministroUnico" },
            { "data": "asignacionMensual" },
            { "data": "consumoMensual" },
            { "data": "consumoUnidadMedida" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioPublicoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioPublicoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dibinfrater - Servicios Públicos',
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
                filename: 'Dibinfrater - Servicios Públicos',
                title: 'Dibinfrater - Servicios Públicos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dibinfrater - Servicios Públicos',
                title: 'Dibinfrater - Servicios Públicos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dibinfrater - Servicios Públicos',
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
    tblDibinfraterServicioPublico.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDibinfraterServicioPublico.columns(11).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DibinfraterServicioPublico/Mostrar?Id=' + Id, [], function (ServicioPublicoDTO) {
        $('#txtCodigo').val(ServicioPublicoDTO.servicioPublicoId);
        $('#txtAnioPagoServicioe').val(ServicioPublicoDTO.anioPagoServicio);
        $('#cbMese').val(ServicioPublicoDTO.numericoMes);
        $('#cbFuenteFinanciamientoe').val(ServicioPublicoDTO.codigoFuenteFinanciamiento);
        $('#cbZonaNavale').val(ServicioPublicoDTO.codigoZonaNaval);
        $('#cbDependenciae').val(ServicioPublicoDTO.codigoDependencia);
        $('#cbTipoServicioPublicoe').val(ServicioPublicoDTO.codigoTipoServicioPublico);
        $('#txtSuministroUnicoe').val(ServicioPublicoDTO.suministroUnico);
        $('#txtAsignacionMensuale').val(ServicioPublicoDTO.asignacionMensual);
        $('#txtConsumoMensuale').val(ServicioPublicoDTO.consumoMensual);
        $('#txtConsumoUnidadMedidae').val(ServicioPublicoDTO.consumoUnidadMedida); 
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
                url: '/DibinfraterServicioPublico/Eliminar',
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
                    $('#tblDibinfraterServicioPublico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDibinfraterServicioPublico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DibinfraterServicioPublico/MostrarDatos',
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
                            $("<td>").text(item.anioPagoServicio),
                            $("<td>").text(item.numericoMes),
                            $("<td>").text(item.codigoFuenteFinanciamiento),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoTipoServicioPublico),
                            $("<td>").text(item.suministroUnico),
                            $("<td>").text(item.asignacionMensual),
                            $("<td>").text(item.consumoMensual),
                            $("<td>").text(item.consumoUnidadMedida)
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
    fetch("DibinfraterServicioPublico/EnviarDatos", {
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
                url: '/DibinfraterServicioPublico/EliminarCarga',
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
                    $('#tblDibinfraterServicioPublico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}


function cargaDatos() {
    $.getJSON('/DibinfraterServicioPublico/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var fuenteFinanciamiento = Json["data2"];
        var zonaNaval = Json["data3"];
        var dependencia = Json["data4"];
        var tipoServicioPublico = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
            $("select#cbMese").append(RowContent);

        });

        $("select#cbFuenteFinanciamiento").html("");
        $("select#cbFuenteFinanciamientoe").html("");
        $.each(fuenteFinanciamiento, function () {
            var RowContent = '<option value=' + this.codigoFuenteFinanciamiento + '>' + this.descFuenteFinanciamiento + '</option>'
            $("select#cbFuenteFinanciamiento").append(RowContent);
            $("select#cbFuenteFinanciamientoe").append(RowContent)
        });


        $("select#cbZonaNaval").html("");
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
            $("select#cbZonaNavale").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbTipoServicioPublico").html("");
        $("select#cbTipoServicioPublicoe").html("");
        $.each(tipoServicioPublico, function () {
            var RowContent = '<option value=' + this.codigoTipoServicioPublico + '>' + this.descTipoServicioPublico + '</option>'
            $("select#cbTipoServicioPublico").append(RowContent);
            $("select#cbTipoServicioPublicoe").append(RowContent);
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