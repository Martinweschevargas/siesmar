var tblCondicionAlistamientoLogisticos;

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
                                url: '/CondicionAlistamientoLogistico/InsertarCondicionAlistamientoLogistico',
                                data: {
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'Codigo': $('#txtCod').val()
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
                                    $('#tblCondicionAlistamientoLogisticos').DataTable().ajax.reload();
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
                                url: '/CondicionAlistamientoLogistico/ActualizarCondicionAlistamientoLogistico',
                                data: {
                                    'CondicionAlistamientoLogisticoId': $('#txtCodigo').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'Codigo': $('#txtCode').val(),
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
                                    $('#tblCondicionAlistamientoLogisticos').DataTable().ajax.reload();
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

    $('#tblCondicionAlistamientoLogisticos').DataTable({
        ajax: {
            "url": '/CondicionAlistamientoLogistico/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "condicionAlistamientoLogisticoId" },
            { "data": "descCondicionAlistamientoLogistico" },
            { "data": "codigoCondicionAlistamientoLogistico" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.condicionAlistamientoLogisticoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.condicionAlistamientoLogisticoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(CondicionAlistamientoLogisticoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CondicionAlistamientoLogistico/MostrarCondicionAlistamientoLogistico?CondicionAlistamientoLogisticoId=' + CondicionAlistamientoLogisticoId, [], function (CondicionAlistamientoLogisticoDTO) {
        $('#txtCodigo').val(CondicionAlistamientoLogisticoDTO.condicionAlistamientoLogisticoId);
        $('#txtDescripcione').val(CondicionAlistamientoLogisticoDTO.descCondicionAlistamientoLogistico);
        $('#txtCode').val(CondicionAlistamientoLogisticoDTO.codigoCondicionAlistamientoLogistico);
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
                url: '/CondicionAlistamientoLogistico/EliminarCondicionAlistamientoLogistico',
                data: {
                    'CondicionAlistamientoLogisticoId': id
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
                    $('#tblCondicionAlistamientoLogisticos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaCondicionAlistamientoLogistico() {
    $('#listar').hide();
    $('#nuevo').show();
}

