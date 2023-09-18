var tblCombima1EvaluacionAlistEntrenamiento;

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
                                url: '/Combima1EvaluacionAlistEntrenamiento/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamiento').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativa').val(),
                                    'TipoCapacidadOperativo': $('#txtTipoCapacidadOperativo').val(),
                                    'EjercicioEntrenamientoAspectoId': $('#cbEjercicioEntrenamientoAspecto').val(),
                                    'CalificativoAsignadoEjercicioId': $('#cbCalificativoAsignadoEjercicio').val(),
                                    'PuntajeObtenido': $('#txtPuntajeObtenido').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluar').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicio').val(),
                                    'TiempoVigencia': $('#txtTiempoVigencia').val(),
                                    'FechaCaducidadEjercicio': $('#txtFechaCaducidadEjercicio').val(), 
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
                                    $('#tblCombima1EvaluacionAlistEntrenamiento').DataTable().ajax.reload();
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
                                url: '/Combima1EvaluacionAlistEntrenamiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamientoe').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativae').val(),
                                    'TipoCapacidadOperativo': $('#txtTipoCapacidadOperativoe').val(),
                                    'EjercicioEntrenamientoAspectoId': $('#cbEjercicioEntrenamientoAspectoe').val(),
                                    'CalificativoAsignadoEjercicioId': $('#cbCalificativoAsignadoEjercicioe').val(),
                                    'PuntajeObtenido': $('#txtPuntajeObtenidoe').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluare').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicioe').val(),
                                    'TiempoVigencia': $('#txtTiempoVigenciae').val(),
                                    'FechaCaducidadEjercicio': $('#txtFechaCaducidadEjercicioe').val(), 
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
                                    $('#tblCombima1EvaluacionAlistEntrenamiento').DataTable().ajax.reload();
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

    $('#tblCombima1EvaluacionAlistEntrenamiento').DataTable({
        ajax: {
            "url": '/Combima1EvaluacionAlistEntrenamiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoId" },
            { "data": "descUnidadNaval" },
            { "data": "nivelEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "tipoCapacidadOperativo" },
            { "data": "descEjercicioEntrenamientoAspecto" },
            { "data": "descEjercicioEntrenamiento" },
            { "data": "aspectoEvaluacion" },
            { "data": "peso" },
            { "data": "descCalificativoAsignadoEjercicio" },
            { "data": "puntajeObtenido" },
            { "data": "fechaPeriodoEvaluar" },
            { "data": "fechaRealizacionEjercicio" },
            { "data": "tiempoVigencia" },
            { "data": "fechaCaducidadEjercicio" }, 


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
                filename: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                title: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                title: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/Combima1EvaluacionAlistEntrenamiento/Mostrar?Id=' + Id, [], function (EvaluacionAlistEntrenamientoCombima1DTO) {
        $('#txtCodigo').val(EvaluacionAlistEntrenamientoCombima1DTO.evaluacionAlistamientoEntrenamientoId);
        $('#cbUnidadNavale').val(EvaluacionAlistEntrenamientoCombima1DTO.unidadNavalId);
        $('#txtNivelEntrenamientoe').val(EvaluacionAlistEntrenamientoCombima1DTO.nivelEntrenamiento);
        $('#cbCapacidadOperativae').val(EvaluacionAlistEntrenamientoCombima1DTO.capacidadOperativaId);
        $('#txtTipoCapacidadOperativoe').val(EvaluacionAlistEntrenamientoCombima1DTO.tipoCapacidadOperativo);
        $('#cbEjercicioEntrenamientoAspectoe').val(EvaluacionAlistEntrenamientoCombima1DTO.ejercicioEntrenamientoAspectoId);
        $('#txtDescEjercicioEntrenamientoe').val(EvaluacionAlistEntrenamientoCombima1DTO.descEjercicioEntrenamiento);
        $('#txtAspectoEvaluacione').val(EvaluacionAlistEntrenamientoCombima1DTO.aspectoEvaluacion);
        $('#txtPesoe').val(EvaluacionAlistEntrenamientoCombima1DTO.peso);
        $('#cbCalificativoAsignadoEjercicioe').val(EvaluacionAlistEntrenamientoCombima1DTO.calificativoAsignadoEjercicioId);
        $('#txtPuntajeObtenidoe').val(EvaluacionAlistEntrenamientoCombima1DTO.puntajeObtenido);
        $('#txtFechaPeriodoEvaluare').val(EvaluacionAlistEntrenamientoCombima1DTO.fechaPeriodoEvaluar);
        $('#txtFechaRealizacionEjercicioe').val(EvaluacionAlistEntrenamientoCombima1DTO.fechaRealizacionEjercicio);
        $('#txtTiempoVigenciae').val(EvaluacionAlistEntrenamientoCombima1DTO.tiempoVigencia);
        $('#txtFechaCaducidadEjercicioe').val(EvaluacionAlistEntrenamientoCombima1DTO.fechaCaducidadEjercicio); 
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
                url: '/Combima1EvaluacionAlistEntrenamiento/Eliminar',
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
                    $('#tblCombima1EvaluacionAlistEntrenamiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaCombima1EvaluacionAlistEntrenamiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/Combima1EvaluacionAlistEntrenamiento/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var CapacidadOperativa = Json["data2"];
        var EjercicioEntrenamientoAspecto = Json["data3"];
        var CalificativoAsignadoEjercicio = Json["data4"];

        $("select#cbUnidadNaval").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbCapacidadOperativa").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
        });
        $("select#cbCapacidadOperativae").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativae").append(RowContent);
        });


        $("select#cbEjercicioEntrenamientoAspecto").html("");
        $.each(EjercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoAspectoId + '>' + this.descEjercicioEntrenamientoAspecto + '</option>'
            $("select#cbEjercicioEntrenamientoAspecto").append(RowContent);
        });
        $("select#cbEjercicioEntrenamientoAspectoe").html("");
        $.each(EjercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoAspectoId + '>' + this.descEjercicioEntrenamientoAspecto + '</option>'
            $("select#cbEjercicioEntrenamientoAspectoe").append(RowContent);
        });


        $("select#cbCalificativoAsignadoEjercicio").html("");
        $.each(CalificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.calificativoAsignadoEjercicioId + '>' + this.descCalificativoAsignadoEjercicio + '</option>'
            $("select#cbCalificativoAsignadoEjercicio").append(RowContent);
        });
        $("select#cbCalificativoAsignadoEjercicioe").html("");
        $.each(CalificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.calificativoAsignadoEjercicioId + '>' + this.descCalificativoAsignadoEjercicio + '</option>'
            $("select#cbCalificativoAsignadoEjercicioe").append(RowContent);
        }); 

    });
}

