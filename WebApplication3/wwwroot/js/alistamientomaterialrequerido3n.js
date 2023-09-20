var tblAlistamientoMaterialRequerido3Ns;

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
                                url: '/AlistamientoMaterialRequerido3N/InsertarAlistamientoMaterialRequerido3N',
                                data: {
                                    'CodigoAlistamientoMaterialRequerido3N': $("#txtCodAli").val(),
                                    'Subclasificacion3N': $('#txtSubclasificacion').val(),
                                    'Ponderado': $('#txtPonderado').val(),
                                    'CodigoAlistamientoMaterialRequerido2N': $('#cbFK').val()
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
                                    $('#tblAlistamientoMaterialRequerido3Ns').DataTable().ajax.reload();
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
                                url: '/AlistamientoMaterialRequerido3N/ActualizarAlistamientoMaterialRequerido3N',
                                data: {
                                    'AlistamientoMaterialRequerido3NId': $('#txtCodigo').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $("#txtCodAlie").val(),
                                    'Subclasificacion3N': $('#txtSubclasificacione').val(),
                                    'Ponderado': $('#txtPonderadoe').val(),
                                    'CodigoAlistamientoMaterialRequerido2N': $('#cbFKe').val()
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
                                    $('#tblAlistamientoMaterialRequerido3Ns').DataTable().ajax.reload();
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

    $('#tblAlistamientoMaterialRequerido3Ns').DataTable({
        ajax: {
            "url": '/AlistamientoMaterialRequerido3N/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialRequerido3NId" },
            { "data": "subclasificacion3N" },
            { "data": "codigoAlistamientoMaterialRequerido3N" },
            { "data": "ponderado3Nivel" },
            { "data": "subclasificacion2N" },
            { "data": "codigoAlistamientoMaterialRequerido2N" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialRequerido3NId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialRequerido3NId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(AlistamientoMaterialRequerido3NId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/AlistamientoMaterialRequerido3N/MostrarAlistamientoMaterialRequerido3N?AlistamientoMaterialRequerido3NId=' + AlistamientoMaterialRequerido3NId, [], function (AlistamientoMaterialRequerido3NDTO) {
        $('#txtCodigo').val(AlistamientoMaterialRequerido3NDTO.alistamientoMaterialRequerido3NId);
        $('#txtCodAlie').val(AlistamientoMaterialRequerido3NDTO.codigoAlistamientoMaterialRequerido3N);
        $('#txtSubclasificacione').val(AlistamientoMaterialRequerido3NDTO.subclasificacion3N);
        $('#txtPonderadoe').val(AlistamientoMaterialRequerido3NDTO.ponderado3Nivel);
        $('#cbFKe').val(AlistamientoMaterialRequerido3NDTO.codigoAlistamientoMaterialRequerido2N);
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
                url: '/AlistamientoMaterialRequerido3N/EliminarAlistamientoMaterialRequerido3N',
                data: {
                    'AlistamientoMaterialRequerido3NId': id
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
                    $('#tblAlistamientoMaterialRequerido3Ns').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaAlistamientoMaterialRequerido3N() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/AlistamientoMaterialRequerido3N/cargaCombs', [], function (Json) {
        var alistamientoMaterialRequerido2N = Json["data"];

        $("select#cbFK").html("");
        $("select#cbFKe").html("");
        $.each(alistamientoMaterialRequerido2N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido2N + '>' + this.subclasificacion + '</option>'
            $("select#cbFK").append(RowContent);
            $("select#cbFKe").append(RowContent);
        });

    });
}