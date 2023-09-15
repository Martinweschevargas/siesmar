var tblBienestarServicioViviendaPrestada;
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
                                url: '/BienestarServicioViviendaPrestada/Insertar',
                                data: {
                                    'CIPBeneficiario': $('#txtCIPBeneficiario').val(),
                                    'DNIBeneficiario': $('#txtDNIBeneficiario').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalM').val(),
                                    'FechaSolicitud': $('#txtFechaSolicitud').val(),
                                    'EstadoSolicitud': $('#txtEstadoSolicitud option:selected').val(),
                                    'CodigoVillaNaval': $('#cbVillaNaval').val(),
                                    'CodigoBlockVillaNaval': $('#cbBlockVillaNaval').val(),
                                    'NumeroDepartamento': $('#txtNumeroDepartamento').val(),
                                    'FechaEntregaVivienda': $('#txtFechaEntregaVivienda').val(),
                                    'CodigoTipoAsignacionCasaServicio': $('#cbTipoAsignacionCasaS').val(),
                                    'PeriodoPermanencia': $('#txtPeriodoPermanencia option:selected').val(), 
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
                                    $('#tblBienestarServicioViviendaPrestada').DataTable().ajax.reload();
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
                                url: '/BienestarServicioViviendaPrestada/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CIPBeneficiario': $('#txtCIPBeneficiarioe').val(),
                                    'DNIBeneficiario': $('#txtDNIBeneficiarioe').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMe').val(),
                                    'FechaSolicitud': $('#txtFechaSolicitude').val(),
                                    'EstadoSolicitud': $('#txtEstadoSolicitude option:selected').val(),
                                    'CodigoVillaNaval': $('#cbVillaNavale').val(),
                                    'CodigoBlockVillaNaval': $('#cbBlockVillaNavale').val(),
                                    'NumeroDepartamento': $('#txtNumeroDepartamentoe').val(),
                                    'FechaEntregaVivienda': $('#txtFechaEntregaViviendae').val(),
                                    'CodigoTipoAsignacionCasaServicio': $('#cbTipoAsignacionCasaSe').val(),
                                    'PeriodoPermanencia': $('#txtPeriodoPermanenciae option:selected').val(), 
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
                                    $('#tblBienestarServicioViviendaPrestada').DataTable().ajax.reload();
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

    tblBienestarServicioViviendaPrestada = $('#tblBienestarServicioViviendaPrestada').DataTable({
        ajax: {
            "url": '/BienestarServicioViviendaPrestada/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioViviendaPrestadaId" },
            { "data": "cipBeneficiario" },
            { "data": "dniBeneficiario" },
            { "data": "descGrado" },
            { "data": "fechaSolicitud" },
            { "data": "estadoSolicitud" },
            { "data": "descVillaNaval" },
            { "data": "descBlockVillaNaval" },
            { "data": "numeroDepartamento" },
            { "data": "fechaEntregaVivienda" },
            { "data": "descTipoAsignacionCasaServicio" },
            { "data": "periodoPermanencia" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioViviendaPrestadaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioViviendaPrestadaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Servicio de Vivienda Prestado de la Dirección de Bienestar (Asignación de Viviendas)',
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
                filename: 'Bienestar - Servicio de Vivienda Prestado de la Dirección de Bienestar (Asignación de Viviendas)',
                title: 'Bienestar - Servicio de Vivienda Prestado de la Dirección de Bienestar (Asignación de Viviendas)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Servicio de Vivienda Prestado de la Dirección de Bienestar (Asignación de Viviendas)',
                title: 'Bienestar - Servicio de Vivienda Prestado de la Dirección de Bienestar (Asignación de Viviendas)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Servicio de Vivienda Prestado de la Dirección de Bienestar (Asignación de Viviendas)',
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
    tblBienestarServicioViviendaPrestada.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarServicioViviendaPrestada.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarServicioViviendaPrestada/Mostrar?Id=' + Id, [], function (ServicioViviendaPrestadaDTO) {
        $('#txtCodigo').val(ServicioViviendaPrestadaDTO.servicioViviendaPrestadaId);
        $('#txtCIPBeneficiarioe').val(ServicioViviendaPrestadaDTO.cipBeneficiario);
        $('#txtDNIBeneficiarioe').val(ServicioViviendaPrestadaDTO.dniBeneficiario);
        $('#cbGradoPersonalMe').val(ServicioViviendaPrestadaDTO.codigoGradoPersonalMilitar);
        $('#txtFechaSolicitude').val(ServicioViviendaPrestadaDTO.fechaSolicitud);
        $('#txtEstadoSolicitude').val(ServicioViviendaPrestadaDTO.estadoSolicitud);
        $('#cbVillaNavale').val(ServicioViviendaPrestadaDTO.codigoVillaNaval);
        $('#cbBlockVillaNavale').val(ServicioViviendaPrestadaDTO.codigoBlockVillaNaval);
        $('#txtNumeroDepartamentoe').val(ServicioViviendaPrestadaDTO.numeroDepartamento);
        $('#txtFechaEntregaViviendae').val(ServicioViviendaPrestadaDTO.fechaEntregaVivienda);
        $('#cbTipoAsignacionCasaSe').val(ServicioViviendaPrestadaDTO.codigoTipoAsignacionCasaServicio);
        $('#txtPeriodoPermanenciae').val(ServicioViviendaPrestadaDTO.periodoPermanencia); 
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
                url: '/BienestarServicioViviendaPrestada/Eliminar',
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
                    $('#tblBienestarServicioViviendaPrestada').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarServicioViviendaPrestada() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarServicioViviendaPrestada/MostrarDatos',
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
                            $("<td>").text(item.cipBeneficiario),
                            $("<td>").text(item.dniBeneficiario),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.fechaSolicitud),
                            $("<td>").text(item.estadoSolicitud),
                            $("<td>").text(item.codigoVillaNaval),
                            $("<td>").text(item.codigoBlockVillaNaval),
                            $("<td>").text(item.numeroDepartamento),
                            $("<td>").text(item.fechaEntregaVivienda),
                            $("<td>").text(item.codigoTipoAsignacionCasaServicio),
                            $("<td>").text(item.periodoPermanencia)
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
    fetch("BienestarServicioViviendaPrestada/EnviarDatos", {
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
                url: '/BienestarServicioViviendaPrestada/EliminarCarga',
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
                    $('#tblBienestarServicioViviendaPrestada').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarServicioViviendaPrestada/cargaCombs', [], function (Json) {
        var gradoPersonalMilitarDTO = Json["data1"];
        var VillaNavalDTO = Json["data2"];
        var blockVillaNavalDTO = Json["data3"];
        var tipoAsignacionCasaServicioDTO = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbGradoPersonalM").html("");
        $("select#cbGradoPersonalMe").html("");
        $.each(gradoPersonalMilitarDTO, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalM").append(RowContent);
            $("select#cbGradoPersonalMe").append(RowContent);
        });

        $("select#cbVillaNaval").html("");
        $("select#cbVillaNavale").html("");
        $.each(VillaNavalDTO, function () {
            var RowContent = '<option value=' + this.codigoVillaNaval + '>' + this.descVillaNaval + '</option>'
            $("select#cbVillaNaval").append(RowContent);
            $("select#cbVillaNavale").append(RowContent);
        });

        $("select#cbBlockVillaNaval").html("");
        $("select#cbBlockVillaNavale").html("");
        $.each(blockVillaNavalDTO, function () {
            var RowContent = '<option value=' + this.codigoBlockVillaNaval + '>' + this.descBlockVillaNaval + '</option>'
            $("select#cbBlockVillaNaval").append(RowContent);
            $("select#cbBlockVillaNavale").append(RowContent);
        });

        $("select#cbTipoAsignacionCasaS").html("");
        $("select#cbTipoAsignacionCasaSe").html("");
        $.each(tipoAsignacionCasaServicioDTO, function () {
            var RowContent = '<option value=' + this.codigoTipoAsignacionCasaServicio + '>' + this.descTipoAsignacionCasaServicio + '</option>'
            $("select#cbTipoAsignacionCasaS").append(RowContent);
            $("select#cbTipoAsignacionCasaSe").append(RowContent);
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
        reporteSeleccionado = '/BienestarServicioViviendaPrestada/ReporteBSVP?idCarga=';
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