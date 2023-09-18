var tblDintemarDocumentoIntelFrenteExterno;
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
                                url: '/DintemarDocumentoIntelFrenteExterno/Insertar',
                                data: {
                                    'MesId': $('#cbMes').val(),
                                    'AnioDocumentoFrenteExterno': $('#txtAnio').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoZonaNaval': $('#cbZonanaval').val(),
                                    'NumericoPais': $('#cbPais').val(),
                                    'NotaInformacionProducidasFE': $('#txtNotaInfoProd').val(),
                                    'NotaInteligenciaFE': $('#txtNotaIntelig').val(),
                                    'ApreciacionInteligenciaFE': $('#txtApreciacionIntel').val(),
                                    'ResumenMensualInteligenciaFE': $('#txtNotasInfoContra').val(),
                                    'EstudioInteligenciaFE': $('#txtResMensualI').val(),
                                    'BoletinInformacionFE': $('#txtBoletinI').val(),
                                    'OtrosEspecificarFE': $('#txtOtros').val(),
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
                                    $('#tblDintemarDocumentoIntelFrenteExterno').DataTable().ajax.reload();
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
                                url: '/DintemarDocumentoIntelFrenteExterno/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'MesId': $('#cbMese').val(),
                                    'AnioDocumentoFrenteExterno': $('#txtAnioe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoZonaNaval': $('#cbZonanavale').val(),
                                    'NumericoPais': $('#cbPaise').val(),
                                    'NotaInformacionProducidasFE': $('#txtNotaInfoProde').val(),
                                    'NotaInteligenciaFE': $('#txtNotaIntelige').val(),
                                    'ApreciacionInteligenciaFE': $('#txtApreciacionIntele').val(),
                                    'ResumenMensualInteligenciaFE': $('#txtNotasInfoContrae').val(),
                                    'EstudioInteligenciaFE': $('#txtResMensualIe').val(),
                                    'BoletinInformacionFE': $('#txtBoletinIe').val(),
                                    'OtrosEspecificarFE': $('#txtOtrose').val(),
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
                                    $('#tblDintemarDocumentoIntelFrenteExterno').DataTable().ajax.reload();
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

        tblDintemarDocumentoIntelFrenteExterno = $('#tblDintemarDocumentoIntelFrenteExterno').DataTable({
        ajax: {
            "url": '/DintemarDocumentoIntelFrenteExterno/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "documentoInteligenciaFrenteExternoId" },
            { "data": "descMes" },
            { "data": "anioDocumentoFrenteExterno" },
            { "data": "descDependencia" },
            { "data": "descZonaNaval" },
            { "data": "nombrePais" },
            { "data": "notaInformacionProducidasFE" },
            { "data": "notaInteligenciaFE" },
            { "data": "apreciacionInteligenciaFE" },
            { "data": "resumenMensualInteligenciaFE" },
            { "data": "estudioInteligenciaFE" },
            { "data": "boletinInformacionFE" },
            { "data": "otrosEspecificarFE" },
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.documentoInteligenciaFrenteExternoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.documentoInteligenciaFrenteExternoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dintemar - Producción de Documentos de Inteligencia para el Frente Externo de la Marina de Guerra del Perú',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dintemar - Producción de Documentos de Inteligencia para el Frente Externo de la Marina de Guerra del Perú',
                title: 'Dintemar - Producción de Documentos de Inteligencia para el Frente Externo de la Marina de Guerra del Perú',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dintemar - Producción de Documentos de Inteligencia para el Frente Externo de la Marina de Guerra del Perú',
                title: 'Dintemar - Producción de Documentos de Inteligencia para el Frente Externo de la Marina de Guerra del Perú',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dintemar - Producción de Documentos de Inteligencia para el Frente Externo de la Marina de Guerra del Perú',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
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
    tblDintemarDocumentoIntelFrenteExterno.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDintemarDocumentoIntelFrenteExterno.columns(13).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DintemarDocumentoIntelFrenteExterno/Mostrar?Id=' + Id, [], function (DocumentoIntelFrenteExternoDTO) {
        $('#txtCodigo').val(DocumentoIntelFrenteExternoDTO.documentoInteligenciaFrenteExternoId);
        $('#txtMese').val(DocumentoIntelFrenteExternoDTO.mesId);
        $('#txtAnioe').val(DocumentoIntelFrenteExternoDTO.anioDocumentoFrenteExterno);
        $('#cbDependenciae').val(DocumentoIntelFrenteExternoDTO.codigoDependencia);
        $('#cbZonanavale').val(DocumentoIntelFrenteExternoDTO.codigoZonaNaval);
        $('#cbPaise').val(DocumentoIntelFrenteExternoDTO.numericoPais);
        $('#txtNotaInfoProde').val(DocumentoIntelFrenteExternoDTO.notaInformacionProducidasFE);
        $('#txtNotaIntelige').val(DocumentoIntelFrenteExternoDTO.notaInteligenciaFE);
        $('#txtApreciacionIntele').val(DocumentoIntelFrenteExternoDTO.apreciacionInteligenciaFE);
        $('#txtNotasInfoContrae').val(DocumentoIntelFrenteExternoDTO.resumenMensualInteligenciaFE);
        $('#txtResMensualIe').val(DocumentoIntelFrenteExternoDTO.estudioInteligenciaFE);
        $('#txtBoletinIe').val(DocumentoIntelFrenteExternoDTO.boletinInformacionFE);
        $('#txtOtrose').val(DocumentoIntelFrenteExternoDTO.otrosEspecificarFE);
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
                url: '/DintemarDocumentoIntelFrenteExterno/Eliminar',
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
                    $('#tblDintemarDocumentoIntelFrenteExterno').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDintemarDocumentoIntelFrenteExterno() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DintemarDocumentoIntelFrenteExterno/MostrarDatos',
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
                            $("<td>").text(item.mesId),
                            $("<td>").text(item.anioDocumentoFrenteExterno),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.numericoPais),
                            $("<td>").text(item.notaInformacionProducidasFE),
                            $("<td>").text(item.notaInteligenciaFE),
                            $("<td>").text(item.apreciacionInteligenciaFE),
                            $("<td>").text(item.resumenMensualInteligenciaFE),
                            $("<td>").text(item.estudioInteligenciaFE),
                            $("<td>").text(item.boletinInformacionFE),
                            $("<td>").text(item.otrosEspecificarFE),
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
    fetch("DintemarDocumentoIntelFrenteExterno/EnviarDatos", {
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
    $.getJSON('/DintemarDocumentoIntelFrenteExterno/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var dependencia = Json["data2"];
        var zonaNaval = Json["data3"];
        var paisUbigeo = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbMes").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
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

        $("select#cbPais").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numericoPais + '>' + this.nombrePais + '</option>'
            $("select#cbPais").append(RowContent);
        });
        $("select#cbPaise").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numericoPais + '>' + this.nombrePais + '</option>'
            $("select#cbPaise").append(RowContent);
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
        reporteSeleccionado = '/DintemarDocumentoIntelFrenteExterno/ReporteDDIFE?idCarga=';
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