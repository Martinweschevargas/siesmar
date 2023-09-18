var tblUsuarios;

$(document).ready(function () {
    //cargarDatosCombos();
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
                                url: '/Usuario/ActualizarUsuario',
                                data: {
                                    'Codigo': $('#txtCodigo').val(),
                                    'Controlador': $('#txtControladore').val(),
                                    'Nombre': $('#txtFormatoReportee').val(),
                                    'PeriodoId': $('#cbPeriodoe').val(),
                                    'Flag': $('#flage').val(),
                                    'Dependencia': $('select#cbDependenciae').val(),
                                    'DpendenciaSubordinada': $('select#cbDependenciaSubordinadoe').val(),
                                    'Nivel': $('#cbNivele').val()
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
                                    $('#tblUsuarios').DataTable().ajax.reload();
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
        });

    tblUsuarios = $('#tblUsuarios').DataTable({
        ajax: {
            "url": '/Usuario/cargarTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "id" },
            { "data": "foto" },
            { "data": "nombres" },
            { "data": "nombre1" },
            { "data": "nombre2" },
            { "data": "nombre3" },
            { "data": "nombres" },
            { "data": "nombreCompleto" },
            { "data": "apellidoPaterno" },
            { "data": "apellidoMaterno" },
            { "data": "cip" },
            { "data": "descEspecialidad" },
            { "data": "descCalificacion" },
            { "data": "tipoPersona" },
            { "data": "tipoDocumento" },
            { "data": "documento" },
            { "data": "sexo" },
            { "data": "fechaIngreso" },
            { "data": "ubigeoOldDomicilio" },
            { "data": "ubigeoDomicilio" },
            { "data": "correoInterno" },
            { "data": "correoExterno" },
            { "data": "telefonoFijo" },
            { "data": "telefonoCelular" },
            { "data": "descDependencia" },
            { "data": "descGradoInstruccion" },
            { "data": "descRol" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.usuarioId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.usuarioId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                "targets": "[7,8]",
                "width": "120px",
            }
        ]
    });

});

function cargarDatosCombos() {
    $.getJSON('/Usuario/CargarCombos', [], function (json) {

        $("select#cbDependenciaSubordinado").html("");
        $("select#cbDependenciaSubordinadoe").html("");
        $.each(json['lstDependenciaSubordinado'], function () {
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
    });
}

function edit(UsuarioId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/Usuario/MostrarUsuario?UsuarioId=' + UsuarioId, [], function (FormatoReporteDTO) {
        $('#txtCodigo').val(FormatoReporteDTO.formatoReporteId);
        $('#txtControladore').val(FormatoReporteDTO.controladorFormatoReporte);
        $('#txtFormatoReportee').val(FormatoReporteDTO.nombreFormatoReporte);
        $('#cbPeriodoe').val(FormatoReporteDTO.periodoId);
        $('#flage').val(FormatoReporteDTO.flag);
        $('select#cbDependencia option[value=' + FormatoReporteDTO.dependenciaId + ']').prop("selected", "true");
        $('select#cbDependenciaSubordinado option[value=' + FormatoReporteDTO.dependenciaSubordinadoId + ']').prop("selected", "true");
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
                url: '/Usuario/EliminarUsuario',
                data: {
                    'UsuarioId': id
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
                    $('#tblUsuarios').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}


