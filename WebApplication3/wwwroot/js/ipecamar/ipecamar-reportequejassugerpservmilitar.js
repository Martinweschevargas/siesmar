var tblIpecamarReporteQuejasSugerPServMilitar;

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
                                url: '/IpecamarReporteQuejasSugerPServMilitar/Insertar',
                                data: {
                                    'FechaRegistroQuejaSuger': $('#cbFechaRegistro').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDep').val(),
                                    'CodigoZonaNaval': $('#cbZonanaval').val(),
                                    'CodigoTipoNovedad': $('#cbTipoNovedad').val(),
                                    'SituacionPersonalQuejasSuger': $('#cbSituacionPersonal').val(),
                                    'CategoriaQuejasSuger': $('#cbCategoria').val(),
                                    'AccionTomadaQuejasSuger': $('#cbAccionTomada').val(),
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
                                    $('#tblIpecamarReporteQuejasSugerPServMilitar').DataTable().ajax.reload();
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
                                url: '/IpecamarReporteQuejasSugerPServMilitar/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaRegistroQuejaSuger': $('#cbFechaRegistroe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDepe').val(),
                                    'CodigoZonaNaval': $('#cbZonanavale').val(),
                                    'CodigoTipoNovedad': $('#cbTipoNovedad').val(),
                                    'SituacionPersonalQuejasSuger': $('#cbSituacionPersonale').val(),
                                    'CategoriaQuejasSuger': $('#cbCategoriae').val(),
                                    'AccionTomadaQuejasSuger': $('#cbAccionTomadae').val(),
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
                                    $('#tblIpecamarReporteQuejasSugerPServMilitar').DataTable().ajax.reload();
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

 tblIpecamarReporteQuejasSugerPServMilitar =   $('#tblIpecamarReporteQuejasSugerPServMilitar').DataTable({
        ajax: {
            "url": '/IpecamarReporteQuejasSugerPServMilitar/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "reporteQuejaSugerPServMilitarId" },
            { "data": "fechaRegistroQuejaSuger" },
            { "data": "descDependencia" },
            { "data": "descComandanciaDependencia" },
            { "data": "descZonaNaval" },
            { "data": "descTipoNovedad" },
            { "data": "situacionPersonalQuejasSuger" },
            { "data": "categoriaQuejasSuger" },
            { "data": "accionTomadaQuejasSuger" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.reporteQuejaSugerPServMilitarId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.reporteQuejaSugerPServMilitarId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Ipecamar - Quejas, Denuncias, Solicitudes, Sugerencias, Consultas y requerimientos del Personal del Servicio Militar',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Ipecamar - Quejas, Denuncias, Solicitudes, Sugerencias, Consultas y requerimientos del Personal del Servicio Militar',
                title: 'Ipecamar - Quejas, Denuncias, Solicitudes, Sugerencias, Consultas y requerimientos del Personal del Servicio Militar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Ipecamar - Quejas, Denuncias, Solicitudes, Sugerencias, Consultas y requerimientos del Personal del Servicio Militar',
                title: 'Ipecamar - Quejas, Denuncias, Solicitudes, Sugerencias, Consultas y requerimientos del Personal del Servicio Militar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Ipecamar - Quejas, Denuncias, Solicitudes, Sugerencias, Consultas y requerimientos del Personal del Servicio Militar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
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
    tblIpecamarReporteQuejasSugerPServMilitar.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblIpecamarReporteQuejasSugerPServMilitar.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/IpecamarReporteQuejasSugerPServMilitar/Mostrar?Id=' + Id, [], function (ReporteAcademiaServMilitarDTO) {
        $('#txtCodigo').val(ReporteAcademiaServMilitarDTO.reporteQuejaSugerPServMilitarId);
        $('#cbFechaRegistroe').val(ReporteAcademiaServMilitarDTO.fechaRegistroQuejaSuger);
        $('#cbDependenciae').val(ReporteAcademiaServMilitarDTO.codigoDependencia);
        $('#cbComandanciaDepe').val(ReporteAcademiaServMilitarDTO.codigoComandanciaDependencia);
        $('#cbZonanavale').val(ReporteAcademiaServMilitarDTO.codigoZonaNaval);
        $('#cbTipoNovedade').val(ReporteAcademiaServMilitarDTO.codigoTipoNovedad);
        $('#cbSituacionPersonale').val(ReporteAcademiaServMilitarDTO.situacionPersonalQuejasSuger);
        $('#cbCategoriae').val(ReporteAcademiaServMilitarDTO.categoriaQuejasSuger);
        $('#cbAccionTomadae').val(ReporteAcademiaServMilitarDTO.accionTomadaQuejasSuger);
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
                url: '/IpecamarReporteQuejasSugerPServMilitar/Eliminar',
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
                    $('#tblIpecamarReporteQuejasSugerPServMilitar').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaIpecamarReporteQuejasSugerPServMilitar() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'IpecamarReporteQuejasSugerPServMilitar/MostrarDatos',
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
                            $("<td>").text(item.fechaRegistroQuejaSugerFechaRegistroQuejaSuger),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoComandanciaDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoTipoNovedad),
                            $("<td>").text(item.situacionPersonalQuejasSuger),
                            $("<td>").text(item.categoriaQuejasSuger),
                            $("<td>").text(item.accionTomadaQuejasSuger)
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
    fetch("IpecamarReporteQuejasSugerPServMilitar/EnviarDatos", {
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

function cargaDatos() {
    $.getJSON('/IpecamarReporteQuejasSugerPServMilitar/cargaCombs', [], function (Json) {
        var dependencia = Json["data1"];
        var comandanciadependencia = Json["data2"];
        var zonaNaval = Json["data3"];
        var tiponovedad = Json["data4"];
        var listaCargas = Json["data5"];

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

        $("select#cbComandanciaDep").html("");
        $.each(comandanciadependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDep").append(RowContent);
        });
        $("select#cbComandanciaDepe").html("");
        $.each(comandanciadependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDepe").append(RowContent);
        });

        $("select#cbZonanaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanaval").append(RowContent);
        });
        $("select#cbZonanavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanavale").append(RowContent);
        });

        $("select#cbTipoNovedad").html("");
        $.each(tiponovedad, function () {
            var RowContent = '<option value=' + this.codigoTipoNovedad + '>' + this.descTipoNovedad + '</option>'
            $("select#cbTipoNovedad").append(RowContent);
        });
        $("select#cbTipoNovedade").html("");
        $.each(tiponovedad, function () {
            var RowContent = '<option value=' + this.codigoTipoNovedad + '>' + this.descTipoNovedad + '</option>'
            $("select#cbTipoNovedade").append(RowContent);
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

