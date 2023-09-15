var tblEstadoFase2Ejecucions;


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
                                url: '/EstadoFase2Ejecucion/InsertarEstadoFase2Ejecucion',
                                data: {
                                    'DescEstadoFase2Ejecucion': $('#txtDescripcion').val(),
                                    'CodigoEstadoFase2Ejecucion': $('#txtCode').val()
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
                                    $('#tblEstadoFase2Ejecucions').DataTable().ajax.reload();
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });

                            callback(true);
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
                                url: '/EstadoFase2Ejecucion/ActualizarEstadoFase2Ejecucion',
                                data: {
                                    'EstadoFase2EjecucionId': $('#txtCodigo').val(),
                                    'DescEstadoFase2Ejecucion': $('#txtDescripcione').val(),
                                    'CodigoEstadoFase2Ejecucion': $('#txtCodee').val(),
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
                                    $('#tblEstadoFase2Ejecucions').DataTable().ajax.reload();
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });

                            callback(true);
                        }
                    })
                    
                }
                form.classList.add('was-validated')
            }, false)
        })

    $('#tblEstadoFase2Ejecucions').DataTable({
        ajax: {
            "url": '/EstadoFase2Ejecucion/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "estadoFase2EjecucionId" },
            { "data": "descEstadoFase2Ejecucion" },
            { "data": "codigoEstadoFase2Ejecucion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.estadoFase2EjecucionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.estadoFase2EjecucionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(EstadoFase2EjecucionId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/EstadoFase2Ejecucion/MostrarEstadoFase2Ejecucion?EstadoFase2EjecucionId=' + EstadoFase2EjecucionId, [], function (EstadoFase2EjecucionDTO) {
        $('#txtCodigo').val(EstadoFase2EjecucionDTO.estadoFase2EjecucionId);
        $('#txtDescripcione').val(EstadoFase2EjecucionDTO.descEstadoFase2Ejecucion);
        $('#txtCodee').val(EstadoFase2EjecucionDTO.codigoEstadoFase2Ejecucion);
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
                url: '/EstadoFase2Ejecucion/EliminarEstadoFase2Ejecucion',
                data: {
                    'EstadoFase2EjecucionId': id
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
                    $('#tblEstadoFase2Ejecucions').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaEstadoFase2Ejecucion() {
    $('#listar').hide();
    $('#nuevo').show();
}

