var tblComgoe3EvaluacionAlistamientoPersonalComgoe;

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
                                url: '/Comgoe3EvaluacionAlistamientoPersonalComgoe/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacion').val(),
                                    'DNIPersonal': $('#txtDNIPersonal').val(),
                                    'CIPPersonal': $('#txtCIPPersonal').val(),
                                    'Cargo': $('#txtCargo').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoPersonalMilitar').val(),
                                    'EspecialidadGenericaPersonalId': $('#cbEspecialidadGenericaPersonal').val(),
                                    'GradoPersonalMilitarActual': $('#cbGradoPersonalMilitarActual').val(),
                                    'EspecialidadGenericaPersonalActual': $('#cbEspecialidadGenericaPersonalActual').val(),
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
                                    $('#tblComgoe3EvaluacionAlistamientoPersonalComgoe').DataTable().ajax.reload();
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
                                url: '/Comgoe3EvaluacionAlistamientoPersonalComgoe/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacione').val(),
                                    'DNIPersonal': $('#txtDNIPersonale').val(),
                                    'CIPPersonal': $('#txtCIPPersonale').val(),
                                    'Cargo': $('#txtCargoe').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoPersonalMilitare').val(),
                                    'EspecialidadGenericaPersonalId': $('#cbEspecialidadGenericaPersonale').val(),
                                    'GradoPersonalMilitarActual': $('#cbGradoPersonalMilitarActuale').val(),
                                    'EspecialidadGenericaPersonalActual': $('#cbEspecialidadGenericaPersonalActuale').val(),
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
                                    $('#tblComgoe3EvaluacionAlistamientoPersonalComgoe').DataTable().ajax.reload();
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

    $('#tblComgoe3EvaluacionAlistamientoPersonalComgoe').DataTable({
        ajax: {
            "url": '/Comgoe3EvaluacionAlistamientoPersonalComgoe/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoPersonalId" },
            { "data": "descUnidadNaval" },
            { "data": "fechaEvaluacion" },
            { "data": "dniPersonal" },
            { "data": "cipPersonal" },
            { "data": "cargo" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "descGradoPersonalMilitarActual" },
            { "data": "descEspecialidadGenericaPersonalActual" },
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
                filename: 'comgoe-3 - Evaluación del alistamiento de personal',
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
                filename: 'comgoe-3 - Evaluación del alistamiento de personal',
                title: 'comgoe-3 - Evaluación del alistamiento de personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'comgoe-3 - Evaluación del alistamiento de personal',
                title: 'comgoe-3 - Evaluación del alistamiento de personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'comgoe-3 - Evaluación del alistamiento de personal',
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
    $.getJSON('/Comgoe3EvaluacionAlistamientoPersonalComgoe/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoPersonalComgoeDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoPersonalComgoeDTO.evaluacionAlistamientoPersonalId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoPersonalComgoeDTO.unidadNavalId);
        $('#txtFechaEvaluacione').val(EvaluacionAlistamientoPersonalComgoeDTO.fechaEvaluacion);
        $('#txtDNIPersonale').val(EvaluacionAlistamientoPersonalComgoeDTO.dniPersonal);
        $('#txtCIPPersonale').val(EvaluacionAlistamientoPersonalComgoeDTO.cipPersonal);
        $('#txtCargoe').val(EvaluacionAlistamientoPersonalComgoeDTO.cargo);
        $('#cbGradoPersonalMilitare').val(EvaluacionAlistamientoPersonalComgoeDTO.gradoPersonalMilitarId);
        $('#cbEspecialidadGenericaPersonale').val(EvaluacionAlistamientoPersonalComgoeDTO.especialidadGenericaPersonalId);
        $('#cbGradoPersonalMilitarActuale').val(EvaluacionAlistamientoPersonalComgoeDTO.gradoPersonalMilitarActual);
        $('#cbEspecialidadGenericaPersonalActuale').val(EvaluacionAlistamientoPersonalComgoeDTO.especialidadGenericaPersonalActual);
        $('#txtGradoJerarquicoe').val(EvaluacionAlistamientoPersonalComgoeDTO.gradoJerarquico);
        $('#txtServicioExperienciae').val(EvaluacionAlistamientoPersonalComgoeDTO.servicioExperiencia);
        $('#txtEspecializacionProfesionale').val(EvaluacionAlistamientoPersonalComgoeDTO.especializacionProfesional);
        $('#txtCursoProfesionalRequeridoe').val(EvaluacionAlistamientoPersonalComgoeDTO.cursoProfesionalRequerido); 
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
                url: '/Comgoe3EvaluacionAlistamientoPersonalComgoe/Eliminar',
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
                    $('#tblComgoe3EvaluacionAlistamientoPersonalComgoe').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComgoe3EvaluacionAlistamientoPersonalComgoe() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/Comgoe3EvaluacionAlistamientoPersonalComgoe/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var especialidadGenericaPersonal = Json["data3"];





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


        $("select#cbGradoPersonalMilitar").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
        });
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });


        $("select#cbEspecialidadGenericaPersonal").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonal").append(RowContent);
        });
        $("select#cbEspecialidadGenericaPersonale").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonale").append(RowContent);
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


        $("select#cbEspecialidadGenericaPersonalActual").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonalActual").append(RowContent);
        });
        $("select#cbEspecialidadGenericaPersonalActuale").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonalActuale").append(RowContent);
        });


    });
}

