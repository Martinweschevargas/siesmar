var tblComzodosServicioDispositivoSeguridadPrestado;

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
                                url: '/ComzodosServicioDispositivoSeguridadPrestado/Insertar',
                                data: {
                                    'FechaSolicitud': $('#txtFechaSoli').val(),
                                    'CodigoZonaNaval': $('#cbZona').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'FechaHoraInicio': $('#txtFechaIni').val(),
                                    'FechaHoraTermino': $('#txtFechaTer').val(),
                                    'EfectivoParticipante': $('#txtParticipante').val(),
                                    'Lugar': $('#txtLugar').val(),
                                    'DistritoUbigeo': $('#cbDistrito').val(),
                                    'ObservacionServicioDispositivo': $('#txtObservacion').val(),
                                    'ComisionPorMes': $('#txtComision').val(), 
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
                                    $('#tblComzodosServicioDispositivoSeguridadPrestado').DataTable().ajax.reload();
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
                                url: '/ComzodosServicioDispositivoSeguridadPrestado/Actualizar',
                                data: {
                                    'ServicioDispositivoSeguridadPrestadoId': $('#txtCodigo').val(),
                                    'FechaSolicitud': $('#txtFechaSolie').val(),
                                    'CodigoZonaNaval': $('#cbZonae').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'FechaHoraInicio': $('#txtFechaInie').val(),
                                    'FechaHoraTermino': $('#txtFechaTere').val(),
                                    'EfectivoParticipante': $('#txtParticipantee').val(),
                                    'Lugar': $('#txtLugare').val(),
                                    'DistritoUbigeo': $('#cbDistritoe').val(),
                                    'ObservacionServicioDispositivo': $('#txtObservacione').val(),
                                    'ComisionPorMes': $('#txtComisione').val(), 
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
                                    $('#tblComzodosServicioDispositivoSeguridadPrestado').DataTable().ajax.reload();
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

    $('#tblComzodosServicioDispositivoSeguridadPrestado').DataTable({
        ajax: {
            "url": '/ComzodosServicioDispositivoSeguridadPrestado/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioDispositivoSeguridadPrestadoId" },
            { "data": "fechaSolicitud" },
            { "data": "descZonaNaval" },
            { "data": "descDependencia" },
            { "data": "fechaHoraInicio" },
            { "data": "fechaHoraTermino" },
            { "data": "efectivoParticipante" },
            { "data": "lugar" },  
            { "data": "descDistrito" },
            { "data": "observacionServicioDispositivo" },
            { "data": "comisionPorMes" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioDispositivoSeguridadPrestadoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioDispositivoSeguridadPrestadoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzodos - Servicios de Dispositivos de Seguridad Prestados',
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
                filename: 'Comzodos - Servicios de Dispositivos de Seguridad Prestados',
                title: 'Comzodos - Servicios de Dispositivos de Seguridad Prestados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzodos - Servicios de Dispositivos de Seguridad Prestados',
                title: 'Comzodos - Servicios de Dispositivos de Seguridad Prestados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzodos - Servicios de Dispositivos de Seguridad Prestados',
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
    tblComzodosServicioDispositivoSeguridadPrestado.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComzodosServicioDispositivoSeguridadPrestado.columns(11).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzodosServicioDispositivoSeguridadPrestado/Mostrar?Id=' + Id, [], function (ServicioDispositivoSeguridadPrestadoDTO) {
        $('#txtCodigo').val(ServicioDispositivoSeguridadPrestadoDTO.servicioDispositivoSeguridadPrestadoId);
        $('#txtFechaSolie').val(ServicioDispositivoSeguridadPrestadoDTO.fechaSolicitud);
        $('#cbZonae').val(ServicioDispositivoSeguridadPrestadoDTO.codigoZonaNaval);
        $('#cbDependenciae').val(ServicioDispositivoSeguridadPrestadoDTO.codigoDependencia);
        $('#txtFechaInie').val(ServicioDispositivoSeguridadPrestadoDTO.fechaHoraInicio);
        $('#txtFechaTere').val(ServicioDispositivoSeguridadPrestadoDTO.fechaHoraTermino);
        $('#txtParticipantee').val(ServicioDispositivoSeguridadPrestadoDTO.efectivoParticipante);
        $('#txtLugare').val(ServicioDispositivoSeguridadPrestadoDTO.lugar);
        $('#cbDistritoe').val(ServicioDispositivoSeguridadPrestadoDTO.distritoUbigeo);
        $('#txtObservacione').val(ServicioDispositivoSeguridadPrestadoDTO.observacionServicioDispositivo);
        $('#txtComisione').val(ServicioDispositivoSeguridadPrestadoDTO.comisionPorMes);
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
                url: '/ComzodosServicioDispositivoSeguridadPrestado/Eliminar',
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
                    $('#tblComzodosServicioDispositivoSeguridadPrestado').DataTable().ajax.reload();
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
                url: '/ComzodosServicioDispositivoSeguridadPrestado/EliminarCarga',
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
                    $('#tblComzodosServicioDispositivoSeguridadPrestado').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComzodosServicioDispositivoSeguridadPrestado() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComzodosServicioDispositivoSeguridadPrestado/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.fechaSolicitud),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.fechaHoraInicio),
                            $("<td>").text(item.fechaHoraTermino),
                            $("<td>").text(item.efectivoParticipante),
                            $("<td>").text(item.lugar),
                            $("<td>").text(item.distritoUbigeo),
                            $("<td>").text(item.observacionServicioDispositivo),
                            $("<td>").text(item.comisionPorMes)

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
    fetch("ComzodosServicioDispositivoSeguridadPrestado/EnviarDatos", {
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
    $.getJSON('/ComzodosServicioDispositivoSeguridadPrestado/cargaCombs', [], function (Json) {
        var zonaNaval = Json["data1"];
        var dependencia = Json["data2"];
        var distritoUbigeo = Json["data3"];
        var listaCargas = Json["data4"];

        $("select#cbZona").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZona").append(RowContent);
        });
        $("select#cbZonae").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonae").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbDistrito").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistrito").append(RowContent);
        });

        $("select#cbDistritoe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoe").append(RowContent);
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

    reporteSeleccionado = '/ComzodosServicioDispositivoSeguridadPrestado/ReporteARTR';
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

