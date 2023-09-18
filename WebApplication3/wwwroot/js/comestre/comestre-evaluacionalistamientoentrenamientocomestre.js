var tblComestreEvaluacionAlistamientoEntrenamientoComestre;

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
                                url: '/ComestreEvaluacionAlistamientoEntrenamientoComestre/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbIdentificacion').val(),
                                    'NivelEntrenamiento': $('#txtEntrenamiento').val(),
                                    'CapacidadOperativaId': $('#cbCapacidad').val(),
                                    'TipoCapacidadOperativo': $('#txtOperativa').val(),
                                    'CodigoEjercicioEntrenamiento': $('#txtEjercicio').val(),
                                    'EjercicioEntrenamientoId': $('#cbEjercicio').val(),
                                    'EjercicioEntrenamientoAspectoId': $('#cbSubEjercicio').val(),
                                    'PesoEjercicioEntrenamiento': $('#txtEstado').val(),
                                    'CalificativoAsignadoEjercicioId': $('#cbCalificativo').val(),
                                    'PuntajeObtenido': $('#txtPuntuaje').val(),
                                    'FechaPeriodoEvaluar': $('#txtPeriodo').val(),
                                    'FechaRealizacionEjercicio': $('#txtRealizacion').val(),
                                    'TiempoVigencia': $('#txtVigencia').val(),
                                    'FechaCaducidadEjercicio': $('#txtCaducidad').val(), 
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
                                    $('#tblComestreEvaluacionAlistamientoEntrenamientoComestre').DataTable().ajax.reload();
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
                                url: '/ComestreEvaluacionAlistamientoEntrenamientoComestre/Actualizar',
                                data: {

                                    'EvaluacionAlistamientoEntrenamientoComestreId': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbIdentificacione').val(),
                                    'NivelEntrenamiento': $('#txtEntrenamientoe').val(),
                                    'CapacidadOperativaId': $('#cbCapacidade').val(),
                                    'TipoCapacidadOperativo': $('#txtOperativae').val(),
                                    'CodigoEjercicioEntrenamiento': $('#txtEjercicioe').val(),
                                    'EjercicioEntrenamientoId': $('#cbEjercicioe').val(),
                                    'EjercicioEntrenamientoAspectoId': $('#cbSubEjercicioe').val(),
                                    'PesoEjercicioEntrenamiento': $('#txtEstadoe').val(),
                                    'CalificativoAsignadoEjercicioId': $('#cbCalificativoe').val(),
                                    'PuntajeObtenido': $('#txtPuntuajee').val(),
                                    'FechaPeriodoEvaluar': $('#txtPeriodoe').val(),
                                    'FechaRealizacionEjercicio': $('#txtRealizacione').val(),
                                    'TiempoVigencia': $('#txtVigenciae').val(),
                                    'FechaCaducidadEjercicio': $('#txtCaducidade').val(), 
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
                                    $('#tblComestreEvaluacionAlistamientoEntrenamientoComestre').DataTable().ajax.reload();
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

    $('#tblComestreEvaluacionAlistamientoEntrenamientoComestre').DataTable({
        ajax: {
            "url": '/ComestreEvaluacionAlistamientoEntrenamientoComestre/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoComestreId" },
            { "data": "descUnidadNaval" },
            { "data": "nivelEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "tipoCapacidadOperativo" },
            { "data": "codigoEjercicioEntrenamiento" },
            { "data": "descEjercicioEntrenamiento" },
            { "data": "descEjercicioEntrenamientoAspecto" },
            { "data": "pesoEjercicioEntrenamiento" },
            { "data": "aspectoEvaluacion" },
            { "data": "puntajeObtenido" },
            { "data": "fechaPeriodoEvaluar" },
            { "data": "fechaRealizacionEjercicio" },
            { "data": "tiempoVigencia" },
            { "data": "fechaCaducidadEjercicio" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionAlistamientoEntrenamientoComestreId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionAlistamientoEntrenamientoComestreId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comestre - Evaluacion de Alistamiento del Entrenamiento',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comestre - Evaluacion de Alistamiento del Entrenamiento',
                title: 'Comestre - Evaluacion de Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comestre - Evaluacion de Alistamiento del Entrenamiento',
                title: 'Comestre - Evaluacion de Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comestre - Evaluacion de Alistamiento del Entrenamiento',
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
    $.getJSON('/ComestreEvaluacionAlistamientoEntrenamientoComestre/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoEntrenamientoComestreDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoEntrenamientoComestreDTO.evaluacionAlistamientoEntrenamientoComestreId);
        $('#cbIdentificacione').val(EvaluacionAlistamientoEntrenamientoComestreDTO.unidadNavalId);
        $('#txtEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComestreDTO.nivelEntrenamiento);
        $('#cbCapacidade').val(EvaluacionAlistamientoEntrenamientoComestreDTO.capacidadOperativaId);
        $('#txtOperativae').val(EvaluacionAlistamientoEntrenamientoComestreDTO.tipoCapacidadOperativo);
        $('#txtEjercicioe').val(EvaluacionAlistamientoEntrenamientoComestreDTO.codigoEjercicioEntrenamiento);
        $('#cbEjercicioe').val(EvaluacionAlistamientoEntrenamientoComestreDTO.ejercicioEntrenamientoId);
        $('#cbSubEjercicioe').val(EvaluacionAlistamientoEntrenamientoComestreDTO.ejercicioEntrenamientoAspectoId);
        $('#txtEstadoe').val(EvaluacionAlistamientoEntrenamientoComestreDTO.pesoEjercicioEntrenamiento);
        $('#cbCalificativoe').val(EvaluacionAlistamientoEntrenamientoComestreDTO.calificativoAsignadoEjercicioId);
        $('#txtPuntuajee').val(EvaluacionAlistamientoEntrenamientoComestreDTO.puntajeObtenido);
        $('#txtPeriodoe').val(EvaluacionAlistamientoEntrenamientoComestreDTO.fechaPeriodoEvaluar);
        $('#txtRealizacione').val(EvaluacionAlistamientoEntrenamientoComestreDTO.fechaRealizacionEjercicio);
        $('#txtVigenciae').val(EvaluacionAlistamientoEntrenamientoComestreDTO.tiempoVigencia);
        $('#txtCaducidade').val(EvaluacionAlistamientoEntrenamientoComestreDTO.fechaCaducidadEjercicio); 
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
                url: '/ComestreEvaluacionAlistamientoEntrenamientoComestre/Eliminar',
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
                    $('#tblComestreEvaluacionAlistamientoEntrenamientoComestre').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComestreEvaluacionAlistamientoEntrenamientoComestre() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            console.log(dataJson);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.nombreTemaEstudioInvestigacion),
                        $("<td>").text(item.tipoEstudioInvestigacion),
                        $("<td>").text(item.fechaInicio),
                        $("<td>").text(item.fechaTermino),
                        $("<td>").text(item.responsable),
                        $("<td>").text(item.solicitante)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            alert(dataJson.mensaje);
        })
}


function cargaDatos() {
    $.getJSON('/ComestreEvaluacionAlistamientoEntrenamientoComestre/cargaCombs', [], function (Json) {

        var unidadNaval = Json["data1"];
        var capacidadOperativa = Json["data2"];
        var ejercicioEntrenamiento = Json["data3"];
        var ejercicioEntrenamientoAspecto = Json["data4"];
        var calificativoAsignadoEjercicio = Json["data5"];

        $("select#cbIdentificacion").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbIdentificacion").append(RowContent);
        });
        $("select#cbIdentificacione").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbIdentificacione").append(RowContent);
        });

        $("select#cbCapacidad").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidad").append(RowContent);
        });
        $("select#cbCapacidade").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidade").append(RowContent);
        });

        $("select#cbEjercicio").html("");
        $.each(ejercicioEntrenamiento, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoId + '>' + this.descEjercicioEntrenamiento + '</option>'
            $("select#cbEjercicio").append(RowContent);
        });
        $("select#cbEjercicioe").html("");
        $.each(ejercicioEntrenamiento, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoId + '>' + this.descEjercicioEntrenamiento + '</option>'
            $("select#cbEjercicioe").append(RowContent);
        });

        $("select#cbSubEjercicio").html("");
        $.each(ejercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoAspectoId + '>' + this.descEjercicioEntrenamientoAspecto + '</option>'
            $("select#cbSubEjercicio").append(RowContent);
        });
        $("select#cbSubEjercicioe").html("");
        $.each(ejercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.ejercicioEntrenamientoAspectoId + '>' + this.descEjercicioEntrenamientoAspecto + '</option>'
            $("select#cbSubEjercicioe").append(RowContent);
        });

        $("select#cbCalificativo").html("");
        $.each(calificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.calificativoAsignadoEjercicioId + '>' + this.aspectoEvaluacion + '</option>'
            $("select#cbCalificativo").append(RowContent);
        });
        $("select#cbCalificativoe").html("");
        $.each(calificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.calificativoAsignadoEjercicioId + '>' + this.aspectoEvaluacion + '</option>'
            $("select#cbCalificativoe").append(RowContent);
        });
    }) 
}

