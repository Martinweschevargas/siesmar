var tblDimarRevistaInstitucionalMonitorGrumete;
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
                                url: '/DimarRevistaInstitucionalMonitorGrumete/Insertar',
                                data: {
                                    'CodigoProductoDimar ': $('#cbProductoDimar').val(),
                                    'CodigoFrecuenciaDifusion ': $('#cbFrecuenciaDifusion').val(),
                                    'FechaPublicacion': $('#txtFechaPublicacion').val(),
                                    'NroEdicion': $('#txtNroEdicion').val(),
                                    'CodigoTipoInformacionEmitida ': $('#cbTipoInformacionEmitida').val(),
                                    'CodigoPlataformaMedioComunicacion ': $('#cbPlataformaMedioComunicacion').val(),
                                    'CodigoPublicoObjetivo ': $('#cbPublicoObjetivo').val(),
                                    'CantidadProducida': $('#txtCantidadProducida').val(),  
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
                                    $('#tblDimarRevistaInstitucionalMonitorGrumete').DataTable().ajax.reload();
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
                                url: '/DimarRevistaInstitucionalMonitorGrumete/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoProductoDimar ': $('#cbProductoDimare').val(),
                                    'CodigoFrecuenciaDifusion ': $('#cbFrecuenciaDifusione').val(),
                                    'FechaPublicacion': $('#txtFechaPublicacione').val(),
                                    'NroEdicion': $('#txtNroEdicione').val(),
                                    'CodigoTipoInformacionEmitida ': $('#cbTipoInformacionEmitidae').val(),
                                    'CodigoPlataformaMedioComunicacion ': $('#cbPlataformaMedioComunicacione').val(),
                                    'CodigoPublicoObjetivo ': $('#cbPublicoObjetivoe').val(),
                                    'CantidadProducida': $('#txtCantidadProducidae').val(), 
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
                                    $('#tblDimarRevistaInstitucionalMonitorGrumete').DataTable().ajax.reload();
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


        tblDimarRevistaInstitucionalMonitorGrumete=  $('#tblDimarRevistaInstitucionalMonitorGrumete').DataTable({
        ajax: {
            "url": '/DimarRevistaInstitucionalMonitorGrumete/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "revistaInstitucionalMonitorGrumeteId" },
            { "data": "descProductoDimar" },
            { "data": "descFrecuenciaDifusion" },
            { "data": "fechaPublicacion" },
            { "data": "nroEdicion" },
            { "data": "descTipoInformacionEmitida" },
            { "data": "descPlataformaMedioComunicacion" },
            { "data": "descPublicoObjetivo" },
            { "data": "cantidadProducida" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.revistaInstitucionalMonitorGrumeteId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.revistaInstitucionalMonitorGrumeteId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dimar - Revistas Institucionales “El Monitor” y el “Grumete” ',
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
                filename: 'Dimar - Revistas Institucionales “El Monitor” y el “Grumete” ',
                title: 'Dimar - Revistas Institucionales “El Monitor” y el “Grumete” ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dimar - Revistas Institucionales “El Monitor” y el “Grumete” ',
                title: 'Dimar - Revistas Institucionales “El Monitor” y el “Grumete” ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dimar - Revistas Institucionales “El Monitor” y el “Grumete” ',
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
    tblDimarRevistaInstitucionalMonitorGrumete.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDimarRevistaInstitucionalMonitorGrumete.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DimarRevistaInstitucionalMonitorGrumete/Mostrar?Id=' + Id, [], function (RevistaInstitucionalMonitorGrumeteDTO) {
        $('#txtCodigo').val(RevistaInstitucionalMonitorGrumeteDTO.revistaInstitucionalMonitorGrumeteId);
        $('#cbProductoDimare').val(RevistaInstitucionalMonitorGrumeteDTO.codigoProductoDimar);
        $('#cbFrecuenciaDifusione').val(RevistaInstitucionalMonitorGrumeteDTO.codigoFrecuenciaDifusion);
        $('#txtFechaPublicacione').val(RevistaInstitucionalMonitorGrumeteDTO.fechaPublicacion);
        $('#txtNroEdicione').val(RevistaInstitucionalMonitorGrumeteDTO.nroEdicion);
        $('#cbTipoInformacionEmitidae').val(RevistaInstitucionalMonitorGrumeteDTO.codigoTipoInformacionEmitida);
        $('#cbPlataformaMedioComunicacione').val(RevistaInstitucionalMonitorGrumeteDTO.codigoPlataformaMedioComunicacion);
        $('#cbPublicoObjetivoe').val(RevistaInstitucionalMonitorGrumeteDTO.codigoPublicoObjetivo);
        $('#txtCantidadProducidae').val(RevistaInstitucionalMonitorGrumeteDTO.cantidadProducida); 
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
                url: '/DimarRevistaInstitucionalMonitorGrumete/Eliminar',
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
                    $('#tblDimarRevistaInstitucionalMonitorGrumete').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDimarRevistaInstitucionalMonitorGrumete() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DimarRevistaInstitucionalMonitorGrumete/MostrarDatos',
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
                            $("<td>").text(item.codigoProductoDimar),
                            $("<td>").text(item.codigoFrecuenciaDifusion),
                            $("<td>").text(item.fechaPublicacion),
                            $("<td>").text(item.nroEdicion),
                            $("<td>").text(item.codigoTipoInformacionEmitida),
                            $("<td>").text(item.codigoPlataformaMedioComunicacion),
                            $("<td>").text(item.codigoPublicoObjetivo),
                            $("<td>").text(item.cantidadProducida),
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
    fetch("DimarRevistaInstitucionalMonitorGrumete/EnviarDatos", {
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
    $.getJSON('/DimarRevistaInstitucionalMonitorGrumete/cargaCombs', [], function (Json) {
        var productoDimar = Json["data1"];
        var frecuenciaDifusion = Json["data2"];
        var tipoInformacionEmitida = Json["data3"];
        var plataformaMedioComunicacion = Json["data4"];
        var publicoObjetivo = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbProductoDimar").html("");
        $.each(productoDimar, function () {
            var RowContent = '<option value=' + this.codigoProductoDimar + '>' + this.descProductoDimar + '</option>'
            $("select#cbProductoDimar").append(RowContent);
        });
        $("select#cbProductoDimare").html("");
        $.each(productoDimar, function () {
            var RowContent = '<option value=' + this.codigoProductoDimar + '>' + this.descProductoDimar + '</option>'
            $("select#cbProductoDimare").append(RowContent);
        });


        $("select#cbFrecuenciaDifusion").html("");
        $.each(frecuenciaDifusion, function () {
            var RowContent = '<option value=' + this.codigoFrecuenciaDifusion + '>' + this.descFrecuenciaDifusion + '</option>'
            $("select#cbFrecuenciaDifusion").append(RowContent);
        });
        $("select#cbFrecuenciaDifusione").html("");
        $.each(frecuenciaDifusion, function () {
            var RowContent = '<option value=' + this.codigoFrecuenciaDifusion + '>' + this.descFrecuenciaDifusion + '</option>'
            $("select#cbFrecuenciaDifusione").append(RowContent);
        });


        $("select#cbTipoInformacionEmitida").html("");
        $.each(tipoInformacionEmitida, function () {
            var RowContent = '<option value=' + this.codigoTipoInformacionEmitida + '>' + this.descTipoInformacionEmitida + '</option>'
            $("select#cbTipoInformacionEmitida").append(RowContent);
        });
        $("select#cbTipoInformacionEmitidae").html("");
        $.each(tipoInformacionEmitida, function () {
            var RowContent = '<option value=' + this.codigoTipoInformacionEmitida + '>' + this.descTipoInformacionEmitida + '</option>'
            $("select#cbTipoInformacionEmitidae").append(RowContent);
        });


        $("select#cbPlataformaMedioComunicacion").html("");
        $.each(plataformaMedioComunicacion, function () {
            var RowContent = '<option value=' + this.codigoPlataformaMedioComunicacion + '>' + this.descPlataformaMedioComunicacion + '</option>'
            $("select#cbPlataformaMedioComunicacion").append(RowContent);
        });
        $("select#cbPlataformaMedioComunicacione").html("");
        $.each(plataformaMedioComunicacion, function () {
            var RowContent = '<option value=' + this.codigoPlataformaMedioComunicacion + '>' + this.descPataformaMedioComunicacion + '</option>'
            $("select#cbPlataformaMedioComunicacione").append(RowContent);
        });


        $("select#cbPublicoObjetivo").html("");
        $.each(publicoObjetivo, function () {
            var RowContent = '<option value=' + this.codigoPublicoObjetivo + '>' + this.descPublicoObjetivo + '</option>'
            $("select#cbPublicoObjetivo").append(RowContent);
        });
        $("select#cbPublicoObjetivoe").html("");
        $.each(publicoObjetivo, function () {
            var RowContent = '<option value=' + this.codigoPublicoObjetivo + '>' + this.descPublicoObjetivo + '</option>'
            $("select#cbPublicoObjetivoe").append(RowContent);
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
        reporteSeleccionado = '/DimarRevistaInstitucionalMonitorGrumete/ReporteDRIMG?idCarga=';
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