var tblComoperguardMineriaIlegal;

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
                                url: '/ComoperguardMineriaIlegal/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'AreaIntervenida': $('#txtAreaIntervenida').val(),
                                    'RefMensajeNaval': $('#txtRefMensajeNaval').val(),
                                    'HoraIntervencion': $('#txtHoraIntervencion').val(),
                                    'DiaIntervencion': $('#txtDiaIntervencion').val(),
                                    'MesId': $('#cbMes').val(),
                                    'AnioIntervencion': $('#txtAnioIntervencion').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacionN').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacionN').val(),
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'CascoUnidadNaval': $('#txtCascoUnidadNaval').val(),
                                    'SectorExtraInstitucionalId': $('#cbSectorExtraInstitucional').val(),
                                    'TipoMaterialDestruidoId': $('#cbTipoMaterialDestruido').val(),
                                    'CantidadPersonasDetenidas': $('#txtCantidadPersonasDetenidas').val(),
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
                                    $('#tblComoperguardMineriaIlegal').DataTable().ajax.reload();
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
                                url: '/ComoperguardMineriaIlegal/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'AreaIntervenida': $('#txtAreaIntervenidae').val(),
                                    'RefMensajeNaval': $('#txtRefMensajeNavale').val(),
                                    'HoraIntervencion': $('#txtHoraIntervencione').val(),
                                    'DiaIntervencion': $('#txtDiaIntervencione').val(),
                                    'MesId': $('#cbMese').val(),
                                    'AnioIntervencion': $('#txtAnioIntervencione').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacionNe').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacionNe').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'CascoUnidadNaval': $('#txtCascoUnidadNavale').val(),
                                    'SectorExtraInstitucionalId': $('#cbSectorExtraInstitucionale').val(),
                                    'TipoMaterialDestruidoId': $('#cbTipoMaterialDestruidoe').val(),
                                    'CantidadPersonasDetenidas': $('#txtCantidadPersonasDetenidase').val(),
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
                                    $('#tblComoperguardMineriaIlegal').DataTable().ajax.reload();
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

    $('#tblComoperguardMineriaIlegal').DataTable({
        ajax: {
            "url": '/ComoperguardMineriaIlegal/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "mineriaIlegalId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "areaIntervenida" },
            { "data": "refMensajeNaval" },
            { "data": "horaIntervencion" },
            { "data": "diaIntervencion" },
            { "data": "descMes" },
            { "data": "anioIntervencion" },
            { "data": "latitudUbicacionNave" },
            { "data": "longitudUbicacionNave" },
            { "data": "descUnidadNaval" },
            { "data": "cascoUnidadNaval" },
            { "data": "descSectorExtraInstitucional" },
            { "data": "descTipoMaterialDestruido" },
            { "data": "cantidadPersonasDetenidas" },
            { "data": "observaciones" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.mineriaIlegalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.mineriaIlegalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Minería Ilegal',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Minería Ilegal',
                title: 'Comoperguard - Minería Ilegal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Minería Ilegal',
                title: 'Comoperguard - Minería Ilegal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Minería Ilegal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
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
    $.getJSON('/ComoperguardMineriaIlegal/Mostrar?Id=' + Id, [], function (MineriaIlegalDTO) {
        $('#txtCodigo').val(MineriaIlegalDTO.mineriaIlegalId);
        $('#cbJefaturaDistritoCapitaniae').val(MineriaIlegalDTO.JefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(MineriaIlegalDTO.CapitaniaId);
        $('#txtAreaIntervenidae').val(MineriaIlegalDTO.AreaIntervenida);
        $('#txtRefMensajeNavale').val(MineriaIlegalDTO.RefMensajeNaval);
        $('#txtHoraIntervencione').val(MineriaIlegalDTO.HoraIntervencion);
        $('#txtDiaIntervencione').val(MineriaIlegalDTO.DiaIntervencion);
        $('#cbMese').val(MineriaIlegalDTO.MesId);
        $('#txtAnioIntervencione').val(MineriaIlegalDTO.AnioIntervencion);
        $('#txtLatitudUbicacionNe').val(MineriaIlegalDTO.LatitudUbicacionNave);
        $('#txtLongitudUbicacionNe').val(MineriaIlegalDTO.LongitudUbicacionNave);
        $('#cbUnidadNavale').val(MineriaIlegalDTO.UnidadNavalId);
        $('#txtCascoUnidadNavale').val(MineriaIlegalDTO.CascoUnidadNaval);
        $('#cbSectorExtraInstitucionale').val(MineriaIlegalDTO.SectorExtraInstitucionalId);
        $('#cbTipoMaterialDestruidoe').val(MineriaIlegalDTO.TipoMaterialDestruidoId);
        $('#txtCantidadPersonasDetenidase').val(MineriaIlegalDTO.CantidadPersonasDetenidas);
        $('#txtObservacionese').val(MineriaIlegalDTO.Observaciones); 
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
                url: '/ComoperguardMineriaIlegal/Eliminar',
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
                    $('#tblComoperguardMineriaIlegal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardMineriaIlegal() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardMineriaIlegal/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var mes = Json["data3"];
        var unidadNaval = Json["data4"];
        var sectorExtraInstitucional = Json["data5"];
        var tipoMaterialDestruido = Json["data6"];

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

        $("select#cbMes").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
        });
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
        });

        $("select#cbUnidadNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbSectorExtraInstitucional").html("");
        $.each(sectorExtraInstitucional, function () {
            var RowContent = '<option value=' + this.sectorExtraInstitucionalId + '>' + this.descSectorExtraInstitucional + '</option>'
            $("select#cbSectorExtraInstitucionale").append(RowContent);
        });
        $("select#cbSectorExtraInstitucionale").html("");
        $.each(sectorExtraInstitucional, function () {
            var RowContent = '<option value=' + this.sectorExtraInstitucionalId + '>' + this.descSectorExtraInstitucional + '</option>'
            $("select#cbSectorExtraInstitucionale").append(RowContent);
        });

        $("select#cbTipoMaterialDestruido").html("");
        $.each(tipoMaterialDestruido, function () {
            var RowContent = '<option value=' + this.tipoMaterialDestruidoId + '>' + this.descTipoMaterialDestruido + '</option>'
            $("select#cbTipoMaterialDestruidoe").append(RowContent);
        });
        $("select#cbTipoMaterialDestruidoe").html("");
        $.each(tipoMaterialDestruido, function () {
            var RowContent = '<option value=' + this.tipoMaterialDestruidoId + '>' + this.descTipoMaterialDestruido + '</option>'
            $("select#cbTipoMaterialDestruidoe").append(RowContent);
        });
    });
}

