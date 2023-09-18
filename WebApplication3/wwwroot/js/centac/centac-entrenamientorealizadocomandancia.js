var tblCentacEntrenamientoRealizadoComandancia;
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
                                url: '/CentacEntrenamientoRealizadoComandancia/Insertar',
                                data: {
                                    'EventoEntrenamiento': $('#txtEventoEntrenamiento').val(),
                                    'FechaEvento': $('#txtFechaEvento').val(),
                                    'NumeroHoras': $('#txtNumeroHoras').val(),
                                    'EventoProgramado': $('#txtEventoProgramado').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'CodigoTipoOperacion': $('#cbTipoOperacion').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamiento').val(),
                                    'CodigoTipoEjercicio': $('#cbTipoEjercicio').val(),
                                    'FcComunicaciones': $('#txtFcComunicaciones').val(),
                                    'FcPosicionInicial': $('#txtFcPosicionInicial').val(),
                                    'FcFunciones': $('#txtFcFunciones').val(),
                                    'FcAcciones': $('#txtFcAcciones').val(),
                                    'FcAtaque': $('#txtFcAtaque').val(),
                                    'PorcentajeFinalEvaluacion': $('#txtPorcentajeFinalEvaluacion').val(),
                                    'CodigoFormula2CalificativoCentac': $('#cbFor2CalificativoCentac').val(), 
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
                                    $('#tblCentacEntrenamientoRealizadoComandancia').DataTable().ajax.reload();
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
                                url: '/CentacEntrenamientoRealizadoComandancia/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'EventoEntrenamiento': $('#txtEventoEntrenamientoe').val(),
                                    'FechaEvento': $('#txtFechaEventoe').val(),
                                    'NumeroHoras': $('#txtNumeroHorase').val(),
                                    'EventoProgramado': $('#txtEventoProgramadoe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoTipoOperacion': $('#cbTipoOperacione').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamientoe').val(),
                                    'CodigoTipoEjercicio': $('#cbTipoEjercicioe').val(),
                                    'FcComunicaciones': $('#txtFcComunicacionese').val(),
                                    'FcPosicionInicial': $('#txtFcPosicionIniciale').val(),
                                    'FcFunciones': $('#txtFcFuncionese').val(),
                                    'FcAcciones': $('#txtFcAccionese').val(),
                                    'FcAtaque': $('#txtFcAtaquee').val(),
                                    'PorcentajeFinalEvaluacion': $('#txtPorcentajeFinalEvaluacione').val(),
                                    'CodigoFormula2CalificativoCentac': $('#cbFor2CalificativoCentace').val(),
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
                                    $('#tblCentacEntrenamientoRealizadoComandancia').DataTable().ajax.reload();
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


    tblCentacEntrenamientoRealizadoComandancia = $('#tblCentacEntrenamientoRealizadoComandancia').DataTable({
        ajax: {
            "url": '/CentacEntrenamientoRealizadoComandancia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "entrenamientoRealizadoComandanciaId" },
            { "data": "eventoEntrenamiento" },
            { "data": "fechaEvento" },
            { "data": "numeroHoras" },
            { "data": "eventoProgramado" },
            { "data": "nombreDependencia" },
            { "data": "descUnidadNaval" },
            { "data": "descTipoOperacion" },
            { "data": "nivelEntrenamiento" },
            { "data": "descTipoEjercicio" },
            { "data": "fcComunicaciones" },
            { "data": "fcPosicionInicial" },
            { "data": "fcFunciones" },
            { "data": "fcAcciones" },
            { "data": "fcAtaque" },
            { "data": "porcentajeFinalEvaluacion" },
            { "data": "descFormula2CalificativoCentac" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.entrenamientoRealizadoComandanciaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.entrenamientoRealizadoComandanciaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Centac - Entrenamiento Realizado por las Comandancias de las Fuerzas Navales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Centac - Entrenamiento Realizado por las Comandancias de las Fuerzas Navales',
                title: 'Centac - Entrenamiento Realizado por las Comandancias de las Fuerzas Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Centac - Entrenamiento Realizado por las Comandancias de las Fuerzas Navales',
                title: 'Centac - Entrenamiento Realizado por las Comandancias de las Fuerzas Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Centac - Entrenamiento Realizado por las Comandancias de las Fuerzas Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
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
    tblCentacEntrenamientoRealizadoComandancia.columns(17).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblCentacEntrenamientoRealizadoComandancia.columns(17).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CentacEntrenamientoRealizadoComandancia/Mostrar?Id=' + Id, [], function (EntrenamientoRealizadoComandanciaDTO) {
        $('#txtCodigo').val(EntrenamientoRealizadoComandanciaDTO.entrenamientoRealizadoComandanciaId);
        $('#txtEventoEntrenamientoe').val(EntrenamientoRealizadoComandanciaDTO.eventoEntrenamiento);
        $('#txtFechaEventoe').val(EntrenamientoRealizadoComandanciaDTO.fechaEvento);
        $('#txtNumeroHorase').val(EntrenamientoRealizadoComandanciaDTO.numeroHoras);
        $('#txtEventoProgramadoe').val(EntrenamientoRealizadoComandanciaDTO.eventoProgramado);
        $('#cbDependenciae').val(EntrenamientoRealizadoComandanciaDTO.codigoDependencia);
        $('#cbUnidadNavale').val(EntrenamientoRealizadoComandanciaDTO.codigoUnidadNaval);
        $('#cbTipoOperacione').val(EntrenamientoRealizadoComandanciaDTO.codigoTipoOperacion);
        $('#txtNivelEntrenamientoe').val(EntrenamientoRealizadoComandanciaDTO.nivelEntrenamiento);
        $('#cbTipoEjercicioe').val(EntrenamientoRealizadoComandanciaDTO.codigoTipoEjercicio);
        $('#txtFcComunicacionese').val(EntrenamientoRealizadoComandanciaDTO.fcComunicaciones);
        $('#txtFcPosicionIniciale').val(EntrenamientoRealizadoComandanciaDTO.fcPosicionInicial);
        $('#txtFcFuncionese').val(EntrenamientoRealizadoComandanciaDTO.fcFunciones);
        $('#txtFcAccionese').val(EntrenamientoRealizadoComandanciaDTO.fcAcciones);
        $('#txtFcAtaquee').val(EntrenamientoRealizadoComandanciaDTO.fcAtaque);
        $('#txtPorcentajeFinalEvaluacione').val(EntrenamientoRealizadoComandanciaDTO.porcentajeFinalEvaluacion);
        $('#cbFor2CalificativoCentace').val(EntrenamientoRealizadoComandanciaDTO.codigoFormula2CalificativoCentac); 
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
                url: '/CentacEntrenamientoRealizadoComandancia/Eliminar',
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
                    $('#tblCentacEntrenamientoRealizadoComandancia').DataTable().ajax.reload();
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
                url: '/CentacEntrenamientoRealizadoComandancia/EliminarCarga',
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
                    $('#tblCentacEntrenamientoRealizadoComandancia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaCentacEntrenamientoRealizadoComandancia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'CentacEntrenamientoRealizadoComandancia/MostrarDatos',
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
                            $("<td>").text(item.eventoEntrenamiento),
                            $("<td>").text(item.fechaEvento),
                            $("<td>").text(item.numeroHoras),
                            $("<td>").text(item.eventoProgramado),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.codigoTipoOperacion),
                            $("<td>").text(item.nivelEntrenamiento),
                            $("<td>").text(item.codigoTipoEjercicio),
                            $("<td>").text(item.fcComunicaciones),
                            $("<td>").text(item.fcPosicionInicial),
                            $("<td>").text(item.fcFunciones),
                            $("<td>").text(item.fcAcciones),
                            $("<td>").text(item.fcAtaque),
                            $("<td>").text(item.porcentajeFinalEvaluacion),
                            $("<td>").text(item.codigoFormula2CalificativoCentac)
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
    fetch("CentacEntrenamientoRealizadoComandancia/EnviarDatos", {
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
    $.getJSON('/CentacEntrenamientoRealizadoComandancia/cargaCombs', [], function (Json) {
        var dependencia = Json["data1"];
        var unidadNaval = Json["data2"];
        var tipoOperacion = Json["data3"];
        var tipoEjercicio = Json["data4"];
        var formula2CalificativoCentac = Json["data5"];
        var listaCargas = Json["data6"];
 
        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbTipoOperacion").html("");
        $("select#cbTipoOperacione").html("");
        $.each(tipoOperacion, function () {
            var RowContent = '<option value=' + this.codigoTipoOperacion + '>' + this.descTipoOperacion + '</option>'
            $("select#cbTipoOperacion").append(RowContent);
            $("select#cbTipoOperacione").append(RowContent);
        });

        $("select#cbTipoEjercicio").html("");
        $("select#cbTipoEjercicioe").html("");
        $.each(tipoEjercicio, function () {
            var RowContent = '<option value=' + this.codigoTipoEjercicio + '>' + this.descTipoEjercicio + '</option>'
            $("select#cbTipoEjercicio").append(RowContent);
            $("select#cbTipoEjercicioe").append(RowContent);
        });

        $("select#cbFor2CalificativoCentac").html("");
        $("select#cbFor2CalificativoCentace").html("");
        $.each(formula2CalificativoCentac, function () {
            var RowContent = '<option value=' + this.codigoFormula2CalificativoCentac + '>' + this.descFormula2CalificativoCentac + '</option>'
            $("select#cbFor2CalificativoCentac").append(RowContent);
            $("select#cbFor2CalificativoCentace").append(RowContent);
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
    if (id == 1) {
        reporteSeleccionado = '/CentacEntrenamientoRealizadoComandancia/ReporteCERC';
        $('#fecha').hide();
    }

    $('#btnReportView').click(function () {
        var idCarga = $('select#cargas').val();
        var numCarga;
        if (idCarga == "0") {
            numCarga = "";
        } else {
            numCarga = 'CargaId=' + idCarga;
        }
        var a = document.createElement('a');
        a.target = "_blank";
        if (optReporteSelect == 1) {
            a.href = reporteSeleccionado + '?' + numCarga;
        }
        a.click();
    }
    )
};