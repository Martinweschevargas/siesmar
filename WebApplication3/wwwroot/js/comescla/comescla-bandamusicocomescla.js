var tblComesclaBandaMusico;

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
                                url: '/ComesclaBandaMusico/Insertar',
                                data: {
                                    'TipoComisionId': $('#cbTipoComision').val(),
                                    'EventoId': $('#cbEvento').val(),
                                    'SolicitudDocumentoReferencia': $('#txtSolicitudDocumentoReferencia').val(),
                                    'InstitucionSolicitante': $('#txtInstitucionSolicitante').val(),
                                    'GrupoComisionadoId': $('#cbGrupoComisionado').val(),
                                    'VestimentaUniforme': $('#txtVestimentaUniforme').val(),
                                    'NombreEvento': $('#txtNombreEvento').val(),
                                    'Lugar': $('#txtLugar').val(),
                                    'FechaHoraSalida': $('#txtFechaHoraSalida').val(),
                                    'FechaHoraInicio': $('#txtFechaHoraInicio').val(),
                                    'FechaHoraTermino': $('#txtFechaHoraTermino').val(),
                                    'RequerimientoMovilidad': $('#txtRequerimientoMovilidad').val(),
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
                                    $('#tblComesclaBandaMusico').DataTable().ajax.reload();
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
                                url: '/ComesclaBandaMusico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoComisionId': $('#cbTipoComisione').val(),
                                    'EventoId': $('#cbEventoe').val(),
                                    'SolicitudDocumentoReferencia': $('#txtSolicitudDocumentoReferenciae').val(),
                                    'InstitucionSolicitante': $('#txtInstitucionSolicitantee').val(),
                                    'GrupoComisionadoId': $('#cbGrupoComisionadoe').val(),
                                    'VestimentaUniforme': $('#txtVestimentaUniformee').val(),
                                    'NombreEvento': $('#txtNombreEventoe').val(),
                                    'Lugar': $('#txtLugare').val(),
                                    'FechaHoraSalida': $('#txtFechaHoraSalidae').val(),
                                    'FechaHoraInicio': $('#txtFechaHoraInicioe').val(),
                                    'FechaHoraTermino': $('#txtFechaHoraTerminoe').val(),
                                    'RequerimientoMovilidad': $('#txtRequerimientoMovilidade').val(),
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
                                    $('#tblComesclaBandaMusico').DataTable().ajax.reload();
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

    $('#tblComesclaBandaMusico').DataTable({
        ajax: {
            "url": '/ComesclaBandaMusico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "bandaMusicoId" },
            { "data": "descTipoComision" },
            { "data": "descEvento" },
            { "data": "solicitudDocumentoReferencia" },
            { "data": "institucionSolicitante" },
            { "data": "descGrupoComisionado" },
            { "data": "vestimentaUniforme" },
            { "data": "nombreEvento" },
            { "data": "lugar" },
            { "data": "fechaHoraSalida" },
            { "data": "fechaHoraInicio" },
            { "data": "fechaHoraTermino" },
            { "data": "requerimientoMovilidad" },
            { "data": "observaciones" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.bandaMusicoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.bandaMusicoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comescla - Banda de Músicos',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comescla - Banda de Músicos',
                title: 'Comescla - Banda de Músicos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescla - Banda de Músicos',
                title: 'Comescla - Banda de Músicos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescla - Banda de Músicos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
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
    $.getJSON('/ComesclaBandaMusico/Mostrar?Id=' + Id, [], function (BandaMusicoComesclaDTO) {
        $('#txtCodigo').val(BandaMusicoComesclaDTO.bandaMusicoId);
        $('#cbTipoComisione').val(BandaMusicoComesclaDTO.tipoComisionId);
        $('#cbEventoe').val(BandaMusicoComesclaDTO.eventoId);
        $('#txtSolicitudDocumentoReferenciae').val(BandaMusicoComesclaDTO.solicitudDocumentoReferencia);
        $('#txtInstitucionSolicitantee').val(BandaMusicoComesclaDTO.institucionSolicitante);
        $('#cbGrupoComisionadoe').val(BandaMusicoComesclaDTO.grupoComisionadoId);
        $('#txtVestimentaUniformee').val(BandaMusicoComesclaDTO.vestimentaUniforme);
        $('#txtNombreEventoe').val(BandaMusicoComesclaDTO.nombreEvento);
        $('#txtLugare').val(BandaMusicoComesclaDTO.lugar);
        $('#txtFechaHoraSalidae').val(BandaMusicoComesclaDTO.fechaHoraSalida);
        $('#txtFechaHoraInicioe').val(BandaMusicoComesclaDTO.fechaHoraInicio);
        $('#txtFechaHoraTerminoe').val(BandaMusicoComesclaDTO.fechaHoraTermino);
        $('#txtRequerimientoMovilidade').val(BandaMusicoComesclaDTO.requerimientoMovilidad);
        $('#txtObservacionese').val(BandaMusicoComesclaDTO.observaciones); 
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
                url: '/ComesclaBandaMusico/Eliminar',
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
                    $('#tblComesclaBandaMusico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComesclaBandaMusico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComesclaBandaMusico/cargaCombs', [], function (Json) {
        var tipoComision = Json["data1"];
        var evento = Json["data2"];
        var grupoComisionado = Json["data3"];

        $("select#cbTipoComision").html("");
        $.each(tipoComision, function () {
            var RowContent = '<option value=' + this.tipoComisionId + '>' + this.descTipoComision + '</option>'
            $("select#cbTipoComision").append(RowContent);
        });
        $("select#cbTipoComisione").html("");
        $.each(tipoComision, function () {
            var RowContent = '<option value=' + this.tipoComisionId + '>' + this.descTipoComision + '</option>'
            $("select#cbTipoComisione").append(RowContent);
        });


        $("select#cbEvento").html("");
        $.each(evento, function () {
            var RowContent = '<option value=' + this.eventoId + '>' + this.descEvento + '</option>'
            $("select#cbEvento").append(RowContent);
        });
        $("select#cbEventoe").html("");
        $.each(evento, function () {
            var RowContent = '<option value=' + this.eventoId + '>' + this.descEvento + '</option>'
            $("select#cbEventoe").append(RowContent);
        });


        $("select#cbGrupoComisionado").html("");
        $.each(grupoComisionado, function () {
            var RowContent = '<option value=' + this.grupoComisionadoId + '>' + this.descGrupoComisionado + '</option>'
            $("select#cbGrupoComisionado").append(RowContent);
        });
        $("select#cbGrupoComisionadoe").html("");
        $.each(grupoComisionado, function () {
            var RowContent = '<option value=' + this.grupoComisionadoId + '>' + this.descGrupoComisionado + '</option>'
            $("select#cbGrupoComisionadoe").append(RowContent);
        }); 


    });
}

