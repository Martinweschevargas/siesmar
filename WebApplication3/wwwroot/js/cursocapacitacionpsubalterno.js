var tblCursoCapacitacionPSubalternos;


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
                                url: '/CursoCapacitacionPSubalterno/InsertarCursoCapacitacionPSubalterno',
                                data: {
                                    'DescCursoCapacitacion': $('#txtDescripcion').val(),
                                    'CodigoCursoCapacitacion': $('#txtCode').val(),
                                    'DuracionCursoCapacitacion': $('#txtDuracion').val(),
                                    'InicioTerminoCursoCapacitacion': $('#txtInicioFinal').val()
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
                                    $('#tblCursoCapacitacionPSubalternos').DataTable().ajax.reload();
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
                                url: '/CursoCapacitacionPSubalterno/ActualizarCursoCapacitacionPSubalterno',
                                data: {
                                    'CursoCapacitacionPSubalternoId': $('#txtCodigo').val(),
                                    'DescCursoCapacitacion': $('#txtDescripcione').val(),
                                    'CodigoCursoCapacitacion': $('#txtCodee').val(),
                                    'DuracionCursoCapacitacion': $('#txtDuracione').val(),
                                    'InicioTerminoCursoCapacitacion': $('#txtInicioFinale').val(),
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
                                    $('#tblCursoCapacitacionPSubalternos').DataTable().ajax.reload();
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

    $('#tblCursoCapacitacionPSubalternos').DataTable({
        ajax: {
            "url": '/CursoCapacitacionPSubalterno/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cursoCapacitacionPSubalternoId" },
            { "data": "descCursoCapacitacion" },
            { "data": "codigoCursoCapacitacion" },
            { "data": "duracionCursoCapacitacion" },
            { "data": "inicioTerminoCursoCapacitacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.cursoCapacitacionPSubalternoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.cursoCapacitacionPSubalternoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(CursoCapacitacionPSubalternoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CursoCapacitacionPSubalterno/MostrarCursoCapacitacionPSubalterno?CursoCapacitacionPSubalternoId=' + CursoCapacitacionPSubalternoId, [], function (CursoCapacitacionPSubalternoDTO) {
        $('#txtCodigo').val(CursoCapacitacionPSubalternoDTO.cursoCapacitacionPSubalternoId);
        $('#txtDescripcione').val(CursoCapacitacionPSubalternoDTO.descCursoCapacitacion);
        $('#txtCodee').val(CursoCapacitacionPSubalternoDTO.codigoCursoCapacitacion);
        $('#txtDuracione').val(CursoCapacitacionPSubalternoDTO.duracionCursoCapacitacion);
        $('#txtInicioFinale').val(CursoCapacitacionPSubalternoDTO.inicioTerminoCursoCapacitacion);
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
                url: '/CursoCapacitacionPSubalterno/EliminarCursoCapacitacionPSubalterno',
                data: {
                    'CursoCapacitacionPSubalternoId': id
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
                    $('#tblCursoCapacitacionPSubalternos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaCursoCapacitacionPSubalterno() {
    $('#listar').hide();
    $('#nuevo').show();
}

