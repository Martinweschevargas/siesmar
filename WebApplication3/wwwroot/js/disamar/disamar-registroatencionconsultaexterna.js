var tblDisamarRegistroAtencionConsultaExterna;
var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

$('select#cbProvinciaUbigeo').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoUbigeo').append('<option selected disabled>Seleccionar Distrito</option>');

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
                                url: '/DisamarRegistroAtencionConsultaExterna/Insertar',
                                data: {
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitar').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoEstablecimientoSaludMGP': $('#cbEstablecimientoSaludMGP').val(),
                                    'FechaRegistro': $('#txtFechaRegistro').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeo').val(),
                                    'CodigoUPSMedicaNoMedica': $('#cbEspecialidadMedicaNoMedica').val(),
                                    'ResponsableAtencionMedica': $('#txtResponsableAtencionMedica').val(),
                                    'NSACIP': $('#txtNSACIP').val(),
                                    'NumeroCMP': $('#txtNumeroCMP').val(),
                                    'Turno': $('#txtTurno').val(),
                                    'HoraInicio': $('#txtHoraInicio').val(),
                                    'HoraTermino': $('#txtHoraTermino').val(),
                                    'HistoriaClinica': $('#txtHistoriaClinica').val(),
                                    'DNIPaciente': $('#txtDNIPaciente').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadDependencia').val(),
                                    'DistritoPaciente': $('#txtDistritoPaciente').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'SituacionPaciente': $('#txtSituacionPaciente').val(),
                                    'CondicionPaciente': $('#cbCondicionPaciente').val(),
                                    'EdadPaciente': $('#cbEdadPaciente').val(),
                                    'TipoEdad': $('#cbTipoEdad').val(),
                                    'SexoPaciente': $('#cbSexoPaciente').val(),
                                    'AlEstablecimiento': $('#cbAlEstablecimiento').val(),
                                    'AlServicio': $('#txtAlServicio').val(),
                                    'CodigoDiagnosticoMotivoAtencion1': $('#txtDiagnosticoMotivoAtencion1').val(),
                                    'TipoDX1': $('#txtTipoDX1').val(),
                                    'Lab1': $('#txtLab1').val(),
                                    'CodigoCIE10_1': $('#txtCIE10_1').val(),
                                    'CodigoDiagnosticoMotivoAtencion2': $('#txtDiagnosticoMotivoAtencion2').val(),
                                    'TipoDX2': $('#txtTipoDX2').val(),
                                    'Lab2': $('#txtLab2').val(),
                                    'CodigoCIE10_2': $('#txtCIE10_2').val(),
                                    'CodigoDiagnosticoMotivoAtencion3': $('#txtDiagnosticoMotivoAtencion3').val(),
                                    'TipoDX3': $('#txtTipoDX3').val(),
                                    'Lab3': $('#txtLab3').val(),
                                    'CodigoCIE10_3': $('#txtCIE10_3').val(),
                                    'CodigoDiagnosticoMotivoAtencion4': $('#txtDiagnosticoMotivoAtencion4').val(),
                                    'TipoDX4': $('#txtTipoDX4').val(),
                                    'Lab4': $('#txtLab4').val(),
                                    'CodigoCIE10_4': $('#txtCIE10_4').val(),
                                    'CodigoDiagnosticoMotivoAtencion5': $('#txtDiagnosticoMotivoAtencion5').val(),
                                    'TipoDX5': $('#txtTipoDX5').val(),
                                    'Lab5': $('#txtLab5').val(),
                                    'CodigoCIE10_5': $('#txtCIE10_5').val(),
                                    'CodigoDiagnosticoMotivoAtencion6': $('#txtDiagnosticoMotivoAtencion6').val(),
                                    'TipoDX6': $('#txtTipoDX6').val(),
                                    'Lab6': $('#txtLab6').val(),
                                    'CodigoCIE10_6': $('#txtCIE10_6').val(),
                                    'Interconsulta': $('#txtInterconsulta').val(),
                                    'CodigoUPSEspecialidadInterconsulta': $('#txtEspecialidadMedicaInterconsulta').val(),
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
                                    $('#tblDisamarRegistroAtencionConsultaExterna').DataTable().ajax.reload();
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
                                url: '/DisamarRegistroAtencionConsultaExterna/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitare').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoEstablecimientoSaludMGP': $('#cbEstablecimientoSaludMGPe').val(),
                                    'FechaRegistro': $('#txtFechaRegistroe').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeoe').val(),
                                    'CodigoUPSMedicaNoMedica': $('#cbEspecialidadMedicaNoMedicae').val(),
                                    'ResponsableAtencionMedica': $('#txtResponsableAtencionMedicae').val(),
                                    'NSACIP': $('#txtNSACIPe').val(),
                                    'NumeroCMP': $('#txtNumeroCMPe').val(),
                                    'Turno': $('#txtTurnoe').val(),
                                    'HoraInicio': $('#txtHoraInicioe').val(),
                                    'HoraTermino': $('#txtHoraTerminoe').val(),
                                    'HistoriaClinica': $('#txtHistoriaClinicae').val(),
                                    'DNIPaciente': $('#txtDNIPacientee').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadDependenciae').val(),
                                    'DistritoPaciente': $('#txtDistritoPacientee').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'SituacionPaciente': $('#txtSituacionPacientee').val(),
                                    'CondicionPaciente': $('#cbCondicionPacientee').val(),
                                    'EdadPaciente': $('#cbEdadPacientee').val(),
                                    'TipoEdad': $('#cbTipoEdade').val(),
                                    'SexoPaciente': $('#cbSexoPacientee').val(),
                                    'AlEstablecimiento': $('#cbAlEstablecimientoe').val(),
                                    'AlServicio': $('#txtAlServicioe').val(),
                                    'CodigoDiagnosticoMotivoAtencion1': $('#txtDiagnosticoMotivoAtencion1e').val(),
                                    'TipoDX1': $('#txtTipoDX1e').val(),
                                    'Lab1': $('#txtLab1e').val(),
                                    'CodigoCIE10_1': $('#txtCIE10_1e').val(),
                                    'CodigoDiagnosticoMotivoAtencion2': $('#txtDiagnosticoMotivoAtencion2e').val(),
                                    'TipoDX2': $('#txtTipoDX2e').val(),
                                    'Lab2': $('#txtLab2e').val(),
                                    'CodigoCIE10_2': $('#txtCIE10_2e').val(),
                                    'CodigoDiagnosticoMotivoAtencion3': $('#txtDiagnosticoMotivoAtencion3e').val(),
                                    'TipoDX3': $('#txtTipoDX3e').val(),
                                    'Lab3': $('#txtLab3e').val(),
                                    'CodigoCIE10_3': $('#txtCIE10_3e').val(),
                                    'CodigoDiagnosticoMotivoAtencion4': $('#txtDiagnosticoMotivoAtencion4e').val(),
                                    'TipoDX4': $('#txtTipoDX4e').val(),
                                    'Lab4': $('#txtLab4e').val(),
                                    'CodigoCIE10_4': $('#txtCIE10_4e').val(),
                                    'CodigoDiagnosticoMotivoAtencion5': $('#txtDiagnosticoMotivoAtencion5e').val(),
                                    'TipoDX5': $('#txtTipoDX5e').val(),
                                    'Lab5': $('#txtLab5e').val(),
                                    'CodigoCIE10_5': $('#txtCIE10_5e').val(),
                                    'CodigoDiagnosticoMotivoAtencion6': $('#txtDiagnosticoMotivoAtencion6e').val(),
                                    'TipoDX6': $('#txtTipoDX6e').val(),
                                    'Lab6': $('#txtLab6e').val(),
                                    'CodigoCIE10_6': $('#txtCIE10_6e').val(),
                                    'Interconsulta': $('#txtInterconsultae').val(),
                                    'CodigoUPSEspecialidadInterconsulta': $('#txtEspecialidadMedicaInterconsultae').val(),
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
                                    $('#tblDisamarRegistroAtencionConsultaExterna').DataTable().ajax.reload();
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

  tblDisamarRegistroAtencionConsultaExterna =  $('#tblDisamarRegistroAtencionConsultaExterna').DataTable({
        ajax: {
            "url": '/DisamarRegistroAtencionConsultaExterna/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroAtencionConsultaExternaId" },
            { "data": "descEntidadMilitar" },
            { "data": "descZonaNaval" },
            { "data": "descEstablecimientoSalud" },
            { "data": "fechaRegistro" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDitrito" },
            { "data": "descEspecialidadMedicaNoMedica" },
            { "data": "responsableAtencionMedica" },
            { "data": "nsaCIP" },
            { "data": "numeroCMP" },
            { "data": "turno" },
            { "data": "horaInicio" },
            { "data": "horaTermino" },
            { "data": "historiaClinica" },
            { "data": "dniPaciente" },
            { "data": "descUnidadDependencia" },
            { "data": "descDistritoPaciente" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "situacionPaciente" },
            { "data": "condicionPaciente" },
            { "data": "edadPaciente" },
            { "data": "tipoEdad" },
            { "data": "sexoPaciente" },
            { "data": "alestablecimiento" },
            { "data": "alservicio" },
            { "data": "codigoDiagnosticoMotivoAtencion1" },
            { "data": "tipoDX1" },
            { "data": "lab1" },
            { "data": "codigoCIE10_1" },
            { "data": "codigoDiagnosticoMotivoAtencion2" },
            { "data": "tipoDX2" },
            { "data": "lab2" },
            { "data": "codigoCIE10_2" },
            { "data": "codigoDiagnosticoMotivoAtencion3" },
            { "data": "tipoDX3" },
            { "data": "lab3" },
            { "data": "codigoCIE10_3" },
            { "data": "codigoDiagnosticoMotivoAtencion4" },
            { "data": "tipoDX4" },
            { "data": "lab4" },
            { "data": "codigoCIE10_4" },
            { "data": "codigoDiagnosticoMotivoAtencion5" },
            { "data": "tipoDX5" },
            { "data": "lab5" },
            { "data": "codigoCIE10_5" },
            { "data": "codigoDiagnosticoMotivoAtencion6" },
            { "data": "tipoDX6" },
            { "data": "lab6" },
            { "data": "codigoCIE10_6" },
            { "data": "interconsulta" },
            { "data": "codigoUPSEspecialidadInterconsulta" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroAtencionConsultaExternaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroAtencionConsultaExternaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Disamar - Registro de Atenciones en Consulta Externa',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Disamar - Registro de Atenciones en Consulta Externa',
                title: 'Disamar - Registro de Atenciones en Consulta Externa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Disamar - Registro de Atenciones en Consulta Externa',
                title: 'Disamar - Registro de Atenciones en Consulta Externa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Disamar - Registro de Atenciones en Consulta Externa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53]
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
    tblDisamarRegistroAtencionConsultaExterna.columns(53).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDisamarRegistroAtencionConsultaExterna.columns(53).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DisamarRegistroAtencionConsultaExterna/Mostrar?Id=' + Id, [], function (RegistroAtencionConsultaExterna) {
        $('#txtCodigo').val(RegistroAtencionConsultaExterna.registroAtencionConsultaExternaId);
        $('#cbEntidadMilitare').val(RegistroAtencionConsultaExternaDTO.codigoEntidadMilitar);
        $('#cbZonaNavale').val(RegistroAtencionConsultaExternaDTO.codigoZonaNaval);
        $('#cbEstablecimientoSaludMGPe').val(RegistroAtencionConsultaExternaDTO.codigoEstablecimientoSaludMGP);
        $('#txtFechaRegistroe').val(RegistroAtencionConsultaExternaDTO.fechaRegistro);
        var iddistrito = RegistroAtencionConsultaExternaDTO.distritoUbigeo;
        $('#cbEspecialidadMedicaNoMedicae').val(RegistroAtencionConsultaExternaDTO.codigoUPSMedicaNoMedica);
        $('#txtResponsableAtencionMedicae').val(RegistroAtencionConsultaExternaDTO.responsableAtencionMedica);
        $('#txtNSACIPe').val(RegistroAtencionConsultaExternaDTO.nsaCIP);
        $('#txtNumeroCMPe').val(RegistroAtencionConsultaExternaDTO.numeroCMP);
        $('#txtTurnoe').val(RegistroAtencionConsultaExternaDTO.turno);
        $('#txtHoraInicioe').val(RegistroAtencionConsultaExternaDTO.horaInicio);
        $('#txtHoraTerminoe').val(RegistroAtencionConsultaExternaDTO.horaTermino);
        $('#txtHistoriaClinicae').val(RegistroAtencionConsultaExternaDTO.historiaClinica);
        $('#txtDNIPacientee').val(RegistroAtencionConsultaExternaDTO.dniPaciente);
        $('#cbUnidadDependenciae').val(RegistroAtencionConsultaExternaDTO.codigoUnidadNaval);
        $('#txtDistritoPacientee').val(RegistroAtencionConsultaExternaDTO.distritoPaciente);
        $('#cbTipoPersonalMilitare').val(RegistroAtencionConsultaExternaDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMilitare').val(RegistroAtencionConsultaExternaDTO.codigoGradoPersonalMilitar);
        $('#txtSituacionPacientee').val(RegistroAtencionConsultaExternaDTO.situacionPaciente);
        $('#cbCondicionPacientee').val(RegistroAtencionConsultaExternaDTO.condicionPaciente);
        $('#cbEdadPacientee').val(RegistroAtencionConsultaExternaDTO.edadPaciente);
        $('#cbTipoEdade').val(RegistroAtencionConsultaExternaDTO.tipoEdad);
        $('#cbSexoPacientee').val(RegistroAtencionConsultaExternaDTO.sexoPaciente);
        $('#cbAlEstablecimientoe').val(RegistroAtencionConsultaExternaDTO.alestablecimiento);
        $('#txtAlServicioe').val(RegistroAtencionConsultaExternaDTO.alservicio);
        $('#txtDiagnosticoMotivoAtencion1e').val(RegistroAtencionConsultaExternaDTO.codigoDiagnosticoMotivoAtencion1);
        $('#txtTipoDX1e').val(RegistroAtencionConsultaExternaDTO.tipoDX1);
        $('#txtLab1e').val(RegistroAtencionConsultaExternaDTO.lab1);
        $('#txtCIE10_1e').val(RegistroAtencionConsultaExternaDTO.codigoCIE10_1);
        $('#txtDiagnosticoMotivoAtencion2e').val(RegistroAtencionConsultaExternaDTO.codigoDiagnosticoMotivoAtencion2);
        $('#txtTipoDX2e').val(RegistroAtencionConsultaExternaDTO.tipoDX2);
        $('#txtLab2e').val(RegistroAtencionConsultaExternaDTO.lab2);
        $('#txtCIE10_2e').val(RegistroAtencionConsultaExternaDTO.codigoCIE10_2);
        $('#txtDiagnosticoMotivoAtencion3e').val(RegistroAtencionConsultaExternaDTO.codigoDiagnosticoMotivoAtencion3);
        $('#txtTipoDX3e').val(RegistroAtencionConsultaExternaDTO.tipoDX3);
        $('#txtLab3e').val(RegistroAtencionConsultaExternaDTO.lab3);
        $('#txtCIE10_3e').val(RegistroAtencionConsultaExternaDTO.codigoCIE10_3);
        $('#txtDiagnosticoMotivoAtencion4e').val(RegistroAtencionConsultaExternaDTO.codigoDiagnosticoMotivoAtencion4);
        $('#txtTipoDX4e').val(RegistroAtencionConsultaExternaDTO.tipoDX4);
        $('#txtLab4e').val(RegistroAtencionConsultaExternaDTO.lab4);
        $('#txtCIE10_4e').val(RegistroAtencionConsultaExternaDTO.codigoCIE10_4);
        $('#txtDiagnosticoMotivoAtencion5e').val(RegistroAtencionConsultaExternaDTO.codigoDiagnosticoMotivoAtencion5);
        $('#txtTipoDX5e').val(RegistroAtencionConsultaExternaDTO.tipoDX5);
        $('#txtLab5e').val(RegistroAtencionConsultaExternaDTO.lab5);
        $('#txtCIE10_5e').val(RegistroAtencionConsultaExternaDTO.codigoCIE10_5);
        $('#txtDiagnosticoMotivoAtencion6e').val(RegistroAtencionConsultaExternaDTO.codigoDiagnosticoMotivoAtencion6);
        $('#txtTipoDX6e').val(RegistroAtencionConsultaExternaDTO.tipoDX6);
        $('#txtLab6e').val(RegistroAtencionConsultaExternaDTO.lab6);
        $('#txtCIE10_6e').val(RegistroAtencionConsultaExternaDTO.codigoCIE10_6);
        $('#txtInterconsultae').val(RegistroAtencionConsultaExternaDTO.interconsulta);
        $('#txtEspecialidadMedicaInterconsultae').val(RegistroAtencionConsultaExternaDTO.codigoUPSEspecialidadInterconsulta);

        encontrardatocombo(iddistrito);

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
                url: '/DisamarRegistroAtencionConsultaExterna/Eliminar',
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
                    $('#tblDisamarRegistroAtencionConsultaExterna').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDisamarRegistroAtencionConsultaExterna() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DisamarRegistroAtencionConsultaExterna/MostrarDatos',
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
                            $("<td>").text(item.codigoEntidadMilitar),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoEstablecimientoSaludMGP),
                            $("<td>").text(item.fechaRegistro),
                            $("<td>").text(item.distritoUbigeo),
                            $("<td>").text(item.codigoUPSMedicaNoMedica),
                            $("<td>").text(item.responsableAtencionMedica),
                            $("<td>").text(item.nsaCIP),
                            $("<td>").text(item.numeroCMP),
                            $("<td>").text(item.turno),
                            $("<td>").text(item.horaInicio),
                            $("<td>").text(item.horaTermino),
                            $("<td>").text(item.historiaClinica),
                            $("<td>").text(item.dniPaciente),
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.distritoPaciente),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.situacionPaciente),
                            $("<td>").text(item.condicionPaciente),
                            $("<td>").text(item.edadPaciente),
                            $("<td>").text(item.tipoEdad),
                            $("<td>").text(item.sexoPaciente),
                            $("<td>").text(item.alestablecimiento),
                            $("<td>").text(item.alservicio),
                            $("<td>").text(item.codigoDiagnosticoMotivoAtencion1),
                            $("<td>").text(item.tipoDX1),
                            $("<td>").text(item.lab1),
                            $("<td>").text(item.codigoCIE10_1),
                            $("<td>").text(item.codigoDiagnosticoMotivoAtencion2),
                            $("<td>").text(item.tipoDX2),
                            $("<td>").text(item.lab2),
                            $("<td>").text(item.codigoCIE10_2),
                            $("<td>").text(item.codigoDiagnosticoMotivoAtencion3),
                            $("<td>").text(item.tipoDX3),
                            $("<td>").text(item.lab3),
                            $("<td>").text(item.codigoCIE10_3),
                            $("<td>").text(item.codigoDiagnosticoMotivoAtencion4),
                            $("<td>").text(item.tipoDX4),
                            $("<td>").text(item.lab4),
                            $("<td>").text(item.codigoCIE10_4),
                            $("<td>").text(item.codigoDiagnosticoMotivoAtencion5),
                            $("<td>").text(item.tipoDX5),
                            $("<td>").text(item.lab5),
                            $("<td>").text(item.codigoCIE10_5),
                            $("<td>").text(item.codigoDiagnosticoMotivoAtencion6),
                            $("<td>").text(item.tipoDX6),
                            $("<td>").text(item.lab6),
                            $("<td>").text(item.codigoCIE10_6),
                            $("<td>").text(item.interconsulta),
                            $("<td>").text(item.codigoUPSEspecialidadInterconsulta)
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
    fetch("DisamarRegistroAtencionConsultaExterna/EnviarDatos", {
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
    $.getJSON('/DisamarRegistroAtencionConsultaExterna/cargaCombs', [], function (Json) {
        var entidadMilitar = Json["data1"];
        var zonaNaval = Json["data2"];
        var establecimientoSaludMGP = Json["data3"];
         departamentoUbigeo = Json["data4"];
         provinciaUbigeo = Json["data5"];
         distritoUbigeo = Json["data6"];
        var especialidadMedicaNoMedica = Json["data7"];
        var unidadNaval = Json["data8"];
        var tipoPersonalMilitar = Json["data9"];
        var gradoPersonalMilitar = Json["data10"];
        var listaCargas = Json["data11"];


        $("select#cbEntidadMilitar").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadMilitar").append(RowContent);
        });
        $("select#cbEntidadMilitare").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadMilitare").append(RowContent);
        });


        $("select#cbZonaNaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
        });


        $("select#cbEstablecimientoSaludMGP").html("");
        $.each(establecimientoSaludMGP, function () {
            var RowContent = '<option value=' + this.codigoEstablecimientoSaludMGP + '>' + this.descEstablecimientoSalud + '</option>'
            $("select#cbEstablecimientoSaludMGP").append(RowContent);
        });
        $("select#cbEstablecimientoSaludMGPe").html("");
        $.each(establecimientoSaludMGP, function () {
            var RowContent = '<option value=' + this.codigoEstablecimientoSaludMGP + '>' + this.descEstablecimientoSalud + '</option>'
            $("select#cbEstablecimientoSaludMGPe").append(RowContent);
        });


        $("select#cbDepartamentoUbigeo").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeo").append(RowContent);
        });




        $("select#cbEspecialidadMedicaNoMedica").html("");
        $.each(especialidadMedicaNoMedica, function () {
            var RowContent = '<option value=' + this.codigoUPSMedicaNoMedica + '>' + this.descEspecialidadMedicaNoMedica + '</option>'
            $("select#cbEspecialidadMedicaNoMedica").append(RowContent);
        });
        $("select#cbEspecialidadMedicaNoMedicae").html("");
        $.each(especialidadMedicaNoMedica, function () {
            var RowContent = '<option value=' + this.codigoUPSMedicaNoMedica + '>' + this.descEspecialidadMedicaNoMedica + '</option>'
            $("select#cbEspecialidadMedicaNoMedicae").append(RowContent);
        });


        $("select#cbUnidadDependencia").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadDependencia").append(RowContent);
        });
        $("select#cbUnidadDependenciae").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadDependenciae").append(RowContent);
        });

        $("select#txtDistritoPaciente").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#txtDistritoPaciente").append(RowContent);
        });
        $("select#txtDistritoPacientee").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#txtDistritoPacientee").append(RowContent);
        });


        $("select#cbTipoPersonalMilitar").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitar").append(RowContent);
        });
        $("select#cbTipoPersonalMilitare").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitare").append(RowContent);
        });


        $("select#cbGradoPersonalMilitar").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
        });
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitare").append(RowContent);
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



$('select#cbDepartamentoUbigeo').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaUbigeo").html("");
            $('select#cbProvinciaUbigeo').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaUbigeo").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoUbigeo").html("");
    $('select#cbDistritoUbigeo').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaUbigeo').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoUbigeo").html("");
            $('select#cbDistritoUbigeo').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoUbigeo").append(RowContent);
                }
            });
        }
    });
});


function encontrardatocombo(id) {
    var iddistrito = id;

    $.each(distritoUbigeo, function () {
        if (this.distritoUbigeo == iddistrito) {
            var provincia = this.provinciaUbigeo;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoUbigeoe").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoUbigeoe").append(RowContent);

                    });
                    $('#cbDepartamentoUbigeoe').val(departamento);
                    $("select#cbProvinciaUbigeoe").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaUbigeoe").append(RowContent);
                        }
                    });
                    $('#cbProvinciaUbigeoe').val(provincia);
                    $("select#cbDistritoUbigeoe").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoUbigeoe").append(RowContent);
                        }
                    });
                    $('#cbDistritoUbigeoe').val(iddistrito);
                }
            });


        }
    });
}
