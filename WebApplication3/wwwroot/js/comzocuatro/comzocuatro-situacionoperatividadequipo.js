var tblComzocuatroSituacionOperatividadEquipo;
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
                                url: '/ComzocuatroSituacionOperatividadEquipo/Insertar',
                                data: {
                                    'DescripcionMaterialId': $('#cbDescripcionMaterial').val(),
                                    'Cantidad': $('#txtCantidad').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'Ubicacion': $('#cbUbicacion').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeo').val(),
                                    'CodigoCondicion': $('#cbCondicion').val(),
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
                                    $('#tblComzocuatroSituacionOperatividadEquipo').DataTable().ajax.reload();
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
                                url: '/ComzocuatroSituacionOperatividadEquipo/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DescripcionMaterialId': $('#cbDescripcionMateriale').val(),
                                    'Cantidad': $('#txtCantidade').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'Ubicacion': $('#cbUbicacione').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeoe').val(),
                                    'CodigoCondicion': $('#cbCondicione').val(),
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
                                    $('#tblComzocuatroSituacionOperatividadEquipo').DataTable().ajax.reload();
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

    $('#tblComzocuatroSituacionOperatividadEquipo').DataTable({
        ajax: {
            "url": '/ComzocuatroSituacionOperatividadEquipo/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionOperatividadEquipoId" },
            { "data": "descDescripcionMaterial" },
            { "data": "cantidad" },
            { "data": "descUnidadNaval" },
            { "data": "descUbicaci" },
            { "data": "descDepartamenteo" },
            { "data": "descProvincia" },
            { "data": "descDistritoUbigeo" },
            { "data": "descCondicion" },
            { "data": "observacion" },
            { "data": "cargaId" },


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionOperatividadEquipoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionOperatividadEquipoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzocuatro - Formato de Situación de Operatividad de Equipos',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comzocuatro - Formato de Situación de Operatividad de Equipos',
                title: 'Comzocuatro - Formato de Situación de Operatividad de Equipos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzocuatro - Formato de Situación de Operatividad de Equipos',
                title: 'Comzocuatro - Formato de Situación de Operatividad de Equipos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzocuatro - Formato de Situación de Operatividad de Equipos',
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzocuatroSituacionOperatividadEquipo/Mostrar?Id=' + Id, [], function (SituacionOperatividadEquipoComzocuatroDTO) {
        $('#txtCodigo').val(SituacionOperatividadEquipoComzocuatroDTO.situacionOperatividadEquipoId);
        $('#cbDescripcionMateriale').val(SituacionOperatividadEquipoComzocuatroDTO.descripcionMaterialId);
        $('#txtCantidade').val(SituacionOperatividadEquipoComzocuatroDTO.cantidad);
        $('#cbUnidadNavale').val(SituacionOperatividadEquipoComzocuatroDTO.codigoUnidadNaval);
        $('#cbUbicacione').val(SituacionOperatividadEquipoComzocuatroDTO.ubicacion);
        $('#cbDepartamentoUbigeoe').val(SituacionOperatividadEquipoComzocuatroDTO.descDepartamenteo);
        $('#cbProvinciaUbigeoe').val(SituacionOperatividadEquipoComzocuatroDTO.descProvincia);
        $('#cbDistritoUbigeoe').val(SituacionOperatividadEquipoComzocuatroDTO.distritoUbigeo);
        $('#cbCondicione').val(SituacionOperatividadEquipoComzocuatroDTO.codigoCondicion);
        $('#txtObservacione').val(SituacionOperatividadEquipoComzocuatroDTO.observacion); 
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
                url: '/ComzocuatroSituacionOperatividadEquipo/Eliminar',
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
                    $('#tblComzocuatroSituacionOperatividadEquipo').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComzocuatroSituacionOperatividadEquipo() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComzocuatroSituacionOperatividadEquipo/cargaCombs', [], function (Json) {
        var DescripcionMaterial = Json["data1"];
        var UnidadNaval = Json["data2"];
        var DistritoUbigeo = Json["data3"];
        var Condicion = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbDescripcionMaterial").html("");
        $.each(DescripcionMaterial, function () {
            var RowContent = '<option value=' + this.descripcionMaterialId + '>' + this.descDescripcionMaterial + '</option>'
            $("select#cbDescripcionMaterial").append(RowContent);
        });
        $("select#cbDescripcionMateriale").html("");
        $.each(DescripcionMaterial, function () {
            var RowContent = '<option value=' + this.descripcionMaterialId + '>' + this.descDescripcionMaterial + '</option>'
            $("select#cbDescripcionMateriale").append(RowContent);
        });


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


        $("select#cbDistritoUbigeo").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeo").append(RowContent);
        });
        $("select#cbDistritoUbigeoe").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });


        $("select#cbCondicion").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.codigoCondicion + '>' + this.descCondicion + '</option>'
            $("select#cbCondicion").append(RowContent);
        });
        $("select#cbCondicione").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.codigoCondicion + '>' + this.descCondicion + '</option>'
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