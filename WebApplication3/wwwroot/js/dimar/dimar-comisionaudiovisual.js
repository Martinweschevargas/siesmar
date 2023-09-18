var tblDimarComisionAudiovisual;
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
                                url: '/DimarComisionAudiovisual/Insertar',
                                data: {
                                    'FechaComisionAudiovisual': $('#txtFechaComisionAudiovisual').val(),
                                    'CodigoPersonalComision ': $('#cbPersonalComision').val(),
                                    'CodigoDependencia ': $('#cbDependencia').val(),
                                    'Motivo': $('#txtMotivo').val(),
                                    'CodigoComision ': $('#cbComision').val(),
                                    'Costo': $('#txtCosto').val(), 
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
                                    $('#tblDimarComisionAudiovisual').DataTable().ajax.reload();
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
                                url: '/DimarComisionAudiovisual/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaComisionAudiovisual': $('#txtFechaComisionAudiovisuale').val(),
                                    'CodigoPersonalComision ': $('#cbPersonalComisione').val(),
                                    'CodigoDependencia ': $('#cbDependenciae').val(),
                                    'Motivo': $('#txtMotivoe').val(),
                                    'CodigoComision ': $('#cbComisione').val(),
                                    'Costo': $('#txtCostoe').val(), 
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
                                    $('#tblDimarComisionAudiovisual').DataTable().ajax.reload();
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


        tblDimarComisionAudiovisual=  $('#tblDimarComisionAudiovisual').DataTable({
        ajax: {
            "url": '/DimarComisionAudiovisual/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "comisionAudiovisualId" },
            { "data": "fechaComisionAudiovisual" },
            { "data": "descPersonalComision" },
            { "data": "nombreDependencia" },
            { "data": "motivo" },
            { "data": "descComision" },
            { "data": "costo" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.comisionAudiovisualId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.comisionAudiovisualId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dimar - Comisiones de audiovisuales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dimar - Comisiones de audiovisuales',
                title: 'Dimar - Comisiones de audiovisuales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dimar - Comisiones de audiovisuales',
                title: 'Dimar - Comisiones de audiovisuales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dimar - Comisiones de audiovisuales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
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
    tblDimarComisionAudiovisual.columns(7).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDimarComisionAudiovisual.columns(7).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DimarComisionAudiovisual/Mostrar?Id=' + Id, [], function (ComisionAudiovisualDTO) {
        $('#txtCodigo').val(ComisionAudiovisualDTO.comisionAudiovisualId);
        $('#txtFechaComisionAudiovisuale').val(ComisionAudiovisualDTO.fechaComisionAudiovisual);
        $('#cbPersonalComisione').val(ComisionAudiovisualDTO.codigoPersonalComision);
        $('#cbDependenciae').val(ComisionAudiovisualDTO.codigoDependencia);
        $('#txtMotivoe').val(ComisionAudiovisualDTO.motivo);
        $('#cbComisione').val(ComisionAudiovisualDTO.codigoComision);
        $('#txtCostoe').val(ComisionAudiovisualDTO.costo); 
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
                url: '/DimarComisionAudiovisual/Eliminar',
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
                    $('#tblDimarComisionAudiovisual').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDimarComisionAudiovisual() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DimarComisionAudiovisual/MostrarDatos',
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
                            $("<td>").text(item.fechaComisionAudiovisual),
                            $("<td>").text(item.codigoPersonalComision),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.motivo),
                            $("<td>").text(item.codigoComision),
                            $("<td>").text(item.costo),
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
    fetch("DimarComisionAudiovisual/EnviarDatos", {
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
    $.getJSON('/DimarComisionAudiovisual/cargaCombs', [], function (Json) {
        var personalComision = Json["data1"];
        var dependencia = Json["data2"];
        var comision = Json["data3"];
        var listaCargas = Json["data4"];

        $("select#cbPersonalComision").html("");
        $.each(personalComision, function () {
            var RowContent = '<option value=' + this.codigoPersonalComision + '>' + this.descPersonalComision + '</option>'
            $("select#cbPersonalComision").append(RowContent);
        });
        $("select#cbPersonalComisione").html("");
        $.each(personalComision, function () {
            var RowContent = '<option value=' + this.codigoPersonalComision + '>' + this.descPersonalComision + '</option>'
            $("select#cbPersonalComisione").append(RowContent);
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


        $("select#cbComision").html("");
        $.each(comision, function () {
            var RowContent = '<option value=' + this.codigoComision + '>' + this.descComision + '</option>'
            $("select#cbComision").append(RowContent);
        });
        $("select#cbComisione").html("");
        $.each(comision, function () {
            var RowContent = '<option value=' + this.codigoComision + '>' + this.descComision + '</option>'
            $("select#cbComisione").append(RowContent);
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
        reporteSeleccionado = '/DimarComisionAudiovisual/ReporteDCA?idCarga=';
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