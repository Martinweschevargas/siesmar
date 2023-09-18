var tblProcumarRegistroCasosProcuraduria;
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
                                url: '/ProcumarRegistroCasosProcuraduria/Insertar',
                                data: {
                                    'AñoDemanda': $('#txtNombreAbogado').val(),
                                    'MesDemanda': $('#txtMesDemanda').val(),
                                    'CodigoAreaProcumar': $('#txtAreaProcumar').val(),
                                    'NombreAbogado': $('#txtNombreAbogado').val(),
                                    'NroExpediente': $('#txtNroExpediente').val(),
                                    'NroCodInterno': $('#txtNroCodInterno').val(),
                                    'NombreDemandante': $('#txtNombreDemandante').val(),
                                    'NombreDemandado': $('#txtNombreDemandado').val(),
                                    'CodigoGradoPersonal': $('#cbGradoPersonal').val(),
                                    'CodigoEspecialidadPersonal': $('#cbEspecialidadPersonal').val(),
                                    'CodigoMateriaProcumar': $('#cbMateriaProcumar').val(),
                                    'Petitorio': $('#txtPetitorio').val(),
                                    'CodigoDistritoJudicial': $('#cbDistritoJudicial').val(),
                                    'CodigoInstanciaJudicial': $('#cbInstanciaJudicial').val(),
                                    'CodigoCasoExcepcional': $('#cbCasoExcepcional').val(),
                                    'UltimoActuado': $('#txtUltimoActuado').val(),
                                    'CodigoEstadoProceso': $('#cbEstadoProceso').val(),
                                    'SentenciaEjecutoria': $('#txtSentenciaEjecutoria').val(),
                                    'AñoTerminoProceso': $('#txtAnioTerminoP').val(),
                                    'MonedaId': $('#cbMoneda').val(),
                                    'MontoPretencion': $('#txtMontoPretencion').val(),
                                    'CargaId': $('#cargasR').val()

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
                                    $('#tblProcumarRegistroCasosProcuraduria').DataTable().ajax.reload();
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
                                url: '/ProcumarRegistroCasosProcuraduria/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AñoDemanda': $('#txtNombreAbogadoe').val(),
                                    'MesDemanda': $('#txtMesDemandae').val(),
                                    'CodigoAreaProcumar': $('#txtAreaProcumare').val(),
                                    'NombreAbogado': $('#txtNombreAbogadoe').val(),
                                    'NroExpediente': $('#txtNroExpedientee').val(),
                                    'NroCodInterno': $('#txtNroCodInternoe').val(),
                                    'NombreDemandante': $('#txtNombreDemandantee').val(),
                                    'NombreDemandado': $('#txtNombreDemandadoe').val(),
                                    'CodigoGradoPersonal': $('#cbGradoPersonale').val(),
                                    'CodigoEspecialidadPersonal': $('#cbEspecialidadPersonale').val(),
                                    'CodigoMateriaProcumar': $('#cbMateriaProcumare').val(),
                                    'Petitorio': $('#txtPetitorioe').val(),
                                    'CodigoDistritoJudicial': $('#cbDistritoJudiciale').val(),
                                    'CodigoInstanciaJudicial': $('#cbInstanciaJudiciale').val(),
                                    'CodigoCasoExcepcional': $('#cbCasoExcepcionale').val(),
                                    'UltimoActuado': $('#txtUltimoActuadoe').val(),
                                    'CodigoEstadoProceso': $('#cbEstadoProcesoe').val(),
                                    'SentenciaEjecutoria': $('#txtSentenciaEjecutoriae').val(),
                                    'AñoTerminoProceso': $('#txtAnioTerminoPe').val(),
                                    'MonedaId': $('#cbMonedae').val(),
                                    'MontoPretencion': $('#txtMontoPretencione').val(),
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
                                    $('#tblProcumarRegistroCasosProcuraduria').DataTable().ajax.reload();
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

   tblProcumarRegistroCasosProcuraduria = $('#tblProcumarRegistroCasosProcuraduria').DataTable({
        ajax: {
            "url": '/ProcumarRegistroCasosProcuraduria/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroCasosProcuraduriaId" },
            { "data": "añoDemanda" },
            { "data": "mesDemanda" },
            { "data": "codigoAreaProcumar" },
            { "data": "nombreAbogado" },
            { "data": "nroExpediente" },
            { "data": "nroCodInterno" },
            { "data": "nombreDemandante" },
            { "data": "nombreDemandado" },
            { "data": "descGradoPersonal" },
            { "data": "descEspecialidadPersonal" },
            { "data": "descMateriaProcumar" },
            { "data": "petitorio" },
            { "data": "descDistritoJudicial" },
            { "data": "descInstanciaJudicial" },
            { "data": "descCasoExcepcional" },
            { "data": "ultimoActuado" },
            { "data": "descEstadoProceso" },
            { "data": "sentenciaEjecutoria" },
            { "data": "añoTerminoProceso" },
            { "data": "descMoneda" },
            { "data": "montoPretencion" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroCasosProcuraduriaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroCasosProcuraduriaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Procumar - Registro de Casos de la Procuraduria',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Procumar - Registro de Casos de la Procuraduria',
                title: 'Procumar - Registro de Casos de la Procuraduria',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Procumar - Registro de Casos de la Procuraduria',
                title: 'Procumar - Registro de Casos de la Procuraduria',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Procumar - Registro de Casos de la Procuraduria',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
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
    tblProcumarRegistroCasosProcuraduria.columns(23).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblProcumarRegistroCasosProcuraduria.columns(23).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ProcumarRegistroCasosProcuraduria/Mostrar?Id=' + Id, [], function (RegistroCasosProcuraduriaDTO) {
        $('#txtCodigo').val(RegistroCasosProcuraduriaDTO.registroCasosProcuraduriaId);
        $('#txtAnioDemandae').val(RegistroCasosProcuraduriaDTO.añoDemanda);
        $('#txtMesDemandae').val(RegistroCasosProcuraduriaDTO.mesDemanda);
        $('#txtAreaProcumare').val(RegistroCasosProcuraduriaDTO.codigoAreaProcumar);
        $('#txtNombreAbogadoe').val(RegistroCasosProcuraduriaDTO.nombreAbogado);
        $('#txtNroExpedientee').val(RegistroCasosProcuraduriaDTO.nroExpediente);
        $('#txtNroCodInternoe').val(RegistroCasosProcuraduriaDTO.nroCodInterno);
        $('#txtNombreDemandantee').val(RegistroCasosProcuraduriaDTO.nombreDemandante);
        $('#txtNombreDemandadoe').val(RegistroCasosProcuraduriaDTO.nombreDemandado);
        $('#cbGradoPersonale').val(RegistroCasosProcuraduriaDTO.codigoGradoPersonal);
        $('#cbEspecialidadPersonale').val(RegistroCasosProcuraduriaDTO.codigoEspecialidadPersonal);
        $('#cbMateriaProcumare').val(RegistroCasosProcuraduriaDTO.codigoMateriaProcumar);
        $('#txtPetitorioe').val(RegistroCasosProcuraduriaDTO.petitorio);
        $('#cbDistritoJudiciale').val(RegistroCasosProcuraduriaDTO.codigoDistritoJudicial);
        $('#cbInstanciaJudiciale').val(RegistroCasosProcuraduriaDTO.codigoInstanciaJudicial);
        $('#cbCasoExcepcionale').val(RegistroCasosProcuraduriaDTO.codigoCasoExcepcional);
        $('#txtUltimoActuadoe').val(RegistroCasosProcuraduriaDTO.ultimoActuado);
        $('#cbEstadoProcesoe').val(RegistroCasosProcuraduriaDTO.codigoEstadoProceso);
        $('#txtSentenciaEjecutoriae').val(RegistroCasosProcuraduriaDTO.sentenciaEjecutoria);
        $('#txtAnioTerminoPe').val(RegistroCasosProcuraduriaDTO.añoTerminoProceso);
        $('#cbMonedae').val(RegistroCasosProcuraduriaDTO.monedaId);
        $('#txtMontoPretencione').val(RegistroCasosProcuraduriaDTO.montoPretencion);
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
                url: '/ProcumarRegistroCasosProcuraduria/Eliminar',
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
                    $('#tblProcumarRegistroCasosProcuraduria').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaProcumarRegistroCasosProcuraduria() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ProcumarRegistroCasosProcuraduria/MostrarDatos',
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
                            $("<td>").text(item.anioDemanda),
                            $("<td>").text(item.mesDemanda),
                            $("<td>").text(item.codigoAreaProcumar),
                            $("<td>").text(item.nombreAbogado),
                            $("<td>").text(item.nroExpediente),
                            $("<td>").text(item.nroCodInterno),
                            $("<td>").text(item.nombreDemandante),
                            $("<td>").text(item.nombreDemandado),
                            $("<td>").text(item.codigoGradoPersonal),
                            $("<td>").text(item.codigoEspecialidadPersonal),
                            $("<td>").text(item.codigoMateriaProcumar),
                            $("<td>").text(item.petitorio),
                            $("<td>").text(item.codigoDistritoJudicial),
                            $("<td>").text(item.codigoInstanciaJudicial),
                            $("<td>").text(item.codigoCasoExcepcional),
                            $("<td>").text(item.ultimoActuado),
                            $("<td>").text(item.codigoEstadoProceso),
                            $("<td>").text(item.sentenciaEjecutoria),
                            $("<td>").text(item.anioTerminoProceso),
                            $("<td>").text(item.monedaId),
                            $("<td>").text(item.montoPretencion)
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
    fetch("ProcumarRegistroCasosProcuraduria/EnviarDatos", {
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
    $.getJSON('/ProcumarRegistroCasosProcuraduria/cargaCombs', [], function (Json) {
        var gradoPersonalDTO = Json["data1"];
        var especialidadPersonalDTO = Json["data2"];
        var materiaProcumarDTO = Json["data3"];
        var distritoJudicialDTO = Json["data4"];
        var instanciaJudicialDTO = Json["data5"];
        var casoExcepcionalDTO = Json["data6"];
        var estadoProcesoDTO = Json["data7"];
        var areaProcumarDTO = Json["data8"];
        var listaCargas = Json["data9"];

        $("select#cbGradoPersonal").html("");
        $.each(gradoPersonalDTO, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonal + '>' + this.descGradoPersonal + '</option>'
            $("select#cbGradoPersonal").append(RowContent);
        });
        $("select#cbGradoPersonale").html("");
        $.each(gradoPersonalDTO, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonal + '>' + this.descGradoPersonal + '</option>'
            $("select#cbGradoPersonale").append(RowContent);
        });

        $("select#cbEspecialidadPersonal").html("");
        $.each(especialidadPersonalDTO, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadPersonal + '>' + this.descEspecialidadPersonal + '</option>'
            $("select#cbEspecialidadPersonal").append(RowContent);
        });
        $("select#cbEspecialidadPersonale").html("");
        $.each(especialidadPersonalDTO, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadPersonal + '>' + this.descEspecialidadPersonal + '</option>'
            $("select#cbEspecialidadPersonale").append(RowContent);
        });

        $("select#cbMateriaProcumar").html("");
        $.each(materiaProcumarDTO, function () {
            var RowContent = '<option value=' + this.codigoMateriaProcumar + '>' + this.descMateriaProcumar + '</option>'
            $("select#cbMateriaProcumar").append(RowContent);
        });
        $("select#cbMateriaProcumare").html("");
        $.each(materiaProcumarDTO, function () {
            var RowContent = '<option value=' + this.codigoMateriaProcumar + '>' + this.descMateriaProcumar + '</option>'
            $("select#cbMateriaProcumare").append(RowContent);
        });

        $("select#cbDistritoJudicial").html("");
        $.each(distritoJudicialDTO, function () {
            var RowContent = '<option value=' + this.codigoDistritoJudicial + '>' + this.descDistritoJudicial + '</option>'
            $("select#cbDistritoJudicial").append(RowContent);
        });
        $("select#cbDistritoJudiciale").html("");
        $.each(distritoJudicialDTO, function () {
            var RowContent = '<option value=' + this.codigoDistritoJudicial + '>' + this.descDistritoJudicial + '</option>'
            $("select#cbDistritoJudiciale").append(RowContent);
        });

        $("select#cbInstanciaJudicial").html("");
        $.each(instanciaJudicialDTO, function () {
            var RowContent = '<option value=' + this.codigoInstanciaJudicial + '>' + this.descInstanciaJudicial + '</option>'
            $("select#cbInstanciaJudicial").append(RowContent);
        });
        $("select#cbInstanciaJudiciale").html("");
        $.each(instanciaJudicialDTO, function () {
            var RowContent = '<option value=' + this.codigoInstanciaJudicial + '>' + this.descInstanciaJudicial + '</option>'
            $("select#cbInstanciaJudiciale").append(RowContent);
        });

        $("select#cbCasoExcepcional").html("");
        $.each(casoExcepcionalDTO, function () {
            var RowContent = '<option value=' + this.codigoCasoExcepcional + '>' + this.descCasoExcepcional + '</option>'
            $("select#cbCasoExcepcional").append(RowContent);
        });
        $("select#cbCasoExcepcionale").html("");
        $.each(casoExcepcionalDTO, function () {
            var RowContent = '<option value=' + this.codigoCasoExcepcional + '>' + this.descCasoExcepcional + '</option>'
            $("select#cbCasoExcepcionale").append(RowContent);
        });

        $("select#cbEstadoProceso").html("");
        $.each(estadoProcesoDTO, function () {
            var RowContent = '<option value=' + this.codigoEstadoProceso + '>' + this.descEstadoProceso + '</option>'
            $("select#cbEstadoProceso").append(RowContent);
        });
        $("select#cbEstadoProcesoe").html("");
        $.each(estadoProcesoDTO, function () {
            var RowContent = '<option value=' + this.codigoEstadoProceso + '>' + this.descEstadoProceso + '</option>'
            $("select#cbEstadoProcesoe").append(RowContent);
        });

        $("select#cbMoneda").html("");
        $.each(areaProcumarDTO, function () {
            var RowContent = '<option value=' + this.codigoAreaProcumarDTO + '>' + this.descAreaProcumar + '</option>'
            $("select#cbMoneda").append(RowContent);
        });
        $("select#cbMonedae").html("");
        $.each(areaProcumarDTO, function () {
            var RowContent = '<option value=' + this.codigoAreaProcumarDTO + '>' + this.descAreaProcumar + '</option>'
            $("select#cbMonedae").append(RowContent);
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
        reporteSeleccionado = '/ProcumarRegistroCasosProcuraduria/ReporteACC?CargaId=';
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
