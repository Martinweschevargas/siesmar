
var tblCarreraUniversitariaEspecialidads;


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
                                url: '/CarreraUniversitariaEspecialidad/InsertarCarreraUniversitariaEspecialidad',
                                data: {
                                    'DescCarreraUniversitariaEspecialidad': $('#txtDescripcion').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#txtCode').val(),
                                    'CodigoCarreraUniversitaria': $('#cbCUniversitaria').val()
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
                                    $('#tblCarreraUniversitariaEspecialidads').DataTable().ajax.reload();
                                    $('.needs-validation :input').val('');
                                    $(".needs-validation").find("select").prop("selectedIndex", 0);
                                    form.classList.remove('was-validated')
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
                        confirmButtonText: 'Si,actualizar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/CarreraUniversitariaEspecialidad/ActualizarCarreraUniversitariaEspecialidad',
                                data: {
                                    'CarreraUniversitariaEspecialidadId': $('#txtCodigo').val(),
                                    'DescCarreraUniversitariaEspecialidad': $('#txtDescripcione').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#txtCodee').val(),
                                    'CodigoCarreraUniversitaria': $('#cbCUniversitariae').val(),
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
                                    $('#tblCarreraUniversitariaEspecialidads').DataTable().ajax.reload();
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

    $('#tblCarreraUniversitariaEspecialidads').DataTable({
        ajax: {
            "url": '/CarreraUniversitariaEspecialidad/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "carreraUniversitariaEspecialidadId" },
            { "data": "descCarreraUniversitariaEspecialidad" },
            { "data": "codigoCarreraUniversitariaEspecialidad" },
            { "data": "descCarreraUniversitaria" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.carreraUniversitariaEspecialidadId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.carreraUniversitariaEspecialidadId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(CarreraUniversitariaEspecialidadId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CarreraUniversitariaEspecialidad/MostrarCarreraUniversitariaEspecialidad?CarreraUniversitariaEspecialidadId=' + CarreraUniversitariaEspecialidadId, [], function (CarreraUniversitariaEspecialidadDTO) {
        $('#txtCodigo').val(CarreraUniversitariaEspecialidadDTO.carreraUniversitariaEspecialidadId);
        $('#txtDescripcione').val(CarreraUniversitariaEspecialidadDTO.descCarreraUniversitariaEspecialidad);
        $('#txtCodee').val(CarreraUniversitariaEspecialidadDTO.codigoCarreraUniversitariaEspecialidad);
        $('#cbCUniversitariae').val(CarreraUniversitariaEspecialidadDTO.codigoCarreraUniversitaria);
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
                url: '/CarreraUniversitariaEspecialidad/EliminarCarreraUniversitariaEspecialidad',
                data: {
                    'CarreraUniversitariaEspecialidadId': id
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
                    $('#tblCarreraUniversitariaEspecialidads').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaCarreraUniversitariaEspecialidad() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/CarreraUniversitariaEspecialidad/cargaCombs', [], function (Json) {
        var carreraUniversitaria = Json["data"];
        $("select#cbCUniversitaria").html("");
        $.each(carreraUniversitaria, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitaria + '>' + this.descCarreraUniversitaria + '</option>'
            $("select#cbCUniversitaria").append(RowContent);
        });
        $("select#cbCUniversitariae").html("");
        $.each(carreraUniversitaria, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitaria + '>' + this.descCarreraUniversitaria + '</option>'
            $("select#cbCUniversitariae").append(RowContent);
        });
    });
}