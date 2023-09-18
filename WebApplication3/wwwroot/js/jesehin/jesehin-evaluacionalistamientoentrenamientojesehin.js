var tblJesehinEvaluacionAlistamientoEntrenamientoJesehin;
var ejercicioEntrenamientoAspecto;

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
                                url: '/JesehinEvaluacionAlistamientoEntrenamientoJesehin/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamiento').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativa').val(),
                                    'TipoCapacidadOperativa': $('#txtTipoCapacidadOperativa').val(),
                                    'EjercicioEntrenamientoAspectoId': $('#cbEjercicioEntrenamientoAspecto').val(),
                                    'CalificativoAsignadoEjercicioId': $('#cbCalificativoAsignadoEjercicio').val(),
                                    'PuntajeObtenidoEjercicio': $('#txtPuntajeObtenidoEjercicio').val(),
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
                                    $('#tblJesehinEvaluacionAlistamientoEntrenamientoJesehin').DataTable().ajax.reload();
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
                                url: '/JesehinEvaluacionAlistamientoEntrenamientoJesehin/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamientoe').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativae').val(),
                                    'TipoCapacidadOperativa': $('#txtTipoCapacidadOperativae').val(),
                                    'EjercicioEntrenamientoAspectoId': $('#cbEjercicioEntrenamientoAspectoe').val(),
                                    'CalificativoAsignadoEjercicioId': $('#cbCalificativoAsignadoEjercicioe').val(),
                                    'PuntajeObtenidoEjercicio': $('#txtPuntajeObtenidoEjercicioe').val(),
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
                                    $('#tblJesehinEvaluacionAlistamientoEntrenamientoJesehin').DataTable().ajax.reload();
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

    $('#tblJesehinEvaluacionAlistamientoEntrenamientoJesehin').DataTable({
        ajax: {
            "url": '/JesehinEvaluacionAlistamientoEntrenamientoJesehin/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoId" },
            { "data": "descUnidadNaval" },
            { "data": "nivelEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "tipoCapacidadOperativa" },
            { "data": "codigoEjercicioEntrenamiento " },
            { "data": "descEjercicioEntrenamiento" },
            { "data": "aspectoEvaluacion" },
            { "data": "peso " },
            { "data": "descripcion" },
            { "data": "puntajeObtenidoEjercicio" },
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
                filename: 'Jesehin - Evaluación del alistamiento del entrenamiento',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Jesehin - Evaluación del alistamiento del entrenamiento',
                title: 'Jesehin - Evaluación del alistamiento del entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Jesehin - Evaluación del alistamiento del entrenamiento',
                title: 'Jesehin - Evaluación del alistamiento del entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Jesehin - Evaluación del alistamiento del entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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
    $.getJSON('/JesehinEvaluacionAlistamientoEntrenamientoJesehin/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoEntrenamientoJesehinDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.evaluacionAlistamientoEntrenamientoId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.unidadNavalId);
        $('#txtNivelEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.nivelEntrenamiento);
        $('#cbCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.capacidadOperativaId);
        $('#txtTipoCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.tipoCapacidadOperativa);
        $('#cbEjercicioEntrenamientoAspectoe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.ejercicioEntrenamientoAspectoId);
        $('#txtCodigoEjercicioEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.codigoEjercicioEntrenamiento);
        $('#txtDescEjercicioEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.descEjercicioEntrenamiento);
        $('#txtAspectoEvaluacione').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.aspectoEvaluacion);
        $('#txtPesoe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.peso);
        $('#cbCalificativoAsignadoEjercicioe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.calificativoAsignadoEjercicioId);
        $('#txtPuntajeObtenidoEjercicioe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.puntajeObtenidoEjercicio);
        $('#txtFechaPeriodoEvaluare').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.fechaPeriodoEvaluar);
        $('#txtFechaRealizacionEjercicioe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.fechaRealizacionEjercicio);
        $('#txtTiempoVigenciae').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.tiempoVigencia); 
        $('#txtFechaCaducidadEjercicioe').val(EvaluacionAlistamientoEntrenamientoJesehinDTO.fechaCaducidadEjercicio); 
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
                url: '/JesehinEvaluacionAlistamientoEntrenamientoJesehin/Eliminar',
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
                    $('#tblJesehinEvaluacionAlistamientoEntrenamientoJesehin').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaJesehinEvaluacionAlistamientoEntrenamientoJesehin() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/JesehinEvaluacionAlistamientoEntrenamientoJesehin/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var capacidadOperativa = Json["data2"];
        ejercicioEntrenamientoAspecto = Json["data3"];
        var calificativoAsignadoEjercicio = Json["data4"];


        $("select#cbUnidadNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbCapacidadOperativa").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
        });
        $("select#cbCapacidadOperativae").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativae").append(RowContent);
        });


        $("select#cbEjercicioEntrenamientoAspecto").html("");
        $.each(ejercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoAspectoId + '>' + this.ejercicioEntrenamientoAspectoId + '</option>'
            $("select#cbEjercicioEntrenamientoAspecto").append(RowContent);

            $("input#txtCodigoEjercicioEntrenamiento").val(ejercicioEntrenamientoAspecto[0].codigoEjercicioEntrenamiento);
            $("input#txtDescEjercicioEntrenamiento").val(ejercicioEntrenamientoAspecto[0].descEjercicioEntrenamiento);
            $("input#txtAspectoEvaluacion").val(ejercicioEntrenamientoAspecto[0].aspectoEvaluacion);
            $("input#txtPeso").val(ejercicioEntrenamientoAspecto[0].peso);

        });

        $("select#cbEjercicioEntrenamientoAspectoe").html("");
        $.each(ejercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoAspectoId + '>' + this.ejercicioEntrenamientoAspectoId + '</option>'
            $("select#cbEjercicioEntrenamientoAspectoe").append(RowContent);
        });


        $("select#cbCalificativoAsignadoEjercicio").html("");
        $.each(calificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.calificativoAsignadoEjercicioId + '>' + this.descripcion + '</option>'
            $("select#cbCalificativoAsignadoEjercicio").append(RowContent);
        });
        $("select#cbCalificativoAsignadoEjercicioe").html("");
        $.each(calificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.calificativoAsignadoEjercicioId + '>' + this.descripcion + '</option>'
            $("select#cbCalificativoAsignadoEjercicioe").append(RowContent);
        });
    });
}


$('select#cbEjercicioEntrenamientoAspecto').on('change', function () {

    var codigo = $(this).val();

    $.each(ejercicioEntrenamientoAspecto, function () {
        if (this.ejercicioEntrenamientoAspectoId == codigo) {
            $("input#txtCodigoEjercicioEntrenamiento").val(this.codigoEjercicioEntrenamiento);
            $("input#txtDescEjercicioEntrenamiento").val(this.descEjercicioEntrenamiento);
            $("input#txtAspectoEvaluacion").val(this.aspectoEvaluacion);
            $("input#txtPeso").val(this.peso);
        }
    });
});

$('select#cbEjercicioEntrenamientoAspectoe').on('change', function () {

    var codigo = $(this).val();

    $.each(ejercicioEntrenamientoAspecto, function () {
        if (this.ejercicioEntrenamientoAspectoId == codigo) {
            $("input#txtCodigoEjercicioEntrenamientoe").val(this.codigoEjercicioEntrenamiento);
            $("input#txtDescEjercicioEntrenamientoe").val(this.descEjercicioEntrenamiento);
            $("input#txtAspectoEvaluacione").val(this.aspectoEvaluacion);
            $("input#txtPesoe").val(this.peso);
        }
    });
});
