var tblDitranavVehiculoEmpleadoComision;
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
                                url: '/DitranavVehiculoEmpleadoComision/Insertar',
                                data: {
                                    'PlacaVehiculoComision': $('#txtPlacaVehiculo').val(),
                                    'ClasificacionFlotaComision': $('#txtClasificacionFlotaV').val(),
                                    'CodigoMarcaVehiculo': $('#cbMarca').val(),
                                    'FechaComisionVehiculo': $('#txtFechaComision').val(),
                                    'CodigoTipoVehiculoTransporte': $('#cbTipoVehiculoTransporte').val(),
                                    'DependenciaSolicitante': $('#txtDependenciaSol').val(),
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
                                    $('#tblDitranavVehiculoEmpleadoComision').DataTable().ajax.reload();
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
                                url: '/DitranavVehiculoEmpleadoComision/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'PlacaVehiculoComision': $('#txtPlacaVehiculoe').val(),
                                    'ClasificacionFlotaComision': $('#txtClasificacionFlotaVe').val(),
                                    'CodigoMarcaVehiculo': $('#cbMarcae').val(),
                                    'FechaComisionVehiculo': $('#txtFechaComisione').val(),
                                    'CodigoTipoVehiculoTransporte': $('#cbTipoVehiculoTransportee').val(),
                                    'DependenciaSolicitante': $('#txtDependenciaSole').val(),
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
                                    $('#tblDitranavVehiculoEmpleadoComision').DataTable().ajax.reload();
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

    tblDitranavVehiculoEmpleadoComision = $('#tblDitranavVehiculoEmpleadoComision').DataTable({
        ajax: {
            "url": '/DitranavVehiculoEmpleadoComision/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "vehiculoEmpleadoComisionId" },
            { "data": "placaVehiculoComision" },
            { "data": "clasificacionFlotaComision" },
            { "data": "clasificacionVehiculo" },
            { "data": "fechaComisionVehiculo" },
            { "data": "descTipoVehiculoTransporte" },
            { "data": "dependenciaSolicitante" },
            { "data": "cargaId" },
            
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.vehiculoEmpleadoComisionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.vehiculoEmpleadoComisionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Ditranav - Vehículo de Transporte Empleados en Comisiones a las Unidades y Dependencias',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Ditranav - Vehículo de Transporte Empleados en Comisiones a las Unidades y Dependencias',
                title: 'Ditranav - Vehículo de Transporte Empleados en Comisiones a las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Ditranav - Vehículo de Transporte Empleados en Comisiones a las Unidades y Dependencias',
                title: 'Ditranav - Vehículo de Transporte Empleados en Comisiones a las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Ditranav - Vehículo de Transporte Empleados en Comisiones a las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
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
    tblDitranavVehiculoEmpleadoComision.columns(7).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDitranavVehiculoEmpleadoComision.columns(7).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DitranavVehiculoEmpleadoComision/Mostrar?Id=' + Id, [], function (VehiculosTerActividadInstitucionDTO) {
        $('#txtCodigo').val(VehiculosTerActividadInstitucionDTO.vehiculoEmpleadoComisionId);
        $('#txtPlacaVehiculoe').val(VehiculosTerActividadInstitucionDTO.placaVehiculoComision);
        $('#txtClasificacionFlotaVe').val(VehiculosTerActividadInstitucionDTO.clasificacionFlotaComision);
        $('#cbMarcae').val(VehiculosTerActividadInstitucionDTO.codigoMarcaVehiculo);
        $('#txtFechaComisione').val(VehiculosTerActividadInstitucionDTO.fechaComisionVehiculo);
        $('#cbTipoVehiculoTransportee').val(VehiculosTerActividadInstitucionDTO.codigoTipoVehiculoTransporte);
        $('#txtDependenciaSole').val(VehiculosTerActividadInstitucionDTO.dependenciaSolicitante);
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
                url: '/DitranavVehiculoEmpleadoComision/Eliminar',
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
                    $('#tblDitranavVehiculoEmpleadoComision').DataTable().ajax.reload();
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
                url: '/DitranavVehiculoEmpleadoComision/EliminarCarga',
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
                    $('#tblDitranavVehiculoEmpleadoComision').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDitranavVehiculoEmpleadoComision() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DitranavVehiculoEmpleadoComision/MostrarDatos',
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
                            $("<td>").text(item.placaVehiculoComision),
                            $("<td>").text(item.clasificacionFlotaComision),
                            $("<td>").text(item.codigoMarcaVehiculo),
                            $("<td>").text(item.fechaComisionVehiculo),
                            $("<td>").text(item.codigoTipoVehiculoTransporte),
                            $("<td>").text(item.dependenciaSolicitante),
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
    fetch("DitranavVehiculoEmpleadoComision/EnviarDatos", {
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
    $.getJSON('/DitranavVehiculoEmpleadoComision/cargaCombs', [], function (Json) {
        var marcaVehiculo= Json["data1"];
        var tipoVehiculoTransporte = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbMarca").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.codigoMarcaVehiculo + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarca").append(RowContent);
        });
        $("select#cbMarcae").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.codigoMarcaVehiculo + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarcae").append(RowContent);
        });

        $("select#cbTipoVehiculoTransporte").html("");
        $.each(tipoVehiculoTransporte, function () {
            var RowContent = '<option value=' + this.codigoTipoVehiculoTransporte + '>' + this.descTipoVehiculoTransporte + '</option>'
            $("select#cbTipoVehiculoTransporte").append(RowContent);
        });
        $("select#cbTipoVehiculoTransportee").html("");
        $.each(tipoVehiculoTransporte, function () {
            var RowContent = '<option value=' + this.codigoTipoVehiculoTransporte + '>' + this.descTipoVehiculoTransporte + '</option>'
            $("select#cbTipoVehiculoTransportee").append(RowContent);
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
        reporteSeleccionado = '/DitranavVehiculoEmpleadoComision/ReporteDVEC';
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