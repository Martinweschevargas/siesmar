var tblDibinfraterEvaluacionExpedienteTecnicoObra;
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
                                url: '/DibinfraterEvaluacionExpedienteTecnicoObra/Insertar',
                                data: {
                                    'NombreProyecto': $('#txtNombreProyecto').val(),
                                    'CodigoSituacionExpedienteTecnico': $('#cbSituacionExpedienteT').val(),
                                    'CodigoTipoProceso': $('#cbTipoProceso').val(),
                                    'CodigoTipoProyecto': $('#cbTipoProyecto').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreaDiperadmon').val(),
                                    'MontoContractual': $('#txtMontoContractual').val(),
                                    'FechaInicioEvaluacionProyecto': $('#txtFechaIEvaluacionP').val(),
                                    'PorcentajeAvanceProyecto': $('#txtPorcentajeAvanceP').val(),
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
                                    $('#tblDibinfraterEvaluacionExpedienteTecnicoObra').DataTable().ajax.reload();
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
                                url: '/DibinfraterEvaluacionExpedienteTecnicoObra/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NombreProyecto': $('#txtNombreProyectoe').val(),
                                    'CodigoSituacionExpedienteTecnico': $('#cbSituacionExpedienteTe').val(),
                                    'CodigoTipoProceso': $('#cbTipoProcesoe').val(),
                                    'CodigoTipoProyecto': $('#cbTipoProyectoe').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreaDiperadmone').val(),
                                    'MontoContractual': $('#txtMontoContractuale').val(),
                                    'FechaInicioEvaluacionProyecto': $('#txtFechaIEvaluacionPe').val(),
                                    'PorcentajeAvanceProyecto': $('#txtPorcentajeAvancePe').val(), 
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
                                    $('#tblDibinfraterEvaluacionExpedienteTecnicoObra').DataTable().ajax.reload();
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

  tblDibinfraterEvaluacionExpedienteTecnicoObra = $('#tblDibinfraterEvaluacionExpedienteTecnicoObra').DataTable({
        ajax: {
            "url": '/DibinfraterEvaluacionExpedienteTecnicoObra/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionExpedienteTecnicoObraId" },
            { "data": "nombreProyecto" },
            { "data": "descSituacionExpedienteTecnico" },
            { "data": "descTipoProceso" },
            { "data": "descTipoProyecto" },
            { "data": "descZonaNaval" },
            { "data": "descAreaDiperadmon" },
            { "data": "montoContractual" },
            { "data": "fechaInicioEvaluacionProyecto" },
            { "data": "porcentajeAvanceProyecto" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionExpedienteTecnicoObraId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionExpedienteTecnicoObraId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dibinfrater - Evaluación Expedientes Técnicos de Obras, PIP (Proyecto de Inversión Pública) y Planos Pilotos',
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
                filename: 'Dibinfrater - Evaluación Expedientes Técnicos de Obras, PIP (Proyecto de Inversión Pública) y Planos Pilotos',
                title: 'Dibinfrater - Evaluación Expedientes Técnicos de Obras, PIP (Proyecto de Inversión Pública) y Planos Pilotos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dibinfrater - Evaluación Expedientes Técnicos de Obras, PIP (Proyecto de Inversión Pública) y Planos Pilotos',
                title: 'Dibinfrater - Evaluación Expedientes Técnicos de Obras, PIP (Proyecto de Inversión Pública) y Planos Pilotos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dibinfrater - Evaluación Expedientes Técnicos de Obras, PIP (Proyecto de Inversión Pública) y Planos Pilotos',
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
    tblDibinfraterEvaluacionExpedienteTecnicoObra.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDibinfraterEvaluacionExpedienteTecnicoObra.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DibinfraterEvaluacionExpedienteTecnicoObra/Mostrar?Id=' + Id, [], function (EvaluacionExpedienteTecnicoObraDTO) {
        $('#txtCodigo').val(EvaluacionExpedienteTecnicoObraDTO.evaluacionExpedienteTecnicoObraId);
        $('#txtNombreProyectoe').val(EvaluacionExpedienteTecnicoObraDTO.nombreProyecto);
        $('#cbSituacionExpedienteTe').val(EvaluacionExpedienteTecnicoObraDTO.codigoSituacionExpedienteTecnico);
        $('#cbTipoProcesoe').val(EvaluacionExpedienteTecnicoObraDTO.codigoTipoProceso);
        $('#cbTipoProyectoe').val(EvaluacionExpedienteTecnicoObraDTO.codigoTipoProyecto);
        $('#cbZonaNavale').val(EvaluacionExpedienteTecnicoObraDTO.codigoZonaNaval);
        $('#cbAreaDiperadmone').val(EvaluacionExpedienteTecnicoObraDTO.codigoAreaDiperadmon);
        $('#txtMontoContractuale').val(EvaluacionExpedienteTecnicoObraDTO.montoContractual);
        $('#txtFechaIEvaluacionPe').val(EvaluacionExpedienteTecnicoObraDTO.fechaInicioEvaluacionProyecto);
        $('#txtPorcentajeAvancePe').val(EvaluacionExpedienteTecnicoObraDTO.porcentajeAvanceProyecto); 
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
                url: '/DibinfraterEvaluacionExpedienteTecnicoObra/Eliminar',
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
                    $('#tblDibinfraterEvaluacionExpedienteTecnicoObra').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDibinfraterEvaluacionExpedienteTecnicoObra() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DibinfraterEvaluacionExpedienteTecnicoObra/MostrarDatos',
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
                            $("<td>").text(item.nombreProyecto),
                            $("<td>").text(item.codigoSituacionExpedienteTecnico),
                            $("<td>").text(item.codigoTipoProceso),
                            $("<td>").text(item.codigoTipoProyecto),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoAreaDiperadmon),
                            $("<td>").text(item.montoContractual),
                            $("<td>").text(item.fechaInicioEvaluacionProyecto),
                            $("<td>").text(item.porcentajeAvanceProyecto)
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
    fetch("DibinfraterEvaluacionExpedienteTecnicoObra/EnviarDatos", {
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
                url: '/DibinfraterEvaluacionExpedienteTecnicoObra/EliminarCarga',
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
                    $('#tblDibinfraterEvaluacionExpedienteTecnicoObra').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}


function cargaDatos() {
    $.getJSON('/DibinfraterEvaluacionExpedienteTecnicoObra/cargaCombs', [], function (Json) {
        var situacionExpedienteTecnico = Json["data1"];
        var tipoProceso = Json["data2"];
        var tipoProyecto = Json["data3"];
        var zonaNaval = Json["data4"];
        var areaDiperadmon = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbSituacionExpedienteT").html("");
        $("select#cbSituacionExpedienteTe").html("");
        $.each(situacionExpedienteTecnico, function () {
            var RowContent = '<option value=' + this.codigoSituacionExpedienteTecnico + '>' + this.descSituacionExpedienteTecnico + '</option>'
            $("select#cbSituacionExpedienteT").append(RowContent);
            $("select#cbSituacionExpedienteTe").append(RowContent);
        });

        $("select#cbTipoProceso").html("");
        $("select#cbTipoProcesoe").html("");
        $.each(tipoProceso, function () {
            var RowContent = '<option value=' + this.codigoTipoProceso + '>' + this.descTipoProceso + '</option>'
            $("select#cbTipoProceso").append(RowContent);
            $("select#cbTipoProcesoe").append(RowContent);
        });

        $("select#cbTipoProyecto").html("");
        $("select#cbTipoProyectoe").html("");
        $.each(tipoProyecto, function () {
            var RowContent = '<option value=' + this.codigoTipoProyecto + '>' + this.descTipoProyecto + '</option>'
            $("select#cbTipoProyecto").append(RowContent);
            $("select#cbTipoProyectoe").append(RowContent);
        });

        $("select#cbZonaNaval").html("");
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
            $("select#cbZonaNavale").append(RowContent);
        });


        $("select#cbAreaDiperadmon").html("");
        $("select#cbAreaDiperadmone").html("");
        $.each(areaDiperadmon, function () {
            var RowContent = '<option value=' + this.codigoAreaDiperadmon + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbAreaDiperadmon").append(RowContent);
            $("select#cbAreaDiperadmone").append(RowContent);
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