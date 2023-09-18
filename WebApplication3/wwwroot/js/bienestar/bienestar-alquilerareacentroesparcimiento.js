var tblBienestarAlquilerAreaCentroEsparcimiento;
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
                                url: '/BienestarAlquilerAreaCentroEsparcimiento/Insertar',
                                data: {
                                    'FechaAlquiler': $('#txtFechaVisitaC').val(),
                                    'DNIUsuario': $('#txtDNIUsuario').val(),
                                    'CodigoUsuarioAlquilerCentroEsparcimiento': $('#cbUsuarioCentroE').val(),
                                    'CodigoClubEsparcimiento': $('#cbClubEsparcimiento').val(),
                                    'CodigoAreaSalonClubEsparcimiento': $('#cbAreasSalonesClubE').val(),
                                    'CodigoTipoEvento': $('#cbTipoEvento').val(),
                                    'HoraInicio': $('#txtHoraInicio').val(),
                                    'HoraTermino': $('#txtHoraTermino').val(),
                                    'NumeroHoras': $('#txtNumeroHoras').val(),
                                    'NumeroInvitados': $('#txtNumeroInvitados').val(), 
                                    'MontoFacturado': $('#txtMontoFacturado').val(),
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
                                    $('#tblBienestarAlquilerAreaCentroEsparcimiento').DataTable().ajax.reload();
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
                                url: '/BienestarAlquilerAreaCentroEsparcimiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaAlquiler': $('#txtFechaVisitaCe').val(),
                                    'DNIUsuario': $('#txtDNIUsuarioe').val(),
                                    'CodigoUsuarioAlquilerCentroEsparcimiento': $('#cbUsuarioCentroEe').val(),
                                    'CodigoClubEsparcimiento': $('#cbClubEsparcimientoe').val(),
                                    'CodigoAreaSalonClubEsparcimiento': $('#cbAreasSalonesClubEe').val(),
                                    'CodigoTipoEvento': $('#cbTipoEventoe').val(),
                                    'HoraInicio': $('#txtHoraInicioe').val(),
                                    'HoraTermino': $('#txtHoraTerminoe').val(),
                                    'NumeroHoras': $('#txtNumeroHorase').val(),
                                    'NumeroInvitados': $('#txtNumeroInvitadose').val(), 
                                    'MontoFacturado': $('#txtMontoFacturadoe').val(),
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
                                    $('#tblBienestarAlquilerAreaCentroEsparcimiento').DataTable().ajax.reload();
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


    tblBienestarAlquilerAreaCentroEsparcimiento = $('#tblBienestarAlquilerAreaCentroEsparcimiento').DataTable({
        ajax: {
            "url": '/BienestarAlquilerAreaCentroEsparcimiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alquilerAreaCentroEsparcimientoId" },
            { "data": "fechaAlquiler" },
            { "data": "dniUsuario" },
            { "data": "descUsuarioAlquilerCentroEsparcimiento" },
            { "data": "descClubEsparcimiento" },
            { "data": "descAreaSalonClubEsparcimiento" },
            { "data": "descTipoEvento" },
            { "data": "horaInicio" },
            { "data": "horaTermino" },
            { "data": "numeroHoras" },
            { "data": "numeroInvitados" },
            { "data": "montoFacturado" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alquilerAreaCentroEsparcimientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alquilerAreaCentroEsparcimientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Alquiler de Areas y Salones de los Centros de Esparcimiento',
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
                filename: 'Bienestar - Alquiler de Areas y Salones de los Centros de Esparcimiento',
                title: 'Bienestar - Alquiler de Areas y Salones de los Centros de Esparcimiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Alquiler de Areas y Salones de los Centros de Esparcimiento',
                title: 'Bienestar - Alquiler de Areas y Salones de los Centros de Esparcimiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Alquiler de Areas y Salones de los Centros de Esparcimiento',
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
    tblBienestarAlquilerAreaCentroEsparcimiento.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarAlquilerAreaCentroEsparcimiento.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarAlquilerAreaCentroEsparcimiento/Mostrar?Id=' + Id, [], function (AlquilerAreaCentroEsparcimientoDTO) {
        $('#txtCodigo').val(AlquilerAreaCentroEsparcimientoDTO.alquilerAreaCentroEsparcimientoId);
        $('#txtFechaVisitaCe').val(AlquilerAreaCentroEsparcimientoDTO.fechaAlquiler);
        $('#txtDNIUsuarioe').val(AlquilerAreaCentroEsparcimientoDTO.dniUsuario);
        $('#cbUsuarioCentroEe').val(AlquilerAreaCentroEsparcimientoDTO.codigoUsuarioAlquilerCentroEsparcimiento);
        $('#cbClubEsparcimientoe').val(AlquilerAreaCentroEsparcimientoDTO.codigoClubEsparcimiento);
        $('#cbAreasSalonesClubEe').val(AlquilerAreaCentroEsparcimientoDTO.codigoAreaSalonClubEsparcimiento);
        $('#cbTipoEventoe').val(AlquilerAreaCentroEsparcimientoDTO.codigoTipoEvento);
        $('#txtHoraInicioe').val(AlquilerAreaCentroEsparcimientoDTO.horaInicio);
        $('#txtHoraTerminoe').val(AlquilerAreaCentroEsparcimientoDTO.horaTermino);
        $('#txtNumeroHorase').val(AlquilerAreaCentroEsparcimientoDTO.numeroHoras);
        $('#txtNumeroInvitadose').val(AlquilerAreaCentroEsparcimientoDTO.numeroInvitados); 
        $('#txtMontoFacturadoe').val(AlquilerAreaCentroEsparcimientoDTO.montoFacturado);
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
                url: '/BienestarAlquilerAreaCentroEsparcimiento/Eliminar',
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
                    $('#tblBienestarAlquilerAreaCentroEsparcimiento').DataTable().ajax.reload();
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
                url: '/BienestarAlquilerAreaCentroEsparcimiento/EliminarCarga',
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
                    $('#tblBienestarAlquilerAreaCentroEsparcimiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaBienestarAlquilerAreaCentroEsparcimiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarAlquilerAreaCentroEsparcimiento/MostrarDatos',
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
                            $("<td>").text(item.fechaAlquiler),
                            $("<td>").text(item.dniUsuario),
                            $("<td>").text(item.codigoUsuarioAlquilerCentroEsparcimiento),
                            $("<td>").text(item.codigoClubEsparcimiento),
                            $("<td>").text(item.codigoAreaSalonClubEsparcimiento),
                            $("<td>").text(item.codigoTipoEvento),
                            $("<td>").text(item.horaInicio),
                            $("<td>").text(item.horaTermino),
                            $("<td>").text(item.numeroHoras),
                            $("<td>").text(item.numeroInvitados),
                            $("<td>").text(item.montoFacturado)
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
    fetch("BienestarAlquilerAreaCentroEsparcimiento/EnviarDatos", {
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
    $.getJSON('/BienestarAlquilerAreaCentroEsparcimiento/cargaCombs', [], function (Json) {
        var usuarioCentroEsparcimiento = Json["data1"];
        var clubEsparcimiento = Json["data2"];
        var tipoEvento = Json["data3"];
        var areaSalonClubEsparcimiento = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbUsuarioCentroE").html("");
        $("select#cbUsuarioCentroEe").html("");
        $.each(usuarioCentroEsparcimiento, function () {
            var RowContent = '<option value=' + this.codigoUsuarioAlquilerCentroEsparcimiento + '>' + this.descUsuarioAlquilerCentroEsparcimiento + '</option>'
            $("select#cbUsuarioCentroE").append(RowContent);
            $("select#cbUsuarioCentroEe").append(RowContent);
        });

        $("select#cbClubEsparcimiento").html("");
        $("select#cbClubEsparcimientoe").html("");
        $.each(clubEsparcimiento, function () {
            var RowContent = '<option value=' + this.codigoClubEsparcimiento + '>' + this.descClubEsparcimiento + '</option>'
            $("select#cbClubEsparcimiento").append(RowContent);
            $("select#cbClubEsparcimientoe").append(RowContent);
        });

        $("select#cbTipoEvento").html("");
        $("select#cbTipoEventoe").html("");
        $.each(tipoEvento, function () {
            var RowContent = '<option value=' + this.codigoTipoEvento + '>' + this.descTipoEvento + '</option>'
            $("select#cbTipoEvento").append(RowContent);
            $("select#cbTipoEventoe").append(RowContent);
        });

        $("select#cbAreasSalonesClubE").html("");
        $("select#cbAreasSalonesClubEe").html("");
        $.each(areaSalonClubEsparcimiento, function () {
            var RowContent = '<option value=' + this.codigoAreaSalonClubEsparcimiento + '>' + this.descAreaSalonClubEsparcimiento + '</option>'
            $("select#cbAreasSalonesClubE").append(RowContent);
            $("select#cbAreasSalonesClubEe").append(RowContent);
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
        reporteSeleccionado = '/BienestarAlquilerAreaCentroEsparcimiento/ReporteBACE?idCarga=';
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

