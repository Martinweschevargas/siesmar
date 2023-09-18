var tblComescuamaEvaluacionAlistEntrenamiento;
var EjercicioEntrenamiento;
var EjercicioEntrenamientoAspecto;
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
                                url: '/ComescuamaEvaluacionAlistEntrenamiento/Insertar',
                                data: {
                                    'CodigoUnidadNaval ': $('#cbUnidadNaval').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamiento').val(),
                                    'CodigoCapacidadOperativa ': $('#cbCapacidadOperativa').val(),
                                    'TipoCapacidadOperativo': $('#txtTipoCapacidadOperativo').val(),
                                    'CodigoEjercicioEntrenamiento ': $('#cbEjercicioEntrenamiento').val(),
                                    'CodigoEjercicioEntrenamientoAspecto ': $('#cbEjercicioEntrenamientoAspecto').val(),
                                    'CodigoCalificativoAsignadoEjercicio  ': $('#cbCalificativoAsignadoEjercicio').val(),
                                    'PuntajeObtenido': $('#txtPuntajeObtenido').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluar').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicio').val(),
                                    'TiempoVigencia': $('#txtTiempoVigencia').val(),
                                    'FechaCaducidadEjercicio': $('#txtFechaCaducidadEjercicio').val(), 
                                    'CargaId': $('#cargasR').val()
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
                                    $('#tblComescuamaEvaluacionAlistEntrenamiento').DataTable().ajax.reload();
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
                                url: '/ComescuamaEvaluacionAlistEntrenamiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval ': $('#cbUnidadNavale').val(),
                                    'NivelEntrenamiento': $('#txtNivelEntrenamientoe').val(),
                                    'CodigoCapacidadOperativa ': $('#cbCapacidadOperativae').val(),
                                    'TipoCapacidadOperativo': $('#txtTipoCapacidadOperativoe').val(),
                                    'CodigoEjercicioEntrenamiento ': $('#cbEjercicioEntrenamientoe').val(),
                                    'CodigoEjercicioEntrenamientoAspecto  ': $('#cbEjercicioEntrenamientoAspectoe').val(),
                                    'CodigoCalificativoAsignadoEjercicio ': $('#cbCalificativoAsignadoEjercicioe').val(),
                                    'PuntajeObtenido': $('#txtPuntajeObtenidoe').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluare').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicioe').val(),
                                    'TiempoVigencia': $('#txtTiempoVigenciae').val(),
                                    'FechaCaducidadEjercicio': $('#txtFechaCaducidadEjercicioe').val(), 
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
                                    $('#tblComescuamaEvaluacionAlistEntrenamiento').DataTable().ajax.reload();
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


        tblComescuamaEvaluacionAlistEntrenamiento=  $('#tblComescuamaEvaluacionAlistEntrenamiento').DataTable({
        ajax: {
            "url": '/ComescuamaEvaluacionAlistEntrenamiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoId" },
            { "data": "descUnidadNaval" },
            { "data": "nivelEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "tipoCapacidadOperativo" },
            { "data": "codigoEjercicioEntrenamiento " },
            { "data": "codigoEjercicioEntrenamientoAspecto" },
            { "data": "descCalificativoAsignadoEjercicio" },
            { "data": "puntajeObtenido" },
            { "data": "fechaPeriodoEvaluar" },
            { "data": "fechaRealizacionEjercicio" },
            { "data": "tiempoVigencia" },
            { "data": "fechaCaducidadEjercicio" }, 
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionAlistamientoEntrenamientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionAlistamientoEntrenamientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                title: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                title: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescuama - Evaluación del Alistamiento del Entrenamiento',
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
    tblComescuamaEvaluacionAlistEntrenamiento.columns(15).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComescuamaEvaluacionAlistEntrenamiento.columns(15).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComescuamaEvaluacionAlistEntrenamiento/Mostrar?Id=' + Id, [], function (EvaluacionAlistEntrenamientoComescuamaDTO) {
        $('#txtCodigo').val(EvaluacionAlistEntrenamientoComescuamaDTO.evaluacionAlistamientoEntrenamientoId);
        $('#cbUnidadNavale').val(EvaluacionAlistEntrenamientoComescuamaDTO.CodigoUnidadNaval);
        $('#txtNivelEntrenamientoe').val(EvaluacionAlistEntrenamientoComescuamaDTO.nivelEntrenamiento);
        $('#cbCapacidadOperativae').val(EvaluacionAlistEntrenamientoComescuamaDTO.codigoCapacidadOperativa);
        $('#txtTipoCapacidadOperativoe').val(EvaluacionAlistEntrenamientoComescuamaDTO.tipoCapacidadOperativo);
        $('#cbEjercicioEntrenamientoe').val(EvaluacionAlistEntrenamientoComescuamaDTO.codigoEjercicioEntrenamiento);
        $('#txtDescEjercicioEntrenamientoe').val(EvaluacionAlistEntrenamientoComescuamaDTO.descEjercicioEntrenamiento);
        $('#cbEjercicioEntrenamientoAspectoe').val(EvaluacionAlistEntrenamientoComescuamaDTO.codigoEjercicioEntrenamientoAspecto);
        $('#txtAspectoEvaluacione').val(EvaluacionAlistEntrenamientoComescuamaDTO.aspectoEvaluacion);
        $('#txtPesoe').val(EvaluacionAlistEntrenamientoComescuamaDTO.peso);
        $('#cbCalificativoAsignadoEjercicioe').val(EvaluacionAlistEntrenamientoComescuamaDTO.codigoCalificativoAsignadoEjercicio);
        $('#txtPuntajeObtenidoe').val(EvaluacionAlistEntrenamientoComescuamaDTO.puntajeObtenido);
        $('#txtFechaPeriodoEvaluare').val(EvaluacionAlistEntrenamientoComescuamaDTO.fechaPeriodoEvaluar);
        $('#txtFechaRealizacionEjercicioe').val(EvaluacionAlistEntrenamientoComescuamaDTO.fechaRealizacionEjercicio);
        $('#txtTiempoVigenciae').val(EvaluacionAlistEntrenamientoComescuamaDTO.tiempoVigencia);
        $('#txtFechaCaducidadEjercicioe').val(EvaluacionAlistEntrenamientoComescuamaDTO.fechaCaducidadEjercicio); 
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
                url: '/ComescuamaEvaluacionAlistEntrenamiento/Eliminar',
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
                    $('#tblComescuamaEvaluacionAlistEntrenamiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComescuamaEvaluacionAlistEntrenamiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComescuamaEvaluacionAlistEntrenamiento/MostrarDatos',
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
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.nivelEntrenamiento),
                            $("<td>").text(item.codigoCapacidadOperativa),
                            $("<td>").text(item.tipoCapacidadOperativo),
                            $("<td>").text(item.codigoEjercicioEntrenamiento),
                            $("<td>").text(item.codigoEjercicioEntrenamientoAspecto),
                            $("<td>").text(item.codigoCalificativoAsignadoEjercicio),
                            $("<td>").text(item.puntajeObtenido),
                            $("<td>").text(item.fechaPeriodoEvaluar),
                            $("<td>").text(item.fechaRealizacionEjercicio),
                            $("<td>").text(item.tiempoVigencia),
                            $("<td>").text(item.fechaCaducidadEjercicio),
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
    fetch("ComescuamaEvaluacionAlistEntrenamiento/EnviarDatos", {
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
    $.getJSON('/ComescuamaEvaluacionAlistEntrenamiento/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var CapacidadOperativa = Json["data2"];
        EjercicioEntrenamiento = Json["data3"];
        EjercicioEntrenamientoAspecto = Json["data4"];
        var CalificativoAsignadoEjercicio = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbUnidadNaval").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbCapacidadOperativa").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativa + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
        });
        $("select#cbCapacidadOperativae").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativa + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativae").append(RowContent);
        });


        $("select#cbEjercicioEntrenamiento").html("");
        $.each(EjercicioEntrenamiento, function () {
            var RowContent = '<option value=' + this.codigoEjercicioEntrenamiento + '>' + this.codigoEjercicioEntrenamiento + '</option>'
            $("select#cbEjercicioEntrenamiento").append(RowContent);

            $("input#txtDescEjercicioEntrenamiento").val(EjercicioEntrenamiento[0].descEjercicioEntrenamiento);
        });
        $("select#cbEjercicioEntrenamientoe").html("");
        $.each(EjercicioEntrenamiento, function () {
            var RowContent = '<option value=' + this.codigoEjercicioEntrenamiento + '>' + this.codigoEjercicioEntrenamiento + '</option>'
            $("select#cbEjercicioEntrenamientoe").append(RowContent);
        });


        $("select#cbEjercicioEntrenamientoAspecto").html("");
        $.each(EjercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.codigoEjercicioEntrenamientoAspecto + '>' + this.codigoEjercicioEntrenamientoAspecto + '</option>'
            $("select#cbEjercicioEntrenamientoAspecto").append(RowContent);

            $("input#txtAspectoEvaluacion").val(EjercicioEntrenamientoAspecto[0].aspectoEvaluacion);
            $("input#txtPeso").val(EjercicioEntrenamientoAspecto[0].peso);
        });
        $("select#cbEjercicioEntrenamientoAspectoe").html("");
        $.each(EjercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.codigoEjercicioEntrenamientoAspecto + '>' + this.codigoEjercicioEntrenamientoAspecto + '</option>'
            $("select#cbEjercicioEntrenamientoAspectoe").append(RowContent);
        });


        $("select#cbCalificativoAsignadoEjercicio").html("");
        $.each(CalificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.codigoCalificativoAsignadoEjercicio + '>' + this.descCalificativoAsignadoEjercicio + '</option>'
            $("select#cbCalificativoAsignadoEjercicio").append(RowContent);
        });
        $("select#cbCalificativoAsignadoEjercicioe").html("");
        $.each(CalificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.codigoCalificativoAsignadoEjercicio + '>' + this.descCalificativoAsignadoEjercicio + '</option>'
            $("select#cbCalificativoAsignadoEjercicioe").append(RowContent);
        }); 

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });


    });
}

$('select#cbEjercicioEntrenamiento').on('change', function () {

    var codigo = $(this).val();

    $.each(codigoEjercicioEntrenamiento, function () {
        if (this.codigoEjercicioEntrenamiento == codigo) {
            $("input#txtDescEjercicioEntrenamiento").val(this.descEjercicioEntrenamiento);
        }
    });
});

$('select#cbEjercicioEntrenamientoe').on('change', function () {

    var codigo = $(this).val();

    $.each(codigoEjercicioEntrenamiento, function () {
        if (this.codigoEjercicioEntrenamiento == codigo) {
            $("input#txtDescEjercicioEntrenamientoe").val(this.descEjercicioEntrenamiento);
        }
    });
});


$('select#cbEjercicioEntrenamientoAspecto').on('change', function () {

    var codigo = $(this).val();

    $.each(codigoEjercicioEntrenamientoAspecto, function () {
        if (this.codigoEjercicioEntrenamientoAspecto == codigo) {
            $("input#txtAspectoEvaluacion").val(this.aspectoEvaluacion);
            $("input#txtPeso").val(this.peso);
        }
    });
});

$('select#cbEjercicioEntrenamientoAspectoe').on('change', function () {

    var codigo = $(this).val();

    $.each(codigoEjercicioEntrenamientoAspecto, function () {
        if (this.codigoEjercicioEntrenamientoAspecto == codigo) {
            $("input#txtAspectoEvaluacione").val(this.aspectoEvaluacion);
            $("input#txtPesoe").val(this.peso);
        }
    });
});

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/ComescuamaEvaluacionAlistEntrenamiento/ReporteCEAE?idCarga=';
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