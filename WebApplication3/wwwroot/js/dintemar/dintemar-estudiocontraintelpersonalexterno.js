var tblDintemarEstudioContraintelPersonalExterno;
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
                                url: '/DintemarEstudioContraintelPersonalExterno/Insertar',
                                data: {
                                    'NumericoPais': $('#cbPaisUbigeo').val(),
                                    'CodigoTipoVinculo': $('#cbTipoVinculo').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoZonaNaval': $('#cbZonanaval').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDep').val(),
                                    'InvestigacionContrainteligenciaProducida': $('#txtNroInvestigContra').val(),
                                    'CodigoTipoEstudioContrainteligencia': $('#cbTipoEstudioContra').val(),
                                    'CargaId': $('#cargasR').val(),
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
                                    $('#tblDintemarEstudioContraintelPersonalExterno').DataTable().ajax.reload();
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
                                url: '/DintemarEstudioContraintelPersonalExterno/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NumericoPais': $('#cbPaisUbigeoe').val(),
                                    'CodigoTipoVinculo': $('#cbTipoVinculoe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoZonaNaval': $('#cbZonanavale').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDepe').val(),
                                    'InvestigacionContrainteligenciaProducida': $('#txtNroInvestigContrae').val(),
                                    'CodigoTipoEstudioContrainteligencia': $('#cbTipoEstudioContrae').val(),
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
                                    $('#tblDintemarEstudioContraintelPersonalExterno').DataTable().ajax.reload();
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

        tblDintemarEstudioContraintelPersonalExterno = $('#tblDintemarEstudioContraintelPersonalExterno').DataTable({
        ajax: {
            "url": '/DintemarEstudioContraintelPersonalExterno/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "estudioContrainteligenciaPersonalExternoId" },
            { "data": "nombrePais" },
            { "data": "descTipoVinculo" },
            { "data": "descDependencia" },
            { "data": "descZonaNaval" },
            { "data": "descComandanciaDependencia" },
            { "data": "investigacionContrainteligenciaProducida" },
            { "data": "descTipoEstudioContrainteligencia" },
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.estudioContrainteligenciaPersonalExternoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.estudioContrainteligenciaPersonalExternoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dintemar - Estudios de Contrainteligencia a Personal Externo a la Institución',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dintemar - Estudios de Contrainteligencia a Personal Externo a la Institución',
                title: 'Dintemar - Estudios de Contrainteligencia a Personal Externo a la Institución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dintemar - Estudios de Contrainteligencia a Personal Externo a la Institución',
                title: 'Dintemar - Estudios de Contrainteligencia a Personal Externo a la Institución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dintemar - Estudios de Contrainteligencia a Personal Externo a la Institución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    tblDintemarEstudioContraintelPersonalExterno.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDintemarEstudioContraintelPersonalExterno.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DintemarEstudioContraintelPersonalExterno/Mostrar?Id=' + Id, [], function (EstudioContraintelPersonalExternoDTO) {
        $('#txtCodigo').val(EstudioContraintelPersonalExternoDTO.estudioContrainteligenciaPersonalExternoId);
        $('#cbPaisUbigeoe').val(EstudioContraintelPersonalExternoDTO.numericoPais);
        $('#cbTipoVinculoe').val(EstudioContraintelPersonalExternoDTO.codigoTipoVinculo);
        $('#cbDependenciae').val(EstudioContraintelPersonalExternoDTO.codigoDependencia);
        $('#cbZonanavale').val(EstudioContraintelPersonalExternoDTO.codigoZonaNaval);
        $('#cbComandanciaDepe').val(EstudioContraintelPersonalExternoDTO.codigoComandanciaDependencia);
        $('#txtNroInvestigContrae').val(EstudioContraintelPersonalExternoDTO.investigacionContrainteligenciaProducida);
        $('#cbTipoEstudioContrae').val(EstudioContraintelPersonalExternoDTO.codigoTipoEstudioContrainteligencia);
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
                url: '/DintemarEstudioContraintelPersonalExterno/Eliminar',
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
                    $('#tblDintemarEstudioContraintelPersonalExterno').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDintemarEstudioContraintelPersonalExterno() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DintemarEstudioContraintelPersonalExterno/MostrarDatos',
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
                            $("<td>").text(item.numericoPais),
                            $("<td>").text(item.codigoTipoVinculo),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoComandanciaDependencia),
                            $("<td>").text(item.investigacionContrainteligenciaProducida),
                            $("<td>").text(item.codigoTipoEstudioContrainteligencia),
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
    fetch("DintemarEstudioContraintelPersonalExterno/EnviarDatos", {
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
    $.getJSON('/DintemarEstudioContraintelPersonalExterno/cargaCombs', [], function (Json) {
        var paisUbigeo = Json["data1"];
        var tipoVinculo = Json["data2"];
        var dependencia = Json["data3"];
        var zonaNaval = Json["data4"];
        var tioestuiocontra = Json["data5"];
        var comandanciadependencia = Json["data6"];
        var listaCargas = Json["data7"];


        $("select#cbPaisUbigeo").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numericoPais + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeo").append(RowContent);
        });
        $("select#cbPaisUbigeoe").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numericoPais + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeoe").append(RowContent);
        });

        $("select#cbTipoVinculo").html("");
        $.each(tipoVinculo, function () {
            var RowContent = '<option value=' + this.codigoTipoVinculo + '>' + this.descTipoVinculo + '</option>'
            $("select#cbTipoVinculo").append(RowContent);
        });
        $("select#cbTipoVinculoe").html("");
        $.each(tipoVinculo, function () {
            var RowContent = '<option value=' + this.codigoTipoVinculo + '>' + this.descTipoVinculo + '</option>'
            $("select#cbTipoVinculoe").append(RowContent);
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

        $("select#cbTipoEstudioContra").html("");
        $.each(tioestuiocontra, function () {
            var RowContent = '<option value=' + this.codigoTipoEstudioContrainteligencia + '>' + this.descTipoEstudioContrainteligencia + '</option>'
            $("select#cbTipoEstudioContra").append(RowContent);
        });
        $("select#cbTipoEstudioContrae").html("");
        $.each(tioestuiocontra, function () {
            var RowContent = '<option value=' + this.codigoTipoEstudioContrainteligencia + '>' + this.descTipoEstudioContrainteligencia + '</option>'
            $("select#cbTipoEstudioContrae").append(RowContent);
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
        reporteSeleccionado = '/DintemarEstudioContraintelPersonalExterno/ReporteDECPE?idCarga=';
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
