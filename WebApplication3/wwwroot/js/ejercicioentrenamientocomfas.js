var tblEjercicioEntrenamientoComfass;

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
                                url: '/EjercicioEntrenamientoComfas/InsertarEjercicioEntrenamientoComfas',
                                data: {
                                    'capacidadOperativaId': $('#cbFK').val(),
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'Codigo': $('#txtCode').val(),
                                    'NivelEjercicio': $('#txtNivel').val(),
                                    'FFMM': $('#txtFFMM').val(),
                                    'CMM': $('#txtCMM').val(),
                                    'DDTT': $('#txtDDTT').val(),
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
                                    $('#tblEjercicioEntrenamientoComfass').DataTable().ajax.reload();
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
                                url: '/EjercicioEntrenamientoComfas/ActualizarEjercicioEntrenamientoComfas',
                                data: {
                                    'EjercicioEntrenamientoComfasId': $('#txtCodigo').val(),
                                    'capacidadOperativaId': $('#cbFKe').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'Codigo': $('#txtCodee').val(),
                                    'NivelEjercicio': $('#txtNivele').val(),
                                    'FFMM': $('#txtFFMMe').val(),
                                    'CMM': $('#txtCMMe').val(),
                                    'DDTT': $('#txtDDTTe').val(),
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
                                    $('#tblEjercicioEntrenamientoComfass').DataTable().ajax.reload();
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

    $('#tblEjercicioEntrenamientoComfass').DataTable({
        ajax: {
            "url": '/EjercicioEntrenamientoComfas/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ejercicioEntrenamientoComfasId" },
            { "data": "descEjercicioEntrenamientoComfas" },
            { "data": "codigoEjercicioEntrenamientoComfas" },
            { "data": "descCapacidadOperativa" },
            { "data": "nivelEjercicio" },
            { "data": "ffmm" },
            { "data": "cmm" },
            { "data": "ddtt" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ejercicioEntrenamientoComfasId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ejercicioEntrenamientoComfasId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(EjercicioEntrenamientoComfasId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/EjercicioEntrenamientoComfas/MostrarEjercicioEntrenamientoComfas?EjercicioEntrenamientoComfasId=' + EjercicioEntrenamientoComfasId, [], function (EjercicioEntrenamientoComfasDTO) {
        $('#txtCodigo').val(EjercicioEntrenamientoComfasDTO.ejercicioEntrenamientoComfasId);
        $('#txtDescripcione').val(EjercicioEntrenamientoComfasDTO.descEjercicioEntrenamientoComfas);
        $('#txtCodee').val(EjercicioEntrenamientoComfasDTO.codigoEjercicioEntrenamientoComfas);
        $('#cbFKe').val(EjercicioEntrenamientoComfasDTO.capacidadOperativaId);
        $('#txtNivele').val(EjercicioEntrenamientoComfasDTO.nivelEjercicio);
        $('#txtFFMMe').val(EjercicioEntrenamientoComfasDTO.ffmm);
        $('#txtCMMe').val(EjercicioEntrenamientoComfasDTO.cmm);
        $('#txtDDTTe').val(EjercicioEntrenamientoComfasDTO.ddtt);
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
                url: '/EjercicioEntrenamientoComfas/EliminarEjercicioEntrenamientoComfas',
                data: {
                    'EjercicioEntrenamientoComfasId': id
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
                    $('#tblEjercicioEntrenamientoComfass').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaEjercicioEntrenamientoComfas() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/EjercicioEntrenamientoComfas/cargaCombs', [], function (Json) {
        var capacidadOperativa = Json["data"];
        $("select#cbFK").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}