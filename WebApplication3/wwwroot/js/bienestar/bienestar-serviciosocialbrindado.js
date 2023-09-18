var tblBienestarServicioSocialBrindado;
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
                                url: '/BienestarServicioSocialBrindado/Insertar',
                                data: {
                                    'FechaSolicitud': $('#txtFechaSolicitud').val(),
                                    'DNIPersonal': $('#txtDNIPersonal').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitante').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitante').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiado').val(),
                                    'CodigoTipoApoyoSocial': $('#cbTipoApoyoSocial').val(),
                                    'CodigoTipoAtencion': $('#cbTipoAtencion').val(),
                                    'CodigoTipoEvaluacionSocial': $('#cbTipoEvaluacionSocial').val(),
                                    'OtroTipoApoyo': $('#txtOtroTipoApoyo option:selected').val(),
                                    'ResultadoSolicitud': $('#txtResultadoSolicitud option:selected').val(),
                                    'FechaResultadoSolicitud': $('#txtFechaResultadoSolicitud').val(), 
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
                                    $('#tblBienestarServicioSocialBrindado').DataTable().ajax.reload();
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
                                url: '/BienestarServicioSocialBrindado/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaSolicitud': $('#txtFechaSolicitude').val(),
                                    'DNIPersonal': $('#txtDNIPersonale').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitantee').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitantee').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiadoe').val(),
                                    'CodigoTipoApoyoSocial': $('#cbTipoApoyoSociale').val(),
                                    'CodigoTipoAtencion': $('#cbTipoAtencione').val(),
                                    'CodigoTipoEvaluacionSocial': $('#cbTipoEvaluacionSociale').val(),
                                    'OtroTipoApoyo': $('#txtOtroTipoApoyoe option:selected').val(),
                                    'ResultadoSolicitud': $('#txtResultadoSolicitude option:selected').val(),
                                    'FechaResultadoSolicitud': $('#txtFechaResultadoSolicitude').val(), 
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
                                    $('#tblBienestarServicioSocialBrindado').DataTable().ajax.reload();
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


    tblBienestarServicioSocialBrindado=  $('#tblBienestarServicioSocialBrindado').DataTable({
        ajax: {
            "url": '/BienestarServicioSocialBrindado/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioSocialBrindadoId" },
            { "data": "fechaSolicitud" },
            { "data": "dniPersonal" },
            { "data": "descPersonalSolicitante" },
            { "data": "descCondicionSolicitante" },
            { "data": "descPersonalBeneficiado" },
            { "data": "descTipoApoyoSocial" },
            { "data": "descTipoAtencion" },
            { "data": "descTipoEvaluacionSocial" },
            { "data": "otroTipoApoyo" },
            { "data": "resultadoSolicitud" },
            { "data": "fechaResultadoSolicitud" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioSocialBrindadoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioSocialBrindadoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Servicio Social Brindado al Personal',
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
                filename: 'Bienestar - Servicio Social Brindado al Personal',
                title: 'Bienestar - Servicio Social Brindado al Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Servicio Social Brindado al Personal',
                title: 'Bienestar - Servicio Social Brindado al Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Servicio Social Brindado al Personal',
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
    tblBienestarServicioSocialBrindado.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarServicioSocialBrindado.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarServicioSocialBrindado/Mostrar?Id=' + Id, [], function (ServicioSocialBrindadoDTO) {
        $('#txtCodigo').val(ServicioSocialBrindadoDTO.servicioSocialBrindadoId);
        $('#txtFechaSolicitude').val(ServicioSocialBrindadoDTO.fechaSolicitud);
        $('#txtDNIPersonale').val(ServicioSocialBrindadoDTO.dniPersonal);
        $('#cbPersonalSolicitantee').val(ServicioSocialBrindadoDTO.codigoPersonalSolicitante);
        $('#cbCondicionSolicitantee').val(ServicioSocialBrindadoDTO.codigoCondicionSolicitante);
        $('#cbPersonalBeneficiadoe').val(ServicioSocialBrindadoDTO.codigoPersonalBeneficiado);
        $('#cbTipoApoyoSociale').val(ServicioSocialBrindadoDTO.codigoTipoApoyoSocial);
        $('#cbTipoAtencione').val(ServicioSocialBrindadoDTO.codigoTipoAtencion);
        $('#cbTipoEvaluacionSociale').val(ServicioSocialBrindadoDTO.codigoTipoEvaluacionSocial);
        $('#txtOtroTipoApoyoe').val(ServicioSocialBrindadoDTO.otroTipoApoyo);
        $('#txtResultadoSolicitude').val(ServicioSocialBrindadoDTO.resultadoSolicitud);
        $('#txtFechaResultadoSolicitude').val(ServicioSocialBrindadoDTO.fechaResultadoSolicitud); 
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
                url: '/BienestarServicioSocialBrindado/Eliminar',
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
                    $('#tblBienestarServicioSocialBrindado').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarServicioSocialBrindado() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarServicioSocialBrindado/MostrarDatos',
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
                            $("<td>").text(item.fechaSolicitud),
                            $("<td>").text(item.dniPersonal),
                            $("<td>").text(item.codigoPersonalSolicitante),
                            $("<td>").text(item.codigoCondicionSolicitante),
                            $("<td>").text(item.codigoPersonalBeneficiado),
                            $("<td>").text(item.codigoTipoApoyoSocial),
                            $("<td>").text(item.codigoTipoAtencion),
                            $("<td>").text(item.codigoTipoEvaluacionSocial),
                            $("<td>").text(item.otroTipoApoyo),
                            $("<td>").text(item.resultadoSolicitud),
                            $("<td>").text(item.fechaResultadoSolicitud)
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
    fetch("BienestarServicioSocialBrindado/EnviarDatos", {
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
                url: '/BienestarServicioSocialBrindado/EliminarCarga',
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
                    $('#tblBienestarServicioSocialBrindado').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarServicioSocialBrindado/cargaCombs', [], function (Json) {
        var personalSolicitante = Json["data1"];
        var condicionSolicitante = Json["data2"];
        var personalBeneficiado = Json["data3"];
        var tipoApoyoSocial = Json["data4"];
        var tipoAtencion = Json["data5"];
        var tipoEvaluacionSocial = Json["data6"];
        var listaCargas = Json["data7"];

        $("select#cbPersonalSolicitante").html("");
        $("select#cbPersonalSolicitantee").html("");
        $.each(personalSolicitante, function () {
            var RowContent = '<option value=' + this.codigoPersonalSolicitante + '>' + this.descPersonalSolicitante + '</option>'
            $("select#cbPersonalSolicitante").append(RowContent);
            $("select#cbPersonalSolicitantee").append(RowContent);
        });

        $("select#cbCondicionSolicitante").html("");
        $("select#cbCondicionSolicitantee").html("");
        $.each(condicionSolicitante, function () {
            var RowContent = '<option value=' + this.codigoCondicionSolicitante + '>' + this.descCondicionSolicitante + '</option>'
            $("select#cbCondicionSolicitante").append(RowContent);
            $("select#cbCondicionSolicitantee").append(RowContent);
        });

        $("select#cbPersonalBeneficiado").html("");
        $("select#cbPersonalBeneficiadoe").html("");
        $.each(personalBeneficiado, function () {
            var RowContent = '<option value=' + this.codigoPersonalBeneficiado + '>' + this.descPersonalBeneficiado + '</option>'
            $("select#cbPersonalBeneficiado").append(RowContent);
            $("select#cbPersonalBeneficiadoe").append(RowContent);
        });

        $("select#cbTipoApoyoSocial").html("");
        $("select#cbTipoApoyoSociale").html("");
        $.each(tipoApoyoSocial, function () {
            var RowContent = '<option value=' + this.codigoTipoApoyoSocial + '>' + this.descTipoApoyoSocial + '</option>'
            $("select#cbTipoApoyoSocial").append(RowContent);
            $("select#cbTipoApoyoSociale").append(RowContent);
        });

        $("select#cbTipoAtencion").html("");
        $("select#cbTipoAtencione").html("");
        $.each(tipoAtencion, function () {
            var RowContent = '<option value=' + this.codigoTipoAtencion + '>' + this.descTipoAtencion + '</option>'
            $("select#cbTipoAtencion").append(RowContent);
            $("select#cbTipoAtencione").append(RowContent);
        });

        $("select#cbTipoEvaluacionSocial").html("");
        $("select#cbTipoEvaluacionSociale").html("");
        $.each(tipoEvaluacionSocial, function () {
            var RowContent = '<option value=' + this.codigoTipoEvaluacionSocial + '>' + this.descTipoEvaluacionSocial + '</option>'
            $("select#cbTipoEvaluacionSocial").append(RowContent);
            $("select#cbTipoEvaluacionSociale").append(RowContent);
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
        reporteSeleccionado = '/BienestarServicioSocialBrindado/ReporteSSB?idCarga=';
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