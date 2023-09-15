var tblCoeficientePonderadoARCs;

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
                                url: '/CoeficientePonderadoARC/InsertarCoeficientePonderadoARC',
                                data: {
                                    'CapacidadIntrinseca': $('#txtCapacidad').val(),
                                    'CLM': $('#txtCLM').val(),
                                    'FM': $('#txtFM').val(),
                                    'CM': $('#txtCM').val(),
                                    'FT': $('#txtFT').val(),
                                    'AUX': $('#txtAUX').val(),
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
                                    $('#tblCoeficientePonderadoARCs').DataTable().ajax.reload();
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
                                url: '/CoeficientePonderadoARC/ActualizarCoeficientePonderadoARC',
                                data: {
                                    'CoeficientePonderadoARCId': $('#txtCodigo').val(),
                                    'CapacidadIntrinseca': $('#txtCapacidade').val(),
                                    'CLM': $('#txtCLMe').val(),
                                    'FM': $('#txtFMe').val(),
                                    'CM': $('#txtCMe').val(),
                                    'FT': $('#txtFTe').val(),
                                    'AUX': $('#txtAUXe').val(),
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
                                    $('#tblCoeficientePonderadoARCs').DataTable().ajax.reload();
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

    $('#tblCoeficientePonderadoARCs').DataTable({
        ajax: {
            "url": '/CoeficientePonderadoARC/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "coeficientePonderadoARCId" },
            { "data": "capacidadIntrinseca" },
            { "data": "clm" },
            { "data": "fm" },
            { "data": "cm" },
            { "data": "ft" },
            { "data": "aux" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.coeficientePonderadoARCId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.coeficientePonderadoARCId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(CoeficientePonderadoARCId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CoeficientePonderadoARC/MostrarCoeficientePonderadoARC?CoeficientePonderadoARCId=' + CoeficientePonderadoARCId, [], function (CoeficientePonderadoARCDTO) {
        $('#txtCodigo').val(CoeficientePonderadoARCDTO.coeficientePonderadoARCId);
        $('#txtCapacidade').val(CoeficientePonderadoARCDTO.capacidadIntrinseca);
        $('#txtCLMe').val(CoeficientePonderadoARCDTO.clm);
        $('#txtFMe').val(CoeficientePonderadoARCDTO.fm);
        $('#txtCMe').val(CoeficientePonderadoARCDTO.cm);
        $('#txtFTe').val(CoeficientePonderadoARCDTO.ft);
        $('#txtAUXe').val(CoeficientePonderadoARCDTO.aux);
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
                url: '/CoeficientePonderadoARC/EliminarCoeficientePonderadoARC',
                data: {
                    'CoeficientePonderadoARCId': id
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
                    $('#tblCoeficientePonderadoARCs').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaCoeficientePonderadoARC() {
    $('#listar').hide();
    $('#nuevo').show();
}

