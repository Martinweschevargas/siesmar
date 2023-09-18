var tblJemgemarArchivoRelacionTipoReunion;
var reporteSeleccionado;
var optReporteSelect;

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
                                url: '/JemgemarArchivoRelacionTipoReunion/Insertar',
                                data: {
                                    'CodigoReunion': $('#txtCodigoReunion').val(),
                                    'NumericoPais': $('#cbPaisUbigeo').val(),
                                    'CondicionPais': $('#txtCondicionPais').val(),
                                    'NroReunion': $('#txtNumeroReunion').val(),
                                    'NroParticipantes': $('#txtNumeroParticipantes').val(),
                                    'NroDiasRelacionReunion': $('#txtNumeroDias').val(),
                                    'GastosRelacionReunion': $('#txtGastos').val(),
                                    'Observaciones': $('#txtObservaciones').val(),
                                    'AFPersonal': $('#txtAFPersonal').val(),
                                    'AFInteligencia': $('#txtAFInteligencia').val(),
                                    'AFOperacionEntrenamiento': $('#txtAFOperacionEntrenamiento').val(),
                                    'AFLogistica': $('#txtAFLogistica').val(),
                                    'AFTelematica': $('#txtAFTelematica').val(),
                                    'AFInstruccion': $('#txtAFInstruccion').val(),
                                    'AFAccionCivica': $('#txtAFAccionCivica').val(),
                                    'AFCienciaTecnologia': $('#txtAFCienciaTecnologia').val(),
                                    'AFTerrorismoNarcotrafico': $('#txtAFTerrorismoNarcotrafico').val(),
                                    'AFMedioAmbiente': $('#txtAFMedioAmbiente').val(),
                                    'APPersonal': $('#txtAPPersonal').val(),
                                    'APInteligencia': $('#txtAPInteligencia').val(),
                                    'APOperacionEntrenamiento': $('#txtAPOperacionEntrenamiento').val(),
                                    'APLogistica': $('#txtAPLogistica').val(),
                                    'APTelematica': $('#txtAPTelematica').val(),
                                    'APInstruccion': $('#txtAPInstruccion').val(),
                                    'APAccionCivica': $('#txtAPAccionCivica').val(),
                                    'APCienciaTecnologia': $('#txtAPCienciaTecnologia').val(),
                                    'APTerrorismoNarcotrafico': $('#txtAPTerrorismoNarcotrafico').val(),
                                    'APMedioAmbiente': $('#txtAPMedioAmbiente').val(),
                                    'AEPersonal': $('#txtAEPersonal').val(),
                                    'AEInteligencia': $('#txtAEInteligencia').val(),
                                    'AEOperacionEntrenamiento': $('#txtAEOperacionEntrenamiento').val(),
                                    'AELogistica': $('#txtAELogistica').val(),
                                    'AETelematica': $('#txtAETelematica').val(),
                                    'AEInstruccion': $('#txtAEInstruccion').val(),
                                    'AEAccionCivica': $('#txtAEAccionCivica').val(),
                                    'AECienciaTecnologia': $('#txtAECienciaTecnologia').val(),
                                    'AETerrorismoNarcotrafico': $('#txtAETerrorismoNarcotrafico').val(),
                                    'AEMedioAmbiente': $('#txtAEMedioAmbiente').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'Fecha': $('#txtFecha').val()
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
                                    $('#tblJemgemarArchivoRelacionTipoReunion').DataTable().ajax.reload();
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
                                url: '/JemgemarArchivoRelacionTipoReunion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoReunion': $('#txtCodigoReunione').val(),
                                    'NumericoPais': $('#cbPaisUbigeoe').val(),
                                    'CondicionPais': $('#txtCondicionPaise').val(),
                                    'NroReunion': $('#txtNumeroReunione').val(),
                                    'NroParticipantes': $('#txtNumeroParticipantese').val(),
                                    'NroDiasRelacionReunion': $('#txtNumeroDiase').val(),
                                    'GastosRelacionReunion': $('#txtGastose').val(),
                                    'Observaciones': $('#txtObservacionese').val(),
                                    'AFPersonal': $('#txtAFPersonale').val(),
                                    'AFInteligencia': $('#txtAFInteligenciae').val(),
                                    'AFOperacionEntrenamiento': $('#txtAFOperacionEntrenamientoe').val(),
                                    'AFLogistica': $('#txtAFLogisticae').val(),
                                    'AFTelematica': $('#txtAFTelematicae').val(),
                                    'AFInstruccion': $('#txtAFInstruccione').val(),
                                    'AFAccionCivica': $('#txtAFAccionCivicae').val(),
                                    'AFCienciaTecnologia': $('#txtAFCienciaTecnologiae').val(),
                                    'AFTerrorismoNarcotrafico': $('#txtAFTerrorismoNarcotraficoe').val(),
                                    'AFMedioAmbiente': $('#txtAFMedioAmbientee').val(),
                                    'APPersonal': $('#txtAPPersonale').val(),
                                    'APInteligencia': $('#txtAPInteligenciae').val(),
                                    'APOperacionEntrenamiento': $('#txtAPOperacionEntrenamientoe').val(),
                                    'APLogistica': $('#txtAPLogisticae').val(),
                                    'APTelematica': $('#txtAPTelematicae').val(),
                                    'APInstruccion': $('#txtAPInstruccione').val(),
                                    'APAccionCivica': $('#txtAPAccionCivicae').val(),
                                    'APCienciaTecnologia': $('#txtAPCienciaTecnologiae').val(),
                                    'APTerrorismoNarcotrafico': $('#txtAPTerrorismoNarcotraficoe').val(),
                                    'APMedioAmbiente': $('#txtAPMedioAmbientee').val(),
                                    'AEPersonal': $('#txtAEPersonale').val(),
                                    'AEInteligencia': $('#txtAEInteligenciae').val(),
                                    'AEOperacionEntrenamiento': $('#txtAEOperacionEntrenamientoe').val(),
                                    'AELogistica': $('#txtAELogisticae').val(),
                                    'AETelematica': $('#txtAETelematicae').val(),
                                    'AEInstruccion': $('#txtAEInstruccione').val(),
                                    'AEAccionCivica': $('#txtAEAccionCivicae').val(),
                                    'AECienciaTecnologia': $('#txtAECienciaTecnologiae').val(),
                                    'AETerrorismoNarcotrafico': $('#txtAETerrorismoNarcotraficoe').val(),
                                    'AEMedioAmbiente': $('#txtAEMedioAmbientee').val(),
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
                                    $('#tblJemgemarArchivoRelacionTipoReunion').DataTable().ajax.reload();
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

   tblJemgemarArchivoRelacionTipoReunion=  $('#tblJemgemarArchivoRelacionTipoReunion').DataTable({
        ajax: {
            "url": '/JemgemarArchivoRelacionTipoReunion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "archivoRelacionTipoReunionId" },
            { "data": "codigoReunion" },
            { "data": "nombrePais" },
            { "data": "condicionPais" },
            { "data": "nroReunion" },
            { "data": "nroParticipantes" },
            { "data": "nroDiasRelacionReunion" },
            { "data": "gastosRelacionReunion" },
            { "data": "observaciones" },
            { "data": "afPersonal" },
            { "data": "afInteligencia" },
            { "data": "afOperacionEntrenamiento" },
            { "data": "afLogistica" },
            { "data": "afTelematica" },
            { "data": "afInstruccion" },
            { "data": "afAccionCivica" },
            { "data": "afCienciaTecnologia" },
            { "data": "afTerrorismoNarcotrafico" },
            { "data": "afMedioAmbiente" },
            { "data": "apPersonal" },
            { "data": "apInteligencia" },
            { "data": "apOperacionEntrenamiento" },
            { "data": "apLogistica" },
            { "data": "apTelematica" },
            { "data": "apInstruccion" },
            { "data": "apAccionCivica" },
            { "data": "apCienciaTecnologia" },
            { "data": "apTerrorismoNarcotrafico" },
            { "data": "apMedioAmbiente" },
            { "data": "aePersonal" },
            { "data": "aeInteligencia" },
            { "data": "aeOperacionEntrenamiento" },
            { "data": "aeLogistica" },
            { "data": "aeTelematica" },
            { "data": "aeInstruccion" },
            { "data": "aeAccionCivica" },
            { "data": "aeCienciaTecnologia" },
            { "data": "aeTerrorismoNarcotrafico" },
            { "data": "aeMedioAmbiente" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.archivoRelacionTipoReunionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.archivoRelacionTipoReunionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Jemgemar - Archivo para Relaciones Bilaterales y Multilaterales por Tipo de Reunión',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Jemgemar - Archivo para Relaciones Bilaterales y Multilaterales por Tipo de Reunión',
                title: 'Jemgemar - Archivo para Relaciones Bilaterales y Multilaterales por Tipo de Reunión',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Jemgemar - Archivo para Relaciones Bilaterales y Multilaterales por Tipo de Reunión',
                title: 'Jemgemar - Archivo para Relaciones Bilaterales y Multilaterales por Tipo de Reunión',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Jemgemar - Archivo para Relaciones Bilaterales y Multilaterales por Tipo de Reunión',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38]
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
    tblJemgemarArchivoRelacionTipoReunion.columns(39).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblJemgemarArchivoRelacionTipoReunion.columns(39).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/JemgemarArchivoRelacionTipoReunion/Mostrar?Id=' + Id, [], function (ArchivoRelacionTipoReunionDTO) {
        $('#txtCodigo').val(ArchivoRelacionTipoReunionDTO.archivoRelacionTipoReunionId);
        $('#txtCodigoReunione').val(ArchivoRelacionTipoReunionDTO.codigoReunion);
        $('select#cbPaisUbigeoe option[value=' + ArchivoRelacionTipoReunionDTO.numericoPais + ']').prop("selected", "true");
        $('#txtCondicionPaise').val(ArchivoRelacionTipoReunionDTO.condicionPais);
        $('#txtNumeroReunione').val(ArchivoRelacionTipoReunionDTO.nroReunion);
        $('#txtNumeroParticipantese').val(ArchivoRelacionTipoReunionDTO.nroParticipantes);
        $('#txtNumeroDiase').val(ArchivoRelacionTipoReunionDTO.nroDiasRelacionReunion);
        $('#txtGastose').val(ArchivoRelacionTipoReunionDTO.gastosRelacionReunion);
        $('#txtObservacionese').val(ArchivoRelacionTipoReunionDTO.observaciones);
        $('#txtAFPersonale').val(ArchivoRelacionTipoReunionDTO.afPersonal);
        $('#txtAFInteligenciae').val(ArchivoRelacionTipoReunionDTO.afInteligencia);
        $('#txtAFOperacionEntrenamientoe').val(ArchivoRelacionTipoReunionDTO.afOperacionEntrenamiento);
        $('#txtAFLogisticae').val(ArchivoRelacionTipoReunionDTO.afLogistica);
        $('#txtAFTelematicae').val(ArchivoRelacionTipoReunionDTO.afTelematica);
        $('#txtAFInstruccione').val(ArchivoRelacionTipoReunionDTO.afInstruccion);
        $('#txtAFAccionCivicae').val(ArchivoRelacionTipoReunionDTO.afAccionCivica);
        $('#txtAFCienciaTecnologiae').val(ArchivoRelacionTipoReunionDTO.afCienciaTecnologia);
        $('#txtAFTerrorismoNarcotraficoe').val(ArchivoRelacionTipoReunionDTO.afTerrorismoNarcotrafico);
        $('#txtAFMedioAmbientee').val(ArchivoRelacionTipoReunionDTO.afMedioAmbiente);
        $('#txtAPPersonale').val(ArchivoRelacionTipoReunionDTO.apPersonal);
        $('#txtAPInteligenciae').val(ArchivoRelacionTipoReunionDTO.apInteligencia);
        $('#txtAPOperacionEntrenamientoe').val(ArchivoRelacionTipoReunionDTO.apOperacionEntrenamiento);
        $('#txtAPLogisticae').val(ArchivoRelacionTipoReunionDTO.apLogistica);
        $('#txtAPCienciaTecnologiae').val(ArchivoRelacionTipoReunionDTO.apCienciaTecnologia);
        $('#txtAPTelematicae').val(ArchivoRelacionTipoReunionDTO.apTelematica);
        $('#txtAPInstruccione').val(ArchivoRelacionTipoReunionDTO.apInstruccion);
        $('#txtAPAccionCivicae').val(ArchivoRelacionTipoReunionDTO.apAccionCivica);
        $('#txtAPTerrorismoNarcotraficoe').val(ArchivoRelacionTipoReunionDTO.apTerrorismoNarcotrafico);
        $('#txtAPMedioAmbientee').val(ArchivoRelacionTipoReunionDTO.apMedioAmbiente);
        $('#txtAEPersonale').val(ArchivoRelacionTipoReunionDTO.aePersonal);
        $('#txtAEInteligenciae').val(ArchivoRelacionTipoReunionDTO.aeInteligencia);
        $('#txtAEOperacionEntrenamientoe').val(ArchivoRelacionTipoReunionDTO.aeOperacionEntrenamiento);
        $('#txtAELogisticae').val(ArchivoRelacionTipoReunionDTO.aeLogistica);
        $('#txtAETelematicae').val(ArchivoRelacionTipoReunionDTO.aeTelematica);
        $('#txtAEInstruccione').val(ArchivoRelacionTipoReunionDTO.aeInstruccion);
        $('#txtAEAccionCivicae').val(ArchivoRelacionTipoReunionDTO.aeAccionCivica);
        $('#txtAECienciaTecnologiae').val(ArchivoRelacionTipoReunionDTO.aeCienciaTecnologia);
        $('#txtAETerrorismoNarcotraficoe').val(ArchivoRelacionTipoReunionDTO.aeTerrorismoNarcotrafico);
        $('#txtAEMedioAmbientee').val(ArchivoRelacionTipoReunionDTO.aeMedioAmbiente);
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
                url: '/JemgemarArchivoRelacionTipoReunion/Eliminar',
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
                    $('#tblJemgemarArchivoRelacionTipoReunion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
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
                url: '/JemgemarArchivoRelacionTipoReunion/EliminarCarga',
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
                    $('#tblJemgemarArchivoRelacionTipoReunion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaJemgemarArchivoRelacionTipoReunion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'JemgemarArchivoRelacionTipoReunion/MostrarDatos',
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
                            $("<td>").text(item.codigoReunion),
                            $("<td>").text(item.numericoPais),
                            $("<td>").text(item.condicionPais),
                            $("<td>").text(item.nroReunion),
                            $("<td>").text(item.nroParticipantes),
                            $("<td>").text(item.nroDiasRelacionReunion),
                            $("<td>").text(item.gastosRelacionReunion),
                            $("<td>").text(item.observaciones),
                            $("<td>").text(item.afPersonal),
                            $("<td>").text(item.afInteligencia),
                            $("<td>").text(item.afOperacionEntrenamiento),
                            $("<td>").text(item.afLogistica),
                            $("<td>").text(item.afTelematica),
                            $("<td>").text(item.afInstruccion),
                            $("<td>").text(item.afAccionCivica),
                            $("<td>").text(item.afCienciaTecnologia),
                            $("<td>").text(item.afTerrorismoNarcotrafico),
                            $("<td>").text(item.afMedioAmbiente),
                            $("<td>").text(item.apPersonal),
                            $("<td>").text(item.apInteligencia),
                            $("<td>").text(item.apOperacionEntrenamiento),
                            $("<td>").text(item.apLogistica),
                            $("<td>").text(item.apTelematica),
                            $("<td>").text(item.apInstruccion),
                            $("<td>").text(item.apAccionCivica),
                            $("<td>").text(item.apCienciaTecnologia),
                            $("<td>").text(item.apTerrorismoNarcotrafico),
                            $("<td>").text(item.apMedioAmbiente),
                            $("<td>").text(item.aePersonal),
                            $("<td>").text(item.aeInteligencia),
                            $("<td>").text(item.aeOperacionEntrenamiento),
                            $("<td>").text(item.aeLogistica),
                            $("<td>").text(item.aeTelematica),
                            $("<td>").text(item.aeInstruccion),
                            $("<td>").text(item.aeAccionCivica),
                            $("<td>").text(item.aeCienciaTecnologia),
                            $("<td>").text(item.aeTerrorismoNarcotrafico),
                            $("<td>").text(item.aeMedioAmbiente)
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
    formData.append("Fecha", $('#txtFecha').val())
    fetch("JemgemarArchivoRelacionTipoReunion/EnviarDatos", {
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
                    'Ocurrio un problema. ' + mensaje,
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/JemgemarArchivoRelacionTipoReunion/cargaCombs', [], function (Json) {
        var paisUbigeo = Json["data1"];
        var listaCargas = Json["data2"];

        $("select#cbPaisUbigeo").html("");
        $("select#cbPaisUbigeoe").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numerico + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeo").append(RowContent);
            $("select#cbPaisUbigeoe").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });

    });
}


function optReporte(id) {
    optReporteSelect = id;

    reporteSeleccionado = '/JemgemarArchivoRelacionTipoReunion/ReporteARTR';
}


$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";

    var numCarga;
    if (idCarga == "0") {
        numCarga = '?CargaId=' + "";
    } else {
        numCarga = '?CargaId=' + idCarga;
    }

    if (optReporteSelect == 1) {
        a.href = reporteSeleccionado + numCarga;
    }
    a.click();
});