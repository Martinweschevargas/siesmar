var tblDircomatProcesoSeleccionContratacion;
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
                                url: '/DircomatProcesoSeleccionContratacion/Insertar',
                                data: {
                                    'NumeroMes': $('#cbMes').val(),
                                    'NroPAC': $('#txtNroPAC').val(),
                                    'CodigoTipoSeleccion': $('#cbTipoSeleccion').val(),
                                    'CodigoEntidadConvocante': $('#cbEntidadConvocante').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuenteFin').val(),
                                    'CodigoObjetoContratacion': $('#cbObjetoContratacion').val(),
                                    'CodigoMoneda': $('#cbMoneda').val(),
                                    'MontoProcesoSiacomar': $('#txtMontoProcesoS').val(),
                                    'CodigoSubUnidadEjecutora': $('#cbSubunidadE').val(),
                                    'CodigoAreaTecnica': $('#cbAreaTecnica').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreaUsuaria').val(),
                                    'CodigoMonedaReferencia': $('#cbMonedaRef').val(),
                                    'ValorReferencia': $('#txtValorReferencia').val(),
                                    'CodigoObservacionProceso': $('#cbObservacionProceso').val(),
                                    'FechaConvocatoria': $('#txtFechaConvocatoria').val(),
                                    'FechaBuenaPro': $('#txtFechaBuenaPro').val(),
                                    'CodigoMonedaAdjudicado': $('#cbMonedaAdjud').val(),
                                    'MontoAdjudicado': $('#txtMontoAdjudicado').val(),
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
                                    $('#tblDircomatProcesoSeleccionContratacion').DataTable().ajax.reload();
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
                                url: '/DircomatProcesoSeleccionContratacion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'NroPAC': $('#txtNroPACe').val(),
                                    'CodigoTipoSeleccion': $('#cbTipoSeleccione').val(),
                                    'CodigoEntidadConvocante': $('#cbEntidadConvocantee').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuenteFine').val(),
                                    'CodigoObjetoContratacion': $('#cbObjetoContratacione').val(),
                                    'CodigoMoneda': $('#cbMonedae').val(),
                                    'MontoProcesoSiacomar': $('#txtMontoProcesoSe').val(),
                                    'CodigoSubUnidadEjecutora': $('#cbSubunidadEe').val(),
                                    'CodigoAreaTecnica': $('#cbAreaTecnicae').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreaUsuariae').val(),
                                    'CodigoMonedaReferencia': $('#cbMonedaRefe').val(),
                                    'ValorReferencia': $('#txtValorReferenciae').val(),
                                    'CodigoObservacionProceso': $('#cbObservacionProcesoe').val(),
                                    'FechaConvocatoria': $('#txtFechaConvocatoriae').val(),
                                    'FechaBuenaPro': $('#txtFechaBuenaProe').val(),
                                    'CodigoMonedaAdjudicado': $('#cbMonedaAdjude').val(),
                                    'MontoAdjudicado': $('#txtMontoAdjudicadoe').val(),
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
                                    $('#tblDircomatProcesoSeleccionContratacion').DataTable().ajax.reload();
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

  tblDircomatProcesoSeleccionContratacion =  $('#tblDircomatProcesoSeleccionContratacion').DataTable({
        ajax: {
            "url": '/DircomatProcesoSeleccionContratacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "procesoSeleccionContratacionId" },
            { "data": "descMes" },
            { "data": "nroPAC" },
            { "data": "descTipoSeleccion" },
            { "data": "descEntidadConvocante" },
            { "data": "descFuenteFinanciamiento" },
            { "data": "descObjetoContratacion" },
            { "data": "descMoneda" },
            { "data": "montoProcesoSiacomar" },
            { "data": "descSubUnidadEjecutora" },
            { "data": "descAreaTecnica" },
            { "data": "descAreaDiperadmon" },
            { "data": "codigoMonedaReferencia" },
            { "data": "valorReferencia" },
            { "data": "descObservacionProceso" },
            { "data": "fechaConvocatoria" },
            { "data": "fechaBuenaPro" },
            { "data": "codigoMonedaAdjudicado" },
            { "data": "montoAdjudicado" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.procesoSeleccionContratacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.procesoSeleccionContratacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dircomat - Proceso de Selección y Contrataciones',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15,16, 17, 18]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dircomat - Proceso de Selección y Contrataciones',
                title: 'Dircomat - Proceso de Selección y Contrataciones',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dircomat - Proceso de Selección y Contrataciones',
                title: 'Dircomat - Proceso de Selección y Contrataciones',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dircomat - Proceso de Selección y Contrataciones',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
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
    tblDircomatProcesoSeleccionContratacion.columns(19).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblDircomatProcesoSeleccionContratacion.columns(19).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DircomatProcesoSeleccionContratacion/Mostrar?Id=' + Id, [], function (ProcesoSeleccionContratacionDTO) {
        $('#txtCodigo').val(ProcesoSeleccionContratacionDTO.procesoSeleccionContratacionId);
        $('#cbMese').val(ProcesoSeleccionContratacionDTO.numeroMes);
        $('#txtNroPACe').val(ProcesoSeleccionContratacionDTO.nroPAC);
        $('#cbTipoSeleccione').val(ProcesoSeleccionContratacionDTO.codigoTipoSeleccion);
        $('#cbEntidadConvocantee').val(ProcesoSeleccionContratacionDTO.codigoEntidadConvocante);
        $('#cbFuenteFine').val(ProcesoSeleccionContratacionDTO.codigoFuenteFinanciamiento);
        $('#cbObjetoContratacione').val(ProcesoSeleccionContratacionDTO.codigoObjetoContratacion);
        $('#cbMonedae').val(ProcesoSeleccionContratacionDTO.codigoMoneda);
        $('#txtMontoProcesoSe').val(ProcesoSeleccionContratacionDTO.montoProcesoSiacomar);
        $('#cbSubunidadEe').val(ProcesoSeleccionContratacionDTO.codigoSubUnidadEjecutora);
        $('#cbAreaTecnicae').val(ProcesoSeleccionContratacionDTO.codigoAreaTecnica);
        $('#cbAreaUsuariae').val(ProcesoSeleccionContratacionDTO.codigoAreaDiperadmon);
        $('#cbMonedaRefe').val(ProcesoSeleccionContratacionDTO.codigoMonedaReferencia);
        $('#txtValorReferenciae').val(ProcesoSeleccionContratacionDTO.valorReferencia);
        $('#cbObservacionProcesoe').val(ProcesoSeleccionContratacionDTO.codigoObservacionProceso);
        $('#txtFechaConvocatoriae').val(ProcesoSeleccionContratacionDTO.fechaConvocatoria);
        $('#txtFechaBuenaProe').val(ProcesoSeleccionContratacionDTO.fechaBuenaPro);
        $('#cbMonedaAdjude').val(ProcesoSeleccionContratacionDTO.codigoMonedaAdjudicado);
        $('#txtMontoAdjudicadoe').val(ProcesoSeleccionContratacionDTO.montoAdjudicado);
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
                url: '/DircomatProcesoSeleccionContratacion/Eliminar',
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
                    $('#tblDircomatProcesoSeleccionContratacion').DataTable().ajax.reload();
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
                url: '/DircomatProcesoSeleccionContratacion/EliminarCarga',
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
                    cargaDatos();
                    $('#tblDircomatProcesoSeleccionContratacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDircomatProcesoSeleccionContratacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DircomatProcesoSeleccionContratacion/MostrarDatos',
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
                            $("<td>").text(item.numeroMes),
                            $("<td>").text(item.nroPAC),
                            $("<td>").text(item.codigoTipoSeleccion),
                            $("<td>").text(item.codigoEntidadConvocante),
                            $("<td>").text(item.codigoFuenteFinanciamiento),
                            $("<td>").text(item.codigoObjetoContratacion),
                            $("<td>").text(item.codigoMoneda),
                            $("<td>").text(item.montoProcesoSiacomar),
                            $("<td>").text(item.codigoSubUnidadEjecutora),
                            $("<td>").text(item.codigoAreaTecnica),
                            $("<td>").text(item.codigoAreaDiperadmon),
                            $("<td>").text(item.codigoMonedaReferencia),
                            $("<td>").text(item.valorReferencia),
                            $("<td>").text(item.codigoObservacionProceso),
                            $("<td>").text(item.fechaConvocatoria),
                            $("<td>").text(item.fechaBuenaPro),
                            $("<td>").text(item.codigoMonedaAdjudicado),
                            $("<td>").text(item.montoAdjudicado)
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
    fetch("DircomatProcesoSeleccionContratacion/EnviarDatos", {
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
    $.getJSON('/DircomatProcesoSeleccionContratacion/cargaCombs', [], function (Json) {
        var mes= Json["data1"];
        var tipoSeleccion= Json["data2"];
        var entidadConvocante = Json["data3"];
        var fuenteFinanciamiento = Json["data4"];
        var objetoContratacion= Json["data5"];
        var moneda= Json["data6"];
        var subUnidadEjecutora = Json["data7"];
        var areaTecnica= Json["data8"];
        var observacionProceso= Json["data9"];
        var areadiperadmon= Json["data10"];
        var listaCargas = Json["data11"];

        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
            $("select#cbMese").append(RowContent);
        });

        $("select#cbTipoSeleccion").html("");
        $("select#cbTipoSeleccione").html("");
        $.each(tipoSeleccion, function () {
            var RowContent = '<option value=' + this.codigoTipoSeleccion + '>' + this.descTipoSeleccion + '</option>'
            $("select#cbTipoSeleccion").append(RowContent);
            $("select#cbTipoSeleccione").append(RowContent);
        });

        $("select#cbEntidadConvocante").html("");
        $("select#cbEntidadConvocantee").html("");
        $.each(entidadConvocante, function () {
            var RowContent = '<option value=' + this.codigoEntidadConvocante + '>' + this.descEntidadConvocante + '</option>'
            $("select#cbEntidadConvocante").append(RowContent);
            $("select#cbEntidadConvocantee").append(RowContent);
        });

        $("select#cbFuenteFin").html("");
        $("select#cbFuenteFine").html("");
        $.each(fuenteFinanciamiento, function () {
            var RowContent = '<option value=' + this.codigoFuenteFinanciamiento + '>' + this.descFuenteFinanciamiento + '</option>'
            $("select#cbFuenteFin").append(RowContent);
            $("select#cbFuenteFine").append(RowContent);
        });

        $("select#cbObjetoContratacion").html("");
        $("select#cbObjetoContratacione").html("");
        $.each(objetoContratacion, function () {
            var RowContent = '<option value=' + this.codigoObjetoContratacion + '>' + this.descObjetoContratacion + '</option>'
            $("select#cbObjetoContratacion").append(RowContent);
            $("select#cbObjetoContratacione").append(RowContent);
        });

        $("select#cbMoneda").html("");
        $("select#cbMonedae").html("");
        $.each(moneda, function () {
            var RowContent = '<option value=' + this.codigoMoneda + '>' + this.descMoneda + '</option>'
            $("select#cbMoneda").append(RowContent);
            $("select#cbMonedae").append(RowContent);
        });
       
        $("select#cbSubunidadE").html("");
        $("select#cbSubunidadEe").html("");
        $.each(subUnidadEjecutora, function () {
            var RowContent = '<option value=' + this.codigoSubUnidadEjecutora + '>' + this.descSubUnidadEjecutora + '</option>'
            $("select#cbSubunidadE").append(RowContent);
            $("select#cbSubunidadEe").append(RowContent);
        });

        $("select#cbAreaTecnica").html("");
        $("select#cbAreaTecnicae").html("");
        $.each(areaTecnica, function () {
            var RowContent = '<option value=' + this.codigoAreaTecnica + '>' + this.descAreaTecnica + '</option>'
            $("select#cbAreaTecnica").append(RowContent);
            $("select#cbAreaTecnicae").append(RowContent);
        });
     
        $("select#cbObservacionProceso").html("");
        $("select#cbObservacionProcesoe").html("");
        $.each(observacionProceso, function () {
            var RowContent = '<option value=' + this.codigoObservacionProceso + '>' + this.descObservacionProceso + '</option>'
            $("select#cbObservacionProceso").append(RowContent);
            $("select#cbObservacionProcesoe").append(RowContent);
        });
       
        $("select#cbAreaUsuaria").html("");
        $("select#cbAreaUsuariae").html("");
        $.each(areadiperadmon, function () {
            var RowContent = '<option value=' + this.codigoAreaDiperadmon + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbAreaUsuaria").append(RowContent);
            $("select#cbAreaUsuariae").append(RowContent);
        });

        $("select#cbMonedaRef").html("");
        $("select#cbMonedaRefe").html("");
        $.each(moneda, function () {
            var RowContent = '<option value=' + this.codigoMoneda + '>' + this.descMoneda + '</option>'
            $("select#cbMonedaRef").append(RowContent);
            $("select#cbMonedaRefe").append(RowContent);
        });

        $("select#cbMonedaAdjud").html("");
        $("select#cbMonedaAdjude").html("");
        $.each(moneda, function () {
            var RowContent = '<option value=' + this.codigoMoneda + '>' + this.descMoneda + '</option>'
            $("select#cbMonedaAdjud").append(RowContent);
            $("select#cbMonedaAdjude").append(RowContent);
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

    reporteSeleccionado = '/FovimarSolicitudPrestamoHipotecarioNaval/ReporteSPHN';
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