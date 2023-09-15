var tblDisamarRegistroEgresoHospitalario;
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
                                url: '/DisamarRegistroEgresoHospitalario/Insertar',
                                data: {
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitar').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoEstablecimientoSaludMGP': $('#cbEstablecimientoSaludMGP').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeo').val(),
                                    'CodigoUPS': $('#cbEspecialidadMedicaNoMedica').val(),
                                    'ResponsableRegistro': $('#txtResponsableRegistro').val(),
                                    'NSACIP': $('#txtNSACIP').val(),
                                    'DNIResponsableSalud': $('#txtDNIResponsableSalud').val(),
                                    'HistoriaClinica': $('#txtHistoriaClinica').val(),
                                    'DNIPaciente': $('#txtDNIPaciente').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadDependencia').val(),
                                    'DistritoPaciente': $('#txtDistritoPaciente').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'SituacionPaciente': $('#txtSituacionPaciente').val(),
                                    'CondicionPaciente': $('#txtCondicionPaciente').val(),
                                    'OrigenPaciente': $('#txtOrigenPaciente').val(),
                                    'EdadPaciente': $('#txtEdadPaciente').val(),
                                    'TipoEdad': $('#txtTipoEdad').val(),
                                    'SexoPaciente': $('#txtSexoPaciente').val(),
                                    'DiagnosticoMotivoAtencion1': $('#txtDiagnosticoMotivoAtencion1').val(),
                                    'TipoDX1': $('#txtTipoDX1').val(),
                                    'CIE10_1': $('#txtCIE101').val(),
                                    'DiagnosticoMotivoAtencion2': $('#txtDiagnosticoMotivoAtencion2').val(),
                                    'TipoDX2': $('#txtTipoDX2').val(),
                                    'CIE10_2': $('#txtCIE10_2').val(),
                                    'DiagnosticoMotivoAtencion3': $('#txtDiagnosticoMotivoAtencion3').val(),
                                    'TipoDX3': $('#txtTipoDX3').val(),
                                    'CIE10_3': $('#txtCIE10_3').val(),
                                    'DiagnosticoMotivoAtencion4': $('#txtDiagnosticoMotivoAtencion4').val(),
                                    'TipoDX4': $('#txtTipoDX4').val(),
                                    'CIE10_4': $('#txtCIE10_4').val(),
                                    'DiagnosticoMotivoAtencion5': $('#txtDiagnosticoMotivoAtencion5').val(),
                                    'TipoDX5': $('#txtTipoDX5').val(),
                                    'CIE10_5': $('#txtCIE10_5').val(),
                                    'DiagnosticoMotivoAtencion6': $('#txtDiagnosticoMotivoAtencion6').val(),
                                    'TipoDX6': $('#txtTipoDX6').val(),
                                    'CIE10_6': $('#txtCIE10_6').val(),
                                    'CondicionEgresoHospitalizacionId': $('#cbCondicionEgresoHospitalizacion').val(),
                                    'FechaIngreso': $('#txtFechaIngreso').val(),
                                    'HoraIngreso': $('#txtHoraIngreso').val(),
                                    'FechaEgreso': $('#txtFechaEgreso').val(),
                                    'HoraEgreso': $('#txtHoraEgreso').val(),
                                    'EspecialidadMedicoTratanteIngreso': $('#txtEspecialidadMedicoTratanteIngreso').val(),
                                    'NombreMedicoIngreso': $('#txtNombreMedicoIngreso').val(),
                                    'DiagnosticoIngreso': $('#txtDiagnosticoIngreso').val(),
                                    'EspecialidadMedicoTratanteEgreso': $('#txtEspecialidadMedicoTratanteEgreso').val(),
                                    'NombreMedicoEgreso': $('#txtNombreMedicoEgreso').val(), 
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
                                    $('#tblDisamarRegistroEgresoHospitalario').DataTable().ajax.reload();
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
                                url: '/DisamarRegistroEgresoHospitalario/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitare').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoEstablecimientoSaludMGP': $('#cbEstablecimientoSaludMGPe').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeoe').val(),
                                    'CodigoUPS': $('#cbEspecialidadMedicaNoMedicae').val(),
                                    'ResponsableRegistro': $('#txtResponsableRegistroe').val(),
                                    'NSACIP': $('#txtNSACIPe').val(),
                                    'DNIResponsableSalud': $('#txtDNIResponsableSalude').val(),
                                    'HistoriaClinica': $('#txtHistoriaClinicae').val(),
                                    'DNIPaciente': $('#txtDNIPacientee').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadDependenciae').val(),
                                    'DistritoPaciente': $('#txtDistritoPacientee').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'SituacionPaciente': $('#txtSituacionPacientee').val(),
                                    'CondicionPaciente': $('#txtCondicionPacientee').val(),
                                    'OrigenPaciente': $('#txtOrigenPacientee').val(),
                                    'EdadPaciente': $('#txtEdadPacientee').val(),
                                    'TipoEdad': $('#txtTipoEdade').val(),
                                    'SexoPaciente': $('#txtSexoPacientee').val(),
                                    'DiagnosticoMotivoAtencion1': $('#txtDiagnosticoMotivoAtencion1e').val(),
                                    'TipoDX1': $('#txtTipoDX1e').val(),
                                    'CIE10_1': $('#txtCIE101e').val(),
                                    'DiagnosticoMotivoAtencion2': $('#txtDiagnosticoMotivoAtencion2e').val(),
                                    'TipoDX2': $('#txtTipoDX2e').val(),
                                    'CIE10_2': $('#txtCIE10_2e').val(),
                                    'DiagnosticoMotivoAtencion3': $('#txtDiagnosticoMotivoAtencion3e').val(),
                                    'TipoDX3': $('#txtTipoDX3e').val(),
                                    'CIE10_3': $('#txtCIE10_3e').val(),
                                    'DiagnosticoMotivoAtencion4': $('#txtDiagnosticoMotivoAtencion4e').val(),
                                    'TipoDX4': $('#txtTipoDX4e').val(),
                                    'CIE10_4': $('#txtCIE10_4e').val(),
                                    'DiagnosticoMotivoAtencion5': $('#txtDiagnosticoMotivoAtencion5e').val(),
                                    'TipoDX5': $('#txtTipoDX5e').val(),
                                    'CIE10_5': $('#txtCIE10_5e').val(),
                                    'DiagnosticoMotivoAtencion6': $('#txtDiagnosticoMotivoAtencion6e').val(),
                                    'TipoDX6': $('#txtTipoDX6e').val(),
                                    'CIE10_6': $('#txtCIE10_6e').val(),
                                    'CondicionEgresoHospitalizacionId': $('#cbCondicionEgresoHospitalizacione').val(),
                                    'FechaIngreso': $('#txtFechaIngresoe').val(),
                                    'HoraIngreso': $('#txtHoraIngresoe').val(),
                                    'FechaEgreso': $('#txtFechaEgresoe').val(),
                                    'HoraEgreso': $('#txtHoraEgresoe').val(),
                                    'EspecialidadMedicoTratanteIngreso': $('#txtEspecialidadMedicoTratanteIngresoe').val(),
                                    'NombreMedicoIngreso': $('#txtNombreMedicoIngresoe').val(),
                                    'DiagnosticoIngreso': $('#txtDiagnosticoIngresoe').val(),
                                    'EspecialidadMedicoTratanteEgreso': $('#txtEspecialidadMedicoTratanteEgresoe').val(),
                                    'NombreMedicoEgreso': $('#txtNombreMedicoEgresoe').val(), 
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
                                    $('#tblDisamarRegistroEgresoHospitalario').DataTable().ajax.reload();
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

   tblDisamarRegistroEgresoHospitalario = $('#tblDisamarRegistroEgresoHospitalario').DataTable({
        ajax: {
            "url": '/DisamarRegistroEgresoHospitalario/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroEgresoHospitalarioId" },
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
            { "data": "ddniPaciente" },
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
            { "data": "diagnosticoMotivoAtencion1" },
            { "data": "tipoDX1" },
            { "data": "cie10_1" },
            { "data": "diagnosticoMotivoAtencion2" },
            { "data": "tipoDX2" },
            { "data": "cie10_2" },
            { "data": "diagnosticoMotivoAtencion3" },
            { "data": "tipoDX3" },
            { "data": "cie10_3" },
            { "data": "diagnosticoMotivoAtencion4" },
            { "data": "tipoDX4" },
            { "data": "cie10_4" },
            { "data": "diagnosticoMotivoAtencion5" },
            { "data": "tipoDX5" },
            { "data": "cie10_5" },
            { "data": "diagnosticoMotivoAtencion6" },
            { "data": "tipoDX6" },
            { "data": "lab6" },
            { "data": "cie10_6" },
            { "data": "interconsulta" },
            { "data": "especialidadMedicaInterconsulta" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroEgresoHospitalarioId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroEgresoHospitalarioId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Disamar - Registro de Egresos Hospitalarios',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Disamar - Registro de Egresos Hospitalarios',
                title: 'Disamar - Registro de Egresos Hospitalarios',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Disamar - Registro de Egresos Hospitalarios',
                title: 'Disamar - Registro de Egresos Hospitalarios',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Disamar - Registro de Egresos Hospitalarios',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52, 53, 54, 55, 56]
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
    tblDisamarRegistroEgresoHospitalario.columns(57).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDisamarRegistroEgresoHospitalario.columns(57).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DisamarRegistroEgresoHospitalario/Mostrar?Id=' + Id, [], function (RegistroEgresoHospitalario) {
        $('#txtCodigo').val(RegistroEgresoHospitalario.registroEgresoHospitalarioId);
        $('#cbEntidadMilitare').val(RegistroEgresoHospitalarioDTO.codigoEntidadMilitar);
        $('#cbZonaNavale').val(RegistroEgresoHospitalarioDTO.codigoZonaNaval);
        $('#cbEstablecimientoSaludMGPe').val(RegistroEgresoHospitalarioDTO.codigoEstablecimientoSaludMGP);
        var iddistrito =RegistroEgresoHospitalarioDTO.distritoUbigeo;
        $('#cbEspecialidadMedicaNoMedicae').val(RegistroEgresoHospitalarioDTO.codigoUPS);
        $('#txtResponsableRegistroe').val(RegistroEgresoHospitalarioDTO.responsableRegistro);
        $('#txtNSACIPe').val(RegistroEgresoHospitalarioDTO.nsaCIP);
        $('#txtDNIResponsableSalude').val(RegistroEgresoHospitalarioDTO.dniResponsableSalud);
        $('#txtHistoriaClinicae').val(RegistroEgresoHospitalarioDTO.historiaClinica);
        $('#txtDNIPacientee').val(RegistroEgresoHospitalarioDTO.dniPaciente);
        $('#cbUnidadDependenciae').val(RegistroEgresoHospitalarioDTO.codigoUnidadNaval);
        $('#txtDistritoPacientee').val(RegistroEgresoHospitalarioDTO.distritoPaciente);
        $('#cbTipoPersonalMilitare').val(RegistroEgresoHospitalarioDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMilitare').val(RegistroEgresoHospitalarioDTO.codigoGradoPersonalMilitar);
        $('#txtSituacionPacientee').val(RegistroEgresoHospitalarioDTO.situacionPaciente);
        $('#txtCondicionPacientee').val(RegistroEgresoHospitalarioDTO.condicionPaciente);
        $('#txtOrigenPacientee').val(RegistroEgresoHospitalarioDTO.origenPaciente);
        $('#txtEdadPacientee').val(RegistroEgresoHospitalarioDTO.edadPaciente);
        $('#txtTipoEdade').val(RegistroEgresoHospitalarioDTO.tipoEdad);
        $('#txtSexoPacientee').val(RegistroEgresoHospitalarioDTO.sexoPaciente);
        $('#txtDiagnosticoMotivoAtencion1e').val(RegistroEgresoHospitalarioDTO.diagnosticoMotivoAtencion1);
        $('#txtTipoDX1e').val(RegistroEgresoHospitalarioDTO.tipoDX1);
        $('#txtCIE101e').val(RegistroEgresoHospitalarioDTO.cie10_1);
        $('#txtDiagnosticoMotivoAtencion2e').val(RegistroEgresoHospitalarioDTO.diagnosticoMotivoAtencion2);
        $('#txtTipoDX2e').val(RegistroEgresoHospitalarioDTO.tipoDX2);
        $('#txtCIE10_2e').val(RegistroEgresoHospitalarioDTO.cie10_2);
        $('#txtDiagnosticoMotivoAtencion3e').val(RegistroEgresoHospitalarioDTO.diagnosticoMotivoAtencion3);
        $('#txtTipoDX3e').val(RegistroEgresoHospitalarioDTO.tipoDX3);
        $('#txtCIE10_3e').val(RegistroEgresoHospitalarioDTO.cie10_3);
        $('#txtDiagnosticoMotivoAtencion4e').val(RegistroEgresoHospitalarioDTO.diagnosticoMotivoAtencion4);
        $('#txtTipoDX4e').val(RegistroEgresoHospitalarioDTO.tipoDX4);
        $('#txtCIE10_4e').val(RegistroEgresoHospitalarioDTO.cie10_4);
        $('#txtDiagnosticoMotivoAtencion5e').val(RegistroEgresoHospitalarioDTO.diagnosticoMotivoAtencion5);
        $('#txtTipoDX5e').val(RegistroEgresoHospitalarioDTO.tipoDX5);
        $('#txtCIE10_5e').val(RegistroEgresoHospitalarioDTO.cie10_5);
        $('#txtDiagnosticoMotivoAtencion6e').val(RegistroEgresoHospitalarioDTO.diagnosticoMotivoAtencion6);
        $('#txtTipoDX6e').val(RegistroEgresoHospitalarioDTO.tipoDX6);
        $('#txtCIE10_6e').val(RegistroEgresoHospitalarioDTO.cie10_6);
        $('#cbCondicionEgresoHospitalizacione').val(RegistroEgresoHospitalarioDTO.condicionEgresoHospitalizacionId);
        $('#txtFechaIngresoe').val(RegistroEgresoHospitalarioDTO.fechaIngreso);
        $('#txtHoraIngresoe').val(RegistroEgresoHospitalarioDTO.horaIngreso);
        $('#txtFechaEgresoe').val(RegistroEgresoHospitalarioDTO.fechaEgreso);
        $('#txtHoraEgresoe').val(RegistroEgresoHospitalarioDTO.horaEgreso);
        $('#txtEspecialidadMedicoTratanteIngresoe').val(RegistroEgresoHospitalarioDTO.especialidadMedicoTratanteIngreso);
        $('#txtNombreMedicoIngresoe').val(RegistroEgresoHospitalarioDTO.nombreMedicoIngreso);
        $('#txtDiagnosticoIngresoe').val(RegistroEgresoHospitalarioDTO.diagnosticoIngreso);
        $('#txtEspecialidadMedicoTratanteEgresoe').val(RegistroEgresoHospitalarioDTO.especialidadMedicoTratanteEgreso);
        $('#txtNombreMedicoEgresoe').val(RegistroEgresoHospitalarioDTO.nombreMedicoEgreso); 

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
                url: '/DisamarRegistroEgresoHospitalario/Eliminar',
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
                    $('#tblDisamarRegistroEgresoHospitalario').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDisamarRegistroEgresoHospitalario() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DisamarRegistroEgresoHospitalario/MostrarDatos',
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
                            $("<td>").text(item.distritoUbigeo),
                            $("<td>").text(item.codigoUPS),
                            $("<td>").text(item.responsableRegistro),
                            $("<td>").text(item.nsaCIP),
                            $("<td>").text(item.dniResponsableSalud),
                            $("<td>").text(item.historiaClinica),
                            $("<td>").text(item.dniPaciente),
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.distritoPaciente),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.situacionPaciente),
                            $("<td>").text(item.condicionPaciente),
                            $("<td>").text(item.origenPaciente),
                            $("<td>").text(item.edadPaciente),
                            $("<td>").text(item.tipoEdad),
                            $("<td>").text(item.sexoPaciente),
                            $("<td>").text(item.diagnosticoMotivoAtencion1),
                            $("<td>").text(item.tipoDX1),
                            $("<td>").text(item.cie10_1),
                            $("<td>").text(item.diagnosticoMotivoAtencion2),
                            $("<td>").text(item.tipoDX2),
                            $("<td>").text(item.cie10_2),
                            $("<td>").text(item.diagnosticoMotivoAtencion3),
                            $("<td>").text(item.tipoDX3),
                            $("<td>").text(item.cie10_3),
                            $("<td>").text(item.diagnosticoMotivoAtencion4),
                            $("<td>").text(item.tipoDX4),
                            $("<td>").text(item.cie10_4),
                            $("<td>").text(item.diagnosticoMotivoAtencion5),
                            $("<td>").text(item.tipoDX5),
                            $("<td>").text(item.cie10_5),
                            $("<td>").text(item.diagnosticoMotivoAtencion6),
                            $("<td>").text(item.tipoDX6),
                            $("<td>").text(item.cie10_6),
                            $("<td>").text(item.codigoCondicionEgresoHospitalizacion),
                            $("<td>").text(item.fechaIngreso),
                            $("<td>").text(item.horaIngreso),
                            $("<td>").text(item.fechaEgreso),
                            $("<td>").text(item.horaEgreso),
                            $("<td>").text(item.especialidadMedicoTratanteIngreso),
                            $("<td>").text(item.nombreMedicoIngreso),
                            $("<td>").text(item.diagnosticoIngreso),
                            $("<td>").text(item.especialidadMedicoTratanteEgreso),
                            $("<td>").text(item.nombreMedicoEgreso)
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
    fetch("DisamarRegistroEgresoHospitalario/EnviarDatos", {
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
    $.getJSON('/DisamarRegistroEgresoHospitalario/cargaCombs', [], function (Json) {
        var entidadMilitar = Json["data1"];
        var zonaNaval = Json["data2"];
        var establecimientoSaludMGP = Json["data3"];
         departamentoUbigeo = Json["data4"];
         provinciaUbigeo = Json["data5"];
        var distritoUbigeo = Json["data6"];
        var especialidadMedicaNoMedica = Json["data7"];
        var unidadDependencia = Json["data8"];
        var tipoPersonalMilitar = Json["data9"];
        var gradoPersonalMilitar = Json["data10"];
        var condicionEgresoHospitalizacion = Json["data11"];
        var listaCargas = Json["data12"];





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
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval+ '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
        });


        $("select#cbEstablecimientoSaludMGP").html("");
        $.each(establecimientoSaludMGP, function () {
            var RowContent = '<option value=' + this.codigoEstablecimientoSaludMGP + '>' + this.descEstablecimientoSalud+ '</option>'
            $("select#cbEstablecimientoSaludMGP").append(RowContent);
        });
        $("select#cbEstablecimientoSaludMGPe").html("");
        $.each(establecimientoSaludMGP, function () {
            var RowContent = '<option value=' + this.codigoEstablecimientoSaludMGP + '>' + this.descEstablecimientoSalud+ '</option>'
            $("select#cbEstablecimientoSaludMGPe").append(RowContent);
        });


        $("select#cbDepartamentoUbigeo").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDepartamento+ '</option>'
            $("select#cbDepartamentoUbigeo").append(RowContent);
        });






        $("select#cbEspecialidadMedicaNoMedica").html("");
        $.each(especialidadMedicaNoMedica, function () {
            var RowContent = '<option value=' + this.codigoUPS + '>' + this.descEspecialidadMedicaNoMedica+ '</option>'
            $("select#cbEspecialidadMedicaNoMedica").append(RowContent);
        });
        $("select#cbEspecialidadMedicaNoMedicae").html("");
        $.each(especialidadMedicaNoMedica, function () {
            var RowContent = '<option value=' + this.codigoUPS + '>' + this.descEspecialidadMedicaNoMedica+ '</option>'
            $("select#cbEspecialidadMedicaNoMedicae").append(RowContent);
        });


        $("select#cbUnidadDependencia").html("");
        $.each(unidadDependencia, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadDependencia + '</option>'
            $("select#cbUnidadDependencia").append(RowContent);
        });
        $("select#cbUnidadDependenciae").html("");
        $.each(unidadDependencia, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadDependencia + '</option>'
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


        $("select#cbCondicionEgresoHospitalizacion").html("");
        $.each(condicionEgresoHospitalizacion, function () {
            var RowContent = '<option value=' + this.condicionEgresoHospitalizacionId+ '>' + this.descCondicionEgresoHospitalizacion + '</option>'
            $("select#cbCondicionEgresoHospitalizacion").append(RowContent);
        });
        $("select#cbCondicionEgresoHospitalizacione").html("");
        $.each(condicionEgresoHospitalizacion, function () {
            var RowContent = '<option value=' + this.condicionEgresoHospitalizacionId+ '>' + this.descCondicionEgresoHospitalizacion + '</option>'
            $("select#cbCondicionEgresoHospitalizacione").append(RowContent);
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

$('select#cbDepartamentoUbigeoe').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaUbigeoe").html("");
            $('select#cbProvinciaUbigeoe').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaUbigeoe").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoUbigeoe").html("");
    $('select#cbDistritoUbigeoe').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaUbigeoe').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoUbigeoe").html("");
            $('select#cbDistritoUbigeoe').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoUbigeoe").append(RowContent);
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