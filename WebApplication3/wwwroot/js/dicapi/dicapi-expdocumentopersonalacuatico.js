var tblDicapiExpDocumentoPersonalAcuatico;
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
                                url: '/DicapiExpDocumentoPersonalAcuatico/Insertar',
                                data: {
                                    'Anio': $('#txtAnio').val(),
                                    'NumeroDocumento': $('#txtNumero').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngreso').val(),
                                    'CodigoDptoPersonalAcuatico': $('#cbDptoAcuatico').val(),
                                    'DocumentoExpedido': $('#txtDocumento').val(),
                                    'ExpedidoA': $('#txtExpedido').val(),
                                    'NombreApellidoAcuatico': $('#cbNombreApellido').val(),
                                    'CodigoTipoPersonalAcuatico': $('#cbPersonal').val(),
                                    'CodigoTipoActividadEmpresa': $('#cbActividad').val(),
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
                                    $('#tblDicapiExpDocumentoPersonalAcuatico').DataTable().ajax.reload();
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
                                url: '/DicapiExpDocumentoPersonalAcuatico/Actualizar',
                                data: {
                                    'ExpDocumentoPersonalAcuaticoId': $('#txtCodigo').val(),
                                    'NumeroDocumento': $('#txtNumeroe').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngresoe').val(),
                                    'CodigoDptoPersonalAcuatico': $('#cbDptoAcuaticoe').val(),
                                    'DocumentoExpedido': $('#txtDocumentoe').val(),
                                    'ExpedidoA': $('#txtExpedidoe').val(),
                                    'NombreApellidoAcuatico': $('#cbNombreApellidoe').val(),
                                    'CodigoTipoPersonalAcuatico': $('#cbPersonale').val(),
                                    'CodigoTipoActividadEmpresa': $('#cbActividade').val(),
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
                                    $('#tblDicapiExpDocumentoPersonalAcuatico').DataTable().ajax.reload();
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

    tblDicapiExpDocumentoPersonalAcuatico = $('#tblDicapiExpDocumentoPersonalAcuatico').DataTable({
        ajax: {
            "url": '/DicapiExpDocumentoPersonalAcuatico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "expDocumentoPersonalAcuaticoId" },
            { "data": "numeroDocumento" },
            { "data": "fechaIngresoSolicitud" },
            { "data": "descDptoPersonalAcuatico" },
            { "data": "documentoExpedido" },
            { "data": "expedidoA" },
            { "data": "nombreApellidoAcuatico" },
            { "data": "descTipoPersonalAcuatico" },   
            { "data": "descTipoActividadEmpresa" },  
            { "data": "fechaAtencionSolicitud" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.expDocumentoPersonalAcuaticoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.expDocumentoPersonalAcuaticoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dicapi - Expedición de Documentos al Personal Acuatico',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dicapi - Expedición de Documentos al Personal Acuatico',
                title: 'Dicapi - Expedición de Documentos al Personal Acuatico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dicapi - Expedición de Documentos al Personal Acuatico',
                title: 'Dicapi - Expedición de Documentos al Personal Acuatico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dicapi - Expedición de Documentos al Personal Acuatico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
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
    $.getJSON('/DicapiExpDocumentoPersonalAcuatico/Mostrar?Id=' + Id, [], function (ExpDocumentoPersonalAcuaticoDTO) {
        $('#txtCodigo').val(ExpDocumentoPersonalAcuaticoDTO.expDocumentoPersonalAcuaticoId);
        $('#txtNumeroe').val(ExpDocumentoPersonalAcuaticoDTO.numeroDocumento);
        $('#txtFechaIngresoe').val(ExpDocumentoPersonalAcuaticoDTO.fechaIngresoSolicitud);
        $('#cbDptoAcuaticoe').val(ExpDocumentoPersonalAcuaticoDTO.codigoDptoPersonalAcuatico);
        $('#txtDocumentoe').val(ExpDocumentoPersonalAcuaticoDTO.documentoExpedido);
        $('#txtExpedidoe').val(ExpDocumentoPersonalAcuaticoDTO.expedidoA);
        $('#cbNombreApellidoe').val(ExpDocumentoPersonalAcuaticoDTO.nombreApellidoAcuatico);
        $('#cbPersonale').val(ExpDocumentoPersonalAcuaticoDTO.codigoTipoPersonalAcuatico);
        $('#cbActividade').val(ExpDocumentoPersonalAcuaticoDTO.codigoTipoActividadEmpresa);
        $('#txtFechaAtencione').val(ExpDocumentoPersonalAcuaticoDTO.fechaAtencionSolicitud); 
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
                url: '/DicapiExpDocumentoPersonalAcuatico/Eliminar',
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
                    $('#tblDicapiExpDocumentoPersonalAcuatico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDicapiExpDocumentoPersonalAcuatico() {
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
    $.getJSON('/DicapiExpDocumentoPersonalAcuatico/cargaCombs', [], function (Json) {
        var dptoPersonalAcuatico = Json["data1"];
        var tipoPersonalAcuatico = Json["data2"];
        var tipoActividadEmpresa = Json["data3"];
        var listaCargas = Json["data4"];


        $("select#cbDptoAcuatico").html("");
        $.each(dptoPersonalAcuatico, function () {
            var RowContent = '<option value=' + this.codigoDptoPersonalAcuatico + '>' + this.descDptoPersonalAcuatico + '</option>'
            $("select#cbDptoAcuatico").append(RowContent);
        });
        $("select#cbDptoAcuaticoe").html("");
        $.each(dptoPersonalAcuatico, function () {
            var RowContent = '<option value=' + this.codigoDptoPersonalAcuatico + '>' + this.descDptoPersonalAcuatico + '</option>'
            $("select#cbDptoAcuaticoe").append(RowContent);
        });

        $("select#cbPersonal").html("");
        $.each(tipoPersonalAcuatico, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalAcuatico + '>' + this.descTipoPersonalAcuatico + '</option>'
            $("select#cbPersonal").append(RowContent);
        });
        $("select#cbPersonale").html("");
        $.each(tipoPersonalAcuatico, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalAcuatico + '>' + this.descTipoPersonalAcuatico + '</option>'
            $("select#cbPersonale").append(RowContent);
        });

        $("select#cbActividad").html("");
        $.each(tipoActividadEmpresa, function () {
            var RowContent = '<option value=' + this.codigoTipoActividadEmpresa + '>' + this.descTipoActividadEmpresa + '</option>'
            $("select#cbActividad").append(RowContent);
        });
        $("select#cbActividade").html("");
        $.each(tipoActividadEmpresa, function () {
            var RowContent = '<option value=' + this.codigoTipoActividadEmpresa + '>' + this.descTipoActividadEmpresa + '</option>'
            $("select#cbActividade").append(RowContent);
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

