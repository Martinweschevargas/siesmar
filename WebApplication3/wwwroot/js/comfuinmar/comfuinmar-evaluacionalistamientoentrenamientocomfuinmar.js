var tblComfuinmarEvaluacionAlistamientoEntrenamiento;
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
                                url: '/ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'CodigoNivelEntrenamiento': $('#cbNivelEntrenamiento').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativa').val(),
                                    'TipoCapacidadOperativa': $('#txtTipoCapacidadOperativa').val(),
                                    'CodigoEjercicioEntrenamientoAspecto': $('#cbEjercicioEntrenamientoAspecto').val(),
                                    'CodigoCalificativoAsignadoEjercicio': $('#cbCalificativoAsignadoEjercicio').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluar').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicio').val(),
                                    'TiempoVigencia': $('#txtTiempoVigencia').val(),
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
                                    $('#tblComfuinmarEvaluacionAlistamientoEntrenamiento').DataTable().ajax.reload();
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
                                url: '/ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoNivelEntrenamiento': $('#cbNivelEntrenamientoe').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativae').val(),
                                    'TipoCapacidadOperativa': $('#txtTipoCapacidadOperativae').val(),
                                    'CodigoEjercicioEntrenamientoAspecto': $('#cbEjercicioEntrenamientoAspectoe').val(),
                                    'CodigoCalificativoAsignadoEjercicio': $('#cbCalificativoAsignadoEjercicioe').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluare').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicioe').val(),
                                    'TiempoVigencia': $('#txtTiempoVigenciae').val(),
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
                                    $('#tblComfuinmarEvaluacionAlistamientoEntrenamiento').DataTable().ajax.reload();
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

    tblComfuinmarEvaluacionAlistamientoEntrenamiento = $('#tblComfuinmarEvaluacionAlistamientoEntrenamiento').DataTable({
        ajax: {
            "url": '/ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoId" },
            { "data": "descUnidadNaval" },
            { "data": "descNivelEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "tipoCapacidadOperativa" },
            { "data": "codigoEjercicioEntrenamientoAspecto" },
            { "data": "descripcion" },
            { "data": "fechaPeriodoEvaluar" },
            { "data": "fechaRealizacionEjercicio" },
            { "data": "tiempoVigencia" }, 
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionAlistamientoEntrenamientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionAlistamientoEntrenamientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfuinmar-3 - Evaluación del alistamiento del entrenamiento',
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
                filename: 'Comfuinmar-3 - Evaluación del alistamiento del entrenamiento',
                title: 'Comfuinmar-3 - Evaluación del alistamiento del entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfuinmar-3 - Evaluación del alistamiento del entrenamiento',
                title: 'Comfuinmar-3 - Evaluación del alistamiento del entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfuinmar-3 - Evaluación del alistamiento del entrenamiento',
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
    tblComfuinmarEvaluacionAlistamientoEntrenamiento.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfuinmarEvaluacionAlistamientoEntrenamiento.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoEntrenamientoComfuinmarDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.evaluacionAlistamientoEntrenamientoId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.codigoUnidadNaval);
        $('#txtNivelEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.codigoNivelEntrenamiento);
        $('#cbCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.codigoCapacidadOperativa);
        $('#txtTipoCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.tipoCapacidadOperativa);
        $('#cbEjercicioEntrenamientoAspectoe').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.codigoEjercicioEntrenamientoAspecto);
        $('#cbCalificativoAsignadoEjercicioe').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.codigoCalificativoAsignadoEjercicio);
        $('#txtFechaPeriodoEvaluare').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.fechaPeriodoEvaluar);
        $('#txtFechaRealizacionEjercicioe').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.fechaRealizacionEjercicio);
        $('#txtTiempoVigenciae').val(EvaluacionAlistamientoEntrenamientoComfuinmarDTO.tiempoVigencia); 
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
                url: '/ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/Eliminar',
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
                    $('#tblComfuinmarEvaluacionAlistamientoEntrenamiento').DataTable().ajax.reload();
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
                url: '/ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/EliminarCarga',
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
                    $('#tblComfuinmarEvaluacionAlistamientoEntrenamiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.codigoNivelEntrenamiento),
                            $("<td>").text(item.codigoCapacidadOperativa),
                            $("<td>").text(item.tipoCapacidadOperativa),
                            $("<td>").text(item.codigoEjercicioEntrenamientoAspecto),
                            $("<td>").text(item.codigoCalificativoAsignadoEjercicio),
                            $("<td>").text(item.fechaPeriodoEvaluar),
                            $("<td>").text(item.fechaRealizacionEjercicio),
                            $("<td>").text(item.tiempoVigencia)
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
    fetch("ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/EnviarDatos", {
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
    $.getJSON('/ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var nivelEntrenamiento = Json["data2"];
        var capacidadOperativa = Json["data3"];
        var ejercicioEntrenamientoAspecto = Json["data4"];
        var calificativoAsignadoEjercicio = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbNivelEntrenamiento").html("");
        $("select#cbNivelEntrenamientoe").html("");
        $.each(nivelEntrenamiento, function () {
            var RowContent = '<option value=' + this.codigoNivelEntrenamiento + '>' + this.descNivelEntrenamiento + '</option>'
            $("select#cbNivelEntrenamiento").append(RowContent);
            $("select#cbNivelEntrenamientoe").append(RowContent);
        });

        $("select#cbCapacidadOperativa").html("");
        $("select#cbCapacidadOperativae").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativa + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
            $("select#cbCapacidadOperativae").append(RowContent);
        });

        $("select#cbEjercicioEntrenamientoAspecto").html("");
        $("select#cbEjercicioEntrenamientoAspectoe").html("");
        $.each(ejercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.codigoEjercicioEntrenamientoAspecto + '>' + this.codigoEjercicioEntrenamientoAspecto + '</option>'
            $("select#cbEjercicioEntrenamientoAspecto").append(RowContent);
            $("select#cbEjercicioEntrenamientoAspectoe").append(RowContent);
        });

        $("select#cbCalificativoAsignadoEjercicio").html("");
        $("select#cbCalificativoAsignadoEjercicioe").html("");
        $.each(calificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.codigoCalificativoAsignadoEjercicio + '>' + this.descripcion + '</option>'
            $("select#cbCalificativoAsignadoEjercicio").append(RowContent);
            $("select#cbCalificativoAsignadoEjercicioe").append(RowContent);
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

    reporteSeleccionado = '/ComfuinmarEvaluacionAlistamientoEntrenamientoComfuinmar/ReporteARTR';
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

