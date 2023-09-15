var tblComoperguardArriboNave;

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
                                url: '/ComoperguardArriboNave/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'HoraArribo': $('#txtHoraArribo').val(),
                                    'DiaArribo': $('#txtDiaArribo').val(),
                                    'MesId': $('#cbMes').val(),
                                    'AnioArribo': $('#txtAnioArribo').val(),
                                    'PuertoPeruId': $('#cbPuertoPeru').val(),
                                    'IndicativoNave': $('#txtIndicativoNave').val(),
                                    'NombreNave': $('#txtNombreNave').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'NumeroOMI': $('#txtNumeroOMI').val(),
                                    'AB': $('#txtAB').val(),
                                    'AgenciaMaritima': $('#txtAgenciaMaritima').val(),
                                    'PaisProcedencia': $('#cbPaisProcedencia').val(),
                                    'PuertoProcedencia': $('#txtPuertoProcedencia').val(),
                                    'TripulantesChilenos': $('#txtTripulantesChilenos').val(),
                                    'TripulantesEcuatorianos': $('#txtTripulantesEcuatorianos').val(),
                                    'TripulantesTotal': $('#txtTripulantesTotal').val(),
                                    'PasajerosChilenos': $('#txtPasajerosChilenos').val(),
                                    'PasajerosEcuatorianos': $('#txtPasajerosEcuatorianos').val(),
                                    'PasajerosTotal': $('#txtPasajerosTotal').val(),
                                    'CantidadCargaDesembarcada': $('#txtCantidadCargaDesembarcada').val(),
                                    'UnidadMedidaId': $('#cbUnidadMedida').val(),
                                    'TipoCargaId': $('#cbTipoCarga').val(),
                                    'CantidadCargaPeligrosa': $('#txtCantidadCargaPeligrosa').val(),
                                    'UnidadMedidaPeligrosa': $('#cbUnidadMedidaPeligrosa').val(),
                                    'TipoCargaPeligrosa': $('#txtTipoCargaPeligrosa').val(),
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
                                    $('#tblComoperguardArriboNave').DataTable().ajax.reload();
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
                                url: '/ComoperguardArriboNave/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'HoraArribo': $('#txtHoraArriboe').val(),
                                    'DiaArribo': $('#txtDiaArriboe').val(),
                                    'MesId': $('#cbMese').val(),
                                    'AnioArribo': $('#txtAnioArriboe').val(),
                                    'PuertoPeruId': $('#cbPuertoPerue').val(),
                                    'IndicativoNave': $('#txtIndicativoNavee').val(),
                                    'NombreNave': $('#txtNombreNavee').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'NumeroOMI': $('#txtNumeroOMIe').val(),
                                    'AB': $('#txtABe').val(),
                                    'AgenciaMaritima': $('#txtAgenciaMaritimae').val(),
                                    'PaisProcedencia': $('#cbPaisProcedenciae').val(),
                                    'PuertoProcedencia': $('#txtPuertoProcedenciae').val(),
                                    'TripulantesChilenos': $('#txtTripulantesChilenose').val(),
                                    'TripulantesEcuatorianos': $('#txtTripulantesEcuatorianose').val(),
                                    'TripulantesTotal': $('#txtTripulantesTotale').val(),
                                    'PasajerosChilenos': $('#txtPasajerosChilenose').val(),
                                    'PasajerosEcuatorianos': $('#txtPasajerosEcuatorianose').val(),
                                    'PasajerosTotal': $('#txtPasajerosTotale').val(),
                                    'CantidadCargaDesembarcada': $('#txtCantidadCargaDesembarcadae').val(),
                                    'UnidadMedidaId': $('#cbUnidadMedidae').val(),
                                    'TipoCargaId': $('#cbTipoCargae').val(),
                                    'CantidadCargaPeligrosa': $('#txtCantidadCargaPeligrosae').val(),
                                    'UnidadMedidaPeligrosa': $('#cbUnidadMedidaPeligrosae').val(),
                                    'TipoCargaPeligrosa': $('#txtTipoCargaPeligrosae').val(),
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
                                    $('#tblComoperguardArriboNave').DataTable().ajax.reload();
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

    $('#tblComoperguardArriboNave').DataTable({
        ajax: {
            "url": '/ComoperguardArriboNave/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "arriboNaveId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "horaArribo" },
            { "data": "diaArribo" },
            { "data": "descMes" },
            { "data": "anioArribo" },
            { "data": "descPuertoPeru" },
            { "data": "indicativoNave" },
            { "data": "nombreNave" },
            { "data": "nombrePais" },
            { "data": "descTipoNave" },
            { "data": "numeroOMI" },
            { "data": "ab" },
            { "data": "agenciaMaritima" },
            { "data": "paisProcedencia" },
            { "data": "puertoProcedencia" },
            { "data": "tripulantesChilenos" },
            { "data": "tripulantesEcuatorianos" },
            { "data": "tripulantesTotal" },
            { "data": "pasajerosChilenos" },
            { "data": "pasajerosEcuatorianos" },
            { "data": "pasajerosTotal" },
            { "data": "cantidadCargaDesembarcada" },
            { "data": "descUnidadMedida" },
            { "data": "descTipoCarga" },
            { "data": "cantidadCargaPeligrosa" },
            { "data": "unidadMedidaPeligrosa" },
            { "data": "tipoCargaPeligrosa" },
            { "data": "observaciones" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.arriboNaveId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.arriboNaveId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Arribo de Naves',
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
                filename: 'Comoperguard - Arribo de Naves',
                title: 'Comoperguard - Arribo de Naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Arribo de Naves',
                title: 'Comoperguard - Arribo de Naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Arribo de Naves',
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
    $.getJSON('/ComoperguardArriboNave/Mostrar?Id=' + Id, [], function (ArriboNaveDTO) {
        $('#txtCodigo').val(ArriboNaveDTO.arriboNaveId);
        $('#cbJefaturaDistritoCapitaniae').val(ArriboNaveDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(ArriboNaveDTO.capitaniaId);
        $('#txtHoraArriboe').val(ArriboNaveDTO.horaArribo);
        $('#txtDiaArriboe').val(ArriboNaveDTO.diaArribo);
        $('#cbMese').val(ArriboNaveDTO.mesId);
        $('#txtAnioArriboe').val(ArriboNaveDTO.anioArribo);
        $('#cbPuertoPerue').val(ArriboNaveDTO.puertoPeruId);
        $('#txtIndicativoNavee').val(ArriboNaveDTO.indicativoNave);
        $('#txtNombreNavee').val(ArriboNaveDTO.nombreNave);
        $('#cbPaisUbigeoe').val(ArriboNaveDTO.paisUbigeoId);
        $('#cbTipoNavee').val(ArriboNaveDTO.tipoNaveId);
        $('#txtNumeroOMIe').val(ArriboNaveDTO.numeroOMI);
        $('#txtABe').val(ArriboNaveDTO.ab);
        $('#txtAgenciaMaritimae').val(ArriboNaveDTO.agenciaMaritima);
        $('#cbPaisProcedenciae').val(ArriboNaveDTO.paisProcedencia);
        $('#txtPuertoProcedenciae').val(ArriboNaveDTO.puertoProcedencia);
        $('#txtTripulantesChilenose').val(ArriboNaveDTO.tripulantesChilenos);
        $('#txtTripulantesEcuatorianose').val(ArriboNaveDTO.tripulantesEcuatorianos);
        $('#txtTripulantesTotale').val(ArriboNaveDTO.tripulantesTotal);
        $('#txtPasajerosChilenose').val(ArriboNaveDTO.pasajerosChilenos);
        $('#txtPasajerosEcuatorianose').val(ArriboNaveDTO.pasajerosEcuatorianos);
        $('#txtPasajerosTotale').val(ArriboNaveDTO.pasajerosTotal);
        $('#txtCantidadCargaDesembarcadae').val(ArriboNaveDTO.cantidadCargaDesembarcada);
        $('#cbUnidadMedidae').val(ArriboNaveDTO.unidadMedidaId);
        $('#cbTipoCargae').val(ArriboNaveDTO.tipoCargaId);
        $('#txtCantidadCargaPeligrosae').val(ArriboNaveDTO.cantidadCargaPeligrosa);
        $('#cbUnidadMedidaPeligrosae').val(ArriboNaveDTO.unidadMedidaPeligrosa);
        $('#txtTipoCargaPeligrosae').val(ArriboNaveDTO.tipoCargaPeligrosa);
        $('#txtObservacionese').val(ArriboNaveDTO.observaciones); 
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
                url: '/ComoperguardArriboNave/Eliminar',
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
                    $('#tblComoperguardArriboNave').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardArriboNave() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardArriboNave/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var mes = Json["data3"];
        var puertoPeru = Json["data4"];
        var paisUbigeo = Json["data5"];
        var tipoNave = Json["data6"];
        var unidadMedida = Json["data7"];
        var tipoCarga = Json["data8"];

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



        $("select#cbPuertoPeru").html("");
        $.each(puertoPeru, function () {
            var RowContent = '<option value=' + this.puertoPeruId + '>' + this.descPuertoPeru + '</option>'
            $("select#cbPuertoPerue").append(RowContent);
        });
        $("select#cbPuertoPerue").html("");
        $.each(puertoPeru, function () {
            var RowContent = '<option value=' + this.puertoPeruId + '>' + this.descPuertoPeru + '</option>'
            $("select#cbPuertoPerue").append(RowContent);
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


        $("select#cbPaisProcedencia").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisProcedenciae").append(RowContent);
        });
        $("select#cbPaisProcedenciae").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisProcedenciae").append(RowContent);
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


        $("select#cbTipoCarga").html("");
        $.each(tipoCarga, function () {
            var RowContent = '<option value=' + this.tipoCargaId + '>' + this.descTipoCarga + '</option>'
            $("select#cbTipoCargae").append(RowContent);
        });
        $("select#cbTipoCargae").html("");
        $.each(tipoCarga, function () {
            var RowContent = '<option value=' + this.tipoCargaId + '>' + this.descTipoCarga + '</option>'
            $("select#cbTipoCargae").append(RowContent);
        });


        $("select#cbUnidadMedidaPeligrosa").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.unidadMedidaId + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedidaPeligrosae").append(RowContent);
        });
        $("select#cbUnidadMedidaPeligrosae").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.unidadMedidaId + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedidaPeligrosae").append(RowContent);
        });

    });
}

