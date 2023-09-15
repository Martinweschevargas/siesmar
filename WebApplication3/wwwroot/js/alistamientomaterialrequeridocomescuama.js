var tblAlistamientoMaterialRequeridoComescuamas;

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
                                url: '/AlistamientoMaterialRequeridoComescuama/InsertarAlistamientoMaterialRequeridoComescuama',
                                data: {
                                    'CodigoAlistamientoMaterialRequeridoComescuama': $('#txtCodigoAlistMaterialRequeridoC').val(),
                                    'AlistamientoMaterialRequerido3NId': $('#cbFK').val(),
                                    'Requerido': $('#txtRequerido').val(),
                                    'Operativo': $('#txtOperativo').val(),
                                    'PorcentajeOperatividad': $('#txtPorcentajeOperatividad').val()
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
                                    $('#tblAlistamientoMaterialRequeridoComescuamas').DataTable().ajax.reload();
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
                                url: '/AlistamientoMaterialRequeridoComescuama/ActualizarAlistamientoMaterialRequeridoComescuama',
                                data: {
                                    'AlistamientoMaterialRequeridoComescuamaId': $('#txtCodigo').val(),
                                    'CodigoAlistamientoMaterialRequeridoComescuama': $('#txtCodigoAlistMaterialRequeridoCe').val(),
                                    'AlistamientoMaterialRequerido3NId': $('#cbFKe').val(),
                                    'Requerido': $('#txtRequeridoe').val(),
                                    'Operativo': $('#txtOperativoe').val(),
                                    'PorcentajeOperatividad': $('#txtPorcentajeOperatividade').val()
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
                                    $('#tblAlistamientoMaterialRequeridoComescuamas').DataTable().ajax.reload();
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

    $('#tblAlistamientoMaterialRequeridoComescuamas').DataTable({
        ajax: {
            "url": '/AlistamientoMaterialRequeridoComescuama/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialRequeridoComescuamaId" },
            { "data": "subclasificacion" },
            { "data": "codigoAlistamientoMaterialRequeridoComescuama" },
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "porcentajeOperatividad" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialRequeridoComescuamaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialRequeridoComescuamaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(AlistamientoMaterialRequeridoComescuamaId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/AlistamientoMaterialRequeridoComescuama/MostrarAlistamientoMaterialRequeridoComescuama?AlistamientoMaterialRequeridoComescuamaId=' + AlistamientoMaterialRequeridoComescuamaId, [], function (AlistamientoMaterialRequeridoComescuamaDTO) {
        $('#txtCodigo').val(AlistamientoMaterialRequeridoComescuamaDTO.alistamientoMaterialRequeridoComescuamaId);
        $('#txtCodigoAlistMaterialRequeridoCe').val(AlistamientoMaterialRequeridoComescuamaDTO.codigoAlistamientoMaterialRequeridoComescuama);
        $('#cbFKe').val(AlistamientoMaterialRequeridoComescuamaDTO.alistamientoMaterialRequerido3NId);
        $('#txtRequeridoe').val(AlistamientoMaterialRequeridoComescuamaDTO.requerido);
        $('#txtOperativoe').val(AlistamientoMaterialRequeridoComescuamaDTO.operativo);
        $('#txtPorcentajeOperatividade').val(AlistamientoMaterialRequeridoComescuamaDTO.porcentajeOperatividad);
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
                url: '/AlistamientoMaterialRequeridoComescuama/EliminarAlistamientoMaterialRequeridoComescuama',
                data: {
                    'AlistamientoMaterialRequeridoComescuamaId': id
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
                    $('#tblAlistamientoMaterialRequeridoComescuamas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaAlistamientoMaterialRequeridoComescuama() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/AlistamientoMaterialRequeridoComescuama/cargaCombs', [], function (Json) {
        var alistamientoMaterialRequerido3N = Json["data"];
        $("select#cbFK").html("");
        $.each(alistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.alistamientoMaterialRequerido3NId + '>' + this.subclasificacion + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(alistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.alistamientoMaterialRequerido3NId + '>' + this.subclasificacion + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}
