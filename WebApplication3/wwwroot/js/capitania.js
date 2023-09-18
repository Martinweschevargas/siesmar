var tblCapitanias;

$(document).ready(function () {

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
                                url: '/Capitania/InsertarCapitania',
                                data: {
                                    'NombreCapitania': $('#txtCapitania').val(),
                                    'DescCapitania': $('#txtDescripcion').val(),
                                    'CodigoCapitania': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val()
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
                                    $('#tblCapitanias').DataTable().ajax.reload();
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
                                url: '/Capitania/ActualizarCapitania',
                                data: {
                                    'CapitaniaId': $('#txtCodigo').val(),
                                    'NombreCapitania': $('#txtCapitaniae').val(),
                                    'DescCapitania': $('#txtDescripcione').val(),
                                    'CodigoCapitania': $('#txtCodigoe').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val()
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
                                    $('#tblCapitanias').DataTable().ajax.reload();
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

    $('#tblCapitanias').DataTable({
        ajax: {
            "url": '/Capitania/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "capitaniaId" },
            { "data": "nombreCapitania" },
            { "data": "descCapitania" },
            { "data": "codigoCapitania" },
            { "data": "jefaturaDistritoCapitaniaDesc"},
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.capitaniaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.capitaniaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(CapitaniaId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/Capitania/MostrarCapitania?CapitaniaId=' + CapitaniaId, [], function (CapitaniaDTO) {
        $('#txtCodigo').val(CapitaniaDTO.capitaniaId);
        $('#txtCapitaniae').val(CapitaniaDTO.nombreCapitania);
        $('#txtDescripcione').val(CapitaniaDTO.descCapitania);
        $('#txtCodigoe').val(CapitaniaDTO.codigoCapitania);
        $('select#cbJefaturaDistritoCapitaniae option[value=' + CapitaniaDTO.jefaturaDistritoCapitaniaId + ']').prop("selected", "true");
    });
}

function cargarCombo() {
    $.getJSON('/Capitania/cargarCombo', [], function (Json) {
        $("select#cbJefaturaDistritoCapitania").html("");
        $("select#cbJefaturaDistritoCapitaniae").html("");
        $.each(Json, function () {
            var RowContent = '<option value=' + this.jefaturaDistritoCapitaniaId + '>' + this.descJefaturaDistritoCapitania + '</option>'
            $("select#cbJefaturaDistritoCapitania").append(RowContent);
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });
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
                url: '/Capitania/EliminarCapitania',
                data: {
                    'CapitaniaId': id
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
                    $('#tblCapitanias').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaCapitania() {
    $('#listar').hide();
    $('#nuevo').show();
}

