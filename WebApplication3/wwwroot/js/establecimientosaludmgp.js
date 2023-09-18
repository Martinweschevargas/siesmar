var tblEstablecimientoSaludMGPs;

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
                                url: '/EstablecimientoSaludMGP/InsertarEstablecimientoSaludMGP',
                                data: {
                                    'CodigoEstablecimiento': $('#txtCodigoEstablecimiento').val(),
                                    'CodigoRenaes': $('#txtCodigoRenaes').val(),
                                    'EntidadMilitarId': $('#cbFK').val(),
                                    'Descripcion': $('#txtDescripcion').val(),
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
                                    $('#tblEstablecimientoSaludMGPs').DataTable().ajax.reload();
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
                                url: '/EstablecimientoSaludMGP/ActualizarEstablecimientoSaludMGP',
                                data: {
                                    'EstablecimientoSaludMGPId': $('#txtCodigo').val(),
                                    'CodigoEstablecimiento': $('#txtCodigoEstablecimientoe').val(),
                                    'CodigoRenaes': $('#txtCodigoRenaese').val(),
                                    'EntidadMilitarId': $('#cbFKe').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
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
                                    $('#tblEstablecimientoSaludMGPs').DataTable().ajax.reload();
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

    $('#tblEstablecimientoSaludMGPs').DataTable({
        ajax: {
            "url": '/EstablecimientoSaludMGP/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "establecimientoSaludMGPId" },
            { "data": "codigoEstablecimientoRENAES" },
            { "data": "codigoRenaesMindef" },
            { "data": "descEntidadMilitar" },
            { "data": "descEstablecimientoSalud" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.establecimientoSaludMGPId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.establecimientoSaludMGPId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(EstablecimientoSaludMGPId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/EstablecimientoSaludMGP/MostrarEstablecimientoSaludMGP?EstablecimientoSaludMGPId=' + EstablecimientoSaludMGPId, [], function (EstablecimientoSaludMGPDTO) {
        $('#txtCodigo').val(EstablecimientoSaludMGPDTO.establecimientoSaludMGPId);
        $('#txtCodigoEstablecimientoe').val(EstablecimientoSaludMGPDTO.codigoEstablecimientoRENAES);
        $('#txtCodigoRenaese').val(EstablecimientoSaludMGPDTO.codigoRenaesMindef);
        $('#cbFKe').val(EstablecimientoSaludMGPDTO.entidadMilitarId);
        $('#txtDescripcione').val(EstablecimientoSaludMGPDTO.descEstablecimientoSalud);
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
                url: '/EstablecimientoSaludMGP/EliminarEstablecimientoSaludMGP',
                data: {
                    'EstablecimientoSaludMGPId': id
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
                    $('#tblEstablecimientoSaludMGPs').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaEstablecimientoSaludMGP() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/EstablecimientoSaludMGP/cargaCombs', [], function (Json) {
        var entidadMilitar = Json["data"];
        $("select#cbFK").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.entidadMilitarId + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.entidadMilitarId + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}