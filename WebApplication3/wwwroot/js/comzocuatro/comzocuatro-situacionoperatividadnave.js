var tblComzocuatroSituacionOperatividadNave;
var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

var reporteSeleccionado;
var optReporteSelect;

$('select#cbProvincia').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
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
                                url: '/ComzocuatroSituacionOperatividadNave/Insertar',
                                data: {
                                    'TipoNaveId': $('#cbNave').val(),
                                    'CascoNave': $('#txtCasco').val(),
                                    'CodigoTipoPlataformaNave': $('#cbPlataforma').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'CodigoDistritoUbigeo': $('#cbDistrito').val(),
                                    'CodigoCapacidadOperativaRequerida': $('#cbCapacidadOperativaRequerida').val(),
                                    'CondicionId': $('#cbCondicion').val(),
                                    'Observacion': $('#txtObservacion').val(),
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
                                    $('#tblComzocuatroSituacionOperatividadNave').DataTable().ajax.reload();
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
                                url: '/ComzocuatroSituacionOperatividadNave/Actualizar',
                                data: {

                                    'Id': $('#txtCodigo').val(),
                                    'TipoNaveId': $('#cbNavee').val(),
                                    'CascoNave': $('#txtCascoe').val(),
                                    'CodigoTipoPlataformaNave': $('#cbPlataformae').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'CodigoDepartamentoUbigeo': $('#cbDepartamentoe').val(),
                                    'CodigoProvinciaUbigeo': $('#cbProvinciae').val(),
                                    'CodigoDistritoUbigeo': $('#cbDistritoe').val(),
                                    'CodigoCapacidadOperativaRequerida': $('#cbCapacidadOperativaRequeridae').val(),
                                    'CondicionId': $('#cbCondicione').val(),
                                    'Observacion': $('#txtObservacione').val(), 
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
                                    $('#tblComzocuatroSituacionOperatividadNave').DataTable().ajax.reload();
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

    tblComzocuatroSituacionOperatividadNave = $('#tblComzocuatroSituacionOperatividadNave').DataTable({
        ajax: {
            "url": '/ComzocuatroSituacionOperatividadNave/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionOperativaNaveComzocuatroId" },
            { "data": "descTipoNave" },
            { "data": "cascoNave" },
            { "data": "descTipoPlataformaNave" },
            { "data": "descDependencia" },
            { "data": "ubicacion" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },  
            { "data": "descDistrito" },
            { "data": "capacidadOperativaNave" },
            { "data": "condicionNave" },
            { "data": "observacion" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionOperativaNaveComzocuatroId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionOperativaNaveComzocuatroId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzocuatro - Situacion de Operatividad de Naves',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comzocuatro - Situacion de Operatividad de Naves',
                title: 'Comzocuatro - Situacion de Operatividad de Naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzocuatro - Situacion de Operatividad de Naves',
                title: 'Comzocuatro - Situacion de Operatividad de Naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzocuatro - Situacion de Operatividad de Naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzocuatroSituacionOperatividadNave/Mostrar?Id=' + Id, [], function (SituacionOperatividadNaveComzocuatroDTO) {
        $('#txtCodigo').val(SituacionOperatividadNaveComzocuatroDTO.situacionOperativaNaveComzocuatroId);
        $('#cbNavee').val(SituacionOperatividadNaveComzocuatroDTO.tipoNaveId);
        $('#txtCascoe').val(SituacionOperatividadNaveComzocuatroDTO.cascoNave);
        $('#cbPlataformae').val(SituacionOperatividadNaveComzocuatroDTO.codigoTipoPlataformaNave);
        $('#cbDependenciae').val(SituacionOperatividadNaveComzocuatroDTO.codigoDependencia);
        $('#txtUbicacione').val(SituacionOperatividadNaveComzocuatroDTO.ubicacion);
        $('#cbDepartamentoe').val(SituacionOperatividadNaveComzocuatroDTO.codigoDepartamentoUbigeo);
        $('#cbProvinciae').val(SituacionOperatividadNaveComzocuatroDTO.codigoProvinciaUbigeo);
        $('#cbDistritoe').val(SituacionOperatividadNaveComzocuatroDTO.codigoDistritoUbigeo);
        $('#cbCapacidadOperativaRequeridae').val(SituacionOperatividadNaveComzocuatroDTO.capacidadOperativaNave);
        $('#cbCondicione').val(SituacionOperatividadNaveComzocuatroDTO.condicionNave);
        $('#txtObservacione').val(SituacionOperatividadNaveComzocuatroDTO.observacion); 
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
                url: '/ComzocuatroSituacionOperatividadNave/Eliminar',
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
                    $('#tblComzocuatroSituacionOperatividadNave').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComzocuatroSituacionOperatividadNave() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            console.log(dataJson);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.nombreTemaEstudioInvestigacion),
                        $("<td>").text(item.tipoEstudioInvestigacion),
                        $("<td>").text(item.fechaInicio),
                        $("<td>").text(item.fechaTermino),
                        $("<td>").text(item.responsable),
                        $("<td>").text(item.solicitante)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            alert(dataJson.mensaje);
        })
}


function cargaDatos() {
    $.getJSON('/ComzocuatroSituacionOperatividadNave/cargaCombs', [], function (Json) {
        var tipoNave = Json["data1"];
        var tipoPlataformaNave = Json["data2"];
        var dependencia = Json["data3"];
        departamentoUbigeo = Json["data4"];
        provinciaUbigeo = Json["data5"];
        distritoUbigeo = Json["data6"];
        var CapacidadOperativaRequerida = Json["data7"];
        var Condicion = Json["data8"];
        var listaCargas = Json["data9"];


        $("select#cbNave").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbNave").append(RowContent);
        });
        $("select#cbNavee").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbNavee").append(RowContent);
        });

        $("select#cbPlataforma").html("");
        $.each(tipoPlataformaNave, function () {
            var RowContent = '<option value=' + this.CodigoTipoPlataformaNave + '>' + this.descTipoPlataformaNave + '</option>'
            $("select#cbPlataforma").append(RowContent);
        });
        $("select#cbPlataformae").html("");
        $.each(tipoPlataformaNave, function () {
            var RowContent = '<option value=' + this.CodigoTipoPlataformaNave + '>' + this.descTipoPlataformaNave + '</option>'
            $("select#cbPlataformae").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.CodigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.CodigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbDepartamento").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamento").append(RowContent);
        });

        $("select#cbCapacidadOperativaRequerida").html("");
        $.each(CapacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.CodigoCapacidadOperativaRequerida + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequerida").append(RowContent);
        });
        $("select#cbCapacidadOperativaRequeridae").html("");
        $.each(CapacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.CodigoCapacidadOperativaRequerida + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequeridae").append(RowContent);
        });


        $("select#cbCondicion").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#cbCondicion").append(RowContent);
        });
        $("select#cbCondicione").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#cbCondicione").append(RowContent);
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


$('select#cbDepartamento').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvincia").html("");
            $('select#cbProvincia').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvincia").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistrito").html("");
    $('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvincia').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistrito").html("");
            $('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistrito").append(RowContent);
                }
            });
        }
    });
});



$('select#cbDepartamentoe').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciae").html("");
            $('select#cbProvinciae').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciae").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoe").html("");
    $('select#cbDistritoe').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciae').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoe").html("");
            $('select#cbDistritoe').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoe").append(RowContent);
                }
            });
        }
    });
});



function encontrardatocombo(id) {
    var iddistrito = id;

    $.each(distritoUbigeo, function () {
        if (this.distritoUbigeo == iddistrito) {
            var provincia = this.provinciaUbigeo;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoe").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoe").append(RowContent);

                    });
                    $('#cbDepartamentoNacimientoe').val(departamento);
                    $("select#cbProvinciae").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciae").append(RowContent);
                        }
                    });
                    $('#cbProvinciaNacimientoe').val(provincia);
                    $("select#cbDistritoe").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoNacimientoe").append(RowContent);
                        }
                    });
                    $('#cbDistritoe').val(iddistrito);
                }
            });


        }
    });
}

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCA';
        $('#accionAnteCiberataque').hide();
        $('#tipoCiberataque').hide();
        $('#fechaInicio').hide();
        $('#fechaTermino').hide();
    }
    if (id == 2) {
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCXSSA';
        $('#accionAnteCiberataque').show();
        $('#tipoCiberataque').hide();
        $('#fechaInicio').show();
        $('#fechaTermino').show();
    }
    if (id == 3) {
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCATCA';
        $('#tipoCiberataque').show();
        $('#accionAnteCiberataque').hide();
        $('#fechaInicio').show();
        $('#fechaTermino').show();
    }
}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var numCarga;
    if (idCarga == "0") {
        numCarga = "";
    } else {
        numCarga = 'CargaId=' + idCarga;
    }
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect == 1) {
        a.href = reporteSeleccionado + '?' + numCarga;
    }
    if (optReporteSelect == 2) {
        a.href = reporteSeleccionado + '?accionAnteCiberataque=' + $('#txtAccionAnteCiberA').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
    }
    if (optReporteSelect == 3) {
        a.href = reporteSeleccionado + '?tipoCiberataque=' + $('#txtCiberAtaque').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
    }
    a.click();
});