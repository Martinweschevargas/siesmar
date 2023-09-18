var tblBlockVillaNavals;

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
                                url: '/BlockVillaNaval/InsertarBlockVillaNaval',
                                data: {
                                    'CodigoBlockVillaNaval': $('#txtCodB').val(),
                                    'DescBlockVillaNaval': $('#txtDescripcion').val(),
                                    'CodigoVillaNaval': $('#cbFK').val()
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
                                    $('#tblBlockVillaNavals').DataTable().ajax.reload();
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
                                url: '/BlockVillaNaval/ActualizarBlockVillaNaval',
                                data: {
                                    'BlockVillaNavalId': $('#txtCodigo').val(),
                                    'CodigoBlockVillaNaval': $('#txtCodBe').val(),
                                    'DescBlockVillaNaval': $('#txtDescripcione').val(),
                                    'CodigoVillaNaval': $('#cbFKe').val()
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
                                    $('#tblBlockVillaNavals').DataTable().ajax.reload();
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

   tblBlockVillaNavals = $('#tblBlockVillaNavals').DataTable({
        ajax: {
            "url": '/BlockVillaNaval/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "blockVillaNavalId" },
            { "data": "codigoBlockVillaNaval" },
            { "data": "descBlockVillaNaval" },
            { "data": "descVillaNaval" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.blockVillaNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.blockVillaNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(BlockVillaNavalId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BlockVillaNaval/MostrarBlockVillaNaval?BlockVillaNavalId=' + BlockVillaNavalId, [], function (BlockVillaNavalDTO) {
        $('#txtCodigo').val(BlockVillaNavalDTO.blockVillaNavalId);
        $('#txtCodBe').val(BlockVillaNavalDTO.codigoBlockVillaNaval);
        $('#txtDescripcione').val(BlockVillaNavalDTO.descBlockVillaNaval);
        $('#cbFKe').val(BlockVillaNavalDTO.codigoVillaNaval);
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
                url: '/BlockVillaNaval/EliminarBlockVillaNaval',
                data: {
                    'BlockVillaNavalId': id
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
                    $('#tblBlockVillaNavals').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaBlockVillaNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/BlockVillaNaval/cargaCombs', [], function (Json) {
        var villaNaval = Json["data"];

        $("select#cbFK").html("");
        $("select#cbFKe").html("");
        $.each(villaNaval, function () {
            var RowContent = '<option value=' + this.codigoVillaNaval + '>' + this.descVillaNaval + '</option>'
            $("select#cbFK").append(RowContent);
            $("select#cbFKe").append(RowContent);
        });

    });
}