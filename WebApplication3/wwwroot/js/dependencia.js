
﻿$(document).ready(function () {
    cargarCombo();

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
                                url: '/Dependencia/InsertarDependencia',
                                data: {
                                    'NombreDependencia': $('#txtNombre').val(),
                                    'DescDependencia': $('#txtDescripcion').val(),
                                    'CodigoDependencia': $('#txtcodigoDep').val(),
                                    'NivelDependenciaId': $('#cbNivel').val(),
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
                                    $('#tblDependencias').DataTable().ajax.reload();
                                    $('.needs-validation :input').val('');
                                    $(".needs-validation").find("select").prop("selectedIndex", 0);
                                    form.classList.remove('was-validated')
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
                                url: '/Dependencia/ActualizarDependencia',
                                data: {
                                    'DependenciaId': $('#txtCodigo').val(),
                                    'NombreDependencia': $('#txtNombree').val(),
                                    'DescDependencia': $('#txtDescripcione').val(),
                                    'CodigoDependencia': $('#txtcodigoDepe').val(),
                                    'NivelDependenciaId': $('#cbNivele').val(),

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
                                    $('#tblDependencias').DataTable().ajax.reload();
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

    $('#tblDependencias').DataTable({
        ajax: {
            "url": '/Dependencia/CargarDatos',
            "type": "GET", 
            "datatype": "json"
        },
        "columns": [
            { "data": "dependenciaId" },
            { "data": "nombreDependencia" },
            { "data": "descDependencia" },
            { "data": "descNivelDependencia" },
            { "data": "codigoDependencia" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.dependenciaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.dependenciaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

    cargarCombo();

});

function cargarCombo() {
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

function edit(DependenciaId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/Dependencia/MostrarDependencia?DependenciaId=' + DependenciaId, [], function (DependenciaDTO) {
        $('#txtCodigo').val(DependenciaDTO.dependenciaId);
        $('#txtNombree').val(DependenciaDTO.nombreDependencia);
        $('#txtDescripcione').val(DependenciaDTO.descDependencia);
        $('#txtcodigoDepe').val(DependenciaDTO.codigoDependencia);
        $('#cbNivele').val(DependenciaDTO.nivelDependenciaId);
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
                url: '/Dependencia/EliminarDependencia',
                data: {
                    'DependenciaId': id
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
                    $('#tblDependencias').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDependencia() {
    $('#listar').hide();
    $('#nuevo').show();
}
