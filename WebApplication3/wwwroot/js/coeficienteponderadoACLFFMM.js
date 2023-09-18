var tblCoeficientePonderadoACLFFMMs;

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
                                url: '/CoeficientePonderadoACLFFMM/InsertarCoeficientePonderadoACLFFMM',
                                data: {
                                    'CombustibleLubricante': $('#txtCombustible').val(),
                                    'CoeficientePonderacion': $('#txtCoeficiente').val(),
                                    'CLExistente': $('#txtExistencia').val(),
                                    'CLRequerido': $('#txtRequerida').val(),
                                    'Total': $('#txtPorcentaje').val(),
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
                                    $('#tblCoeficientePonderadoACLFFMMs').DataTable().ajax.reload();
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
                                url: '/CoeficientePonderadoACLFFMM/ActualizarCoeficientePonderadoACLFFMM',
                                data: {
                                    'CoeficientePonderadoACLFFMMId': $('#txtCodigo').val(),
                                    'CombustibleLubricante': $('#txtCombustiblee').val(),
                                    'CoeficientePonderacion': $('#txtCoeficientee').val(),
                                    'CLExistente': $('#txtExistenciae').val(),
                                    'CLRequerido': $('#txtRequeridae').val(),
                                    'Total': $('#txtPorcentajee').val(),
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
                                    $('#tblCoeficientePonderadoACLFFMMs').DataTable().ajax.reload();
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

    $('#tblCoeficientePonderadoACLFFMMs').DataTable({
        ajax: {
            "url": '/CoeficientePonderadoACLFFMM/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "coeficientePonderadoACLFFMMId" },
            { "data": "combustibleLubricante" },
            { "data": "coeficientePonderacion" },
            { "data": "clExistente" },
            { "data": "clRequerido" },
            { "data": "total" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.coeficientePonderadoACLFFMMId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.coeficientePonderadoACLFFMMId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(CoeficientePonderadoACLFFMMId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CoeficientePonderadoACLFFMM/MostrarCoeficientePonderadoACLFFMM?CoeficientePonderadoACLFFMMId=' + CoeficientePonderadoACLFFMMId, [], function (CoeficientePonderadoACLFFMMDTO) {
        $('#txtCodigo').val(CoeficientePonderadoACLFFMMDTO.coeficientePonderadoACLFFMMId);
        $('#txtCombustiblee').val(CoeficientePonderadoACLFFMMDTO.combustibleLubricante);
        $('#txtCoeficientee').val(CoeficientePonderadoACLFFMMDTO.coeficientePonderacion);
        $('#txtExistenciae').val(CoeficientePonderadoACLFFMMDTO.clExistente);
        $('#txtRequeridae').val(CoeficientePonderadoACLFFMMDTO.clRequerido);
        $('#txtPorcentajee').val(CoeficientePonderadoACLFFMMDTO.total);
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
                url: '/CoeficientePonderadoACLFFMM/EliminarCoeficientePonderadoACLFFMM',
                data: {
                    'CoeficientePonderadoACLFFMMId': id
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
                    $('#tblCoeficientePonderadoACLFFMMs').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaCoeficientePonderadoACLFFMM() {
    $('#listar').hide();
    $('#nuevo').show();
}

