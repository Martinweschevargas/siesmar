var tblDicapiExpTransporteMercanciaSustancia;
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
                                url: '/DicapiExpTransporteMercanciaSustancia/Insertar',
                                data: {
                                    'NumeroDocumento': $('#txtNumero').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngreso').val(),
                                    'CodigoDptoMercanciaPeligrosa': $('#cbDptoMaterial').val(),
                                    'DocumentoExpedido': $('#txtDocumento').val(),
                                    'NombreNave': $('#txtNave').val(),
                                    'PropietarioNave': $('#txtPropietario').val(),
                                    'RazonSocial': $('#txtRazon').val(),
                                    'CodigoClaseNave': $('#cbClase').val(),
                                    'MatriculaNave': $('#txtMatricula').val(),
                                    'NumericoPais': $('#cbNacionalidad').val(),
                                    'FechaAtencionSolicitud': $('#txtFechaAtencion').val(),
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
                                    $('#tblDicapiExpTransporteMercanciaSustancia').DataTable().ajax.reload();
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
                                url: '/DicapiExpTransporteMercanciaSustancia/Actualizar',
                                data: {

                                    'ExpTransporteMercanciaSustanciaId': $('#txtCodigo').val(),
                                    'NumeroDocumento': $('#txtNumeroe').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngresoe').val(),
                                    'CodigoDptoMercanciaPeligrosa': $('#cbDptoMateriale').val(),
                                    'DocumentoExpedido': $('#txtDocumentoe').val(),
                                    'NombreNave': $('#txtNavee').val(),
                                    'PropietarioNave': $('#txtPropietarioe').val(),
                                    'RazonSocial': $('#txtRazone').val(),
                                    'CodigoClaseNave': $('#cbClasee').val(),
                                    'MatriculaNave': $('#txtMatriculae').val(),
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
                                    $('#tblDicapiExpTransporteMercanciaSustancia').DataTable().ajax.reload();
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

    $('#tblDicapiExpTransporteMercanciaSustancia').DataTable({
        ajax: {
            "url": '/DicapiExpTransporteMercanciaSustancia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "expTransporteMercanciaSustanciaId" },
            { "data": "numeroDocumento" },
            { "data": "fechaIngresoSolicitud" },
            { "data": "descDptoMercanciaPeligrosa" },
            { "data": "documentoExpedido" },
            { "data": "nombreNave" },
            { "data": "propietarioNave" },
            { "data": "razonSocial" },   
            { "data": "descClaseNave" },  
            { "data": "matriculaNave" }, 
            { "data": "nombrePais" },
            { "data": "fechaAtencionSolicitud" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.expTransporteMercanciaSustanciaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.expTransporteMercanciaSustanciaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dicapi - Expedición de Documentos para el Transporte Marítimo de Mercancías y Sustancias Peligrosas',
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
                filename: 'Dicapi - Expedición de Documentos para el Transporte Marítimo de Mercancías y Sustancias Peligrosas',
                title: 'Dicapi - Expedición de Documentos para el Transporte Marítimo de Mercancías y Sustancias Peligrosas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dicapi - Expedición de Documentos para el Transporte Marítimo de Mercancías y Sustancias Peligrosas',
                title: 'Dicapi - Expedición de Documentos para el Transporte Marítimo de Mercancías y Sustancias Peligrosas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dicapi - Expedición de Documentos para el Transporte Marítimo de Mercancías y Sustancias Peligrosas',
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
    $.getJSON('/DicapiExpTransporteMercanciaSustancia/Mostrar?Id=' + Id, [], function (ExpTransporteMercanciaSustanciaDTO) {
        $('#txtCodigo').val(ExpTransporteMercanciaSustanciaDTO.expTransporteMercanciaSustanciaId);
        $('#txtNumeroe').val(ExpTransporteMercanciaSustanciaDTO.numeroDocumento);
        $('#txtFechaIngresoe').val(ExpTransporteMercanciaSustanciaDTO.fechaIngresoSolicitud);
        $('#cbDptoMateriale').val(ExpTransporteMercanciaSustanciaDTO.codigoDptoMercanciaPeligrosa);
        $('#txtDocumentoe').val(ExpTransporteMercanciaSustanciaDTO.documentoExpedido);
        $('#txtNavee').val(ExpTransporteMercanciaSustanciaDTO.nombreNave);
        $('#txtPropietarioe').val(ExpTransporteMercanciaSustanciaDTO.propietarioNave);
        $('#txtRazone').val(ExpTransporteMercanciaSustanciaDTO.razonSocial);
        $('#cbClasee').val(ExpTransporteMercanciaSustanciaDTO.codigoClaseNave);
        $('#txtMatriculae').val(ExpTransporteMercanciaSustanciaDTO.matriculaNave);
        $('#cbNacionalidade').val(ExpTransporteMercanciaSustanciaDTO.numericoPais);
        $('#txtFechaAtencione').val(ExpTransporteMercanciaSustanciaDTO.fechaAtencionSolicitud);
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
                url: '/DicapiExpTransporteMercanciaSustancia/Eliminar',
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
                    $('#tblDicapiExpTransporteMercanciaSustancia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDicapiExpTransporteMercanciaSustancia() {
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
    $.getJSON('/DicapiExpTransporteMercanciaSustancia/cargaCombs', [], function (Json) {
        var dptoMercanciaPeligrosa = Json["data1"];
        var claseNave = Json["data2"];
        var paisUbigeo = Json["data3"];
        var listaCargas = Json["data4"];


        $("select#cbDptoMaterial").html("");
        $.each(dptoMercanciaPeligrosa, function () {
            var RowContent = '<option value=' + this.codigoDptoMercanciaPeligrosa + '>' + this.descDptoMercanciaPeligrosa + '</option>'
            $("select#cbDptoMaterial").append(RowContent);
        });
        $("select#cbDptoMateriale").html("");
        $.each(dptoMercanciaPeligrosa, function () {
            var RowContent = '<option value=' + this.codigoDptoMercanciaPeligrosa + '>' + this.descDptoMercanciaPeligrosa + '</option>'
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

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCA';
        $('#accionAnteCiberataque').hide();
        $('#tipoCiberataque').hide();
        $('#fechaInicio').hide();
        $('#fechaTermino').hide();
    }
    if (id == 2) {
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCXSSA';
        $('#accionAnteCiberataque').show();
        $('#tipoCiberataque').hide();
        $('#fechaInicio').show();
        $('#fechaTermino').show();
    }
    if (id == 3) {
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCATCA';
        $('#tipoCiberataque').show();
        $('#accionAnteCiberataque').hide();
        $('#fechaInicio').show();
        $('#fechaTermino').show();
    }
}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var numCarga;
    if (idCarga == "0") {
        numCarga = "";
    } else {
        numCarga = 'CargaId=' + idCarga;
    }
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect == 1) {
        a.href = reporteSeleccionado + '?' + numCarga;
    }
    if (optReporteSelect == 2) {
        a.href = reporteSeleccionado + '?accionAnteCiberataque=' + $('#txtAccionAnteCiberA').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
    }
    if (optReporteSelect == 3) {
        a.href = reporteSeleccionado + '?tipoCiberataque=' + $('#txtCiberAtaque').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
    }
    a.click();
});