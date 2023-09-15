$(document).ready(function () {
    $('#tblJefaturaCapitania').DataTable({
        "columnDefs": [
            { "className": "dt-center", "targets": "_all" }
        ],
        pagingType: 'full_numbers',
    });
    cargarDatos();
    $('#nuevo').bootstrapValidator({
        fields: {
            txtDescripcion: {
                validators: {
                    notEmpty: {
                        message: 'La Jefatura Capitania es obligatorio'
                    }
                }
            }
        }
    });

    $('#editar').bootstrapValidator({
        fields: {
            txtDescripcione: {
                validators: {
                    notEmpty: {
                        message: 'La Jefatura Capitania es obligatorio'
                    }
                }
            }
        }
    });
});

function cargarDatos() {
    $.getJSON('/JefaturaCapitania/cargarDatos', [], function (JefaturaCapitania) {
        $("table#tblJefaturaCapitania tbody").html("");
        $.each(JefaturaCapitania, function () {
            var RowContent = '<tr>' +
                '<td>' + this.jefaturaCapitaniaId + '</td>' +
                '<td>' + this.descJefaturaCapitania + '</td>' +
                '<td><a onclick=edit(' + this.jefaturaCapitaniaId + ') title="Actualizar" class="btn btn-primary btn-edit" style="display: inline-block;"><i class="fa fa-check-square-o" aria-hidden="true"></i></a>' +
                '<a onclick=eliminar(' + this.jefaturaCapitaniaId+') title="Eliminar" class="btn btn-danger btn-delete" style="display: inline-block;"><i class="fa fa-minus-square-o" aria-hidden="true"></i></a></td>' +
                '</tr>';
            $("table#tblJefaturaCapitania tbody").append(RowContent);
        });
    });
}

function edit(JefaturaCapitaniaId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/JefaturaCapitania/MostrarJefaturaCapitania?JefaturaCapitaniaId=' + JefaturaCapitaniaId, [], function (JefaturaCapitaniaDTO) {
        $('#txtCodigo').val(JefaturaCapitaniaDTO.jefaturaCapitaniaId);
        $('#txtDescripcione').val(JefaturaCapitaniaDTO.descJefaturaCapitania);
    });
}

function actualizarJefaturaCapitania() {
    $.ajax({
        type: "POST",
        url: '/JefaturaCapitania/ActualizarJefaturaCapitania',
        data: {
            'JefaturaCapitaniaId': $('#txtCodigo').val(),
            'DescJefaturaCapitania': $('#txtDescripcione').val()
        },
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function () {
            $('#listar').show();
            $('#editar').hide();
            cargarDatos();
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_PRIMARY,
                title: 'Información',
                message: 'Se actualizo la Jefatura capitania.'
            }); 
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al actualizar la Jefatura capitania.'
            });     
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}


function eliminar(JefaturaCapitaniaId) {
    $.ajax({
        type: "POST",
        url: '/JefaturaCapitania/EliminarJefaturaCapitania',
        data: {
            'JefaturaCapitaniaId': JefaturaCapitaniaId
        },
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function () {
            cargarDatos();
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_PRIMARY,
                title: 'Información',
                message: 'Se elimino la Jefatura Capitania.'
            });
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al eliminar la Jefatura capitania.'
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
        url: '/JefaturaCapitania/InsertarJefaturaCapitania',
        data: {
            'DescJefaturaCapitania': $('#txtDescripcion').val()
        },
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function () {
            $('#listar').show();
            $('#nuevo').hide();
            cargarDatos();
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_PRIMARY,
                title: 'Información',
                message: 'Se registro la Jefatura Capitania.'
            });
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al registar la Jefatura Capitania.'
            });
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function nuevaJefaturaCapitania() {
    $('#listar').hide();
    $('#nuevo').show();
}
