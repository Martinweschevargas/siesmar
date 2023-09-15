var tblComoperguardNavePeruanaCapturadaInternacional;

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
                                url: '/ComoperguardNavePeruanaCapturadaInternacional/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'HoraCaptura': $('#txtHoraCaptura').val(),
                                    'DiaCaptura': $('#txtDiaCaptura').val(),
                                    'MesId': $('#cbMes').val(),
                                    'AnioCaptura': $('#txtAnioCaptura').val(),
                                    'NombreNave': $('#txtNombreNave').val(),
                                    'MatriculaNave': $('#txtMatriculaNave').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'CantidadTripulantes': $('#txtCantidadTripulantes').val(),
                                    'CantidadPasajeros': $('#txtCantidadPasajeros').val(),
                                    'AutoridadEmiteZarpeId': $('#cbAutoridadEmiteZarpe').val(),
                                    'Latitud': $('#txtLatitud').val(),
                                    'Longitud': $('#txtLongitud').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNave').val(),
                                    'PuertoPeruId': $('#cbPuertoPeru').val(),
                                    'PaisUbigeoId': $('#cbPaisDestino').val(),
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
                                    $('#tblComoperguardNavePeruanaCapturadaInternacional').DataTable().ajax.reload();
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
                                url: '/ComoperguardNavePeruanaCapturadaInternacional/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'HoraCaptura': $('#txtHoraCapturae').val(),
                                    'DiaCaptura': $('#txtDiaCapturae').val(),
                                    'MesId': $('#cbMese').val(),
                                    'AnioCaptura': $('#txtAnioCapturae').val(),
                                    'NombreNave': $('#txtNombreNavee').val(),
                                    'MatriculaNave': $('#txtMatriculaNavee').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'CantidadTripulantes': $('#txtCantidadTripulantese').val(),
                                    'CantidadPasajeros': $('#txtCantidadPasajerose').val(),
                                    'AutoridadEmiteZarpeId': $('#cbAutoridadEmiteZarpee').val(),
                                    'Latitud': $('#txtLatitude').val(),
                                    'Longitud': $('#txtLongitude').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNavee').val(),
                                    'PuertoPeruId': $('#cbPuertoPerue').val(),
                                    'PaisUbigeoId': $('#cbPaisDestinoe').val(),
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
                                    $('#tblComoperguardNavePeruanaCapturadaInternacional').DataTable().ajax.reload();
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

    $('#tblComoperguardNavePeruanaCapturadaInternacional').DataTable({
        ajax: {
            "url": '/ComoperguardNavePeruanaCapturadaInternacional/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "navePeruanaCapturadaInternacionalId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "horaCaptura" },
            { "data": "diaCaptura" },
            { "data": "descMes" },
            { "data": "anioCaptura" },
            { "data": "nombreNave" },
            { "data": "matriculaNave" },
            { "data": "descTipoNave" },
            { "data": "cantidadTripulantes" },
            { "data": "cantidadPasajeros" },
            { "data": "descAutoridadEmiteZarpe" },
            { "data": "latitud" },
            { "data": "longitud" },
            { "data": "descAmbitoNaveo" },
            { "data": "descPuertoPeru" },
            { "data": "nombrePais" },
            { "data": "observaciones" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.navePeruanaCapturadaInternacionalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.navePeruanaCapturadaInternacionalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Naves Peruanas Capturadas en Aguas Internacionales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Naves Peruanas Capturadas en Aguas Internacionales',
                title: 'Comoperguard - Naves Peruanas Capturadas en Aguas Internacionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Naves Peruanas Capturadas en Aguas Internacionales',
                title: 'Comoperguard - Naves Peruanas Capturadas en Aguas Internacionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Naves Peruanas Capturadas en Aguas Internacionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
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
    $.getJSON('/ComoperguardNavePeruanaCapturadaInternacional/Mostrar?Id=' + Id, [], function (NavePeruanaCapturadaInternacionalDTO) {
        $('#txtCodigo').val(NavePeruanaCapturadaInternacionalDTO.navePeruanaCapturadaInternacionalId);
        $('#cbJefaturaDistritoCapitaniae').val(NavePeruanaCapturadaInternacionalDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(NavePeruanaCapturadaInternacionalDTO.capitaniaId);
        $('#txtHoraCapturae').val(NavePeruanaCapturadaInternacionalDTO.horaCaptura);
        $('#txtDiaCapturae').val(NavePeruanaCapturadaInternacionalDTO.diaCaptura);
        $('#cbMese').val(NavePeruanaCapturadaInternacionalDTO.mesId);
        $('#txtAnioCapturae').val(NavePeruanaCapturadaInternacionalDTO.anioCaptura);
        $('#txtNombreNavee').val(NavePeruanaCapturadaInternacionalDTO.nombreNave);
        $('#txtMatriculaNavee').val(NavePeruanaCapturadaInternacionalDTO.matriculaNave);
        $('#cbTipoNavee').val(NavePeruanaCapturadaInternacionalDTO.tipoNaveId);
        $('#txtCantidadTripulantese').val(NavePeruanaCapturadaInternacionalDTO.cantidadTripulantes);
        $('#txtCantidadPasajerose').val(NavePeruanaCapturadaInternacionalDTO.cantidadPasajeros);
        $('#cbAutoridadEmiteZarpee').val(NavePeruanaCapturadaInternacionalDTO.autoridadEmiteZarpeId);
        $('#txtLatitude').val(NavePeruanaCapturadaInternacionalDTO.latitud);
        $('#txtLongitude').val(NavePeruanaCapturadaInternacionalDTO.longitud);
        $('#cbAmbitoNavee').val(NavePeruanaCapturadaInternacionalDTO.ambitoNaveId);
        $('#cbPuertoPerue').val(NavePeruanaCapturadaInternacionalDTO.puertoPeruId);
        $('#cbPaisDestinoe').val(NavePeruanaCapturadaInternacionalDTO.paisUbigeoId);
        $('#txtObservacionese').val(NavePeruanaCapturadaInternacionalDTO.observaciones); 
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
                url: '/ComoperguardNavePeruanaCapturadaInternacional/Eliminar',
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
                    $('#tblComoperguardNavePeruanaCapturadaInternacional').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardNavePeruanaCapturadaInternacional() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardNavePeruanaCapturadaInternacional/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var mes = Json["data3"];
        var tipoNave = Json["data4"];
        var autoridadEmiteZarpe = Json["data5"];
        var ambitoNave = Json["data6"];
        var puertoPeru = Json["data7"];
        var paisUbigeo = Json["data8"];

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


        $("select#cbAutoridadEmiteZarpe").html("");
        $.each(autoridadEmiteZarpe, function () {
            var RowContent = '<option value=' + this.autoridadEmiteZarpeId + '>' + this.descAutoridadEmiteZarpe + '</option>'
            $("select#cbAutoridadEmiteZarpee").append(RowContent);
        });
        $("select#cbAutoridadEmiteZarpee").html("");
        $.each(autoridadEmiteZarpe, function () {
            var RowContent = '<option value=' + this.autoridadEmiteZarpeId + '>' + this.descAutoridadEmiteZarpe + '</option>'
            $("select#cbAutoridadEmiteZarpee").append(RowContent);
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


        $("select#cbPaisDestino").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisDestinoe").append(RowContent);
        });
        $("select#cbPaisDestinoe").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisDestinoe").append(RowContent);
        }); 

    });
}

