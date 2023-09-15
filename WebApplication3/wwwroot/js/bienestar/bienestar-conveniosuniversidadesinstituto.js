var tblBienestarConvenioUniversidadInstituto;
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
                                url: '/BienestarConvenioUniversidadInstituto/Insertar',
                                data: {
                                    'FechaSolicitudConvenio': $('#txtFechaSolicitud').val(),
                                    'DNISolicitante': $('#txtDNISolicitante').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitante').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitante').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiado').val(),
                                    'NivelEstudioConvenio': $('#txtNivelEstudioConvenio option:selected').val(),
                                    'TipoEntidadAcademica': $('#txtTipoEntidadAcademica option:selected').val(),
                                    'CodigoInstitucionEducativaSuperior': $('#cbInstitucionEducativaS').val(),
                                    'ResultadoSolicitud': $('#txtResultadoSolicitud option:selected').val(),
                                    'FechaResultadoSolicitud': $('#txtFechaResultadoS').val(), 
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
                                    $('#tblBienestarConvenioUniversidadInstituto').DataTable().ajax.reload();
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
                                url: '/BienestarConvenioUniversidadInstituto/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaSolicitudConvenio': $('#txtFechaSolicitude').val(),
                                    'DNISolicitante': $('#txtDNISolicitantee').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitantee').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitantee').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiadoe').val(),
                                    'NivelEstudioConvenio': $('#txtNivelEstudioConvenioe option:selected').val(),
                                    'TipoEntidadAcademica': $('#txtTipoEntidadAcademicae option:selected').val(),
                                    'CodigoInstitucionEducativaSuperior': $('#cbInstitucionEducativaSe').val(),
                                    'ResultadoSolicitud': $('#txtResultadoSolicitude option:selected').val(),
                                    'FechaResultadoSolicitud': $('#txtFechaResultadoSe').val(), 
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
                                    $('#tblBienestarConvenioUniversidadInstituto').DataTable().ajax.reload();
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

  
    tblBienestarConvenioUniversidadInstituto=  $('#tblBienestarConvenioUniversidadInstituto').DataTable({
        ajax: {
            "url": '/BienestarConvenioUniversidadInstituto/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "convenioUniversidadInstitutoId" },
            { "data": "fechaSolicitudConvenio" },
            { "data": "dniSolicitante" },
            { "data": "descPersonalSolicitante" },
            { "data": "descCondicionSolicitante" },
            { "data": "descGrado" },
            { "data": "descPersonalBeneficiado" },
            { "data": "nivelEstudioConvenio" },
            { "data": "tipoEntidadAcademica" },
            { "data": "descInstitucionEducativaSuperior" },
            { "data": "resultadoSolicitud" },
            { "data": "fechaResultadoSolicitud" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.convenioUniversidadInstitutoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.convenioUniversidadInstitutoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Convenios con Universidades e Institutos',
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
                filename: 'Bienestar - Convenios con Universidades e Institutos',
                title: 'Bienestar - Convenios con Universidades e Institutos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Convenios con Universidades e Institutos',
                title: 'Bienestar - Convenios con Universidades e Institutos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Convenios con Universidades e Institutos',
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
    tblBienestarConvenioUniversidadInstituto.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarConvenioUniversidadInstituto.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarConvenioUniversidadInstituto/Mostrar?Id=' + Id, [], function (ConveniosUniversidadesInstitutosDTO) {
        $('#txtCodigo').val(ConveniosUniversidadesInstitutosDTO.convenioUniversidadInstitutoId);
        $('#txtFechaSolicitude').val(ConveniosUniversidadesInstitutosDTO.fechaSolicitudConvenio);
        $('#txtDNISolicitantee').val(ConveniosUniversidadesInstitutosDTO.dniSolicitante);
        $('#cbPersonalSolicitantee').val(ConveniosUniversidadesInstitutosDTO.codigoPersonalSolicitante);
        $('#cbCondicionSolicitantee').val(ConveniosUniversidadesInstitutosDTO.codigoCondicionSolicitante);
        $('#cbGradoPersonalMilitare').val(ConveniosUniversidadesInstitutosDTO.codigoGradoPersonalMilitar);
        $('#cbPersonalBeneficiadoe').val(ConveniosUniversidadesInstitutosDTO.codigoPersonalBeneficiado);
        $('#txtNivelEstudioConvenioe').val(ConveniosUniversidadesInstitutosDTO.nivelEstudioConvenio);
        $('#txtTipoEntidadAcademicae').val(ConveniosUniversidadesInstitutosDTO.tipoEntidadAcademica);
        $('#cbInstitucionEducativaSe').val(ConveniosUniversidadesInstitutosDTO.codigoInstitucionEducativaSuperior);
        $('#txtResultadoSolicitude').val(ConveniosUniversidadesInstitutosDTO.resultadoSolicitud);
        $('#txtFechaResultadoSe').val(ConveniosUniversidadesInstitutosDTO.fechaResultadoSolicitud); 
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
                url: '/BienestarConvenioUniversidadInstituto/Eliminar',
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
                    $('#tblBienestarConvenioUniversidadInstituto').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarConvenioUniversidadInstituto() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarConvenioUniversidadInstituto/MostrarDatos',
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
                            $("<td>").text(item.fechaSolicitudConvenio),
                            $("<td>").text(item.dniSolicitante),
                            $("<td>").text(item.codigoPersonalSolicitante),
                            $("<td>").text(item.codigoCondicionSolicitante),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoPersonalBeneficiado),
                            $("<td>").text(item.nivelEstudioConvenio),
                            $("<td>").text(item.tipoEntidadAcademica),
                            $("<td>").text(item.codigoInstitucionEducativaSuperior),
                            $("<td>").text(item.resultadoSolicitud),
                            $("<td>").text(item.fechaResultadoSolicitud)
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
    formData.append("mes", $('select#cbMes').val())
    formData.append("anio", $('select#cbAnio').val())
    fetch("BienestarConvenioUniversidadInstituto/EnviarDatos", {
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
                url: '/BienestarConvenioUniversidadInstituto/EliminarCarga',
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
                    $('#tblBienestarConvenioUniversidadInstituto').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarConvenioUniversidadInstituto/cargaCombs', [], function (Json) {
        var personalSolicitante = Json["data1"];
        var condicionSolicitante = Json["data2"];
        var gradoPersonalMilitarDTO = Json["data3"];
        var personalBeneficiado = Json["data4"];
        var institucionEducativaSuperior = Json["data5"];
        var listaCargas = Json["data6"];
        var listaMes = Json["mes"];
        var listaAnio = Json["anio"];

        $("select#cbMes").html("");
        $.each(listaMes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });

        $("select#cbAnio").html("");
        $.each(listaAnio, function () {
            var RowContent = '<option value=' + this.codigoAnio + '>' + this.descAnio + '</option>'
            $("select#cbAnio").append(RowContent);
        });

        $("select#cbPersonalSolicitante").html("");
        $.each(personalSolicitante, function () {
            var RowContent = '<option value=' + this.codigoPersonalSolicitante + '>' + this.descPersonalSolicitante + '</option>'
            $("select#cbPersonalSolicitante").append(RowContent);
        });
        $("select#cbPersonalSolicitantee").html("");
        $.each(personalSolicitante, function () {
            var RowContent = '<option value=' + this.codigoPersonalSolicitante + '>' + this.descPersonalSolicitante + '</option>'
            $("select#cbPersonalSolicitantee").append(RowContent);
        });


        $("select#cbCondicionSolicitante").html("");
        $.each(condicionSolicitante, function () {
            var RowContent = '<option value=' + this.codigoCondicionSolicitante + '>' + this.descCondicionSolicitante + '</option>'
            $("select#cbCondicionSolicitante").append(RowContent);
        });
        $("select#cbCondicionSolicitantee").html("");
        $.each(condicionSolicitante, function () {
            var RowContent = '<option value=' + this.codigoCondicionSolicitante + '>' + this.descCondicionSolicitante + '</option>'
            $("select#cbCondicionSolicitantee").append(RowContent);
        });


        $("select#cbGradoPersonalMilitar").html("");
        $.each(gradoPersonalMilitarDTO, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.abreviatura + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
        });
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitarDTO, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.abreviatura + '</option>'
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });



        $("select#cbPersonalBeneficiado").html("");
        $.each(personalBeneficiado, function () {
            var RowContent = '<option value=' + this.codigoPersonalBeneficiado + '>' + this.descPersonalBeneficiado + '</option>'
            $("select#cbPersonalBeneficiado").append(RowContent);
        });
        $("select#cbPersonalBeneficiadoe").html("");
        $.each(personalBeneficiado, function () {
            var RowContent = '<option value=' + this.codigoPersonalBeneficiado + '>' + this.descPersonalBeneficiado + '</option>'
            $("select#cbPersonalBeneficiadoe").append(RowContent);
        });


        $("select#cbInstitucionEducativaS").html("");
        $.each(institucionEducativaSuperior, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativaSuperior + '>' + this.descInstitucionEducativaSuperior + '</option>'
            $("select#cbInstitucionEducativaS").append(RowContent);
        });
        $("select#cbInstitucionEducativaSe").html("");
        $.each(institucionEducativaSuperior, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativaSuperior + '>' + this.descInstitucionEducativaSuperior + '</option>'
            $("select#cbInstitucionEducativaSe").append(RowContent);
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
        reporteSeleccionado = '/BienestarConvenioUniversidadInstituto/ReporteBACE?idCarga=';
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