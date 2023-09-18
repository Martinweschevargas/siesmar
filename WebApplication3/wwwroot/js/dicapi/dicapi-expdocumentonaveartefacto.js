var tblDicapiExpDocumentoNaveArtefacto;
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
                                url: '/DicapiExpDocumentoNaveArtefacto/Insertar',
                                data: {
                                    'NumeroDocumento': $('#txtNumero').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngreso').val(),
                                    'CodigoDptoMaterialAcuatico': $('#cbDptoMaterial').val(),
                                    'NombreNaveArtefacto': $('#txtNombre').val(),
                                    'PropietarioNave': $('#txtPropietario').val(),
                                    'RazonSocial': $('#txtRazon').val(),
                                    'CodigoClaseNave': $('#cbTipo').val(),
                                    'MatriculaNave': $('#txtMatricula').val(),
                                    'NumericoPais': $('#cbNacionalidad').val(),
                                    'FechaAtencionSolicitud': $('#txtFechaAtencion').val(),
                                    'Observacion': $('#txtObservacion').val(),
                                    'ResponsableDocumentoExpedido': $('#txtResponsable').val(),
                                    'CodigoCapitania': $('#cbCapitania').val(),
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
                                    $('#tblDicapiExpDocumentoNaveArtefacto').DataTable().ajax.reload();
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
                                url: '/DicapiExpDocumentoNaveArtefacto/Actualizar',
                                data: {

                                    'ExpDocumentoNaveArtefactoId': $('#txtCodigo').val(),
                                    'NumeroDocumento': $('#txtNumeroe').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngresoe').val(),
                                    'CodigoDptoMaterialAcuatico': $('#cbDptoMateriale').val(),
                                    'NombreNaveArtefacto': $('#txtNombree').val(),
                                    'PropietarioNave': $('#txtPropietarioe').val(),
                                    'RazonSocial': $('#txtRazone').val(),
                                    'CodigoClaseNave': $('#cbTipoe').val(),
                                    'MatriculaNave': $('#txtMatriculae').val(),
                                    'NumericoPais': $('#cbNacionalidade').val(),
                                    'FechaAtencionSolicitud': $('#txtFechaAtencione').val(),
                                    'Observacion': $('#txtObservacione').val(),
                                    'ResponsableDocumentoExpedido': $('#txtResponsablee').val(),
                                    'CodigoCapitania': $('#cbCapitaniae').val(), 
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
                                    $('#tblDicapiExpDocumentoNaveArtefacto').DataTable().ajax.reload();
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

  tblDicapiExpDocumentoNaveArtefacto =  $('#tblDicapiExpDocumentoNaveArtefacto').DataTable({
        ajax: {
            "url": '/DicapiExpDocumentoNaveArtefacto/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "expDocumentoNaveArtefactoId" },
            { "data": "numeroDocumento" },
            { "data": "fechaIngresoSolicitud" },
            { "data": "descDptoMaterialAcuatico" },
            { "data": "documentoExpedido" },
            { "data": "nombreNaveArtefacto" },
            { "data": "propietarioNave" },
            { "data": "razonSocial" },
            { "data": "descClaseNave" },
            { "data": "matriculaNave" },
            { "data": "nombrePais" },
            { "data": "fechaAtencionSolicitud" },
            { "data": "observacion" },
            { "data": "responsableDocumentoExpedido" },
            { "data": "descCapitania" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.expDocumentoNaveArtefactoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.expDocumentoNaveArtefactoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dicapi - Expedición de Documentos de Naves y Artefactos Navales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dicapi - Expedición de Documentos de Naves y Artefactos Navales',
                title: 'Dicapi - Expedición de Documentos de Naves y Artefactos Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dicapi - Expedición de Documentos de Naves y Artefactos Navales',
                title: 'Dicapi - Expedición de Documentos de Naves y Artefactos Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dicapi - Expedición de Documentos de Naves y Artefactos Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
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
    tblDicapiExpDocumentoNaveArtefacto.columns(15).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDicapiExpDocumentoNaveArtefacto.columns(15).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DicapiExpDocumentoNaveArtefacto/Mostrar?Id=' + Id, [], function (ExpDocumentoNaveArtefactoDTO) {
        $('#txtCodigo').val(ExpDocumentoNaveArtefactoDTO.expDocumentoNaveArtefactoId);
        $('#txtNumeroe').val(ExpDocumentoNaveArtefactoDTO.numeroDocumento);
        $('#txtFechaIngresoe').val(ExpDocumentoNaveArtefactoDTO.fechaIngresoSolicitud);
        $('#cbDptoMateriale').val(ExpDocumentoNaveArtefactoDTO.codigoDptoMaterialAcuatico);
        $('#txtNombree').val(ExpDocumentoNaveArtefactoDTO.nombreNaveArtefacto);
        $('#txtPropietarioe').val(ExpDocumentoNaveArtefactoDTO.propietarioNave);
        $('#txtRazone').val(ExpDocumentoNaveArtefactoDTO.razonSocial);
        $('#cbTipoe').val(ExpDocumentoNaveArtefactoDTO.codigoClaseNave);
        $('#txtMatriculae').val(ExpDocumentoNaveArtefactoDTO.matriculaNave);
        $('#cbNacionalidade').val(ExpDocumentoNaveArtefactoDTO.numericoPais);
        $('#txtFechaAtencione').val(ExpDocumentoNaveArtefactoDTO.fechaAtencionSolicitud);
        $('#txtObservacione').val(ExpDocumentoNaveArtefactoDTO.observacion);
        $('#txtResponsablee').val(ExpDocumentoNaveArtefactoDTO.responsableDocumentoExpedido);
        $('#cbCapitaniae').val(ExpDocumentoNaveArtefactoDTO.codigoCapitania); 
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
                url: '/DicapiExpDocumentoNaveArtefacto/Eliminar',
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
                    $('#tblDicapiExpDocumentoNaveArtefacto').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDicapiExpDocumentoNaveArtefacto() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DicapiExpDocumentoNaveArtefacto/MostrarDatos',
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
                            $("<td>").text(item.numeroDocumento),
                            $("<td>").text(item.fechaIngresoSolicitud),
                            $("<td>").text(item.codigoDptoMaterialAcuatico),
                            $("<td>").text(item.descDptoMaterialAcuatico),
                            $("<td>").text(item.nombreNaveArtefacto),
                            $("<td>").text(item.propietarioNave),
                            $("<td>").text(item.razonSocial),
                            $("<td>").text(item.codigoClaseNave),
                            $("<td>").text(item.matriculaNave),
                            $("<td>").text(item.numericoPais),
                            $("<td>").text(item.FechaAtencionSolicitud),
                            $("<td>").text(item.observacion),
                            $("<td>").text(item.responsableDocumentoExpedido),
                            $("<td>").text(item.codigoCapitania)
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
    fetch("DicapiExpDocumentoNaveArtefacto/EnviarDatos", {
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
    $.getJSON('/DicapiExpDocumentoNaveArtefacto/cargaCombs', [], function (Json) {
        var dptoMaterialAcuatico = Json["data1"];
        var claseNave = Json["data2"];
        var paisUbigeo = Json["data3"];
        var capitania = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbDptoMaterial").html("");
        $("select#cbDptoMateriale").html("");
        $.each(dptoMaterialAcuatico, function () {
            var RowContent = '<option value=' + this.codigoDptoMaterialAcuatico + '>' + this.descDptoMaterialAcuatico + '</option>'
            $("select#cbDptoMaterial").append(RowContent);
            $("select#cbDptoMateriale").append(RowContent);
        });

        $("select#cbTipo").html("");
        $("select#cbTipoe").html("");
        $.each(claseNave, function () {
            var RowContent = '<option value=' + this.codigoClaseNave + '>' + this.descClaseNave + '</option>'
            $("select#cbTipo").append(RowContent);
            $("select#cbTipoe").append(RowContent);
        });

        $("select#cbNacionalidad").html("");
        $("select#cbNacionalidade").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numericoPais + '>' + this.nombrePais + '</option>'
            $("select#cbNacionalidad").append(RowContent);
            $("select#cbNacionalidade").append(RowContent);
        });
        

        $("select#cbCapitania").html("");
         $("select#cbCapitaniae").html("");
        $.each(capitania, function () {
            var RowContent = '<option value=' + this.codigoCapitania + '>' + this.descCapitania + '</option>'
            $("select#cbCapitania").append(RowContent);
            $("select#cbCapitaniae").append(RowContent);
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