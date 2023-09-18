var tblDintemarDocumentoIntelFrenteInterno;
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
                                url: '/DintemarDocumentoIntelFrenteInterno/Insertar',
                                data: {
                                    'MesId': $('#cbMes').val(),
                                    'AnioDocumentoFrenteInterno': $('#txtAnio').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoZonaNaval': $('#cbZonanaval').val(),
                                    'NotaInformacionProducidoFI': $('#txtNotaInfoProd').val(),
                                    'NotaInteligenciaFI': $('#txtNotaIntelig').val(),
                                    'ApreciacionInteligenciaFI': $('#txtApreciacionIntel').val(),
                                    'ResumenMensualInteligenciaFI': $('#txtNotasInfoContra').val(),
                                    'EstudioInteligenciaFI': $('#txtResMensualI').val(),
                                    'BoletinInformacionFI': $('#txtBoletinI').val(),
                                    'OtrosEspecificarFI': $('#txtOtros').val(),
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
                                    $('#tblDintemarDocumentoIntelFrenteInterno').DataTable().ajax.reload();
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
                                url: '/DintemarDocumentoIntelFrenteInterno/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'MesId': $('#cbMese').val(),
                                    'AnioDocumentoFrenteInterno': $('#txtAnioe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoZonaNaval': $('#cbZonanavale').val(),
                                    'NotaInformacionProducidoFI': $('#txtNotaInfoProde').val(),
                                    'NotaInteligenciaFI': $('#txtNotaIntelige').val(),
                                    'ApreciacionInteligenciaFI': $('#txtApreciacionIntele').val(),
                                    'ResumenMensualInteligenciaFI': $('#txtNotasInfoContrae').val(),
                                    'EstudioInteligenciaFI': $('#txtResMensualIe').val(),
                                    'BoletinInformacionFI': $('#txtBoletinIe').val(),
                                    'OtrosEspecificarFI': $('#txtOtrose').val(),
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
                                    $('#tblDintemarDocumentoIntelFrenteInterno').DataTable().ajax.reload();
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


        tblDintemarDocumentoIntelFrenteInterno = $('#tblDintemarDocumentoIntelFrenteInterno').DataTable({
        ajax: {
            "url": '/DintemarDocumentoIntelFrenteInterno/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "documentoInteligenciaFrenteInternoId" },
            { "data": "descMes" },
            { "data": "anioDocumentoFrenteInterno" },
            { "data": "descDependencia" },
            { "data": "descZonaNaval" },
            { "data": "notaInformacionProducidoFI" },
            { "data": "notaInteligenciaFI" },
            { "data": "apreciacionInteligenciaFI" },
            { "data": "resumenMensualInteligenciaFI" },
            { "data": "estudioInteligenciaFI" },
            { "data": "boletinInformacionFI" },
            { "data": "otrosEspecificarFI" },
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.documentoInteligenciaFrenteInternoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.documentoInteligenciaFrenteInternoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dintemar - Producción de Documentos de Inteligencia Para el Frente Interno de la Marina de Guerra del Perú',
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
                filename: 'Dintemar - Producción de Documentos de Inteligencia Para el Frente Interno de la Marina de Guerra del Perú',
                title: 'Dintemar - Producción de Documentos de Inteligencia Para el Frente Interno de la Marina de Guerra del Perú',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dintemar - Producción de Documentos de Inteligencia Para el Frente Interno de la Marina de Guerra del Perú',
                title: 'Dintemar - Producción de Documentos de Inteligencia Para el Frente Interno de la Marina de Guerra del Perú',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dintemar - Producción de Documentos de Inteligencia Para el Frente Interno de la Marina de Guerra del Perú',
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
    tblDintemarDocumentoIntelFrenteInterno.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDintemarDocumentoIntelFrenteInterno.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DintemarDocumentoIntelFrenteInterno/Mostrar?Id=' + Id, [], function (DocumentoIntelFrenteInternoDTO) {
        $('#txtCodigo').val(DocumentoIntelFrenteInternoDTO.documentoInteligenciaFrenteInternoId);
        $('#txtMese').val(DocumentoIntelFrenteInternoDTO.mesId);
        $('#txtAnioe').val(DocumentoIntelFrenteInternoDTO.anioDocumentoFrenteInterno);
        $('#cbDependenciae').val(DocumentoIntelFrenteInternoDTO.codigoDependencia);
        $('#cbZonanavale').val(DocumentoIntelFrenteInternoDTO.codigoZonaNaval);
        $('#txtNotaInfoProde').val(DocumentoIntelFrenteInternoDTO.notaInformacionProducidoFI);
        $('#txtNotaIntelige').val(DocumentoIntelFrenteInternoDTO.notaInteligenciaFI);
        $('#txtApreciacionIntele').val(DocumentoIntelFrenteInternoDTO.apreciacionInteligenciaFI);
        $('#txtNotasInfoContrae').val(DocumentoIntelFrenteInternoDTO.resumenMensualInteligenciaFI);
        $('#txtResMensualIe').val(DocumentoIntelFrenteInternoDTO.estudioInteligenciaFI);
        $('#txtBoletinIe').val(DocumentoIntelFrenteInternoDTO.boletinInformacionFI);
        $('#txtOtrose').val(DocumentoIntelFrenteInternoDTO.otrosEspecificarFI);
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
                url: '/DintemarDocumentoIntelFrenteInterno/Eliminar',
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
                    $('#tblDintemarDocumentoIntelFrenteInterno').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDintemarDocumentoIntelFrenteInterno() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DintemarDocumentoIntelFrenteInterno/MostrarDatos',
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
                            $("<td>").text(item.anioDocumentoFrenteInterno),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.notaInformacionProducidasFI),
                            $("<td>").text(item.notaInteligenciaFI),
                            $("<td>").text(item.apreciacionInteligenciaFI),
                            $("<td>").text(item.resumenMensualInteligenciaFI),
                            $("<td>").text(item.estudioInteligenciaFI),
                            $("<td>").text(item.boletinInformacionFI),
                            $("<td>").text(item.otrosEspecificarFI),
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
    fetch("DintemarDocumentoIntelFrenteInterno/EnviarDatos", {
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
    $.getJSON('/DintemarDocumentoIntelFrenteInterno/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var dependencia = Json["data2"];
        var zonaNaval = Json["data3"];
        var listaCargas = Json["data4"];

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
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbZonanaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.zonaNavalId + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanaval").append(RowContent);
        });
        $("select#cbZonanavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.zonaNavalId + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanavale").append(RowContent);
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
        reporteSeleccionado = '/DintemarDocumentoIntelFrenteInterno/ReporteDDIFI?idCarga=';
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
