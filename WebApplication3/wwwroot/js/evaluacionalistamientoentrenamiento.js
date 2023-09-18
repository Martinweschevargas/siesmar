var tblEvaluacionAlistamientoEntrenamientos;

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
                        title: 'Deseas agregar?',
                        text: "Se agregara a la tabla!",
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si,agregar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/EvaluacionAlistamientoEntrenamiento/InsertarEvaluacionAlistamientoEntrenamiento',
                                data: {
                                    'Nivel': $('#txtNivel').val(),
                                    'CodigoCapacidad': $('#txtCodigoCapacidad').val(),
                                    'TipoCapacidad': $('#txtTipoCapacidad').val(),
                                    'CodigoEjercicio': $('#txtCodigoEjercicio').val(),
                                    'Calificativo': $('#txtCalificativo').val(),
                                    'FechaPeriodo': $('#txtFechaPeriodo').val(),
                                    'FechaRealizacion': $('#txtFechaRealizacion').val(),
                                    'Tiempo': $('#txtTiempo').val(),
                                },
                                beforeSend: function () {
                                    $('#loader-6').show();
                                },
                                success: function (mensaje) {
                                    if (mensaje == "1") {
                                        Swal.fire(
                                            'Agregado!',
                                            'Se agregó con éxito.',
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
                                    $('#tblEvaluacionAlistamientoEntrenamientos').DataTable().ajax.reload();
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });
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
                        confirmButtonText: 'Si,actualizar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/EvaluacionAlistamientoEntrenamiento/ActualizarEvaluacionAlistamientoEntrenamiento',
                                data: {
                                    'EvaluacionAlistamientoEntrenamientoId': $('#txtCodigo').val(),
                                    'Nivel': $('#txtNivele').val(),
                                    'CodigoCapacidad': $('#txtCodigoCapacidade').val(),
                                    'TipoCapacidad': $('#txtTipoCapacidade').val(),
                                    'CodigoEjercicio': $('#txtCodigoEjercicioe').val(),
                                    'Calificativo': $('#txtCalificativoe').val(),
                                    'FechaPeriodo': $('#txtFechaPeriodoe').val(),
                                    'FechaRealizacion': $('#txtFechaRealizacione').val(),
                                    'Tiempo': $('#txtTiempoe').val(),
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
                                    $('#tblEvaluacionAlistamientoEntrenamientos').DataTable().ajax.reload();
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });
                        }
                    })
                }
                form.classList.add('was-validated')
            }, false)
        })

    $('#tblEvaluacionAlistamientoEntrenamientos').DataTable({
        ajax: {
            "url": '/EvaluacionAlistamientoEntrenamiento/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoId" },
            { "data": "nivelEntrenamiento" },
            { "data": "codigoCapacidadOperativa" },
            { "data": "tipoCapacidadOperativa" },
            { "data": "codigoEjercicio" },
            { "data": "calificativo" },
            { "data": "fechaPeriodoEvaluacionEjercicio" },
            { "data": "fechaRealizacionEjercicio" },
            { "data": "tiempoVigencia" },
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
        columnDefs: [
            {
                "targets": "_all",
                "className": "text-center",
            },
            {
                "targets": "[3,4]",
                "width": "120px",
            }
        ]
    });
});

function edit(EvaluacionAlistamientoEntrenamientoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/EvaluacionAlistamientoEntrenamiento/MostrarEvaluacionAlistamientoEntrenamiento?EvaluacionAlistamientoEntrenamientoId=' + EvaluacionAlistamientoEntrenamientoId, [], function (EvaluacionAlistamientoEntrenamientoDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoEntrenamientoDTO.evaluacionAlistamientoEntrenamientoId);
        $('#txtNivele').val(EvaluacionAlistamientoEntrenamientoDTO.nivelEntrenamiento);
        $('#txtCodigoCapacidade').val(EvaluacionAlistamientoEntrenamientoDTO.codigoCapacidadOperativa);
        $('#txtTipoCapacidade').val(EvaluacionAlistamientoEntrenamientoDTO.tipoCapacidadOperativa);
        $('#txtCodigoEjercicioe').val(EvaluacionAlistamientoEntrenamientoDTO.codigoEjercicio);
        $('#txtCalificativoe').val(EvaluacionAlistamientoEntrenamientoDTO.calificativo);
        $('#txtFechaPeriodoe').val(EvaluacionAlistamientoEntrenamientoDTO.fechaPeriodoEvaluacionEjercicio);
        $('#txtFechaRealizacione').val(EvaluacionAlistamientoEntrenamientoDTO.fechaRealizacionEjercicio);
        $('#txtTiempoe').val(EvaluacionAlistamientoEntrenamientoDTO.tiempoVigencia);
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
                url: '/EvaluacionAlistamientoEntrenamiento/EliminarEvaluacionAlistamientoEntrenamiento',
                data: {
                    'EvaluacionAlistamientoEntrenamientoId': id
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
                    $('#tblEvaluacionAlistamientoEntrenamientos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaEvaluacionAlistamientoEntrenamiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

