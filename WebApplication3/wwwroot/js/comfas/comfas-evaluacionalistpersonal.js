var tblComfasEvaluacionAlistPersonal;

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
                                url: '/ComfasEvaluacionAlistPersonal/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacion').val(),
                                    'DNIPersonal': $('#txtDNIPersonal').val(),
                                    'CIPPersonal': $('#txtCIPPersonal').val(),
                                    'CargoPersonal': $('#txtCargoPersonal').val(),
                                    'GradoPersonalMilitarEsperado': $('#cbGradoPersonalMilitarEsperado').val(),
                                    'EspecialidadGenericaEsperado': $('#cbEspecialidadGenericaEsperado').val(),
                                    'GradoPersonalMilitarActual': $('#cbGradoPersonalMilitarActual').val(),
                                    'EspecialidadGenericaActual': $('#cbEspecialidadGenericaActual').val(),
                                    'GradoJerarquico': $('#txtGradoJerarquico').val(),
                                    'ServicioExperiencia': $('#txtServicioExperiencia').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacionProfesional').val(),
                                    'CursoProfesionalRequerido': $('#txtCursoProfesionalRequerido').val(), 
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
                                    $('#tblComfasEvaluacionAlistPersonal').DataTable().ajax.reload();
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
                                url: '/ComfasEvaluacionAlistPersonal/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacione').val(),
                                    'DNIPersonal': $('#txtDNIPersonale').val(),
                                    'CIPPersonal': $('#txtCIPPersonale').val(),
                                    'CargoPersonal': $('#txtCargoPersonale').val(),
                                    'GradoPersonalMilitarEsperado': $('#cbGradoPersonalMilitarEsperadoe').val(),
                                    'EspecialidadGenericaEsperado': $('#cbEspecialidadGenericaEsperadoe').val(),
                                    'GradoPersonalMilitarActual': $('#cbGradoPersonalMilitarActuale').val(),
                                    'EspecialidadGenericaActual': $('#cbEspecialidadGenericaActuale').val(),
                                    'GradoJerarquico': $('#txtGradoJerarquicoe').val(),
                                    'ServicioExperiencia': $('#txtServicioExperienciae').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacionProfesionale').val(),
                                    'CursoProfesionalRequerido': $('#txtCursoProfesionalRequeridoe').val(), 
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
                                    $('#tblComfasEvaluacionAlistPersonal').DataTable().ajax.reload();
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

    $('#tblComfasEvaluacionAlistPersonal').DataTable({
        ajax: {
            "url": '/ComfasEvaluacionAlistPersonal/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoPersonalId" },
            { "data": "descUnidadNaval" },
            { "data": "fechaEvaluacion" },
            { "data": "dniPersonal" },
            { "data": "cipPersonal" },
            { "data": "cargoPersonal" },
            { "data": "descGradoPersonalMilitarEsperado" },
            { "data": "descEspecialidadGenericaEsperado" },
            { "data": "descGradoPersonalMilitarActual" },
            { "data": "descEspecialidadGenericaActual" },
            { "data": "gradoJerarquico" },
            { "data": "servicioExperiencia" },
            { "data": "especializacionProfesional" },
            { "data": "cursoProfesionalRequerido" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionAlistamientoPersonalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionAlistamientoPersonalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Evaluación del Alistamiento de Personal',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfas - Evaluación del Alistamiento de Personal',
                title: 'Comfas - Evaluación del Alistamiento de Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Evaluación del Alistamiento de Personal',
                title: 'Comfas - Evaluación del Alistamiento de Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Evaluación del Alistamiento de Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
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
    $.getJSON('/ComfasEvaluacionAlistPersonal/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoPersonalComfasDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoPersonalComfasDTO.evaluacionAlistamientoPersonalId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoPersonalComfasDTO.unidadNavalId);
        $('#txtFechaEvaluacione').val(EvaluacionAlistamientoPersonalComfasDTO.fechaEvaluacion);
        $('#txtDNIPersonale').val(EvaluacionAlistamientoPersonalComfasDTO.dniPersonal);
        $('#txtCIPPersonale').val(EvaluacionAlistamientoPersonalComfasDTO.cipPersonal);
        $('#txtCargoPersonale').val(EvaluacionAlistamientoPersonalComfasDTO.cargoPersonal);
        $('#cbGradoPersonalMilitarEsperadoe').val(EvaluacionAlistamientoPersonalComfasDTO.gradoPersonalMilitarEsperado);
        $('#cbEspecialidadGenericaEsperadoe').val(EvaluacionAlistamientoPersonalComfasDTO.especialidadGenericaEsperado);
        $('#cbGradoPersonalMilitarActuale').val(EvaluacionAlistamientoPersonalComfasDTO.gradoPersonalMilitarActual);
        $('#cbEspecialidadGenericaActuale').val(EvaluacionAlistamientoPersonalComfasDTO.especialidadGenericaActual);
        $('#txtGradoJerarquicoe').val(EvaluacionAlistamientoPersonalComfasDTO.gradoJerarquico);
        $('#txtServicioExperienciae').val(EvaluacionAlistamientoPersonalComfasDTO.servicioExperiencia);
        $('#txtEspecializacionProfesionale').val(EvaluacionAlistamientoPersonalComfasDTO.especializacionProfesional);
        $('#txtCursoProfesionalRequeridoe').val(EvaluacionAlistamientoPersonalComfasDTO.cursoProfesionalRequerido); 
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
                url: '/ComfasEvaluacionAlistPersonal/Eliminar',
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
                    $('#tblComfasEvaluacionAlistPersonal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasEvaluacionAlistPersonal() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasEvaluacionAlistPersonal/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var especialidadGenerica = Json["data3"];


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


        $("select#cbGradoPersonalMilitarEsperado").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarEsperado").append(RowContent);
        });
        $("select#cbGradoPersonalMilitarEsperadoe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarEsperadoe").append(RowContent);
        });


        $("select#cbEspecialidadGenericaEsperado").html("");
        $.each(especialidadGenerica, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaEsperado").append(RowContent);
        });
        $("select#cbEspecialidadGenericaEsperadoe").html("");
        $.each(especialidadGenerica, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaEsperadoe").append(RowContent);
        });


        $("select#cbGradoPersonalMilitarActual").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarActual").append(RowContent);
        });
        $("select#cbGradoPersonalMilitarActuale").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarActuale").append(RowContent);
        });


        $("select#cbEspecialidadGenericaActual").html("");
        $.each(especialidadGenerica, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaActual").append(RowContent);
        });
        $("select#cbEspecialidadGenericaActuale").html("");
        $.each(especialidadGenerica, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaActuale").append(RowContent);
        });



    });
}

