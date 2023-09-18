var tblUnidadMovilTerrestres;

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
                                url: '/UnidadMovilTerrestre/InsertarUnidadMovilTerrestre',
                                data: {
                                    'PlacaUnidadMovilTerrestre': $('#txtCode').val(),
                                    'MarcaVehiculoId': $('#cbMarca').val(),
                                    'TipoVehiculoMovilId': $('#cbTipo').val(),
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
                                    $('#tblUnidadMovilTerrestres').DataTable().ajax.reload();
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
                                url: '/UnidadMovilTerrestre/ActualizarUnidadMovilTerrestre',
                                data: {
                                    'UnidadMovilTerrestreId': $('#txtCodigo').val(),
                                    'PlacaUnidadMovilTerrestre': $('#txtCodee').val(),
                                    'MarcaVehiculoId': $('#cbMarcae').val(),
                                    'TipoVehiculoMovilId': $('#cbTipoe').val(),
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
                                    $('#tblUnidadMovilTerrestres').DataTable().ajax.reload();
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

    $('#tblUnidadMovilTerrestres').DataTable({
        ajax: {
            "url": '/UnidadMovilTerrestre/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "unidadMovilTerrestreId" },
            { "data": "placaUnidadMovilTerrestre" },
            { "data": "clasificacionVehiculo" },
            { "data": "descTipoVehiculoMovil" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.unidadMovilTerrestreId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.unidadMovilTerrestreId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

    cargaCombosTipo();
    cargaCombosMarca();

});

function edit(UnidadMovilTerrestreId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/UnidadMovilTerrestre/MostrarUnidadMovilTerrestre?UnidadMovilTerrestreId=' + UnidadMovilTerrestreId, [], function (UnidadMovilTerrestreDTO) {
        $('#txtCodigo').val(UnidadMovilTerrestreDTO.unidadMovilTerrestreId);
        $('#txtCodee').val(UnidadMovilTerrestreDTO.placaUnidadMovilTerrestre);
        $('#cbMarcae').val(UnidadMovilTerrestreDTO.marcaVehiculoId);
        $('#cbTipoe').val(UnidadMovilTerrestreDTO.tipoVehiculoMovilId);
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
                url: '/UnidadMovilTerrestre/EliminarUnidadMovilTerrestre',
                data: {
                    'UnidadMovilTerrestreId': id
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
                    $('#tblUnidadMovilTerrestres').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaUnidadMovilTerrestre() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombosMarca() {
    $.getJSON('/UnidadMovilTerrestre/cargaCombsMarca', [], function (Json) {
        var marcaVehiculo = Json["data"];
        $("select#cbMarca").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.marcaVehiculoId + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarca").append(RowContent);
        });
        $("select#cbMarcae").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.marcaVehiculoId + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarcae").append(RowContent);
        });
    });
}

function cargaCombosTipo() {
    $.getJSON('/UnidadMovilTerrestre/cargaCombsTipo', [], function (Json) {
        var tipoVehiculo = Json["data"];
        $("select#cbTipo").html("");
        $.each(tipoVehiculo, function () {
            var RowContent = '<option value=' + this.tipoVehiculoMovilId + '>' + this.descTipoVehiculoMovil + '</option>'
            $("select#cbTipo").append(RowContent);
        });
        $("select#cbTipoe").html("");
        $.each(tipoVehiculo, function () {
            var RowContent = '<option value=' + this.tipoVehiculoMovilId + '>' + this.descTipoVehiculoMovil + '</option>'
            $("select#cbTipoe").append(RowContent);
        });
    });
}