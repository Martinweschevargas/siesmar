$(document).ready(function () {
    $('#tblFormatoReporteSubordinados').DataTable({
        "columnDefs": [
            { "className": "dt-center", "targets": "_all" }
        ],
        pagingType: 'full_numbers',
    });
    cargaDatos();

});

function cargaDatos() {
    $.getJSON('/FormatoReporteSubordinado/cargarDatos', [], function (FormatoReporteSubordinados) {
        $("table#tblFormatoReporteSubordinados tbody").html("");
        $.each(FormatoReporteSubordinados, function () {
            var RowContent = '<tr>' +
                '<td>' + this.formatoReporteSubordinadoId + '</td>' +
                '<td>' + this.formatoReporteId + '</td>' +
                '<td>' + this.dependenciaSubordinadoId + '</td>' +
                '<td><a onclick=edit(' + this.formatoReporteSubordinadoId + ') title="Actualizar" class="btn btn-primary btn-edit" style="display: inline-block;"><i class="fa fa-check-square-o" aria-hidden="true"></i></a>' +
                '<a onclick=eliminar(' + this.formatoReporteSubordinadoId+') title="Eliminar" class="btn btn-danger btn-delete" style="display: inline-block;"><i class="fa fa-minus-square-o" aria-hidden="true"></i></a></td>' +
                '</tr>';
            $("table#tblFormatoReporteSubordinados tbody").append(RowContent);
        });
    });
}

function cargarDatosCB(selectReporteCb, selectDepenedenciaCb) {
    $.getJSON('/FormatoReporteSubordinado/cargarDatosFormatoReporteCB', [], function (FormatoReporte) {
        $("select#" + selectReporteCb).html("");
        $.each(FormatoReporte, function () {
            var RowContent = '<option value=' + this.formatoReporteId + '>' + this.nombreFormatoReporte + '</option>'
            $("select#" + selectReporteCb).append(RowContent);
        });
    });
    $.getJSON('/FormatoReporteSubordinado/cargarDatosDependenciaSubordinadoCB', [], function (DependenciaSubordinado) {
        $("select#" + selectDepenedenciaCb).html("");
        $.each(DependenciaSubordinado, function () {
            var RowContent = '<option value=' + this.dependenciaSubordinadoId + '>' + this.nombre + '</option>'
            $("select#" + selectDepenedenciaCb).append(RowContent);
        });
    });
}

function edit(FormatoReporteSubordinadoId) {
    cargarDatosCB('cbFormatoReportee', 'cbDependenciaSubordinadoe');
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/FormatoReporteSubordinado/MostrarFormatoReporteSubordinado?FormatoReporteSubordinadoId=' + FormatoReporteSubordinadoId, [], function (FormatoReporteSubordinadoDTO) {
        $('#txtCodigo').val(FormatoReporteSubordinadoDTO.formatoReporteSubordinadoId);
        $('#cbFormatoReportee').val(FormatoReporteSubordinadoDTO.formatoReporteId);
        $('#cbDependenciaSubordinadoe').val(FormatoReporteSubordinadoDTO.dependenciaSubordinadoId);
    });
}

function actualizarFormatoReporteSubordinado() {
    $.ajax({
        type: "POST",
        url: '/FormatoReporteSubordinado/ActualizarFormatoReporteSubordinado',
        data: {
            'FormatoReporteSubordinadoId': $('#txtCodigo').val(),
            'FormatoReporteId': $('#cbFormatoReportee').val(),
            'DependenciaSubordinadoId': $('#cbDependenciaSubordinadoe').val()
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
                message: 'Se actualizo la dependencia.'
            }); 
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al actualizar la dependencia.'
            });     
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}


function eliminar(FormatoReporteSubordinadoId) {
    $.ajax({
        type: "POST",
        url: '/FormatoReporteSubordinado/EliminarFormatoReporteSubordinado',
        data: {
            'FormatoReporteSubordinadoId': FormatoReporteSubordinadoId,
        },
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function () {
            cargaDatos();
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_PRIMARY,
                title: 'Información',
                message: 'Se elimino la dependencia.'
            });
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al eliminar la dependencia.'
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
        url: '/FormatoReporteSubordinado/InsertarFormatoReporteSubordinado',
        data: {
            'FormatoReporteId': $('select#cbFormatoReporte').val(),
            'DependenciaSubordinadoId': $('select#cbDependenciaSubordinado').val()
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
                message: 'Se registro la dependencia.'
            });
        },
        error: function () {
            BootstrapDialog.show({
                type: BootstrapDialog.TYPE_DANGER,
                title: 'Error',
                message: 'Ocurrio un problema al registar la dependencia.'
            });
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function nuevoFormatoReporteSubordinado() {
    $('#listar').hide();
    $('#nuevo').show();
    cargarDatosCB('cbFormatoReporte', 'cbDependenciaSubordinado');
}
