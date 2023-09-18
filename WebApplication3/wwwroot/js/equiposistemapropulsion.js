var tblEquipoSistemaPropulsions;

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
                                url: '/EquipoSistemaPropulsion/InsertarEquipoSistemaPropulsion',
                                data: {
                                    'CodigoEquipoSistemaPropulsion': $('#txtCodiEq'),
                                    'DescEquipoSistemaPropulsion': $('#txtDescripcion').val(),
                                    'CodigoSubSistemaPropulsion': $('#cbFK').val()
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
                                    $('#tblEquipoSistemaPropulsions').DataTable().ajax.reload();
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
                                url: '/EquipoSistemaPropulsion/ActualizarEquipoSistemaPropulsion',
                                data: {
                                    'EquipoSistemaPropulsionId': $('#txtCodigo').val(),
                                    'CodigoEquipoSistemaPropulsion': $('#txtCodiEqe'),
                                    'DescEquipoSistemaPropulsion': $('#txtDescripcione').val(),
                                    'CodigoSubSistemaPropulsion': $('#cbFKe').val()
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
                                    $('#tblEquipoSistemaPropulsions').DataTable().ajax.reload();
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

    $('#tblEquipoSistemaPropulsions').DataTable({
        ajax: {
            "url": '/EquipoSistemaPropulsion/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "equipoSistemaPropulsionId" },
            { "data": "codigoEquipoSistemaPropulsion" },
            { "data": "descEquipoSistemaPropulsion" },
            { "data": "descSubSistemaPropulsion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.equipoSistemaPropulsionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.equipoSistemaPropulsionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

    cargaCombo();

});

function edit(EquipoSistemaPropulsionId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/EquipoSistemaPropulsion/MostrarEquipoSistemaPropulsion?EquipoSistemaPropulsionId=' + EquipoSistemaPropulsionId, [], function (EquipoSistemaPropulsionDTO) {
        $('#txtCodigo').val(EquipoSistemaPropulsionDTO.equipoSistemaPropulsionId);
        $('#txtCodiEqe').val(EquipoSistemaPropulsionDTO.codigoEquipoSistemaPropulsion);
        $('#txtDescripcione').val(EquipoSistemaPropulsionDTO.descEquipoSistemaPropulsion);
        $('#cbFKe').val(EquipoSistemaPropulsionDTO.CodigoSubSistemaPropulsion);
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
                url: '/EquipoSistemaPropulsion/EliminarEquipoSistemaPropulsion',
                data: {
                    'EquipoSistemaPropulsionId': id
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
                    $('#tblEquipoSistemaPropulsions').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaEquipoSistemaPropulsion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/EquipoSistemaPropulsion/cargaCombs', [], function (Json) {
        var subSistemaPropulsion = Json["data"];

        $("select#cbFK").html("");
        $("select#cbFKe").html("");
        $.each(subSistemaPropulsion, function () {
            var RowContent = '<option value=' + this.codigoSubSistemaPropulsion + '>' + this.descSubSistemaPropulsion + '</option>'
            $("select#cbFK").append(RowContent);
            $("select#cbFKe").append(RowContent);
        });

    });
}