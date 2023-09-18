var tblComoperpacNumeroUnidadFuerzaNaval;
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
                                url: '/ComoperpacNumeroUnidadFuerzaNaval/Insertar',
                                data: {
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDependencia').val(),
                                    'CodigoUnidadBelica': $('#cbUnidadBelica').val(),
                                    'CodigoEstadoOperativo': $('#cbEstadoOperativo').val(),
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
                                    $('#tblComoperpacNumeroUnidadFuerzaNaval').DataTable().ajax.reload();
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
                                url: '/ComoperpacNumeroUnidadFuerzaNaval/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDependenciae').val(),
                                    'CodigoUnidadBelica': $('#cbUnidadBelicae').val(),
                                    'CodigoEstadoOperativo': $('#cbEstadoOperativoe').val(), 
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
                                    $('#tblComoperpacNumeroUnidadFuerzaNaval').DataTable().ajax.reload();
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

    tblComoperpacNumeroUnidadFuerzaNaval = $('#tblComoperpacNumeroUnidadFuerzaNaval').DataTable({
        ajax: {
            "url": '/ComoperpacNumeroUnidadFuerzaNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "numeroUnidadFuerzaNavalId" },
            { "data": "descComandanciaDependencia" },
            { "data": "descUnidadBelica" },
            { "data": "descEstadoOperativo" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.numeroUnidadFuerzaNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.numeroUnidadFuerzaNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperpac - Número de Unidades Navales, Aeronavales y Pelotones Operativas de las Fuerzas Navales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperpac - Número de Unidades Navales, Aeronavales y Pelotones Operativas de las Fuerzas Navales',
                title: 'Comoperpac - Número de Unidades Navales, Aeronavales y Pelotones Operativas de las Fuerzas Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperpac - Número de Unidades Navales, Aeronavales y Pelotones Operativas de las Fuerzas Navales',
                title: 'Comoperpac - Número de Unidades Navales, Aeronavales y Pelotones Operativas de las Fuerzas Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperpac - Número de Unidades Navales, Aeronavales y Pelotones Operativas de las Fuerzas Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3]
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
    tblComoperpacNumeroUnidadFuerzaNaval.columns(4).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComoperpacNumeroUnidadFuerzaNaval.columns(4).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComoperpacNumeroUnidadFuerzaNaval/Mostrar?Id=' + Id, [], function (NumeroUnidadFuerzaNavalDTO) {
        $('#txtCodigo').val(NumeroUnidadFuerzaNavalDTO.numeroUnidadFuerzaNavalId);
        $('select#cbComandanciaDependenciae option[value=' + NumeroUnidadFuerzaNavalDTO.codigoComandanciaDependencia + ']').prop("selected", "true");
        $('#cbUnidadBelicae').val(NumeroUnidadFuerzaNavalDTO.codigoUnidadBelica);
        $('#cbEstadoOperativoe').val(NumeroUnidadFuerzaNavalDTO.codigoEstadoOperativo); 
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
                url: '/ComoperpacNumeroUnidadFuerzaNaval/Eliminar',
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
                    $('#tblComoperpacNumeroUnidadFuerzaNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
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
                url: '/ComoperpacNumeroUnidadFuerzaNaval/EliminarCarga',
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
                    $('#tblComoperpacNumeroUnidadFuerzaNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComoperpacNumeroUnidadFuerzaNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComoperpacNumeroUnidadFuerzaNaval/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.codigoComandanciaDependencia),
                            $("<td>").text(item.codigoUnidadBelica),
                            $("<td>").text(item.codigoEstadoOperativo),

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
    fetch("ComoperpacNumeroUnidadFuerzaNaval/EnviarDatos", {
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
                    'Ocurrio un problema. ' + mensaje,
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/ComoperpacNumeroUnidadFuerzaNaval/cargaCombs', [], function (Json) {
        var comandanciaDependencia = Json["data1"];
        var unidadBelica = Json["data2"];
        var estadoOperativo = Json["data3"];
        var listaCargas = Json["data4"];

        $("select#cbComandanciaDependencia").html("");
        $("select#cbComandanciaDependenciae").html("");
        $.each(comandanciaDependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDependencia").append(RowContent);
            $("select#cbComandanciaDependenciae").append(RowContent);
        });

        $("select#cbUnidadBelica").html("");
        $("select#cbUnidadBelicae").html("");
        $.each(unidadBelica, function () {
            var RowContent = '<option value=' + this.codigoUnidadBelica + '>' + this.descUnidadBelica + '</option>'
            $("select#cbUnidadBelica").append(RowContent);
            $("select#cbUnidadBelicae").append(RowContent);
        });

        $("select#cbEstadoOperativo").html("");
        $("select#cbEstadoOperativoe").html("");
        $.each(estadoOperativo, function () {
            var RowContent = '<option value=' + this.codigoEstadoOperativo + '>' + this.descEstadoOperativo + '</option>'
            $("select#cbEstadoOperativo").append(RowContent);
            $("select#cbEstadoOperativoe").append(RowContent);
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

    reporteSeleccionado = '/ComoperpacNumeroUnidadFuerzaNaval/ReporteARTR';
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

