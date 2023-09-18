var tblComfuavinavEvaluacionAlistamientoEntrenamiento;
var ejercicioEntrenamiento;

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
                                url: '/ComfuavinavEvaluacionAlistamientoEntrenamiento/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamiento').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativa').val(),
                                    'TipoCompetenciaTecnicaId': $('#cbTipoCompetenciaTecnica').val(),
                                    'EjercicioEntrenamientoId': $('#cbEjercicioEntrenamiento').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluar').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicio').val(),
                                    'TiempoVigencia': $('#txtTiempoVigencia').val(),
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
                                    $('#tblComfuavinavEvaluacionAlistamientoEntrenamiento').DataTable().ajax.reload();
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
                                url: '/ComfuavinavEvaluacionAlistamientoEntrenamiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamientoe').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativae').val(),
                                    'TipoCompetenciaTecnicaId': $('#cbTipoCompetenciaTecnicae').val(),
                                    'EjercicioEntrenamientoId': $('#cbEjercicioEntrenamientoe').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluare').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicioe').val(),
                                    'TiempoVigencia': $('#txtTiempoVigencia').val(),
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
                                    $('#tblComfuavinavEvaluacionAlistamientoEntrenamiento').DataTable().ajax.reload();
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

    $('#tblComfuavinavEvaluacionAlistamientoEntrenamiento').DataTable({
        ajax: {
            "url": '/ComfuavinavEvaluacionAlistamientoEntrenamiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoId" },
            { "data": "descUnidadNaval" },
            { "data": "nivelEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "descTipoCompetenciaTecnica" },
            { "data": "codigoEjercicioEntrenamiento " },
            { "data": "descEjercicioEntrenamiento" },
            { "data": "fechaPeriodoEvaluar" },
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
        dom: 'Bfrtip',
        buttons: [
            //csv,
            {
                extend: 'csvHtml5',
                text: 'Exportar CSV',
                filename: 'Comfuavinav - Reporte de Ejercicios para el Alistamiento de Entrenamiento de las Unidades Aeronavales',
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
                filename: 'Comfuavinav - Reporte de Ejercicios para el Alistamiento de Entrenamiento de las Unidades Aeronavales',
                title: 'Comfuavinav - Reporte de Ejercicios para el Alistamiento de Entrenamiento de las Unidades Aeronavales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfuavinav - Reporte de Ejercicios para el Alistamiento de Entrenamiento de las Unidades Aeronavales',
                title: 'Comfuavinav - Reporte de Ejercicios para el Alistamiento de Entrenamiento de las Unidades Aeronavales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfuavinav - Reporte de Ejercicios para el Alistamiento de Entrenamiento de las Unidades Aeronavales',
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfuavinavEvaluacionAlistamientoEntrenamiento/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoEntrenamientoComfuavinavDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.evaluacionAlistamientoEntrenamientoId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.unidadNavalId);
        $('#txtNivelEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.nivelEntrenamiento);
        $('#cbCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.capacidadOperativaId);
        $('#cbTipoCompetenciaTecnicae').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.tipoCompetenciaTecnicaId);
        $('#cbEjercicioEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.ejercicioEntrenamientoId);
        $('#txtCodigoEjercicioEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.codigoEjercicioEntrenamiento);
        $('#txtPuntajeObtenidoEjercicioe').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.puntajeObtenidoEjercicio);
        $('#txtFechaPeriodoEvaluare').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.fechaPeriodoEvaluar);
        $('#txtFechaRealizacionEjercicioe').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.fechaRealizacionEjercicio);
        $('#txtTiempoVigenciae').val(EvaluacionAlistamientoEntrenamientoComfuavinavDTO.tiempoVigencia); 
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
                url: '/ComfuavinavEvaluacionAlistamientoEntrenamiento/Eliminar',
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
                    $('#tblComfuavinavEvaluacionAlistamientoEntrenamiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfuavinavEvaluacionAlistamientoEntrenamiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfuavinavEvaluacionAlistamientoEntrenamiento/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var capacidadOperativa = Json["data2"];
        var tipoCompetenciaTecnica = Json["data3"];
        ejercicioEntrenamiento = Json["data4"];


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


        $("select#cbTipoCompetenciaTecnica").html("");
        $.each(tipoCompetenciaTecnica, function () {
            var RowContent = '<option value=' + this.tipoCompetenciaTecnicaId + '>' + this.descTipoCompetenciaTecnica + '</option>'
            $("select#cbTipoCompetenciaTecnica").append(RowContent);
        });
        $("select#cbTipoCompetenciaTecnicae").html("");
        $.each(tipoCompetenciaTecnica, function () {
            var RowContent = '<option value=' + this.tipoCompetenciaTecnicaId + '>' + this.descTipoCompetenciaTecnica + '</option>'
            $("select#cbTipoCompetenciaTecnicae").append(RowContent);
        });


        $("select#cbEjercicioEntrenamiento").html("");
        $.each(ejercicioEntrenamiento, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoId + '>' + this.descEjercicioEntrenamiento + '</option>'
            $("select#cbEjercicioEntrenamiento").append(RowContent);

            $("input#txtCodigoEjercicioEntrenamiento").val(ejercicioEntrenamiento[0].codigoEjercicioEntrenamiento);

        });

        $("select#cbEjercicioEntrenamientoe").html("");
        $.each(ejercicioEntrenamiento, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoId + '>' + this.descEjercicioEntrenamiento + '</option>'
            $("select#cbEjercicioEntrenamientoe").append(RowContent);
        });
    });
}


$('select#cbEjercicioEntrenamiento').on('change', function () {

    var codigo = $(this).val();

    $.each(ejercicioEntrenamientoId, function () {
        if (this.ejercicioEntrenamientoId == codigo) {
            $("input#txtCodigoEjercicioEntrenamiento").val(this.codigoEjercicioEntrenamiento);
        }
    });
});

$('select#cbEjercicioEntrenamientoe').on('change', function () {

    var codigo = $(this).val();

    $.each(ejercicioEntrenamientoId, function () {
        if (this.ejercicioEntrenamientoId == codigo) {
            $("input#txtCodigoEjercicioEntrenamientoe").val(this.codigoEjercicioEntrenamiento);
        }
    });
});
