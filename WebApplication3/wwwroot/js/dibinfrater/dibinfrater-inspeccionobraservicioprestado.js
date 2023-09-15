var tblDibinfraterInspeccionObraServicioPrestado;
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
                                url: '/DibinfraterInspeccionObraServicioPrestado/Insertar',
                                data: {
                                    'IdentificacionSolicitud': $('#txtIdentificacionSolicitud').val(),
                                    'NombreObra': $('#txtNombreObra').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreaDiperadmon').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'EstadoSolicitud': $('#txtEstadoSolicitud').val(),
                                    'IdentificacionContrato': $('#txtIdentificacionContrato').val(),
                                    'CodigoTipoObraServicio': $('#cbTipoObraServicio').val(),
                                    'CodigoTipoProceso': $('#cbTipoProceso').val(),
                                    'MontoContrato': $('#txtMontoContrato').val(),
                                    'FechaInicioObraServicio': $('#txtFechaInicioObraServicio').val(),
                                    'FechaTerminoEstimada': $('#txtFechaTerminoEstimada').val(),
                                    'PorcentajeAvanceFisico': $('#txtPorcentajeAvanceFisico').val(), 
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
                                    $('#tblDibinfraterInspeccionObraServicioPrestado').DataTable().ajax.reload();
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
                                url: '/DibinfraterInspeccionObraServicioPrestado/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'IdentificacionSolicitud': $('#txtIdentificacionSolicitude').val(),
                                    'NombreObra': $('#txtNombreObrae').val(),
                                    'CodigoAreaDiperadmon': $('#cbAreaDiperadmone').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'EstadoSolicitud': $('#txtEstadoSolicitude').val(),
                                    'IdentificacionContrato': $('#txtIdentificacionContratoe').val(),
                                    'CodigoTipoObraServicio': $('#cbTipoObraServicioe').val(),
                                    'CodigoTipoProceso': $('#cbTipoProcesoe').val(),
                                    'MontoContrato': $('#txtMontoContratoe').val(),
                                    'FechaInicioObraServicio': $('#txtFechaInicioObraServicioe').val(),
                                    'FechaTerminoEstimada': $('#txtFechaTerminoEstimadae').val(),
                                    'PorcentajeAvanceFisico': $('#txtPorcentajeAvanceFisicoe').val(), 
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
                                    $('#tblDibinfraterInspeccionObraServicioPrestado').DataTable().ajax.reload();
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

   tblDibinfraterInspeccionObraServicioPrestado = $('#tblDibinfraterInspeccionObraServicioPrestado').DataTable({
        ajax: {
            "url": '/DibinfraterInspeccionObraServicioPrestado/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "inspeccionObraServicioPrestadoId" },
            { "data": "identificacionSolicitud" },
            { "data": "nombreObra" },
            { "data": "descAreaDiperadmon" },
            { "data": "descZonaNaval" },
            { "data": "estadoSolicitud" },
            { "data": "identificacionContrato" },
            { "data": "descTipoObraServicio" },
            { "data": "descTipoProceso" },
            { "data": "montoContrato" },
            { "data": "fechaInicioObraServicio" },
            { "data": "fechaTerminoEstimada" },
            { "data": "porcentajeAvanceFisico" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.inspeccionObraServicioPrestadoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.inspeccionObraServicioPrestadoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dibinfrater - Inspecciones de Obras y Servicios Prestados',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dibinfrater - Inspecciones de Obras y Servicios Prestados',
                title: 'Dibinfrater - Inspecciones de Obras y Servicios Prestados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dibinfrater - Inspecciones de Obras y Servicios Prestados',
                title: 'Dibinfrater - Inspecciones de Obras y Servicios Prestados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dibinfrater - Inspecciones de Obras y Servicios Prestados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
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
    tblDibinfraterInspeccionObraServicioPrestado.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDibinfraterInspeccionObraServicioPrestado.columns(13).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DibinfraterInspeccionObraServicioPrestado/Mostrar?Id=' + Id, [], function (InspeccionObraServicioPrestadoDTO) {
        $('#txtCodigo').val(InspeccionObraServicioPrestadoDTO.inspeccionObraServicioPrestadoId);
        $('#txtIdentificacionSolicitude').val(InspeccionObraServicioPrestadoDTO.identificacionSolicitud);
        $('#txtNombreObrae').val(InspeccionObraServicioPrestadoDTO.nombreObra);
        $('#cbAreaDiperadmone').val(InspeccionObraServicioPrestadoDTO.codigoAreaDiperadmon);
        $('#cbZonaNavale').val(InspeccionObraServicioPrestadoDTO.codigoZonaNaval);
        $('#txtEstadoSolicitude').val(InspeccionObraServicioPrestadoDTO.estadoSolicitud);
        $('#txtIdentificacionContratoe').val(InspeccionObraServicioPrestadoDTO.identificacionContrato);
        $('#cbTipoObraServicioe').val(InspeccionObraServicioPrestadoDTO.codigoTipoObraServicio);
        $('#cbTipoProcesoe').val(InspeccionObraServicioPrestadoDTO.codigoTipoProceso);
        $('#txtMontoContratoe').val(InspeccionObraServicioPrestadoDTO.montoContrato);
        $('#txtFechaInicioObraServicioe').val(InspeccionObraServicioPrestadoDTO.fechaInicioObraServicio);
        $('#txtFechaTerminoEstimadae').val(InspeccionObraServicioPrestadoDTO.fechaTerminoEstimada);
        $('#txtPorcentajeAvanceFisicoe').val(InspeccionObraServicioPrestadoDTO.porcentajeAvanceFisico); 
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
                url: '/DibinfraterInspeccionObraServicioPrestado/Eliminar',
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
                    $('#tblDibinfraterInspeccionObraServicioPrestado').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDibinfraterInspeccionObraServicioPrestado() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DibinfraterInspeccionObraServicioPrestado/MostrarDatos',
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
                            $("<td>").text(item.identificacionSolicitud),
                            $("<td>").text(item.nombreObra),
                            $("<td>").text(item.codigoAreaDiperadmon),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.estadoSolicitud),
                            $("<td>").text(item.identificacionContrato),
                            $("<td>").text(item.codigoTipoObraServicio),
                            $("<td>").text(item.codigoTipoProceso),
                            $("<td>").text(item.montoContrato),
                            $("<td>").text(item.fechaInicioObraServicio),
                            $("<td>").text(item.fechaTerminoEstimada),
                            $("<td>").text(item.porcentajeAvanceFisico)

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
    fetch("DibinfraterInspeccionObraServicioPrestado/EnviarDatos", {
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
                url: '/DibinfraterInspeccionObraServicioPrestado/EliminarCarga',
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
                    $('#tblDibinfraterInspeccionObraServicioPrestado').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DibinfraterInspeccionObraServicioPrestado/cargaCombs', [], function (Json) {
        var areaDiperadmon = Json["data1"];
        var zonaNaval = Json["data2"];
        var tipoObraServicio = Json["data3"];
        var tipoProceso = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbAreaDiperadmon").html("");
        $("select#cbAreaDiperadmone").html("");
        $.each(areaDiperadmon, function () {
            var RowContent = '<option value=' + this.codigoAreaDiperadmon + '>' + this.descAreaDiperadmon + '</option>'
            $("select#cbAreaDiperadmon").append(RowContent);
            $("select#cbAreaDiperadmone").append(RowContent);
        });

        $("select#cbZonaNaval").html("");
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
            $("select#cbZonaNavale").append(RowContent);
        });

        $("select#cbTipoObraServicio").html("");
        $("select#cbTipoObraServicioe").html("");
        $.each(tipoObraServicio, function () {
            var RowContent = '<option value=' + this.codigoTipoObraServicio + '>' + this.descTipoObraServicio + '</option>'
            $("select#cbTipoObraServicio").append(RowContent);
            $("select#cbTipoObraServicioe").append(RowContent);
        });

        $("select#cbTipoProceso").html("");
        $("select#cbTipoProcesoe").html("");
        $.each(tipoProceso, function () {
            var RowContent = '<option value=' + this.codigoTipoProceso + '>' + this.descTipoProceso + '</option>'
            $("select#cbTipoProceso").append(RowContent);
            $("select#cbTipoProcesoe").append(RowContent);
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