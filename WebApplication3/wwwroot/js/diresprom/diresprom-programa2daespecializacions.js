var tblDirespromPrograma2daEspecializacionS;
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
                                url: '/DirespromPrograma2daEspecializacionS/Insertar',
                                data: {
                                    'DNIPersonalSuperior': $('#txtDNI').val(),
                                    'EdadPersonalSuperior': $('#txtEdad').val(),
                                    'SexoPersonalSuperior': $('#txtSexo').val(),
                                    'CondicionPersonalSuperior': $('#txtCondicion').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalM').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGP').val(),
                                    'ProcedenciaPersonalSuperior': $('#txtProcedenciaPS').val(),
                                    'AnioPromocionPersonalSuperior': $('#txtAnioPromocionPS').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoProgramaEspecializacionGrupo': $('#cbProgramaEspecializacionG').val(),
                                    'CodigoProgramaEspecializacionEspecifico': $('#cbProgramaEspecializacionE').val(),
                                    'FechaInicio': $('#txtFechaInicio').val(),
                                    'FechaTermino': $('#txtFechaTermino').val(),
                                    'FechaRegistro': $('#txtFechaRegistro').val(),
                                    'CodigoModalidadPrograma': $('#cbModalidadPrograma').val(),
                                    'ConcluyoProgramaEstudios': $('#txtConcluyoProgramaEstudios').val(),
                                    'MotivosNoConcluir': $('#txtMotivosNoConcluir').val(),
                                    'CalificacionFinalObtenida': $('#txtCalificacionFinalO').val(),
                                    'CertificacionTituloObtenido': $('#txtCertificacionTituloO').val(), 
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
                                    $('#tblDirespromPrograma2daEspecializacionS').DataTable().ajax.reload();
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
                                url: '/DirespromPrograma2daEspecializacionS/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPersonalSuperior': $('#txtDNIe').val(),
                                    'EdadPersonalSuperior': $('#txtEdade').val(),
                                    'SexoPersonalSuperior': $('#txtSexoe').val(),
                                    'CondicionPersonalSuperior': $('#txtCondicione').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMe').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGPe').val(),
                                    'ProcedenciaPersonalSuperior': $('#txtProcedenciaPSe').val(),
                                    'AnioPromocionPersonalSuperior': $('#txtAnioPromocionPSe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoProgramaEspecializacionGrupo': $('#cbProgramaEspecializacionGe').val(),
                                    'CodigoProgramaEspecializacionEspecifico': $('#cbProgramaEspecializacionEe').val(),
                                    'FechaInicio': $('#txtFechaInicioe').val(),
                                    'FechaTermino': $('#txtFechaTerminoe').val(),
                                    'FechaRegistro': $('#txtFechaRegistroe').val(),
                                    'CodigoModalidadPrograma': $('#cbModalidadProgramae').val(),
                                    'ConcluyoProgramaEstudios': $('#txtConcluyoProgramaEstudiose').val(),
                                    'MotivosNoConcluir': $('#txtMotivosNoConcluire').val(),
                                    'CalificacionFinalObtenida': $('#txtCalificacionFinalOe').val(),
                                    'CertificacionTituloObtenido': $('#txtCertificacionTituloOe').val(), 
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
                                    $('#tblDirespromPrograma2daEspecializacionS').DataTable().ajax.reload();
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


    tblDirespromPrograma2daEspecializacionS = $('#tblDirespromPrograma2daEspecializacionS').DataTable({
        ajax: {
            "url": '/DirespromPrograma2daEspecializacionS/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "programa2daEspecializacionSuperiorId" },
            { "data": "dniPersonalSuperior" },
            { "data": "edadPersonalSuperior" },
            { "data": "sexoPersonalSuperior" },
            { "data": "condicionPersonalSuperior" },
            { "data": "descEntidadMilitar" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "procedenciaPersonalSuperior" },
            { "data": "anioPromocionPersonalSuperior" },
            { "data": "nombreDependencia" },
            { "data": "descZonaNaval" },
            { "data": "descProgramaEspecializacionGrupo" },
            { "data": "descProgramaEspecializacionEspecifico" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "fechaRegistro" },
            { "data": "descModalidadPrograma" },
            { "data": "concluyoProgramaEstudios" },
            { "data": "motivosNoConcluir" },
            { "data": "calificacionFinalObtenida" },
            { "data": "certificacionTituloObtenido" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.programa2daEspecializacionSuperiorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.programa2daEspecializacionSuperiorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresprom - Programas de Segunda Especialización del Personal Superior de la Marina',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diresprom - Programas de Segunda Especialización del Personal Superior de la Marina',
                title: 'Diresprom - Programas de Segunda Especialización del Personal Superior de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresprom - Programas de Segunda Especialización del Personal Superior de la Marina',
                title: 'Diresprom - Programas de Segunda Especialización del Personal Superior de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresprom - Programas de Segunda Especialización del Personal Superior de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
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
    tblDirespromPrograma2daEspecializacionS.columns(22).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblDirespromPrograma2daEspecializacionS.columns(22).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirespromPrograma2daEspecializacionS/Mostrar?Id=' + Id, [], function (Programa2daEspecializacionSuperiorDTO) {
        $('#txtCodigo').val(Programa2daEspecializacionSuperiorDTO.programa2daEspecializacionSuperiorId);
        $('#txtDNIe').val(Programa2daEspecializacionSuperiorDTO.dniPersonalSuperior);
        $('#txtEdade').val(Programa2daEspecializacionSuperiorDTO.edadPersonalSuperior);
        $('#txtSexoe').val(Programa2daEspecializacionSuperiorDTO.sexoPersonalSuperior);
        $('#txtCondicione').val(Programa2daEspecializacionSuperiorDTO.condicionPersonalSuperior);
        $('#cbEntidadMilitare').val(Programa2daEspecializacionSuperiorDTO.codigoEntidadMilitar);
        $('#cbGradoPersonalMe').val(Programa2daEspecializacionSuperiorDTO.codigoGradoPersonalMilitar);
        $('#cbEspecialidadGPe').val(Programa2daEspecializacionSuperiorDTO.codigoEspecialidadGenericaPersonal);
        $('#txtProcedenciaPSe').val(Programa2daEspecializacionSuperiorDTO.procedenciaPersonalSuperior);
        $('#txtAnioPromocionPSe').val(Programa2daEspecializacionSuperiorDTO.anioPromocionPersonalSuperior);
        $('#cbDependenciae').val(Programa2daEspecializacionSuperiorDTO.codigoDependencia);
        $('#cbZonaNavale').val(Programa2daEspecializacionSuperiorDTO.codigoZonaNaval);
        $('#cbProgramaEspecializacionGe').val(Programa2daEspecializacionSuperiorDTO.codigoProgramaEspecializacionGrupo);
        $('#cbProgramaEspecializacionEe').val(Programa2daEspecializacionSuperiorDTO.codigoProgramaEspecializacionEspecifico);
        $('#txtFechaInicioe').val(Programa2daEspecializacionSuperiorDTO.fechaInicio);
        $('#txtFechaTerminoe').val(Programa2daEspecializacionSuperiorDTO.fechaTermino);
        $('#txtFechaRegistroe').val(Programa2daEspecializacionSuperiorDTO.fechaRegistro);
        $('#cbModalidadProgramae').val(Programa2daEspecializacionSuperiorDTO.codigoModalidadPrograma);
        $('#txtConcluyoProgramaEstudiose').val(Programa2daEspecializacionSuperiorDTO.concluyoProgramaEstudios);
        $('#txtMotivosNoConcluire').val(Programa2daEspecializacionSuperiorDTO.motivosNoConcluir);
        $('#txtCalificacionFinalOe').val(Programa2daEspecializacionSuperiorDTO.calificacionFinalObtenida);
        $('#txtCertificacionTituloOe').val(Programa2daEspecializacionSuperiorDTO.certificacionTituloObtenido); 
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
                url: '/DirespromPrograma2daEspecializacionS/Eliminar',
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
                    $('#tblDirespromPrograma2daEspecializacionS').DataTable().ajax.reload();
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
                url: '/DirespromPrograma2daEspecializacionS/EliminarCarga',
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
                    $('#tblDirespromPrograma2daEspecializacionS').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDirespromPrograma2daEspecializacionS() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirespromPrograma2daEspecializacionS/MostrarDatos',
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
                            $("<td>").text(item.dniPersonalSuperior),
                            $("<td>").text(item.edadPersonalSuperior),
                            $("<td>").text(item.sexoPersonalSuperior),
                            $("<td>").text(item.condicionPersonalSuperior),
                            $("<td>").text(item.codigoEntidadMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.procedenciaPersonalSuperior),
                            $("<td>").text(item.anioPromocionPersonalSuperior),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoProgramaEspecializacionGrupo),
                            $("<td>").text(item.codigoProgramaEspecializacionEspecifico),
                            $("<td>").text(item.fechaInicio),
                            $("<td>").text(item.fechaTermino),
                            $("<td>").text(item.fechaRegistro),
                            $("<td>").text(item.codigoModalidadPrograma),
                            $("<td>").text(item.concluyoProgramaEstudios),
                            $("<td>").text(item.motivosNoConcluir),
                            $("<td>").text(item.calificacionFinalObtenida),
                            $("<td>").text(item.certificacionTituloObtenido),

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
    fetch("DirespromPrograma2daEspecializacionS/EnviarDatos", {
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
    $.getJSON('/DirespromPrograma2daEspecializacionS/cargaCombs', [], function (Json) {
        var entidadMilitar = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var especialidadGenericaPersonal = Json["data3"];
        var dependencia = Json["data4"];
        var zonaNaval = Json["data5"];
        var programaEspecializacionGrupo = Json["data6"];
        var programaEspecializacionEspecifico = Json["data7"];
        var modalidadPrograma = Json["data8"];
        var listaCargas = Json["data9"];

        $("select#cbEntidadMilitar").html("");
        $("select#cbEntidadMilitare").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadMilitar").append(RowContent);
            $("select#cbEntidadMilitare").append(RowContent);
        });

        $("select#cbGradoPersonalM").html("");
        $("select#cbGradoPersonalMe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalM").append(RowContent);
            $("select#cbGradoPersonalMe").append(RowContent);
        });

        $("select#cbEspecialidadGP").html("");
        $("select#cbEspecialidadGPe").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGP").append(RowContent);
            $("select#cbEspecialidadGPe").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbZonaNaval").html("");
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
            $("select#cbZonaNavale").append(RowContent);
        });

        $("select#cbProgramaEspecializacionG").html("");
        $("select#cbProgramaEspecializacionGe").html("");
        $.each(programaEspecializacionGrupo, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionGrupo + '>' + this.descProgramaEspecializacionGrupo + '</option>'
            $("select#cbProgramaEspecializacionG").append(RowContent);
            $("select#cbProgramaEspecializacionGe").append(RowContent);
        });

        $("select#cbProgramaEspecializacionE").html("");
        $("select#cbProgramaEspecializacionEe").html("");
        $.each(programaEspecializacionEspecifico, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionEspecifico + '>' + this.descProgramaEspecializacionEspecifico + '</option>'
            $("select#cbProgramaEspecializacionE").append(RowContent);
            $("select#cbProgramaEspecializacionEe").append(RowContent);
        });

        $("select#cbModalidadPrograma").html("");
        $("select#cbModalidadProgramae").html("");
        $.each(modalidadPrograma, function () {
            var RowContent = '<option value=' + this.codigoModalidadPrograma + '>' + this.descModalidadPrograma + '</option>'
            $("select#cbModalidadPrograma").append(RowContent);
            $("select#cbModalidadProgramae").append(RowContent);
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
    if (id == 1) {
        reporteSeleccionado = '/DirespromPrograma2daEspecializacionS/ReporteDPES?idCarga=';
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
