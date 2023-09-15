var tblComoperguardKilometroRecorridoUnidadTerrestre;

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
                        title: 'Deseas Agregar?',
                        text: "Se agregará a la tabla",
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si, Agregar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/ComoperguardKilometroRecorridoUnidadTerrestre/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'TipoVehiculoMovilId': $('#cbTipoVehiculoMovil').val(),
                                    'MarcaVehiculoId': $('#cbMarcaVehiculo').val(),
                                    'UnidadMovilTerrestreId': $('#cbUnidadMovilTerrestre').val(),
                                    'KmRecorridos': $('#txtAnioCaptura').val(),
                                    'CombustibleConsumido': $('#txtNombreNaveExtranjera').val(),
                                    'FechaInicio': $('#txtMatriculaNaveExtranjera').val(),
                                    'FechaTermino': $('#txtPaisUbigeo').val(),
                                    'Observaciones': $('#txtObservaciones').val(), 
                                },
                                beforeSend: function () {
                                    $('#loader-6').show();
                                },
                                success: function (mensaje) {
                                    if (mensaje == "1") {
                                        Swal.fire(
                                            'Agregado!',
                                            'Se Agregó con éxito.',
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
                                    $('#tblComoperguardKilometroRecorridoUnidadTerrestre').DataTable().ajax.reload();
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
                        confirmButtonText: 'Si, Actualizar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/ComoperguardKilometroRecorridoUnidadTerrestre/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'TipoVehiculoMovilId': $('#cbTipoVehiculoMovile').val(),
                                    'MarcaVehiculoId': $('#cbMarcaVehiculoe').val(),
                                    'UnidadMovilTerrestreId': $('#cbUnidadMovilTerrestree').val(),
                                    'KmRecorridos': $('#txtAnioCapturae').val(),
                                    'CombustibleConsumido': $('#txtNombreNaveExtranjerae').val(),
                                    'FechaInicio': $('#txtMatriculaNaveExtranjerae').val(),
                                    'FechaTermino': $('#txtPaisUbigeoe').val(),
                                    'Observaciones': $('#txtObservacionese').val(), 
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
                                    $('#tblComoperguardKilometroRecorridoUnidadTerrestre').DataTable().ajax.reload();
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

    $('#tblComoperguardKilometroRecorridoUnidadTerrestre').DataTable({
        ajax: {
            "url": '/ComoperguardKilometroRecorridoUnidadTerrestre/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "kilometroRecorridoUnidadTerrestreId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "descTipoVehiculoMovil" },
            { "data": "descMarcaVehiculo" },
            { "data": "descUnidadMovilTerrestre" },
            { "data": "kmrecorridos" },
            { "data": "combustibleConsumido" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "observaciones" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.kilometroRecorridoUnidadTerrestreId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.kilometroRecorridoUnidadTerrestreId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
                }
            }
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        dom: 'Bfrtip',
        buttons: [
            //csv,
            {
                extend: 'csvHtml5',
                text: 'Exportar CSV',
                filename: 'Comoperguard - Kilometros Recorridos por Unidades Terrestres',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Kilometros Recorridos por Unidades Terrestres',
                title: 'Comoperguard - Kilometros Recorridos por Unidades Terrestres',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Kilometros Recorridos por Unidades Terrestres',
                title: 'Comoperguard - Kilometros Recorridos por Unidades Terrestres',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Kilometros Recorridos por Unidades Terrestres',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-print'

            },
            //extra
            'pageLength'
        ],
        columnDefs: [
            {
                "targets": "_all",
                "className": "text-center",
            },
            {
                "targets": "[7,8]",
                "width": "180px",
            }
        ]
    });
    cargaDatos();
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComoperguardKilometroRecorridoUnidadTerrestre/Mostrar?Id=' + Id, [], function (KilometroRecorridoUnidadTerrestreDTO) {
        $('#txtCodigo').val(KilometroRecorridoUnidadTerrestreDTO.kilometroRecorridoUnidadTerrestreId);
        $('#cbJefaturaDistritoCapitaniae').val(KilometroRecorridoUnidadTerrestreDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(KilometroRecorridoUnidadTerrestreDTO.capitaniaId);
        $('#cbTipoVehiculoMovile').val(KilometroRecorridoUnidadTerrestreDTO.tipoVehiculoMovilId);
        $('#cbMarcaVehiculoe').val(KilometroRecorridoUnidadTerrestreDTO.marcaVehiculoId);
        $('#cbUnidadMovilTerrestree').val(KilometroRecorridoUnidadTerrestreDTO.unidadMovilTerrestreId);
        $('#txtAnioCapturae').val(KilometroRecorridoUnidadTerrestreDTO.kmrecorridos);
        $('#txtNombreNaveExtranjerae').val(KilometroRecorridoUnidadTerrestreDTO.combustibleConsumido);
        $('#txtMatriculaNaveExtranjerae').val(KilometroRecorridoUnidadTerrestreDTO.fechaInicio);
        $('#txtPaisUbigeoe').val(KilometroRecorridoUnidadTerrestreDTO.fechaTermino);
        $('#txtObservacionese').val(KilometroRecorridoUnidadTerrestreDTO.observaciones); 
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
                url: '/ComoperguardKilometroRecorridoUnidadTerrestre/Eliminar',
                data: {
                    'Id': id
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
                    $('#tblComoperguardKilometroRecorridoUnidadTerrestre').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardKilometroRecorridoUnidadTerrestre() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardKilometroRecorridoUnidadTerrestre/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var tipoVehiculoMovil = Json["data3"];
        var marcaVehiculo = Json["data4"];
        var unidadMovilTerrestre = Json["data5"];


        $("select#cbJefaturaDistritoCapitania").html("");
        $.each(jefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.jefaturaDistritoCapitaniaId + '>' + this.descJefaturaDistritoCapitania + '</option>'
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });
        $("select#cbJefaturaDistritoCapitaniae").html("");
        $.each(jefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.jefaturaDistritoCapitaniaId + '>' + this.descJefaturaDistritoCapitania + '</option>'
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });

        $("select#cbCapitania").html("");
        $.each(capitania, function () {
            var RowContent = '<option value=' + this.capitaniaId + '>' + this.nombre + '</option>'
            $("select#cbCapitaniae").append(RowContent);
        });
        $("select#cbCapitaniae").html("");
        $.each(capitania, function () {
            var RowContent = '<option value=' + this.capitaniaId + '>' + this.nombre + '</option>'
            $("select#cbCapitaniae").append(RowContent);
        });


        $("select#cbTipoVehiculoMovil").html("");
        $.each(tipoVehiculoMovil, function () {
            var RowContent = '<option value=' + this.tipoVehiculoMovilId + '>' + this.descTipoVehiculoMovil + '</option>'
            $("select#cbTipoVehiculoMovile").append(RowContent);
        });
        $("select#cbTipoVehiculoMovile").html("");
        $.each(tipoVehiculoMovil, function () {
            var RowContent = '<option value=' + this.tipoVehiculoMovilId + '>' + this.descTipoVehiculoMovil + '</option>'
            $("select#cbTipoVehiculoMovile").append(RowContent);
        });


        $("select#cbMarcaVehiculo").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.marcaVehiculoId + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarcaVehiculoe").append(RowContent);
        });
        $("select#cbMarcaVehiculoe").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.marcaVehiculoId + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarcaVehiculoe").append(RowContent);
        });


        $("select#cbUnidadMovilTerrestre").html("");
        $.each(unidadMovilTerrestre, function () {
            var RowContent = '<option value=' + this.unidadMovilTerrestreId + '>' + this.placaUnidadMovilTerrestre + '</option>'
            $("select#cbUnidadMovilTerrestree").append(RowContent);
        });
        $("select#cbUnidadMovilTerrestree").html("");
        $.each(unidadMovilTerrestre, function () {
            var RowContent = '<option value=' + this.unidadMovilTerrestreId + '>' + this.placaUnidadMovilTerrestre + '</option>'
            $("select#cbUnidadMovilTerrestree").append(RowContent);
        }); 
    });
}

