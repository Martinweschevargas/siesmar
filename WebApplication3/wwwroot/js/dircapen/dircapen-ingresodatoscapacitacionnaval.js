var tblDircapenIngresoDatosCapacitacionNaval;
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
                                url: '/DircapenIngresoDatosCapacitacionNaval/Insertar',
                                data: {
                                    'CIPPersonal': $('#txtCIP').val(),
                                    'DNIPersonal': $('#txtDNI').val(),
                                    'SexoPersonal': $('#txtSexo').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonal').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGrado').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenerica').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoProgramaEspecializacionEspecifico': $('#cbNivel').val(),
                                    'CodigoProgramaEspecializacionGrupo': $('#cbPrograma').val(),
                                    'FechaInicio': $('#txtFechaInicio').val(),
                                    'FechaTemino': $('#txtFechaTermino').val(),
                                    'CodigoTipoModalidad': $('#cbModalidad').val(),
                                    'ConcluyoProgramaEstudios': $('#txtConcluyoPrograma').val(),
                                    'TotalCredito': $('#txtTotalCreditos').val(),
                                    'MotivosNoConcluir': $('#txtMotivosNoConcluir').val(),
                                    'CalificacionFinalObtenida': $('#txtCalificacionFinal').val(),
                                    'NombreDiploma': $('#txtDiploma').val(), 
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
                                    $('#tblDircapenIngresoDatosCapacitacionNaval').DataTable().ajax.reload();
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
                                url: '/DircapenIngresoDatosCapacitacionNaval/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CIPPersonal': $('#txtCIPe').val(),
                                    'DNIPersonal': $('#txtDNIe').val(),
                                    'SexoPersonal': $('#txtSexoe').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonale').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoe').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericae').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoProgramaEspecializacionEspecifico': $('#cbNivele').val(),
                                    'CodigoProgramaEspecializacionGrupo': $('#cbProgramae').val(),
                                    'FechaInicio': $('#txtFechaInicioe').val(),
                                    'FechaTemino': $('#txtFechaTerminoe').val(),
                                    'CodigoTipoModalidad': $('#cbModalidade').val(),
                                    'ConcluyoProgramaEstudios': $('#txtConcluyoProgramae').val(),
                                    'TotalCredito': $('#txtTotalCreditose').val(),
                                    'MotivosNoConcluir': $('#txtMotivosNoConcluire').val(),
                                    'CalificacionFinalObtenida': $('#txtCalificacionFinale').val(),
                                    'NombreDiploma': $('#txtDiplomae').val(), 
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
                                    $('#tblDircapenIngresoDatosCapacitacionNaval').DataTable().ajax.reload();
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


        tblDircapenIngresoDatosCapacitacionNaval=  $('#tblDircapenIngresoDatosCapacitacionNaval').DataTable({
        ajax: {
            "url": '/DircapenIngresoDatosCapacitacionNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ingresoDatoCapacitacionNavalId" },
            { "data": "cipPersonal" },
            { "data": "dniPersonal" },
            { "data": "sexoPersonal" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "nombreDependencia" },
            { "data": "descZonaNaval" },
            { "data": "descProgramaEspecializacionEspecifico" },
            { "data": "descProgramaEspecializacionGrupo" },
            { "data": "fechaInicio" },
            { "data": "fechaTemino" },
            { "data": "descTipoModalidad" },
            { "data": "concluyoProgramaEstudios" },
            { "data": "totalCredito" },
            { "data": "motivosNoConcluir" },
            { "data": "calificacionFinalObtenida" },
            { "data": "nombreDiploma" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ingresoDatoCapacitacionNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ingresoDatoCapacitacionNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dircapen - Formatos para el Ingreso de Datos de la Dirección de Capacitación del Personal Naval',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dircapen - Formatos para el Ingreso de Datos de la Dirección de Capacitación del Personal Naval',
                title: 'Dircapen - Formatos para el Ingreso de Datos de la Dirección de Capacitación del Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dircapen - Formatos para el Ingreso de Datos de la Dirección de Capacitación del Personal Naval',
                title: 'Dircapen - Formatos para el Ingreso de Datos de la Dirección de Capacitación del Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dircapen - Formatos para el Ingreso de Datos de la Dirección de Capacitación del Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11, 12, 13, 14, 15, 16, 17, 18]
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
    tblDircapenIngresoDatosCapacitacionNaval.columns(19).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDircapenIngresoDatosCapacitacionNaval.columns(19).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DircapenIngresoDatosCapacitacionNaval/Mostrar?Id=' + Id, [], function (IngresoDatosCapacitacionNavalDTO) {
        $('#txtCodigo').val(IngresoDatosCapacitacionNavalDTO.ingresoDatoCapacitacionNavalId);
        $('#txtCIPe').val(IngresoDatosCapacitacionNavalDTO.cipPersonal);
        $('#txtDNIe').val(IngresoDatosCapacitacionNavalDTO.dniPersonal);
        $('#txtSexoe').val(IngresoDatosCapacitacionNavalDTO.sexoPersonal);
        $('#cbTipoPersonale').val(IngresoDatosCapacitacionNavalDTO.codigoTipoPersonalMilitar);
        $('#cbGradoe').val(IngresoDatosCapacitacionNavalDTO.codigoGradoPersonalMilitar);
        $('#cbEspecialidadGenericae').val(IngresoDatosCapacitacionNavalDTO.codigoEspecialidadGenericaPersonal);
        $('#cbDependenciae').val(IngresoDatosCapacitacionNavalDTO.codigoDependencia);
        $('#cbZonaNavale').val(IngresoDatosCapacitacionNavalDTO.codigoZonaNaval);
        $('#cbNivele').val(IngresoDatosCapacitacionNavalDTO.codigoProgramaEspecializacionEspecifico);
        $('#cbProgramae').val(IngresoDatosCapacitacionNavalDTO.codigoProgramaEspecializacionGrupo);
        $('#txtFechaInicioe').val(IngresoDatosCapacitacionNavalDTO.fechaInicio);
        $('#txtFechaTerminoe').val(IngresoDatosCapacitacionNavalDTO.fechaTemino);
        $('#cbModalidade').val(IngresoDatosCapacitacionNavalDTO.codigoTipoModalidad);
        $('#txtConcluyoProgramae').val(IngresoDatosCapacitacionNavalDTO.concluyoProgramaEstudios);
        $('#txtTotalCreditose').val(IngresoDatosCapacitacionNavalDTO.totalCredito);
        $('#txtMotivosNoConcluire').val(IngresoDatosCapacitacionNavalDTO.motivosNoConcluir);
        $('#txtCalificacionFinale').val(IngresoDatosCapacitacionNavalDTO.calificacionFinalObtenida);
        $('#txtDiplomae').val(IngresoDatosCapacitacionNavalDTO.nombreDiploma); 
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
                url: '/DircapenIngresoDatosCapacitacionNaval/Eliminar',
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
                    $('#tblDircapenIngresoDatosCapacitacionNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDircapenIngresoDatosCapacitacionNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DircapenIngresoDatosCapacitacionNaval/MostrarDatos',
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
                            $("<td>").text(item.cipPersonal),
                            $("<td>").text(item.dniPersonal),
                            $("<td>").text(item.sexoPersonal),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoProgramaEspecializacionEspecifico),
                            $("<td>").text(item.codigoProgramaEspecializacionGrupo),
                            $("<td>").text(item.fechaInicio),
                            $("<td>").text(item.fechaTemino),
                            $("<td>").text(item.codigoTipoModalidad),
                            $("<td>").text(item.concluyoProgramaEstudios),
                            $("<td>").text(item.totalCredito),
                            $("<td>").text(item.motivosNoConcluir),
                            $("<td>").text(item.calificacionFinalObtenida),
                            $("<td>").text(item.nombreDiploma),
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
    fetch("DircapenIngresoDatosCapacitacionNaval/EnviarDatos", {
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
                url: '/DircapenIngresoDatosCapacitacionNaval/EliminarCarga',
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
                    $('#tblDircapenIngresoDatosCapacitacionNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DircapenIngresoDatosCapacitacionNaval/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var tipoPersonalMilitar = Json["data2"];
        var especialidadGenericaPersonal = Json["data3"];
        var dependencia = Json["data4"];
        var zonaNaval = Json["data5"];
        var tipoModalidad = Json["data6"];
        var programaEspecializacionEspecifico = Json["data7"];
        var programaEspecializacionGrupo = Json["data8"];
        var listaCargas = Json["data9"];

        $("select#cbGrado").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGrado").append(RowContent);
        });
        $("select#cbGradoe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoe").append(RowContent);
        });

        $("select#cbTipoPersonal").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonal").append(RowContent);
        });
        $("select#cbTipoPersonale").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonale").append(RowContent);
        });

        $("select#cbEspecialidadGenerica").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenerica").append(RowContent);
        });
        $("select#cbEspecialidadGenericae").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericae").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbZonaNaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
        });

        $("select#cbModalidad").html("");
        $.each(tipoModalidad, function () {
            var RowContent = '<option value=' + this.codigoTipoModalidad + '>' + this.descTipoModalidad + '</option>'
            $("select#cbModalidad").append(RowContent);
        });
        $("select#cbModalidade").html("");
        $.each(tipoModalidad, function () {
            var RowContent = '<option value=' + this.codigoTipoModalidad + '>' + this.descTipoModalidad + '</option>'
            $("select#cbModalidade").append(RowContent);
        });

        $("select#cbNivel").html("");
        $.each(programaEspecializacionEspecifico, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionEspecifico + '>' + this.descProgramaEspecializacionEspecifico + '</option>'
            $("select#cbNivel").append(RowContent);
        });
        $("select#cbNivele").html("");
        $.each(programaEspecializacionEspecifico, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionEspecifico + '>' + this.descProgramaEspecializacionEspecifico + '</option>'
            $("select#cbNivele").append(RowContent);
        });

        $("select#cbPrograma").html("");
        $.each(programaEspecializacionGrupo, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionGrupo + '>' + this.descProgramaEspecializacionGrupo + '</option>'
            $("select#cbPrograma").append(RowContent);
        });
        $("select#cbProgramae").html("");
        $.each(programaEspecializacionGrupo, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionGrupo + '>' + this.descProgramaEspecializacionGrupo + '</option>'
            $("select#cbProgramae").append(RowContent);
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
        reporteSeleccionado = '/DircapenIngresoDatosCapacitacionNaval/ReporteDIDCN?idCarga=';
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