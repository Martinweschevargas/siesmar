var tblComoperguardZarpeNave;

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
                                url: '/ComoperguardZarpeNave/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'HoraZarpe': $('#txtHoraArribo').val(),
                                    'DiaZarpe': $('#txtDiaArribo').val(),
                                    'MesId': $('#cbMes').val(),
                                    'AnioZarpe': $('#txtAnioArribo').val(),
                                    'PuertoZarpe': $('#txtPuertoPeru').val(),
                                    'IndicativoNave': $('#txtIndicativoNave').val(),
                                    'NombreNave': $('#txtNombreNave').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'NumeroOMI': $('#txtNumeroOMI').val(),
                                    'AB': $('#txtAB').val(),
                                    'AgenciaMaritima': $('#txtAgenciaMaritima').val(),
                                    'PaisProcedencia': $('#cbPaisProcedencia').val(),
                                    'PuertoProcedencia': $('#txtPuertoProcedencia').val(),
                                    'TiempoEstimadoArriboHoras': $('#txtTiempoEstimadoArriboHoras').val(),
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
                                    'TipoCargaPeligrosa': $('#cbTipoCargaPeligrosa').val(),
                                    'CantidadCargaTransito': $('#txtCantidadCargaTransito').val(),
                                    'UnidadMedidaTransito': $('#cbUnidadMedidaTransito').val(),
                                    'TipoCargaTransito': $('#cbTipoCargaTransito').val(),
                                    'CantidadCargaPeligrosaTransito': $('#txtCantidadCargaPeligrosaTransito').val(),
                                    'UnidadMedidaPeligrosaTransito': $('#cbUnidadMedidaPeligrosaTransito').val(),
                                    'TipoCargaPeligrosaTransito': $('#cbTipoCargaPeligrosaTransito').val(), 
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
                                    $('#tblComoperguardZarpeNave').DataTable().ajax.reload();
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
                                url: '/ComoperguardZarpeNave/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'HoraZarpe': $('#txtHoraArriboe').val(),
                                    'DiaZarpe': $('#txtDiaArriboe').val(),
                                    'MesId': $('#cbMese').val(),
                                    'AnioZarpe': $('#txtAnioArriboe').val(),
                                    'PuertoZarpe': $('#txtPuertoPerue').val(),
                                    'IndicativoNave': $('#txtIndicativoNavee').val(),
                                    'NombreNave': $('#txtNombreNavee').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'NumeroOMI': $('#txtNumeroOMIe').val(),
                                    'AB': $('#txtABe').val(),
                                    'AgenciaMaritima': $('#txtAgenciaMaritimae').val(),
                                    'PaisProcedencia': $('#cbPaisProcedenciae').val(),
                                    'PuertoProcedencia': $('#txtPuertoProcedenciae').val(),
                                    'TiempoEstimadoArriboHoras': $('#txtTiempoEstimadoArriboHorase').val(),
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
                                    'TipoCargaPeligrosa': $('#cbTipoCargaPeligrosae').val(),
                                    'CantidadCargaTransito': $('#txtCantidadCargaTransitoe').val(),
                                    'UnidadMedidaTransito': $('#cbUnidadMedidaTransitoe').val(),
                                    'TipoCargaTransito': $('#cbTipoCargaTransitoe').val(),
                                    'CantidadCargaPeligrosaTransito': $('#txtCantidadCargaPeligrosaTransitoe').val(),
                                    'UnidadMedidaPeligrosaTransito': $('#cbUnidadMedidaPeligrosaTransitoe').val(),
                                    'TipoCargaPeligrosaTransito': $('#cbTipoCargaPeligrosaTransitoe').val(), 
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
                                    $('#tblComoperguardZarpeNave').DataTable().ajax.reload();
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

    $('#tblComoperguardZarpeNave').DataTable({
        ajax: {
            "url": '/ComoperguardZarpeNave/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "zarpeNaveId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "horaZarpe" },
            { "data": "diaZarpe" },
            { "data": "descMes" },
            { "data": "anioZarpe" },
            { "data": "puertoZarpe" },
            { "data": "indicativoNave" },
            { "data": "nombreNave" },
            { "data": "nombrePais" },
            { "data": "descTipoNave" },
            { "data": "numeroOMI" },
            { "data": "ab" },
            { "data": "agenciaMaritima" },
            { "data": "nombrePaisProcedencia" },
            { "data": "puertoProcedencia" },
            { "data": "tiempoEstimadoArriboHoras" },
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
            { "data": "descUnidadMedidaPeligrosa" },
            { "data": "desceTipoCargaPeligrosa" },
            { "data": "cantidadCargaTransito" },
            { "data": "descUnidadMedidaTransito" },
            { "data": "descTipoCargaTransito" },
            { "data": "cantidadCargaPeligrosaTransito" },
            { "data": "descUnidadMedidaPeligrosaTransito" },
            { "data": "descTipoCargaPeligrosaTransito" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.zarpeNaveId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.zarpeNaveId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Zarpe de Naves',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Zarpe de Naves',
                title: 'Comoperguard - Zarpe de Naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Zarpe de Naves',
                title: 'Comoperguard - Zarpe de Naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Zarpe de Naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35]
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
    $.getJSON('/ComoperguardZarpeNave/Mostrar?Id=' + Id, [], function (ZarpeNaveDTO) {
        $('#txtCodigo').val(ZarpeNaveDTO.zarpeNaveId);
        $('#cbJefaturaDistritoCapitaniae').val(ZarpeNaveDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(ZarpeNaveDTO.capitaniaId);
        $('#txtHoraArriboe').val(ZarpeNaveDTO.horaZarpe);
        $('#txtDiaArriboe').val(ZarpeNaveDTO.diaZarpe);
        $('#cbMese').val(ZarpeNaveDTO.mesId);
        $('#txtAnioArriboe').val(ZarpeNaveDTO.anioZarpe);
        $('#txtPuertoPerue').val(ZarpeNaveDTO.puertoZarpe);
        $('#txtIndicativoNavee').val(ZarpeNaveDTO.indicativoNave);
        $('#txtNombreNavee').val(ZarpeNaveDTO.nombreNave);
        $('#cbPaisUbigeoe').val(ZarpeNaveDTO.paisUbigeoId);
        $('#cbTipoNavee').val(ZarpeNaveDTO.tipoNaveId);
        $('#txtNumeroOMIe').val(ZarpeNaveDTO.numeroOMI);
        $('#txtABe').val(ZarpeNaveDTO.ab);
        $('#txtAgenciaMaritimae').val(ZarpeNaveDTO.agenciaMaritima);
        $('#cbPaisProcedenciae').val(ZarpeNaveDTO.paisProcedencia);
        $('#txtPuertoProcedenciae').val(ZarpeNaveDTO.puertoProcedencia);
        $('#txtTiempoEstimadoArriboHorase').val(ZarpeNaveDTO.tiempoEstimadoArriboHoras);
        $('#txtTripulantesChilenose').val(ZarpeNaveDTO.tripulantesChilenos);
        $('#txtTripulantesEcuatorianose').val(ZarpeNaveDTO.tripulantesEcuatorianos);
        $('#txtTripulantesTotale').val(ZarpeNaveDTO.tripulantesTotal);
        $('#txtPasajerosChilenose').val(ZarpeNaveDTO.pasajerosChilenos);
        $('#txtPasajerosEcuatorianose').val(ZarpeNaveDTO.pasajerosEcuatorianos);
        $('#txtPasajerosTotale').val(ZarpeNaveDTO.pasajerosTotal);
        $('#txtCantidadCargaDesembarcadae').val(ZarpeNaveDTO.cantidadCargaDesembarcada);
        $('#cbUnidadMedidae').val(ZarpeNaveDTO.unidadMedidaId);
        $('#cbTipoCargae').val(ZarpeNaveDTO.tipoCargaId);
        $('#txtCantidadCargaPeligrosae').val(ZarpeNaveDTO.cantidadCargaPeligrosa);
        $('#cbUnidadMedidaPeligrosae').val(ZarpeNaveDTO.unidadMedidaPeligrosa);
        $('#cbTipoCargaPeligrosae').val(ZarpeNaveDTO.tipoCargaPeligrosa);
        $('#txtCantidadCargaTransitoe').val(ZarpeNaveDTO.cantidadCargaTransito);
        $('#cbUnidadMedidaTransitoe').val(ZarpeNaveDTO.unidadMedidaTransito);
        $('#cbTipoCargaTransitoe').val(ZarpeNaveDTO.tipoCargaTransito);
        $('#txtCantidadCargaPeligrosaTransitoe').val(ZarpeNaveDTO.cantidadCargaPeligrosaTransito);
        $('#cbUnidadMedidaPeligrosaTransitoe').val(ZarpeNaveDTO.unidadMedidaPeligrosaTransito);
        $('#cbTipoCargaPeligrosaTransitoe').val(ZarpeNaveDTO.tipoCargaPeligrosaTransito); 
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
                url: '/ComoperguardZarpeNave/Eliminar',
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
                    $('#tblComoperguardZarpeNave').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardZarpeNave() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardZarpeNave/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var mes = Json["data3"];
        var paisUbigeo = Json["data4"];
        var tipoNave = Json["data5"];
        var unidadMedida = Json["data6"];
        var tipoCarga = Json["data7"];

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


        $("select#cbTipoCargaPeligrosa").html("");
        $.each(tipoCarga, function () {
            var RowContent = '<option value=' + this.tipoCargaId + '>' + this.descTipoCarga + '</option>'
            $("select#cbTipoCargaPeligrosae").append(RowContent);
        });
        $("select#cbTipoCargaPeligrosae").html("");
        $.each(tipoCarga, function () {
            var RowContent = '<option value=' + this.tipoCargaId + '>' + this.descTipoCarga + '</option>'
            $("select#cbTipoCargaPeligrosae").append(RowContent);
        });


        $("select#cbUnidadMedidaTransito").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.unidadMedidaId + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedidaTransitoe").append(RowContent);
        });
        $("select#cbUnidadMedidaTransitoe").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.unidadMedidaId + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedidaTransitoe").append(RowContent);
        });


        $("select#cbTipoCargaTransito").html("");
        $.each(tipoCarga, function () {
            var RowContent = '<option value=' + this.tipoCargaId + '>' + this.descTipoCarga + '</option>'
            $("select#cbTipoCargaTransitoe").append(RowContent);
        });
        $("select#cbTipoCargaTransitoe").html("");
        $.each(tipoCarga, function () {
            var RowContent = '<option value=' + this.tipoCargaId + '>' + this.descTipoCarga + '</option>'
            $("select#cbTipoCargaTransitoe").append(RowContent);
        });


        $("select#cbUnidadMedidaPeligrosaTransito").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.unidadMedidaId + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedidaPeligrosaTransitoe").append(RowContent);
        });
        $("select#cbUnidadMedidaPeligrosaTransitoe").html("");
        $.each(unidadMedida, function () {
            var RowContent = '<option value=' + this.unidadMedidaId + '>' + this.descUnidadMedida + '</option>'
            $("select#cbUnidadMedidaPeligrosaTransitoe").append(RowContent);
        });


        $("select#cbTipoCargaPeligrosaTransito").html("");
        $.each(tipoCarga, function () {
            var RowContent = '<option value=' + this.tipoCargaId + '>' + this.descTipoCarga + '</option>'
            $("select#cbTipoCargaPeligrosaTransitoe").append(RowContent);
        });
        $("select#cbTipoCargaPeligrosaTransitoe").html("");
        $.each(tipoCarga, function () {
            var RowContent = '<option value=' + this.tipoCargaId + '>' + this.descTipoCarga + '</option>'
            $("select#cbTipoCargaPeligrosaTransitoe").append(RowContent);
        }); 
    });
}

