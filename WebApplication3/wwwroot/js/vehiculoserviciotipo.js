var tblVehiculoServicioTipos;

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
                                url: '/VehiculoServicioTipo/InsertarVehiculoServicioTipo',
                                data: {
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'Codigo': $('#txtCode').val(),
                                    'VehiculoServicioGrupoId': $('#cbFK').val()
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
                                    $('#tblVehiculoServicioTipos').DataTable().ajax.reload();
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
                                url: '/VehiculoServicioTipo/ActualizarVehiculoServicioTipo',
                                data: {
                                    'VehiculoServicioTipoId': $('#txtCodigo').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'Codigo': $('#txtCodee').val(),
                                    'VehiculoServicioGrupoId': $('#cbFKe').val()
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
                                    $('#tblVehiculoServicioTipos').DataTable().ajax.reload();
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

    $('#tblVehiculoServicioTipos').DataTable({
        ajax: {
            "url": '/VehiculoServicioTipo/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "vehiculoServicioTipoId" },
            { "data": "descVehiculoServicioTipo" },
            { "data": "codigoVehiculoServicioTipo" },
            { "data": "descVehiculoServicioGrupo" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.vehiculoServicioTipoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.vehiculoServicioTipoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(VehiculoServicioTipoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/VehiculoServicioTipo/MostrarVehiculoServicioTipo?VehiculoServicioTipoId=' + VehiculoServicioTipoId, [], function (VehiculoServicioTipoDTO) {
        $('#txtCodigo').val(VehiculoServicioTipoDTO.vehiculoServicioTipoId);
        $('#txtDescripcione').val(VehiculoServicioTipoDTO.descVehiculoServicioTipo);
        $('#txtCodee').val(VehiculoServicioTipoDTO.codigoVehiculoServicioTipo);
        $('#cbFKe').val(VehiculoServicioTipoDTO.vehiculoServicioGrupoId);
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
                url: '/VehiculoServicioTipo/EliminarVehiculoServicioTipo',
                data: {
                    'VehiculoServicioTipoId': id
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
                    $('#tblVehiculoServicioTipos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaVehiculoServicioTipo() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/VehiculoServicioTipo/cargaCombs', [], function (Json) {
        var vehiculoServicioGrupo = Json["data"];
        $("select#cbFK").html("");
        $.each(vehiculoServicioGrupo, function () {
            var RowContent = '<option value=' + this.vehiculoServicioGrupoId + '>' + this.descVehiculoServicioGrupo + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(vehiculoServicioGrupo, function () {
            var RowContent = '<option value=' + this.vehiculoServicioGrupoId + '>' + this.descVehiculoServicioGrupo + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}