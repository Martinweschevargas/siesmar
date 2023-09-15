var tblDirintemarActividadDifusionMaritimo;

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
                                url: '/DirintemarActividadDifusionMaritimo/Insertar',
                                data: {
                                    'TipoActividadDifusionId': $('#cbTipoActivDifusion').val(),
                                    'NombreActDifusionMar': $('#txtNombreActivida').val(),
                                    'AreaActDifusionMar': $('#txtArea').val(),
                                    'ResponsableActDifusionMar': $('#txtResponsable').val(),
                                    'InicioActDifusionMar': $('#txtFechaI').val(),
                                    'TerminoActDifusionMar': $('#txtFechaT').val(),
                                    'LugarActDifusionMar': $('#txtLugar').val(),
                                    'QParticipanteActDifusionMar': $('#txtParticipante').val(),
                                    'QParticipanteEncuesta': $('#txtParticipanteE').val(),
                                    'QPreguntaEncuestaOBS': $('#txtPreguntaEOBS').val(),
                                    'RptaCorrectasEncuenta': $('#txtRespuestaC').val(),
                                    'RptaIncorrectaEncuenta': $('#txtRespuestaI').val(),
                                    'PorcentRptaCorrectaEncuenta': $('#txtPorcentajeR').val()
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
                                    $('#tblDirintemarActividadDifusionMaritimo').DataTable().ajax.reload();
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
                                url: '/DirintemarActividadDifusionMaritimo/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoActividadDifusionId': $('#cbTipoActivDifusione').val(),
                                    'NombreActDifusionMar': $('#txtNombreActividae').val(),
                                    'AreaActDifusionMar': $('#txtAreae').val(),
                                    'ResponsableActDifusionMar': $('#txtResponsablee').val(),
                                    'InicioActDifusionMar': $('#txtFechaIe').val(),
                                    'TerminoActDifusionMar': $('#txtFechaTe').val(),
                                    'LugarActDifusionMar': $('#txtLugare').val(),
                                    'QParticipanteActDifusionMar': $('#txtParticipantee').val(),
                                    'QParticipanteEncuesta': $('#txtParticipanteEe').val(),
                                    'QPreguntaEncuestaOBS': $('#txtPreguntaEOBSe').val(),
                                    'RptaCorrectasEncuenta': $('#txtRespuestaCe').val(),
                                    'RptaIncorrectaEncuenta': $('#txtRespuestaIe').val(),
                                    'PorcentRptaCorrectaEncuenta': $('#txtPorcentajeRe').val(),
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
                                    $('#tblDirintemarActividadDifusionMaritimo').DataTable().ajax.reload();
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

    $('#tblDirintemarActividadDifusionMaritimo').DataTable({
        ajax: {
            "url": '/DirintemarActividadDifusionMaritimo/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "actividadDifusionMaritimoId" },
            { "data": "descTipoActividadDifusion" },
            { "data": "nombreActDifusionMar" },
            { "data": "areaActDifusionMar" },
            { "data": "responsableActDifusionMar" },
            { "data": "inicioActDifusionMar" },
            { "data": "terminoActDifusionMar" },
            { "data": "lugarActDifusionMar" },
            { "data": "qParticipanteActDifusionMar" },  
            { "data": "qParticipanteEncuesta" },  
            { "data": "qPreguntaEncuestaOBS" },  
            { "data": "rptaCorrectasEncuenta" },  
            { "data": "rptaIncorrectaEncuenta" },  
            { "data": "porcentRptaCorrectaEncuenta" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.actividadDifusionMaritimoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.actividadDifusionMaritimoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Actividades de Difusión de realidad e Intereses Maritimos',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirintemar - Actividades de Difusión de realidad e Intereses Maritimos',
                title: 'Dirintemar - Actividades de Difusión de realidad e Intereses Maritimos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Actividades de Difusión de realidad e Intereses Maritimos',
                title: 'Dirintemar - Actividades de Difusión de realidad e Intereses Maritimos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Actividades de Difusión de realidad e Intereses Maritimos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
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
    $.getJSON('/DirintemarActividadDifusionMaritimo/Mostrar?Id=' + Id, [], function (ActividadDifusionMaritimoDTO) {
        $('#txtCodigo').val(ActividadDifusionMaritimoDTO.actividadDifusionMaritimoId);
        $('#cbTipoActivDifusione').val(ActividadDifusionMaritimoDTO.tipoActividadDifusionId);
        $('#txtNombreActividae').val(ActividadDifusionMaritimoDTO.nombreActDifusionMar);
        $('#txtAreae').val(ActividadDifusionMaritimoDTO.areaActDifusionMar);
        $('#txtResponsablee').val(ActividadDifusionMaritimoDTO.responsableActDifusionMar);
        $('#txtFechaIe').val(ActividadDifusionMaritimoDTO.inicioActDifusionMar);
        $('#txtFechaTe').val(ActividadDifusionMaritimoDTO.terminoActDifusionMar);
        $('#txtLugare').val(ActividadDifusionMaritimoDTO.lugarActDifusionMar);
        $('#txtParticipantee').val(ActividadDifusionMaritimoDTO.qParticipanteActDifusionMar);
        $('#txtParticipanteEe').val(ActividadDifusionMaritimoDTO.qParticipanteEncuesta);
        $('#txtPreguntaEOBSe').val(ActividadDifusionMaritimoDTO.qPreguntaEncuestaOBS);
        $('#txtRespuestaCe').val(ActividadDifusionMaritimoDTO.rptaCorrectasEncuenta);
        $('#txtRespuestaIe').val(ActividadDifusionMaritimoDTO.rptaIncorrectaEncuenta);
        $('#txtPorcentajeRe').val(ActividadDifusionMaritimoDTO.porcentRptaCorrectaEncuenta);     
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
                url: '/DirintemarActividadDifusionMaritimo/Eliminar',
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
                    $('#tblDirintemarActividadDifusionMaritimo').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarActividadDifusionMaritimo() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarActividadDifusionMaritimo/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.actividadDifusionMaritimoId),
                        $("<td>").text(item.descTipoActividadDifusion),
                        $("<td>").text(item.nombreActDifusionMar),
                        $("<td>").text(item.areaActDifusionMar),
                        $("<td>").text(item.responsableActDifusionMar),
                        $("<td>").text(item.inicioActDifusionMar),
                        $("<td>").text(item.terminoActDifusionMar),
                        $("<td>").text(item.lugarActDifusionMar),
                        $("<td>").text(item.qParticipanteActDifusionMar),
                        $("<td>").text(item.qParticipanteEncuesta),
                        $("<td>").text(item.qPreguntaEncuestaOBS),
                        $("<td>").text(item.rptaCorrectasEncuenta),
                        $("<td>").text(item.rptaIncorrectaEncuenta),
                        $("<td>").text(item.porcentRptaCorrectaEncuenta)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarActividadDifusionMaritimo/EnviarDatos", {
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
    $.getJSON('/DirintemarActividadDifusionMaritimo/cargaCombs', [], function (Json) {
        var TipoActividadDifusion = Json["data"];
        $("select#cbTipoActivDifusion").html("");
        $.each(TipoActividadDifusion, function () {
            var RowContent = '<option value=' + this.tipoActividadDifusionId + '>' + this.descTipoActividadDifusion + '</option>'
            $("select#cbTipoActivDifusion").append(RowContent);
        });
        $("select#cbTipoActivDifusione").html("");
        $.each(TipoActividadDifusion, function () {
            var RowContent = '<option value=' + this.tipoActividadDifusionId + '>' + this.descTipoActividadDifusion + '</option>'
            $("select#cbTipoActivDifusione").append(RowContent);
        });
    })
}

