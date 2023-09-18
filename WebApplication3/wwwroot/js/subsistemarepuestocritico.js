var tblSubsistemaRepuestoCriticos;

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
                                url: '/SubsistemaRepuestoCritico/InsertarSubsistemaRepuestoCritico',
                                data: {
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'SistemaRepuestoCriticoId': $('#cbFK').val()
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
                                    $('#tblSubsistemaRepuestoCriticos').DataTable().ajax.reload();
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
                                url: '/SubsistemaRepuestoCritico/ActualizarSubsistemaRepuestoCritico',
                                data: {
                                    'SubsistemaRepuestoCriticoId': $('#txtCodigo').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'SistemaRepuestoCriticoId': $('#cbFKe').val()
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
                                    $('#tblSubsistemaRepuestoCriticos').DataTable().ajax.reload();
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

    $('#tblSubsistemaRepuestoCriticos').DataTable({
        ajax: {
            "url": '/SubsistemaRepuestoCritico/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "subsistemaRepuestoCriticoId" },
            { "data": "descSubsistemaRepuestoCritico" },
            { "data": "descSistemaRepuestoCritico" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.subsistemaRepuestoCriticoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.subsistemaRepuestoCriticoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(SubsistemaRepuestoCriticoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/SubsistemaRepuestoCritico/MostrarSubsistemaRepuestoCritico?SubsistemaRepuestoCriticoId=' + SubsistemaRepuestoCriticoId, [], function (SubsistemaRepuestoCriticoDTO) {
        $('#txtCodigo').val(SubsistemaRepuestoCriticoDTO.subsistemaRepuestoCriticoId);
        $('#txtDescripcione').val(SubsistemaRepuestoCriticoDTO.descSubsistemaRepuestoCritico);
        $('#cbFKe').val(SubsistemaRepuestoCriticoDTO.sistemaRepuestoCriticoId);
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
                url: '/SubsistemaRepuestoCritico/EliminarSubsistemaRepuestoCritico',
                data: {
                    'SubsistemaRepuestoCriticoId': id
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
                    $('#tblSubsistemaRepuestoCriticos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaSubsistemaRepuestoCritico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/SubsistemaRepuestoCritico/cargaCombs', [], function (Json) {
        var sistemaRepuestoCritico = Json["data"];
        $("select#cbFK").html("");
        $.each(sistemaRepuestoCritico, function () {
            var RowContent = '<option value=' + this.sistemaRepuestoCriticoId + '>' + this.descSistemaRepuestoCritico + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(sistemaRepuestoCritico, function () {
            var RowContent = '<option value=' + this.sistemaRepuestoCriticoId + '>' + this.descSistemaRepuestoCritico + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}