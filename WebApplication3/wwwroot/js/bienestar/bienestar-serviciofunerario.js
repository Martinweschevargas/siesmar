var tblBienestarServicioFunerario;
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
                                url: '/BienestarServicioFunerario/Insertar',
                                data: {
                                    'FechaServicioFunerario': $('#txtFechaServicioLiturgico').val(),
                                    'DNISolicitante': $('#txtDNISolicitante').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitante').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitante').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiado').val(),
                                    'CodigoCategoriaPago': $('#cbCategoriaPago').val(),
                                    'ServicioTramiteSepelio': $('#txtServicioTramiteSepelion').val(),
                                    'ServicioAlquilerAtaud': $('#txtServicioAlquilerAtaud').val(),
                                    'ServicioVentaAtaud': $('#txtServicioVentaAtaud').val(),
                                    'ServicioCremacion': $('#txtServicioCremacion').val(),
                                    'ServicioSalonVelatorio': $('#txtServicioSalonVelatorio').val(),
                                    'ServicioCapillaArdiente': $('#txtServicioCapillaArdiente').val(),
                                    'ServicioAlquilerCarroza': $('#txtServicioAlquilerCarroza').val(),
                                    'ServicioAlquilerCarroServicio': $('#txtServicioAlquilerCarroServicio').val(),
                                    'ServicioAlquilerCarroFlores': $('#txtServicioAlquilerCarroFlores').val(),
                                    'MontoTotalServicio': $('#txtMontoTotalServicio').val(), 
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
                                    $('#tblBienestarServicioFunerario').DataTable().ajax.reload();
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
                                url: '/BienestarServicioFunerario/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaServicioFunerario': $('#txtFechaServicioLiturgicoe').val(),
                                    'DNISolicitante': $('#txtDNISolicitantee').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitantee').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitantee').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiadoe').val(),
                                    'CodigoCategoriaPago': $('#cbCategoriaPagoe').val(),
                                    'ServicioTramiteSepelio': $('#txtServicioTramiteSepelione').val(),
                                    'ServicioAlquilerAtaud': $('#txtServicioAlquilerAtaude').val(),
                                    'ServicioVentaAtaud': $('#txtServicioVentaAtaude').val(),
                                    'ServicioCremacion': $('#txtServicioCremacione').val(),
                                    'ServicioSalonVelatorio': $('#txtServicioSalonVelatorioe').val(),
                                    'ServicioCapillaArdiente': $('#txtServicioCapillaArdientee').val(),
                                    'ServicioAlquilerCarroza': $('#txtServicioAlquilerCarrozae').val(),
                                    'ServicioAlquilerCarroServicio': $('#txtServicioAlquilerCarroServicioe').val(),
                                    'ServicioAlquilerCarroFlores': $('#txtServicioAlquilerCarroFlorese').val(),
                                    'MontoTotalServicio': $('#txtMontoTotalServicioe').val(), 
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
                                    $('#tblBienestarServicioFunerario').DataTable().ajax.reload();
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

    tblBienestarServicioFunerario = $('#tblBienestarServicioFunerario').DataTable({
        ajax: {
            "url": '/BienestarServicioFunerario/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioFunerarioId" },
            { "data": "fechaServicioFunerario" },
            { "data": "dniSolicitante" },
            { "data": "descPersonalSolicitante" },
            { "data": "descCondicionSolicitante" },
            { "data": "descPersonalBeneficiado" },
            { "data": "descCategoriaPago" },
            { "data": "servicioTramiteSepelio" },
            { "data": "servicioAlquilerAtaud" },
            { "data": "servicioVentaAtaud" },
            { "data": "servicioCremacion" },
            { "data": "servicioSalonVelatorio" },
            { "data": "servicioCapillaArdiente" },
            { "data": "servicioAlquilerCarroza" },
            { "data": "servicioAlquilerCarroServicio" },
            { "data": "servicioAlquilerCarroFlores" },
            { "data": "montoTotalServicio" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioFunerarioId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioFunerarioId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Servicio Litúrgico',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Bienestar - Servicio Litúrgico',
                title: 'Bienestar - Servicio Litúrgico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]

                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Servicio Litúrgico',
                title: 'Bienestar - Servicio Litúrgico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Servicio Litúrgico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
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
    tblBienestarServicioFunerario.columns(17).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarServicioFunerario.columns(17).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarServicioFunerario/Mostrar?Id=' + Id, [], function (ServicioFunerarioDTO) {
        $('#txtCodigo').val(ServicioFunerarioDTO.servicioFunerarioId);
        $('#txtFechaServicioLiturgicoe').val(ServicioFunerarioDTO.fechaServicioFunerario);
        $('#txtDNISolicitantee').val(ServicioFunerarioDTO.dniSolicitante);
        $('#cbPersonalSolicitantee').val(ServicioFunerarioDTO.codigoPersonalBeneficiado);
        $('#cbCondicionSolicitantee').val(ServicioFunerarioDTO.codigoCondicionSolicitante);
        $('#cbPersonalBeneficiadoe').val(ServicioFunerarioDTO.codigoPersonalBeneficiado);
        $('#cbCategoriaPagoe').val(ServicioFunerarioDTO.codigoCategoriaPago);
        $('#txtServicioTramiteSepelione').val(ServicioFunerarioDTO.servicioTramiteSepelio);
        $('#txtServicioAlquilerAtaude').val(ServicioFunerarioDTO.servicioAlquilerAtaud);
        $('#txtServicioVentaAtaude').val(ServicioFunerarioDTO.servicioVentaAtaud);
        $('#txtServicioCremacione').val(ServicioFunerarioDTO.servicioCremacion);
        $('#txtServicioSalonVelatorioe').val(ServicioFunerarioDTO.servicioSalonVelatorio);
        $('#txtServicioCapillaArdientee').val(ServicioFunerarioDTO.servicioCapillaArdiente);
        $('#txtServicioAlquilerCarrozae').val(ServicioFunerarioDTO.servicioAlquilerCarroza);
        $('#txtServicioAlquilerCarroServicioe').val(ServicioFunerarioDTO.servicioAlquilerCarroServicio);
        $('#txtServicioAlquilerCarroFlorese').val(ServicioFunerarioDTO.servicioAlquilerCarroFlores);
        $('#txtMontoTotalServicioe').val(ServicioFunerarioDTO.montoTotalServicio); 
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
                url: '/BienestarServicioFunerario/Eliminar',
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
                    $('#tblBienestarServicioFunerario').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarServicioFunerario() {
    $('#listar').hide();
    $('#nuevo').show();
}



function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarServicioFunerario/MostrarDatos',
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
                            $("<td>").text(item.fechaServicioFunerario),
                            $("<td>").text(item.dniSolicitante),
                            $("<td>").text(item.codigoPersonalSolicitante),
                            $("<td>").text(item.codigoCondicionSolicitante),
                            $("<td>").text(item.codigoPersonalBeneficiado),
                            $("<td>").text(item.codigoCategoriaPago),
                            $("<td>").text(item.servicioTramiteSepelio),
                            $("<td>").text(item.servicioAlquilerAtaud),
                            $("<td>").text(item.servicioVentaAtaud),
                            $("<td>").text(item.servicioCremacion),
                            $("<td>").text(item.servicioSalonVelatorio),
                            $("<td>").text(item.servicioCapillaArdiente),
                            $("<td>").text(item.servicioAlquilerCarroza),
                            $("<td>").text(item.servicioAlquilerCarroServicio),
                            $("<td>").text(item.servicioAlquilerCarroFlores),
                            $("<td>").text(item.montoTotalServicio)
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
    fetch("BienestarServicioFunerario/EnviarDatos", {
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
                url: '/BienestarServicioFunerario/EliminarCarga',
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
                    $('#tblBienestarServicioFunerario').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarServicioFunerario/cargaCombs', [], function (Json) {
        var personalSolicitante = Json["data1"];
        var condicionSolicitante = Json["data2"];
        var personalBeneficiado = Json["data3"];
        var categoriaPago = Json["data4"];
        var listaCargas = Json["data5"];


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

        $("select#cbCategoriaPago").html("");
        $("select#cbCategoriaPagoe").html("");
        $.each(categoriaPago, function () {
            var RowContent = '<option value=' + this.codigoCategoriaPago + '>' + this.descCategoriaPago + '</option>'
            $("select#cbCategoriaPago").append(RowContent);
            $("select#cbCategoriaPagoe").append(RowContent);
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
        reporteSeleccionado = '/BienestarServicioFunerario/ReporteSF?idCarga=';
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