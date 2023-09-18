var tblSecuenciaCargas;

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
                                url: '/SecuenciaCarga/InsertarSecuenciaCarga',
                                data: {
                                    'NOM_TABLA': $('#txtNOM_TABLA').val(),
                                    'NUM_SECUENCIA': $('#txtNUM_SECUENCIA').val(),
                                    'FEC_REGISTRO': $('#txtFEC_REGISTRO').val(),
                                    'USR_REGISTRO': $('#txtUSR_REGISTRO').val(),
                                    'FEC_ACTUALIZO': $('#txtFEC_ACTUALIZO').val(),
                                    'USR_ACTUALIZO': $('#txtUSR_ACTUALIZO').val()
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
                                    $('#tblSecuenciaCargas').DataTable().ajax.reload();
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
                                url: '/SecuenciaCarga/ActualizarSecuenciaCarga',
                                data: {
                                    'NOM_TABLA': $('#txtNOM_TABLAe').val(),
                                    'NUM_SECUENCIA': $('#txtNUM_SECUENCIAe').val(),
                                    'FEC_REGISTRO': $('#txtFEC_REGISTROe').val(),
                                    'USR_REGISTRO': $('#txtUSR_REGISTROe').val(),
                                    'FEC_ACTUALIZO': $('#txtFEC_ACTUALIZOe').val(),
                                    'USR_ACTUALIZO': $('#txtUSR_ACTUALIZOe').val()
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
                                    $('#tblSecuenciaCargas').DataTable().ajax.reload();
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

    $('#tblSecuenciaCargas').DataTable({
        ajax: {
            "url": '/SecuenciaCarga/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "noM_TABLA" },
            { "data": "nuM_SECUENCIA" },
            { "data": "feC_REGISTRO" },
            { "data": "usR_REGISTRO" },
            { "data": "feC_ACTUALIZO" },
            { "data": "usR_ACTUALIZO" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit("' + row.noM_TABLA + '") title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar("' + row.noM_TABLA + '") title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(noM_TABLA) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/SecuenciaCarga/MostrarSecuenciaCarga?NOM_TABLA=' + noM_TABLA, [], function (SecuenciaCargaDTO) {
        $('#txtNOM_TABLAe').val(SecuenciaCargaDTO.noM_TABLA);
        $('#txtNUM_SECUENCIAe').val(SecuenciaCargaDTO.nuM_SECUENCIA);
        $('#txtFEC_REGISTROe').val(SecuenciaCargaDTO.feC_REGISTRO);
        $('#txtUSR_REGISTROe').val(SecuenciaCargaDTO.usR_REGISTRO);
        $('#txtFEC_ACTUALIZOe').val(SecuenciaCargaDTO.feC_ACTUALIZO);
        $('#txtUSR_ACTUALIZOe').val(SecuenciaCargaDTO.usR_ACTUALIZO);
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
                url: '/SecuenciaCarga/EliminarSecuenciaCarga',
                data: {
                    'NOM_TABLA': id
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
                    $('#tblSecuenciaCargas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaSecuenciaCarga() {
    $('#listar').hide();
    $('#nuevo').show();
}

