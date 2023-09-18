var tblModeloBienServicioDenominacions;

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
                                url: '/ModeloBienServicioDenominacion/InsertarModeloBienServicioDenominacion',
                                data: {
                                    'DescModeloBienServicioDenominacion': $('#txtDescripcion').val(),
                                    'CodigoModeloBienServicioDenominacion': $('#txtCode').val(),
                                    'ModeloBienServicioSubcampoId': $('#cbMBSSubcampo').val()
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
                                    $('#tblModeloBienServicioDenominacions').DataTable().ajax.reload();
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
                                url: '/ModeloBienServicioDenominacion/ActualizarModeloBienServicioDenominacion',
                                data: {
                                    'ModeloBienServicioDenominacionId': $('#txtCodigo').val(),
                                    'DescModeloBienServicioDenominacion': $('#txtDescripcione').val(),
                                    'CodigoModeloBienServicioDenominacion': $('#txtCodee').val(),
                                    'ModeloBienServicioSubcampoId': $('#cbMBSSubcampoe').val()
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
                                    $('#tblModeloBienServicioDenominacions').DataTable().ajax.reload();
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

    $('#tblModeloBienServicioDenominacions').DataTable({
        ajax: {
            "url": '/ModeloBienServicioDenominacion/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "modeloBienServicioDenominacionId" },
            { "data": "descModeloBienServicioDenominacion" },
            { "data": "codigoModeloBienServicioDenominacion" },
            { "data": "descModeloBienServicioSubcampo" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.modeloBienServicioDenominacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.modeloBienServicioDenominacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(ModeloBienServicioDenominacionId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ModeloBienServicioDenominacion/MostrarModeloBienServicioDenominacion?ModeloBienServicioDenominacionId=' + ModeloBienServicioDenominacionId, [], function (ModeloBienServicioDenominacionDTO) {
        $('#txtCodigo').val(ModeloBienServicioDenominacionDTO.modeloBienServicioDenominacionId);
        $('#txtDescripcione').val(ModeloBienServicioDenominacionDTO.descModeloBienServicioDenominacion);
        $('#txtCodee').val(ModeloBienServicioDenominacionDTO.codigoModeloBienServicioDenominacion);
        $('#cbMBSSubcampoe').val(ModeloBienServicioDenominacionDTO.modeloBienServicioSubcampoId);
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
                url: '/ModeloBienServicioDenominacion/EliminarModeloBienServicioDenominacion',
                data: {
                    'ModeloBienServicioDenominacionId': id
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
                    $('#tblModeloBienServicioDenominacions').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaModeloBienServicioDenominacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/ModeloBienServicioDenominacion/cargaCombs', [], function (Json) {
        var modeloBienServicioSubcampo = Json["data"];
        $("select#cbMBSSubcampo").html("");
        $.each(modeloBienServicioSubcampo, function () {
            var RowContent = '<option value=' + this.modeloBienServicioSubcampoId + '>' + this.descModeloBienServicioSubcampo + '</option>'
            $("select#cbMBSSubcampo").append(RowContent);
        });
        $("select#cbMBSSubcampoe").html("");
        $.each(modeloBienServicioSubcampo, function () {
            var RowContent = '<option value=' + this.modeloBienServicioSubcampoId + '>' + this.descModeloBienServicioSubcampo + '</option>'
            $("select#cbMBSSubcampoe").append(RowContent);
        });
    });
}