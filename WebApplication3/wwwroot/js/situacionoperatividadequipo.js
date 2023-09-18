var tblSituacionOperatividadEquipos;

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
                                url: '/SituacionOperatividadEquipo/InsertarSituacionOperatividadEquipo',
                                data: {
                                    'DescripcionMaterial': $('#txtDescripcion').val(),
                                    'Cantidad': $('#txtCantidad').val(),
                                    'CodigoUnidad': $('#txtCode').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'Distrito': $('#txtDistrito').val(),
                                    'Condicion': $('#txtCondicion').val(),
                                    'Observacion': $('#txtObservacion').val()
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
                                    $('#tblSituacionOperatividadEquipos').DataTable().ajax.reload();
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
                                url: '/SituacionOperatividadEquipo/ActualizarSituacionOperatividadEquipo',
                                data: {
                                    'SituacionOperatividadEquipoId': $('#txtCodigo').val(),
                                    'DescripcionMaterial': $('#txtDescripcione').val(),
                                    'Cantidad': $('#txtCantidade').val(),
                                    'CodigoUnidad': $('#txtCodee').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'Distrito': $('#txtDistritoe').val(),
                                    'Condicion': $('#txtCondicione').val(),
                                    'Observacion': $('#txtObservacione').val()
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
                                    $('#tblSituacionOperatividadEquipos').DataTable().ajax.reload();
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

    $('#tblSituacionOperatividadEquipos').DataTable({
        ajax: {
            "url": '/SituacionOperatividadEquipo/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionOperatividadEquipoId" },
            { "data": "descripcionMaterial" },
            { "data": "cantidad" },
            { "data": "codigoUnidad" },
            { "data": "ubicacion" },
            { "data": "distrito" },
            { "data": "condicion" },
            { "data": "observacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionOperatividadEquipoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionOperatividadEquipoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
});

function edit(SituacionOperatividadEquipoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/SituacionOperatividadEquipo/MostrarSituacionOperatividadEquipo?SituacionOperatividadEquipoId=' + SituacionOperatividadEquipoId, [], function (SituacionOperatividadEquipoDTO) {
        $('#txtCodigo').val(SituacionOperatividadEquipoDTO.situacionOperatividadEquipoId);
        $('#txtDescripcione').val(SituacionOperatividadEquipoDTO.descripcionMaterial);
        $('#txtCantidade').val(SituacionOperatividadEquipoDTO.cantidad);
        $('#txtCodee').val(SituacionOperatividadEquipoDTO.codigoUnidad);
        $('#txtUbicacione').val(SituacionOperatividadEquipoDTO.ubicacion);
        $('#txtDistritoe').val(SituacionOperatividadEquipoDTO.distrito);
        $('#txtCondicione').val(SituacionOperatividadEquipoDTO.condicion);
        $('#txtObservacione').val(SituacionOperatividadEquipoDTO.observacion);
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
                url: '/SituacionOperatividadEquipo/EliminarSituacionOperatividadEquipo',
                data: {
                    'SituacionOperatividadEquipoId': id
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
                    $('#tblSituacionOperatividadEquipos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaSituacionOperatividadEquipo() {
    $('#listar').hide();
    $('#nuevo').show();
}

