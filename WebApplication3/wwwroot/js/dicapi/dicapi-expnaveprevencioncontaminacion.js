var tblDicapiExpNavePrevencionContaminacion;
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
                                url: '/DicapiExpNavePrevencionContaminacion/Insertar',
                                data: {
                                    'NumeroDocumento': $('#txtNumero').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngreso').val(),
                                    'CodigoDptoProteccionMedioAmbiente': $('#cbDptoMaterial').val(),
                                    'DocumentoExpedido': $('#txtDocumento').val(),
                                    'NombreNaveArtefacto': $('#txtNombre').val(),
                                    'CodigoClaseNave': $('#cbClase').val(),
                                    'CodigoInstalacionTerrestreAcuatica': $('#cbTerrestre').val(),
                                    'MatriculaNave': $('#txtMatricula').val(),
                                    'PropietarioNave': $('#txtPropietario').val(),
                                    'NumericoPais': $('#cbNacionalidad').val(),
                                    'FechaAtencionSolicitud': $('#txtFechaAtencion').val(),
                                    'CargaId': $('#cargasR').val(),  
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
                                    $('#tblDicapiExpNavePrevencionContaminacion').DataTable().ajax.reload();
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
                                url: '/DicapiExpNavePrevencionContaminacion/Actualizar',
                                data: {
                                    'ExpNavePrevencionContaminacionId': $('#txtCodigo').val(),
                                    'NumeroDocumento': $('#txtNumeroe').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngresoe').val(),
                                    'CodigoDptoProteccionMedioAmbiente': $('#cbDptoMateriale').val(),
                                    'DocumentoExpedido': $('#txtDocumentoe').val(),
                                    'NombreNaveArtefacto': $('#txtNombree').val(),
                                    'CodigoClaseNave': $('#cbClasee').val(),
                                    'CodigoInstalacionTerrestreAcuatica': $('#cbTerrestree').val(),
                                    'MatriculaNave': $('#txtMatriculae').val(),
                                    'PropietarioNave': $('#txtPropietarioe').val(),
                                    'NumericoPais': $('#cbNacionalidade').val(),
                                    'FechaAtencionSolicitud': $('#txtFechaAtencione').val(), 
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
                                    $('#tblDicapiExpNavePrevencionContaminacion').DataTable().ajax.reload();
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

    $('#tblDicapiExpNavePrevencionContaminacion').DataTable({
        ajax: {
            "url": '/DicapiExpNavePrevencionContaminacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "expNavePrevencionContaminacionId" },
            { "data": "numeroDocumento" },
            { "data": "fechaIngresoSolicitud" },
            { "data": "descDptoProteccionMedioAmbiente" },
            { "data": "documentoExpedido" },
            { "data": "nombreNaveArtefacto" },
            { "data": "descClaseNave" },
            { "data": "descInstalacionTerrestreAcuatica" },  
            { "data": "matriculaNave" }, 
            { "data": "propietarioNave" },
            { "data": "nombrePais" },  
            { "data": "fechaAtencionSolicitud" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.expNavePrevencionContaminacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.expNavePrevencionContaminacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dicapi - Expedición de Documentos para Naves en Prevención de la Contaminación',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dicapi - Expedición de Documentos para Naves en Prevención de la Contaminación',
                title: 'Dicapi - Expedición de Documentos para Naves en Prevención de la Contaminación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dicapi - Expedición de Documentos para Naves en Prevención de la Contaminación',
                title: 'Dicapi - Expedición de Documentos para Naves en Prevención de la Contaminación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dicapi - Expedición de Documentos para Naves en Prevención de la Contaminación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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
    $.getJSON('/DicapiExpNavePrevencionContaminacion/Mostrar?Id=' + Id, [], function (ExpNavePrevencionContaminacionDTO) {
        $('#txtCodigo').val(ExpNavePrevencionContaminacionDTO.expNavePrevencionContaminacionId);
        $('#txtNumeroe').val(ExpNavePrevencionContaminacionDTO.numeroDocumento);
        $('#txtFechaIngresoe').val(ExpNavePrevencionContaminacionDTO.fechaIngresoSolicitud);
        $('#cbDptoMateriale').val(ExpNavePrevencionContaminacionDTO.codigoDptoProteccionMedioAmbiente);
        $('#txtDocumentoe').val(ExpNavePrevencionContaminacionDTO.documentoExpedido);
        $('#txtNombree').val(ExpNavePrevencionContaminacionDTO.nombreNaveArtefacto);
        $('#cbClasee').val(ExpNavePrevencionContaminacionDTO.codigoClaseNave);
        $('#cbTerrestree').val(ExpNavePrevencionContaminacionDTO.codigoInstalacionTerrestreAcuatica);
        $('#txtMatriculae').val(ExpNavePrevencionContaminacionDTO.matriculaNave);
        $('#txtPropietarioe').val(ExpNavePrevencionContaminacionDTO.propietarioNave);
        $('#cbNacionalidade').val(ExpNavePrevencionContaminacionDTO.mumericoPais);
        $('#txtFechaAtencione').val(ExpNavePrevencionContaminacionDTO.fechaAtencionSolicitud); 
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
                url: '/DicapiExpNavePrevencionContaminacion/Eliminar',
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
                    $('#tblDicapiExpNavePrevencionContaminacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDicapiExpNavePrevencionContaminacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            console.log(dataJson);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.nombreTemaEstudioInvestigacion),
                        $("<td>").text(item.tipoEstudioInvestigacion),
                        $("<td>").text(item.fechaInicio),
                        $("<td>").text(item.fechaTermino),
                        $("<td>").text(item.responsable),
                        $("<td>").text(item.solicitante)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            alert(dataJson.mensaje);
        })
}


function cargaDatos() {
    $.getJSON('/DicapiExpNavePrevencionContaminacion/cargaCombs', [], function (Json) {
        var dptoProteccionMedioAmbiente = Json["data1"];
        var claseNave = Json["data2"];
        var instalacionTerrestreAcuatica = Json["data3"];
        var paisUbigeo = Json["data4"];
        var listaCargas = Json["data5"];


        $("select#cbDptoMaterial").html("");
        $.each(dptoProteccionMedioAmbiente, function () {
            var RowContent = '<option value=' + this.codigoDptoProteccionMedioAmbiente + '>' + this.descDptoProteccionMedioAmbiente + '</option>'
            $("select#cbDptoMaterial").append(RowContent);
        });
        $("select#cbDptoMateriale").html("");
        $.each(dptoProteccionMedioAmbiente, function () {
            var RowContent = '<option value=' + this.codigoDptoProteccionMedioAmbiente + '>' + this.descDptoProteccionMedioAmbiente + '</option>'
            $("select#cbDptoMateriale").append(RowContent);
        });

        $("select#cbClase").html("");
        $.each(claseNave, function () {
            var RowContent = '<option value=' + this.codigoClaseNave + '>' + this.descClaseNave + '</option>'
            $("select#cbClase").append(RowContent);
        });
        $("select#cbClasee").html("");
        $.each(claseNave, function () {
            var RowContent = '<option value=' + this.codigoClaseNave + '>' + this.descClaseNave + '</option>'
            $("select#cbClasee").append(RowContent);
        });

        $("select#cbTerrestre").html("");
        $.each(instalacionTerrestreAcuatica, function () {
            var RowContent = '<option value=' + this.codigoInstalacionTerrestreAcuatica + '>' + this.descInstalacionTerrestreAcuatica + '</option>'
            $("select#cbTerrestre").append(RowContent);
        });
        $("select#cbTerrestree").html("");
        $.each(instalacionTerrestreAcuatica, function () {
            var RowContent = '<option value=' + this.codigoInstalacionTerrestreAcuatica + '>' + this.descInstalacionTerrestreAcuatica + '</option>'
            $("select#cbTerrestree").append(RowContent);
        });

        $("select#cbNacionalidad").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numericoPais + '>' + this.nombrePais + '</option>'
            $("select#cbNacionalidad").append(RowContent);
        });
        $("select#cbNacionalidade").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numericoPais + '>' + this.nombrePais + '</option>'
            $("select#cbNacionalidade").append(RowContent);
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

//function optReporte(id) {
//    optReporteSelect = id;
//    if (id == 1) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCA';
//        $('#accionAnteCiberataque').hide();
//        $('#tipoCiberataque').hide();
//        $('#fechaInicio').hide();
//        $('#fechaTermino').hide();
//    }
//    if (id == 2) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCXSSA';
//        $('#accionAnteCiberataque').show();
//        $('#tipoCiberataque').hide();
//        $('#fechaInicio').show();
//        $('#fechaTermino').show();
//    }
//    if (id == 3) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCATCA';
//        $('#tipoCiberataque').show();
//        $('#accionAnteCiberataque').hide();
//        $('#fechaInicio').show();
//        $('#fechaTermino').show();
//    }
//}

//$('#btnReportView').click(function () {
//    var idCarga = $('select#cargas').val();
//    var numCarga;
//    if (idCarga == "0") {
//        numCarga = "";
//    } else {
//        numCarga = 'CargaId=' + idCarga;
//    }
//    var a = document.createElement('a');
//    a.target = "_blank";
//    if (optReporteSelect == 1) {
//        a.href = reporteSeleccionado + '?' + numCarga;
//    }
//    if (optReporteSelect == 2) {
//        a.href = reporteSeleccionado + '?accionAnteCiberataque=' + $('#txtAccionAnteCiberA').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
//    }
//    if (optReporteSelect == 3) {
//        a.href = reporteSeleccionado + '?tipoCiberataque=' + $('#txtCiberAtaque').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
//    }
//    a.click();
//});