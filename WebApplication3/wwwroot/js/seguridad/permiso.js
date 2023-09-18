$(document).ready(function () {
    $('#tblPermisos').DataTable({
        "columnDefs": [
            { "className": "dt-center", "targets": "_all" }
        ],
        pagingType: 'full_numbers',
    });
    cargaDatos();

    $('#nuevo').bootstrapValidator({
        fields: {
            txtNombre: {
                validators: {
                    notEmpty: {
                        message: 'El Permiso es obligatorio'
                    }
                }
            }
        }
    });

    $('#editar').bootstrapValidator({
        fields: {
            txtNombree: {
                validators: {
                    notEmpty: {
                        message: 'El Permiso es obligatorio'
                    }
                }
            }
        }
    });
});

function cargaDatos() {
    $.getJSON('/Permiso/cargarDatos', [], function (Permisos) {
        $("table#tblPermisos tbody").html("");
        $.each(Permisos, function () {
            var RowContent = '<tr>' +
                '<td>' + this.permisoId + '</td>' +
                '<td>' + this.nombre + '</td>' +
                '<td><a onclick=edit(' + this.permisoId + ') title="Actualizar" class="btn btn-primary btn-edit" style="display: inline-block;"><i class="fa fa-check-square-o" aria-hidden="true"></i></a>' +
                '<a onclick=eliminar(' + this.permisoId+') title="Eliminar" class="btn btn-danger btn-delete" style="display: inline-block;"><i class="fa fa-minus-square-o" aria-hidden="true"></i></a></td>' +
                '</tr>';
            $("table#tblPermisos tbody").append(RowContent);
        });
    });
}

function edit(PermisoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/Permiso/MostrarPermiso?PermisoId=' + PermisoId, [], function (PermisoDTO) {
        $('#txtCodigo').val(PermisoDTO.permisoId);
        $('#txtNombree').val(PermisoDTO.nombre);
    });
}

function actualizarPermiso() {
    $.ajax({
        type: "POST",
        url: '/Permiso/ActualizarPermiso',
        data: {
            'PermisoId': $('#txtCodigo').val(),
            'Nombre': $('#txtNombree').val(),
        },
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function () {
            $('#listar').show();
            $('#editar').hide();
            cargaDatos();
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_PRIMARY,
                title: 'Información',
                message: 'Se actualizo el permiso.'
            }); 
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al actualizar el permiso.'
            });     
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}


function eliminar(PermisoId) {
    $.ajax({
        type: "POST",
        url: '/Permiso/EliminarPermiso',
        data: {
            'PermisoId': PermisoId
        },
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function () {
            cargaDatos();
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_PRIMARY,
                title: 'Información',
                message: 'Se elimino el permiso.'
            });
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al eliminar el permiso.'
            });
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function registrar() {
    $.ajax({
        type: "POST",
        url: '/Permiso/InsertarPermiso',
        data: {
            'Nombre': $('#txtNombre').val()
        },
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function () {
            $('#listar').show();
            $('#nuevo').hide();
            cargaDatos();
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_PRIMARY,
                title: 'Información',
                message: 'Se registro el permiso.'
            });
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al registar el permiso.'
            });
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function nuevoPermiso() {
    $('#listar').hide();
    $('#nuevo').show();
}
