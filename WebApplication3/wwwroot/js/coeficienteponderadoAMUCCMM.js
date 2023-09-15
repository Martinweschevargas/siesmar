var tblCoeficientePonderadoAMUCCMMs;

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
                                url: '/CoeficientePonderadoAMUCCMM/InsertarCoeficientePonderadoAMUCCMM',
                                data: {
                                    'Municion': $('#txtMunicion').val(),
                                    'CoeficientePonderacion': $('#txtCoeficiente').val(),
                                    'ExistenciaMunicion': $('#txtExistencia').val(),
                                    'MunicionRequerida': $('#txtRequerida').val(),
                                    'TotalPorcentaje': $('#txtPorcentaje').val(),
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
                                    $('#tblCoeficientePonderadoAMUCCMMs').DataTable().ajax.reload();
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
                                url: '/CoeficientePonderadoAMUCCMM/ActualizarCoeficientePonderadoAMUCCMM',
                                data: {
                                    'CoeficientePonderadoAMUCCMMId': $('#txtCodigo').val(),
                                    'Municion': $('#txtMunicione').val(),
                                    'CoeficientePonderacion': $('#txtCoeficientee').val(),
                                    'ExistenciaMunicion': $('#txtExistenciae').val(),
                                    'MunicionRequerida': $('#txtRequeridae').val(),
                                    'TotalPorcentaje': $('#txtPorcentajee').val(),
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
                                    $('#tblCoeficientePonderadoAMUCCMMs').DataTable().ajax.reload();
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

    $('#tblCoeficientePonderadoAMUCCMMs').DataTable({
        ajax: {
            "url": '/CoeficientePonderadoAMUCCMM/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "coeficientePonderadoAMUCCMMId" },
            { "data": "municion" },
            { "data": "coeficientePonderacion" },
            { "data": "existenciaMunicion" },
            { "data": "municionRequerida" },
            { "data": "totalPorcentaje" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.coeficientePonderadoAMUCCMMId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.coeficientePonderadoAMUCCMMId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(CoeficientePonderadoAMUCCMMId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CoeficientePonderadoAMUCCMM/MostrarCoeficientePonderadoAMUCCMM?CoeficientePonderadoAMUCCMMId=' + CoeficientePonderadoAMUCCMMId, [], function (CoeficientePonderadoAMUCCMMDTO) {
        $('#txtCodigo').val(CoeficientePonderadoAMUCCMMDTO.coeficientePonderadoAMUCCMMId);
        $('#txtMunicione').val(CoeficientePonderadoAMUCCMMDTO.municion);
        $('#txtCoeficientee').val(CoeficientePonderadoAMUCCMMDTO.coeficientePonderacion);
        $('#txtExistenciae').val(CoeficientePonderadoAMUCCMMDTO.existenciaMunicion);
        $('#txtRequeridae').val(CoeficientePonderadoAMUCCMMDTO.municionRequerida);
        $('#txtPorcentajee').val(CoeficientePonderadoAMUCCMMDTO.totalPorcentaje);
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
                url: '/CoeficientePonderadoAMUCCMM/EliminarCoeficientePonderadoAMUCCMM',
                data: {
                    'CoeficientePonderadoAMUCCMMId': id
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
                    $('#tblCoeficientePonderadoAMUCCMMs').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaCoeficientePonderadoAMUCCMM() {
    $('#listar').hide();
    $('#nuevo').show();
}

