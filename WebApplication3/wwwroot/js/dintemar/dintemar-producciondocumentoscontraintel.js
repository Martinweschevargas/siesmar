var tblDintemarProduccionDocumentosContraintel;
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
                                url: '/DintemarProduccionDocumentosContraintel/Insertar',
                                data: {
                                    'NumeroMes': $('#cbMes').val(),
                                    'AnioProduccionDocumento': $('#txtAnio').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDep').val(),
                                    'CodigoZonaNaval': $('#cbZonanaval').val(),
                                    'NotasInformacionContrainteligencia': $('#txtNroInfoComb').val(),
                                    'NotasContrainteligenciaProducidas': $('#txtNroNotasContra').val(),
                                    'ApreciacionesContrainteligenciaProducida': $('#txtNroApelacionContra').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'Fecha': $('#txtFecha').val(),
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
                                    $('#tblDintemarProduccionDocumentosContraintel').DataTable().ajax.reload();
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
                                url: '/DintemarProduccionDocumentosContraintel/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'AnioProduccionDocumento': $('#txtAnioe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDepe').val(),
                                    'CodigoZonaNaval': $('#cbZonanavale').val(),
                                    'NotasInformacionContrainteligencia': $('#txtNroInfoCombe').val(),
                                    'NotasContrainteligenciaProducidas': $('#txtNroNotasContrae').val(),
                                    'ApreciacionesContrainteligenciaProducida': $('#txtNroApelacionContrae').val(),
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
                                    $('#tblDintemarProduccionDocumentosContraintel').DataTable().ajax.reload();
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


        tblDintemarProduccionDocumentosContraintel = $('#tblDintemarProduccionDocumentosContraintel').DataTable({
        ajax: {
            "url": '/DintemarProduccionDocumentosContraintel/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "produccionDocumentosContrainteligenciaId" },
            { "data": "descMes" },
            { "data": "anioProduccionDocumento" },
            { "data": "descDependencia" },
            { "data": "descComandanciaDependencia" },
            { "data": "descZonaNaval" },
            { "data": "notasInformacionContrainteligencia" },
            { "data": "notasContrainteligenciaProducidas" },
            { "data": "apreciacionesContrainteligenciaProducida" },
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.produccionDocumentosContrainteligenciaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.produccionDocumentosContrainteligenciaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dintemar - Producción de Documentos de Contrainteligencia',
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
                filename: 'Dintemar - Producción de Documentos de Contrainteligencia',
                title: 'Dintemar - Producción de Documentos de Contrainteligencia',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dintemar - Producción de Documentos de Contrainteligencia',
                title: 'Dintemar - Producción de Documentos de Contrainteligencia',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dintemar - Producción de Documentos de Contrainteligencia',
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
    tblDintemarProduccionDocumentosContraintel.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDintemarProduccionDocumentosContraintel.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DintemarProduccionDocumentosContraintel/Mostrar?Id=' + Id, [], function (ProduccionDocumentosContraintelDTO) {
        $('#txtCodigo').val(ProduccionDocumentosContraintelDTO.produccionDocumentosContrainteligenciaId);
        $('#cbMese').val(ProduccionDocumentosContraintelDTO.numeroMes);
        $('#txtAnioe').val(ProduccionDocumentosContraintelDTO.anioProduccionDocumento);
        $('#cbDependenciae').val(ProduccionDocumentosContraintelDTO.codigoDependencia);
        $('#cbComandanciaDepe').val(ProduccionDocumentosContraintelDTO.codigoComandanciaDependencia);
        $('#cbZonanavale').val(ProduccionDocumentosContraintelDTO.codigoZonaNaval);
        $('#txtNroInfoCombe').val(ProduccionDocumentosContraintelDTO.notasInformacionContrainteligencia);
        $('#txtNroNotasContrae').val(ProduccionDocumentosContraintelDTO.notasContrainteligenciaProducidas);
        $('#txtNroApelacionContrae').val(ProduccionDocumentosContraintelDTO.apreciacionesContrainteligenciaProducida);
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
                url: '/DintemarProduccionDocumentosContraintel/Eliminar',
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
                    $('#tblDintemarProduccionDocumentosContraintel').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDintemarProduccionDocumentosContraintel() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DintemarProduccionDocumentosContraintel/MostrarDatos',
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
                            $("<td>").text(item.numeroMes),
                            $("<td>").text(item.anioProduccionDocumento),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoComandanciaDependencia),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.notasInformacionContrainteligencia),
                            $("<td>").text(item.notasContrainteligenciaProducidas),
                            $("<td>").text(item.apreciacionesContrainteligenciaProducida),
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
    fetch("DintemarProduccionDocumentosContraintel/EnviarDatos", {
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
    $.getJSON('/DintemarProduccionDocumentosContraintel/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var zonaNaval = Json["data2"];
        var dependencia = Json["data3"];
        var comandanciadependencia = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbMes").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
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
                url: '/DintemarProduccionDocumentosContraintel/EliminarCarga',
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
                    cargaDatos();
                    $('#tblDintemarProduccionDocumentosContraintel').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DintemarProduccionDocumentosContraintel/ReporteDPDC?idCarga=';
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