var tblComfasubEvaluacionAlistamientoEntrenamientoComfasub;


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
                                url: '/ComfasubEvaluacionAlistamientoEntrenamientoComfasub/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'CodigoNivelEntrenamiento': $('#cbNivelEntrenamiento').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativa').val(),
                                    'TipoCapacidadOperativa': $('#txtTipoCapacidadOperativa').val(),
                                    'CodigoEjercicioEntrenamientoComfasub': $('#cbEjercicioEntrenamientoAspecto').val(),
                                    'EjercicioEntrenamientoAspectos': $('#txtDescEjercicioEntrenamiento').val(),
                                    'PesoAspectosEjercicio': $('#txtPeso').val(),
                                    'CodigoCalificativoAsignadoEjercicio': $('#cbCalificativoAsignadoEjercicio').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluar').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicio').val(),
                                    'TiempoVigencia': $('#txtTiempoVigencia').val(), 
                                    'HoraNavegacionUnidad': $('#txtHoraNavegacion').val(), 
                                    'OperativoDespliegueRealizado': $('#txtOperativoDespliegue').val(),
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
                                    $('#tblComfasubEvaluacionAlistamientoEntrenamientoComfasub').DataTable().ajax.reload();
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
                                url: '/ComfasubEvaluacionAlistamientoEntrenamientoComfasub/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoNivelEntrenamiento': $('#cbNivelEntrenamientoe').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativae').val(),
                                    'TipoCapacidadOperativa': $('#txtTipoCapacidadOperativae').val(),
                                    'CodigoEjercicioEntrenamientoComfasub': $('#cbEjercicioEntrenamientoAspectoe').val(),
                                    'EjercicioEntrenamientoAspectos': $('#txtDescEjercicioEntrenamientoe').val(),
                                    'PesoAspectosEjercicio': $('#txtPesoe').val(),
                                    'CodigoCalificativoAsignadoEjercicio': $('#cbCalificativoAsignadoEjercicioe').val(),
                                    'FechaPeriodoEvaluar': $('#txtFechaPeriodoEvaluare').val(),
                                    'FechaRealizacionEjercicio': $('#txtFechaRealizacionEjercicioe').val(),
                                    'TiempoVigencia': $('#txtTiempoVigenciae').val(),
                                    'HoraNavegacionUnidad': $('#txtHoraNavegacione').val(),
                                    'OperativoDespliegueRealizado': $('#txtOperativoDesplieguee').val(),
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
                                    $('#tblComfasubEvaluacionAlistamientoEntrenamientoComfasub').DataTable().ajax.reload();
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

    tblComfasubEvaluacionAlistamientoEntrenamientoComfasub = $('#tblComfasubEvaluacionAlistamientoEntrenamientoComfasub').DataTable({
        ajax: {
            "url": '/ComfasubEvaluacionAlistamientoEntrenamientoComfasub/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoEntrenamientoId" },
            { "data": "descUnidadNaval" },
            { "data": "descNivelEntrenamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "tipoCapacidadOperativa" },
            { "data": "descEjercicioEntrenamiento" },
            { "data": "ejercicioEntrenamientoAspectos" },
            { "data": "pesoAspectosEjercicio" },
            { "data": "descripcion" },
            { "data": "fechaPeriodoEvaluar" },
            { "data": "fechaRealizacionEjercicio" },
            { "data": "tiempoVigencia" }, 
            { "data": "horaNavegacionUnidad" }, 
            { "data": "operativoDespliegueRealizado" }, 
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
                filename: 'Comfasub - Evaluación del alistamiento del entrenamiento',
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
                filename: 'Comfasub - Evaluación del alistamiento del entrenamiento',
                title: 'Comfasub - Evaluación del alistamiento del entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfasub - Evaluación del alistamiento del entrenamiento',
                title: 'Comfasub - Evaluación del alistamiento del entrenamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfasub - Evaluación del alistamiento del entrenamiento',
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
    tblComfasubEvaluacionAlistamientoEntrenamientoComfasub.columns(14).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfasubEvaluacionAlistamientoEntrenamientoComfasub.columns(14).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfasubEvaluacionAlistamientoEntrenamientoComfasub/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoEntrenamientoComfasubDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.evaluacionAlistamientoEntrenamientoId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.codigoUnidadNaval);
        $('#cbNivelEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.codigoNivelEntrenamiento);
        $('#cbCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.codigoCapacidadOperativa);
        $('#txtTipoCapacidadOperativae').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.tipoCapacidadOperativa);
        $('#cbEjercicioEntrenamientoAspectoe').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.codigoEjercicioEntrenamientoComfasub);
        $('#txtDescEjercicioEntrenamientoe').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.ejercicioEntrenamientoAspectos);
        $('#txtPesoe').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.pesoAspectosEjercicio);
        $('#cbCalificativoAsignadoEjercicioe').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.codigoCalificativoAsignadoEjercicio);
        $('#txtFechaPeriodoEvaluare').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.fechaPeriodoEvaluar);
        $('#txtFechaRealizacionEjercicioe').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.fechaRealizacionEjercicio);
        $('#txtTiempoVigenciae').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.tiempoVigencia); 
        $('#txtHoraNavegacione').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.horaNavegacionUnidad); 
        $('#txtOperativoDesplieguee').val(EvaluacionAlistamientoEntrenamientoComfasubDTO.operativoDespliegueRealizado); 
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
                url: '/ComfasubEvaluacionAlistamientoEntrenamientoComfasub/Eliminar',
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
                    $('#tblComfasubEvaluacionAlistamientoEntrenamientoComfasub').DataTable().ajax.reload();
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
                url: '/ComfasubEvaluacionAlistamientoEntrenamientoComfasub/EliminarCarga',
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
                    $('#tblComfasubEvaluacionAlistamientoEntrenamientoComfasub').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComfasubEvaluacionAlistamientoEntrenamientoComfasub() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfasubEvaluacionAlistamientoEntrenamientoComfasub/MostrarDatos',
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
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.codigoNivelEntrenamiento),
                            $("<td>").text(item.codigoCapacidadOperativa),
                            $("<td>").text(item.TipoCapacidadOperativa),
                            $("<td>").text(item.codigoEjercicioEntrenamientoComfasub),
                            $("<td>").text(item.ejercicioEntrenamientoAspectos),
                            $("<td>").text(item.pesoAspectosEjercicio),
                            $("<td>").text(item.codigoCalificativoAsignadoEjercicio),
                            $("<td>").text(item.fechaPeriodoEvaluar),
                            $("<td>").text(item.fechaRealizacionEjercicio),
                            $("<td>").text(item.tiempoVigencia),
                            $("<td>").text(item.horaNavegacionUnidad),
                            $("<td>").text(item.operativoDespliegueRealizado)

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
    fetch("ComfasubEvaluacionAlistamientoEntrenamientoComfasub/EnviarDatos", {
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
    $.getJSON('/ComfasubEvaluacionAlistamientoEntrenamientoComfasub/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var NivelEntrenamiento = Json["data2"];
        var capacidadOperativa = Json["data3"];
        var ejercicioEntrenamientoAspecto = Json["data4"];
        var calificativoAsignadoEjercicio = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbNivelEntrenamiento").html("");
        $("select#cbNivelEntrenamientoe").html("");
        $.each(NivelEntrenamiento, function () {
            var RowContent = '<option value=' + this.codigoNivelEntrenamiento + '>' + this.descNivelEntrenamiento + '</option>'
            $("select#cbNivelEntrenamiento").append(RowContent);
            $("select#cbNivelEntrenamientoe").append(RowContent);
        });

        $("select#cbCapacidadOperativa").html("");
        $("select#cbCapacidadOperativae").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativa + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
            $("select#cbCapacidadOperativae").append(RowContent);
        });

        $("select#cbEjercicioEntrenamientoAspecto").html("");
        $("select#cbEjercicioEntrenamientoAspectoe").html("");
        $.each(ejercicioEntrenamientoAspecto, function () {
            var RowContent = '<option value=' + this.codigoEjercicioEntrenamiento + '>' + this.descEjercicioEntrenamiento + '</option>'
            $("select#cbEjercicioEntrenamientoAspecto").append(RowContent);
            $("select#cbEjercicioEntrenamientoAspectoe").append(RowContent);

        });

        $("select#cbCalificativoAsignadoEjercicio").html("");
        $("select#cbCalificativoAsignadoEjercicioe").html("");
        $.each(calificativoAsignadoEjercicio, function () {
            var RowContent = '<option value=' + this.codigoCalificativoAsignadoEjercicio + '>' + this.descripcion + '</option>'
            $("select#cbCalificativoAsignadoEjercicio").append(RowContent);
            $("select#cbCalificativoAsignadoEjercicioe").append(RowContent);
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

