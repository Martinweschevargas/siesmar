var tblEjercicioEntrenamientoComfasubs;

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
                                url: '/EjercicioEntrenamientoComfasub/InsertarEjercicioEntrenamientoComfasub',
                                data: {
                                    'CodigoEjercicioEntrenamiento': $('#txtCode').val(),
                                    'CodigoCapacidadOperativa': $('#cbFK').val(),
                                    'DescEjercicioEntrenamiento': $('#txtDescripcion').val(),
                                    'NivelEjercicio': $('#txtNivel').val(),
                                    'VigenciaIslay': $('#txtVigenciaIslay').val(),
                                    'VigenciaAngamos': $('#txtVigenciaAngamos').val(),
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
                                    $('#tblEjercicioEntrenamientoComfasubs').DataTable().ajax.reload();
                                    $('.needs-validation :input').val('');
                                    $(".needs-validation").find("select").prop("selectedIndex", 0);
                                    form.classList.remove('was-validated')
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
                                url: '/EjercicioEntrenamientoComfasub/ActualizarEjercicioEntrenamientoComfasub',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoEjercicioEntrenamiento': $('#txtCodee').val(),
                                    'CodigoCapacidadOperativa': $('#cbFKe').val(),
                                    'DescEjercicioEntrenamiento': $('#txtDescripcione').val(),
                                    'NivelEjercicio': $('#txtNivele').val(),
                                    'VigenciaIslay': $('#txtVigenciaIslaye').val(),
                                    'VigenciaAngamos': $('#txtVigenciaAngamose').val(),
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
                                    $('#tblEjercicioEntrenamientoComfasubs').DataTable().ajax.reload();
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

    $('#tblEjercicioEntrenamientoComfasubs').DataTable({
        ajax: {
            "url": '/EjercicioEntrenamientoComfasub/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ejercicioEntrenamientoComfasubId" },
            { "data": "descEjercicioEntrenamiento" },
            { "data": "codigoEjercicioEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "nivelEjercicio" },
            { "data": "vigenciaDiasClaseIslay" },
            { "data": "vigenciaDiasClaseAngamos" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ejercicioEntrenamientoComfasubId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ejercicioEntrenamientoComfasubId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

    cargaCombo();

});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/EjercicioEntrenamientoComfasub/MostrarEjercicioEntrenamientoComfasub?Id=' + Id, [], function (EjercicioEntrenamientoComfasubDTO) {
        $('#txtCodigo').val(EjercicioEntrenamientoComfasubDTO.ejercicioEntrenamientoComfasubId);
        $('#txtCodee').val(EjercicioEntrenamientoComfasubDTO.codigoEjercicioEntrenamiento);
        $('#txtDescripcione').val(EjercicioEntrenamientoComfasubDTO.descEjercicioEntrenamiento);
        $('#cbFKe').val(EjercicioEntrenamientoComfasubDTO.codigoCapacidadOperativa);
        $('#txtNivele').val(EjercicioEntrenamientoComfasubDTO.nivelEjercicio);
        $('#txtVigenciaIslaye').val(EjercicioEntrenamientoComfasubDTO.vigenciaDiasClaseIslay);
        $('#txtVigenciaAngamose').val(EjercicioEntrenamientoComfasubDTO.vigenciaDiasClaseAngamos);
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
                url: '/EjercicioEntrenamientoComfasub/EliminarEjercicioEntrenamientoComfasub',
                data: {
                    'EjercicioEntrenamientoComfasubId': id
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
                    $('#tblEjercicioEntrenamientoComfasubs').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaEjercicioEntrenamientoComfasub() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/EjercicioEntrenamientoComfasub/cargaCombs', [], function (Json) {
        var capacidadOperativa = Json["data"];

        $("select#cbFK").html("");
        $("select#cbFKe").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbFK").append(RowContent);
            $("select#cbFKe").append(RowContent);
        });

    });
}