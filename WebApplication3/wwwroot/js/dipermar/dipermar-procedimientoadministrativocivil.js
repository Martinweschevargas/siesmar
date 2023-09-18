var tblDipermarProcedimientoAdministrativoCivil;
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
                                url: '/DipermarProcedimientoAdministrativoCivil/Insertar',
                                data: {
                                    'NroDocumentoProcedimientoAdm': $('#txtNumeroDocumento').val(),
                                    'FechaDocumento': $('#txtFechaD').val(),
                                    'CodigoCondicionLaboralCivil': $('#txtCondicionLaboral').val(),
                                    'CodigoGrupoOcupacionalCivil': $('#cbGrupoOcupacional').val(),
                                    'CodigoCargo': $('#txtCargoDesem').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoInfraccionDisciplinariaCivil': $('#cbInfracionD').val(),
                                    'SolicitanteSancion': $('#txtSolicitanteS').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonal').val(),
                                    'CodigoCargoSolicitante': $('#txtCargoDesempenioS').val(),
                                    'CodigoGradoPersonalMilitarSansion': $('#txtGradoImponeS').val(),
                                    'CodigoCargoImponeSancion': $('#txtCargoImponesancion').val(),
                                    'CodigoSancionDisciplinariaCivil': $('#cbSancionDisc').val(),
                                    'InicioSancion': $('#txtInicioS').val(),
                                    'TerminoSancion': $('#txtTerminoS').val(),
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
                                    $('#tblDipermarProcedimientoAdministrativoCivil').DataTable().ajax.reload();
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
                                url: '/DipermarProcedimientoAdministrativoCivil/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NroDocumentoProcedimientoAdm': $('#txtNumeroDocumentoe').val(),
                                    'FechaDocumento': $('#txtFechaDe').val(),
                                    'CodigoCondicionLaboralCivil': $('#txtCondicionLaborale').val(),
                                    'CodigoGrupoOcupacionalCivil': $('#cbGrupoOcupacionale').val(),
                                    'CodigoCargo': $('#txtCargoDeseme').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoInfraccionDisciplinariaCivil': $('#cbInfracionDe').val(),
                                    'SolicitanteSancion': $('#txtSolicitanteSe').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonale').val(),
                                    'CodigoCargoSolicitante': $('#txtCargoDesempenioSe').val(),
                                    'CodigoGradoPersonalMilitarSansion': $('#txtGradoImponeSe').val(),
                                    'CodigoCargoImponeSancion': $('#txtCargoImponesancione').val(),
                                    'CodigoSancionDisciplinariaCivil': $('#cbSancionDisce').val(),
                                    'InicioSancion': $('#txtInicioSe').val(),
                                    'TerminoSancion': $('#txtTerminoSe').val()
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
                                    $('#tblDipermarProcedimientoAdministrativoCivil').DataTable().ajax.reload();
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

    tblDipermarProcedimientoAdministrativoCivil = $('#tblDipermarProcedimientoAdministrativoCivil').DataTable({
        ajax: {
            "url": '/DipermarProcedimientoAdministrativoCivil/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "procedimientoAdministrativoCivilId" },
            { "data": "nroDocumentoProcedimientoAdm" },
            { "data": "fechaDocumento" },
            { "data": "descCondicionLaboralCivil" },
            { "data": "descGrupoOcupacionalCivil" },
            { "data": "descCargo" },
            { "data": "nombreDependencia" },
            { "data": "descInfraccionDisciplinariaCivil" },
            { "data": "solicitanteSancion" },
            { "data": "descGrado" },
            { "data": "descCargoSolicitante" },
            { "data": "descGradoPersonalMilitarSansion" },
            { "data": "descCargoImponeSancion" },
            { "data": "descSancionDisciplinariaCivil" },
            { "data": "inicioSancion" },
            { "data": "terminoSancion" },
            { "data": "cargaId" },


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.procedimientoAdministrativoCivilId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.procedimientoAdministrativoCivilId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dipermar - Procedimiento Administrativo Disciplinario del Personal Civil',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11, 12, 13, 14, 15]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dipermar - Procedimiento Administrativo Disciplinario del Personal Civil',
                title: 'Dipermar - Procedimiento Administrativo Disciplinario del Personal Civil',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dipermar - Procedimiento Administrativo Disciplinario del Personal Civil',
                title: 'Dipermar - Procedimiento Administrativo Disciplinario del Personal Civil',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dipermar - Procedimiento Administrativo Disciplinario del Personal Civil',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
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
    tblDipermarProcedimientoAdministrativoCivil.columns(16).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDipermarProcedimientoAdministrativoCivil.columns(16).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DipermarProcedimientoAdministrativoCivil/Mostrar?Id=' + Id, [], function (ProcedimientoAdministrativoCivilDTO) {
        $('#txtCodigo').val(ProcedimientoAdministrativoCivilDTO.procedimientoAdministrativoCivilId);
        $('#txtNumeroDocumentoe').val(ProcedimientoAdministrativoCivilDTO.nroDocumentoProcedimientoAdm);
        $('#txtFechaDe').val(ProcedimientoAdministrativoCivilDTO.fechaDocumento);
        $('#txtCondicionLaborale').val(ProcedimientoAdministrativoCivilDTO.codigoCondicionLaboralCivil);
        $('#cbGrupoOcupacionale').val(ProcedimientoAdministrativoCivilDTO.codigoGrupoOcupacionalCivil);
        $('#txtCargoDeseme').val(ProcedimientoAdministrativoCivilDTO.codigoCargo);
        $('#cbDependenciae').val(ProcedimientoAdministrativoCivilDTO.codigoDependencia);
        $('#cbInfracionDe').val(ProcedimientoAdministrativoCivilDTO.codigoInfraccionDisciplinariaCivil);
        $('#txtSolicitanteSe').val(ProcedimientoAdministrativoCivilDTO.solicitanteSancion);
        $('#cbGradoPersonale').val(ProcedimientoAdministrativoCivilDTO.codigoGradoPersonalMilitar);
        $('#txtCargoDe').val(ProcedimientoAdministrativoCivilDTO.codigoCargoSolicitante);
        $('#txtGradoImponeSe').val(ProcedimientoAdministrativoCivilDTO.codigoGradoPersonalMilitarSansion);
        $('#txtCargoImponesancione').val(ProcedimientoAdministrativoCivilDTO.codigoCargoImponeSancion);
        $('#cbSancionDisce').val(ProcedimientoAdministrativoCivilDTO.codigoSancionDisciplinariaCivil);
        $('#txtInicioSe').val(ProcedimientoAdministrativoCivilDTO.inicioSancion);
        $('#txtTerminoSe').val(ProcedimientoAdministrativoCivilDTO.terminoSancion);
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
                url: '/DipermarProcedimientoAdministrativoCivil/Eliminar',
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
                    $('#tblDipermarProcedimientoAdministrativoCivil').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDipermarProcedimientoAdministrativoCivil() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DipermarProcedimientoAdministrativoCivil/MostrarDatos',
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
                            $("<td>").text(item.nroDocumentoProcedimientoAdm),
                            $("<td>").text(item.fechaDocumento),
                            $("<td>").text(item.codigoCondicionLaboralCivil),
                            $("<td>").text(item.codigoGrupoOcupacionalCivil),
                            $("<td>").text(item.codigoCargo),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoInfraccionDisciplinariaCivil),
                            $("<td>").text(item.solicitanteSancion),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoCargoSolicitante),
                            $("<td>").text(item.codigoGradoPersonalMilitarSansion),
                            $("<td>").text(item.codigoCargoImponeSancion),
                            $("<td>").text(item.codigoSancionDisciplinariaCivil),
                            $("<td>").text(item.inicioSancion),
                            $("<td>").text(item.terminoSancion)
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
    fetch("DipermarProcedimientoAdministrativoCivil/EnviarDatos", {
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
                url: '/DipermarProcedimientoAdministrativoCivil/EliminarCarga',
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
                    $('#tblDipermarProcedimientoAdministrativoCivil').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DipermarProcedimientoAdministrativoCivil/cargaCombs', [], function (Json) {
        var grupoOcupacionalCivil  = Json["data1"];
        var dependencia= Json["data2"];
        var infraccionDisciplinariaCivil= Json["data3"];
        var gradoPersonalMilitar= Json["data4"];
        var sancionDisciplinariaCivil= Json["data5"];
        var condicionLaboralCivil = Json["data6"];
        var cargos = Json["data7"];
        var listaCargas = Json["data8"];

        $("select#cbGrupoOcupacional").html("");
        $.each(grupoOcupacionalCivil, function () {
            var RowContent = '<option value=' + this.codigoGrupoOcupacionalCivil + '>' + this.descGrupoOcupacionalCivil + '</option>'
            $("select#cbGrupoOcupacional").append(RowContent);
        });
        $("select#cbGrupoOcupacionale").html("");
        $.each(grupoOcupacionalCivil, function () {
            var RowContent = '<option value=' + this.codigoGrupoOcupacionalCivil + '>' + this.descGrupoOcupacionalCivil + '</option>'
            $("select#cbGrupoOcupacionale").append(RowContent);
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

        $("select#cbInfracionD").html("");
        $.each(infraccionDisciplinariaCivil, function () {
            var RowContent = '<option value=' + this.codigoInfraccionDisciplinariaCivil + '>' + this.descInfraccionDisciplinariaCivil + '</option>'
            $("select#cbInfracionD").append(RowContent);
        });
        $("select#cbInfracionDe").html("");
        $.each(infraccionDisciplinariaCivil, function () {
            var RowContent = '<option value=' + this.codigoInfraccionDisciplinariaCivil + '>' + this.descInfraccionDisciplinariaCivil + '</option>'
            $("select#cbInfracionDe").append(RowContent);
        });

        $("select#cbGradoPersonal").html("");
        $("select#txtGradoImponeS").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonal").append(RowContent);
            $("select#txtGradoImponeS").append(RowContent);
        });

        $("select#cbGradoPersonale").html("");
        $("select#txtGradoImponeSe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonale").append(RowContent);
            $("select#txtGradoImponeSe").append(RowContent);
        });

        $("select#cbSancionDisc").html("");
        $.each(sancionDisciplinariaCivil, function () {
            var RowContent = '<option value=' + this.codigoSancionDisciplinariaCivil + '>' + this.descSancionDisciplinariaCivil + '</option>'
            $("select#cbSancionDisc").append(RowContent);
        });
        $("select#cbSancionDisce").html("");
        $.each(sancionDisciplinariaCivil, function () {
            var RowContent = '<option value=' + this.codigoSancionDisciplinariaCivil + '>' + this.descSancionDisciplinariaCivil + '</option>'
            $("select#cbSancionDisce").append(RowContent);
        });


        $("select#txtCondicionLaboral").html("");
        $.each(condicionLaboralCivil, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralCivil + '>' + this.descCondicionLaboralCivil + '</option>'
            $("select#txtCondicionLaboral").append(RowContent);
        });
        $("select#txtCondicionLaborale").html("");
        $.each(condicionLaboralCivil, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralCivil + '>' + this.descCondicionLaboralCivil + '</option>'
            $("select#txtCondicionLaborale").append(RowContent);
        });

        $("select#txtCargoDesem").html("");
        $("select#txtCargoDeseme").html("");
        $("select#txtCargoDesempenioS").html("");
        $("select#txtCargoDesempenioSe").html("");
        $("select#txtCargoImponesancion").html("");
        $("select#txtCargoImponesancione").html("");
        $.each(cargos, function () {
            var RowContent = '<option value=' + this.codigoCargo + '>' + this.descCargo + '</option>'
            $("select#txtCargoDesem").append(RowContent);
            $("select#txtCargoDeseme").append(RowContent);
            $("select#txtCargoDesempenioS").append(RowContent);
            $("select#txtCargoDesempenioSe").append(RowContent);
            $("select#txtCargoImponesancion").append(RowContent);
            $("select#txtCargoImponesancione").append(RowContent);
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
