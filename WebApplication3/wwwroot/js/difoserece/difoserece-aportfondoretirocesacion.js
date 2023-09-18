var tblDifosereceAportFondoRetiroCesacion;
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
                                url: '/DifosereceAportFondoRetiroCesacion/Insertar',
                                data: {
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalM').val(),
                                    'DNIPersonalRetiro': $('#txtDNI').val(),
                                    'SexoPersonalRetiro': $('#txtSexo').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoGradoRemunerativo': $('#cbGradoRemunerativo').val(),
                                    'CodigoSituacionPersonalNaval': $('#cbSituacionPersonalN').val(),
                                    'FechaNacimientoPersonalR': $('#txtFechaN').val(),
                                    'FechaIngresoPersonalR': $('#txtFechaIngreso').val(),
                                    'FechaNombramientoPersonalR': $('#txtFechaNombramiento').val(),
                                    'FechaPaseRetiroPersonalR': $('#txtFechaPaseR').val(),
                                    'FechaReincorporacionPersonalR': $('#txtFechaReinconr').val(),
                                    'FechaPrimerAportePersonalR': $('#txtFechaPrimerA').val(),
                                    'FechaUltimoAportePersonalR': $('#txtFechaUltimoA').val(),
                                    'NumeroCuotasAportadasPersonalR': $('#txtNCuotasAport').val(),
                                    'AporteMensualUltimoPersonalR': $('#txtAporteMensualU').val(),
                                    'TipoLiquidacionPersonalR': $('#txtTipoLiquidacion').val(),
                                    'DevolucionAportePersonalR': $('#txtDevolucionA').val(),
                                    'FechaLiquidacionPersonalR': $('#txtFechaLiqidacion').val(),
                                    'CodigoCausalLiquidacion': $('#cbCausalLiquidacion').val(),
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
                                    $('#tblDifosereceAportFondoRetiroCesacion').DataTable().ajax.reload();
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
                                url: '/DifosereceAportFondoRetiroCesacion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMe').val(),
                                    'DNIPersonalRetiro': $('#txtDNIe').val(),
                                    'SexoPersonalRetiro': $('#txtSexoe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoGradoRemunerativo': $('#cbGradoRemunerativoe').val(),
                                    'CodigoSituacionPersonalNaval': $('#cbSituacionPersonalNe').val(),
                                    'FechaNacimientoPersonalR': $('#txtFechaNe').val(),
                                    'FechaIngresoPersonalR': $('#txtFechaIngresoe').val(),
                                    'FechaNombramientoPersonalR': $('#txtFechaNombramientoe').val(),
                                    'FechaPaseRetiroPersonalR': $('#txtFechaPaseRe').val(),
                                    'FechaReincorporacionPersonalR': $('#txtFechaReinconre').val(),
                                    'FechaPrimerAportePersonalR': $('#txtFechaPrimerAe').val(),
                                    'FechaUltimoAportePersonalR': $('#txtFechaUltimoAe').val(),
                                    'NumeroCuotasAportadasPersonalR': $('#txtNCuotasAporte').val(),
                                    'AporteMensualUltimoPersonalR': $('#txtAporteMensualUe').val(),
                                    'TipoLiquidacionPersonalR': $('#txtTipoLiquidacione').val(),
                                    'DevolucionAportePersonalR': $('#txtDevolucionAe').val(),
                                    'FechaLiquidacionPersonalR': $('#txtFechaLiqidacione').val(),
                                    'CodigoCausalLiquidacion': $('#cbCausalLiquidacione').val(),
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
                                    $('#tblDifosereceAportFondoRetiroCesacion').DataTable().ajax.reload();
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


    tblDifosereceAportFondoRetiroCesacion =  $('#tblDifosereceAportFondoRetiroCesacion').DataTable({
        ajax: {
            "url": '/DifosereceAportFondoRetiroCesacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "aportacionFondoRetiroCesacionId" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "dniPersonalRetiro" },
            { "data": "sexoPersonalRetiro" },
            { "data": "descDependencia" },
            { "data": "descGradoRemunerativo" },
            { "data": "descSituacionPersonalNaval" },
            { "data": "fechaNacimientoPersonalR" },
            { "data": "fechaIngresoPersonalR" },
            { "data": "fechaNombramientoPersonalR" },
            { "data": "fechaPaseRetiroPersonalR" },
            { "data": "fechaReincorporacionPersonalR" },
            { "data": "fechaPrimerAportePersonalR" },
            { "data": "fechaUltimoAportePersonalR" },
            { "data": "numeroCuotasAportadasPersonalR" },
            { "data": "aporteMensualUltimoPersonalR" },
            { "data": "tipoLiquidacionPersonalR" },
            { "data": "devolucionAportePersonalR" },
            { "data": "fechaLiquidacionPersonalR" },
            { "data": "descCausalLiquidacion" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.aportacionFondoRetiroCesacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.aportacionFondoRetiroCesacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Difoserece - Formato Para el Ingreso de Datos de la Dirección de Fondo de Seguro de Retiro y Cesación',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Difoserece - Formato Para el Ingreso de Datos de la Dirección de Fondo de Seguro de Retiro y Cesación',
                title: 'Difoserece - Formato Para el Ingreso de Datos de la Dirección de Fondo de Seguro de Retiro y Cesación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Difoserece - Formato Para el Ingreso de Datos de la Dirección de Fondo de Seguro de Retiro y Cesación',
                title: 'Difoserece - Formato Para el Ingreso de Datos de la Dirección de Fondo de Seguro de Retiro y Cesación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Difoserece - Formato Para el Ingreso de Datos de la Dirección de Fondo de Seguro de Retiro y Cesación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19]
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
    tblDifosereceAportFondoRetiroCesacion.columns(20).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDifosereceAportFondoRetiroCesacion.columns(20).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DifosereceAportFondoRetiroCesacion/Mostrar?Id=' + Id, [], function (AportFondoRetiroCesacionDTO) {
        $('#txtCodigo').val(AportFondoRetiroCesacionDTO.aportacionFondoRetiroCesacionId);
        $('#cbTipoPersonalMe').val(AportFondoRetiroCesacionDTO.codigoTipoPersonalMilitar);
        $('#txtDNIe').val(AportFondoRetiroCesacionDTO.dniPersonalRetiro);
        $('#txtSexoe').val(AportFondoRetiroCesacionDTO.sexoPersonalRetiro);
        $('#cbDependenciae').val(AportFondoRetiroCesacionDTO.codigoDependencia);
        $('#cbGradoRemunerativoe').val(AportFondoRetiroCesacionDTO.codigoGradoRemunerativo);
        $('#cbSituacionPersonalNe').val(AportFondoRetiroCesacionDTO.codigoSituacionPersonalNaval);
        $('#txtFechaNe').val(AportFondoRetiroCesacionDTO.fechaNacimientoPersonalR);
        $('#txtFechaIngresoe').val(AportFondoRetiroCesacionDTO.fechaIngresoPersonalR);
        $('#txtFechaNombramientoe').val(AportFondoRetiroCesacionDTO.fechaNombramientoPersonalR);
        $('#txtFechaPaseRe').val(AportFondoRetiroCesacionDTO.fechaPaseRetiroPersonalR);
        $('#txtFechaReinconre').val(AportFondoRetiroCesacionDTO.fechaReincorporacionPersonalR);
        $('#txtFechaPrimerAe').val(AportFondoRetiroCesacionDTO.fechaPrimerAportePersonalR);
        $('#txtFechaUltimoAe').val(AportFondoRetiroCesacionDTO.fechaUltimoAportePersonalR);
        $('#txtNCuotasAporte').val(AportFondoRetiroCesacionDTO.numeroCuotasAportadasPersonalR);
        $('#txtAporteMensualUe').val(AportFondoRetiroCesacionDTO.aporteMensualUltimoPersonalR);
        $('#txtTipoLiquidacione').val(AportFondoRetiroCesacionDTO.tipoLiquidacionPersonalR);
        $('#txtDevolucionAe').val(AportFondoRetiroCesacionDTO.devolucionAportePersonalR);
        $('#txtFechaLiqidacione').val(AportFondoRetiroCesacionDTO.fechaLiquidacionPersonalR);
        $('#cbCausalLiquidacione').val(AportFondoRetiroCesacionDTO.codigoCausalLiquidacion);
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
                url: '/DifosereceAportFondoRetiroCesacion/Eliminar',
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
                    $('#tblDifosereceAportFondoRetiroCesacion').DataTable().ajax.reload();
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
                url: '/DifosereceAportFondoRetiroCesacion/EliminarCarga',
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
                    $('#tblDifosereceAportFondoRetiroCesacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDifosereceAportFondoRetiroCesacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DifosereceAportFondoRetiroCesacion/MostrarDatos',
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
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.dniPersonalRetiro),
                            $("<td>").text(item.sexoPersonalRetiro),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoGradoRemunerativo),
                            $("<td>").text(item.codigoSituacionPersonalNaval),
                            $("<td>").text(item.fechaNacimientoPersonalR),
                            $("<td>").text(item.fechaIngresoPersonalR),
                            $("<td>").text(item.fechaNombramientoPersonalR),
                            $("<td>").text(item.fechaPaseRetiroPersonalR),
                            $("<td>").text(item.fechaReincorporacionPersonalR),
                            $("<td>").text(item.fechaPrimerAportePersonalR),
                            $("<td>").text(item.fechaUltimoAportePersonalR),
                            $("<td>").text(item.numeroCuotasAportadasPersonalR),
                            $("<td>").text(item.aporteMensualUltimoPersonalR),
                            $("<td>").text(item.tipoLiquidacionPersonalR),
                            $("<td>").text(item.devolucionAportePersonalR),
                            $("<td>").text(item.fechaLiquidacionPersonalR),
                            $("<td>").text(item.codigoCausalLiquidacion),
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
    fetch("DifosereceAportFondoRetiroCesacion/EnviarDatos", {
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
    $.getJSON('/DifosereceAportFondoRetiroCesacion/cargaCombs', [], function (Json) {
        var tipoPersonaMilitar = Json["data1"];
        var dependencia = Json["data2"];
        var gradoRemunerativo = Json["data3"];
        var situacionPersonalNaval = Json["data4"];
        var causalLiquidacion = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbTipoPersonalM").html("");
        $("select#cbTipoPersonalMe").html("");
        $.each(tipoPersonaMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalM").append(RowContent);
            $("select#cbTipoPersonalMe").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbGradoRemunerativo").html("");
        $("select#cbGradoRemunerativoe").html("");
        $.each(gradoRemunerativo, function () {
            var RowContent = '<option value=' + this.codigoGradoRemunerativo + '>' + this.descGradoRemunerativo + '</option>'
            $("select#cbGradoRemunerativo").append(RowContent);
            $("select#cbGradoRemunerativoe").append(RowContent);
        });

        $("select#cbSituacionPersonalN").html("");
        $("select#cbSituacionPersonalNe").html("");
        $.each(situacionPersonalNaval, function () {
            var RowContent = '<option value=' + this.codigoSituacionPersonalNaval + '>' + this.descSituacionPersonalNaval + '</option>'
            $("select#cbSituacionPersonalN").append(RowContent);
            $("select#cbSituacionPersonalNe").append(RowContent);
        });

        $("select#cbCausalLiquidacion").html("");
        $("select#cbCausalLiquidacione").html("");
        $.each(causalLiquidacion, function () {
            var RowContent = '<option value=' + this.codigoCausalLiquidacion + '>' + this.descCausalLiquidacion + '</option>'
            $("select#cbCausalLiquidacion").append(RowContent);
            $("select#cbCausalLiquidacione").append(RowContent);
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

    reporteSeleccionado = '/DifosereceAportFondoRetiroCesacion/ReporteARTR';
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