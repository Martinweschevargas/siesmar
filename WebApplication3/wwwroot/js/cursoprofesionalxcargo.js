var tblCursoProfesionalXCargos;

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
                                url: '/CursoProfesionalXCargo/InsertarCursoProfesionalXCargo',
                                data: {
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'TipoPersonalMilitarId': $('#cbTipo').val(),
                                    'Cargo': $('#cbCargo').val()
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
                                    $('#tblCursoProfesionalXCargos').DataTable().ajax.reload();
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
                                url: '/CursoProfesionalXCargo/ActualizarCursoProfesionalXCargo',
                                data: {
                                    'CursoProfesionalXCargoId': $('#txtCodigo').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'TipoPersonalMilitarId': $('#cbTipoe').val(),
                                    'Cargo': $('#cbCargoe').val()
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
                                    $('#tblCursoProfesionalXCargos').DataTable().ajax.reload();
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

    $('#tblCursoProfesionalXCargos').DataTable({
        ajax: {
            "url": '/CursoProfesionalXCargo/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cursoProfesionalXCargoId" },
            { "data": "descCursoCapacitacion" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descCargo" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.cursoProfesionalXCargoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.cursoProfesionalXCargoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

    cargaComboTipo();
    cargaComboCargo();

});

function edit(CursoProfesionalXCargoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CursoProfesionalXCargo/MostrarCursoProfesionalXCargo?CursoProfesionalXCargoId=' + CursoProfesionalXCargoId, [], function (CursoProfesionalXCargoDTO) {
        $('#txtCodigo').val(CursoProfesionalXCargoDTO.cursoProfesionalXCargoId);
        $('#cbTipoe').val(CursoProfesionalXCargoDTO.tipoPersonalMilitarId);
        $('#cbCargoe').val(CursoProfesionalXCargoDTO.cargoId);
        $('#txtDescripcione').val(CursoProfesionalXCargoDTO.descCursoCapacitacion);
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
                url: '/CursoProfesionalXCargo/EliminarCursoProfesionalXCargo',
                data: {
                    'CursoProfesionalXCargoId': id
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
                    $('#tblCursoProfesionalXCargos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaCursoProfesionalXCargo() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaComboTipo() {
    $.getJSON('/CursoProfesionalXCargo/cargaCombsTipo', [], function (Json) {
        var tipoPersonalMilitar = Json["data"];
        $("select#cbTipo").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.tipoPersonalMilitarId + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipo").append(RowContent);
        });
        $("select#cbTipoe").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.tipoPersonalMilitarId + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoe").append(RowContent);
        });
    });
}

function cargaComboCargo() {
    $.getJSON('/CursoProfesionalXCargo/cargaCombsCargo', [], function (Json) {
        var cargo = Json["data"];
        $("select#cbCargo").html("");
        $.each(cargo, function () {
            var RowContent = '<option value=' + this.cargoId + '>' + this.descCargo + '</option>'
            $("select#cbCargo").append(RowContent);
        });
        $("select#cbCargoe").html("");
        $.each(cargo, function () {
            var RowContent = '<option value=' + this.cargoId + '>' + this.descCargo + '</option>'
            $("select#cbCargoe").append(RowContent);
        });
    });
}