var tblBienestarVisitaCentroEsparcimiento;
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
                                url: '/BienestarVisitaCentroEsparcimiento/Insertar',
                                data: {
                                    'FechaVisitaCentro': $('#txtFechaVisitaC').val(),
                                    'DNIUsuario': $('#txtDNIUsuario').val(),
                                    'CodigoUsuarioCentroEsparcimiento': $('#cbUsuarioCentroE').val(),
                                    'CodigoClubEsparcimiento': $('#cbClubEsparcimiento').val(),
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
                                    $('#tblBienestarVisitaCentroEsparcimiento').DataTable().ajax.reload();
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
                                url: '/BienestarVisitaCentroEsparcimiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaVisitaCentro': $('#txtFechaVisitaCe').val(),
                                    'DNIUsuario': $('#txtDNIUsuarioe').val(),
                                    'CodigoUsuarioCentroEsparcimiento': $('#cbUsuarioCentroEe').val(),
                                    'CodigoClubEsparcimiento': $('#cbClubEsparcimientoe').val(),
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
                                    $('#tblBienestarVisitaCentroEsparcimiento').DataTable().ajax.reload();
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


    tblBienestarVisitaCentroEsparcimiento=  $('#tblBienestarVisitaCentroEsparcimiento').DataTable({
        ajax: {
            "url": '/BienestarVisitaCentroEsparcimiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "visitaCentroEsparcimientoId" },
            { "data": "fechaVisitaCentro" },
            { "data": "dniUsuario" },
            { "data": "descUsuarioCentroEsparcimiento" },
            { "data": "descClubEsparcimiento" },
            { "data": "numeroHoras" },
            { "data": "numeroInvitados" },
            { "data": "montoFacturado" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.visitaCentroEsparcimientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.visitaCentroEsparcimientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Visitas a Centros de Esparcimiento',
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
                filename: 'Bienestar - Visitas a Centros de Esparcimiento',
                title: 'Bienestar - Visitas a Centros de Esparcimiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Visitas a Centros de Esparcimiento',
                title: 'Bienestar - Visitas a Centros de Esparcimiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Visitas a Centros de Esparcimiento',
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
    tblBienestarVisitaCentroEsparcimiento.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarVisitaCentroEsparcimiento.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarVisitaCentroEsparcimiento/Mostrar?Id=' + Id, [], function (VisitaCentroEsparcimientoDTO) {
        $('#txtCodigo').val(VisitaCentroEsparcimientoDTO.visitaCentroEsparcimientoId);
        $('#txtFechaVisitaCe').val(VisitaCentroEsparcimientoDTO.fechaVisitaCentro);
        $('#txtDNIUsuarioe').val(VisitaCentroEsparcimientoDTO.dniUsuario);
        $('#cbUsuarioCentroEe').val(VisitaCentroEsparcimientoDTO.codigoUsuarioCentroEsparcimiento);
        $('#cbClubEsparcimientoe').val(VisitaCentroEsparcimientoDTO.codigoClubEsparcimiento);
        $('#txtNumeroHorase').val(VisitaCentroEsparcimientoDTO.numeroHoras);
        $('#txtNumeroInvitadose').val(VisitaCentroEsparcimientoDTO.numeroInvitados);
        $('#txtMontoFacturadoe').val(VisitaCentroEsparcimientoDTO.montoFacturado);
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
                url: '/BienestarVisitaCentroEsparcimiento/Eliminar',
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
                    $('#tblBienestarVisitaCentroEsparcimiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarVisitaCentroEsparcimiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarVisitaCentroEsparcimiento/MostrarDatos',
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
                            $("<td>").text(item.fechaVisitaCentro),
                            $("<td>").text(item.dniUsuario),
                            $("<td>").text(item.codigoUsuarioCentroEsparcimiento),
                            $("<td>").text(item.codigoClubEsparcimiento),
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
    fetch("BienestarVisitaCentroEsparcimiento/EnviarDatos", {
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
                url: '/BienestarVisitaCentroEsparcimiento/EliminarCarga',
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
                    $('#tblBienestarVisitaCentroEsparcimiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarVisitaCentroEsparcimiento/cargaCombs', [], function (Json) {
        var usuarioCentroEsparcimiento = Json["data1"];
        var clubEsparcimiento = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbUsuarioCentroE").html("");
        $("select#cbUsuarioCentroEe").html("");
        $.each(usuarioCentroEsparcimiento, function () {
            var RowContent = '<option value=' + this.codigoUsuarioCentroEsparcimiento + '>' + this.descUsuarioCentroEsparcimiento + '</option>'
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
        reporteSeleccionado = '/BienestarVisitaCentroEsparcimiento/ReporteBVCE?idCarga=';
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