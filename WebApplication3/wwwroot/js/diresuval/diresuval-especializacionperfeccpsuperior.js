var tblDiresuvalEspecializacionPerfeccPSuperior;
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
                                url: '/DiresuvalEspecializacionPerfeccPSuperior/Insertar',
                                data: {
                                    'DNIPersonalSuperior': $('#txtDNIPersonalSuperior').val(),
                                    'EdadAnios': $('#txtEdadAnios').val(),
                                    'Sexo': $('#txtSexo').val(),
                                    'Condicion': $('#txtCondicion').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericaPersonal').val(),
                                    'Procedencia': $('#txtProcedencia').val(),
                                    'AnioPromocion': $('#txtAnioPromocion').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'CodigoProgramaEspecializacionGrupo': $('#cbProgramaEspecializacionGrupo').val(),
                                    'CodigoProgramaEspecializacionEspecifico': $('#cbProgramaEspecializacionEspecificacion').val(),
                                    'FechaInicio': $('#txtFechaInicio').val(),
                                    'FechaTermino': $('#txtFechaTermino').val(),
                                    'FechaRegistro': $('#txtFechaRegistro').val(),
                                    'ModalidadEspecializacion': $('#txtModalidadEspecializacion').val(),
                                    'ConcluyoPrograma': $('#txtConcluyoPrograma').val(),
                                    'MotivoNoConcluir': $('#txtMotivoNoConcluir').val(),
                                    'CalificacionObtenida': $('#txtCalificacionObtenida').val(),
                                    'CertificacionObtenido': $('#txtCertificacionObtenido').val(), 
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
                                    $('#tblDiresuvalEspecializacionPerfeccPSuperior').DataTable().ajax.reload();
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
                                url: '/DiresuvalEspecializacionPerfeccPSuperior/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPersonalSuperior': $('#txtDNIPersonalSuperiore').val(),
                                    'EdadAnios': $('#txtEdadAniose').val(),
                                    'Sexo': $('#txtSexoe').val(),
                                    'Condicion': $('#txtCondicione').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericaPersonale').val(),
                                    'Procedencia': $('#txtProcedenciae').val(),
                                    'AnioPromocion': $('#txtAnioPromocione').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'CodigoProgramaEspecializacionGrupo': $('#cbProgramaEspecializacionGrupoe').val(),
                                    'CodigoProgramaEspecializacionEspecifico': $('#cbProgramaEspecializacionEspecificacione').val(),
                                    'FechaInicio': $('#txtFechaInicioe').val(),
                                    'FechaTermino': $('#txtFechaTerminoe').val(),
                                    'FechaRegistro': $('#txtFechaRegistroe').val(),
                                    'ModalidadEspecializacion': $('#txtModalidadEspecializacione').val(),
                                    'ConcluyoPrograma': $('#txtConcluyoProgramae').val(),
                                    'MotivoNoConcluir': $('#txtMotivoNoConcluire').val(),
                                    'CalificacionObtenida': $('#txtCalificacionObtenidae').val(),
                                    'CertificacionObtenido': $('#txtCertificacionObtenidoe').val(), 
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
                                    $('#tblDiresuvalEspecializacionPerfeccPSuperior').DataTable().ajax.reload();
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

  
        tblDiresuvalEspecializacionPerfeccPSuperior=  $('#tblDiresuvalEspecializacionPerfeccPSuperior').DataTable({
        ajax: {
            "url": '/DiresuvalEspecializacionPerfeccPSuperior/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "especializacionPerfeccionamientoId" },
            { "data": "dniPersonalSuperior" },
            { "data": "edadAnios" },
            { "data": "sexo" },
            { "data": "condicion" },
            { "data": "descEntidadMilitar" },
            { "data": "descGradoPersonalMilitar" },
            { "data": "descEspecialidad" },
            { "data": "procedencia" },
            { "data": "anioPromocion" },
            { "data": "descDependencia" },
            { "data": "descZonaNaval" },
            { "data": "descProgramaEspecializacionGrupo" },
            { "data": "descProgramaEspecializacionEspecifico" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "fechaRegistro" },
            { "data": "modalidadEspecializacion" },
            { "data": "concluyoPrograma" },
            { "data": "motivoNoConcluir" },
            { "data": "calificacionObtenida" },
            { "data": "certificacionObtenido" }, 
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.especializacionPerfeccionamientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.especializacionPerfeccionamientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresuval - Especialización y Perfeccionamiento del Personal Superior de la Marina',
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
                filename: 'Diresuval - Especialización y Perfeccionamiento del Personal Superior de la Marina',
                title: 'Diresuval - Especialización y Perfeccionamiento del Personal Superior de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresuval - Especialización y Perfeccionamiento del Personal Superior de la Marina',
                title: 'Diresuval - Especialización y Perfeccionamiento del Personal Superior de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresuval - Especialización y Perfeccionamiento del Personal Superior de la Marina',
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
    tblDiresuvalEspecializacionPerfeccPSuperior.columns(22).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiresuvalEspecializacionPerfeccPSuperior.columns(22).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiresuvalEspecializacionPerfeccPSuperior/Mostrar?Id=' + Id, [], function (EspecializacionPerfeccionamientoPSuperiorDTO) {
        $('#txtCodigo').val(EspecializacionPerfeccionamientoPSuperiorDTO.especializacionPerfeccionamientoId);
        $('#txtDNIPersonalSuperiore').val(EspecializacionPerfeccionamientoPSuperiorDTO.dniPersonalSuperior);
        $('#txtEdadAniose').val(EspecializacionPerfeccionamientoPSuperiorDTO.edadAnios);
        $('#txtSexoe').val(EspecializacionPerfeccionamientoPSuperiorDTO.sexo);
        $('#txtCondicione').val(EspecializacionPerfeccionamientoPSuperiorDTO.condicion);
        $('#cbEntidadMilitare').val(EspecializacionPerfeccionamientoPSuperiorDTO.codigoEntidadMilitar);
        $('#cbGradoPersonalMilitare').val(EspecializacionPerfeccionamientoPSuperiorDTO.codigoGradoPersonalMilitar);
        $('#cbEspecialidadGenericaPersonale').val(EspecializacionPerfeccionamientoPSuperiorDTO.codigoEspecialidadGenericaPersonal);
        $('#txtProcedenciae').val(EspecializacionPerfeccionamientoPSuperiorDTO.procedencia);
        $('#txtAnioPromocione').val(EspecializacionPerfeccionamientoPSuperiorDTO.anioPromocion);
        $('#cbDependenciae').val(EspecializacionPerfeccionamientoPSuperiorDTO.codigoDependencia);
        $('#cbZonaNavale').val(EspecializacionPerfeccionamientoPSuperiorDTO.codigoZonaNaval);
        $('#cbProgramaEspecializacionGrupoe').val(EspecializacionPerfeccionamientoPSuperiorDTO.codigoProgramaEspecializacionGrupo);
        $('#cbProgramaEspecializacionEspecificacione').val(EspecializacionPerfeccionamientoPSuperiorDTO.codigoProgramaEspecializacionEspecifico);
        $('#txtFechaInicioe').val(EspecializacionPerfeccionamientoPSuperiorDTO.fechaInicio);
        $('#txtFechaTerminoe').val(EspecializacionPerfeccionamientoPSuperiorDTO.fechaTermino);
        $('#txtFechaRegistroe').val(EspecializacionPerfeccionamientoPSuperiorDTO.fechaRegistro);
        $('#txtModalidadEspecializacione').val(EspecializacionPerfeccionamientoPSuperiorDTO.modalidadEspecializacion);
        $('#txtConcluyoProgramae').val(EspecializacionPerfeccionamientoPSuperiorDTO.concluyoPrograma);
        $('#txtMotivoNoConcluire').val(EspecializacionPerfeccionamientoPSuperiorDTO.motivoNoConcluir);
        $('#txtCalificacionObtenidae').val(EspecializacionPerfeccionamientoPSuperiorDTO.calificacionObtenida);
        $('#txtCertificacionObtenidoe').val(EspecializacionPerfeccionamientoPSuperiorDTO.certificacionObtenido); 
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
                url: '/DiresuvalEspecializacionPerfeccPSuperior/Eliminar',
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
                    $('#tblDiresuvalEspecializacionPerfeccPSuperior').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDiresuvalEspecializacionPerfeccPSuperior() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiresuvalEspecializacionPerfeccPSuperior/MostrarDatos',
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
                            $("<td>").text(item.edadAnios),
                            $("<td>").text(item.sexo),
                            $("<td>").text(item.condicion),
                            $("<td>").text(item.codigoEntidadMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.procedencia),
                            $("<td>").text(item.anioPromocion),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoProgramaEspecializacionGrupo),
                            $("<td>").text(item.codigoProgramaEspecializacionEspecifico),
                            $("<td>").text(item.fechaInicio),
                            $("<td>").text(item.fechaTermino),
                            $("<td>").text(item.fechaRegistro),
                            $("<td>").text(item.modalidadEspecializacion),
                            $("<td>").text(item.concluyoPrograma),
                            $("<td>").text(item.motivoNoConcluir),
                            $("<td>").text(item.calificacionObtenida),
                            $("<td>").text(item.certificacionObtenido),
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
    fetch("DiresuvalEspecializacionPerfeccPSuperior/EnviarDatos", {
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
                    'Ocurrio un problema.' +mensaje,
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
                url: '/DiresuvalEspecializacionPerfeccPSuperior/EliminarCarga',
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
                    $('#tblDiresuvalEspecializacionPerfeccPSuperior').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DiresuvalEspecializacionPerfeccPSuperior/cargaCombs', [], function (Json) {
        var EntidadMilitar = Json["data1"];
        var GradoPersonalMilitar = Json["data2"];
        var EspecialidadGenericaPersonal = Json["data3"];
        var Dependencia = Json["data4"];
        var ZonaNaval = Json["data5"];
        var ProgramaEspecializacionGrupo = Json["data6"];
        var ProgramaEspecializacionEspecificacion = Json["data7"];
        var listaCargas = Json["data8"];

        $("select#cbEntidadMilitar").html("");
        $.each(EntidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadMilitar").append(RowContent);
        });
        $("select#cbEntidadMilitare").html("");
        $.each(EntidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadMilitare").append(RowContent);
        });


        $("select#cbGradoPersonalMilitar").html("");
        $.each(GradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
        });
        $("select#cbGradoPersonalMilitare").html("");
        $.each(GradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });


        $("select#cbEspecialidadGenericaPersonal").html("");
        $.each(EspecialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonal").append(RowContent);
        });
        $("select#cbEspecialidadGenericaPersonale").html("");
        $.each(EspecialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonale").append(RowContent);
        });


        $("select#cbDependencia").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbZonaNaval").html("");
        $.each(ZonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(ZonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
        });


        $("select#cbProgramaEspecializacionGrupo").html("");
        $.each(ProgramaEspecializacionGrupo, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionGrupo + '>' + this.descProgramaEspecializacionGrupo + '</option>'
            $("select#cbProgramaEspecializacionGrupo").append(RowContent);
        });
        $("select#cbProgramaEspecializacionGrupoe").html("");
        $.each(ProgramaEspecializacionGrupo, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionGrupo + '>' + this.descProgramaEspecializacionGrupo + '</option>'
            $("select#cbProgramaEspecializacionGrupoe").append(RowContent);
        });


        $("select#cbProgramaEspecializacionEspecificacion").html("");
        $.each(ProgramaEspecializacionEspecificacion, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionEspecifico + '>' + this.descProgramaEspecializacionEspecifico + '</option>'
            $("select#cbProgramaEspecializacionEspecificacion").append(RowContent);
        });
        $("select#cbProgramaEspecializacionEspecificacione").html("");
        $.each(ProgramaEspecializacionEspecificacion, function () {
            var RowContent = '<option value=' + this.codigoProgramaEspecializacionEspecifico + '>' + this.descProgramaEspecializacionEspecifico + '</option>'
            $("select#cbProgramaEspecializacionEspecificacione").append(RowContent);
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
        reporteSeleccionado = '/DiresuvalEspecializacionPerfeccPSuperior/ReporteDEPPS?idCarga=';
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