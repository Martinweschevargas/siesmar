var tblComoperguardActividadIlicita;

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
                                url: '/ComoperguardActividadIlicita/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'FechaIntervencion': $('#txtFechaIntervencion').val(),
                                    'ActividadIlicitaId': $('#cbActividadIlicita').val(),
                                    'TomaConocimientoId': $('#cbTomaConocimiento').val(),
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'CascoNave': $('#txtCascoNave').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacionN').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacionN').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNave').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeo').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeo').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeo').val(),
                                    'NombreNave': $('#txtNombreNave').val(),
                                    'MatriculaNave': $('#txtMatriculaNave').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'NumeroIntervenidos': $('#txtNumeroIntervenidos').val(),
                                    'MaterialIncautadoId': $('#cbMaterialIncautado').val(),
                                    'CantidadMaterialIncautado': $('#txtCantidadMaterialIncautado').val(),
                                    'UnidadMedidaId': $('#cbUnidadMedida').val(),
                                    'DocumentoInformacion': $('#txtDocumentoInformacion').val(),
                                    'FechaDocumento': $('#txtFechaDocumento').val(),
                                    'ObservacionIntervencion': $('#txtObservacionIntervencion').val(), 
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
                                    $('#tblComoperguardActividadIlicita').DataTable().ajax.reload();
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
                                url: '/ComoperguardActividadIlicita/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'FechaIntervencion': $('#txtFechaIntervencione').val(),
                                    'ActividadIlicitaId': $('#cbActividadIlicitae').val(),
                                    'TomaConocimientoId': $('#cbTomaConocimientoe').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'CascoNave': $('#txtCascoNavee').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacionNe').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacionNe').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNavee').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeoe').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeoe').val(),
                                    'NombreNave': $('#txtNombreNavee').val(),
                                    'MatriculaNave': $('#txtMatriculaNavee').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'NumeroIntervenidos': $('#txtNumeroIntervenidose').val(),
                                    'MaterialIncautadoId': $('#cbMaterialIncautadoe').val(),
                                    'CantidadMaterialIncautado': $('#txtCantidadMaterialIncautadoe').val(),
                                    'UnidadMedidaId': $('#cbUnidadMedidae').val(),
                                    'DocumentoInformacion': $('#txtDocumentoInformacione').val(),
                                    'FechaDocumento': $('#txtFechaDocumentoe').val(),
                                    'ObservacionIntervencion': $('#txtObservacionIntervencione').val(), 
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
                                    $('#tblComoperguardActividadIlicita').DataTable().ajax.reload();
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

    $('#tblComoperguardActividadIlicita').DataTable({
        ajax: {
            "url": '/ComoperguardActividadIlicita/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "factividadIlicitaId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "fechaIntervencion" },
            { "data": "descActividadIlicita" },
            { "data": "descTomaConocimiento" },
            { "data": "descUnidadNaval" },
            { "data": "cascoNave" },
            { "data": "latitudUbicacionNave" },
            { "data": "longitudUbicacionNave" },
            { "data": "descAmbitoNave" },
            { "data": "descDistrito" },
            { "data": "descProvincia" },
            { "data": "descDepartamento" },
            { "data": "nombreNave" },
            { "data": "matriculaNave" },
            { "data": "nombrePais" },
            { "data": "descTipoNave" },
            { "data": "numeroIntervenidos" },
            { "data": "descMaterialIncautado" },
            { "data": "cantidadMaterialIncautado" },
            { "data": "descUnidadMedida" },
            { "data": "documentoInformacion" },
            { "data": "fechaDocumento" },
            { "data": "observacionIntervencion" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.factividadIlicitaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.factividadIlicitaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Actividades Ilicitas',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Actividades Ilicitas',
                title: 'Comoperguard - Actividades Ilicitas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Actividades Ilicitas',
                title: 'Comoperguard - Actividades Ilicitas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Actividades Ilicitas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24]
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
    $.getJSON('/ComoperguardActividadIlicita/Mostrar?Id=' + Id, [], function (ActividadIlicitaDTO) {
        $('#txtCodigo').val(ActividadIlicitaDTO.factividadIlicitaId);
        $('#cbJefaturaDistritoCapitaniae').val(ActividadIlicitaDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(ActividadIlicitaDTO.capitaniaId);
        $('#txtFechaIntervencione').val(ActividadIlicitaDTO.fechaIntervencion);
        $('#cbActividadIlicitae').val(ActividadIlicitaDTO.actividadIlicitaId);
        $('#cbTomaConocimientoe').val(ActividadIlicitaDTO.tomaConocimientoId);
        $('#cbUnidadNavale').val(ActividadIlicitaDTO.unidadNavalId);
        $('#txtCascoNavee').val(ActividadIlicitaDTO.cascoNave);
        $('#txtLatitudUbicacionNe').val(ActividadIlicitaDTO.latitudUbicacionNave);
        $('#txtLongitudUbicacionNe').val(ActividadIlicitaDTO.longitudUbicacionNave);
        $('#cbAmbitoNavee').val(ActividadIlicitaDTO.ambitoNaveId);
        $('#cbDistritoUbigeoe').val(ActividadIlicitaDTO.distritoUbigeoId);
        $('#cbProvinciaUbigeoe').val(ActividadIlicitaDTO.provinciaUbigeoId);
        $('#cbDepartamentoUbigeoe').val(ActividadIlicitaDTO.departamentoUbigeoId);
        $('#txtNombreNavee').val(ActividadIlicitaDTO.nombreNave);
        $('#txtMatriculaNavee').val(ActividadIlicitaDTO.matriculaNave);
        $('#cbPaisUbigeoe').val(ActividadIlicitaDTO.paisUbigeoId);
        $('#cbTipoNavee').val(ActividadIlicitaDTO.tipoNaveId);
        $('#txtNumeroIntervenidose').val(ActividadIlicitaDTO.numeroIntervenidos);
        $('#cbMaterialIncautadoe').val(ActividadIlicitaDTO.materialIncautadoId);
        $('#txtCantidadMaterialIncautadoe').val(ActividadIlicitaDTO.cantidadMaterialIncautado);
        $('#cbUnidadMedidae').val(ActividadIlicitaDTO.unidadMedidaId);
        $('#txtDocumentoInformacione').val(ActividadIlicitaDTO.documentoInformacion);
        $('#txtFechaDocumentoe').val(ActividadIlicitaDTO.fechaDocumento);
        $('#txtObservacionIntervencione').val(ActividadIlicitaDTO.observacionIntervencion); 
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
                url: '/ComoperguardActividadIlicita/Eliminar',
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
                    $('#tblComoperguardActividadIlicita').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardActividadIlicita() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardActividadIlicita/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var actividadIlicita = Json["data3"];
        var tomaConocimiento = Json["data4"];
        var unidadNaval = Json["data5"];
        var ambitoNave = Json["data6"];
        var distritoUbigeo = Json["data7"];
        var provinciaUbigeo = Json["data8"];
        var departamentoUbigeo = Json["data9"];
        var paisUbigeo = Json["data10"];
        var tipoNave = Json["data11"];
        var materialIncautado = Json["data12"];
        var unidadMedida = Json["data13"];

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


        $("select#cbActividadIlicita").html("");
        $.each(actividadIlicita, function () {
            var RowContent = '<option value=' + this.actividadIlicitaId + '>' + this.descActividadIlicita + '</option>'
            $("select#cbActividadIlicitae").append(RowContent);
        });
        $("select#cbActividadIlicitae").html("");
        $.each(actividadIlicita, function () {
            var RowContent = '<option value=' + this.actividadIlicitaId + '>' + this.descActividadIlicita + '</option>'
            $("select#cbActividadIlicitae").append(RowContent);
        });


        $("select#cbTomaConocimiento").html("");
        $.each(tomaConocimiento, function () {
            var RowContent = '<option value=' + this.tomaConocimientoId + '>' + this.descTomaConocimiento + '</option>'
            $("select#cbTomaConocimientoe").append(RowContent);
        });
        $("select#cbTomaConocimientoe").html("");
        $.each(tomaConocimiento, function () {
            var RowContent = '<option value=' + this.tomaConocimientoId + '>' + this.descTomaConocimiento + '</option>'
            $("select#cbTomaConocimientoe").append(RowContent);
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


        $("select#cbDistritoUbigeo").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });
        $("select#cbDistritoUbigeoe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });


        $("select#cbProvinciaUbigeo").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUbigeoe").append(RowContent);
        });
        $("select#cbProvinciaUbigeoe").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUbigeoe").append(RowContent);
        });


        $("select#cbDepartamentoUbigeo").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeoe").append(RowContent);
        });
        $("select#cbDepartamentoUbigeoe").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeoe").append(RowContent);
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


        $("select#cbTipoNave").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbTipoNavee").append(RowContent);
        });
        $("select#cbTipoNavee").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbTipoNavee").append(RowContent);
        });


        $("select#cbMaterialIncautado").html("");
        $.each(materialIncautado, function () {
            var RowContent = '<option value=' + this.materialIncautadoId + '>' + this.descMaterialIncautado + '</option>'
            $("select#cbMaterialIncautadoe").append(RowContent);
        });
        $("select#cbMaterialIncautadoe").html("");
        $.each(materialIncautado, function () {
            var RowContent = '<option value=' + this.materialIncautadoId + '>' + this.descMaterialIncautado + '</option>'
            $("select#cbMaterialIncautadoe").append(RowContent);
        });


        $("select#cbUnidadMedida").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.unidadMedidaId + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedidae").append(RowContent);
        });
        $("select#cbUnidadMedidae").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.unidadMedidaId + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedidae").append(RowContent);
        }); 
    });
}

