var tblUsuarioPermisos;
var lstFormatos;

$(document).ready(function () {
    cargarDatosCombos();
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
                        text: "Se agregará el Permiso al Usuario!",
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si,agregar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/UsuarioPermiso/InsertarUsuarioPermiso',
                                data: {
                                    'UsuarioFormatoId': $('#cbFormato').val(),
                                    'PermisoId': $('#cbPermiso').val(),
                                    'Estado': $('#txtEstado').val(),
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
                                    $('#tblUsuarioPermisos').DataTable().ajax.reload();
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
                                url: '/UsuarioPermiso/ActualizarUsuarioPermiso',
                                data: {
                                    'UsuarioPermisoId': $('#txtCodigo').val(),
                                    'UsuarioFormatoId': $('#cbFormatoe').val(),
                                    'PermisoId': $('#cbPermisoe').val(),
                                    'Estado': $('#txtEstadoe').val(),
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
                                    $('#tblUsuarioPermisos').DataTable().ajax.reload();
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

    tblUsuarioPermisos = $('#tblUsuarioPermisos').DataTable({
        ajax: {
            "url": '/UsuarioPermiso/cargarTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "usuarioPermisoId" },
            { "data": "usuario" },
            { "data": "dependencia" },
            { "data": "dependenciaSubordinada" },
            { "data": "formato" },
            { "data": "permiso" },
            { "data": "estado" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.usuarioPermisoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.usuarioPermisoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function cargarDatosCombos() {
    $.getJSON('/UsuarioPermiso/cargarCombos', [], function (json) {

        $("select#cbUsuario").html("");
        $("select#cbUsuario").append('<option value=0>Seleccion</option>');
        $("select#cbUsuarioe").html("");
        $("select#cbUsuarioe").append('<option value=0>Seleccion</option>');
        $.each(json['lstUsuarios'], function () {
            var RowContent = '<option value=' + this.id + '>' + this.nombreCompleto+' '+this.apellidoPaterno+' '+this.apellidoMaterno + '</option>'
            $("select#cbUsuario").append(RowContent);
            $("select#cbUsuarioe").append(RowContent);
        });

        $("select#cbDependenciaSubordinado").html("");
        $("select#cbDependenciaSubordinadoe").html("");
        $.each(json['lstDependenciasSubordinado'], function () {
            var RowContent = '<option value=' + this.dependenciaSubordinadoId + '>' + this.nombre + '</option>'
            $("select#cbDependenciaSubordinado").append(RowContent);
            $("select#cbDependenciaSubordinadoe").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");
        $.each(json['lstDependencia'], function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbPermiso").html("");
        $("select#cbPermisoe").html("");
        $.each(json['lstPermisos'], function () {
            var RowContent = '<option value=' + this.permisoId + '>' + this.nombre + '</option>'
            $("select#cbPermiso").append(RowContent);
            $("select#cbPermisoe").append(RowContent);
        });
    });
}

function edit(UsuarioPermisoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/UsuarioPermiso/MostrarUsuarioPermiso?UsuarioPermisoId=' + UsuarioPermisoId, [], function (UsuarioPermisoDTO) {
        $('#txtCodigo').val(UsuarioPermisoDTO.usuarioRolId);
        $('#txtUsuarioe').val(UsuarioPermisoDTO.usuarioId);
        $('#cbRole').val(UsuarioPermisoDTO.rolId);
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
                url: '/UsuarioPermiso/EliminarUsuarioPermiso',
                data: {
                    'UsuarioPermisoId': id
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
                    $('#tblUsuarioPermisos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevoUsuarioPermiso() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarCombo() {
    var opt = $('select#cbNivel').val();
    if (opt == "0") {
        $('#2do').hide();
    }
    if (opt == "1") {
        $('#2do').show();
        $('#3ro').hide();
    }
    if (opt == "2") {
        $('#2do').hide();
        $('#3ro').show();
    }
    var opt2 = $('select#cbNivele').val();
    if (opt2 == 0) {
        $('#2do2').hide();
    }
    if (opt2 == "1") {
        $('#2do2').show();
        $('#3ro2').hide();
    }
    if (opt2 == "2") {
        $('#2do2').hide();
        $('#3ro2').show();
    }
}

function cambiarFormato() {
    var flag = $('#flag').val();
    var dependencia = $('#cbDependencia').val();
    var dependenciaSubordinada = $('#cbDependenciaSubordinado').val();
    var nivel = $('#cbNivel').val();
    var idUsuario = $('#cbUsuario').val();

    $.getJSON('/UsuarioPermiso/cargarFormatoUsuario?Usuario='+idUsuario, [], function (json) {
        $("select#cbFormato").html("");
        $("select#cbFormatoe").html("");
        $.each(json['lstFormatos'], function () {
            if (nivel == 1) {
                if (this.dependenciaId == dependencia && this.flag == flag) {
                    var RowContent = '<option value=' + this.usuarioFormatoId + '>' + this.descFormato + '</option>'
                    $("select#cbFormato").append(RowContent);
                    $("select#cbFormatoe").append(RowContent);
                }
            } else {
                if (this.dependenciaSubordinadaId == dependenciaSubordinada && this.flag == flag) {
                    var RowContent = '<option value=' + this.usuarioFormatoId + '>' + this.descFormato + '</option>'
                    $("select#cbFormato").append(RowContent);
                    $("select#cbFormatoe").append(RowContent);
                }

            }
        });
    });
}
