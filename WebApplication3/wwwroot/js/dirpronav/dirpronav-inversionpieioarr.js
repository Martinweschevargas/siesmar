var tblDirpronavInversionPIeIOARR;

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
                                url: '/DirpronavInversionPIeIOARR/Insertar',
                                data: {
                                    'CodigoUnificado': $('#txtCodigoUnificado').val(),
                                    'NombreInversion': $('#txtNombreInversion').val(),
                                    'CodigoClaseInversion': $('#cbClaseInversion').val(),
                                    'MontoInversionInicial': $('#txtMontoInversionInicial').val(),
                                    'MontoInversionModificado': $('#txtMontoInversionModificado').val(),
                                    'FechaViabilidadProyecto': $('#txtFechaViabilidadProyecto').val(),
                                    'CodigoFaseInversion': $('#cbFaseInversion').val(),
                                    'UnidadFormuladora': $('#txtUnidadFormuladora').val(),
                                    'UnidadEjecutora': $('#txtUnidadEjecutora').val(),
                                    'CodigoUnidadNaval': $('#cbUnidNaval').val(),
                                    'CodigoEstadoFase1FormEval': $('#cbEstadoFase1FormEval').val(),
                                    'CodigoEstadoFase2Ejecucion': $('#cbEstadoFase2Ejecucion').val(),
                                    'CodigoEstadoFase3Funcionamiento': $('#cbEstadoFase3Funcionamiento').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuenteFinanciamiento').val(),
                                    'FechaTerminoEjecucionInversion': $('#txtFechaTerminoEjecucionInversion').val(),
                                    'FechaUltimaActualizacionProyecto': $('#txtFechaUltimaActualizacionProyecto').val(),
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
                                    $('#tblDirpronavInversionPIeIOARR').DataTable().ajax.reload();
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
                                url: '/DirpronavInversionPIeIOARR/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnificado': $('#txtCodigoUnificadoe').val(),
                                    'NombreInversion': $('#txtNombreInversione').val(),
                                    'CodigoClaseInversion': $('#cbClaseInversione').val(),
                                    'MontoInversionInicial': $('#txtMontoInversionIniciale').val(),
                                    'MontoInversionModificado': $('#txtMontoInversionModificadoe').val(),
                                    'FechaViabilidadProyecto': $('#txtFechaViabilidadProyectoe').val(),
                                    'CodigoFaseInversion': $('#cbFaseInversione').val(),
                                    'UnidadFormuladora': $('#txtUnidadFormuladorae').val(),
                                    'UnidadEjecutora': $('#txtUnidadEjecutorae').val(),
                                    'CodigoUnidadNaval': $('#cbUnidNaval').val(),
                                    'CodigoEstadoFase1FormEval': $('#cbEstadoFase1FormEvale').val(),
                                    'CodigoEstadoFase2Ejecucion': $('#cbEstadoFase2Ejecucione').val(),
                                    'CodigoEstadoFase3Funcionamiento': $('#cbEstadoFase3Funcionamientoe').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuenteFinanciamientoe').val(),
                                    'FechaTerminoEjecucionInversion': $('#txtFechaTerminoEjecucionInversione').val(),
                                    'FechaUltimaActualizacionProyecto': $('#txtFechaUltimaActualizacionProyectoe').val(),
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
                                    $('#tblDirpronavInversionPIeIOARR').DataTable().ajax.reload();
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

   tblDirpronavInversionPIeIOARR = $('#tblDirpronavInversionPIeIOARR').DataTable({
        ajax: {
            "url": '/DirpronavInversionPIeIOARR/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "inversionPIeIOARRId" },
            { "data": "codigoUnificado" },
            { "data": "nombreInversion" },
            { "data": "descClaseInversion" },
            { "data": "montoInversionInicial" },
            { "data": "montoInversionModificado" },
            { "data": "fechaViabilidadProyecto" },
            { "data": "descFaseInversion" },
            { "data": "unidadFormuladora" },
            { "data": "unidadEjecutora" },
            { "data": "descUnidadNaval" },
            { "data": "descEstadoFase1FormEval" },
            { "data": "descEstadoFase2Ejecucion" },
            { "data": "descEstadoFase3Funcionamiento" },
            { "data": "descFuenteFinanciamiento" },
            { "data": "fechaTerminoEjecucionInversion" },
            { "data": "fechaUltimaActualizacionProyecto" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.inversionPIeIOARRId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.inversionPIeIOARRId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirpronav - Proyectos de Inversion e Inversiones no Ligadas a Proyectos (PI e IOARR)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirpronav - Proyectos de Inversion e Inversiones no Ligadas a Proyectos (PI e IOARR)',
                title: 'Dirpronav - Proyectos de Inversion e Inversiones no Ligadas a Proyectos (PI e IOARR)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirpronav - Proyectos de Inversion e Inversiones no Ligadas a Proyectos (PI e IOARR)',
                title: 'Dirpronav - Proyectos de Inversion e Inversiones no Ligadas a Proyectos (PI e IOARR)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirpronav - Proyectos de Inversion e Inversiones no Ligadas a Proyectos (PI e IOARR)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
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
    tblDirpronavInversionPIeIOARR.columns(17).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirpronavInversionPIeIOARR.columns(17).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirpronavInversionPIeIOARR/Mostrar?Id=' + Id, [], function (InversionPIeIOARRDTO) {
        $('#txtCodigo').val(InversionPIeIOARRDTO.inversionPIeIOARRId);
        $('#txtCodigoUnificadoe').val(InversionPIeIOARRDTO.codigoUnificado);
        $('#txtNombreInversione').val(InversionPIeIOARRDTO.nombreInversion);
        $('#cbClaseInversione').val(InversionPIeIOARRDTO.codigoClaseInversion);
        $('#txtMontoInversionIniciale').val(InversionPIeIOARRDTO.montoInversionInicial);
        $('#txtMontoInversionModificadoe').val(InversionPIeIOARRDTO.montoInversionModificado);
        $('#txtFechaViabilidadProyectoe').val(InversionPIeIOARRDTO.fechaViabilidadProyecto);
        $('#cbFaseInversione').val(InversionPIeIOARRDTO.codigoFaseInversion);
        $('#txtUnidadFormuladorae').val(InversionPIeIOARRDTO.unidadFormuladora);
        $('#txtUnidadEjecutorae').val(InversionPIeIOARRDTO.unidadEjecutora);
        $('#cbUnidNavale').val(InversionPIeIOARRDTO.codigoUnidadNaval);
        $('#cbEstadoFase1FormEvale').val(InversionPIeIOARRDTO.codigoEstadoFase1FormEval);
        $('#cbEstadoFase2Ejecucione').val(InversionPIeIOARRDTO.codigoEstadoFase2Ejecucion);
        $('#cbEstadoFase3Funcionamientoe').val(InversionPIeIOARRDTO.codigoEstadoFase3Funcionamiento);
        $('#cbFuenteFinanciamientoe').val(InversionPIeIOARRDTO.codigoFuenteFinanciamiento);
        $('#txtFechaTerminoEjecucionInversione').val(InversionPIeIOARRDTO.fechaTerminoEjecucionInversion);
        $('#txtFechaUltimaActualizacionProyectoe').val(InversionPIeIOARRDTO.fechaUltimaActualizacionProyecto); 
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
                url: '/DirpronavInversionPIeIOARR/Eliminar',
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
                    $('#tblDirpronavInversionPIeIOARR').DataTable().ajax.reload();
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
                url: '/DirpronavInversionPIeIOARR/EliminarCarga',
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
                    $('#tblDirpronavInversionPIeIOARR').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}


function nuevaDirpronavInversionPIeIOARR() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirpronavInversionPIeIOARR/MostrarDatos',
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
                            $("<td>").text(item.codigoUnificado),
                            $("<td>").text(item.nombreInversion),
                            $("<td>").text(item.codigoClaseInversion),
                            $("<td>").text(item.montoInversionInicial),
                            $("<td>").text(item.montoInversionModificado),
                            $("<td>").text(item.fechaViabilidadProyecto),
                            $("<td>").text(item.codigoFaseInversion),
                            $("<td>").text(item.unidadFormuladora),
                            $("<td>").text(item.unidadEjecutora),
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.codigoEstadoFase1FormEval),
                            $("<td>").text(item.codigoEstadoFase2Ejecucion),
                            $("<td>").text(item.codigoEstadoFase3Funcionamiento),
                            $("<td>").text(item.codigoFuenteFinanciamiento),
                            $("<td>").text(item.fechaTerminoEjecucionInversion),
                            $("<td>").text(item.fechaUltimaActualizacionProyecto)
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
    fetch("DirpronavInversionPIeIOARR/EnviarDatos", {
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
    $.getJSON('/DirpronavInversionPIeIOARR/cargaCombs', [], function (Json) {
        var claseInversion = Json["data1"];
        var faseInversion = Json["data2"];
        var unidadnaval = Json["data3"];
        var estadoFase1FormEval = Json["data4"];
        var estadosFase2Ejecucion = Json["data5"];
        var estadoFase3Funcionamiento = Json["data6"];
        var fuenteFinanciamiento = Json["data7"];
        var listaCargas = Json["data8"];


        $("select#cbClaseInversion").html("");
        $("select#cbClaseInversione").html("");
        $.each(claseInversion, function () {
            var RowContent = '<option value=' + this.codigoClaseInversion + '>' + this.descClaseInversion + '</option>'
            $("select#cbClaseInversion").append(RowContent);
            $("select#cbClaseInversione").append(RowContent);
        });

        $("select#cbFaseInversion").html("");
        $("select#cbFaseInversione").html("");
        $.each(faseInversion, function () {
            var RowContent = '<option value=' + this.codigoFaseInversion + '>' + this.descFaseInversion + '</option>'
            $("select#cbFaseInversion").append(RowContent);
            $("select#cbFaseInversione").append(RowContent);
        });

        $("select#cbUnidNaval").html("");
        $("select#cbUnidNavale").html("");
        $.each(unidadnaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidNaval").append(RowContent);
            $("select#cbUnidNavale").append(RowContent);
        });

        $("select#cbEstadoFase1FormEval").html("");
        $("select#cbEstadoFase1FormEvale").html("");
        $.each(estadoFase1FormEval, function () {
            var RowContent = '<option value=' + this.codigoEstadoFase1FormEval + '>' + this.descEstadoFase1FormEval + '</option>'
            $("select#cbEstadoFase1FormEval").append(RowContent);
            $("select#cbEstadoFase1FormEvale").append(RowContent);
        });

        $("select#cbEstadoFase2Ejecucion").html("");
        $("select#cbEstadoFase2Ejecucione").html("");
        $.each(estadosFase2Ejecucion, function () {
            var RowContent = '<option value=' + this.codigoEstadoFase2Ejecucion + '>' + this.descEstadoFase2Ejecucion + '</option>'
            $("select#cbEstadoFase2Ejecucion").append(RowContent);
            $("select#cbEstadoFase2Ejecucione").append(RowContent);
        });


        $("select#cbEstadoFase3Funcionamiento").html("");
        $("select#cbEstadoFase3Funcionamientoe").html("");
        $.each(estadoFase3Funcionamiento, function () {
            var RowContent = '<option value=' + this.codigoEstadoFase3Funcionamiento + '>' + this.descEstadoFase3Funcionamiento + '</option>'
            $("select#cbEstadoFase3Funcionamiento").append(RowContent);
            $("select#cbEstadoFase3Funcionamientoe").append(RowContent);
        });

        $("select#cbFuenteFinanciamiento").html("");
        $("select#cbFuenteFinanciamientoe").html("");
        $.each(fuenteFinanciamiento, function () {
            var RowContent = '<option value=' + this.codigoFuenteFinanciamiento + '>' + this.descFuenteFinanciamiento + '</option>'
            $("select#cbFuenteFinanciamiento").append(RowContent);
            $("select#cbFuenteFinanciamientoe").append(RowContent);
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

    reporteSeleccionado = '/FovimarSolicitudPrestamoHipotecarioNaval/ReporteSPHN';
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