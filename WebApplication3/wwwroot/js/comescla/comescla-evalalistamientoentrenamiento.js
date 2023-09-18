var tblComesclaEvalAlistamientoEntrenamiento;

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
                                url: '/ComesclaEvalAlistamientoEntrenamiento/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'NivelEntrenamientoId': $('#cbNivelEntrenamiento').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativa').val(),
                                    'TipoCapacidadOperativa': $('#txtTipoCapacidadOperativa').val(),
                                    'CodigoEjercicioEntrenamiento': $('#txtCodigoEjercicioEntrenamiento').val(),
                                    'EjercicioEntrenamiento': $('#txtEjercicioEntrenamiento').val(),
                                    'EjercicioEntrenamientoAspectos': $('#txtEjercicioEntrenamientoAspectos').val(),
                                    'PesoEjercicioEntrenamiento': $('#txtPesoEjercicioEntrenamiento').val(),
                                    'CalificativoAsignadoEjercicioId': $('#cbCalificativoAsignadoEjercicio').val(),
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
                                    $('#tblComesclaEvalAlistamientoEntrenamiento').DataTable().ajax.reload();
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
                                url: '/ComesclaEvalAlistamientoEntrenamiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'NivelEntrenamientoId': $('#cbNivelEntrenamientoe').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativae').val(),
                                    'TipoCapacidadOperativa': $('#txtTipoCapacidadOperativae').val(),
                                    'CodigoEjercicioEntrenamiento': $('#txtCodigoEjercicioEntrenamientoe').val(), 
                                    'EjercicioEntrenamiento': $('#txtEjercicioEntrenamientoe').val(),
                                    'EjercicioEntrenamientoAspectos': $('#txtEjercicioEntrenamientoAspectose').val(),
                                    'PesoEjercicioEntrenamiento': $('#txtPesoEjercicioEntrenamientoe').val(),
                                    'CalificativoAsignadoEjercicioId': $('#cbCalificativoAsignadoEjercicioe').val(),
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
                                    $('#tblComesclaEvalAlistamientoEntrenamiento').DataTable().ajax.reload();
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

    $('#tblComesclaEvalAlistamientoEntrenamiento').DataTable({
        ajax: {
            "url": '/ComesclaEvalAlistamientoEntrenamiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoId" },
            { "data": "descUnidadNaval" },
            { "data": "descNivelEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "tipoCapacidadOperativa" },
            { "data": "descCodigoEjercicioEntrenamien" },
            { "data": "ejercicioEntrenamiento" },
            { "data": "ejercicioEntrenamientoAspectos" },
            { "data": "pesoEjercicioEntrenamiento" },
            { "data": "descCalificativoAsignadoEjercicio" },
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
                filename: 'Comescla - Evaluación del Alistamiento del Entrenamiento',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comescla - Evaluación del Alistamiento del Entrenamiento',
                title: 'Comescla - Evaluación del Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescla - Evaluación del Alistamiento del Entrenamiento',
                title: 'Comescla - Evaluación del Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescla - Evaluación del Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
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
    $.getJSON('/ComesclaEvalAlistamientoEntrenamiento/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoEntrenamientoComesclaDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.evaluacionAlistamientoEntrenamientoId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.unidadNavalId);
        $('#cbNivelEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.nivelEntrenamientoId);
        $('#cbCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.capacidadOperativaId);
        $('#txtTipoCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.tipoCapacidadOperativa);
        $('#txtCodigoEjercicioEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.codigoEjercicioEntrenamiento); 
        $('#txtEjercicioEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.ejercicioEntrenamiento);
        $('#txtEjercicioEntrenamientoAspectose').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.ejercicioEntrenamientoAspectos);
        $('#txtPesoEjercicioEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.pesoEjercicioEntrenamiento);
        $('#cbCalificativoAsignadoEjercicioe').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.calificativoAsignadoEjercicioId);
        $('#txtFechaPeriodoEvaluare').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.fechaPeriodoEvaluar);
        $('#txtFechaRealizacionEjercicioe').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.fechaRealizacionEjercicio);
        $('#txtTiempoVigenciae').val(EvaluacionAlistamientoEntrenamientoComesclaDTO.tiempoVigencia); 
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
                url: '/ComesclaEvalAlistamientoEntrenamiento/Eliminar',
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
                    $('#tblComesclaEvalAlistamientoEntrenamiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComesclaEvalAlistamientoEntrenamiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComesclaEvalAlistamientoEntrenamiento/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var NivelEntrenamiento = Json["data2"];
        var CapacidadOperativa = Json["data3"];
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


        $("select#cbNivelEntrenamiento").html("");
        $.each(NivelEntrenamiento, function () {
            var RowContent = '<option value=' + this.nivelEntrenamientoId + '>' + this.descNivelEntrenamiento + '</option>'
            $("select#cbNivelEntrenamiento").append(RowContent);
        });
        $("select#cbNivelEntrenamientoe").html("");
        $.each(NivelEntrenamiento, function () {
            var RowContent = '<option value=' + this.nivelEntrenamientoId + '>' + this.descNivelEntrenamiento + '</option>'
            $("select#cbNivelEntrenamientoe").append(RowContent);
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


        $("select#cbCalificativoAsignadoEjercicio").html("");
        $.each(CalificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.calificativoAsignadoEjercicioId + '>' + this.descripcion + '</option>'
            $("select#cbCalificativoAsignadoEjercicio").append(RowContent);
        });
        $("select#cbCalificativoAsignadoEjercicioe").html("");
        $.each(CalificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.calificativoAsignadoEjercicioId + '>' + this.descripcion + '</option>'
            $("select#cbCalificativoAsignadoEjercicioe").append(RowContent);
        }); 

    });
}

