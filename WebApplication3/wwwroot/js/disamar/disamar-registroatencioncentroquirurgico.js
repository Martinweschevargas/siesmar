var tblDisamarRegistroAtencionCentroQuirurgico;
var reporteSeleccionado;
var optReporteSelect;

var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

$('select#cbProvinciaUbigeo').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#DistritoUbigeo').append('<option selected disabled>Seleccionar Distrito</option>');

$('select#cbProvinciaPaciente').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#txtDistritoPaciente').append('<option selected disabled>Seleccionar Distrito</option>');
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
                                url: '/DisamarRegistroAtencionCentroQuirurgico/Insertar',
                                data: {
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitar').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoEstablecimientoSaludMGP': $('#cbEstablecimientoSaludMGP').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeo').val(),
                                    'SalaOperacion': $('#txtSalaOperacion').val(),
                                    'NombreMedicoIntervencion': $('#txtNombreMedicoIntervencion').val(),
                                    'NSACIPMedicoIntervencion': $('#txtNSACIPMedicoIntervencion').val(),
                                    'CMPMedicoIntervencion': $('#txtCMPMedicoIntervencion').val(),
                                    'EspecialidadMedico': $('#txtEspecialidadMedico').val(),
                                    'NumeroIntervencion': $('#txtNumeroIntervencion').val(),
                                    'HistoriaClinica': $('#txtHistoriaClinica').val(),
                                    'DNIPaciente': $('#txtDNIPaciente').val(),
                                    'CodigoUnidadDependencia': $('#cbUnidadDependencia').val(),
                                    'DistritoPaciente': $('#txtDistritoPaciente').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'SituacionPaciente': $('#txtSituacionPaciente').val(),
                                    'CondicionPaciente': $('#txtCondicionPaciente').val(),
                                    'EdadPaciente': $('#txtEdadPaciente').val(),
                                    'TipoEdad': $('#txtTipoEdad').val(),
                                    'SexoPaciente': $('#txtSexoPaciente').val(),
                                    'CodigoOrigenPacienteIntervenido': $('#cbOrigenPacienteIntervenido').val(),
                                    'DiagnosticoMotivoAtencion1': $('#txtDiagnosticoMotivoAtencion1').val(),
                                    'TipoDX1': $('#txtTipoDX1').val(),
                                    'CIE10_1': $('#txtCIE10_1').val(),
                                    'DiagnosticoMotivoAtencion2': $('#txtDiagnosticoMotivoAtencion2').val(),
                                    'TipoDX2': $('#txtTipoDX2options').val(),
                                    'CIE10_2': $('#txtCIE10_2').val(),
                                    'DiagnosticoMotivoAtencion3': $('#txtDiagnosticoMotivoAtencion3').val(),
                                    'TipoDX3': $('#txtTipoDX3options').val(),
                                    'CIE10_3': $('#txtCIE10_3').val(),
                                    'IntervencionQuirurgicaEfectuada': $('#txtIntervencionQuirurgicaEfectuada').val(),
                                    'CodigoIntervencionEfectuada': $('#txtCodigoIntervencionEfectuada').val(),
                                    'IntervencionQuirurgicaAdicional': $('#txtIntervencionQuirurgicaAdicional').val(),
                                    'CodigoIntervencionAdicional': $('#txtCodigoIntervencionAdicional').val(),
                                    'FechaHoraInicio': $('#txtFechaHoraInicio').val(),
                                    'FechaHoraFin': $('#txtFechaHoraFin').val(),
                                    'TipoIntervencion': $('#txtTipoIntervencion').val(),
                                    'EstadoPaciente': $('#txtEstadoPaciente').val(),
                                    'CodigoDestinoPaciente': $('#cbDestinoPaciente').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'mes': $('select#cbMess').val(),
                                    'anio': $('select#cbAnio').val()
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
                                    $('#tblDisamarRegistroAtencionCentroQuirurgico').DataTable().ajax.reload();
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
                                url: '/DisamarRegistroAtencionCentroQuirurgico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitare').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoEstablecimientoSaludMGP': $('#cbEstablecimientoSaludMGPe').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeoe').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeoe').val(),
                                    'SalaOperacion': $('#txtSalaOperacione').val(),
                                    'NombreMedicoIntervencion': $('#txtNombreMedicoIntervencione').val(),
                                    'NSACIPMedicoIntervencion': $('#txtNSACIPMedicoIntervencione').val(),
                                    'CMPMedicoIntervencion': $('#txtCMPMedicoIntervencione').val(),
                                    'EspecialidadMedico': $('#txtEspecialidadMedicoe').val(),
                                    'NumeroIntervencion': $('#txtNumeroIntervencione').val(),
                                    'HistoriaClinica': $('#txtHistoriaClinicae').val(),
                                    'DNIPaciente': $('#txtDNIPacientee').val(),
                                    'CodigoUnidadDependencia': $('#cbUnidadDependenciae').val(),
                                    'DistritoPaciente': $('#txtDistritoPacientee').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'SituacionPaciente': $('#txtSituacionPacientee').val(),
                                    'CondicionPaciente': $('#txtCondicionPacientee').val(),
                                    'EdadPaciente': $('#txtEdadPacientee').val(),
                                    'TipoEdad': $('#txtTipoEdade').val(),
                                    'SexoPaciente': $('#txtSexoPacientee').val(),
                                    'CodigoOrigenPacienteIntervenido': $('#cbOrigenPacienteIntervenidoe').val(),
                                    'DiagnosticoMotivoAtencion1': $('#txtDiagnosticoMotivoAtencion1e').val(),
                                    'TipoDX1': $('#txtTipoDX1e').val(),
                                    'CIE10_1': $('#txtCIE10_1e').val(),
                                    'DiagnosticoMotivoAtencion2': $('#txtDiagnosticoMotivoAtencion2e').val(),
                                    'TipoDX2': $('#txtTipoDX2optionse').val(),
                                    'CIE10_2': $('#txtCIE10_2e').val(),
                                    'DiagnosticoMotivoAtencion3': $('#txtDiagnosticoMotivoAtencion3e').val(),
                                    'TipoDX3': $('#txtTipoDX3optionse').val(),
                                    'CIE10_3': $('#txtCIE10_3e').val(),
                                    'IntervencionQuirurgicaEfectuada': $('#txtIntervencionQuirurgicaEfectuadae').val(),
                                    'CodigoIntervencionEfectuada': $('#txtCodigoIntervencionEfectuadae').val(),
                                    'IntervencionQuirurgicaAdicional': $('#txtIntervencionQuirurgicaAdicionale').val(),
                                    'CodigoIntervencionAdicional': $('#txtCodigoIntervencionAdicionale').val(),
                                    'FechaHoraInicio': $('#txtFechaHoraInicioe').val(),
                                    'FechaHoraFin': $('#txtFechaHoraFine').val(),
                                    'TipoIntervencion': $('#txtTipoIntervencione').val(),
                                    'EstadoPaciente': $('#txtEstadoPacientee').val(),
                                    'CodigoDestinoPaciente': $('#cbDestinoPacientee').val(), 
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
                                    $('#tblDisamarRegistroAtencionCentroQuirurgico').DataTable().ajax.reload();
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

   tblDisamarRegistroAtencionCentroQuirurgico =  $('#tblDisamarRegistroAtencionCentroQuirurgico').DataTable({
        ajax: {
            "url": '/DisamarRegistroAtencionCentroQuirurgico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroAtencionCentroQuirurgicoId" },
            { "data": "descEntidadMilitar" },
            { "data": "descZonaNaval" },
            { "data": "descEstablecimientoSalud" },
            { "data": "descDistrito" },
            { "data": "salaOperacion" },
            { "data": "nombreMedicoIntervencion" },
            { "data": "nsaCIPMedicoIntervencion" },
            { "data": "cmpMedicoIntervencion" },
            { "data": "especialidadMedico" },
            { "data": "numeroIntervencion" },
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
            { "data": "descOrigenPacienteIntervenido" },
            { "data": "diagnosticoMotivoAtencion1" },
            { "data": "tipoDX1" },
            { "data": "cie10_1" },
            { "data": "diagnosticoMotivoAtencion2" },
            { "data": "tipoDX2" },
            { "data": "cie10_2" },
            { "data": "diagnosticoMotivoAtencion3" },
            { "data": "tipoDX3" },
            { "data": "cie10_3" },
            { "data": "intervencionQuirurgicaEfectuada" },
            { "data": "codigoIntervencionEfectuada" },
            { "data": "intervencionQuirurgicaAdicional" },
            { "data": "codigoIntervencionAdicional" },
            { "data": "fechaHoraInicio" },
            { "data": "fechaHoraFin" },
            { "data": "tipoIntervencion" },
            { "data": "estadoPaciente" },
            { "data": "descDestinoPaciente" },
            { "data": "cargaId" }

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroAtencionCentroQuirurgicoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroAtencionCentroQuirurgicoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Disamar - Registro de atención en Centro Quirúrgico',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Disamar - Registro de atención en Centro Quirúrgico',
                title: 'Disamar - Registro de atención en Centro Quirúrgico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Disamar - Registro de atención en Centro Quirúrgico',
                title: 'Disamar - Registro de atención en Centro Quirúrgico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Disamar - Registro de atención en Centro Quirúrgico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40]
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
    tblDisamarRegistroAtencionCentroQuirurgico.columns(43).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDisamarRegistroAtencionCentroQuirurgico.columns(43).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DisamarRegistroAtencionCentroQuirurgico/Mostrar?Id=' + Id, [], function (RegistroAtencionCentroQuirurgico) {
        $('#txtCodigo').val(RegistroAtencionCentroQuirurgico.registroAtencionCentroQuirurgicoId);
        $('#cbEntidadMilitare').val(RegistroAtencionCentroQuirurgicoDTO.codigoEntidadMilitar);
        $('#cbZonaNavale').val(RegistroAtencionCentroQuirurgicoDTO.codigoZonaNaval);
        $('#cbEstablecimientoSaludMGPe').val(RegistroAtencionCentroQuirurgicoDTO.codigoEstablecimientoSaludMGP);
        var iddistrito =RegistroAtencionCentroQuirurgicoDTO.distritoUbigeo;
        $('#txtSalaOperacione').val(RegistroAtencionCentroQuirurgicoDTO.salaOperacion);
        $('#txtNombreMedicoIntervencione').val(RegistroAtencionCentroQuirurgicoDTO.nombreMedicoIntervencion);
        $('#txtNSACIPMedicoIntervencione').val(RegistroAtencionCentroQuirurgicoDTO.nsaCIPMedicoIntervencion);
        $('#txtCMPMedicoIntervencione').val(RegistroAtencionCentroQuirurgicoDTO.cmpMedicoIntervencion);
        $('#txtEspecialidadMedicoe').val(RegistroAtencionCentroQuirurgicoDTO.especialidadMedico);
        $('#txtNumeroIntervencione').val(RegistroAtencionCentroQuirurgicoDTO.numeroIntervencion);
        $('#txtHistoriaClinicae').val(RegistroAtencionCentroQuirurgicoDTO.historiaClinica);
        $('#txtDNIPacientee').val(RegistroAtencionCentroQuirurgicoDTO.dniPaciente);
        $('#cbUnidadDependenciae').val(RegistroAtencionCentroQuirurgicoDTO.codigoUnidadDependencia);
        var iddistrito2 =RegistroAtencionCentroQuirurgicoDTO.distritoPaciente;
        $('#cbTipoPersonalMilitare').val(RegistroAtencionCentroQuirurgicoDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMilitare').val(RegistroAtencionCentroQuirurgicoDTO.codigoGradoPersonalMilitar);
        $('#txtSituacionPacientee').val(RegistroAtencionCentroQuirurgicoDTO.situacionPaciente);
        $('#txtCondicionPacientee').val(RegistroAtencionCentroQuirurgicoDTO.condicionPaciente);
        $('#txtEdadPacientee').val(RegistroAtencionCentroQuirurgicoDTO.edadPaciente);
        $('#txtTipoEdade').val(RegistroAtencionCentroQuirurgicoDTO.tipoEdad);
        $('#txtSexoPacientee').val(RegistroAtencionCentroQuirurgicoDTO.sexoPaciente);
        $('#cbOrigenPacienteIntervenidoe').val(RegistroAtencionCentroQuirurgicoDTO.codigoOrigenPacienteIntervenido);
        $('#txtDiagnosticoMotivoAtencion1e').val(RegistroAtencionCentroQuirurgicoDTO.diagnosticoMotivoAtencion1);
        $('#txtTipoDX1e').val(RegistroAtencionCentroQuirurgicoDTO.tipoDX1);
        $('#txtCIE10_1e').val(RegistroAtencionCentroQuirurgicoDTO.cie10_1);
        $('#txtDiagnosticoMotivoAtencion2e').val(RegistroAtencionCentroQuirurgicoDTO.diagnosticoMotivoAtencion2);
        $('#txtTipoDX2optionse').val(RegistroAtencionCentroQuirurgicoDTO.tipoDX2);
        $('#txtCIE10_2e').val(RegistroAtencionCentroQuirurgicoDTO.cie10_2);
        $('#txtDiagnosticoMotivoAtencion3e').val(RegistroAtencionCentroQuirurgicoDTO.diagnosticoMotivoAtencion3);
        $('#txtTipoDX3optionse').val(RegistroAtencionCentroQuirurgicoDTO.tipoDX3);
        $('#txtCIE10_3e').val(RegistroAtencionCentroQuirurgicoDTO.cie10_3);
        $('#txtIntervencionQuirurgicaEfectuadae').val(RegistroAtencionCentroQuirurgicoDTO.intervencionQuirurgicaEfectuada);
        $('#txtCodigoIntervencionEfectuadae').val(RegistroAtencionCentroQuirurgicoDTO.codigoIntervencionEfectuada);
        $('#txtIntervencionQuirurgicaAdicionale').val(RegistroAtencionCentroQuirurgicoDTO.intervencionQuirurgicaAdicional);
        $('#txtCodigoIntervencionAdicionale').val(RegistroAtencionCentroQuirurgicoDTO.codigoIntervencionAdicional);
        $('#txtFechaHoraInicioe').val(RegistroAtencionCentroQuirurgicoDTO.fechaHoraInicio);
        $('#txtFechaHoraFine').val(RegistroAtencionCentroQuirurgicoDTO.fechaHoraFin);
        $('#txtTipoIntervencione').val(RegistroAtencionCentroQuirurgicoDTO.tipoIntervencion);
        $('#txtEstadoPacientee').val(RegistroAtencionCentroQuirurgicoDTO.estadoPaciente);
        $('#cbDestinoPacientee').val(RegistroAtencionCentroQuirurgicoDTO.codigoDestinoPaciente); 


        encontrardatocombo(iddistrito);
        encontrardatocombo(iddistrito2);

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
                url: '/DisamarRegistroAtencionCentroQuirurgico/Eliminar',
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
                    $('#tblDisamarRegistroAtencionCentroQuirurgico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDisamarRegistroAtencionCentroQuirurgico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DisamarRegistroAtencionCentroQuirurgico/MostrarDatos',
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
                            $("<td>").text(item.salaOperacion),
                            $("<td>").text(item.nombreMedicoIntervencion),
                            $("<td>").text(item.nsaCIPMedicoIntervencion),
                            $("<td>").text(item.cmpMedicoIntervencion),
                            $("<td>").text(item.especialidadMedico),
                            $("<td>").text(item.numeroIntervencion),
                            $("<td>").text(item.historiaClinica),
                            $("<td>").text(item.dniPaciente),
                            $("<td>").text(item.codigoUnidadDependencia),
                            $("<td>").text(item.distritoPaciente),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.situacionPaciente),
                            $("<td>").text(item.condicionPaciente),
                            $("<td>").text(item.edadPaciente),
                            $("<td>").text(item.tipoEdad),
                            $("<td>").text(item.sexoPaciente),
                            $("<td>").text(item.codigoOrigenPacienteIntervenido),
                            $("<td>").text(item.diagnosticoMotivoAtencion1),
                            $("<td>").text(item.tipoDX1),
                            $("<td>").text(item.cie10_1),
                            $("<td>").text(item.diagnosticoMotivoAtencion2),
                            $("<td>").text(item.tipoDX2),
                            $("<td>").text(item.cie10_2),
                            $("<td>").text(item.diagnosticoMotivoAtencion3),
                            $("<td>").text(item.tipoDX3),
                            $("<td>").text(item.cie10_3),
                            $("<td>").text(item.intervencionQuirurgicaEfectuada),
                            $("<td>").text(item.codigoIntervencionEfectuada),
                            $("<td>").text(item.intervencionQuirurgicaAdicional),
                            $("<td>").text(item.codigoIntervencionAdicional),
                            $("<td>").text(item.fechaHoraInicio),
                            $("<td>").text(item.fechaHoraFin),
                            $("<td>").text(item.tipoIntervencion),
                            $("<td>").text(item.estadoPaciente),
                            $("<td>").text(item.codigoDestinoPaciente)
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
    formData.append("mes", $('select#cbMess').val())
    formData.append("anio", $('select#cbAnios').val())
    fetch("DisamarRegistroAtencionCentroQuirurgico/EnviarDatos", {
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

function eliminarCarga() {
    var id = $('select#cargas').val();
    Swal.fire({
        title: 'Estas seguro?',
        text: "No podras revertir!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si,borralo!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '/DisamarRegistroAtencionCentroQuirurgico/EliminarCarga',
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
                    $('#tblDisamarRegistroAtencionCentroQuirurgico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}
function cargaDatos() {
    $.getJSON('/DisamarRegistroAtencionCentroQuirurgico/cargaCombs', [], function (Json) {
        var entidadMilitar = Json["data1"];
        var zonaNaval = Json["data2"];
        var establecimientoSaludMGP = Json["data3"];
        distritoUbigeo = Json["data4"];
        var unidadDependencia = Json["data5"];
        var tipoPersonalMilitar = Json["data6"];
        var gradoPersonalMilitar = Json["data7"];
        var origenPacienteIntervenido = Json["data8"];
        var destinoPaciente = Json["data9"];
        var listaCargas = Json["data10"];
        provinciaUbigeo = Json["data11"];
        departamentoUbigeo = Json["data12"];
        var listaMes = Json["mes"];
        var listaAnio = Json["anio"];

        $("select#cbMess").html("");
        $.each(listaMes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMess").append(RowContent);
        });

        $("select#cbAnios").html("");
        $.each(listaAnio, function () {
            var RowContent = '<option value=' + this.codigoAnio + '>' + this.descAnio + '</option>'
            $("select#cbAnios").append(RowContent);
        });



        $("select#cbEntidadMilitar").html("");
        $("select#cbEntidadMilitare").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadMilitar").append(RowContent);
            $("select#cbEntidadMilitare").append(RowContent);
        });


        $("select#cbZonaNaval").html("");
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
            $("select#cbZonaNavale").append(RowContent);
        });


        $("select#cbEstablecimientoSaludMGP").html("");
        $("select#cbEstablecimientoSaludMGPe").html("");
        $.each(establecimientoSaludMGP, function () {
            var RowContent = '<option value=' + this.codigoEstablecimientoSaludMGP + '>' + this.descEstablecimientoSalud + '</option>'
            $("select#cbEstablecimientoSaludMGP").append(RowContent);
            $("select#cbEstablecimientoSaludMGPe").append(RowContent);
        });


        $("select#cbDepartamentoUbigeo").html("");
        $("select#cbDepartamentoPaciente").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeo").append(RowContent);
            $("select#cbDepartamentoPaciente").append(RowContent);
        });



        $("select#cbUnidadDependencia").html("");
        $("select#cbUnidadDependenciae").html("");
        $.each(unidadDependencia, function () {
            var RowContent = '<option value=' + this.codigoUnidadDependencia + '>' + this.descUnidadDependencia + '</option>'
            $("select#cbUnidadDependencia").append(RowContent);
            $("select#cbUnidadDependenciae").append(RowContent);
        });

        $("select#txtDistritoPaciente").html("");
        $("select#txtDistritoPacientee").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#txtDistritoPaciente").append(RowContent);
            $("select#txtDistritoPacientee").append(RowContent);
        });

        $("select#cbTipoPersonalMilitar").html("");
        $("select#cbTipoPersonalMilitare").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitar").append(RowContent);
            $("select#cbTipoPersonalMilitare").append(RowContent);
        });

        $("select#cbGradoPersonalMilitar").html("");
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });


        $("select#cbOrigenPacienteIntervenido").html("");
        $("select#cbOrigenPacienteIntervenidoe").html("");
        $.each(origenPacienteIntervenido, function () {
            var RowContent = '<option value=' + this.codigoOrigenPacienteIntervenido + '>' + this.descOrigenPacienteIntervenido + '</option>'
            $("select#cbOrigenPacienteIntervenido").append(RowContent);
            $("select#cbOrigenPacienteIntervenidoe").append(RowContent);
        });

        $("select#cbDestinoPaciente").html("");
        $("select#cbDestinoPacientee").html("");
        $.each(destinoPaciente, function () {
            var RowContent = '<option value=' + this.codigoDestinoPaciente + '>' + this.descDestinoPaciente + '</option>'
            $("select#cbDestinoPaciente").append(RowContent);
            $("select#cbDestinoPacientee").append(RowContent);
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

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/BienestarMovilidadEscolar/ReporteME?idCarga=';
        $('#fecha').hide();
    }
    /*if (id == 2) { 
        reporteSeleccionado = '/BienestarMovilidadEscolar/ReporteME?idCarga=';
        $('#fecha').show();
    }*/
}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();

    var a = document.createElement('a');

    a.target = "_blank";
    if (optReporteSelect = 1) {
        a.href = reporteSeleccionado + idCarga;
    } else {
        // a.href = reporteSeleccionado + idCarga;
    }
    a.click();
});


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


$('select#cbDepartamentoPaciente').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaPaciente").html("");
            $('select#cbProvinciaPaciente').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaPaciente").append(RowContent);
                }
            });
        }
    });
    $("select#txtDistritoPaciente").html("");
    $('select#txtDistritoPaciente').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaPaciente').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#txtDistritoPaciente").html("");
            $('select#txtDistritoPaciente').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#txtDistritoPaciente").append(RowContent);
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
                    $("select#cbDepartamentoUbigeo").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoUbigeo").append(RowContent);

                    });
                    $('#cbDepartamentoUbigeo').val(departamento);
                    $("select#cbProvinciaUbigeo").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaUbigeo").append(RowContent);
                        }
                    });
                    $('#cbProvinciaUbigeo').val(provincia);
                    $("select#cbDistritoUbigeo").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoUbigeo").append(RowContent);
                        }
                    });
                    $('#cbDistritoUbigeo').val(iddistrito);
                }
            });


        }
    });
}




function encontrardatocombo(id) {
    var iddistrito = id;

    $.each(distritoUbigeo, function () {
        if (this.distritoUbigeo == iddistrito) {
            var provincia = this.provinciaUbigeo;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoPaciente").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoPaciente").append(RowContent);

                    });
                    $('#cbDepartamentoPaciente').val(departamento);
                    $("select#cbProvinciaPaciente").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaPaciente").append(RowContent);
                        }
                    });
                    $('#cbProvinciaPaciente').val(provincia);
                    $("select#txtDistritoPaciente").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#txtDistritoPaciente").append(RowContent);
                        }
                    });
                    $('#txtDistritoPaciente').val(iddistrito);
                }
            });


        }
    });
}



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


$('select#cbDepartamentoPacientee').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaPacientee").html("");
            $('select#cbProvinciaPacientee').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaPaciente").append(RowContent);
                }
            });
        }
    });
    $("select#txtDistritoPacientee").html("");
    $('select#txtDistritoPacientee').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaPacientee').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#txtDistritoPacientee").html("");
            $('select#txtDistritoPacientee').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#txtDistritoPacientee").append(RowContent);
                }
            });
        }
    });
});
