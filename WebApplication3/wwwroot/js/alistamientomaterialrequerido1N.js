var tblAlistamientoMaterialRequerido1Ns;

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
                                url: '/AlistamientoMaterialRequerido1N/InsertarAlistamientoMaterialRequerido1N',
                                data: {
                                    'Capacidad': $('#txtCapacidad').val(),
                                    'Ponderado': $('#txtPonderado').val(),
                                    'CodigoAlistamientoMaterialRequerido1N': $('#txtAMR').val()

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
                                    $('#tblAlistamientoMaterialRequerido1Ns').DataTable().ajax.reload();
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
                                url: '/AlistamientoMaterialRequerido1N/ActualizarAlistamientoMaterialRequerido1N',
                                data: {
                                    'AlistamientoMaterialRequerido1NId': $('#txtCodigo').val(),
                                    'Capacidad': $('#txtCapacidade').val(),
                                    'Ponderado': $('#txtPonderadoe').val(),
                                    'CodigoAlistamientoMaterialRequerido1N': $('#txtAMRe').val()
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
                                    $('#tblAlistamientoMaterialRequerido1Ns').DataTable().ajax.reload();
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

    $('#tblAlistamientoMaterialRequerido1Ns').DataTable({
        ajax: {
            "url": '/AlistamientoMaterialRequerido1N/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialRequerido1NId" },
            { "data": "capacidadIntrinseca" },
            { "data": "ponderado1N" },
            { "data": "codigoAlistamientoMaterialRequerido1N" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialRequerido1NId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialRequerido1NId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(AlistamientoMaterialRequerido1NId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/AlistamientoMaterialRequerido1N/MostrarAlistamientoMaterialRequerido1N?AlistamientoMaterialRequerido1NId=' + AlistamientoMaterialRequerido1NId, [], function (AlistamientoMaterialRequerido1NDTO) {
        $('#txtCodigo').val(AlistamientoMaterialRequerido1NDTO.alistamientoMaterialRequerido1NId);
        $('#txtCapacidade').val(AlistamientoMaterialRequerido1NDTO.capacidadIntrinseca);
        $('#txtPonderadoe').val(AlistamientoMaterialRequerido1NDTO.ponderado1N);
        $('#txtAMRe').val(AlistamientoMaterialRequerido1NDTO.codigoAlistamientoMaterialRequerido1N);
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
                url: '/AlistamientoMaterialRequerido1N/EliminarAlistamientoMaterialRequerido1N',
                data: {
                    'AlistamientoMaterialRequerido1NId': id
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
                    $('#tblAlistamientoMaterialRequerido1Ns').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaAlistamientoMaterialRequerido1N() {
    $('#listar').hide();
    $('#nuevo').show();
}

