var tblComoperguardAperturaCierrePuertos;

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
                                url: '/ComoperguardAperturaCierrePuertos/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'Condicion': $('#txtCondicion').val(),
                                    'TipoPuertoPeruId': $('#cbTipoPuertoPeru').val(),
                                    'FechaInicio': $('#txtFechaInicio').val(),
                                    'FechaTermino': $('#txtFechaTermino').val(),
                                    'ResolucionCapitania': $('#txtResolucionCapitania').val(),
                                    'FechaResolucion': $('#txtFechaResolucion').val(),
                                    'GFHMensajeNaval': $('#txtGFHMensajeNaval').val(), 
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
                                    $('#tblComoperguardAperturaCierrePuertos').DataTable().ajax.reload();
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
                                url: '/ComoperguardAperturaCierrePuertos/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'Condicion': $('#txtCondicione').val(),
                                    'TipoPuertoPeruId': $('#cbTipoPuertoPerue').val(),
                                    'FechaInicio': $('#txtFechaInicioe').val(),
                                    'FechaTermino': $('#txtFechaTerminoe').val(),
                                    'ResolucionCapitania': $('#txtResolucionCapitaniae').val(),
                                    'FechaResolucion': $('#txtFechaResolucione').val(),
                                    'GFHMensajeNaval': $('#txtGFHMensajeNavale').val(), 
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
                                    $('#tblComoperguardAperturaCierrePuertos').DataTable().ajax.reload();
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

    $('#tblComoperguardAperturaCierrePuertos').DataTable({
        ajax: {
            "url": '/ComoperguardAperturaCierrePuertos/CargaTabla',
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
    $.getJSON('/ComoperguardAperturaCierrePuertos/Mostrar?Id=' + Id, [], function (MineriaIlegalDTO) {
        $('#txtCodigo').val(MineriaIlegalDTO.mineriaIlegalId);
        $('#cbJefaturaDistritoCapitaniae').val(AperturaCierrePuertosDTO.JefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(AperturaCierrePuertosDTO.CapitaniaId);
        $('#txtCondicione').val(AperturaCierrePuertosDTO.Condicion);
        $('#cbTipoPuertoPerue').val(AperturaCierrePuertosDTO.TipoPuertoPeruId);
        $('#txtFechaInicioe').val(AperturaCierrePuertosDTO.FechaInicio);
        $('#txtFechaTerminoe').val(AperturaCierrePuertosDTO.FechaTermino);
        $('#txtResolucionCapitaniae').val(AperturaCierrePuertosDTO.ResolucionCapitania);
        $('#txtFechaResolucione').val(AperturaCierrePuertosDTO.FechaResolucion);
        $('#txtGFHMensajeNavale').val(AperturaCierrePuertosDTO.GFHMensajeNaval); 
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
                url: '/ComoperguardAperturaCierrePuertos/Eliminar',
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
                    $('#tblComoperguardAperturaCierrePuertos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardAperturaCierrePuertos() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardAperturaCierrePuertos/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var tipoPuertoPeru = Json["data3"];


        $("select#cbJefaturaDistritoCapitania").html("");
        $.each(jefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });
        $("select#cbJefaturaDistritoCapitaniae").html("");
        $.each(jefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });

        $("select#cbCapitania").html("");
        $.each(capitania, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbCapitaniae").append(RowContent);
        });
        $("select#cbCapitaniae").html("");
        $.each(capitania, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbCapitaniae").append(RowContent);
        });

        $("select#cbTipoPuertoPeru").html("");
        $.each(tipoPuertoPeru, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbTipoPuertoPerue").append(RowContent);
        });
        $("select#cbTipoPuertoPerue").html("");
        $.each(tipoPuertoPeru, function () {
            var RowContent = '<option value=' + this.areaDiperadmonId + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbTipoPuertoPerue").append(RowContent);
        }); 
    });
}

