var tblComoperguardOperacionesBusquedasSalvamento;

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
                                url: '/ComoperguardOperacionesBusquedasSalvamento/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'HoraSiniestro': $('#txtHoraSiniestro').val(),
                                    'FechaSiniestro': $('#txtFechaSiniestro').val(),
                                    'TipoSiniestroId': $('#cbTipoSiniestro').val(),
                                    'MensajeActivacionRSC': $('#txtMensajeActivacionRSC').val(),
                                    'MensajeDesactivacionRSC': $('#txtMensajeDesactivacionRSC').val(),
                                    'NombreNaveSiniestrada': $('#txtNombreNaveSiniestrada').val(),
                                    'MatriculaNaveSiniestrada': $('#txtMatriculaNaveSiniestrada').val(),
                                    'ABEdad': $('#txtABEdad').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'PersonasRescatadasVida': $('#txtPersonasRescatadasVida').val(),
                                    'PersonasFallecidas': $('#txtPersonasFallecidas').val(),
                                    'PersonasDesaparecidas': $('#txtPersonasDesaparecidas').val(),
                                    'PersonasEvacuadas': $('#txtPersonasEvacuadas').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacionNave').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacionNave').val(),
                                    'ZonaSiniestro': $('#txtZonaSiniestro').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeo').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeo').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeo').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNave').val(),
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'TipoVehiculoMovilId': $('#cbTipoVehiculoMovil').val(),
                                    'MarcaVehiculoId': $('#cbMarcaVehiculo').val(),
                                    'Millas': $('#txtMillas').val(),
                                    'Kilometro': $('#txtKilometro').val(),
                                    'Galones': $('#txtGalones').val(),
                                    'ResultadoTerminoOperaciones': $('#txtResultadoTerminoO').val(),
                                    'ObservacionesSiniestro': $('#txtObservacionesSiniestro').val(), 
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
                                    $('#tblComoperguardOperacionesBusquedasSalvamento').DataTable().ajax.reload();
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
                                url: '/ComoperguardOperacionesBusquedasSalvamento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'HoraSiniestro': $('#txtHoraSiniestroe').val(),
                                    'FechaSiniestro': $('#txtFechaSiniestroe').val(),
                                    'TipoSiniestroId': $('#cbTipoSiniestroe').val(),
                                    'MensajeActivacionRSC': $('#txtMensajeActivacionRSCe').val(),
                                    'MensajeDesactivacionRSC': $('#txtMensajeDesactivacionRSCe').val(),
                                    'NombreNaveSiniestrada': $('#txtNombreNaveSiniestradae').val(),
                                    'MatriculaNaveSiniestrada': $('#txtMatriculaNaveSiniestradae').val(),
                                    'ABEdad': $('#txtABEdade').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'PersonasRescatadasVida': $('#txtPersonasRescatadasVidae').val(),
                                    'PersonasFallecidas': $('#txtPersonasFallecidase').val(),
                                    'PersonasDesaparecidas': $('#txtPersonasDesaparecidase').val(),
                                    'PersonasEvacuadas': $('#txtPersonasEvacuadase').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacionNavee').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacionNavee').val(),
                                    'ZonaSiniestro': $('#txtZonaSiniestroe').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeoe').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeoe').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNavee').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'TipoVehiculoMovilId': $('#cbTipoVehiculoMovile').val(),
                                    'MarcaVehiculoId': $('#cbMarcaVehiculoe').val(),
                                    'Millas': $('#txtMillase').val(),
                                    'Kilometro': $('#txtKilometroe').val(),
                                    'Galones': $('#txtGalonese').val(),
                                    'ResultadoTerminoOperaciones': $('#txtResultadoTerminoOe').val(),
                                    'ObservacionesSiniestro': $('#txtObservacionesSiniestroe').val(), 
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
                                    $('#tblComoperguardOperacionesBusquedasSalvamento').DataTable().ajax.reload();
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

    $('#tblComoperguardOperacionesBusquedasSalvamento').DataTable({
        ajax: {
            "url": '/ComoperguardOperacionesBusquedasSalvamento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "operacionBusquedaSalvamentoId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "horaSiniestro" },
            { "data": "fechaSiniestro" },
            { "data": "descTipoSiniestro" },
            { "data": "mensajeActivacionRSC" },
            { "data": "mensajeDesactivacionRSC" },
            { "data": "nombreNaveSiniestrada" },
            { "data": "matriculaNaveSiniestrada" },
            { "data": "abedad" },
            { "data": "nombrePais" },
            { "data": "personasRescatadasVida" },
            { "data": "personasFallecidas" },
            { "data": "personasDesaparecidas" },
            { "data": "personasEvacuadas" },
            { "data": "latitudUbicacionNave" },
            { "data": "longitudUbicacionNave" },
            { "data": "zonaSiniestro" },
            { "data": "descDistrito" },
            { "data": "descProvincia" },
            { "data": "descDepartamento" },
            { "data": "descAmbitoNave" },
            { "data": "descUnidadNaval" },
            { "data": "descTipoVehiculoMovil" },
            { "data": "descMarcaVehiculo" },
            { "data": "millas" },
            { "data": "kilometro" },
            { "data": "galones" },
            { "data": "resultadoTerminoOperaciones" },
            { "data": "observacionesSiniestro" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.operacionBusquedaSalvamentoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.operacionBusquedaSalvamentoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Operaciones de Busqueda y Salvamento RSC',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Operaciones de Busqueda y Salvamento RSC',
                title: 'Comoperguard - Operaciones de Busqueda y Salvamento RSC',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Operaciones de Busqueda y Salvamento RSC',
                title: 'Comoperguard - Operaciones de Busqueda y Salvamento RSC',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Operaciones de Busqueda y Salvamento RSC',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30]
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
    $.getJSON('/ComoperguardOperacionesBusquedasSalvamento/Mostrar?Id=' + Id, [], function (OperacionesBusquedasSalvamentoDTO) {
        $('#txtCodigo').val(OperacionesBusquedasSalvamentoDTO.operacionBusquedaSalvamentoId);
        $('#cbJefaturaDistritoCapitaniae').val(OperacionesBusquedasSalvamentoDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(OperacionesBusquedasSalvamentoDTO.capitaniaId);
        $('#txtHoraSiniestroe').val(OperacionesBusquedasSalvamentoDTO.horaSiniestro);
        $('#txtFechaSiniestroe').val(OperacionesBusquedasSalvamentoDTO.fechaSiniestro);
        $('#cbTipoSiniestroe').val(OperacionesBusquedasSalvamentoDTO.tipoSiniestroId);
        $('#txtMensajeActivacionRSCe').val(OperacionesBusquedasSalvamentoDTO.mensajeActivacionRSC);
        $('#txtMensajeDesactivacionRSCe').val(OperacionesBusquedasSalvamentoDTO.mensajeDesactivacionRSC);
        $('#txtNombreNaveSiniestradae').val(OperacionesBusquedasSalvamentoDTO.nombreNaveSiniestrada);
        $('#txtMatriculaNaveSiniestradae').val(OperacionesBusquedasSalvamentoDTO.matriculaNaveSiniestrada);
        $('#txtABEdade').val(OperacionesBusquedasSalvamentoDTO.abedad);
        $('#cbPaisUbigeoe').val(OperacionesBusquedasSalvamentoDTO.paisUbigeoId);
        $('#txtPersonasRescatadasVidae').val(OperacionesBusquedasSalvamentoDTO.personasRescatadasVida);
        $('#txtPersonasFallecidase').val(OperacionesBusquedasSalvamentoDTO.personasFallecidas);
        $('#txtPersonasDesaparecidase').val(OperacionesBusquedasSalvamentoDTO.personasDesaparecidas);
        $('#txtPersonasEvacuadase').val(OperacionesBusquedasSalvamentoDTO.personasEvacuadas);
        $('#txtLatitudUbicacionNavee').val(OperacionesBusquedasSalvamentoDTO.latitudUbicacionNave);
        $('#txtLongitudUbicacionNavee').val(OperacionesBusquedasSalvamentoDTO.longitudUbicacionNave);
        $('#txtZonaSiniestroe').val(OperacionesBusquedasSalvamentoDTO.zonaSiniestro);
        $('#cbDistritoUbigeoe').val(OperacionesBusquedasSalvamentoDTO.distritoUbigeoId);
        $('#cbProvinciaUbigeoe').val(OperacionesBusquedasSalvamentoDTO.provinciaUbigeoId);
        $('#cbDepartamentoUbigeoe').val(OperacionesBusquedasSalvamentoDTO.departamentoUbigeoId);
        $('#cbAmbitoNavee').val(OperacionesBusquedasSalvamentoDTO.ambitoNaveId);
        $('#cbUnidadNavale').val(OperacionesBusquedasSalvamentoDTO.unidadNavalId);
        $('#cbTipoVehiculoMovile').val(OperacionesBusquedasSalvamentoDTO.tipoVehiculoMovilId);
        $('#cbMarcaVehiculoe').val(OperacionesBusquedasSalvamentoDTO.marcaVehiculoId);
        $('#txtMillase').val(OperacionesBusquedasSalvamentoDTO.millas);
        $('#txtKilometroe').val(OperacionesBusquedasSalvamentoDTO.kilometro);
        $('#txtGalonese').val(OperacionesBusquedasSalvamentoDTO.galones);
        $('#txtResultadoTerminoOe').val(OperacionesBusquedasSalvamentoDTO.resultadoTerminoOperaciones);
        $('#txtObservacionesSiniestroe').val(OperacionesBusquedasSalvamentoDTO.observacionesSiniestro); 
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
                url: '/ComoperguardOperacionesBusquedasSalvamento/Eliminar',
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
                    $('#tblComoperguardOperacionesBusquedasSalvamento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardOperacionesBusquedasSalvamento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardOperacionesBusquedasSalvamento/cargaCombs', [], function (Json) {
        var JefaturaDistritoCapitania = Json["data1"];
        var Capitania = Json["data2"];
        var TipoSiniestro = Json["data3"];
        var PaisUbigeo = Json["data4"];
        var DistritoUbigeo = Json["data5"];
        var ProvinciaUbigeo = Json["data6"];
        var DepartamentoUbigeo = Json["data7"];
        var AmbitoNave = Json["data8"];
        var UnidadNaval = Json["data9"];
        var TipoVehiculoMovil = Json["data10"];
        var MarcaVehiculo = Json["data11"];

        $("select#cbJefaturaDistritoCapitania").html("");
        $.each(JefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });
        $("select#cbJefaturaDistritoCapitaniae").html("");
        $.each(JefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });

        $("select#cbCapitania").html("");
        $.each(Capitania, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbCapitaniae").append(RowContent);
        });
        $("select#cbCapitaniae").html("");
        $.each(Capitania, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbCapitaniae").append(RowContent);
        });

        $("select#cbTipoSiniestro").html("");
        $.each(TipoSiniestro, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbTipoSiniestroe").append(RowContent);
        });
        $("select#cbTipoSiniestroe").html("");
        $.each(TipoSiniestro, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbTipoSiniestroe").append(RowContent);
        });

        $("select#cbPaisUbigeo").html("");
        $.each(PaisUbigeo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbPaisUbigeoe").append(RowContent);
        });
        $("select#cbPaisUbigeoe").html("");
        $.each(PaisUbigeo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbPaisUbigeoe").append(RowContent);
        });

        $("select#cbDistritoUbigeo").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });
        $("select#cbDistritoUbigeoe").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });

        $("select#cbProvinciaUbigeo").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbProvinciaUbigeoe").append(RowContent);
        });
        $("select#cbProvinciaUbigeoe").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbProvinciaUbigeoe").append(RowContent);
        });

        $("select#cbDepartamentoUbigeo").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbDepartamentoUbigeoe").append(RowContent);
        });
        $("select#cbDepartamentoUbigeoe").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbDepartamentoUbigeoe").append(RowContent);
        });

        $("select#cbAmbitoNave").html("");
        $.each(AmbitoNave, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbAmbitoNavee").append(RowContent);
        });
        $("select#cbAmbitoNavee").html("");
        $.each(AmbitoNave, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbAmbitoNavee").append(RowContent);
        });

        $("select#cbUnidadNaval").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbTipoVehiculoMovil").html("");
        $.each(TipoVehiculoMovil, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbTipoVehiculoMovile").append(RowContent);
        });
        $("select#cbTipoVehiculoMovile").html("");
        $.each(TipoVehiculoMovil, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbTipoVehiculoMovile").append(RowContent);
        });

        $("select#cbMarcaVehiculo").html("");
        $.each(MarcaVehiculo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbMarcaVehiculoe").append(RowContent);
        });
        $("select#cbMarcaVehiculoe").html("");
        $.each(MarcaVehiculo, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbMarcaVehiculoe").append(RowContent);
        });

    });
}

