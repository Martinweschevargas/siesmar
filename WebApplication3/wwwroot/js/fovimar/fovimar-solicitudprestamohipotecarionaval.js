var tblFovimarSolicitudPrestamoHipotecarioNaval;
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
                                url: '/FovimarSolicitudPrestamoHipotecarioNaval/Insertar',
                                data: {
                                    'DNIPersonalNaval': $('#txtDNI').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGrado').val(),
                                    'CodigoSituacionPersonalNaval': $('#cbSituacion').val(),
                                    'Prestario': $('#txtPrestario').val(),
                                    'MontoSolicitado': $('#txtMonto').val(),
                                    'CodigoMoneda': $('#cbMoneda').val(),
                                    'FechaSolicitud': $('#txtFechaSoli').val(),
                                    'AprobacionSolicitud': $('#txtAprobacion').val(),
                                    'FechaAprobacion': $('#txtFechaApro').val(),
                                    'FechaDesembolso': $('#txtFechaDese').val(),
                                    'NroCuota': $('#txtCuotas').val(),
                                    'CodigoModalidadPrestamo': $('#cbModalidad').val(),
                                    'CodigoFinalidadPrestamo': $('#cbFinalidad').val(),
                                    'CodigoEntidadFinanciera': $('#cbEntidad').val(),
                                    'RentabilidadFinanciera': $('#txtRentabilidad').val(),
                                    'CodigoProyectoFovimar': $('#cbProyecto').val(),
                                    'EstadoSolicitudPrestamo': $('#txtEstadoSoli').val(),
                                    'GarantiaConstituida': $('#txtGarantia').val(), 
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
                                    $('#tblFovimarSolicitudPrestamoHipotecarioNaval').DataTable().ajax.reload();
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
                                url: '/FovimarSolicitudPrestamoHipotecarioNaval/Actualizar',
                                data: {

                                    'SolicitudPrestamoHipotecarioNavalId': $('#txtCodigo').val(),
                                    'DNIPersonalNaval': $('#txtDNIe').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoe').val(),
                                    'CodigoSituacionPersonalNaval': $('#cbSituacione').val(),
                                    'Prestario': $('#txtPrestarioe').val(),
                                    'MontoSolicitado': $('#txtMontoe').val(),
                                    'CodigoMoneda': $('#cbMonedae').val(),
                                    'FechaSolicitud': $('#txtFechaSolie').val(),
                                    'AprobacionSolicitud': $('#txtAprobacione').val(),
                                    'FechaAprobacion': $('#txtFechaAproe').val(),
                                    'FechaDesembolso': $('#txtFechaDesee').val(),
                                    'NroCuota': $('#txtCuotase').val(),
                                    'CodigoModalidadPrestamo': $('#cbModalidade').val(),
                                    'CodigoFinalidadPrestamo': $('#cbFinalidade').val(),
                                    'CodigoEntidadFinanciera': $('#cbEntidade').val(),
                                    'RentabilidadFinanciera': $('#txtRentabilidade').val(),
                                    'CodigoProyectoFovimar': $('#cbProyectoe').val(),
                                    'EstadoSolicitudPrestamo': $('#txtEstadoSolie').val(),
                                    'GarantiaConstituida': $('#txtGarantiae').val(), 
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
                                    $('#tblFovimarSolicitudPrestamoHipotecarioNaval').DataTable().ajax.reload();
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

   tblFovimarSolicitudPrestamoHipotecarioNaval= $('#tblFovimarSolicitudPrestamoHipotecarioNaval').DataTable({
        ajax: {
            "url": '/FovimarSolicitudPrestamoHipotecarioNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "solicitudPrestamoHipotecarioNavalId" },
            { "data": "dniPersonalNaval" },
            { "data": "descGrado" },
            { "data": "descSituacionPersonalNaval" },
            { "data": "prestario" },
            { "data": "montoSolicitado" },
            { "data": "descMoneda" },
            { "data": "fechaSolicitud" },   
            { "data": "aprobacionSolicitud" },  
            { "data": "fechaAprobacion" }, 
            { "data": "fechaDesembolso" },
            { "data": "nroCuota" },  
            { "data": "descModalidadPrestamo" },
            { "data": "descFinalidadPrestamo" },  
            { "data": "descEntidadFinanciera" }, 
            { "data": "rentabilidadFinanciera" },
            { "data": "descProyectoFovimar" },
            { "data": "estadoSolicitudPrestamo" },
            { "data": "garantiaConstituida" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.solicitudPrestamoHipotecarioNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.solicitudPrestamoHipotecarioNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Fovimar - Expedición de Documentos de Naves y Artefactos Navales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Fovimar - Solicitud de Préstamos Hipotecarios del Personal Naval',
                title: 'Fovimar - Solicitud de Préstamos Hipotecarios del Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Fovimar - Solicitud de Préstamos Hipotecarios del Personal Naval',
                title: 'Fovimar - Solicitud de Préstamos Hipotecarios del Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Fovimar - Solicitud de Préstamos Hipotecarios del Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
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
    tblFovimarSolicitudPrestamoHipotecarioNaval.columns(19).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblFovimarSolicitudPrestamoHipotecarioNaval.columns(19).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/FovimarSolicitudPrestamoHipotecarioNaval/Mostrar?Id=' + Id, [], function (SolicitudPrestamoHipotecarioNavalDTO) {
        $('#txtCodigo').val(SolicitudPrestamoHipotecarioNavalDTO.solicitudPrestamoHipotecarioNavalId);
        $('#txtDNIe').val(SolicitudPrestamoHipotecarioNavalDTO.dniPersonalNaval);
        $('#cbGradoe').val(SolicitudPrestamoHipotecarioNavalDTO.codigoGradoPersonalMilitar);
        $('#cbSituacione').val(SolicitudPrestamoHipotecarioNavalDTO.codigoSituacionPersonalNaval);
        $('#txtPrestarioe').val(SolicitudPrestamoHipotecarioNavalDTO.prestario);
        $('#txtMontoe').val(SolicitudPrestamoHipotecarioNavalDTO.montoSolicitado);
        $('#cbMonedae').val(SolicitudPrestamoHipotecarioNavalDTO.codigoMoneda);
        $('#txtFechaSolie').val(SolicitudPrestamoHipotecarioNavalDTO.fechaSolicitud);
        $('#txtAprobacione').val(SolicitudPrestamoHipotecarioNavalDTO.aprobacionSolicitud);
        $('#txtFechaAproe').val(SolicitudPrestamoHipotecarioNavalDTO.fechaAprobacion);
        $('#txtFechaDesee').val(SolicitudPrestamoHipotecarioNavalDTO.fechaDesembolso);
        $('#txtCuotase').val(SolicitudPrestamoHipotecarioNavalDTO.nroCuota);
        $('#cbModalidade').val(SolicitudPrestamoHipotecarioNavalDTO.codigoModalidadPrestamo);
        $('#cbFinalidade').val(SolicitudPrestamoHipotecarioNavalDTO.codigoFinalidadPrestamo);
        $('#cbEntidade').val(SolicitudPrestamoHipotecarioNavalDTO.codigoEntidadFinanciera);
        $('#txtRentabilidade').val(SolicitudPrestamoHipotecarioNavalDTO.rentabilidadFinanciera);
        $('#cbProyectoe').val(SolicitudPrestamoHipotecarioNavalDTO.codigoProyectoFovimar);
        $('#txtEstadoSolie').val(SolicitudPrestamoHipotecarioNavalDTO.estadoSolicitudPrestamo);
        $('#txtGarantiae').val(SolicitudPrestamoHipotecarioNavalDTO.garantiaConstituida); 
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
                url: '/FovimarSolicitudPrestamoHipotecarioNaval/Eliminar',
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
                    $('#tblFovimarSolicitudPrestamoHipotecarioNaval').DataTable().ajax.reload();
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
                url: '/FovimarSolicitudPrestamoHipotecarioNaval/EliminarCarga',
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
                    $('#tblFovimarSolicitudPrestamoHipotecarioNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaFovimarSolicitudPrestamoHipotecarioNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'FovimarSolicitudPrestamoHipotecarioNaval/MostrarDatos',
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
                            $("<td>").text(item.dniPersonalNaval),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoSituacionPersonalNaval),
                            $("<td>").text(item.prestario),
                            $("<td>").text(item.montoSolicitado),
                            $("<td>").text(item.codigoMoneda),
                            $("<td>").text(item.fechaSolicitud),
                            $("<td>").text(item.aprobacionSolicitud),
                            $("<td>").text(item.fechaAprobacion),
                            $("<td>").text(item.fechaDesembolso),
                            $("<td>").text(item.nroCuota),
                            $("<td>").text(item.codigoModalidadPrestamo),
                            $("<td>").text(item.codigoFinalidadPrestamo),
                            $("<td>").text(item.codigoEntidadFinanciera),
                            $("<td>").text(item.rentabilidadFinanciera),
                            $("<td>").text(item.codigoProyectoFovimar),
                            $("<td>").text(item.estadoSolicitudPrestamo),
                            $("<td>").text(item.garantiaConstituida)
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
    fetch("FovimarSolicitudPrestamoHipotecarioNaval/EnviarDatos", {
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
    $.getJSON('/FovimarSolicitudPrestamoHipotecarioNaval/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var moneda = Json["data2"];
        var situacionPersonalNaval = Json["data3"];
        var modalidadPrestamo = Json["data4"];
        var finalidadPrestamo = Json["data5"];
        var entidadFinanciera = Json["data6"];
        var proyectoFovimar = Json["data7"];
        var listaCargas = Json["data8"];

        $("select#cbGrado").html("");
        $("select#cbGradoe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGrado").append(RowContent);
            $("select#cbGradoe").append(RowContent);
        });

        $("select#cbMoneda").html("");
        $("select#cbMonedae").html("");
        $.each(moneda, function () {
            var RowContent = '<option value=' + this.codigoMoneda + '>' + this.descMoneda + '</option>'
            $("select#cbMoneda").append(RowContent);
            $("select#cbMonedae").append(RowContent);
        });

        $("select#cbSituacion").html("");
        $("select#cbSituacione").html("");
        $.each(situacionPersonalNaval, function () {
            var RowContent = '<option value=' + this.codigoSituacionPersonalNaval + '>' + this.descSituacionPersonalNaval + '</option>'
            $("select#cbSituacion").append(RowContent);
            $("select#cbSituacione").append(RowContent);
        });

        $("select#cbModalidad").html("");
        $("select#cbModalidade").html("");
        $.each(modalidadPrestamo, function () {
            var RowContent = '<option value=' + this.codigoModalidadPrestamo + '>' + this.descModalidadPrestamo + '</option>'
            $("select#cbModalidad").append(RowContent);
            $("select#cbModalidade").append(RowContent);
        });

        $("select#cbFinalidad").html("");
        $("select#cbFinalidade").html("");
        $.each(finalidadPrestamo, function () {
            var RowContent = '<option value=' + this.codigoFinalidadPrestamo + '>' + this.descFinalidadPrestamo + '</option>'
            $("select#cbFinalidad").append(RowContent);
            $("select#cbFinalidade").append(RowContent);
        });

        $("select#cbEntidad").html("");
        $("select#cbEntidade").html("");
        $.each(entidadFinanciera, function () {
            var RowContent = '<option value=' + this.codigoEntidadFinanciera + '>' + this.descEntidadFinanciera + '</option>'
            $("select#cbEntidad").append(RowContent);
            $("select#cbEntidade").append(RowContent);
        });

        $("select#cbProyecto").html("");
        $("select#cbProyectoe").html("");
        $.each(proyectoFovimar, function () {
            var RowContent = '<option value=' + this.codigoProyectoFovimar + '>' + this.descProyectoFovimar + '</option>'
            $("select#cbProyecto").append(RowContent);
            $("select#cbProyectoe").append(RowContent);
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

    reporteSeleccionado = '/FovimarSolicitudPrestamoHipotecarioNaval/ReporteSPHN';
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