var tblDitranavVehiculosTerActividadInsti;
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
                                url: '/DitranavVehiculosTerActividadInsti/Insertar',
                                data: {
                                    'PlacaVehiculo': $('#txtPlacaVehiculo').val(),
                                    'ClasificacionFlotaVehiculo': $('#txtClasificacionFlotaV').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoMarcaVehiculo': $('#cbMarca').val(),
                                    'AnioFabricacionVehiculo': $('#txtAnioFabricacion').val(),
                                    'DependenciaAsignadaVehiculo': $('#txtDependenciaA').val(),
                                    'EstadoOperatividadVehiculo': $('#txtEstadoOperatividadV').val(),
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
                                    $('#tblDitranavVehiculosTerActividadInsti').DataTable().ajax.reload();
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
                                url: '/DitranavVehiculosTerActividadInsti/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'PlacaVehiculo': $('#txtPlacaVehiculoe').val(),
                                    'ClasificacionFlotaVehiculo': $('#txtClasificacionFlotaVe').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoMarcaVehiculo': $('#cbMarcae').val(),
                                    'AnioFabricacionVehiculo': $('#txtAnioFabricacione').val(),
                                    'DependenciaAsignadaVehiculo': $('#txtDependenciaAe').val(),
                                    'EstadoOperatividadVehiculo': $('#txtEstadoOperatividadVe').val(),
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
                                    $('#tblDitranavVehiculosTerActividadInsti').DataTable().ajax.reload();
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

    tblDitranavVehiculosTerActividadInsti = $('#tblDitranavVehiculosTerActividadInsti').DataTable({
        ajax: {
            "url": '/DitranavVehiculosTerActividadInsti/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "vehiculosTerActividadInstitucionId" },
            { "data": "placaVehiculo" },
            { "data": "clasificacionFlotaVehiculo" },
            { "data": "descZonaNaval" },
            { "data": "clasificacionVehiculo" },
            { "data": "anioFabricacionVehiculo" },
            { "data": "dependenciaAsignadaVehiculo" },
            { "data": "estadoOperatividadVehiculo" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.vehiculosTerActividadInstitucionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.vehiculosTerActividadInstitucionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Ditranav - Vehículos de Transporte Terrestre usados en Actividades de la Institución',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Ditranav - Vehículos de Transporte Terrestre usados en Actividades de la Institución',
                title: 'Ditranav - Vehículos de Transporte Terrestre usados en Actividades de la Institución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Ditranav - Vehículos de Transporte Terrestre usados en Actividades de la Institución',
                title: 'Ditranav - Vehículos de Transporte Terrestre usados en Actividades de la Institución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Ditranav - Vehículos de Transporte Terrestre usados en Actividades de la Institución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    tblDitranavVehiculosTerActividadInsti.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDitranavVehiculosTerActividadInsti.columns(8).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DitranavVehiculosTerActividadInsti/Mostrar?Id=' + Id, [], function (VehiculosTerActividadInstitucionDTO) {
        $('#txtCodigo').val(VehiculosTerActividadInstitucionDTO.vehiculosTerActividadInstitucionId);
        $('#txtPlacaVehiculoe').val(VehiculosTerActividadInstitucionDTO.placaVehiculo);
        $('#txtClasificacionFlotaVe').val(VehiculosTerActividadInstitucionDTO.clasificacionFlotaVehiculo);
        $('#cbZonaNavale').val(VehiculosTerActividadInstitucionDTO.codigoZonaNaval);
        $('#cbMarcae').val(VehiculosTerActividadInstitucionDTO.codigoMarcaVehiculo);
        $('#txtAnioFabricacione').val(VehiculosTerActividadInstitucionDTO.anioFabricacionVehiculo);
        $('#txtDependenciaAe').val(VehiculosTerActividadInstitucionDTO.dependenciaAsignadaVehiculo);
        $('#txtEstadoOperatividadVe').val(VehiculosTerActividadInstitucionDTO.estadoOperatividadVehiculo);
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
                url: '/DitranavVehiculosTerActividadInsti/Eliminar',
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
                    $('#tblDitranavVehiculosTerActividadInsti').DataTable().ajax.reload();
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
                url: '/DitranavVehiculosTerActividadInsti/EliminarCarga',
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
                    $('#tblDitranavVehiculosTerActividadInsti').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDitranavVehiculosTerActividadInsti() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DitranavVehiculosTerActividadInsti/MostrarDatos',
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
                            $("<td>").text(item.placaVehiculo),
                            $("<td>").text(item.clasificacionFlotaVehiculo),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoMarcaVehiculo),
                            $("<td>").text(item.anioFabricacionVehiculo),
                            $("<td>").text(item.dependenciaAsignadaVehiculo),
                            $("<td>").text(item.estadoOperatividadVehiculo),
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
    fetch("DitranavVehiculosTerActividadInsti/EnviarDatos", {
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
                    'Ocurrio un problema.' +mensaje,
                    'error'
                )
            }
        })
}
function cargaDatos() {
    $.getJSON('/DitranavVehiculosTerActividadInsti/cargaCombs', [], function (Json) {
        var zonaNaval = Json["data1"];
        var marcaVehiculo = Json["data2"];
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

        $("select#cbZonaNaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
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
        reporteSeleccionado = '/DitranavVehiculosTerActividadInsti/ReporteDVTAI';
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