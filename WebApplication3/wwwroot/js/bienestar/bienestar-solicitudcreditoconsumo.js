var tblBienestarSolicitudCreditoConsumo;
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
                                url: '/BienestarSolicitudCreditoConsumo/Insertar',
                                data: {
                                    'FechaSolicitudCredito': $('#txtFechaSolicitudC').val(),
                                    'DNISolicitante': $('#txtDNISolicitante').val(),
                                    'CIPSolicitante': $('#txtCIPSolicitante').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'AnioServicio': $('#txtAnioServicio').val(),
                                    'ResultadoSolicitud': $('#txtResultadoSolicitud option:selected').val(),
                                    'CodigoEntidadFinanciera': $('#cbEntidadFinanciera').val(),
                                    'NumeroCuotas': $('#txtNumeroCuotas').val(),
                                    'ImporteCredito': $('#txtImporteCredito').val(),
                                    'TasaInteresCredito': $('#txtTasaInteresCredito').val(), 
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
                                    $('#tblBienestarSolicitudCreditoConsumo').DataTable().ajax.reload();
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
                                url: '/BienestarSolicitudCreditoConsumo/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaSolicitudCredito': $('#txtFechaSolicitudCe').val(),
                                    'DNISolicitante': $('#txtDNISolicitantee').val(),
                                    'CIPSolicitante': $('#txtCIPSolicitantee').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'AnioServicio': $('#txtAnioServicioe').val(),
                                    'ResultadoSolicitud': $('#txtResultadoSolicitude option:selected').val(),
                                    'CodigoEntidadFinanciera': $('#cbEntidadFinancierae').val(),
                                    'NumeroCuotas': $('#txtNumeroCuotase').val(),
                                    'ImporteCredito': $('#txtImporteCreditoe').val(),
                                    'TasaInteresCredito': $('#txtTasaInteresCreditoe').val(),
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
                                    $('#tblBienestarSolicitudCreditoConsumo').DataTable().ajax.reload();
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

    tblBienestarSolicitudCreditoConsumo=  $('#tblBienestarSolicitudCreditoConsumo').DataTable({
        ajax: {
            "url": '/BienestarSolicitudCreditoConsumo/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "solicitudCreditoConsumoId" },
            { "data": "fechaSolicitudCredito" },
            { "data": "dniSolicitante" },
            { "data": "cipSolicitante" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "anioServicio" },
            { "data": "resultadoSolicitud" },
            { "data": "descEntidadFinanciera" },
            { "data": "numeroCuotas" },
            { "data": "importeCredito" },
            { "data": "tasaInteresCredito" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.solicitudCreditoConsumoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.solicitudCreditoConsumoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Solicitud de Créditos por Consumo',
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
                filename: 'Bienestar - Solicitud de Créditos por Consumo',
                title: 'Bienestar - Solicitud de Créditos por Consumo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Solicitud de Créditos por Consumo',
                title: 'Bienestar - Solicitud de Créditos por Consumo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Solicitud de Créditos por Consumo',
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
    tblBienestarSolicitudCreditoConsumo.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarSolicitudCreditoConsumo.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarSolicitudCreditoConsumo/Mostrar?Id=' + Id, [], function (SolicitudCreditoConsumoDTO) {
        $('#txtCodigo').val(SolicitudCreditoConsumoDTO.solicitudCreditoConsumoId);
        $('#txtFechaSolicitudCe').val(SolicitudCreditoConsumoDTO.fechaSolicitudCredito);
        $('#txtDNISolicitantee').val(SolicitudCreditoConsumoDTO.dniSolicitante);
        $('#txtCIPSolicitantee').val(SolicitudCreditoConsumoDTO.cipSolicitante);
        $('#cbTipoPersonalMilitare').val(SolicitudCreditoConsumoDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMilitare').val(SolicitudCreditoConsumoDTO.codigoGradoPersonalMilitar);
        $('#txtAnioServicioe').val(SolicitudCreditoConsumoDTO.anioServicio);
        $('#txtResultadoSolicitude').val(SolicitudCreditoConsumoDTO.resultadoSolicitud);
        $('#cbEntidadFinancierae').val(SolicitudCreditoConsumoDTO.codigoEntidadFinanciera);
        $('#txtNumeroCuotase').val(SolicitudCreditoConsumoDTO.numeroCuotas);
        $('#txtImporteCreditoe').val(SolicitudCreditoConsumoDTO.importeCredito);
        $('#txtTasaInteresCreditoe').val(SolicitudCreditoConsumoDTO.tasaInteresCredito);
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
                url: '/BienestarSolicitudCreditoConsumo/Eliminar',
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
                    $('#tblBienestarSolicitudCreditoConsumo').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarSolicitudCreditoConsumo() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarSolicitudCreditoConsumo/MostrarDatos',
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
                            $("<td>").text(item.fechaSolicitudCredito),
                            $("<td>").text(item.dniSolicitante),
                            $("<td>").text(item.cipSolicitante),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.anioServicio),
                            $("<td>").text(item.resultadoSolicitud),
                            $("<td>").text(item.codigoEntidadFinanciera),
                            $("<td>").text(item.numeroCuotas),
                            $("<td>").text(item.importeCredito),
                            $("<td>").text(item.tasaInteresCredito)
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
    fetch("BienestarSolicitudCreditoConsumo/EnviarDatos", {
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
                url: '/BienestarSolicitudCreditoConsumo/EliminarCarga',
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
                    $('#tblBienestarSolicitudCreditoConsumo').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarSolicitudCreditoConsumo/cargaCombs', [], function (Json) {
        var tipoPersonalMilitar = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var entidadFinanciera = Json["data3"];
        var listaCargas = Json["data4"];

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

        $("select#cbEntidadFinanciera").html("");
        $("select#cbEntidadFinancierae").html("");
        $.each(entidadFinanciera, function () {
            var RowContent = '<option value=' + this.codigoEntidadFinanciera + '>' + this.descEntidadFinanciera + '</option>'
            $("select#cbEntidadFinanciera").append(RowContent);
            $("select#cbEntidadFinancierae").append(RowContent);
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
        reporteSeleccionado = '/BienestarSolicitudCreditoConsumo/ReporteBSCC?idCarga=';
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