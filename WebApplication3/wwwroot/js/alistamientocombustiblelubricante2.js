var tblAlistamientoCombustibleLubricante2s;

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
                                url: '/AlistamientoCombustibleLubricante2/InsertarAlistamientoCombustibleLubricante2',
                                data: {
                                    'CodigoAlistamientoCombustibleLubricante2': $('#txtCodigoCo').val(),
                                    'Articulo': $('#txtArticulo').val(),
                                    'Equipo': $('#txtEquipo').val(),
                                    'CodigoUnidadMedida': $('#cbUnidadMedida').val(),
                                    'Cargo': $('#txtCargo').val(),
                                    'Aumento': $('#txtAumento').val(),
                                    'Consumo': $('#txtConsumo').val(),
                                    'Existencia': $('#txtExistencia').val(),
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
                                    $('#tblAlistamientoCombustibleLubricante2s').DataTable().ajax.reload();
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
                                url: '/AlistamientoCombustibleLubricante2/ActualizarAlistamientoCombustibleLubricante2',
                                data: {
                                    'AlistamientoCombustibleLubricante2Id': $('#txtCodigo').val(),
                                    'CodigoAlistamientoCombustibleLubricante2': $('#txtCodigoCoe').val(),
                                    'Articulo': $('#txtArticuloe').val(),
                                    'Equipo': $('#txtEquipoe').val(),
                                    'CodigoUnidadMedida': $('#cbUnidadMedidae').val(),
                                    'Cargo': $('#txtCargoe').val(),
                                    'Aumento': $('#txtAumentoe').val(),
                                    'Consumo': $('#txtConsumoe').val(),
                                    'Existencia': $('#txtExistenciae').val(),
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
                                    $('#tblAlistamientoCombustibleLubricante2s').DataTable().ajax.reload();
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

    $('#tblAlistamientoCombustibleLubricante2s').DataTable({
        ajax: {
            "url": '/AlistamientoCombustibleLubricante2/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoCombustibleLubricante2Id" },
            { "data": "codigoAlistamientoCombustibleLubricante2" },
            { "data": "articulo" },
            { "data": "equipo" },
            { "data": "descUnidadMedida" },
            { "data": "cargo" },
            { "data": "aumento" },
            { "data": "consumo" },
            { "data": "existencia" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoCombustibleLubricante2Id + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoCombustibleLubricante2Id + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(AlistamientoCombustibleLubricante2Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/AlistamientoCombustibleLubricante2/MostrarAlistamientoCombustibleLubricante2?AlistamientoCombustibleLubricante2Id=' + AlistamientoCombustibleLubricante2Id, [], function (AlistamientoCombustibleLubricante2DTO) {
        $('#txtCodigo').val(AlistamientoCombustibleLubricante2DTO.alistamientoCombustibleLubricante2Id);
        $('#txtCodigoCoe').val(AlistamientoCombustibleLubricante2DTO.codigoAlistamientoCombustibleLubricante2);
        $('#txtArticuloe').val(AlistamientoCombustibleLubricante2DTO.articulo);
        $('#txtEquipoe').val(AlistamientoCombustibleLubricante2DTO.equipo);
        $('#cbUnidadMedidae').val(AlistamientoCombustibleLubricante2DTO.unidadMedidaId);
        $('#txtCargoe').val(AlistamientoCombustibleLubricante2DTO.cargo);
        $('#txtAumentoe').val(AlistamientoCombustibleLubricante2DTO.aumento);
        $('#txtConsumoe').val(AlistamientoCombustibleLubricante2DTO.consumo);
        $('#txtExistenciae').val(AlistamientoCombustibleLubricante2DTO.existencia);
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
                url: '/AlistamientoCombustibleLubricante2/EliminarAlistamientoCombustibleLubricante2',
                data: {
                    'AlistamientoCombustibleLubricante2Id': id
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
                    $('#tblAlistamientoCombustibleLubricante2s').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaAlistamientoCombustibleLubricante2() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/AlistamientoCombustibleLubricante2/cargaCombs', [], function (Json) {
        var unidadMedida = Json["data"];

        $("select#cbUnidadMedida").html("");
        $("select#cbUnidadMedidae").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.codigoUnidadMedida + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedida").append(RowContent);
            $("select#cbUnidadMedidae").append(RowContent);
        });

    });
}