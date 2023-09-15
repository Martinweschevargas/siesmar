var tblComzocuatroAlistamientoMaterial;
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
                                url: '/ComzocuatroAlistamientoMaterial/Insertar',
                                data: {
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativa').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3N').val(),
                                    'Requerido': $('#txtNivelAlistamientoParcial').val(),
                                    'Operativo': $('#txtOperativo').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperatividad').val(),
                                    'PonderadoFuncional': $('#PorcentajeFuncional').val(),
                                    'NivelAlistamientoParcial': $('#txtNivelAlistamientoParcial').val(),
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
                                    $('#tblComzocuatroAlistamientoMaterial').DataTable().ajax.reload();
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
                                url: '/ComzocuatroAlistamientoMaterial/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativae').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3N').val(),
                                    'Requerido': $('#txtNivelAlistamientoParciale').val(),
                                    'Operativo': $('#txtOperativoe').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperatividade').val(),
                                    'PonderadoFuncional': $('#PorcentajeFuncionale').val(),
                                    'NivelAlistamientoParcial': $('#txtNivelAlistamientoParciale').val(),
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
                                    $('#tblComzocuatroAlistamientoMaterial').DataTable().ajax.reload();
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

    tblComzocuatroAlistamientoMaterial = $('#tblComzocuatroAlistamientoMaterial').DataTable({
        ajax: {
            "url": '/ComzocuatroAlistamientoMaterial/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialId" },
            { "data": "descCapacidadOperativa" },
            { "data": "descUnidadNaval" },
            { "data": "capacidadIntrinseca" },
            { "data": "ponderado1N" },
            { "data": "subclasificacion2" },
            { "data": "ponderado2Nivel" },
            { "data": "subclasificacion3" },
            { "data": "ponderado3Nivel" },
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "porcentajeOperatividad" },
            { "data": "porcentajeFuncional" },
            { "data": "nivelAlistamientoParcial" },
            { "data": "cargaId" }


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzocuatro - Alistamiento de Material',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comzocuatro - Alistamiento de Material',
                title: 'Comzocuatro - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzocuatro - Alistamiento de Material',
                title: 'Comzocuatro - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzocuatro - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
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
    $.getJSON('/ComzocuatroAlistamientoMaterial/Mostrar?Id=' + Id, [], function (AlistamientoMaterialComzocuatroDTO) {
        $('#txtCodigo').val(AlistamientoMaterialComzocuatroDTO.alistamientoMaterialId);
        $('#cbCapacidadOperativae').val(AlistamientoMaterialComzocuatroDTO.codigoCapacidadOperativa);
        $('#cbUnidadNavale').val(AlistamientoMaterialComzocuatroDTO.codigoUnidadNaval);
        $('#cbAlistamientoMaterialRequerido3Ne').val(AlistamientoMaterialComzocuatroDTO.codigoAlistamientoMaterialRequerido3N);
        $('#txtRequeridoe').val(AlistamientoMaterialComzocuatroDTO.requerido);
        $('#txtOperativoe').val(AlistamientoMaterialComzocuatroDTO.operativo);
        $('#txtPorcentajeOperatividade').val(AlistamientoMaterialComzocuatroDTO.porcentajeOperatividad);
        $('#PorcentajeFuncionale').val(AlistamientoMaterialComzocuatroDTO.porcentajeFuncional);
        $('#txtCapacidadIntrinsecae').val(AlistamientoMaterialComzocuatroDTO.capacidadIntrinseca);
        $('#txtPonderado1Ne').val(AlistamientoMaterialComzocuatroDTO.ponderado1N);
        $('#txtSubclasificacion2e').val(AlistamientoMaterialComzocuatroDTO.subclasificacion2);
        $('#txtPonderado2Nivele').val(AlistamientoMaterialComzocuatroDTO.ponderado2Nivel);
        $('#txtPonderado3Nivele').val(AlistamientoMaterialComzocuatroDTO.ponderado3Nivel);
        $('#txtNivelAlistamientoParciale').val(AlistamientoMaterialComzocuatroDTO.nivelAlistamientoParcial);
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
                url: '/ComzocuatroAlistamientoMaterial/Eliminar',
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
                    $('#tblComzocuatroAlistamientoMaterial').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComzocuatroAlistamientoMaterial() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComzocuatroAlistamientoMaterial/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var CapacidadOperativa = Json["data2"];
        var AlistamientoMaterialRequerido3N = Json["data3"];
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

        $("select#cbCapacidadOperativa").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativa + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
        });
        $("select#cbCapacidadOperativae").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativa + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativae").append(RowContent);
        });


        $("select#cbAlistamientoMaterialRequerido3N").html("");
        $.each(AlistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido3N + '>' + this.descAlistamientoMaterialRequerido3N + '</option>'
            $("select#cbAlistamientoMaterialRequerido3N").append(RowContent);
        });
        $("select#cbAlistamientoMaterialRequerido3Ne").html("");
        $.each(AlistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido3N + '>' + this.descAlistamientoMaterialRequerido3N + '</option>'
            $("select#cbAlistamientoMaterialRequerido3Ne").append(RowContent);
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

//function optReporte(id) {
//    optReporteSelect = id;
//    if (id == 1) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCA';
//        $('#accionAnteCiberataque').hide();
//        $('#tipoCiberataque').hide();
//        $('#fechaInicio').hide();
//        $('#fechaTermino').hide();
//    }
//    if (id == 2) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCXSSA';
//        $('#accionAnteCiberataque').show();
//        $('#tipoCiberataque').hide();
//        $('#fechaInicio').show();
//        $('#fechaTermino').show();
//    }
//    if (id == 3) {
//        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCATCA';
//        $('#tipoCiberataque').show();
//        $('#accionAnteCiberataque').hide();
//        $('#fechaInicio').show();
//        $('#fechaTermino').show();
//    }
//}

//$('#btnReportView').click(function () {
//    var idCarga = $('select#cargas').val();
//    var numCarga;
//    if (idCarga == "0") {
//        numCarga = "";
//    } else {
//        numCarga = 'CargaId=' + idCarga;
//    }
//    var a = document.createElement('a');
//    a.target = "_blank";
//    if (optReporteSelect == 1) {
//        a.href = reporteSeleccionado + '?' + numCarga;
//    }
//    if (optReporteSelect == 2) {
//        a.href = reporteSeleccionado + '?accionAnteCiberataque=' + $('#txtAccionAnteCiberA').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
//    }
//    if (optReporteSelect == 3) {
//        a.href = reporteSeleccionado + '?tipoCiberataque=' + $('#txtCiberAtaque').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
//    }
//    a.click();
//});