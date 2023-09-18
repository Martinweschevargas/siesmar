var tblDintemarInformeAccionTransgredenSeguridad;

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
                                url: '/DintemarInformeAccionTransgredenSeguridad/Insertar',
                                data: {
                                    'InformeTransgresion': $('#txtInformeTrans').val(),
                                    'FechaInforme': $('#txtFechaInforme').val(),
                                    'FechaSucesoTransgresion': $('#txtFechasucesoTrans').val(),
                                    'DepartamentoUbigeo': $('#cbDepartamentoU').val(),
                                    'Ubigeo': $('#cbProvinciaU').val(),
                                    'DistritoUbigeo': $('#cbDistritoU').val(),
                                    'CodigoZonaNaval': $('#cbZonanaval').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'TipoTransgresionId': $('#cbTipoTransgresion').val(),
                                    'DetalleHecho': $('#txtDetalleHecho').val(),
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
                                    $('#tblDintemarInformeAccionTransgredenSeguridad').DataTable().ajax.reload();
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
                                url: '/DintemarInformeAccionTransgredenSeguridad/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'InformeTransgresion': $('#txtInformeTranse').val(),
                                    'FechaInforme': $('#txtFechaInformee').val(),
                                    'FechaSucesoTransgresion': $('#txtFechasucesoTranse').val(),
                                    'DepartamentoUbigeo': $('#cbDepartamentoUe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUe').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUe').val(),
                                    'CodigoZonaNaval': $('#cbZonanavale').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'TipoTransgresionId': $('#cbTipoTransgresione').val(),
                                    'DetalleHecho': $('#txtDetalleHechoe').val(),
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
                                    $('#tblDintemarInformeAccionTransgredenSeguridad').DataTable().ajax.reload();
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

    $('#tblDintemarInformeAccionTransgredenSeguridad').DataTable({
        ajax: {
            "url": '/DintemarInformeAccionTransgredenSeguridad/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "informeAccionTransgredenSeguridadId" },
            { "data": "informeTransgresion" },
            { "data": "fechaInforme" },
            { "data": "fechaSucesoTransgresion" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDistrito" },
            { "data": "descZonaNaval" },
            { "data": "descDependencia" },
            { "data": "descTipoTransgresion" },
            { "data": "detalleHecho" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.informeAccionTransgredenSeguridadId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.informeAccionTransgredenSeguridadId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dintemar - Informes Emitidos por la Marina de Guerra del Perú sobre Acciones que Transgreden la Seguridad del Territorio NacionaL',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dintemar - Informes Emitidos por la Marina de Guerra del Perú sobre Acciones que Transgreden la Seguridad del Territorio NacionaL',
                title: 'Dintemar - Informes Emitidos por la Marina de Guerra del Perú sobre Acciones que Transgreden la Seguridad del Territorio NacionaL',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dintemar - Informes Emitidos por la Marina de Guerra del Perú sobre Acciones que Transgreden la Seguridad del Territorio NacionaL',
                title: 'Dintemar - Informes Emitidos por la Marina de Guerra del Perú sobre Acciones que Transgreden la Seguridad del Territorio NacionaL',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dintemar - Informes Emitidos por la Marina de Guerra del Perú sobre Acciones que Transgreden la Seguridad del Territorio NacionaL',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
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
    tblDintemarInformeAccionTransgredenSeguridad.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDintemarInformeAccionTransgredenSeguridad.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DintemarInformeAccionTransgredenSeguridad/Mostrar?Id=' + Id, [], function (InformeAccionTransgredenSeguridadDTO) {
        $('#txtCodigo').val(InformeAccionTransgredenSeguridadDTO.informeAccionTransgredenSeguridadId);
        $('#txtInformeTranse').val(InformeAccionTransgredenSeguridadDTO.informeTransgresion);
        $('#txtFechaInformee').val(InformeAccionTransgredenSeguridadDTO.fechaInforme);
        $('#txtFechasucesoTranse').val(InformeAccionTransgredenSeguridadDTO.fechaSucesoTransgresion);
        $('#cbDepartamentoUe').val(InformeAccionTransgredenSeguridadDTO.DepartamentoUbigeo);
        $('#cbProvinciaUe').val(InformeAccionTransgredenSeguridadDTO.provinciaUbigeoId);
        $('#cbDistritoUe').val(InformeAccionTransgredenSeguridadDTO.distritoUbigeoId);
        $('#cbZonanavale').val(InformeAccionTransgredenSeguridadDTO.codigoZonaNaval);
        $('#cbDependenciae').val(InformeAccionTransgredenSeguridadDTO.codigoDependencia);
        $('#cbTipoTransgresione').val(InformeAccionTransgredenSeguridadDTO.tipoTransgresionId);
        $('#txtDetalleHechoe').val(InformeAccionTransgredenSeguridadDTO.detalleHecho);
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
                url: '/DintemarInformeAccionTransgredenSeguridad/Eliminar',
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
                    $('#tblDintemarInformeAccionTransgredenSeguridad').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDintemarInformeAccionTransgredenSeguridad() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/DintemarInformeAccionTransgredenSeguridad/cargaCombs', [], function (Json) {
        var DepartamentoUbigeo = Json["data1"];
        var ProvinciaUbigeo = Json["data2"];
        var DistritoUbigeo = Json["data3"];
        var ZonaNaval = Json["data4"];
        var Dependencia = Json["data5"];
        var TipoTransgresion = Json["data6"];

        $("select#cbDepartamentoU").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.DepartamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoU").append(RowContent);
        });
        $("select#cbDepartamentoUe").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.DepartamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUe").append(RowContent);
        });

        $("select#cbProvinciaU").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaU").append(RowContent);
        });
        $("select#cbProvinciaUe").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUe").append(RowContent);
        });

        $("select#cbDistritoU").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoU").append(RowContent);
        });
        $("select#cbDistritoUe").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUe").append(RowContent);
        });

        $("select#cbZonanaval").html("");
        $.each(ZonaNaval, function () {
            var RowContent = '<option value=' + this.zonaNavalId + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanaval").append(RowContent);
        });
        $("select#cbZonanavale").html("");
        $.each(ZonaNaval, function () {
            var RowContent = '<option value=' + this.zonaNavalId + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanavale").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.CodigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.CodigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbTipoTransgresion").html("");
        $.each(TipoTransgresion, function () {
            var RowContent = '<option value=' + this.tipoTransgresionId + '>' + this.descTipoTransgresion + '</option>'
            $("select#cbTipoTransgresion").append(RowContent);
        });
        $("select#cbTipoTransgresione").html("");
        $.each(TipoTransgresion, function () {
            var RowContent = '<option value=' + this.tipoTransgresionId + '>' + this.descTipoTransgresion + '</option>'
            $("select#cbTipoTransgresione").append(RowContent);
        });
    });
}

