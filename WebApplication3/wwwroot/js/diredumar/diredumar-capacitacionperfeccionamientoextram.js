var tblDiredumarCapacitacionPerfeccionamientoExtraM;
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
                                url: '/DiredumarCapacitacionPerfeccionamientoExtraM/Insertar',
                                data: {
                                    'CIPCapPerf': $('#txtCIPCapPerf').val(),
                                    'DNICapPerf': $('#txtDNICapPerf').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),  
                                    'CodigoNivelEstudio': $('#cbNivelEstudio').val(),
                                    'CodigoInstitucionEducativaSuperior': $('#cbInstitucionEducativaS').val(),
                                    'MensionCapacitacion': $('#txtMensionCurso').val(),
                                    'FinanciamientoCapacitacion': $('#txtFinanciamiento').val(), 
                                    'NumericoPais': $('#cbPaisUbigeo').val(),
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
                                    $('#tblDiredumarCapacitacionPerfeccionamientoExtraM').DataTable().ajax.reload();
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
                                url: '/DiredumarCapacitacionPerfeccionamientoExtraM/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CIPCapPerf': $('#txtCIPCapPerfe').val(),
                                    'DNICapPerf': $('#txtDNICapPerfe').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudioe').val(),
                                    'CodigoInstitucionEducativaSuperior': $('#cbInstitucionEducativaSe').val(),
                                    'MensionCapacitacion': $('#txtMensionCursoe').val(),
                                    'FinanciamientoCapacitacion': $('#txtFinanciamientoe').val(),
                                    'NumericoPais': $('#cbPaisUbigeoe').val(),
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
                                    $('#tblDiredumarCapacitacionPerfeccionamientoExtraM').DataTable().ajax.reload();
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

        tblDiredumarCapacitacionPerfeccionamientoExtraM =  $('#tblDiredumarCapacitacionPerfeccionamientoExtraM').DataTable({
        ajax: {
            "url": '/DiredumarCapacitacionPerfeccionamientoExtraM/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "capacitacionPerfeccionamientoExtraMId" },
            { "data": "cipCapaPerf" },
            { "data": "dniCapaPerf" },
            { "data": "descTipoPersonalMilitar" }, 
            { "data": "descGrado" },
            { "data": "descNivelEstudio" },
            { "data": "descInstitucionEducativaSuperior" },
            { "data": "mencionCapacitacion" },
            { "data": "financiamientoCapacitacion" },
            { "data": "nombrePais" }, 
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.capacitacionPerfeccionamientoExtraMId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.capacitacionPerfeccionamientoExtraMId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diredumar - Capacitación y Perfeccionamiento Extra Institucional del Personal Militar ',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diredumar - Capacitación y Perfeccionamiento Extra Institucional del Personal Militar ',
                title: 'Diredumar - Capacitación y Perfeccionamiento Extra Institucional del Personal Militar ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diredumar - Capacitación y Perfeccionamiento Extra Institucional del Personal Militar ',
                title: 'Diredumar - Capacitación y Perfeccionamiento Extra Institucional del Personal Militar ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diredumar - Capacitación y Perfeccionamiento Extra Institucional del Personal Militar ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
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
    tblDiredumarCapacitacionPerfeccionamientoExtraM.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiredumarCapacitacionPerfeccionamientoExtraM.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiredumarCapacitacionPerfeccionamientoExtraM/Mostrar?Id=' + Id, [], function (CapacitacionPerfeccionamientoMilitarDTO) {
        $('#txtCodigo').val(CapacitacionPerfeccionamientoMilitarDTO.capacitacionPerfeccionamientoExtraMId);
        $('#txtCIPCapPerfe').val(CapacitacionPerfeccionamientoMilitarDTO.cipCapaPerf);
        $('#txtDNICapPerfe').val(CapacitacionPerfeccionamientoMilitarDTO.dniCapaPerf);
        $('#cbTipoPersonalMilitare').val(CapacitacionPerfeccionamientoMilitarDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMilitare').val(CapacitacionPerfeccionamientoMilitarDTO.codigoGradoPersonalMilitar);
        $('#cbEntidadMilitare').val(CapacitacionPerfeccionamientoMilitarDTO.codigoNivelEstudio);
        $('#cbCodigoEscuelae').val(CapacitacionPerfeccionamientoMilitarDTO.codigoInstitucionEducativaSuperior);
        $('#txtMensionCursoe').val(CapacitacionPerfeccionamientoMilitarDTO.mencionCapacitacion);
        $('#txtFinanciamiento').val(CapacitacionPerfeccionamientoMilitarDTO.financiamientoCapacitacion); 
        $('select#cbPaisUbigeoe option[value=' + CapacitacionPerfeccionamientoMilitarDTO.numericoPais + ']').prop("selected", "true");

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
                url: '/DiredumarCapacitacionPerfeccionamientoExtraM/Eliminar',
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
                    $('#tblDiredumarCapacitacionPerfeccionamientoExtraM').DataTable().ajax.reload();
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
                url: '/DiredumarCapacitacionPerfeccionamientoExtraM/EliminarCarga',
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
                    $('#tblDiredumarCapacitacionPerfeccionamientoExtraM').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiredumarCapacitacionPerfeccionamientoExtraM() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiredumarCapacitacionPerfeccionamientoExtraM/MostrarDatos',
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
                            $("<td>").text(item.cipCapaPerf),
                            $("<td>").text(item.dniCapaPerf),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoNivelEstudio),
                            $("<td>").text(item.codigoNivelEstudio),
                            $("<td>").text(item.mencionCapacitacion),
                            $("<td>").text(item.financiamientoCapacitacion),
                            $("<td>").text(item.numericoPais)
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
    fetch("DiredumarCapacitacionPerfeccionamientoExtraM/EnviarDatos", {
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
                    'Ocurrio un problema. '+mensaje,
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/DiredumarCapacitacionPerfeccionamientoExtraM/cargaCombs', [], function (Json) {
        var TipoPersonalMilitar = Json["data1"];
        var GradoPersonalMilitar = Json["data2"];
        var PaisUbigeo = Json["data3"];
        var NivelEstudio = Json["data4"];
        var InstitucionEducativaS = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbTipoPersonalMilitar").html("");
        $("select#cbTipoPersonalMilitare").html("");
        $.each(TipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitar").append(RowContent);
            $("select#cbTipoPersonalMilitare").append(RowContent);
        });

        $("select#cbGradoPersonalMilitar").html("");
        $("select#cbGradoPersonalMilitare").html("");
        $.each(GradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });

        $("select#cbPaisUbigeo").html("");
        $("select#cbPaisUbigeoe").html("");
        $.each(PaisUbigeo, function () {
            var RowContent = '<option value=' + this.numerico + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeo").append(RowContent);
            $("select#cbPaisUbigeoe").append(RowContent);
        });

        $("select#cbNivelEstudio").html("");
        $("select#cbNivelEstudioe").html("");
        $.each(NivelEstudio, function () {
            var RowContent = '<option value=' + this.codigoNivelEstudio + '>' + this.descNivelEstudio + '</option>'
            $("select#cbNivelEstudio").append(RowContent);
            $("select#cbNivelEstudioe").append(RowContent);
        });

        $("select#cbInstitucionEducativaS").html("");
        $("select#cbInstitucionEducativaSe").html("");
        $.each(InstitucionEducativaS, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativaSuperior + '>' + this.descInstitucionEducativaSuperior + '</option>'
            $("select#cbInstitucionEducativaS").append(RowContent);
            $("select#cbInstitucionEducativaSe").append(RowContent);
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

    reporteSeleccionado = '/DiredumarCapacitacionPerfeccionamientoExtraM/ReporteARTR';
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