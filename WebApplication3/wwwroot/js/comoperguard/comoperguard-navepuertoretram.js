var tblComoperguardNavePuertoRETRAM;

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
                                url: '/ComoperguardNavePuertoRETRAM/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'IndicativoLlamada': $('#txtIndicativoLlamada').val(),
                                    'NombreBuque': $('#txtNombreBuque').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'NumeroOMI': $('#txtNumeroOMI').val(),
                                    'AB': $('#txtAB').val(),
                                    'PaisProcedencia': $('#cbPaisProcedencia').val(),
                                    'FechaArribo': $('#txtFechaArribo').val(),
                                    'HoraArribo': $('#txtHoraArribo').val(),
                                    'PuertoPeruId': $('#cbPuertoPeru').val(),
                                    'TiempoPermanencia': $('#txtTiempoPermanencia').val(),
                                    'ProximosPuertos': $('#txtProximosPuertos').val(),
                                    'TripulantesChilenos': $('#txtTripulantesChilenos').val(),
                                    'TripulantesEcuatorianos': $('#txtTripulantesEcuatorianos').val(),
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
                                    $('#tblComoperguardNavePuertoRETRAM').DataTable().ajax.reload();
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
                                url: '/ComoperguardNavePuertoRETRAM/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'IndicativoLlamada': $('#txtIndicativoLlamadae').val(),
                                    'NombreBuque': $('#txtNombreBuquee').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'NumeroOMI': $('#txtNumeroOMIe').val(),
                                    'AB': $('#txtABe').val(),
                                    'PaisProcedencia': $('#cbPaisProcedenciae').val(),
                                    'FechaArribo': $('#txtFechaArriboe').val(),
                                    'HoraArribo': $('#txtHoraArriboe').val(),
                                    'PuertoPeruId': $('#cbPuertoPerue').val(),
                                    'TiempoPermanencia': $('#txtTiempoPermanenciae').val(),
                                    'ProximosPuertos': $('#txtProximosPuertose').val(),
                                    'TripulantesChilenos': $('#txtTripulantesChilenose').val(),
                                    'TripulantesEcuatorianos': $('#txtTripulantesEcuatorianose').val(),
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
                                    $('#tblComoperguardNavePuertoRETRAM').DataTable().ajax.reload();
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

    $('#tblComoperguardNavePuertoRETRAM').DataTable({
        ajax: {
            "url": '/ComoperguardNavePuertoRETRAM/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "navePuertoRETRAMId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "indicativoLlamada" },
            { "data": "nombreBuque" },
            { "data": "nombrePais" },
            { "data": "descTipoNave" },
            { "data": "numeroOMI" },
            { "data": "ab" },
            { "data": "descPaisProcedencia" },
            { "data": "fechaArribo" },
            { "data": "horaArribo" },
            { "data": "descPuertoPeru" },
            { "data": "tiempoPermanencia" },
            { "data": "proximosPuertos" },
            { "data": "tripulantesChilenos" },
            { "data": "tripulantesEcuatorianos" },
            { "data": "observaciones" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.navePuertoRETRAMId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.navePuertoRETRAMId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Naves en Puerto – RETRAM',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Naves en Puerto – RETRAM',
                title: 'Comoperguard - Naves en Puerto – RETRAM',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Naves en Puerto – RETRAM',
                title: 'Comoperguard - Naves en Puerto – RETRAM',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Naves en Puerto – RETRAM',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
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
    $.getJSON('/ComoperguardNavePuertoRETRAM/Mostrar?Id=' + Id, [], function (NavePuertoRETRAMDTO) {
        $('#txtCodigo').val(NavePuertoRETRAMDTO.navePuertoRETRAMId);
        $('#cbJefaturaDistritoCapitaniae').val(NavePuertoRETRAMDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(NavePuertoRETRAMDTO.capitaniaId);
        $('#txtIndicativoLlamadae').val(NavePuertoRETRAMDTO.indicativoLlamada);
        $('#txtNombreBuquee').val(NavePuertoRETRAMDTO.nombreBuque);
        $('#cbPaisUbigeoe').val(NavePuertoRETRAMDTO.paisUbigeoId);
        $('#cbTipoNavee').val(NavePuertoRETRAMDTO.tipoNaveId);
        $('#txtNumeroOMIe').val(NavePuertoRETRAMDTO.numeroOMI);
        $('#txtABe').val(NavePuertoRETRAMDTO.ab);
        $('#cbPaisProcedenciae').val(NavePuertoRETRAMDTO.paisProcedencia);
        $('#txtFechaArriboe').val(NavePuertoRETRAMDTO.fechaArribo);
        $('#txtHoraArriboe').val(NavePuertoRETRAMDTO.horaArribo);
        $('#cbPuertoPerue').val(NavePuertoRETRAMDTO.puertoPeruId);
        $('#txtTiempoPermanenciae').val(NavePuertoRETRAMDTO.tiempoPermanencia);
        $('#txtProximosPuertose').val(NavePuertoRETRAMDTO.proximosPuertos);
        $('#txtTripulantesChilenose').val(NavePuertoRETRAMDTO.tripulantesChilenos);
        $('#txtTripulantesEcuatorianose').val(NavePuertoRETRAMDTO.tripulantesEcuatorianos);
        $('#txtObservacionese').val(NavePuertoRETRAMDTO.observaciones); 
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
                url: '/ComoperguardNavePuertoRETRAM/Eliminar',
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
                    $('#tblComoperguardNavePuertoRETRAM').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardNavePuertoRETRAM() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardNavePuertoRETRAM/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var paisUbigeo = Json["data3"];
        var tipoNave = Json["data4"];
        var puertoPeru = Json["data5"];


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

    });

}

