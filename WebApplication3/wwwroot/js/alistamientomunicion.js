var tblAlistamientoMunicions;

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
                                url: '/AlistamientoMunicion/InsertarAlistamientoMunicion',
                                data: {
                                    'CodigoAlistamientoMunicion': $('#cbMuni').val(),
                                    'CodigoSistemaMunicion': $('#cbSistema').val(),
                                    'CodigoSubsistemaMunicion': $('#cbSubsistema').val(),
                                    'Equipo': $('#txtEquipo').val(),
                                    'Municion': $('#txtMunicion').val(),
                                    'Existente': $('#txtExistente').val(),
                                    'Necesaria': $('#txtNecesaria').val(),
                                    'Coeficiente': $('#txtCoeficiente').val(),
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
                                    $('#tblAlistamientoMunicions').DataTable().ajax.reload();
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
                                url: '/AlistamientoMunicion/ActualizarAlistamientoMunicion',
                                data: {
                                    'AlistamientoMunicionId': $('#txtCodigo').val(),
                                    'CodigoAlistamientoMunicion': $('#cbMunie').val(),
                                    'CodigoSistemaMunicion': $('#cbSistemae').val(),
                                    'CodigoSubsistemaMunicion': $('#cbSubsistemae').val(),
                                    'Equipo': $('#txtEquipoe').val(),
                                    'Municion': $('#txtMunicione').val(),
                                    'Existente': $('#txtExistentee').val(),
                                    'Necesaria': $('#txtNecesariae').val(),
                                    'Coeficiente': $('#txtCoeficientee').val(),
                                },
                                beforeSend: function () {
                                    $('#loader-6').show();
                                },
                                success: function (mensaje) {
                                    if (mensaje == "1") {
                                        Swal.fire(
                                            'Actualizado!',
                                            'Se actualizo con éxito.',
                                            'success',
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
                                    $('#tblAlistamientoMunicions').DataTable().ajax.reload();
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

    $('#tblAlistamientoMunicions').DataTable({
        ajax: {
            "url": '/AlistamientoMunicion/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMunicionId" },
            { "data": "codigoAlistamientoMunicion" },
            { "data": "descSistemaMunicion" },
            { "data": "descSubsistemaMunicion" },
            { "data": "equipo" },
            { "data": "municion" },
            { "data": "existente" },
            { "data": "necesaria" },
            { "data": "coeficientePonderacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMunicionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMunicionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

    cargaComboSistema();
    cargaComboSubsistema();

});

function edit(AlistamientoMunicionId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/AlistamientoMunicion/MostrarAlistamientoMunicion?AlistamientoMunicionId=' + AlistamientoMunicionId, [], function (AlistamientoMunicionDTO) {
        $('#txtCodigo').val(AlistamientoMunicionDTO.alistamientoMunicionId);
        $('#cbMunie').val(AlistamientoMunicionDTO.codigoSistemaMunicion);
        $('#cbSistemae').val(AlistamientoMunicionDTO.codigoSistemaMunicion);
        $('#cbSubsistemae').val(AlistamientoMunicionDTO.codigoSubsistemaMunicion);
        $('#txtEquipoe').val(AlistamientoMunicionDTO.equipo);
        $('#txtMunicione').val(AlistamientoMunicionDTO.municion);
        $('#txtExistentee').val(AlistamientoMunicionDTO.existente);
        $('#txtNecesariae').val(AlistamientoMunicionDTO.necesaria);
        $('#txtCoeficientee').val(AlistamientoMunicionDTO.coeficientePonderacion);
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
                url: '/AlistamientoMunicion/EliminarAlistamientoMunicion',
                data: {
                    'AlistamientoMunicionId': id
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
                    $('#tblAlistamientoMunicions').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaAlistamientoMunicion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaComboSistema() {
    $.getJSON('/AlistamientoMunicion/cargaCombsSistemas', [], function (Json) {
        var sistemaMunicion = Json["data"];

        $("select#cbSistema").html("");
        $("select#cbSistemae").html("");
        $.each(sistemaMunicion, function () {
            var RowContent = '<option value=' + this.codigoSistemaMunicion + '>' + this.descSistemaMunicion + '</option>'
            $("select#cbSistema").append(RowContent);
            $("select#cbSistemae").append(RowContent);
        });

    });
}

function cargaComboSubsistema() {
    $.getJSON('/AlistamientoMunicion/cargaCombsSubsistemas', [], function (Json) {
        var subsistemaMunicion = Json["data"];

        $("select#cbSubsistema").html("");
        $("select#cbSubsistemae").html("");
        $.each(subsistemaMunicion, function () {
            var RowContent = '<option value=' + this.codigoSubsistemaMunicion + '>' + this.descSubsistemaMunicion + '</option>'
            $("select#cbSubsistema").append(RowContent);
            $("select#cbSubsistemae").append(RowContent);
        });

    });
}