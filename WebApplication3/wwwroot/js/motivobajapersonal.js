var tblMotivoBajaPersonals;

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
                                url: '/MotivoBajaPersonal/InsertarMotivoBajaPersonal',
                                data: {
                                    'FlagMotivoBajaPersonal': $('#txtFlag').val(),
                                    'DescMotivoBajaPersonal': $('#txtDescripcion').val(),
                                    'CodigoMotivoBajaPersonal': $('#txtCode').val(),
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
                                    $('#tblMotivoBajaPersonals').DataTable().ajax.reload();
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
                                url: '/MotivoBajaPersonal/ActualizarMotivoBajaPersonal',
                                data: {
                                    'MotivoBajaPersonalId': $('#txtCodigo').val(),
                                    'FlagMotivoBajaPersonal': $('#txtFlage').val(),
                                    'DescMotivoBajaPersonal': $('#txtDescripcione').val(),
                                    'CodigoMotivoBajaPersonal': $('#txtCodee').val(),
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
                                    $('#tblMotivoBajaPersonals').DataTable().ajax.reload();
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

    $('#tblMotivoBajaPersonals').DataTable({
        ajax: {
            "url": '/MotivoBajaPersonal/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "motivoBajaPersonalId" },
            { "data": "flagMotivoBajaPersonal" },
            { "data": "descMotivoBajaPersonal" },
            { "data": "codigoMotivoBajaPersonal" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.motivoBajaPersonalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.motivoBajaPersonalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(MotivoBajaPersonalId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/MotivoBajaPersonal/MostrarMotivoBajaPersonal?MotivoBajaPersonalId=' + MotivoBajaPersonalId, [], function (MotivoBajaPersonalDTO) {
        $('#txtCodigo').val(MotivoBajaPersonalDTO.motivoBajaPersonalId);
        $('#txtFlage').val(MotivoBajaPersonalDTO.flagMotivoBajaPersonal);
        $('#txtDescripcione').val(MotivoBajaPersonalDTO.descMotivoBajaPersonal);
        $('#txtCodee').val(MotivoBajaPersonalDTO.codigoMotivoBajaPersonal);
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
                url: '/MotivoBajaPersonal/EliminarMotivoBajaPersonal',
                data: {
                    'MotivoBajaPersonalId': id
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
                    $('#tblMotivoBajaPersonals').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaMotivoBajaPersonal() {
    $('#listar').hide();
    $('#nuevo').show();
}
