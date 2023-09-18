var tblUsuarioFormato;
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
                                url: '/UsuarioFormato/InsertarUsuarioFormato',
                                data: {
                                    'Formato': $('#cbFormato').val(),
                                    'Usuario': $('#cbUsuario').val()
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
                                    $('#tblUsuarioFormato').DataTable().ajax.reload();
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
                                url: '/FormatoReporte/ActualizarFormatoReporte',
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
                                    $('#tblFormatoReporte').DataTable().ajax.reload();
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

    tblUsuarioFormato = $('#tblUsuarioFormato').DataTable({
        ajax: {
            "url": '/UsuarioFormato/cargarTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "usuarioFormatoId" },
            { "data": "nombreUsuario" },
            { "data": "descFormato" },
            { "data": "descDependencia" },
            { "data": "descDependenciaSubordinado" },
            {
                "render": function (data, type, row) {
                    return (row.flag == "1" ? "Formato" : row.flag == "2" ? "Mantenimiento" : "Seguridad");
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.usuarioFormatoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.usuarioFormatoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                "targets": "[5,6]",
                "width": "120px",
            }
        ]
    });

});

function cargarDatosCombos() {
    $.getJSON('/UsuarioFormato/cargarDatos', [], function (json) {

        lstFormatos = json['lstFormatos'];

        $("select#cbUsuario").html("");
        $("select#cbUsuarioe").html("");
        $.each(json['lstUsuarios'], function () {
            var RowContent = '<option value=' + this.id + '>' + this.nombreCompleto + ' ' + this.apellidoPaterno + '</option>'
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
    });
}

function edit(FormatoReporteId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/FormatoReporte/MostrarFormatoReporte?FormatoReporteId=' + FormatoReporteId, [], function (FormatoReporteDTO) {
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
                url: '/FormatoReporte/EliminarFormatoReporte',
                data: {
                    'FormatoReporteId': id
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
                    $('#tblFormatoReporte').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevoUsuarioFormato() {
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

    $("select#cbFormato").html("");
    $("select#cbFormatoe").html("");
    $.each(lstFormatos, function () {
        if (nivel == 1) {
            if (this.dependenciaId == dependencia && this.flag == flag) {
                var RowContent = '<option value=' + this.formatoReporteId + '>' + this.nombreFormatoReporte + '</option>'
                $("select#cbFormato").append(RowContent);
                $("select#cbFormatoe").append(RowContent);
            }
        } else {
            if (this.dependenciaSubordinadaId == dependenciaSubordinada && this.flag == flag) {
                var RowContent = '<option value=' + this.formatoReporteId + '>' + this.nombreFormatoReporte + '</option>'
                $("select#cbFormato").append(RowContent);
                $("select#cbFormatoe").append(RowContent);
            }

        }
    });
}
