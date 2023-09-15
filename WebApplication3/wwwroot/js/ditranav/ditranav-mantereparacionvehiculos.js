var tblDitranavMantReparacionVehiculos;
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
                                url: '/DitranavMantReparacionVehiculos/Insertar',
                                data: {
                                    'PlacaVehiculoMantenimiento': $('#txtPlacaVehiculo').val(),
                                    'FechaIngresoMantenimiento': $('#txtFechaIngreso').val(),
                                    'ClasificacionFlotaVehiculoM': $('#txtClasificacionFlota').val(),
                                    'CodigoMarcaVehiculo': $('#cbMarca').val(),
                                    'AnioFabricacionVehiculoM': $('#txtAnioFabricacion').val(),
                                    'KilometrosVehiculoM': $('#txtKilometros').val(),
                                    'DependenciaVehiculoM': $('#txtDependencia').val(),
                                    'MotivoServicioVehiculo': $('#txtMotivoServicioV').val(),
                                    'FechaSalidaVehiculoM': $('#txtFechaSalidaV').val(),
                                    'RequerimientoRepuesto': $('#txtRequerimientoRepuesto').val(),
                                    'CostoRepuestos': $('#txtCostoRepuestos').val(),
                                    'OrdenCompraServicio': $('#txtOrdenCompraS').val(),
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
                                    $('#tblDitranavMantReparacionVehiculos').DataTable().ajax.reload();
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
                                url: '/DitranavMantReparacionVehiculos/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'PlacaVehiculoMantenimiento': $('#txtPlacaVehiculoe').val(),
                                    'FechaIngresoMantenimiento': $('#txtFechaIngresoe').val(),
                                    'ClasificacionFlotaVehiculoM': $('#txtClasificacionFlotae').val(),
                                    'CodigoMarcaVehiculo': $('#cbMarcae').val(),
                                    'AnioFabricacionVehiculoM': $('#txtAnioFabricacione').val(),
                                    'KilometrosVehiculoM': $('#txtKilometrose').val(),
                                    'DependenciaVehiculoM': $('#txtDependenciae').val(),
                                    'MotivoServicioVehiculo': $('#txtMotivoServicioVe').val(),
                                    'FechaSalidaVehiculoM': $('#txtFechaSalidaVe').val(),
                                    'RequerimientoRepuesto': $('#txtRequerimientoRepuestoe').val(),
                                    'CostoRepuestos': $('#txtCostoRepuestose').val(),
                                    'OrdenCompraServicio': $('#txtOrdenCompraSe').val(),
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
                                    $('#tblDitranavMantReparacionVehiculos').DataTable().ajax.reload();
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

    tblDitranavMantReparacionVehiculos = $('#tblDitranavMantReparacionVehiculos').DataTable({
        ajax: {
            "url": '/DitranavMantReparacionVehiculos/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "mantenimientoReparacionVehiculoId" },
            { "data": "placaVehiculoMantenimiento" },
            { "data": "fechaIngresoMantenimiento" },
            { "data": "clasificacionFlotaVehiculoM" },
            { "data": "clasificacionVehiculo" },
            { "data": "anioFabricacionVehiculoM" },
            { "data": "kilometrosVehiculoM" },
            { "data": "dependenciaVehiculoM" },
            { "data": "motivoServicioVehiculo" },
            { "data": "fechaSalidaVehiculoM" },
            { "data": "requerimientoRepuesto" },
            { "data": "costoRepuestos" },
            { "data": "ordenCompraServicio" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.mantenimientoReparacionVehiculoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.mantenimientoReparacionVehiculoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Ditranav - Mantenimiento y Reparación de Vehiculos de Transporte Terrestre',
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
                filename: 'Ditranav - Mantenimiento y Reparación de Vehiculos de Transporte Terrestre',
                title: 'Ditranav - Mantenimiento y Reparación de Vehiculos de Transporte Terrestre',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Ditranav - Mantenimiento y Reparación de Vehiculos de Transporte Terrestre',
                title: 'Ditranav - Mantenimiento y Reparación de Vehiculos de Transporte Terrestre',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Ditranav - Mantenimiento y Reparación de Vehiculos de Transporte Terrestre',
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
    tblDitranavMantReparacionVehiculos.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDitranavMantReparacionVehiculos.columns(13).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DitranavMantReparacionVehiculos/Mostrar?Id=' + Id, [], function (MantenimientoReparacionVehiculosDTO) {
        $('#txtCodigo').val(MantenimientoReparacionVehiculosDTO.mantenimientoReparacionVehiculoId);
        $('#txtPlacaVehiculoe').val(MantenimientoReparacionVehiculosDTO.placaVehiculoMantenimiento);
        $('#txtFechaIngresoe').val(MantenimientoReparacionVehiculosDTO.fechaIngresoMantenimiento);
        $('#txtClasificacionFlotae').val(MantenimientoReparacionVehiculosDTO.clasificacionFlotaVehiculoM);
        $('#cbMarcae').val(MantenimientoReparacionVehiculosDTO.codigoMarcaVehiculo);
        $('#txtAnioFabricacione').val(MantenimientoReparacionVehiculosDTO.anioFabricacionVehiculoM);
        $('#txtKilometrose').val(MantenimientoReparacionVehiculosDTO.kilometrosVehiculoM);
        $('#txtDependenciae').val(MantenimientoReparacionVehiculosDTO.dependenciaVehiculoM);
        $('#txtMotivoServicioVe').val(MantenimientoReparacionVehiculosDTO.motivoServicioVehiculo);
        $('#txtFechaSalidaVe').val(MantenimientoReparacionVehiculosDTO.fechaSalidaVehiculoM);
        $('#txtRequerimientoRepuestoe').val(MantenimientoReparacionVehiculosDTO.requerimientoRepuesto);
        $('#txtCostoRepuestose').val(MantenimientoReparacionVehiculosDTO.costoRepuestos);
        $('#txtOrdenCompraSe').val(MantenimientoReparacionVehiculosDTO.ordenCompraServicio);
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
                url: '/DitranavMantReparacionVehiculos/Eliminar',
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
                    $('#tblDitranavMantReparacionVehiculos').DataTable().ajax.reload();
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
                url: '/DitranavMantReparacionVehiculos/EliminarCarga',
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
                    cargaDatos();
                    $('#tblDitranavMantReparacionVehiculos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDitranavMantReparacionVehiculos() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DitranavMantReparacionVehiculos/MostrarDatos',
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
                            $("<td>").text(item.placaVehiculoMantenimiento),
                            $("<td>").text(item.fechaIngresoMantenimiento),
                            $("<td>").text(item.clasificacionFlotaVehiculoM),
                            $("<td>").text(item.codigoMarcaVehiculo),
                            $("<td>").text(item.anioFabricacionVehiculoM),
                            $("<td>").text(item.kilometrosVehiculoM),
                            $("<td>").text(item.dependenciaVehiculoM),
                            $("<td>").text(item.motivoServicioVehiculo),
                            $("<td>").text(item.echaSalidaVehiculoM),
                            $("<td>").text(item.requerimientoRepuesto),
                            $("<td>").text(item.costoRepuestos),
                            $("<td>").text(item.ordenCompraServicio),
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
    fetch("DitranavMantReparacionVehiculos/EnviarDatos", {
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
    $.getJSON('/DitranavMantReparacionVehiculos/cargaCombs', [], function (Json) {
        var marcavehiculo = Json["data1"];
        var listaCargas = Json["data2"];

        $("select#cbMarca").html("");
        $("select#cbMarcae").html("");
        $.each(marcavehiculo, function () {
            var RowContent = '<option value=' + this.codigoMarcaVehiculo + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarca").append(RowContent);
            $("select#cbMarcae").append(RowContent);
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
        reporteSeleccionado = '/DitranavMantReparacionVehiculos/ReporteDMRV';
        $('#fecha').hide();
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
        a.click();
    }
    )
};
