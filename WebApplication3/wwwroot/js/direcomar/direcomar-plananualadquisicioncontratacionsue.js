var tblDirecomarPlanAnualAdquisicionContratacionesSUE;
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
                                url: '/DirecomarPlanAnualAdquisicionContratacionesSUE/Insertar',
                                data: {
                                    'AnioAdquisicion': $('#txtAnio').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'CodigoSubunidadEjecutora': $('#cbSUE').val(),
                                    'IncluidosAdquisicion': $('#txtIncluidos').val(),
                                    'ImporteIncluidosAdquisicion': $('#txtImporteIncluido').val(),
                                    'ConvocadosAdquisicion': $('#txtConvocado').val(),
                                    'ImporteConvocadosAdquisicion': $('#txtImporteConvocado').val(),
                                    'ExcluidosAdquisicion': $('#txtExcluido').val(),
                                    'ImporteExcluidoAdquisicion': $('#txtImporteExcluido').val(), 
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
                                    $('#tblDirecomarPlanAnualAdquisicionContratacionesSUE').DataTable().ajax.reload();
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
                                url: '/DirecomarPlanAnualAdquisicionContratacionesSUE/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioAdquisicion': $('#txtAnioe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'CodigoSubunidadEjecutora': $('#cbSUEe').val(),
                                    'IncluidosAdquisicion': $('#txtIncluidose').val(),
                                    'ImporteIncluidosAdquisicion': $('#txtImporteIncluidoe').val(),
                                    'ConvocadosAdquisicion': $('#txtConvocadoe').val(),
                                    'ImporteConvocadosAdquisicion': $('#txtImporteConvocadoe').val(),
                                    'ExcluidosAdquisicion': $('#txtExcluidoe').val(),
                                    'ImporteExcluidoAdquisicion': $('#txtImporteExcluidoe').val(), 
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
                                    $('#tblDirecomarPlanAnualAdquisicionContratacionesSUE').DataTable().ajax.reload();
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


    tblDirecomarPlanAnualAdquisicionContratacionesSUE = $('#tblDirecomarPlanAnualAdquisicionContratacionesSUE').DataTable({
        ajax: {
            "url": '/DirecomarPlanAnualAdquisicionContratacionesSUE/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "planAnualAdquisicionContratacionId" },
            { "data": "anioAdquisicion" },
            { "data": "descMes" },
            { "data": "descSubUnidadEjecutora" },
            { "data": "incluidosAdquisicion" },
            { "data": "importeIncluidosAdquisicion" },
            { "data": "convocadosAdquisicion" },
            { "data": "importeConvocadosAdquisicion" },
            { "data": "excluidosAdquisicion" },
            { "data": "importeExcluidoAdquisicion" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.planAnualAdquisicionContratacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.planAnualAdquisicionContratacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Direcomar - Plan Anual de Adquisiciones y Contrataciones por Sub Unidad Ejecutora',
                title: '',
                exportOptions: { 
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Direcomar - Plan Anual de Adquisiciones y Contrataciones por Sub Unidad Ejecutora',
                title: 'Direcomar - Plan Anual de Adquisiciones y Contrataciones por Sub Unidad Ejecutora',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Direcomar - Plan Anual de Adquisiciones y Contrataciones por Sub Unidad Ejecutora',
                title: 'Direcomar - Plan Anual de Adquisiciones y Contrataciones por Sub Unidad Ejecutora',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Direcomar - Plan Anual de Adquisiciones y Contrataciones por Sub Unidad Ejecutora',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9]
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
    tblDirecomarPlanAnualAdquisicionContratacionesSUE.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirecomarPlanAnualAdquisicionContratacionesSUE.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirecomarPlanAnualAdquisicionContratacionesSUE/Mostrar?Id=' + Id, [], function (PlanAnualAdquisicionContratacionesSUEDTO) {
        $('#txtCodigo').val(PlanAnualAdquisicionContratacionesSUEDTO.planAnualAdquisicionContratacionId);
        $('#txtAnioe').val(PlanAnualAdquisicionContratacionesSUEDTO.anioAdquisicion);
        $('#cbMese').val(PlanAnualAdquisicionContratacionesSUEDTO.numeroMes);
        $('#cbSUEe').val(PlanAnualAdquisicionContratacionesSUEDTO.codigoSubunidadEjecutora);
        $('#txtIncluidose').val(PlanAnualAdquisicionContratacionesSUEDTO.incluidosAdquisicion);
        $('#txtImporteIncluidoe').val(PlanAnualAdquisicionContratacionesSUEDTO.importeIncluidosAdquisicion);
        $('#txtConvocadoe').val(PlanAnualAdquisicionContratacionesSUEDTO.convocadosAdquisicion);
        $('#txtImporteConvocadoe').val(PlanAnualAdquisicionContratacionesSUEDTO.importeConvocadosAdquisicion);
        $('#txtExcluidoe').val(PlanAnualAdquisicionContratacionesSUEDTO.excluidosAdquisicion);
        $('#txtImporteExcluidoe').val(PlanAnualAdquisicionContratacionesSUEDTO.importeExcluidoAdquisicion); 
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
                url: '/DirecomarPlanAnualAdquisicionContratacionesSUE/Eliminar',
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
                    $('#tblDirecomarPlanAnualAdquisicionContratacionesSUE').DataTable().ajax.reload();
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
                url: '/DirecomarPlanAnualAdquisicionContratacionesSUE/EliminarCarga',
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
                    $('#tblDirecomarPlanAnualAdquisicionContratacionesSUE').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDirecomarPlanAnualAdquisicionContratacionesSUE() {
    $('#listar').hide();
    $('#nuevo').show();

}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirecomarPlanAnualAdquisicionContratacionesSUE/MostrarDatos',
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
                            $("<td>").text(item.anioAdquisicion),
                            $("<td>").text(item.numeroMes),
                            $("<td>").text(item.codigoSubunidadEjecutora),
                            $("<td>").text(item.incluidosAdquisicion),
                            $("<td>").text(item.importeIncluidosAdquisicion),
                            $("<td>").text(item.convocadosAdquisicion),
                            $("<td>").text(item.importeConvocadosAdquisicion),
                            $("<td>").text(item.excluidosAdquisicion),
                            $("<td>").text(item.importeExcluidoAdquisicion),
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
    fetch("DirecomarPlanAnualAdquisicionContratacionesSUE/EnviarDatos", {
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
    $.getJSON('/DirecomarPlanAnualAdquisicionContratacionesSUE/cargaCombs', [], function (Json) {
        var Mes = Json["data1"];
        var SubUnidadEjecutora = Json["data2"];
        var listaCargas = Json["data3"];

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

    reporteSeleccionado = '/DirecomarPlanAnualAdquisicionContratacionesSUE/ReportePAACSUE';

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
