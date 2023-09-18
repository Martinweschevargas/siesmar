var tblComescuamaEvaluacionAlistPersonal;
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
                                url: '/ComescuamaEvaluacionAlistPersonal/Insertar',
                                data: {
                                    'CodigoUnidadNaval ': $('#cbUnidadNaval').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacion').val(),
                                    'DNIPersonal': $('#txtDNIPersonal').val(),
                                    'CIPPersonal': $('#txtCIPPersonal').val(),
                                    'CodigoCargo ': $('#cbCargo').val(),
                                    'CodigoGradoPersonalMilitarEsperado ': $('#cbGradoPersonalMilitarEsperado').val(),
                                    'CodigoEspecialidadGenericaEsperado ': $('#cbEspecialidadGenericaEsperado').val(),
                                    'CodigoGradoPersonalMilitarActual ': $('#cbGradoPersonalMilitarActual').val(),
                                    'CodigoEspecialidadGenericaActual ': $('#cbEspecialidadGenericaActual').val(),
                                    'GradoJerarquico': $('#txtGradoJerarquico').val(),
                                    'ServicioExperiencia': $('#txtServicioExperiencia').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacionProfesional').val(),
                                    'CursoProfesionalRequerido': $('#txtCursoProfesionalR').val(),
                                    'TotalPuntaje': $('#txtTotalPuntaje').val(), 
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
                                    $('#tblComescuamaEvaluacionAlistPersonal').DataTable().ajax.reload();
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
                                url: '/ComescuamaEvaluacionAlistPersonal/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval ': $('#cbUnidadNavale').val(),
                                    'FechaEvaluacion': $('#txtFechaEvaluacione').val(),
                                    'DNIPersonal': $('#txtDNIPersonale').val(),
                                    'CIPPersonal': $('#txtCIPPersonale').val(),
                                    'CodigoCargo ': $('#cbCargoe').val(),
                                    'CodigoGradoPersonalMilitarEsperado ': $('#cbGradoPersonalMilitarEsperadoe').val(),
                                    'CodigoEspecialidadGenericaEsperado ': $('#cbEspecialidadGenericaEsperadoe').val(),
                                    'CodigoGradoPersonalMilitarActual ': $('#cbGradoPersonalMilitarActuale').val(),
                                    'CodigoEspecialidadGenericaActual ': $('#cbEspecialidadGenericaActuale').val(),
                                    'GradoJerarquico': $('#txtGradoJerarquicoe').val(),
                                    'ServicioExperiencia': $('#txtServicioExperienciae').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacionProfesionale').val(),
                                    'CursoProfesionalRequerido': $('#txtCursoProfesionalRe').val(),
                                    'TotalPuntaje': $('#txtTotalPuntajee').val(), 
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
                                    $('#tblComescuamaEvaluacionAlistPersonal').DataTable().ajax.reload();
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


        tblComescuamaEvaluacionAlistPersonal=  $('#tblComescuamaEvaluacionAlistPersonal').DataTable({
        ajax: {
            "url": '/ComescuamaEvaluacionAlistPersonal/CargaTabla',
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
            { "data": "descGradoPersonalMilitarEsperado " },
            { "data": "descEspecialidadGenericaEsperado" },
            { "data": "descGradoPersonalMilitarActual" },
            { "data": "descEspecialidadGenericaActual" },
            { "data": "gradoJerarquico" },
            { "data": "servicioExperiencia" },
            { "data": "especializacionProfesional" },
            { "data": "cursoProfesionalRequerido" },
            { "data": "totalPuntaje" }, 
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
                filename: 'Comescuama - Evaluación del Alistamiento de Personal',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9 , 10 , 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comescuama - Evaluación del Alistamiento de Personal',
                title: 'Comescuama - Evaluación del Alistamiento de Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescuama - Evaluación del Alistamiento de Personal',
                title: 'Comescuama - Evaluación del Alistamiento de Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescuama - Evaluación del Alistamiento de Personal',
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
    tblComescuamaEvaluacionAlistPersonal.columns(15).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComescuamaEvaluacionAlistPersonal.columns(15).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComescuamaEvaluacionAlistPersonal/Mostrar?Id=' + Id, [], function (EvaluacionAlistPersonalComescuamaDTO) {
        $('#txtCodigo').val(EvaluacionAlistPersonalComescuamaDTO.evaluacionAlistamientoPersonalId);
        $('#cbUnidadNavale').val(EvaluacionAlistPersonalComescuamaDTO.codigoUnidadNaval);
        $('#txtFechaEvaluacione').val(EvaluacionAlistPersonalComescuamaDTO.fechaEvaluacion);
        $('#txtDNIPersonale').val(EvaluacionAlistPersonalComescuamaDTO.dniPersonal);
        $('#txtCIPPersonale').val(EvaluacionAlistPersonalComescuamaDTO.cipPersonal);
        $('#cbCargoe').val(EvaluacionAlistPersonalComescuamaDTO.codigoCargo);
        $('#cbGradoPersonalMilitarEsperadoe').val(EvaluacionAlistPersonalComescuamaDTO.codigoGradoPersonalMilitarEsperado);
        $('#cbEspecialidadGenericaEsperadoe').val(EvaluacionAlistPersonalComescuamaDTO.codigoEspecialidadGenericaEsperado);
        $('#cbGradoPersonalMilitarActuale').val(EvaluacionAlistPersonalComescuamaDTO.codigoGradoPersonalMilitarActual);
        $('#cbEspecialidadGenericaActuale').val(EvaluacionAlistPersonalComescuamaDTO.codigoEspecialidadGenericaActual);
        $('#txtGradoJerarquicoe').val(EvaluacionAlistPersonalComescuamaDTO.gradoJerarquico);
        $('#txtServicioExperienciae').val(EvaluacionAlistPersonalComescuamaDTO.servicioExperiencia);
        $('#txtEspecializacionProfesionale').val(EvaluacionAlistPersonalComescuamaDTO.especializacionProfesional);
        $('#txtCursoProfesionalRe').val(EvaluacionAlistPersonalComescuamaDTO.cursoProfesionalRequerido);
        $('#txtTotalPuntajee').val(EvaluacionAlistPersonalComescuamaDTO.totalPuntaje); 
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
                url: '/ComescuamaEvaluacionAlistPersonal/Eliminar',
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
                    $('#tblComescuamaEvaluacionAlistPersonal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComescuamaEvaluacionAlistPersonal() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComescuamaEvaluacionAlistPersonal/MostrarDatos',
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
                            $("<td>").text(item.totalPuntaje)
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
    fetch("ComescuamaEvaluacionAlistPersonal/EnviarDatos", {
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
    $.getJSON('/ComescuamaEvaluacionAlistPersonal/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var GradoPersonalMilitarEsperado = Json["data2"];
        var EspecialidadGenericaEsperado = Json["data3"];
        var listaCargas = Json["data4"];

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


        $("select#cbGradoPersonalMilitarEsperado").html("");
        $.each(GradoPersonalMilitarEsperado, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGradoPersonalMilitar + '</option>'
            $("select#cbGradoPersonalMilitarEsperado").append(RowContent);
        });
        $("select#cbGradoPersonalMilitarEsperadoe").html("");
        $.each(GradoPersonalMilitarEsperado, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGradoPersonalMilitar + '</option>'
            $("select#cbGradoPersonalMilitarEsperadoe").append(RowContent);
        });


        $("select#cbEspecialidadGenericaEsperado").html("");
        $.each(EspecialidadGenericaEsperado, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidadGenericaPersonal + '</option>'
            $("select#cbEspecialidadGenericaEsperado").append(RowContent);
        });
        $("select#cbEspecialidadGenericaEsperadoe").html("");
        $.each(EspecialidadGenericaEsperado, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidadGenericaPersonal + '</option>'
            $("select#cbEspecialidadGenericaEsperadoe").append(RowContent);
        });


        $("select#cbGradoPersonalMilitarActual").html("");
        $.each(GradoPersonalMilitarActual, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGradoPersonalMilitar + '</option>'
            $("select#cbGradoPersonalMilitarActual").append(RowContent);
        });
        $("select#cbGradoPersonalMilitarActuale").html("");
        $.each(GradoPersonalMilitarActual, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGradoPersonalMilitar + '</option>'
            $("select#cbGradoPersonalMilitarActuale").append(RowContent);
        });


        $("select#cbEspecialidadGenericaActual").html("");
        $.each(EspecialidadGenericaActual, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidadGenericaPersonal + '</option>'
            $("select#cbEspecialidadGenericaActual").append(RowContent);
        });
        $("select#cbEspecialidadGenericaActuale").html("");
        $.each(EspecialidadGenericaActual, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidadGenericaPersonal + '</option>'
            $("select#cbEspecialidadGenericaActuale").append(RowContent);
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
function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/ComescuamaEvaluacionAlistPersonal/ReporteCEAP?idCarga=';
        $('#fecha').hide();
    }
    /*if (id == 2) { 
        reporteSeleccionado = '/BienestarMovilidadEscolar/ReporteME?idCarga=';
        $('#fecha').show();
    }*/
}
$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect = 1) {
        a.href = reporteSeleccionado + idCarga;
    } else {
        // a.href = reporteSeleccionado + idCarga;
    }
    a.click();
});

