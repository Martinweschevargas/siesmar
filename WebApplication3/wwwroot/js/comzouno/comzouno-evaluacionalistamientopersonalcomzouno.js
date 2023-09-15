var tblComzounoEvaluacionAlistamientoPersonalComzouno;

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
                                url: '/ComzounoEvaluacionAlistamientoPersonalComzouno/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacion').val(),
                                    'DNIPersonal': $('#txtDNIPersonal').val(),
                                    'CIPPersonal': $('#txtCIPPersonal').val(),
                                    'CodigoCargo': $('#cbCargo').val(),
                                    'CodigoGradoPersonalMilitarEsperado': $('#cbGradoPersonalMilitar').val(),
                                    'CodigoEspecialidadGenericaEsperado': $('#cbEspecialidadGenericaPersonal').val(),
                                    'CodigoGradoPersonalMilitarActual': $('#cbGradoPersonalMilitarActual').val(),
                                    'CodigoEspecialidadGenericaActual': $('#cbEspecialidadGenericaPersonalActual').val(),
                                    'GradoJerarquico': $('#txtGradoJerarquico').val(),
                                    'ServicioExperiencia': $('#txtServicioExperiencia').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacionProfesional').val(),
                                    'CursoProfesionalRequerido': $('#txtCursoProfesionalRequerido').val(), 
                                    'PuntajeTotalPersonal': $('#txtPuntuajeTotal').val(),
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
                                    $('#tblComzounoEvaluacionAlistamientoPersonalComzouno').DataTable().ajax.reload();
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
                                url: '/ComzounoEvaluacionAlistamientoPersonalComzouno/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacione').val(),
                                    'DNIPersonal': $('#txtDNIPersonale').val(),
                                    'CIPPersonal': $('#txtCIPPersonale').val(),
                                    'CodigoCargo': $('#cbCargoe').val(),
                                    'CodigoGradoPersonalMilitarEsperado': $('#cbGradoPersonalMilitare').val(),
                                    'CodigoEspecialidadGenericaEsperado': $('#cbEspecialidadGenericaPersonale').val(),
                                    'CodigoGradoPersonalMilitarActual': $('#cbGradoPersonalMilitarActuale').val(),
                                    'CodigoEspecialidadGenericaActual': $('#cbEspecialidadGenericaPersonalActuale').val(),
                                    'GradoJerarquico': $('#txtGradoJerarquicoe').val(),
                                    'ServicioExperiencia': $('#txtServicioExperienciae').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacionProfesionale').val(),
                                    'CursoProfesionalRequerido': $('#txtCursoProfesionalRequeridoe').val(),
                                    'PuntajeTotalPersonal': $('#txtPuntuajeTotale').val(),
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
                                    $('#tblComzounoEvaluacionAlistamientoPersonalComzouno').DataTable().ajax.reload();
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

    tblComzounoEvaluacionAlistamientoPersonalComzouno = $('#tblComzounoEvaluacionAlistamientoPersonalComzouno').DataTable({
        ajax: {
            "url": '/ComzounoEvaluacionAlistamientoPersonalComzouno/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoPersonalId" },
            { "data": "descUnidadNaval" },
            { "data": "fechaEvaluacion" },
            { "data": "dniPersonal" },
            { "data": "cipPersonal" },
            { "data": "descCargo" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "descGradoPersonalMilitarActual" },
            { "data": "descEspecialidadGenericaPersonalActual" },
            { "data": "gradoJerarquico" },
            { "data": "servicioExperiencia" },
            { "data": "especializacionProfesional" },
            { "data": "cursoProfesionalRequerido" }, 
            { "data": "puntajeTotalPersonal" },
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionAlistamientoPersonalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionAlistamientoPersonalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzouno - Evaluación del alistamiento de personal',
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
                filename: 'Comzouno - Evaluación del alistamiento de personal',
                title: 'Comzouno - Evaluación del alistamiento de personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzouno - Evaluación del alistamiento de personal',
                title: 'Comzouno - Evaluación del alistamiento de personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzouno - Evaluación del alistamiento de personal',
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
    tblComzounoEvaluacionAlistamientoPersonalComzouno.columns(15).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComzounoEvaluacionAlistamientoPersonalComzouno.columns(15).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzounoEvaluacionAlistamientoPersonalComzouno/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoPersonalComzounoDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoPersonalComzounoDTO.evaluacionAlistamientoPersonalComzounoId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoPersonalComzounoDTO.codigoUnidadNaval);
        $('#txtFechaEvaluacione').val(EvaluacionAlistamientoPersonalComzounoDTO.fechaEvaluacion);
        $('#txtDNIPersonale').val(EvaluacionAlistamientoPersonalComzounoDTO.dniPersonal);
        $('#txtCIPPersonale').val(EvaluacionAlistamientoPersonalComzounoDTO.cipPersonal);
        $('#cbCargoe').val(EvaluacionAlistamientoPersonalComzounoDTO.codigoCargo);
        $('#cbGradoPersonalMilitare').val(EvaluacionAlistamientoPersonalComzounoDTO.codigoGradoPersonalMilitarEsperado);
        $('#cbEspecialidadGenericaPersonale').val(EvaluacionAlistamientoPersonalComzounoDTO.codigoEspecialidadGenericaEsperado);
        $('#cbCodigoGradoPersonalMilitarActuale').val(EvaluacionAlistamientoPersonalComzounoDTO.codigoGradoPersonalMilitarActual);
        $('#cbEspecialidadGenericaPersonalActuale').val(EvaluacionAlistamientoPersonalComzounoDTO.codigoEspecialidadGenericaActual);
        $('#txtGradoJerarquicoe').val(EvaluacionAlistamientoPersonalComzounoDTO.gradoJerarquico);
        $('#txtServicioExperienciae').val(EvaluacionAlistamientoPersonalComzounoDTO.servicioExperiencia);
        $('#txtEspecializacionProfesionale').val(EvaluacionAlistamientoPersonalComzounoDTO.especializacionProfesional);
        $('#txtCursoProfesionalRequeridoe').val(EvaluacionAlistamientoPersonalComzounoDTO.cursoProfesionalRequerido); 
        $('#txtPuntuajeTotale').val(EvaluacionAlistamientoPersonalComzounoDTO.puntajeTotalPersonal); 
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
                url: '/ComzounoEvaluacionAlistamientoPersonalComzouno/Eliminar',
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
                    $('#tblComzounoEvaluacionAlistamientoPersonalComzouno').DataTable().ajax.reload();
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
                url: '/ComzounoEvaluacionAlistamientoPersonalComzouno/EliminarCarga',
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
                    $('#tblComzounoEvaluacionAlistamientoPersonalComzouno').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComzounoEvaluacionAlistamientoPersonalComzouno() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComzounoEvaluacionAlistamientoPersonalComzouno/MostrarDatos',
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
                            $("<td>").text(item.fechaEvaluacion),
                            $("<td>").text(item.dniPersonal),
                            $("<td>").text(item.cipPersonal),
                            $("<td>").text(item.codigoCargo),
                            $("<td>").text(item.codigoGradoPersonalMilitarEsperado),
                            $("<td>").text(item.codigoEspecialidadGenericaEsperado),
                            $("<td>").text(item.codigoGradoPersonalMilitarActual),
                            $("<td>").text(item.codigoEspecialidadGenericaActual),
                            $("<td>").text(item.gradoJerarquico),
                            $("<td>").text(item.servicioExperiencia),
                            $("<td>").text(item.especializacionProfesional),
                            $("<td>").text(item.cursoProfesionalRequerido),
                            $("<td>").text(item.puntajeTotalPersonal)

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
    fetch("ComzounoEvaluacionAlistamientoPersonalComzouno/EnviarDatos", {
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
    $.getJSON('/ComzounoEvaluacionAlistamientoPersonalComzouno/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var cargo = Json["data2"];
        var gradoPersonalMilitar = Json["data3"];
        var especialidadGenericaPersonal = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbCargo").html("");
        $("select#cbCargoe").html("");
        $.each(cargo, function () {
            var RowContent = '<option value=' + this.codigoCargo + '>' + this.descCargo + '</option>'
            $("select#cbCargo").append(RowContent);
            $("select#cbCargoe").append(RowContent);
        });

        $("select#cbGradoPersonalMilitar").html("");
        $("select#cbGradoPersonalMilitare").html("");
        $("select#cbGradoPersonalMilitarActual").html("");
        $("select#cbGradoPersonalMilitarActuale").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarActuale").append(RowContent);
            $("select#cbGradoPersonalMilitarActual").append(RowContent);
            $("select#cbGradoPersonalMilitare").append(RowContent);
            $("select#cbGradoPersonalMilitar").append(RowContent);

        });

        $("select#cbEspecialidadGenericaPersonal").html("");
        $("select#cbEspecialidadGenericaPersonale").html("");
        $("select#cbEspecialidadGenericaPersonalActual").html("");
        $("select#cbEspecialidadGenericaPersonalActuale").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonalActuale").append(RowContent);
            $("select#cbEspecialidadGenericaPersonalActual").append(RowContent);
            $("select#cbEspecialidadGenericaPersonale").append(RowContent);
            $("select#cbEspecialidadGenericaPersonal").append(RowContent);

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

