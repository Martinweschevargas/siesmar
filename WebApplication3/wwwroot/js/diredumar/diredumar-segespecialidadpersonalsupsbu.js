var tblDiredumarSegEspecialidadPersonalSupSub;
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
                                url: '/DiredumarSegEspecialidadPersonalSupSub/Insertar',
                                data: {
                                    'CIPSegEspecialidad': $('#txtCIP').val(),
                                    'DNISegEspecialidad': $('#txtDNI').val(),
                                    'NombreSegEspecialidad': $('#txtNombre').val(),
                                    'FechaNacimientoSegEspecialidad': $('#txtFechaN').val(),
                                    'SexoSegEspecialidad': $('#txtSexo').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoTipoPersonalMilitar': $('#txtTipoPersonal').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalM').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericaP').val(),
                                    'TipoProgramaCapSegEspecialidad': $('#txtTipoProgramaC').val(),
                                    'NumericoPais': $('#cbPaisU').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadaMilitar').val(),
                                    'CodigoCodigoEscuela': $('#cbCodigoEscuela').val(),
                                    'MencionCursoSegEspecialidad': $('#txtMencionCurso').val(),
                                    'FinanciamientoSegEspecialidad': $('#txtFinanciamiento').val(),
                                    'FechaInicioSegEspecialidad': $('#txtFechaIinicio').val(),
                                    'FechaTerminoSegEspecialidad': $('#txtFechaTermino').val(),
                                    'FechaRegistroSegEspecialidad': $('#txtFechaRegistro').val(),
                                    'HorasCapacitacionSegEspecialidad': $('#txtHoraCapacitacion').val(),
                                    'CalificacionSegEspecialidad': $('#txtCalificacion').val(),
                                    'CodigoMotivoTerminoCurso': $('#cbMotivoTerminoC').val(),
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
                                    $('#tblDiredumarSegEspecialidadPersonalSupSub').DataTable().ajax.reload();
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
                                url: '/DiredumarSegEspecialidadPersonalSupSub/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CIPSegEspecialidad': $('#txtCIPe').val(),
                                    'DNISegEspecialidad': $('#txtDNIe').val(),
                                    'NombreSegEspecialidad': $('#txtNombree').val(),
                                    'FechaNacimientoSegEspecialidad': $('#txtFechaNe').val(),
                                    'SexoSegEspecialidad': $('#txtSexoe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoTipoPersonalMilitar': $('#txtTipoPersonale').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMe').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericaPe').val(),
                                    'TipoProgramaCapSegEspecialidad': $('#txtTipoProgramaCe').val(),
                                    'NumericoPais': $('#cbPaisUe').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadaMilitare').val(),
                                    'CodigoCodigoEscuela': $('#cbCodigoEscuelae').val(),
                                    'MencionCursoSegEspecialidad': $('#txtMencionCursoe').val(),
                                    'FinanciamientoSegEspecialidad': $('#txtFinanciamientoe').val(),
                                    'FechaInicioSegEspecialidad': $('#txtFechaIinicioe').val(),
                                    'FechaTerminoSegEspecialidad': $('#txtFechaTerminoe').val(),
                                    'FechaRegistroSegEspecialidad': $('#txtFechaRegistroe').val(),
                                    'HorasCapacitacionSegEspecialidad': $('#txtHoraCapacitacione').val(),
                                    'CalificacionSegEspecialidad': $('#txtCalificacione').val(),
                                    'CodigoMotivoTerminoCurso': $('#cbMotivoTerminoCe').val(),
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
                                    $('#tblDiredumarSegEspecialidadPersonalSupSub').DataTable().ajax.reload();
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

    tblDiredumarSegEspecialidadPersonalSupSub = $('#tblDiredumarSegEspecialidadPersonalSupSub').DataTable({
        ajax: {
            "url": '/DiredumarSegEspecialidadPersonalSupSub/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "segEspecialidadPersonalSupSubId" },
            { "data": "cipSegEspecialidad" },
            { "data": "dniSegEspecialidad" },
            { "data": "nombreSegEspecialidad" },
            { "data": "fechaNacimientoSegEspecialidad" },
            { "data": "sexoSegEspecialidad" },
            { "data": "descDependencia" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "tipoProgramaCapSegEspecialidad" },
            { "data": "nombrePais" },
            { "data": "descEntidadMilitar" },
            { "data": "descCodigoEscuela" },
            { "data": "mencionCursoSegEspecialidad" },
            { "data": "financiamientoSegEspecialidad" },
            { "data": "fechaInicioSegEspecialidad" },
            { "data": "fechaTerminoSegEspecialidad" },
            { "data": "fechaRegistroSegEspecialidad" },
            { "data": "horasCapacitacionSegEspecialidad" },
            { "data": "calificacionSegEspecialidad" },
            { "data": "descMotivoTerminoCurso" },
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.segEspecialidadPersonalSupSubId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.segEspecialidadPersonalSupSubId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diredumar - Segunda Especialidad Profesional y Técnica del Personal Superior y Subalterno Matriculado ',
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
                filename: 'Diredumar - Segunda Especialidad Profesional y Técnica del Personal Superior y Subalterno Matriculado ',
                title: 'Diredumar - Segunda Especialidad Profesional y Técnica del Personal Superior y Subalterno Matriculado ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diredumar - Segunda Especialidad Profesional y Técnica del Personal Superior y Subalterno Matriculado ',
                title: 'Diredumar - Segunda Especialidad Profesional y Técnica del Personal Superior y Subalterno Matriculado ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diredumar - Segunda Especialidad Profesional y Técnica del Personal Superior y Subalterno Matriculado ',
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
    tblDiredumarSegEspecialidadPersonalSupSub.columns(22).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiredumarSegEspecialidadPersonalSupSub.columns(22).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiredumarSegEspecialidadPersonalSupSub/Mostrar?Id=' + Id, [], function (SegEspecialidadPersonalSupSubDTO) {
        $('#txtCodigo').val(SegEspecialidadPersonalSupSubDTO.segEspecialidadPersonalSupSubId);
        $('#txtCIPe').val(SegEspecialidadPersonalSupSubDTO.cipSegEspecialidad);
        $('#txtDNIe').val(SegEspecialidadPersonalSupSubDTO.dniSegEspecialidad);
        $('#txtNombree').val(SegEspecialidadPersonalSupSubDTO.nombreSegEspecialidad);
        $('#txtFechaNe').val(SegEspecialidadPersonalSupSubDTO.fechaNacimientoSegEspecialidad);
        $('#txtSexoe').val(SegEspecialidadPersonalSupSubDTO.sexoSegEspecialidad);
        $('#cbDependenciae').val(SegEspecialidadPersonalSupSubDTO.codigoDependencia);
        $('#txtTipoPersonale').val(SegEspecialidadPersonalSupSubDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMe').val(SegEspecialidadPersonalSupSubDTO.codigoGradoPersonalMilitar);
        $('#cbEspecialidadGenericaPe').val(SegEspecialidadPersonalSupSubDTO.codigoEspecialidadGenericaPersonal);
        $('#txtTipoProgramaCe').val(SegEspecialidadPersonalSupSubDTO.tipoProgramaCapSegEspecialidad);
        $('#cbPaisUe').val(SegEspecialidadPersonalSupSubDTO.numericoPais);
        $('#cbEntidadaMilitare').val(SegEspecialidadPersonalSupSubDTO.codigoEntidadMilitar);
        $('#cbCodigoEscuelae').val(SegEspecialidadPersonalSupSubDTO.codigoEscuela);
        $('#txtMencionCursoe').val(SegEspecialidadPersonalSupSubDTO.mencionCursoSegEspecialidad);
        $('#txtFinanciamientoe').val(SegEspecialidadPersonalSupSubDTO.financiamientoSegEspecialidad);
        $('#txtFechaIinicioe').val(SegEspecialidadPersonalSupSubDTO.fechaInicioSegEspecialidad);
        $('#txtFechaTerminoe').val(SegEspecialidadPersonalSupSubDTO.fechaTerminoSegEspecialidad);
        $('#txtFechaRegistroe').val(SegEspecialidadPersonalSupSubDTO.fechaRegistroSegEspecialidad);
        $('#txtHoraCapacitacione').val(SegEspecialidadPersonalSupSubDTO.horasCapacitacionSegEspecialidad);
        $('#txtCalificacione').val(SegEspecialidadPersonalSupSubDTO.calificacionSegEspecialidad);
        $('#cbMotivoTerminoCe').val(SegEspecialidadPersonalSupSubDTO.codigoMotivoTerminoCurso);
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
                url: '/DiredumarSegEspecialidadPersonalSupSub/Eliminar',
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
                    $('#tblDiredumarSegEspecialidadPersonalSupSub').DataTable().ajax.reload();
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
                url: '/DiredumarSegEspecialidadPersonalSupSub/EliminarCarga',
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
                    $('#tblDiredumarSegEspecialidadPersonalSupSub').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiredumarSegEspecialidadPersonalSupSub() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiredumarSegEspecialidadPersonalSupSub/MostrarDatos',
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
                            $("<td>").text(item.cipSegEspecialidad),
                            $("<td>").text(item.dniSegEspecialidad),
                            $("<td>").text(item.nombreSegEspecialidad),
                            $("<td>").text(item.fechaNacimientoSegEspecialidad),
                            $("<td>").text(item.sexoSegEspecialidad),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.tipoProgramaCapSegEspecialidad),
                            $("<td>").text(item.numericoPais),
                            $("<td>").text(item.codigoEntidadMilitar),
                            $("<td>").text(item.codigoEscuela),
                            $("<td>").text(item.mencionCursoSegEspecialidad),
                            $("<td>").text(item.financiamientoSegEspecialidad),
                            $("<td>").text(item.fechaInicioSegEspecialidad),
                            $("<td>").text(item.fechaTerminoSegEspecialidad),
                            $("<td>").text(item.fechaRegistroSegEspecialidad),
                            $("<td>").text(item.horasCapacitacionSegEspecialidad),
                            $("<td>").text(item.calificacionSegEspecialidad),
                            $("<td>").text(item.codigoMotivoTerminoCurso)
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
    fetch("DiredumarSegEspecialidadPersonalSupSub/EnviarDatos", {
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
    $.getJSON('/DiredumarSegEspecialidadPersonalSupSub/cargaCombs', [], function (Json) {
        var dependencia = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var especialidadGenericaPersonal = Json["data3"];
        var paisUbigeo = Json["data4"];
        var entidadMilitar = Json["data5"];
        var codigoEscuela = Json["data6"];
        var motivoTerminoCurso = Json["data7"];
        var tipoPersonalMilitar = Json["data8"];
        var listaCargas = Json["data9"];

        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbGradoPersonalM").html("");
        $("select#cbGradoPersonalMe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalM").append(RowContent);
            $("select#cbGradoPersonalMe").append(RowContent);
        });

        $("select#cbEspecialidadGenericaP").html("");
        $("select#cbEspecialidadGenericaPe").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaP").append(RowContent);
            $("select#cbEspecialidadGenericaPe").append(RowContent);
        });

        $("select#cbPaisU").html("");
        $("select#cbPaisUe").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numerico + '>' + this.nombrePais + '</option>'
            $("select#cbPaisU").append(RowContent);
            $("select#cbPaisUe").append(RowContent);
        });

        $("select#cbEntidadaMilitar").html("");
        $("select#cbEntidadaMilitare").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadaMilitar").append(RowContent);
            $("select#cbEntidadaMilitare").append(RowContent);
        });

        $("select#cbCodigoEscuela").html("");
        $("select#cbCodigoEscuelae").html("");
        $.each(codigoEscuela, function () {
            var RowContent = '<option value=' + this.codigoCodigoEscuela + '>' + this.descCodigoEscuela + '</option>'
            $("select#cbCodigoEscuela").append(RowContent);
            $("select#cbCodigoEscuelae").append(RowContent);
        });

        $("select#cbMotivoTerminoC").html("");
        $("select#cbMotivoTerminoCe").html("");
        $.each(motivoTerminoCurso, function () {
            var RowContent = '<option value=' + this.codigoMotivoTerminoCurso + '>' + this.descMotivoTerminoCurso + '</option>'
            $("select#cbMotivoTerminoC").append(RowContent);
            $("select#cbMotivoTerminoCe").append(RowContent);
        });

        $("select#txtTipoPersonal").html("");
        $("select#txtTipoPersonale").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#txtTipoPersonal").append(RowContent);
            $("select#txtTipoPersonale").append(RowContent);
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

    reporteSeleccionado = '/DiredumarSegEspecialidadPersonalSupSub/ReporteARTR';
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
