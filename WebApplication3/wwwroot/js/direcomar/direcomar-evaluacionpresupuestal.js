var tblDirecomarEvaluacionPresupuestal;
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
                                url: '/DirecomarEvaluacionPresupuestal/Insertar',
                                data: {
                                    'AnioEvaluacionPresupuesta': $('#txtAnio').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'CodigoSubunidadEjecutora': $('#cbSUE').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuenteFinanc').val(),
                                    'ClasificacionGenericaGasto': $('#cbClasi').val(),
                                    'ASIGPIMPresupuestal': $('#txtASIG').val(),
                                    'PCAPresupuestal': $('#txtPCA').val(),
                                    'CertificadoPresupuestal': $('#txtCertificado').val(),
                                    'CompromisoPresupuestal': $('#txtCompromiso').val(),
                                    'DevengadoPresupuestal': $('#txtDevengado').val(),
                                    'GiradoPresupuestal': $('#txtGirado').val(),
                                    'AvancePresupuestal': $('#txtAvance').val(), 
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
                                    $('#tblDirecomarEvaluacionPresupuestal').DataTable().ajax.reload();
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
                                url: '/DirecomarEvaluacionPresupuestal/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioEvaluacionPresupuesta': $('#txtAnioe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'CodigoSubunidadEjecutora': $('#cbSUEe').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuenteFinance').val(),
                                    'ClasificacionGenericaGasto': $('#cbClasie').val(),
                                    'ASIGPIMPresupuestal': $('#txtASIGe').val(),
                                    'PCAPresupuestal': $('#txtPCAe').val(),
                                    'CertificadoPresupuestal': $('#txtCertificadoe').val(),
                                    'CompromisoPresupuestal': $('#txtCompromisoe').val(),
                                    'DevengadoPresupuestal': $('#txtDevengadoe').val(),
                                    'GiradoPresupuestal': $('#txtGiradoe').val(),
                                    'AvancePresupuestal': $('#txtAvancee').val(), 
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
                                    $('#tblDirecomarEvaluacionPresupuestal').DataTable().ajax.reload();
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

        tblDirecomarEvaluacionPresupuestal = $('#tblDirecomarEvaluacionPresupuestal').DataTable({
        ajax: {
            "url": '/DirecomarEvaluacionPresupuestal/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionPresupuestalId" },
            { "data": "anioEvaluacionPresupuesta" },
            { "data": "descMes" },
            { "data": "descSubUnidadEjecutora" },
            { "data": "descFuenteFinanciamiento" },
            { "data": "descClasificacionGenericaGasto" },
            { "data": "asigpimPresupuestal" },
            { "data": "pcaPresupuestal" },
            { "data": "certificadoPresupuestal" },
            { "data": "compromisoPresupuestal" },
            { "data": "devengadoPresupuestal" },
            { "data": "giradoPresupuestal" },
            { "data": "avancePresupuestal" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionPresupuestalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionPresupuestalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Direcomar - Evaluación Presupuestal',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Direcomar - Evaluación Presupuestal',
                title: 'Direcomar - Evaluación Presupuestal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Direcomar - Evaluación Presupuestal',
                title: 'Direcomar - Evaluación Presupuestal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Direcomar - Evaluación Presupuestal',
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
    tblDirecomarEvaluacionPresupuestal.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirecomarEvaluacionPresupuestal.columns(13).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirecomarEvaluacionPresupuestal/Mostrar?Id=' + Id, [], function (EvaluacionPresupuestalDTO) {
        $('#txtCodigo').val(EvaluacionPresupuestalDTO.evaluacionPresupuestalId);
        $('#txtAnioe').val(EvaluacionPresupuestalDTO.anioEvaluacionPresupuesta);
        $('#cbMese').val(EvaluacionPresupuestalDTO.numeroMes);
        $('#cbSUEe').val(EvaluacionPresupuestalDTO.codigoSubunidadEjecutora);
        $('#cbFuenteFinance').val(EvaluacionPresupuestalDTO.codigoFuenteFinanciamiento);
        $('#cbClasie').val(EvaluacionPresupuestalDTO.clasificacionGenericaGasto);
        $('#txtASIGe').val(EvaluacionPresupuestalDTO.asigpimPresupuestal);
        $('#txtPCAe').val(EvaluacionPresupuestalDTO.pcaPresupuestal);
        $('#txtCertificadoe').val(EvaluacionPresupuestalDTO.certificadoPresupuestal);
        $('#txtCompromisoe').val(EvaluacionPresupuestalDTO.compromisoPresupuestal);
        $('#txtDevengadoe').val(EvaluacionPresupuestalDTO.devengadoPresupuestal);
        $('#txtGiradoe').val(EvaluacionPresupuestalDTO.giradoPresupuestal);
        $('#txtAvancee').val(EvaluacionPresupuestalDTO.avancePresupuestal); 
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
                url: '/DirecomarEvaluacionPresupuestal/Eliminar',
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
                    $('#tblDirecomarEvaluacionPresupuestal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirecomarEvaluacionPresupuestal() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirecomarEvaluacionPresupuestal/MostrarDatos',
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
                            $("<td>").text(item.anioEvaluacionPresupuesta),
                            $("<td>").text(item.mumeroMes),
                            $("<td>").text(item.codigoSubunidadEjecutora),
                            $("<td>").text(item.codigoFuenteFinanciamiento),
                            $("<td>").text(item.clasificacionGenericaGasto),
                            $("<td>").text(item.asigpimPresupuestal),
                            $("<td>").text(item.pcaPresupuestal),
                            $("<td>").text(item.certificadoPresupuestal),
                            $("<td>").text(item.compromisoPresupuestal),
                            $("<td>").text(item.devengadoPresupuestal),
                            $("<td>").text(item.giradoPresupuestal),
                            $("<td>").text(item.avancePresupuestal),
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
    fetch("DirecomarEvaluacionPresupuestal/EnviarDatos", {
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
                url: '/DirecomarEvaluacionPresupuestal/EliminarCarga',
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
                    $('#tblDirecomarEvaluacionPresupuestal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DirecomarEvaluacionPresupuestal/cargaCombs', [], function (Json) {
        var Mes = Json["data1"];
        var SubUnidadEjecutora = Json["data2"];
        var FuenteFinanciamiento = Json["data3"];
        var ClasificacionGenericaGasto = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(Mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
            $("select#cbMese").append(RowContent);
        });

        $("select#cbSUE").html("");
        $("select#cbSUEe").html("");
        $.each(SubUnidadEjecutora, function () {
            var RowContent = '<option value=' + this.codigoSubUnidadEjecutora + '>' + this.descSubUnidadEjecutora + '</option>'
            $("select#cbSUE").append(RowContent);
            $("select#cbSUEe").append(RowContent);
        });

        $("select#cbFuenteFinanc").html("");
        $("select#cbFuenteFinance").html("");
        $.each(FuenteFinanciamiento, function () {
            var RowContent = '<option value=' + this.codigoFuenteFinanciamiento + '>' + this.descFuenteFinanciamiento + '</option>'
            $("select#cbFuenteFinanc").append(RowContent);
            $("select#cbFuenteFinance").append(RowContent);
        });

        $("select#cbClasi").html("");
        $("select#cbClasie").html("");
        $.each(ClasificacionGenericaGasto, function () {
            var RowContent = '<option value=' + this.clasificacionGenericaGasto + '>' + this.descClasificacionGenericaGasto + '</option>'
            $("select#cbClasi").append(RowContent);
            $("select#cbClasie").append(RowContent);
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
        reporteSeleccionado = '/DirecomarEvaluacionPresupuestal/ReporteDEP';
    
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

