var tblIpecamarInspeccionInstitucionales;

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
                                url: '/IpecamarInspeccionInstitucionales/Insertar',
                                data: {
                                    'FechaInicioInspeccion': $('#cbFechFechaInicioInsp').val(),
                                    'FechaTerminoInspeccion': $('#txtFechaTerminoInsp').val(),
                                    'DuracionInspeccion': $('#txtDuracionInspeccion').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDependencia').val(),
                                    'CodigoNivelDependencia': $('#cbNivelDependencia').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoInspeccionConocimiento': $('#cbInspeccionConocimiento').val(),
                                    'CodigoInspeccionExtension': $('#cbInspeccionExtension').val(),
                                    'CodigoInspeccionFinalidad': $('#cbInspeccionFinalidad').val(),
                                    'CodigoOrganoControlInspeccion': $('#cbOrganoControlInspeccion').val(),
                                    'QInspectorParticipante': $('#txtQInspectorParticipante').val(),
                                    'DeficienciaOperAdm': $('#txtDeficienciaOperAdm').val(),
                                    'DeficienciaComunesOperAdm': $('#txtDeficienciaComunesOperAdm').val(),
                                    'ApreciacionOperAdm': $('#txtApreciacionOperAdm').val(),
                                    'ObservacionOperAdm': $('#txtObservacionOperAdm').val(),
                                    'IrregularidadOperAdm': $('#txtIrregularidadOperAdm').val(),
                                    'DeficienciaControlGestion': $('#txtDeficienciaControlGestion').val(),
                                    'DeficienciaComunControlG': $('#txtDeficienciaComunControlG').val(),
                                    'ApreciacionControlGestion': $('#txtApreciacionControlGestion').val(),
                                    'ObservacionControlGestion': $('#txtObservacionControlGestion').val(),
                                    'IrregularidadControlGestion': $('#txtIrregularidadControlGestion').val(),
                                    'DeficienciaPendOperAdm': $('#txtDeficienciaPendOperAdm').val(),
                                    'DeficienciaComunPendOperAdm': $('#txtDeficienciaComunPendOperAdm').val(),
                                    'ApreciacionPendOperAdm': $('#txtApreciacionPendOperAdm').val(),
                                    'ObservacionPendOperAdm': $('#txtObservacionPendOperAdm').val(),
                                    'IrregularidadPendOperAdm': $('#txtIrregularidadPendOperAdm').val(),
                                    'DeficienciaPendControlGestion': $('#txtDeficienciaPendControlGestion').val(),
                                    'DeficienciaComunPendControlGestion': $('#txtDeficienciaComunPendControlGestion').val(),
                                    'ApreciacionPendControlGestion': $('#txtApreciacionPendControlGestion').val(),
                                    'ObservacionPendControlGestion': $('#txtObservacionPendControlGestion').val(),
                                    'IrregularidadPendControlGestion': $('#txtIrregularidadPendControlGestion').val(),
                                    'DeficienciaSuperadaOperAdm': $('#txtDeficienciaSuperadaOperAdm').val(),
                                    'DeficienciaComunSuperadaOperAdm': $('#txtDeficienciaComunSuperadaOperAdm').val(),
                                    'ApreciacionSuperadaOperAdm': $('#txtApreciacionSuperadaOperAdm').val(),
                                    'ObservacionSuperadaOperAdm': $('#txtObservacionSuperadaOperAdm').val(),
                                    'IrregularidadSuperadaOperAdm': $('#txtIrregularidadSuperadaOperAdm').val(),
                                    'DeficienciaSuperadaControlGestion': $('#txtDeficienciaSuperadaControlGestion').val(),
                                    'DeficienciaComunSuperadaControlGestion': $('#txtDeficienciaComunSuperadaControlGestion').val(),
                                    'ApreciacionSuperadaControlGestion': $('#txtApreciacionSuperadaControlGestion').val(),
                                    'ObservacionSuperadaControlGestion': $('#txtObservacionSuperadaControlGestion').val(),
                                    'IrregularidadSuperadaControlGestion': $('#txtIrregularidadSuperadaControlGestion').val(),
                                    'FTotalDeficiencias': $('#txtFTotalDeficiencias').val(),
                                    'FTotalApreciaciones': $('#txtFTotalApreciaciones').val(),
                                    'FTotalObservaciones': $('#txtFTotalObservaciones').val(),
                                    'FTotalIrregularidades': $('#txtFTotalIrregularidades').val(),
                                    'FTotalDeficienciaSuperadas': $('#txtFTotalDeficienciaSuperadas').val(),
                                    'FTotalApreciacionSuperadas': $('#txtFTotalApreciacionSuperadas').val(),
                                    'FTotalObservacionSuperadas': $('#txtFTotalObservacionSuperadas').val(),
                                    'FTotalIrregularidadSuperadas': $('#txtFTotalIrregularidadSuperadas').val(),
                                    'FTotalDeficienciasPendientes': $('#txtFTotalDeficienciasPendientes').val(),
                                    'FTotalApreciacionesPendientes': $('#txtFTotalApreciacionesPendientes').val(),
                                    'FTotalObservacionPendientes': $('#txtFTotalObservacionPendientes').val(),
                                    'FTotalIrregularidadPendientes': $('#txtFTotalIrregularidadPendientes').val(), 
                                    'CargaId': $('#cargasR').val()
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
                                    $('#tblIpecamarInspeccionInstitucionales').DataTable().ajax.reload();
                                    $('.needs-validation :input').val('');
                                    $(".needs-validation").find("select").prop("selectedIndex", 0);
                                    form.classList.remove('was-validated')
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
                                url: '/IpecamarInspeccionInstitucionales/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaInicioInspeccion': $('#cbFechFechaInicioInspe').val(),
                                    'FechaTerminoInspeccion': $('#txtFechaTerminoInspe').val(),
                                    'DuracionInspeccion': $('#txtDuracionInspeccione').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDependenciae').val(),
                                    'CodigoNivelDependencia': $('#cbNivelDependenciae').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoInspeccionConocimiento': $('#cbInspeccionConocimientoe').val(),
                                    'CodigoInspeccionExtension': $('#cbInspeccionExtensione').val(),
                                    'CodigoInspeccionFinalidad': $('#cbInspeccionFinalidade').val(),
                                    'CodigoOrganoControlInspeccion': $('#cbOrganoControlInspeccione').val(),
                                    'QInspectorParticipante': $('#txtQInspectorParticipantee').val(),
                                    'DeficienciaOperAdm': $('#txtDeficienciaOperAdme').val(),
                                    'DeficienciaComunesOperAdm': $('#txtDeficienciaComunesOperAdme').val(),
                                    'ApreciacionOperAdm': $('#txtApreciacionOperAdme').val(),
                                    'ObservacionOperAdm': $('#txtObservacionOperAdme').val(),
                                    'IrregularidadOperAdm': $('#txtIrregularidadOperAdme').val(),
                                    'DeficienciaControlGestion': $('#txtDeficienciaControlGestione').val(),
                                    'DeficienciaComunControlG': $('#txtDeficienciaComunControlGe').val(),
                                    'ApreciacionControlGestion': $('#txtApreciacionControlGestione').val(),
                                    'ObservacionControlGestion': $('#txtObservacionControlGestione').val(),
                                    'IrregularidadControlGestion': $('#txtIrregularidadControlGestione').val(),
                                    'DeficienciaPendOperAdm': $('#txtDeficienciaPendOperAdme').val(),
                                    'DeficienciaComunPendOperAdm': $('#txtDeficienciaComunPendOperAdme').val(),
                                    'ApreciacionPendOperAdm': $('#txtApreciacionPendOperAdme').val(),
                                    'ObservacionPendOperAdm': $('#txtObservacionPendOperAdme').val(),
                                    'IrregularidadPendOperAdm': $('#txtIrregularidadPendOperAdme').val(),
                                    'DeficienciaPendControlGestion': $('#txtDeficienciaPendControlGestione').val(),
                                    'DeficienciaComunPendControlGestion': $('#txtDeficienciaComunPendControlGestione').val(),
                                    'ApreciacionPendControlGestion': $('#txtApreciacionPendControlGestione').val(),
                                    'ObservacionPendControlGestion': $('#txtObservacionPendControlGestione').val(),
                                    'IrregularidadPendControlGestion': $('#txtIrregularidadPendControlGestione').val(),
                                    'DeficienciaSuperadaOperAdm': $('#txtDeficienciaSuperadaOperAdme').val(),
                                    'DeficienciaComunSuperadaOperAdm': $('#txtDeficienciaComunSuperadaOperAdme').val(),
                                    'ApreciacionSuperadaOperAdm': $('#txtApreciacionSuperadaOperAdme').val(),
                                    'ObservacionSuperadaOperAdm': $('#txtObservacionSuperadaOperAdme').val(),
                                    'IrregularidadSuperadaOperAdm': $('#txtIrregularidadSuperadaOperAdme').val(),
                                    'DeficienciaSuperadaControlGestion': $('#txtDeficienciaSuperadaControlGestione').val(),
                                    'DeficienciaComunSuperadaControlGestion': $('#txtDeficienciaComunSuperadaControlGestione').val(),
                                    'ApreciacionSuperadaControlGestion': $('#txtApreciacionSuperadaControlGestione').val(),
                                    'ObservacionSuperadaControlGestion': $('#txtObservacionSuperadaControlGestione').val(),
                                    'IrregularidadSuperadaControlGestion': $('#txtIrregularidadSuperadaControlGestione').val(),
                                    'FTotalDeficiencias': $('#txtFTotalDeficienciase').val(),
                                    'FTotalApreciaciones': $('#txtFTotalApreciacionese').val(),
                                    'FTotalObservaciones': $('#txtFTotalObservacionese').val(),
                                    'FTotalIrregularidades': $('#txtFTotalIrregularidadese').val(),
                                    'FTotalDeficienciaSuperadas': $('#txtFTotalDeficienciaSuperadase').val(),
                                    'FTotalApreciacionSuperadas': $('#txtFTotalApreciacionSuperadase').val(),
                                    'FTotalObservacionSuperadas': $('#txtFTotalObservacionSuperadase').val(),
                                    'FTotalIrregularidadSuperadas': $('#txtFTotalIrregularidadSuperadase').val(),
                                    'FTotalDeficienciasPendientes': $('#txtFTotalDeficienciasPendientese').val(),
                                    'FTotalApreciacionesPendientes': $('#txtFTotalApreciacionesPendientese').val(),
                                    'FTotalObservacionPendientes': $('#txtFTotalObservacionPendientese').val(),
                                    'FTotalIrregularidadPendientes': $('#txtFTotalIrregularidadPendientese').val(),
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
                                    $('#tblIpecamarInspeccionInstitucionales').DataTable().ajax.reload();
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

    tblIpecamarInspeccionInstitucionales = $('#tblIpecamarInspeccionInstitucionales').DataTable({
        ajax: {
            "url": '/IpecamarInspeccionInstitucionales/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "inspeccionInstitucionalId" },
            { "data": "fechaInicioInspeccion" },
            { "data": "fechaTerminoInspeccion" },
            { "data": "duracionInspeccion" },
            { "data": "nombreDependencia" },
            { "data": "descComandanciaDependencia" },
            { "data": "descNivelDependencia" },
            { "data": "descZonaNaval" },
            { "data": "descInspeccionConocimiento" },
            { "data": "descInspeccionExtension" },
            { "data": "descInspeccionFinalidad" },
            { "data": "descOrganoControlInspeccion" },
            { "data": "qinspectorParticipante" },
            { "data": "deficienciaOperAdm" },
            { "data": "deficienciaComunesOperAdm" },
            { "data": "apreciacionOperAdm" },
            { "data": "observacionOperAdm" },
            { "data": "irregularidadOperAdm" },
            { "data": "deficienciaControlGestion" },
            { "data": "deficienciaComunControlG" },
            { "data": "apreciacionControlGestion" },
            { "data": "observacionControlGestion" },
            { "data": "irregularidadControlGestion" },
            { "data": "deficienciaPendOperAdm" },
            { "data": "deficienciaComunPendOperAdm" },
            { "data": "apreciacionPendOperAdm" },
            { "data": "observacionPendOperAdm" },
            { "data": "irregularidadPendOperAdm" },
            { "data": "deficienciaPendControlGestion" },
            { "data": "deficienciaComunPendControlGestion" },
            { "data": "apreciacionPendControlGestion" },
            { "data": "observacionPendControlGestion" },
            { "data": "irregularidadPendControlGestion" },
            { "data": "deficienciaSuperadaOperAdm" },
            { "data": "deficienciaComunSuperadaOperAdm" },
            { "data": "apreciacionSuperadaOperAdm" },
            { "data": "observacionSuperadaOperAdm" },
            { "data": "irregularidadSuperadaOperAdm" },
            { "data": "deficienciaSuperadaControlGestion" },
            { "data": "deficienciaComunSuperadaControlGestion" },
            { "data": "apreciacionSuperadaControlGestion" },
            { "data": "observacionSuperadaControlGestion" },
            { "data": "irregularidadSuperadaControlGestion" },
            { "data": "ftotalDeficiencias" },
            { "data": "ftotalApreciaciones" },
            { "data": "ftotalObservaciones" },
            { "data": "ftotalIrregularidades" },
            { "data": "ftotalDeficienciaSuperadas" },
            { "data": "ftotalApreciacionSuperadas" },
            { "data": "ftotalObservacionSuperadas" },
            { "data": "ftotalIrregularidadSuperadas" },
            { "data": "ftotalDeficienciasPendientes" },
            { "data": "ftotalApreciacionesPendientes" },
            { "data": "ftotalObservacionPendientes" },
            { "data": "ftotalIrregularidadPendientes" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.inspeccionInstitucionalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.inspeccionInstitucionalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Ipecamar - Inspecciones Institucionales, Supervisión y Seguimiento',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Ipecamar - Inspecciones Institucionales, Supervisión y Seguimiento',
                title: 'Ipecamar - Inspecciones Institucionales, Supervisión y Seguimiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Ipecamar - Inspecciones Institucionales, Supervisión y Seguimiento',
                title: 'Ipecamar - Inspecciones Institucionales, Supervisión y Seguimiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Ipecamar - Inspecciones Institucionales, Supervisión y Seguimiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54]
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
    cargaBusqueda();
});

$('#btn_search').click(function () {
    cargaBusqueda();
});


$('#btn_all').click(function () {
    mostrarTodos();
});


function cargaBusqueda() {
    var CodigoCarga = $('#cargas').val();
    tblIpecamarInspeccionInstitucionales.columns(55).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblIpecamarInspeccionInstitucionales.columns(55).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/IpecamarInspeccionInstitucionales/Mostrar?Id=' + Id, [], function (InspeccionInstitucionalesDTO) {
        $('#txtCodigo').val(InspeccionInstitucionalesDTO.inspeccionInstitucionalId);
        $('#cbFechFechaInicioInspe').val(InspeccionInstitucionalesDTO.fechaInicioInspeccion);
        $('#txtFechaTerminoInspe').val(InspeccionInstitucionalesDTO.fechaTerminoInspeccion);
        $('#txtDuracionInspeccione').val(InspeccionInstitucionalesDTO.duracionInspeccion);
        $('#cbDependenciae').val(InspeccionInstitucionalesDTO.codigoDependencia);
        $('#cbComandanciaDependenciae').val(InspeccionInstitucionalesDTO.codigoComandanciaDependencia);
        $('#cbNivelDependenciae').val(InspeccionInstitucionalesDTO.codigoNivelDependencia);
        $('#cbZonaNavale').val(InspeccionInstitucionalesDTO.codigoZonaNaval);
        $('#cbInspeccionConocimientoe').val(InspeccionInstitucionalesDTO.codigoInspeccionConocimiento);
        $('#cbInspeccionExtensione').val(InspeccionInstitucionalesDTO.codigoInspeccionExtension);
        $('#cbInspeccionFinalidade').val(InspeccionInstitucionalesDTO.codigoInspeccionFinalidad);
        $('#cbOrganoControlInspeccione').val(InspeccionInstitucionalesDTO.codigoOrganoControlInspeccion);
        $('#txtQInspectorParticipantee').val(InspeccionInstitucionalesDTO.qinspectorParticipante);
        $('#txtDeficienciaOperAdme').val(InspeccionInstitucionalesDTO.deficienciaOperAdm);
        $('#txtDeficienciaComunesOperAdme').val(InspeccionInstitucionalesDTO.deficienciaComunesOperAdm);
        $('#txtApreciacionOperAdme').val(InspeccionInstitucionalesDTO.apreciacionOperAdm);
        $('#txtObservacionOperAdme').val(InspeccionInstitucionalesDTO.observacionOperAdm);
        $('#txtIrregularidadOperAdme').val(InspeccionInstitucionalesDTO.irregularidadOperAdm);
        $('#txtDeficienciaControlGestione').val(InspeccionInstitucionalesDTO.deficienciaControlGestion);
        $('#txtDeficienciaComunControlGe').val(InspeccionInstitucionalesDTO.deficienciaComunControlG);
        $('#txtApreciacionControlGestione').val(InspeccionInstitucionalesDTO.apreciacionControlGestion);
        $('#txtObservacionControlGestione').val(InspeccionInstitucionalesDTO.observacionControlGestion);
        $('#txtIrregularidadControlGestione').val(InspeccionInstitucionalesDTO.irregularidadControlGestion);
        $('#txtDeficienciaPendOperAdme').val(InspeccionInstitucionalesDTO.deficienciaPendOperAdm);
        $('#txtDeficienciaComunPendOperAdme').val(InspeccionInstitucionalesDTO.deficienciaComunPendOperAdm);
        $('#txtApreciacionPendOperAdme').val(InspeccionInstitucionalesDTO.apreciacionPendOperAdm);
        $('#txtObservacionPendOperAdme').val(InspeccionInstitucionalesDTO.observacionPendOperAdm);
        $('#txtIrregularidadPendOperAdme').val(InspeccionInstitucionalesDTO.irregularidadPendOperAdm);
        $('#txtDeficienciaPendControlGestione').val(InspeccionInstitucionalesDTO.deficienciaPendControlGestion);
        $('#txtDeficienciaComunPendControlGestione').val(InspeccionInstitucionalesDTO.deficienciaComunPendControlGestion);
        $('#txtApreciacionPendControlGestione').val(InspeccionInstitucionalesDTO.apreciacionPendControlGestion);
        $('#txtObservacionPendControlGestione').val(InspeccionInstitucionalesDTO.observacionPendControlGestion);
        $('#txtIrregularidadPendControlGestione').val(InspeccionInstitucionalesDTO.irregularidadPendControlGestion);
        $('#txtDeficienciaSuperadaOperAdme').val(InspeccionInstitucionalesDTO.deficienciaSuperadaOperAdm);
        $('#txtDeficienciaComunSuperadaOperAdme').val(InspeccionInstitucionalesDTO.deficienciaComunSuperadaOperAdm);
        $('#txtApreciacionSuperadaOperAdme').val(InspeccionInstitucionalesDTO.apreciacionSuperadaOperAdm);
        $('#txtObservacionSuperadaOperAdme').val(InspeccionInstitucionalesDTO.observacionSuperadaOperAdm);
        $('#txtIrregularidadSuperadaOperAdme').val(InspeccionInstitucionalesDTO.irregularidadSuperadaOperAdm);
        $('#txtDeficienciaSuperadaControlGestione').val(InspeccionInstitucionalesDTO.deficienciaSuperadaControlGestion);
        $('#txtDeficienciaComunSuperadaControlGestione').val(InspeccionInstitucionalesDTO.deficienciaComunSuperadaControlGestion);
        $('#txtApreciacionSuperadaControlGestione').val(InspeccionInstitucionalesDTO.apreciacionSuperadaControlGestion);
        $('#txtObservacionSuperadaControlGestione').val(InspeccionInstitucionalesDTO.observacionSuperadaControlGestion);
        $('#txtIrregularidadSuperadaControlGestione').val(InspeccionInstitucionalesDTO.irregularidadSuperadaControlGestion);
        $('#txtFTotalDeficienciase').val(InspeccionInstitucionalesDTO.ftotalDeficiencias);
        $('#txtFTotalApreciacionese').val(InspeccionInstitucionalesDTO.ftotalApreciaciones);
        $('#txtFTotalObservacionese').val(InspeccionInstitucionalesDTO.ftotalObservaciones);
        $('#txtFTotalIrregularidadese').val(InspeccionInstitucionalesDTO.ftotalIrregularidades);
        $('#txtFTotalDeficienciaSuperadase').val(InspeccionInstitucionalesDTO.ftotalDeficienciaSuperadas);
        $('#txtFTotalApreciacionSuperadase').val(InspeccionInstitucionalesDTO.ftotalApreciacionSuperadas);
        $('#txtFTotalObservacionSuperadase').val(InspeccionInstitucionalesDTO.ftotalObservacionSuperadas);
        $('#txtFTotalIrregularidadSuperadase').val(InspeccionInstitucionalesDTO.ftotalIrregularidadSuperadas);
        $('#txtFTotalDeficienciasPendientese').val(InspeccionInstitucionalesDTO.ftotalDeficienciasPendientes);
        $('#txtFTotalApreciacionesPendientese').val(InspeccionInstitucionalesDTO.ftotalApreciacionesPendientes);
        $('#txtFTotalObservacionPendientese').val(InspeccionInstitucionalesDTO.ftotalObservacionPendientes);
        $('#txtFTotalIrregularidadPendientese').val(InspeccionInstitucionalesDTO.ftotalIrregularidadPendientes); 
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
                url: '/IpecamarInspeccionInstitucionales/Eliminar',
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
                    $('#tblIpecamarInspeccionInstitucionales').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaIpecamarInspeccionInstitucionales() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'IpecamarInspeccionInstitucionales/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            console.log(dataJson);
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.fechaInicioInspeccion),
                            $("<td>").text(item.fechaTerminoInspeccion),
                            $("<td>").text(item.duracionInspeccion),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoComandanciaDependencia),
                            $("<td>").text(item.codigoNivelDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoInspeccionConocimiento),
                            $("<td>").text(item.codigoInspeccionExtension),
                            $("<td>").text(item.codigoInspeccionFinalidad),
                            $("<td>").text(item.codigoOrganoControlInspeccion),
                            $("<td>").text(item.qinspectorParticipante),
                            $("<td>").text(item.deficienciaOperAdm),
                            $("<td>").text(item.deficienciaComunesOperAdm),
                            $("<td>").text(item.apreciacionOperAdm),
                            $("<td>").text(item.observacionOperAdm),
                            $("<td>").text(item.irregularidadOperAdm),
                            $("<td>").text(item.deficienciaControlGestion),
                            $("<td>").text(item.deficienciaComunControlG),
                            $("<td>").text(item.apreciacionControlGestion),
                            $("<td>").text(item.observacionControlGestion),
                            $("<td>").text(item.irregularidadControlGestion),
                            $("<td>").text(item.deficienciaPendOperAdm),
                            $("<td>").text(item.deficienciaComunPendOperAdm),
                            $("<td>").text(item.apreciacionPendOperAdm),
                            $("<td>").text(item.observacionPendOperAdm),
                            $("<td>").text(item.irregularidadPendOperAdm),
                            $("<td>").text(item.deficienciaPendControlGestion),
                            $("<td>").text(item.deficienciaComunPendControlGestion),
                            $("<td>").text(item.apreciacionPendControlGestion),
                            $("<td>").text(item.observacionPendControlGestion),
                            $("<td>").text(item.irregularidadPendControlGestion),
                            $("<td>").text(item.deficienciaSuperadaOperAdm),
                            $("<td>").text(item.deficienciaComunSuperadaOperAdm),
                            $("<td>").text(item.apreciacionSuperadaOperAdm),
                            $("<td>").text(item.observacionSuperadaOperAdm),
                            $("<td>").text(item.irregularidadSuperadaOperAdm),
                            $("<td>").text(item.deficienciaSuperadaControlGestion),
                            $("<td>").text(item.deficienciaComunSuperadaControlGestion),
                            $("<td>").text(item.apreciacionSuperadaControlGestion),
                            $("<td>").text(item.observacionSuperadaControlGestion),
                            $("<td>").text(item.irregularidadSuperadaControlGestion),
                            $("<td>").text(item.ftotalDeficiencias),
                            $("<td>").text(item.ftotalApreciaciones),
                            $("<td>").text(item.ftotalObservaciones),
                            $("<td>").text(item.ftotalIrregularidades),
                            $("<td>").text(item.ftotalDeficienciaSuperadas),
                            $("<td>").text(item.ftotalApreciacionSuperadas),
                            $("<td>").text(item.ftotalObservacionSuperadas),
                            $("<td>").text(item.ftotalIrregularidadSuperadas),
                            $("<td>").text(item.ftotalDeficienciasPendientes),
                            $("<td>").text(item.ftotalApreciacionesPendientes),
                            $("<td>").text(item.ftotalObservacionPendientes),
                            $("<td>").text(item.ftotalIrregularidadPendientes)
                        )
                    )
                })
                Swal.fire(
                    'Cargado!',
                    'Vista previa con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema.',
                    'error'
                )
            }
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("IpecamarInspeccionInstitucionales/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((mensaje) => {
            if (mensaje == "1") {
                Swal.fire(
                    'Cargado!',
                    'Se Cargo el archivo con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema.',
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/IpecamarInspeccionInstitucionales/cargaCombs', [], function (Json) {
        var dependencia   = Json["data1"];
        var comandanciaDependencia = Json["data2"];
        var nivelDependencia = Json["data3"];
        var zonaNaval = Json["data4"];
        var inspeccionConocimiento= Json["data5"];
        var inspeccionExtension = Json["data6"];
        var inspeccionFinalidad = Json["data7"];
        var organoControlInspeccion = Json["data8"];
        var listaCargas = Json["data9"];

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbComandanciaDependencia").html("");
        $.each(comandanciaDependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDependencia").append(RowContent);
        });
        $("select#cbComandanciaDependenciae").html("");
        $.each(comandanciaDependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDependenciae").append(RowContent);
        });


        $("select#cbCartegoriaPersonal").html("");
        $.each(nivelDependencia, function () {
            var RowContent = '<option value=' + this.codigoNivelDependencia + '>' + this.descNivelDependencia + '</option>'
            $("select#cbCartegoriaPersonal").append(RowContent);
        });
        $("select#cbCartegoriaPersonale").html("");
        $.each(nivelDependencia, function () {
            var RowContent = '<option value=' + this.codigoNivelDependencia + '>' + this.descNivelDependencia + '</option>'
            $("select#cbCartegoriaPersonale").append(RowContent);
        });


        $("select#cbZonanaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanaval").append(RowContent);
        });
        $("select#cbZonanavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanavale").append(RowContent);
        });


        $("select#cbInspeccionConocimiento").html("");
        $.each(inspeccionConocimiento, function () {
            var RowContent = '<option value=' + this.CodigoInspeccionConocimiento + '>' + this.descZonaNaval + '</option>'
            $("select#cbInspeccionConocimiento").append(RowContent);
        });
        $("select#cbInspeccionConocimientoe").html("");
        $.each(inspeccionConocimiento, function () {
            var RowContent = '<option value=' + this.CodigoInspeccionConocimiento + '>' + this.descZonaNaval + '</option>'
            $("select#cbInspeccionConocimientoe").append(RowContent);
        });

        $("select#cbInspeccionExtension").html("");
        $.each(inspeccionExtension, function () {
            var RowContent = '<option value=' + this.CodigoInspeccionExtension + '>' + this.descZonaNaval + '</option>'
            $("select#cbInspeccionExtension").append(RowContent);
        });
        $("select#cbInspeccionExtensione").html("");
        $.each(inspeccionExtension, function () {
            var RowContent = '<option value=' + this.CodigoInspeccionExtension + '>' + this.descZonaNaval + '</option>'
            $("select#cbInspeccionExtensione").append(RowContent);
        });


        $("select#cbInspeccionFinalidad").html("");
        $.each(inspeccionFinalidad, function () {
            var RowContent = '<option value=' + this.CodigoInspeccionFinalidad + '>' + this.descZonaNaval + '</option>'
            $("select#cbInspeccionFinalidad").append(RowContent);
        });
        $("select#cbInspeccionFinalidade").html("");
        $.each(inspeccionFinalidad, function () {
            var RowContent = '<option value=' + this.CodigoInspeccionFinalidad + '>' + this.descZonaNaval + '</option>'
            $("select#cbInspeccionFinalidade").append(RowContent);
        });


        $("select#cbOrganoControlInspeccion").html("");
        $.each(organoControlInspeccion, function () {
            var RowContent = '<option value=' + this.CodigoOrganoControlInspeccion + '>' + this.descZonaNaval + '</option>'
            $("select#cbOrganoControlInspeccion").append(RowContent);
        });
        $("select#cbOrganoControlInspeccione").html("");
        $.each(organoControlInspeccion, function () {
            var RowContent = '<option value=' + this.CodigoOrganoControlInspeccion + '>' + this.descZonaNaval + '</option>'
            $("select#cbOrganoControlInspeccione").append(RowContent);
        });


        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    });
}

