var tblUsuarioDependencias;

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
                        text: "Se agregará el Rol al Usuario!",
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si,agregar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/UsuarioDependencia/InsertarUsuarioDependencia',
                                data: {
                                    'UsuarioId': $('#cbUsuario').val(),
                                    'DependenciaId': $('#cbDependencia').val()
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
                                    $('#tblUsuarioDependencias').DataTable().ajax.reload();
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
                                url: '/UsuarioDependencia/ActualizarUsuarioDependencia',
                                data: {
                                    'UsuarioDependenciaId': $('#txtCodigo').val(),
                                    'UsuarioId': $('#cbUsuarioe').val(),
                                    'DependenciaId': $('#cbDependenciae').val()
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
                                    $('#tblUsuarioDependencias').DataTable().ajax.reload();
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

    tblUsuarioDependencias = $('#tblUsuarioDependencias').DataTable({
        ajax: {
            "url": '/UsuarioDependencia/cargarTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "usuarioDependenciaId" },
            { "data": "nombreUsuario" },
            { "data": "descDependencia" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.usuarioDependenciaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.usuarioDependenciaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
    cargarDatosCombos();
});

function edit(UsurioDependenciaId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/UsuarioDependencia/MostrarUsuarioDependencia?UsuarioDependenciaId=' + UsurioDependenciaId, [], function (UsuarioDependenciaDTO) {
        $('#txtCodigo').val(UsuarioDependenciaDTO.usuarioDependenciaId);
        $('select#cbUsuario option[value=' + UsuarioDependenciaDTO.usuarioId + ']').prop("selected", "true");
        $('select#cbDependencia option[value=' + UsuarioDependenciaDTO.dependencia + ']').prop("selected", "true");        
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
                url: '/UsuarioDependencia/EliminarUsuarioDependencia',
                data: {
                    'UsuarioDependenciaId': id
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
                    $('#tblUsuarioDependencias').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}


function cargarDatosCombos() {
    $.getJSON('/UsuarioDependencia/cargarDatos', [], function (json) {

        $("select#cbUsuario").html("");
        $("select#cbUsuarioe").html("");
        $.each(json['lstUsuarios'], function () {
            var RowContent = '<option value=' + this.id + '>' + this.nombreCompleto + ' ' + this.apellidoPaterno + '</option>'
            $("select#cbUsuario").append(RowContent);
            $("select#cbUsuarioe").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");
        $.each(json['lstDependencias'], function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });
    });
}


function nuevoUsuariosDependencias() {
    $('#listar').hide();
    $('#nuevo').show();
}
