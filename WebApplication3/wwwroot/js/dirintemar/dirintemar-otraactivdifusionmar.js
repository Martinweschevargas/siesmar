var tblDirintemarOtraActividadDifusionMar;

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
                                url: '/DirintemarOtraActividadDifusionMar/Insertar',
                                data: {
                                    'TipoActividadDifusionId': $('#cbTipoActivDifusion').val(),
                                    'NombreOtraActDifusionMar': $('#txtNombreOActiv').val(),
                                    'AreaOtraActDifusionMar': $('#txtArea').val(),
                                    'ResponsableOtraActDifusionMar': $('#txtResponsable').val(),
                                    'InicioOtraActDifusionMar': $('#txtFechaI').val(),
                                    'TerminoOtraActDifusionMar': $('#txtFechaT').val(),
                                    'LugarOtraActDifusionMar': $('#txtLugar').val(),
                                    'DirigidoAId': $('#cbDirigido').val(),
                                    'QParticipanteOtraActDifusionMar': $('#txtParticipante').val(),
                                    'QParticipanteEncuestaOtra': $('#txtParticipanteE').val(),
                                    'QPreguntaEncuestaOtraOBS': $('#txtParticipantesEOBS').val(),
                                    'RptaCorrectaEncuentaOtra': $('#txtRespuestaC').val(),
                                    'RptaIncorrectaEncuentaOtra': $('#txtRespuestaI').val(),
                                    'PorcentRptaCorrectaEncuentaOtra': $('#txtPorcentajeR').val(),
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
                                    $('#tblDirintemarOtraActividadDifusionMar').DataTable().ajax.reload();
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
                                url: '/DirintemarOtraActividadDifusionMar/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoActividadDifusionId': $('#cbTipoActivDifusione').val(),
                                    'NombreOtraActDifusionMar': $('#txtNombreOActive').val(),
                                    'AreaOtraActDifusionMar': $('#txtAreae').val(),
                                    'ResponsableOtraActDifusionMar': $('#txtResponsablee').val(),
                                    'InicioOtraActDifusionMar': $('#txtFechaIe').val(),
                                    'TerminoOtraActDifusionMar': $('#txtFechaTe').val(),
                                    'LugarOtraActDifusionMar': $('#txtLugare').val(),
                                    'DirigidoAId': $('#cbDirigidoe').val(),
                                    'QParticipanteOtraActDifusionMar': $('#txtParticipantee').val(),
                                    'QParticipanteEncuestaOtra': $('#txtParticipanteEe').val(),
                                    'QPreguntaEncuestaOtraOBS': $('#txtParticipantesEOBSe').val(),
                                    'RptaCorrectaEncuentaOtra': $('#txtRespuestaCe').val(),
                                    'RptaIncorrectaEncuentaOtra': $('#txtRespuestaIe').val(),
                                    'PorcentRptaCorrectaEncuentaOtra': $('#txtPorcentajeRe').val(),
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
                                    $('#tblDirintemarOtraActividadDifusionMar').DataTable().ajax.reload();
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

    $('#tblDirintemarOtraActividadDifusionMar').DataTable({
        ajax: {
            "url": '/DirintemarOtraActividadDifusionMar/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "otraActDifusionMarId" },
            { "data": "descTipoActividadDifusion" },
            { "data": "nombreOtraActDifusionMar" },
            { "data": "areaOtraActDifusionMar" },
            { "data": "responsableOtraActDifusionMar" },
            { "data": "inicioOtraActDifusionMar" },
            { "data": "terminoOtraActDifusionMar" },
            { "data": "lugarOtraActDifusionMar" },
            { "data": "descDirigidoA" },  
            { "data": "qParticipanteOtraActDifusionMar" },  
            { "data": "qParticipanteEncuestaOtra" },  
            { "data": "qPreguntaEncuestaOtraOBS" },  
            { "data": "rptaCorrectaEncuentaOtra" },  
            { "data": "rptaIncorrectaEncuentaOtra" },  
            { "data": "porcentRptaCorrectaEncuentaOtra" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.otraActDifusionMarId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.otraActDifusionMarId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Otras Actividades de Difusión de Realidad e Intereses Maritimos',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirintemar - Otras Actividades de Difusión de Realidad e Intereses Maritimos',
                title: 'Dirintemar - Otras Actividades de Difusión de Realidad e Intereses Maritimos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Otras Actividades de Difusión de Realidad e Intereses Maritimos',
                title: 'Dirintemar - Otras Actividades de Difusión de Realidad e Intereses Maritimos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Otras Actividades de Difusión de Realidad e Intereses Maritimos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirintemarOtraActividadDifusionMar/Mostrar?Id=' + Id, [], function (OtraActividadDifusionMarDTO) {
        $('#txtCodigo').val(OtraActividadDifusionMarDTO.otraActDifusionMarId);
        $('#cbTipoActivDifusione').val(OtraActividadDifusionMarDTO.tipoActividadDifusionId);
        $('#txtNombreOActive').val(OtraActividadDifusionMarDTO.nombreOtraActDifusionMar);
        $('#txtAreae').val(OtraActividadDifusionMarDTO.areaOtraActDifusionMar);
        $('#txtResponsablee').val(OtraActividadDifusionMarDTO.responsableOtraActDifusionMar);
        $('#txtFechaIe').val(OtraActividadDifusionMarDTO.inicioOtraActDifusionMar);
        $('#txtFechaTe').val(OtraActividadDifusionMarDTO.terminoOtraActDifusionMar);
        $('#txtLugare').val(OtraActividadDifusionMarDTO.lugarOtraActDifusionMar);
        $('#cbDirigidoe').val(OtraActividadDifusionMarDTO.dirigidoAId);
        $('#txtParticipantee').val(OtraActividadDifusionMarDTO.qParticipanteOtraActDifusionMar);
        $('#txtParticipanteEe').val(OtraActividadDifusionMarDTO.qParticipanteEncuestaOtra);
        $('#txtParticipantesEOBSe').val(OtraActividadDifusionMarDTO.qPreguntaEncuestaOtraOBS);
        $('#txtRespuestaCe').val(OtraActividadDifusionMarDTO.rptaCorrectaEncuentaOtra);
        $('#txtRespuestaIe').val(OtraActividadDifusionMarDTO.rptaIncorrectaEncuentaOtra);
        $('#txtPorcentajeRe').val(OtraActividadDifusionMarDTO.porcentRptaCorrectaEncuentaOtra);
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
                url: '/DirintemarOtraActividadDifusionMar/Eliminar',
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
                    $('#tblDirintemarOtraActividadDifusionMar').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarOtraActividadDifusionMar() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarOtraActividadDifusionMar/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.otraActDifusionMarId),
                        $("<td>").text(item.descTipoActividadDifusion),
                        $("<td>").text(item.nombreOtraActDifusionMar),
                        $("<td>").text(item.areaOtraActDifusionMar),
                        $("<td>").text(item.responsableOtraActDifusionMar),
                        $("<td>").text(item.inicioOtraActDifusionMar),
                        $("<td>").text(item.terminoOtraActDifusionMar),
                        $("<td>").text(item.lugarOtraActDifusionMar),
                        $("<td>").text(item.descDirigidoA),
                        $("<td>").text(item.qParticipanteOtraActDifusionMar),
                        $("<td>").text(item.qParticipanteEncuestaOtra),
                        $("<td>").text(item.qPreguntaEncuestaOtraOBS),
                        $("<td>").text(item.rptaCorrectaEncuentaOtra),
                        $("<td>").text(item.rptaIncorrectaEncuentaOtra),
                        $("<td>").text(item.porcentRptaCorrectaEncuentaOtra)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarOtraActividadDifusionMar/EnviarDatos", {
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
    $.getJSON('/DirintemarOtraActividadDifusionMar/cargaCombs', [], function (Json) {
        var tipoactividaddifusion = Json["data1"];
        var dirigidoa = Json["data2"];

        $("select#cbTipoActivDifusion").html("");
        $.each(tipoactividaddifusion, function () {
            var RowContent = '<option value=' + this.tipoActividadDifusionId + '>' + this.descTipoActividadDifusion + '</option>'
            $("select#cbTipoActivDifusion").append(RowContent);
        });
        $("select#cbTipoActivDifusione").html("");
        $.each(tipoactividaddifusion, function () {
            var RowContent = '<option value=' + this.tipoActividadDifusionId + '>' + this.descTipoActividadDifusion + '</option>'
            $("select#cbTipoActivDifusione").append(RowContent);
        });

        $("select#cbDirigido").html("");
        $.each(dirigidoa, function () {
            var RowContent = '<option value=' + this.dirigidoAId + '>' + this.descDirigidoA + '</option>'
            $("select#cbDirigido").append(RowContent);
        });
        $("select#cbDirigidoe").html("");
        $.each(dirigidoa, function () {
            var RowContent = '<option value=' + this.dirigidoAId + '>' + this.descDirigidoA + '</option>'
            $("select#cbDirigidoe").append(RowContent);
        });
    });
}

