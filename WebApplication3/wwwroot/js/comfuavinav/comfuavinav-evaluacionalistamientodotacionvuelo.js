var tblComfuavinavEvaluacionAlistamientoDotacionVuelo;
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
                                url: '/ComfuavinavEvaluacionAlistamientoDotacionVuelo/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacion').val(),
                                    'DNIPersonal': $('#txtDNIPersonal').val(),
                                    'CIPPersonal': $('#txtCIPPersonal').val(),
                                    'CodigoCargo': $('#cbCargoPersonal').val(),
                                    'CodigoGradoPersonalMilitarEsperado': $('#cbGradoPersonalMilitarEsperado').val(),
                                    'CodigoEspecialidadGenericaEsperado': $('#cbEspecialidadGenericaEsperado').val(),
                                    'CodigoGradoPersonalMilitarActual': $('#cbGradoPersonalMilitarActual').val(),
                                    'CodigoEspecialidadGenericaActual': $('#cbEspecialidadGenericaActual').val(),
                                    'GradoJerarquico': $('#txtGradoJerarquico').val(),
                                    'ServicioExperiencia': $('#txtServicioExperiencia').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacionProfesional').val(),
                                    'CursoProfesionalRequerido': $('#txtCursoProfesionalRequerido').val(),
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
                                    $('#tblComfuavinavEvaluacionAlistamientoDotacionVuelo').DataTable().ajax.reload();
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
                                url: '/ComfuavinavEvaluacionAlistamientoDotacionVuelo/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacione').val(),
                                    'DNIPersonal': $('#txtDNIPersonale').val(),
                                    'CIPPersonal': $('#txtCIPPersonale').val(),
                                    'CodigoCargo': $('#cbCargoPersonale').val(),
                                    'CodigoGradoPersonalMilitarEsperado': $('#cbGradoPersonalMilitarEsperadoe').val(),
                                    'CodigoEspecialidadGenericaEsperado': $('#cbEspecialidadGenericaEsperadoe').val(),
                                    'CodigoGradoPersonalMilitarActual': $('#cbGradoPersonalMilitarActuale').val(),
                                    'CodigoEspecialidadGenericaActual': $('#cbEspecialidadGenericaActuale').val(),
                                    'GradoJerarquico': $('#txtGradoJerarquicoe').val(),
                                    'ServicioExperiencia': $('#txtServicioExperienciae').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacionProfesionale').val(),
                                    'CursoProfesionalRequerido': $('#txtCursoProfesionalRequeridoe').val(),

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
                                    $('#tblComfuavinavEvaluacionAlistamientoDotacionVuelo').DataTable().ajax.reload();
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

   tblComfuavinavEvaluacionAlistamientoDotacionVuelo = $('#tblComfuavinavEvaluacionAlistamientoDotacionVuelo').DataTable({
        ajax: {
            "url": '/ComfuavinavEvaluacionAlistamientoDotacionVuelo/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoDotacionVueloId" },
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
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionAlistamientoDotacionVueloId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionAlistamientoDotacionVueloId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfuavinav - Evaluación del Alistamiento de Dotación de Vuelo',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9 , 10 , 11, 12, 13]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfuavinav - Evaluación del Alistamiento de Dotación de Vuelo',
                title: 'Comfuavinav - Evaluación del Alistamiento de Dotación de Vuelo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfuavinav - Evaluación del Alistamiento de Dotación de Vuelo',
                title: 'Comfuavinav - Evaluación del Alistamiento de Dotación de Vuelo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfuavinav - Evaluación del Alistamiento de Dotación de Vuelo',
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
    tblComfuavinavEvaluacionAlistamientoDotacionVuelo.columns(14).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComfuavinavEvaluacionAlistamientoDotacionVuelo.columns(14).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfuavinavEvaluacionAlistamientoDotacionVuelo/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoDotacionVueloComfuavinavDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.evaluacionAlistamientoDotacionVueloId);
        $('#cbUnidadNavale').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.codigoUnidadNaval);
        $('#txtFechaEvaluacione').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.fechaEvaluacion);
        $('#txtDNIPersonale').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.dniPersonal);
        $('#txtCIPPersonale').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.cipPersonal);
        $('#cbCargoPersonale').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.codigoCargo);
        $('#cbGradoPersonalMilitarEsperadoe').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.codigoGradoPersonalMilitarEsperado);
        $('#cbEspecialidadGenericaEsperadoe').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.codigoEspecialidadGenericaEsperado);
        $('#cbGradoPersonalMilitarActuale').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.codigoGradoPersonalMilitarActual);
        $('#cbEspecialidadGenericaActuale').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.codigoEspecialidadGenericaActual);
        $('#txtGradoJerarquicoe').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.gradoJerarquico);
        $('#txtServicioExperienciae').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.servicioExperiencia);
        $('#txtEspecializacionProfesionale').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.especializacionProfesional);
        $('#txtCursoProfesionalRequeridoe').val(EvaluacionAlistamientoDotacionVueloComfuavinavDTO.cursoProfesionalRequerido); 
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
                url: '/ComfuavinavEvaluacionAlistamientoDotacionVuelo/Eliminar',
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
                    $('#tblComfuavinavEvaluacionAlistamientoDotacionVuelo').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfuavinavEvaluacionAlistamientoDotacionVuelo() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfuavinavEvaluacionAlistamientoDotacionVuelo/MostrarDatos',
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
                            $("<td>").text(item.cursoProfesionalRequerido)
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
    fetch("ComfuavinavEvaluacionAlistamientoDotacionVuelo/EnviarDatos", {
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
                    'Ocurrio un problema.' + mensaje,
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
                url: '/ComfuavinavEvaluacionAlistamientoDotacionVuelo/EliminarCarga',
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
                    $('#tblComfuavinavEvaluacionAlistamientoDotacionVuelo').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/ComfuavinavEvaluacionAlistamientoDotacionVuelo/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var cargoPersonal = Json["data2"];
        var gradoPersonalMilitarEsperado = Json["data3"];
        var especialidadGenericaEsperado = Json["data4"];
        var listaCargas = Json["data5"];


        $("select#cbUnidadNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbCargoPersonal").html("");
        $.each(cargoPersonal, function () {
            var RowContent = '<option value=' + this.codigoCargo + '>' + this.descCargo + '</option>'
            $("select#cbCargoPersonal").append(RowContent);
        });
        $("select#cbCargoPersonale").html("");
        $.each(cargoPersonal, function () {
            var RowContent = '<option value=' + this.codigoCargo + '>' + this.descCargo + '</option>'
            $("select#cbCargoPersonale").append(RowContent);
        });

        $("select#cbGradoPersonalMilitarEsperado").html("");
        $.each(gradoPersonalMilitarEsperado, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarEsperado").append(RowContent);
        });
        $("select#cbGradoPersonalMilitarEsperadoe").html("");
        $.each(gradoPersonalMilitarEsperado, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarEsperadoe").append(RowContent);
        });


        $("select#cbEspecialidadGenericaEsperado").html("");
        $.each(especialidadGenericaEsperado, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaEsperado").append(RowContent);
        });
        $("select#cbEspecialidadGenericaEsperadoe").html("");
        $.each(especialidadGenericaEsperado, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaEsperadoe").append(RowContent);
        });


        $("select#cbGradoPersonalMilitarActual").html("");
        $.each(gradoPersonalMilitarEsperado, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarActual").append(RowContent);
        });
        $("select#cbGradoPersonalMilitarActuale").html("");
        $.each(gradoPersonalMilitarEsperado, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitarActuale").append(RowContent);
        });


        $("select#cbEspecialidadGenericaActual").html("");
        $.each(especialidadGenericaEsperado, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaActual").append(RowContent);
        });
        $("select#cbEspecialidadGenericaActuale").html("");
        $.each(especialidadGenericaEsperado, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaActuale").append(RowContent);
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

    reporteSeleccionado = '/DipermarProcedimientoAdministrativoCivil/ReportePAC';
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
