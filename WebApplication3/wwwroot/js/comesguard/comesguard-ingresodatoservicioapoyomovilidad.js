var tblComesguardIngresoDatoServicioApoyoMovilidad;
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
                                url: '/ComesguardIngresoDatoServicioApoyoMovilidad/Insertar',
                                data: {
                                    'FechaInicio': $('#txtFechaInicio').val(),
                                    'FechaTermino': $('#txtFechaTermino').val(),
                                    'CodigoDependencia ': $('#cbDependencia').val(),
                                    'CodigoClaseVehiculo ': $('#cbClaseVehiculo').val(),
                                    'CodigoMarcaVehiculo ': $('#cbMarcaVehiculo').val(),
                                    'PlacaVehiculo': $('#txtPlacaVehiculo').val(),
                                    'CodigoEstadoOperativo ': $('#cbEstadoOperativo').val(), 
                                    'CargaId': $('#cargasR').val(), 
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
                                    $('#tblComesguardIngresoDatoServicioApoyoMovilidad').DataTable().ajax.reload();
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
                                url: '/ComesguardIngresoDatoServicioApoyoMovilidad/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaInicio': $('#txtFechaInicioe').val(),
                                    'FechaTermino': $('#txtFechaTerminoe').val(),
                                    'CodigoDependencia ': $('#cbDependenciae').val(),
                                    'CodigoClaseVehiculo ': $('#cbClaseVehiculoe').val(),
                                    'CodigoMarcaVehiculo ': $('#cbMarcaVehiculoe').val(),
                                    'PlacaVehiculo': $('#txtPlacaVehiculoe').val(),
                                    'CodigoEstadoOperativo ': $('#cbEstadoOperativoe').val(), 
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
                                    $('#tblComesguardIngresoDatoServicioApoyoMovilidad').DataTable().ajax.reload();
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

        tblComesguardIngresoDatoServicioApoyoMovilidad = $('#tblComesguardIngresoDatoServicioApoyoMovilidad').DataTable({
        ajax: {
            "url": '/ComesguardIngresoDatoServicioApoyoMovilidad/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ingresoDatoServicioApoyoMovilidadId" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "nombreDependencia" },
            { "data": "clasificacion" },
            { "data": "clasificacionVehiculo" },
            { "data": "placaVehiculo" },
            { "data": "descEstadoOperativo" }, 
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ingresoDatoServicioApoyoMovilidadId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ingresoDatoServicioApoyoMovilidadId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de apoyo con movilidad',
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
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de apoyo con movilidad',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de apoyo con movilidad',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de apoyo con movilidad',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de apoyo con movilidad',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de apoyo con movilidad',
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
    tblComesguardIngresoDatoServicioApoyoMovilidad.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComesguardIngresoDatoServicioApoyoMovilidad.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComesguardIngresoDatoServicioApoyoMovilidad/Mostrar?Id=' + Id, [], function (IngresoDatoServicioApoyoMovilidadDTO) {
        $('#txtCodigo').val(IngresoDatoServicioApoyoMovilidadDTO.ingresoDatoServicioApoyoMovilidadId);
        $('#txtFechaInicioe').val(IngresoDatoServicioApoyoMovilidadDTO.fechaInicio);
        $('#txtFechaTerminoe').val(IngresoDatoServicioApoyoMovilidadDTO.fechaTermino);
        $('#cbDependenciae').val(IngresoDatoServicioApoyoMovilidadDTO.codigoDependencia);
        $('#cbClaseVehiculoe').val(IngresoDatoServicioApoyoMovilidadDTO.codigoClaseVehiculo);
        $('#cbMarcaVehiculoe').val(IngresoDatoServicioApoyoMovilidadDTO.codigoMarcaVehiculo);
        $('#txtPlacaVehiculoe').val(IngresoDatoServicioApoyoMovilidadDTO.placaVehiculo);
        $('#cbEstadoOperativoe').val(IngresoDatoServicioApoyoMovilidadDTO.codigoEstadoOperativo);
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
                url: '/ComesguardIngresoDatoServicioApoyoMovilidad/Eliminar',
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
                    $('#tblComesguardIngresoDatoServicioApoyoMovilidad').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComesguardIngresoDatoServicioApoyoMovilidad() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComesguardIngresoDatoServicioApoyoMovilidad/MostrarDatos',
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
                            $("<td>").text(item.fechaInicio),
                            $("<td>").text(item.fechaTermino),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoClaseVehiculo),
                            $("<td>").text(item.codigoMarcaVehiculo),
                            $("<td>").text(item.placaVehiculo),
                            $("<td>").text(item.codigoEstadoOperativo),
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
    fetch("ComesguardIngresoDatoServicioApoyoMovilidad/EnviarDatos", {
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
    $.getJSON('/ComesguardIngresoDatoServicioApoyoMovilidad/cargaCombs', [], function (Json) {
        var dependencia = Json["data1"];
        var claseVehiculo = Json["data2"];
        var marcaVehiculo = Json["data3"];
        var estadoOperativo = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbClaseVehiculo").html("");
        $.each(claseVehiculo, function () {
            var RowContent = '<option value=' + this.codigoClaseVehiculo + '>' + this.clasificacion + '</option>'
            $("select#cbClaseVehiculo").append(RowContent);
        });
        $("select#cbClaseVehiculoe").html("");
        $.each(claseVehiculo, function () {
            var RowContent = '<option value=' + this.codigoClaseVehiculo + '>' + this.clasificacion + '</option>'
            $("select#cbClaseVehiculoe").append(RowContent);
        });


        $("select#cbMarcaVehiculo").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.codigoMarcaVehiculo + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarcaVehiculo").append(RowContent);
        });
        $("select#cbMarcaVehiculoe").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.codigoMarcaVehiculo + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarcaVehiculoe").append(RowContent);
        });


        $("select#cbEstadoOperativo").html("");
        $.each(estadoOperativo, function () {
            var RowContent = '<option value=' + this.codigoEstadoOperativo + '>' + this.descEstadoOperativo + '</option>'
            $("select#cbEstadoOperativo").append(RowContent);
        });
        $("select#cbEstadoOperativoe").html("");
        $.each(estadoOperativo, function () {
            var RowContent = '<option value=' + this.codigoEstadoOperativo + '>' + this.descEstadoOperativo + '</option>'
            $("select#cbEstadoOperativoe").append(RowContent);
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
        reporteSeleccionado = '/ComesguardIngresoDatoServicioApoyoMovilidad/ReporteCIDSAM?idCarga=';
        $('#fecha').hide();
    }

}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect = 1) {
        a.href = reporteSeleccionado + idCarga;
    }
    a.click();
});