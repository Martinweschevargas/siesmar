var tblComoperguardSiniestroAcuaticoActivRadiobaliza;

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
                                url: '/ComoperguardSiniestroAcuaticoActivRadiobaliza/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'HoraSiniestro': $('#txtHoraSiniestro').val(),
                                    'FechaSiniestro': $('#txtFechaSiniestro').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'NombreNaveSiniestro': $('#txtNombre').val(),
                                    'MatriculaNaveSiniestro': $('#txtMatriculaNave').val(),
                                    'ABEdad': $('#txtABEdad').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'TipoSiniestroId': $('#cbTipoSiniestro').val(),
                                    'CuentaRadiobaliza': $('#txtCuentaRadiobaliza').val(),
                                    'ActivoRadiobaliza': $('#txtActivoRadiobaliza').val(),
                                    'TipoActivacionRadiobaliza': $('#txtTipoActivacionRadiobaliza').val(),
                                    'TipoRadiobalizaId': $('#cbTipoRadiobaliza').val(),
                                    'CodigoHexadecimal': $('#txtCodigoHexadecimal').val(),
                                    'ActivoPlanBusqueda': $('#txtActivoPlanBusqueda').val(),
                                    'MNReferenciaActivacion': $('#txtMNReferenciaActivacion').val(),
                                    'MNReferenciaDesactiva': $('#txtMNReferenciaDesactiva').val(),
                                    'TiempoDuracionHoras': $('#txtTiempoDuracionHoras').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacionNave').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacionNave').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNave').val(),
                                    'PersonasRescatadasVida': $('#txtPersonasRescatadasVida').val(),
                                    'PersonasFallecidas': $('#txtPersonasFallecidas').val(),
                                    'PersonasDesaparecida': $('#txtPersonasDesaparecida').val(),
                                    'TotalPersonas': $('#txtTotalPersonas').val(),
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'UnidadesParticulares': $('#txtUnidadesParticulares').val(),
                                    'ResumenCaso': $('#txtResumenCaso').val(), 
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
                                    $('#tblComoperguardSiniestroAcuaticoActivRadiobaliza').DataTable().ajax.reload();
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
                                url: '/ComoperguardSiniestroAcuaticoActivRadiobaliza/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'HoraSiniestro': $('#txtHoraSiniestroe').val(),
                                    'FechaSiniestro': $('#txtFechaSiniestroe').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'NombreNaveSiniestro': $('#txtNombree').val(),
                                    'MatriculaNaveSiniestro': $('#txtMatriculaNavee').val(),
                                    'ABEdad': $('#txtABEdade').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'TipoSiniestroId': $('#cbTipoSiniestroe').val(),
                                    'CuentaRadiobaliza': $('#txtCuentaRadiobalizae').val(),
                                    'ActivoRadiobaliza': $('#txtActivoRadiobalizae').val(),
                                    'TipoActivacionRadiobaliza': $('#txtTipoActivacionRadiobalizae').val(),
                                    'TipoRadiobalizaId': $('#cbTipoRadiobalizae').val(),
                                    'CodigoHexadecimal': $('#txtCodigoHexadecimale').val(),
                                    'ActivoPlanBusqueda': $('#txtActivoPlanBusquedae').val(),
                                    'MNReferenciaActivacion': $('#txtMNReferenciaActivacione').val(),
                                    'MNReferenciaDesactiva': $('#txtMNReferenciaDesactivae').val(),
                                    'TiempoDuracionHoras': $('#txtTiempoDuracionHorase').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacionNavee').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacionNavee').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNavee').val(),
                                    'PersonasRescatadasVida': $('#txtPersonasRescatadasVidae').val(),
                                    'PersonasFallecidas': $('#txtPersonasFallecidase').val(),
                                    'PersonasDesaparecida': $('#txtPersonasDesaparecidae').val(),
                                    'TotalPersonas': $('#txtTotalPersonase').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'UnidadesParticulares': $('#txtUnidadesParticularese').val(),
                                    'ResumenCaso': $('#txtResumenCasoe').val(), 
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
                                    $('#tblComoperguardSiniestroAcuaticoActivRadiobaliza').DataTable().ajax.reload();
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

    $('#tblComoperguardSiniestroAcuaticoActivRadiobaliza').DataTable({
        ajax: {
            "url": '/ComoperguardSiniestroAcuaticoActivRadiobaliza/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "siniestroAcuaticoActivacionRadiobalizaId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "horaSiniestro" },
            { "data": "fechaSiniestro" },
            { "data": "descTipoNave" },
            { "data": "nombreNaveSiniestro" },
            { "data": "matriculaNaveSiniestro" },
            { "data": "abedad" },
            { "data": "nombrePais" },
            { "data": "descTipoSiniestro" },
            { "data": "cuentaRadiobaliza" },
            { "data": "activoRadiobaliza" },
            { "data": "tipoActivacionRadiobaliza" },
            { "data": "descTipoRadiobaliza" },
            { "data": "codigoHexadecimal" },
            { "data": "activoPlanBusqueda" },
            { "data": "mnreferenciaActivacion" },
            { "data": "mnreferenciaDesactiva" },
            { "data": "tiempoDuracionHoras" },
            { "data": "latitudUbicacionNave" },
            { "data": "longitudUbicacionNave" },
            { "data": "descAmbitoNave" },
            { "data": "personasRescatadasVida" },
            { "data": "personasFallecidas" },
            { "data": "personasDesaparecida" },
            { "data": "totalPersonas" },
            { "data": "descUnidadNaval" },
            { "data": "unidadesParticulares" },
            { "data": "resumenCaso" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.siniestroAcuaticoActivacionRadiobalizaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.siniestroAcuaticoActivacionRadiobalizaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Siniestros Acuáticos y Activaciones de Radiobalizas',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Siniestros Acuáticos y Activaciones de Radiobalizas',
                title: 'Comoperguard - Siniestros Acuáticos y Activaciones de Radiobalizas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Siniestros Acuáticos y Activaciones de Radiobalizas',
                title: 'Comoperguard - Siniestros Acuáticos y Activaciones de Radiobalizas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Siniestros Acuáticos y Activaciones de Radiobalizas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29]
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
    $.getJSON('/ComoperguardSiniestroAcuaticoActivRadiobaliza/Mostrar?Id=' + Id, [], function (SiniestroAcuaticoActivacionRadiobalizaDTO) {
        $('#txtCodigo').val(SiniestroAcuaticoActivacionRadiobalizaDTO.siniestroAcuaticoActivacionRadiobalizaId);
        $('#cbJefaturaDistritoCapitaniae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.capitaniaId);
        $('#txtHoraSiniestroe').val(SiniestroAcuaticoActivacionRadiobalizaDTO.horaSiniestro);
        $('#txtFechaSiniestroe').val(SiniestroAcuaticoActivacionRadiobalizaDTO.fechaSiniestro);
        $('#cbTipoNavee').val(SiniestroAcuaticoActivacionRadiobalizaDTO.tipoNaveId);
        $('#txtNombree').val(SiniestroAcuaticoActivacionRadiobalizaDTO.nombreNaveSiniestro);
        $('#txtMatriculaNavee').val(SiniestroAcuaticoActivacionRadiobalizaDTO.matriculaNaveSiniestro);
        $('#txtABEdade').val(SiniestroAcuaticoActivacionRadiobalizaDTO.abedad);
        $('#cbPaisUbigeoe').val(SiniestroAcuaticoActivacionRadiobalizaDTO.paisUbigeoId);
        $('#cbTipoSiniestroe').val(SiniestroAcuaticoActivacionRadiobalizaDTO.tipoSiniestroId);
        $('#txtCuentaRadiobalizae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.cuentaRadiobaliza);
        $('#txtActivoRadiobalizae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.activoRadiobaliza);
        $('#txtTipoActivacionRadiobalizae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.tipoActivacionRadiobaliza);
        $('#cbTipoRadiobalizae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.tipoRadiobalizaId);
        $('#txtCodigoHexadecimale').val(SiniestroAcuaticoActivacionRadiobalizaDTO.codigoHexadecimal);
        $('#txtActivoPlanBusquedae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.activoPlanBusqueda);
        $('#txtMNReferenciaActivacione').val(SiniestroAcuaticoActivacionRadiobalizaDTO.mnreferenciaActivacion);
        $('#txtMNReferenciaDesactivae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.mnreferenciaDesactiva);
        $('#txtTiempoDuracionHorase').val(SiniestroAcuaticoActivacionRadiobalizaDTO.tiempoDuracionHoras);
        $('#txtLatitudUbicacionNavee').val(SiniestroAcuaticoActivacionRadiobalizaDTO.latitudUbicacionNave);
        $('#txtLongitudUbicacionNavee').val(SiniestroAcuaticoActivacionRadiobalizaDTO.longitudUbicacionNave);
        $('#cbAmbitoNavee').val(SiniestroAcuaticoActivacionRadiobalizaDTO.ambitoNaveId);
        $('#txtPersonasRescatadasVidae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.personasRescatadasVida);
        $('#txtPersonasFallecidase').val(SiniestroAcuaticoActivacionRadiobalizaDTO.personasFallecidas);
        $('#txtPersonasDesaparecidae').val(SiniestroAcuaticoActivacionRadiobalizaDTO.personasDesaparecida);
        $('#txtTotalPersonase').val(SiniestroAcuaticoActivacionRadiobalizaDTO.totalPersonas);
        $('#cbUnidadNavale').val(SiniestroAcuaticoActivacionRadiobalizaDTO.unidadNavalId);
        $('#txtUnidadesParticularese').val(SiniestroAcuaticoActivacionRadiobalizaDTO.unidadesParticulares);
        $('#txtResumenCasoe').val(SiniestroAcuaticoActivacionRadiobalizaDTO.resumenCaso); 
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
                url: '/ComoperguardSiniestroAcuaticoActivRadiobaliza/Eliminar',
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
                    $('#tblComoperguardSiniestroAcuaticoActivRadiobaliza').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardSiniestroAcuaticoActivRadiobaliza() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardSiniestroAcuaticoActivRadiobaliza/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var TipoNave = Json["data3"];
        var paisUbigeo = Json["data4"];
        var tipoSiniestro = Json["data5"];
        var tipoRadiobaliza = Json["data6"];
        var ambitoNave = Json["data7"];
        var unidadNaval = Json["data8"];

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


        $("select#cbTipoNave").html("");
        $.each(TipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbTipoNavee").append(RowContent);
        });
        $("select#cbTipoNavee").html("");
        $.each(TipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbTipoNavee").append(RowContent);
        });


        $("select#cbPaisUbigeo").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeoe").append(RowContent);
        });
        $("select#cbPaisUbigeoe").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeoe").append(RowContent);
        });


        $("select#cbTipoSiniestro").html("");
        $.each(tipoSiniestro, function () {
            var RowContent = '<option value=' + this.tipoSiniestroId + '>' + this.descTipoSiniestro + '</option>'
            $("select#cbTipoSiniestroe").append(RowContent);
        });
        $("select#cbTipoSiniestroe").html("");
        $.each(tipoSiniestro, function () {
            var RowContent = '<option value=' + this.tipoSiniestroId + '>' + this.descTipoSiniestro + '</option>'
            $("select#cbTipoSiniestroe").append(RowContent);
        });


        $("select#cbTipoRadiobaliza").html("");
        $.each(tipoRadiobaliza, function () {
            var RowContent = '<option value=' + this.tipoRadiobalizaId + '>' + this.descTipoRadiobaliza + '</option>'
            $("select#cbTipoRadiobalizae").append(RowContent);
        });
        $("select#cbTipoRadiobalizae").html("");
        $.each(tipoRadiobaliza, function () {
            var RowContent = '<option value=' + this.tipoRadiobalizaId + '>' + this.descTipoRadiobaliza + '</option>'
            $("select#cbTipoRadiobalizae").append(RowContent);
        });


        $("select#cbAmbitoNave").html("");
        $.each(ambitoNave, function () {
            var RowContent = '<option value=' + this.ambitoNaveId + '>' + this.descAmbitoNave + '</option>'
            $("select#cbAmbitoNavee").append(RowContent);
        });
        $("select#cbAmbitoNavee").html("");
        $.each(ambitoNave, function () {
            var RowContent = '<option value=' + this.ambitoNaveId + '>' + this.descAmbitoNave + '</option>'
            $("select#cbAmbitoNavee").append(RowContent);
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


    });
}

