﻿var tblComzotresBandaMusicoComzotres;
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
                                url: '/ComzotresBandaMusicoComzotres/Insertar',
                                data: {
                                    'CodigoTipoComision': $('#cbComision').val(),
                                    'CodigoEvento': $('#cbEvento').val(),
                                    'CodigoGrupoComisionado': $('#cbComisionado').val(),
                                    'CodigoVestimentaUniforme': $('#cbVestimenta').val(),
                                    'NombreEvento': $('#txtEvento').val(),
                                    'Lugar': $('#txtLugar').val(),
                                    'FechaHoraSalida': $('#txtFechaSalida').val(),
                                    'FechaHoraInicio': $('#txtFechaInicio').val(),
                                    'FechaHoraTermino': $('#txtFechaTermino').val(),
                                    'RequerimientoMovilidad': $('#txtRequerimiento').val(),
                                    'Observacion': $('#txtObservacion').val(),
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
                                    $('#tblComzotresBandaMusicoComzotres').DataTable().ajax.reload();
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
                                url: '/ComzotresBandaMusicoComzotres/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(), 
                                    'CodigoTipoComision': $('#cbComisione').val(),
                                    'CodigoEvento': $('#cbEventoe').val(),
                                    'CodigoGrupoComisionado': $('#cbComisionadoe').val(),
                                    'CodigoVestimentaUniforme': $('#cbVestimentae').val(),
                                    'NombreEvento': $('#txtEventoe').val(),
                                    'Lugar': $('#txtLugare').val(),
                                    'FechaHoraSalida': $('#txtFechaSalidae').val(),
                                    'FechaHoraInicio': $('#txtFechaInicioe').val(),
                                    'FechaHoraTermino': $('#txtFechaTerminoe').val(),
                                    'RequerimientoMovilidad': $('#txtRequerimientoe').val(),
                                    'Observacion': $('#txtObservacione').val(), 
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
                                    $('#tblComzotresBandaMusicoComzotres').DataTable().ajax.reload();
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

    tblComzotresBandaMusicoComzotres = $('#tblComzotresBandaMusicoComzotres').DataTable({
        ajax: {
            "url": '/ComzotresBandaMusicoComzotres/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "bandaMusicoComzotresId" },
            { "data": "descTipoComision" },
            { "data": "descEvento" },
            { "data": "descGrupoComisionado" },
            { "data": "descVestimentaUniforme" },  
            { "data": "nombreEvento" },
            { "data": "lugar" },
            { "data": "fechaHoraSalida" },
            { "data": "fechaHoraInicio" },
            { "data": "fechaHoraTermino" },
            { "data": "requerimientoMovilidad" },
            { "data": "observacion" },
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.bandaMusicoComzotresId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.bandaMusicoComzotresId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzotres - Banda de Musicos',
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
                filename: 'Comzotres - Banda de Musicos',
                title: 'Comzotres - Banda de Musicos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzotres - Banda de Musicos',
                title: 'Comzotres - Banda de Musicos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzotres - Banda de Musicos',
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
    tblComzotresBandaMusicoComzotres.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComzotresBandaMusicoComzotres.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzotresBandaMusicoComzotres/Mostrar?Id=' + Id, [], function (BandaMusicoComzotresDTO) {
        $('#txtCodigo').val(BandaMusicoComzotresDTO.bandaMusicoComzotresId);
        $('#cbComisione').val(BandaMusicoComzotresDTO.codigoTipoComision);
        $('#cbEventoe').val(BandaMusicoComzotresDTO.codigoEvento);
        $('#cbComisionadoe').val(BandaMusicoComzotresDTO.codigoGrupoComisionado);
        $('#cbVestimentae').val(BandaMusicoComzotresDTO.codigoVestimentaUniforme);
        $('#txtEventoe').val(BandaMusicoComzotresDTO.nombreEvento);
        $('#txtLugare').val(BandaMusicoComzotresDTO.lugar);
        $('#txtFechaSalidae').val(BandaMusicoComzotresDTO.fechaHoraSalida);
        $('#txtFechaInicioe').val(BandaMusicoComzotresDTO.fechaHoraInicio);
        $('#txtFechaTerminoe').val(BandaMusicoComzotresDTO.fechaHoraTermino);
        $('#txtRequerimientoe').val(BandaMusicoComzotresDTO.requerimientoMovilidad);
        $('#txtObservacione').val(BandaMusicoComzotresDTO.observacion); 
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
                url: '/ComzotresBandaMusicoComzotres/Eliminar',
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
                    $('#tblComzotresBandaMusicoComzotres').DataTable().ajax.reload();
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
                url: '/ComzotresBandaMusicoComzotres/EliminarCarga',
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
                    $('#tblComzotresBandaMusicoComzotres').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComzotresBandaMusicoComzotres() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComzotresBandaMusicoComzotres/MostrarDatos',
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
                            $("<td>").text(item.codigoTipoComision),
                            $("<td>").text(item.codigoEvento),
                            $("<td>").text(item.codigoGrupoComisionado),
                            $("<td>").text(item.codigoVestimentaUniforme),
                            $("<td>").text(item.nombreEvento),
                            $("<td>").text(item.lugar),
                            $("<td>").text(item.fechaHoraSalida),
                            $("<td>").text(item.fechaHoraInicio),
                            $("<td>").text(item.fechaHoraTermino),
                            $("<td>").text(item.requerimientoMovilidad),
                            $("<td>").text(item.observacion)
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
    fetch("ComzotresBandaMusicoComzotres/EnviarDatos", {
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
    $.getJSON('/ComzotresBandaMusicoComzotres/cargaCombs', [], function (Json) {
        var tipoComision = Json["data1"];
        var evento = Json["data2"];
        var grupoComisionado = Json["data3"];
        var vestimentaUniforme = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbComision").html("");
        $("select#cbComisione").html("");
        $.each(tipoComision, function () {
            var RowContent = '<option value=' + this.codigoTipoComision + '>' + this.descTipoComision + '</option>'
            $("select#cbComision").append(RowContent);
            $("select#cbComisione").append(RowContent);
        });

        $("select#cbEvento").html("");
        $("select#cbEventoe").html("");
        $.each(evento, function () {
            var RowContent = '<option value=' + this.codigoEvento + '>' + this.descEvento + '</option>'
            $("select#cbEvento").append(RowContent);
            $("select#cbEventoe").append(RowContent);
        });

        $("select#cbComisionado").html("");
        $("select#cbComisionadoe").html("");
        $.each(grupoComisionado, function () {
            var RowContent = '<option value=' + this.codigoGrupoComisionado + '>' + this.descGrupoComisionado + '</option>'
            $("select#cbComisionado").append(RowContent);
            $("select#cbComisionadoe").append(RowContent);
        });

        $("select#cbVestimenta").html("");
        $("select#cbVestimentae").html("");
        $.each(vestimentaUniforme, function () {
            var RowContent = '<option value=' + this.codigoVestimentaUniforme + '>' + this.descVestimentaUniforme + '</option>'
            $("select#cbVestimenta").append(RowContent);
            $("select#cbVestimentae").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    }) 
}

function optReporte(id) {
    optReporteSelect = id;

    reporteSeleccionado = '/ComzotresBandaMusicoComzotres/ReporteARTR';
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

