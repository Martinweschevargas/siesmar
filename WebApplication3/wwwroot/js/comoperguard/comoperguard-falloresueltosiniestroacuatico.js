var tblComoperguardFalloResueltoSiniestroAcuatico;

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
                                url: '/ComoperguardFalloResueltoSiniestroAcuatico/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'HoraCaptura': $('#txtHoraCaptura').val(),
                                    'DiaCaptura': $('#txtDiaCaptura').val(),
                                    'MesId': $('#cbMes').val(),
                                    'AnioSiniestro': $('#txtAnioCaptura').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'NombreNaveSiniestro': $('#txtNombre').val(),
                                    'MatriculaNaveSiniestro': $('#txtMatriculaNave').val(),
                                    'ABEdad': $('#txtABEdad').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'TipoSiniestroId': $('#cbTipoSiniestro').val(),
                                    'PersonasRescatadasVida': $('#txtPersonasRescatada').val(),
                                    'PersonasFallecidas': $('#txtPersonasFallecidas').val(),
                                    'PersonasDesaparecida': $('#txtPersonasDesaparecida').val(),
                                    'PersonasEvacuadas': $('#txtPersonasEvacuadas').val(),
                                    'TotalPersonas': $('#txtTotalPersonas').val(),
                                    'ReferenciaDocumento': $('#txtReferenciaDocumento').val(),
                                    'FechaDocumento': $('#txtFechaDocumento').val(),
                                    'ResumenFallo': $('#txtResumenFallo').val(), 
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
                                    $('#tblComoperguardFalloResueltoSiniestroAcuatico').DataTable().ajax.reload();
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
                                url: '/ComoperguardFalloResueltoSiniestroAcuatico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'HoraCaptura': $('#txtHoraCapturae').val(),
                                    'DiaCaptura': $('#txtDiaCapturae').val(),
                                    'MesId': $('#cbMese').val(),
                                    'AnioSiniestro': $('#txtAnioCapturae').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'NombreNaveSiniestro': $('#txtNombree').val(),
                                    'MatriculaNaveSiniestro': $('#txtMatriculaNavee').val(),
                                    'ABEdad': $('#txtABEdade').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'TipoSiniestroId': $('#cbTipoSiniestroe').val(),
                                    'PersonasRescatadasVida': $('#txtPersonasRescatadae').val(),
                                    'PersonasFallecidas': $('#txtPersonasFallecidase').val(),
                                    'PersonasDesaparecida': $('#txtPersonasDesaparecidae').val(),
                                    'PersonasEvacuadas': $('#txtPersonasEvacuadase').val(),
                                    'TotalPersonas': $('#txtTotalPersonase').val(),
                                    'ReferenciaDocumento': $('#txtReferenciaDocumentoe').val(),
                                    'FechaDocumento': $('#txtFechaDocumentoe').val(),
                                    'ResumenFallo': $('#txtResumenFalloe').val(), 
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
                                    $('#tblComoperguardFalloResueltoSiniestroAcuatico').DataTable().ajax.reload();
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

    $('#tblComoperguardFalloResueltoSiniestroAcuatico').DataTable({
        ajax: {
            "url": '/ComoperguardFalloResueltoSiniestroAcuatico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "falloResueltoSiniestroAcuaticoId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "horaCaptura" },
            { "data": "diaCaptura" },
            { "data": "descMes" },
            { "data": "anioSiniestro" },
            { "data": "descTipoNave" },
            { "data": "nombreNaveSiniestro" },
            { "data": "matriculaNaveSiniestro" },
            { "data": "abedad" },
            { "data": "nombrePaisUbigeo" },
            { "data": "descTipoSiniestro" },
            { "data": "personasRescatadasVida" },
            { "data": "personasFallecidas" },
            { "data": "personasDesaparecida" },
            { "data": "personasEvacuadas" },
            { "data": "totalPersonas" },
            { "data": "referenciaDocumento" },
            { "data": "fechaDocumento" },
            { "data": "resumenFallo" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.falloResueltoSiniestroAcuaticoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.falloResueltoSiniestroAcuaticoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Fallos Resueltos por Siniestros Acuáticos',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Fallos Resueltos por Siniestros Acuáticos',
                title: 'Comoperguard - Fallos Resueltos por Siniestros Acuáticos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Fallos Resueltos por Siniestros Acuáticos',
                title: 'Comoperguard - Fallos Resueltos por Siniestros Acuáticos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Fallos Resueltos por Siniestros Acuáticos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20]
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
    $.getJSON('/ComoperguardFalloResueltoSiniestroAcuatico/Mostrar?Id=' + Id, [], function (FalloResueltoSiniestroAcuaticoDTO) {
        $('#txtCodigo').val(FalloResueltoSiniestroAcuaticoDTO.falloResueltoSiniestroAcuaticoId);
        $('#cbJefaturaDistritoCapitaniae').val(FalloResueltoSiniestroAcuaticoDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(FalloResueltoSiniestroAcuaticoDTO.capitaniaId);
        $('#txtHoraCapturae').val(FalloResueltoSiniestroAcuaticoDTO.horaCaptura);
        $('#txtDiaCapturae').val(FalloResueltoSiniestroAcuaticoDTO.diaCaptura);
        $('#cbMese').val(FalloResueltoSiniestroAcuaticoDTO.mesId);
        $('#txtAnioCapturae').val(FalloResueltoSiniestroAcuaticoDTO.anioSiniestro);
        $('#cbTipoNavee').val(FalloResueltoSiniestroAcuaticoDTO.tipoNaveId);
        $('#txtNombree').val(FalloResueltoSiniestroAcuaticoDTO.nombreNaveSiniestro);
        $('#txtMatriculaNavee').val(FalloResueltoSiniestroAcuaticoDTO.matriculaNaveSiniestro);
        $('#txtABEdade').val(FalloResueltoSiniestroAcuaticoDTO.abedad);
        $('#cbPaisUbigeoe').val(FalloResueltoSiniestroAcuaticoDTO.paisUbigeoId);
        $('#cbTipoSiniestroe').val(FalloResueltoSiniestroAcuaticoDTO.tipoSiniestroId);
        $('#txtPersonasRescatadae').val(FalloResueltoSiniestroAcuaticoDTO.personasRescatadasVida);
        $('#txtPersonasFallecidase').val(FalloResueltoSiniestroAcuaticoDTO.personasFallecidas);
        $('#txtPersonasDesaparecidae').val(FalloResueltoSiniestroAcuaticoDTO.personasDesaparecida);
        $('#txtPersonasEvacuadase').val(FalloResueltoSiniestroAcuaticoDTO.personasEvacuadas);
        $('#txtTotalPersonase').val(FalloResueltoSiniestroAcuaticoDTO.totalPersonas);
        $('#txtReferenciaDocumentoe').val(FalloResueltoSiniestroAcuaticoDTO.referenciaDocumento);
        $('#txtFechaDocumentoe').val(FalloResueltoSiniestroAcuaticoDTO.fechaDocumento);
        $('#txtResumenFalloe').val(FalloResueltoSiniestroAcuaticoDTO.resumenFallo); 
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
                url: '/ComoperguardFalloResueltoSiniestroAcuatico/Eliminar',
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
                    $('#tblComoperguardFalloResueltoSiniestroAcuatico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardFalloResueltoSiniestroAcuatico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardFalloResueltoSiniestroAcuatico/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var mes = Json["data3"];
        var tipoNave = Json["data4"];
        var paisUbigeo = Json["data5"];
        var tipoSiniestro = Json["data6"];

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

    });
}

