var tblComoperguardNaveExtranjeraCapturada;

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
                                url: '/ComoperguardNaveExtranjeraCapturada/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'HoraCaptura': $('#txtHoraCaptura').val(),
                                    'DiaCaptura': $('#txtDiaCaptura').val(),
                                    'MesId': $('#cbMesId').val(),
                                    'AnioCaptura': $('#txtAnioCaptura').val(),
                                    'NombreNaveExtranjera': $('#txtNombreNaveExtranjera').val(),
                                    'MatriculaNaveExtranjera': $('#txtMatriculaNaveExtranjera').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNave').val(),
                                    'TenorInfracciones': $('#txtTenorInfracciones').val(),
                                    'ArticuloInfraccion': $('#txtArticuloInfraccion').val(),
                                    'ProcesoAdministrativo': $('#txtProcesoAdministrativo').val(),
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
                                    $('#tblComoperguardNaveExtranjeraCapturada').DataTable().ajax.reload();
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
                                url: '/ComoperguardNaveExtranjeraCapturada/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'HoraCaptura': $('#txtHoraCapturae').val(),
                                    'DiaCaptura': $('#txtDiaCapturae').val(),
                                    'MesId': $('#cbMesIde').val(),
                                    'AnioCaptura': $('#txtAnioCapturae').val(),
                                    'NombreNaveExtranjera': $('#txtNombreNaveExtranjerae').val(),
                                    'MatriculaNaveExtranjera': $('#txtMatriculaNaveExtranjerae').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNavee').val(),
                                    'TenorInfracciones': $('#txtTenorInfraccionese').val(),
                                    'ArticuloInfraccion': $('#txtArticuloInfraccione').val(),
                                    'ProcesoAdministrativo': $('#txtProcesoAdministrativoe').val(),
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
                                    $('#tblComoperguardNaveExtranjeraCapturada').DataTable().ajax.reload();
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

    $('#tblComoperguardNaveExtranjeraCapturada').DataTable({
        ajax: {
            "url": '/ComoperguardNaveExtranjeraCapturada/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "navesExtranjerasCapturadasId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "horaCaptura" },
            { "data": "diaCaptura" },
            { "data": "descMes" },
            { "data": "anioCaptura" },
            { "data": "nombreNaveExtranjera" },
            { "data": "matriculaNaveExtranjera" },
            { "data": "nombrePais" },
            { "data": "descTipoNave" },
            { "data": "descUnidadNaval" },
            { "data": "descAmbitoNave" },
            { "data": "tenorInfracciones" },
            { "data": "articuloInfraccion" },
            { "data": "procesoAdministrativo" },
            { "data": "observaciones" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.navesExtranjerasCapturadasId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.navesExtranjerasCapturadasId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Naves Extranjeras Capturadas en Ámbito Marítimo, FluviaL, Lacustre',
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
                filename: 'Comoperguard - Naves Extranjeras Capturadas en Ámbito Marítimo, FluviaL, Lacustre',
                title: 'Comoperguard - Naves Extranjeras Capturadas en Ámbito Marítimo, FluviaL, Lacustre',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Naves Extranjeras Capturadas en Ámbito Marítimo, FluviaL, Lacustre',
                title: 'Comoperguard - Naves Extranjeras Capturadas en Ámbito Marítimo, FluviaL, Lacustre',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Naves Extranjeras Capturadas en Ámbito Marítimo, FluviaL, Lacustre',
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
    $.getJSON('/ComoperguardNaveExtranjeraCapturada/Mostrar?Id=' + Id, [], function (NaveExtranjeraCapturadaDTO) {
        $('#txtCodigo').val(NaveExtranjeraCapturadaDTO.navesExtranjerasCapturadasId);
        $('#cbJefaturaDistritoCapitaniae').val(NaveExtranjeraCapturadaDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(NaveExtranjeraCapturadaDTO.capitaniaId);
        $('#txtHoraCapturae').val(NaveExtranjeraCapturadaDTO.horaCaptura);
        $('#txtDiaCapturae').val(NaveExtranjeraCapturadaDTO.diaCaptura);
        $('#cbMesIde').val(NaveExtranjeraCapturadaDTO.mesId);
        $('#txtAnioCapturae').val(NaveExtranjeraCapturadaDTO.anioCaptura);
        $('#txtNombreNaveExtranjerae').val(NaveExtranjeraCapturadaDTO.nombreNaveExtranjera);
        $('#txtMatriculaNaveExtranjerae').val(NaveExtranjeraCapturadaDTO.matriculaNaveExtranjera);
        $('#cbPaisUbigeoe').val(NaveExtranjeraCapturadaDTO.paisUbigeoId);
        $('#cbTipoNavee').val(NaveExtranjeraCapturadaDTO.tipoNaveId);
        $('#cbUnidadNavale').val(NaveExtranjeraCapturadaDTO.unidadNavalId);
        $('#cbAmbitoNavee').val(NaveExtranjeraCapturadaDTO.ambitoNaveId);
        $('#txtTenorInfraccionese').val(NaveExtranjeraCapturadaDTO.tenorInfracciones);
        $('#txtArticuloInfraccione').val(NaveExtranjeraCapturadaDTO.articuloInfraccion);
        $('#txtProcesoAdministrativoe').val(NaveExtranjeraCapturadaDTO.procesoAdministrativo);
        $('#txtObservacionese').val(NaveExtranjeraCapturadaDTO.observaciones); 
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
                url: '/ComoperguardNaveExtranjeraCapturada/Eliminar',
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
                    $('#tblComoperguardNaveExtranjeraCapturada').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardNaveExtranjeraCapturada() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardNaveExtranjeraCapturada/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var mes = Json["data3"];
        var paisUbigeo = Json["data4"];
        var tipoNave = Json["data5"];
        var unidadNaval = Json["data6"];
        var ambitoNave = Json["data7"];

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


        $("select#cbMesId").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMesIde").append(RowContent);
        });
        $("select#cbMesIde").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMesIde").append(RowContent);
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
    });
}

