var tblAlistamientoMaterialRequerido2Ns;

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
                                url: '/AlistamientoMaterialRequerido2N/InsertarAlistamientoMaterialRequerido2N',
                                data: {
                                    'Subclasificacion': $('#txtSubclasificacion').val(),
                                    'Ponderado': $('#txtPonderado').val(),
                                    'Equipo': $('#txtEquipo').val(),
                                    'CodigoAlistamientoMaterialRequerido2N': $('#txtFK').val(),
                                    'CodigoAlistamientoMaterialRequerido1N': $('#cbFKR').val()
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
                                    $('#tblAlistamientoMaterialRequerido2Ns').DataTable().ajax.reload();
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
                                url: '/AlistamientoMaterialRequerido2N/ActualizarAlistamientoMaterialRequerido2N',
                                data: {
                                    'AlistamientoMaterialRequerido2NId': $('#txtCodigo').val(),
                                    'Subclasificacion': $('#txtSubclasificacione').val(),
                                    'Ponderado': $('#txtPonderadoe').val(),
                                    'Equipo': $('#txtEquipoe').val(),
                                    'CodigoAlistamientoMaterialRequerido2N': $('#txtFKe').val(),
                                    'CodigoAlistamientoMaterialRequerido1N': $('#cbFKRe').val()
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
                                    $('#tblAlistamientoMaterialRequerido2Ns').DataTable().ajax.reload();
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

    $('#tblAlistamientoMaterialRequerido2Ns').DataTable({
        ajax: {
            "url": '/AlistamientoMaterialRequerido2N/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialRequerido2NId" },
            { "data": "subclasificacion" },
            { "data": "ponderado2Nivel" },
            { "data": "equipo" },
            { "data": "codigoAlistamientoMaterialRequerido2N" },
            { "data": "capacidadIntrinseca" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialRequerido2NId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialRequerido2NId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(AlistamientoMaterialRequerido2NId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/AlistamientoMaterialRequerido2N/MostrarAlistamientoMaterialRequerido2N?AlistamientoMaterialRequerido2NId=' + AlistamientoMaterialRequerido2NId, [], function (AlistamientoMaterialRequerido2NDTO) {
        $('#txtCodigo').val(AlistamientoMaterialRequerido2NDTO.alistamientoMaterialRequerido2NId);
        $('#txtSubclasificacione').val(AlistamientoMaterialRequerido2NDTO.subclasificacion);
        $('#txtPonderadoe').val(AlistamientoMaterialRequerido2NDTO.ponderado2Nivel);
        $('#txtEquipoe').val(AlistamientoMaterialRequerido2NDTO.equipo);
        $('#txtFKe').val(AlistamientoMaterialRequerido2NDTO.codigoAlistamientoMaterialRequerido2N);
        $('#cbFKRe').val(AlistamientoMaterialRequerido2NDTO.codigoAlistamientoMaterialRequerido1N);
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
                url: '/AlistamientoMaterialRequerido2N/EliminarAlistamientoMaterialRequerido2N',
                data: {
                    'AlistamientoMaterialRequerido2NId': id
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
                    $('#tblAlistamientoMaterialRequerido2Ns').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaAlistamientoMaterialRequerido2N() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/AlistamientoMaterialRequerido2N/cargaCombs', [], function (Json) {
        var alistamientoMaterialRequerido1N = Json["data"];

        $("select#cbFKR").html("");
        $.each(alistamientoMaterialRequerido1N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido1N + '>' + this.capacidadIntrinseca + '</option>'
            $("select#cbFKR").append(RowContent);
        });
        $("select#cbFKRe").html("");
        $.each(alistamientoMaterialRequerido1N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido1N + '>' + this.capacidadIntrinseca + '</option>'
            $("select#cbFKRe").append(RowContent);

        });

        });
    }
