$(document).ready(function () {
    cargaDatosCombos();
    cargarNivel();

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
                                url: '/DependenciaSubordinado/InsertarDependenciaSubordinado',
                                data: {
                                    'Nombre': $('#txtDependenciaSubordinado').val(),
                                    'DependenciaId': $('select#cbDependencia').val(),
                                    'NivelDependenciaId': $('select#cbNivel').val()
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
                                    $('#tblDependenciaSubordinados').DataTable().ajax.reload();
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
                                url: '/DependenciaSubordinado/ActualizarDependenciaSubordinado',
                                data: {
                                    'DependenciaSubordinadoId': $('#txtCodigo').val(),
                                    'Nombre': $('#txtDependenciaSubordinadoe').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'NivelDependenciaId': $('select#cbNivele').val()
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
                                    $('#tblDependenciaSubordinados').DataTable().ajax.reload();
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

    $('#tblDependenciaSubordinados').DataTable({
        ajax: {
            "url": '/DependenciaSubordinado/cargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "dependenciaSubordinadoId" },
            { "data": "nombre" },
            { "data": "descNivelDependencia" },
            { "data": "nombreDependencia" },
            { "data": "descDependencia" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.dependenciaSubordinadoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.dependenciaSubordinadoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function cargaDatosCombos() {
    $.getJSON('/DependenciaSubordinado/cargarDatosDependenciasCB', [], function (Dependencias) {
        $("select#cbDependencia").html("");
        $.each(Dependencias, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });
    });
}

function cargarNivel() {
    $.getJSON('/Dependencia/cargarCombs', [], function (Json) {
        $("select#cbNivel").html("");
        $("select#cbNivele").html("");
        $.each(Json, function () {
            var RowContent = '<option value=' + this.nivelDependenciaId + '>' + this.descNivelDependencia + '</option>'
            $("select#cbNivel").append(RowContent);
            $("select#cbNivele").append(RowContent);
        });
    });
}

function edit(DependenciaSubordinadoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DependenciaSubordinado/MostrarDependenciaSubordinado?DependenciaSubordinadoId=' + DependenciaSubordinadoId, [], function (DependenciaSubordinadoDTO) {
        $('#txtCodigo').val(DependenciaSubordinadoDTO.dependenciaSubordinadoId);
        $('#txtDependenciaSubordinadoe').val(DependenciaSubordinadoDTO.nombre);
        $('#cbDependenciae').val(DependenciaSubordinadoDTO.dependenciaId);
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
                url: '/DependenciaSubordinado/EliminarDependenciaSubordinado',
                data: {
                    'DependenciaSubordinadoId': id
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
                    $('#tblDependenciaSubordinados').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDependenciaSubordinado() {
    $('#listar').hide();
    $('#nuevo').show();
}
