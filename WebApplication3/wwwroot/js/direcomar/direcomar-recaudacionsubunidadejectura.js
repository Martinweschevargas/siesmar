var tblDirecomarRecaudacionSubunidadEjectura;
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
                                url: '/DirecomarRecaudacionSubunidadEjectura/Insertar',
                                data: {
                                    'AnioRecaudacionSUE': $('#txtAnio').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'CodigoSubunidadEjecutora': $('#cbSUE').val(),
                                    'ProyeccionRecaudacionSUE': $('#txtProyeccion').val(),
                                    'RecaudadoRecaudacionSUE': $('#txtRecaudado').val(),
                                    'MetaRecaudacionSUE': $('#txtMetaRecaudado').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'Fecha': $('#txtFecha').val()
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
                                    $('#tblDirecomarRecaudacionSubunidadEjectura').DataTable().ajax.reload();
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
                                url: '/DirecomarRecaudacionSubunidadEjectura/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioRecaudacionSUE': $('#txtAnioe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'CodigoSubunidadEjecutora': $('#cbSUEe').val(),
                                    'ProyeccionRecaudacionSUE': $('#txtProyeccione').val(),
                                    'RecaudadoRecaudacionSUE': $('#txtRecaudadoe').val(),
                                    'MetaRecaudacionSUE': $('#txtMetaRecaudadoe').val(), 
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
                                    $('#tblDirecomarRecaudacionSubunidadEjectura').DataTable().ajax.reload();
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

        tblDirecomarRecaudacionSubunidadEjectura =  $('#tblDirecomarRecaudacionSubunidadEjectura').DataTable({
        ajax: {
            "url": '/DirecomarRecaudacionSubunidadEjectura/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "recaudacionSubunidadEjecturaId" },
            { "data": "anioRecaudacionSUE" },
            { "data": "descMes" },
            { "data": "descSubUnidadEjecutora" },
            { "data": "proyeccionRecaudacionSUE" },
            { "data": "recaudadoRecaudacionSUE" },
            { "data": "metaRecaudacionSUE" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.recaudacionSubunidadEjecturaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.recaudacionSubunidadEjecturaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Direcomar - Recaudación por Sub Unidad Ejecutora',
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
                filename: 'Direcomar - Recaudación por Sub Unidad Ejecutora',
                title: 'Direcomar - Recaudación por Sub Unidad Ejecutora',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Direcomar - Recaudación por Sub Unidad Ejecutora',
                title: 'Direcomar - Recaudación por Sub Unidad Ejecutora',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Direcomar - Recaudación por Sub Unidad Ejecutora',
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
    tblDirecomarRecaudacionSubunidadEjectura.columns(7).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirecomarRecaudacionSubunidadEjectura.columns(7).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirecomarRecaudacionSubunidadEjectura/Mostrar?Id=' + Id, [], function (RecaudacionSubunidadEjecturaDTO) {
        $('#txtCodigo').val(RecaudacionSubunidadEjecturaDTO.recaudacionSubunidadEjecturaId);
        $('#txtAnioe').val(RecaudacionSubunidadEjecturaDTO.anioRecaudacionSUE);
        $('#cbMese').val(RecaudacionSubunidadEjecturaDTO.numeroMes);
        $('#cbSUEe').val(RecaudacionSubunidadEjecturaDTO.codigoSubunidadEjecutora);
        $('#txtProyeccione').val(RecaudacionSubunidadEjecturaDTO.proyeccionRecaudacionSUE);
        $('#txtRecaudadoe').val(RecaudacionSubunidadEjecturaDTO.recaudadoRecaudacionSUE);
        $('#txtMetaRecaudadoe').val(RecaudacionSubunidadEjecturaDTO.metaRecaudacionSUE);  
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
                url: '/DirecomarRecaudacionSubunidadEjectura/Eliminar',
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
                    $('#tblDirecomarRecaudacionSubunidadEjectura').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}


function nuevaDirecomarRecaudacionSubunidadEjectura() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirecomarRecaudacionSubunidadEjectura/MostrarDatos',
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
                            $("<td>").text(item.anioRecaudacionSUE),
                            $("<td>").text(item.numeroMes),
                            $("<td>").text(item.codigoSubunidadEjecutora),
                            $("<td>").text(item.proyeccionRecaudacionSUE),
                            $("<td>").text(item.recaudadoRecaudacionSUE),
                            $("<td>").text(item.metaRecaudacionSUE),
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
    fetch("DirecomarRecaudacionSubunidadEjectura/EnviarDatos", {
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
                url: '/DirecomarRecaudacionSubunidadEjectura/EliminarCarga',
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
                    $('#tblDirecomarRecaudacionSubunidadEjectura').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DirecomarRecaudacionSubunidadEjectura/cargaCombs', [], function (Json) {
        var Mes = Json["data1"];
        var SubUnidadEjecutora = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(Mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
            $("select#cbMese").append(RowContent);
        });

        $("select#cbSUE").html("");
        $("select#cbSUEe").html("");
        $.each(SubUnidadEjecutora, function () {
            var RowContent = '<option value=' + this.codigoSubUnidadEjecutora + '>' + this.descSubUnidadEjecutora + '</option>'
            $("select#cbSUE").append(RowContent);
            $("select#cbSUEe").append(RowContent);
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

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DirecomarRecaudacionSubunidadEjectura/ReporteRSE';
        $('#fecha').hide();
    }
}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";

    var numCarga;
    if (idCarga == "0") {
        numCarga = '?CargaId=' + "";
    } else {
        numCarga = '?CargaId=' + idCarga;
    }

    if (optReporteSelect == 1) {
        a.href = reporteSeleccionado + numCarga;
    }
    a.click();
});