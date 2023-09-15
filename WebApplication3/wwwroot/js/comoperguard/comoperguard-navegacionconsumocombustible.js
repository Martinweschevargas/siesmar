var tblComoperguardNavegacionConsumoCombustible;

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
                                url: '/ComoperguardNavegacionConsumoCombustible/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'CascoUnidadNaval': $('#txtCascoUnidadNaval').val(),
                                    'TipoUnidadNavalInterventoraId': $('#cbTipoUnidadNavalInterventora').val(),
                                    'TipoCombustibleComoperguardId': $('#cbTipoCombustibleComoperguard').val(),
                                    'StockServicentroSaldop': $('#txtStockServicentroSaldop').val(),
                                    'StockTanque': $('#txtStockTanque').val(),
                                    'StockTotal': $('#txtStockTotal').val(),
                                    'AsignacionMes': $('#txtAsignacionMes').val(),
                                    'EntregaOtrasUUGG': $('#txtEntregaOtrasUUGG').val(),
                                    'ConsumoTotal': $('#txtConsumoTotal').val(),
                                    'SaldoTotalMes': $('#txtSaldoTotalMes').val(),
                                    'StockServicentro': $('#txtStockServicentro').val(),
                                    'StockTanques': $('#txtStockTanques').val(),
                                    'FechaInicio': $('#txtFechaInicio').val(),
                                    'FechaTermino': $('#txtFechaTermino').val(),
                                    'Hora': $('#txtHora').val(),
                                    'Milla': $('#txtMilla').val(),
                                    'OficioReferencia': $('#txtOficioReferencia').val(),
                                    'FechaReferenciaOficio': $('#txtFechaReferenciaOficio').val(), 
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
                                    $('#tblComoperguardNavegacionConsumoCombustible').DataTable().ajax.reload();
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
                                url: '/ComoperguardNavegacionConsumoCombustible/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'CascoUnidadNaval': $('#txtCascoUnidadNavale').val(),
                                    'TipoUnidadNavalInterventoraId': $('#cbTipoUnidadNavalInterventorae').val(),
                                    'TipoCombustibleComoperguardId': $('#cbTipoCombustibleComoperguarde').val(),
                                    'StockServicentroSaldop': $('#txtStockServicentroSaldope').val(),
                                    'StockTanque': $('#txtStockTanquee').val(),
                                    'StockTotal': $('#txtStockTotale').val(),
                                    'AsignacionMes': $('#txtAsignacionMese').val(),
                                    'EntregaOtrasUUGG': $('#txtEntregaOtrasUUGGe').val(),
                                    'ConsumoTotal': $('#txtConsumoTotale').val(),
                                    'SaldoTotalMes': $('#txtSaldoTotalMese').val(),
                                    'StockServicentro': $('#txtStockServicentroe').val(),
                                    'StockTanques': $('#txtStockTanquese').val(),
                                    'FechaInicio': $('#txtFechaInicioe').val(),
                                    'FechaTermino': $('#txtFechaTerminoe').val(),
                                    'Hora': $('#txtHorae').val(),
                                    'Milla': $('#txtMillae').val(),
                                    'OficioReferencia': $('#txtOficioReferenciae').val(),
                                    'FechaReferenciaOficio': $('#txtFechaReferenciaOficioe').val(), 
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
                                    $('#tblComoperguardNavegacionConsumoCombustible').DataTable().ajax.reload();
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

    $('#tblComoperguardNavegacionConsumoCombustible').DataTable({
        ajax: {
            "url": '/ComoperguardNavegacionConsumoCombustible/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "navesExtranjerasCapturadasId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "descUnidadNaval" },
            { "data": "cascoUnidadNaval" },
            { "data": "descTipoUnidadNavalInterventora" },
            { "data": "descTipoCombustibleComoperguard" },
            { "data": "stockServicentroSaldop" },
            { "data": "stockTanque" },
            { "data": "stockTotal" },
            { "data": "asignacionMes" },
            { "data": "entregaOtrasUUGG" },
            { "data": "consumoTotal" },
            { "data": "saldoTotalMes" },
            { "data": "stockServicentro" },
            { "data": "stockTanques" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "hora" },
            { "data": "milla" },
            { "data": "oficioReferencia" },
            { "data": "fechaReferenciaOficio" },

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
                filename: 'Comoperguard - Millas, horas Navegadas y Consumo de Combustible',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Millas, horas Navegadas y Consumo de Combustible',
                title: 'Comoperguard - Millas, horas Navegadas y Consumo de Combustible',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Millas, horas Navegadas y Consumo de Combustible',
                title: 'Comoperguard - Millas, horas Navegadas y Consumo de Combustible',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Millas, horas Navegadas y Consumo de Combustible',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
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
    $.getJSON('/ComoperguardNavegacionConsumoCombustible/Mostrar?Id=' + Id, [], function (NavegacionConsumoCombustibleDTO) {
        $('#txtCodigo').val(NavegacionConsumoCombustibleDTO.navesExtranjerasCapturadasId);
        $('#cbJefaturaDistritoCapitaniae').val(NavegacionConsumoCombustibleDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(NavegacionConsumoCombustibleDTO.capitaniaId);
        $('#cbUnidadNavale').val(NavegacionConsumoCombustibleDTO.unidadNavalId);
        $('#txtCascoUnidadNavale').val(NavegacionConsumoCombustibleDTO.cascoUnidadNaval);
        $('#cbTipoUnidadNavalInterventorae').val(NavegacionConsumoCombustibleDTO.tipoUnidadNavalInterventoraId);
        $('#cbTipoCombustibleComoperguarde').val(NavegacionConsumoCombustibleDTO.tipoCombustibleComoperguardId);
        $('#txtStockServicentroSaldope').val(NavegacionConsumoCombustibleDTO.stockServicentroSaldop);
        $('#txtStockTanquee').val(NavegacionConsumoCombustibleDTO.stockTanque);
        $('#txtStockTotale').val(NavegacionConsumoCombustibleDTO.stockTotal);
        $('#txtAsignacionMese').val(NavegacionConsumoCombustibleDTO.asignacionMes);
        $('#txtEntregaOtrasUUGGe').val(NavegacionConsumoCombustibleDTO.entregaOtrasUUGG);
        $('#txtConsumoTotale').val(NavegacionConsumoCombustibleDTO.consumoTotal);
        $('#txtSaldoTotalMese').val(NavegacionConsumoCombustibleDTO.saldoTotalMes);
        $('#txtStockServicentroe').val(NavegacionConsumoCombustibleDTO.stockServicentro);
        $('#txtStockTanquese').val(NavegacionConsumoCombustibleDTO.stockTanques);
        $('#txtFechaInicioe').val(NavegacionConsumoCombustibleDTO.fechaInicio);
        $('#txtFechaTerminoe').val(NavegacionConsumoCombustibleDTO.fechaTermino);
        $('#txtHorae').val(NavegacionConsumoCombustibleDTO.hora);
        $('#txtMillae').val(NavegacionConsumoCombustibleDTO.Milla);
        $('#txtOficioReferenciae').val(NavegacionConsumoCombustibleDTO.OficioReferencia);
        $('#txtFechaReferenciaOficioe').val(NavegacionConsumoCombustibleDTO.FechaReferenciaOficio); 
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
                url: '/ComoperguardNavegacionConsumoCombustible/Eliminar',
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
                    $('#tblComoperguardNavegacionConsumoCombustible').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardNavegacionConsumoCombustible() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardNavegacionConsumoCombustible/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var unidadNaval = Json["data3"];
        var tipoUnidadNavalInterventora = Json["data4"];
        var tipoCombustibleComoperguard = Json["data5"];

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

        $("select#cbTipoUnidadNavalInterventora").html("");
        $.each(tipoUnidadNavalInterventora, function () {
            var RowContent = '<option value=' + this.tipoUnidadNavalInterventoraId + '>' + this.descTipoUnidadNavalInterventora + '</option>'
            $("select#cbTipoUnidadNavalInterventorae").append(RowContent);
        });
        $("select#cbTipoUnidadNavalInterventorae").html("");
        $.each(tipoUnidadNavalInterventora, function () {
            var RowContent = '<option value=' + this.tipoUnidadNavalInterventoraId + '>' + this.descTipoUnidadNavalInterventora + '</option>'
            $("select#cbTipoUnidadNavalInterventorae").append(RowContent);
        });


        $("select#cbTipoCombustibleComoperguard").html("");
        $.each(tipoCombustibleComoperguard, function () {
            var RowContent = '<option value=' + this.tipoCombustibleComoperguardId + '>' + this.descTipoCombustibleComoperguard + '</option>'
            $("select#cbTipoCombustibleComoperguarde").append(RowContent);
        });
        $("select#cbTipoCombustibleComoperguarde").html("");
        $.each(tipoCombustibleComoperguard, function () {
            var RowContent = '<option value=' + this.tipoCombustibleComoperguardId + '>' + this.descTipoCombustibleComoperguard + '</option>'
            $("select#cbTipoCombustibleComoperguarde").append(RowContent);
        }); 
    });
}

