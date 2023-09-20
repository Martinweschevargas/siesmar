var tblComescuamaAlistamientoMaterial;
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
                                url: '/ComescuamaAlistamientoMaterial/Insertar',
                                data: {
                                    'CodigoUnidadComescuama': $('#cbUnidadNaval').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativa').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3N').val(),
                                    'CodigoAlistamientoMaterialRequeridoComescuama': $('#cbAlistMaterialRequeridoComescuama').val(),
                                    'PonderadoFuncional': $('#txtPonderadoFuncional').val(),
                                    'NivelAlistamientoParcial': $('#txtNivelAlistamientoParcial').val(),
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
                                    $('#tblComescuamaAlistamientoMaterial').DataTable().ajax.reload();
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
                                url: '/ComescuamaAlistamientoMaterial/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadComescuama': $('#cbUnidadNavale').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativae').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3Ne').val(),
                                    'CodigoAlistamientoMaterialRequeridoComescuama': $('#cbAlistMaterialRequeridoComescuamae').val(),
                                    'PonderadoFuncional': $('#txtPonderadoFuncionale').val(),
                                    'NivelAlistamientoParcial': $('#txtNivelAlistamientoParciale').val(),
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
                                    $('#tblComescuamaAlistamientoMaterial').DataTable().ajax.reload();
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

    tblComescuamaAlistamientoMaterial = $('#tblComescuamaAlistamientoMaterial').DataTable({
        ajax: {
            "url": '/ComescuamaAlistamientoMaterial/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialId" },
            { "data": "descUnidadComescuama" },
            { "data": "descCapacidadOperativa" },
            { "data": "capacidadIntrinseca" },
            { "data": "ponderado1N" },
            { "data": "subclasificacion2N" },
            { "data": "ponderado2Nivel" },
            { "data": "subclasificacion3N" },
            { "data": "ponderado3Nivel" },
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "porcentajeOperatividad" },
            { "data": "ponderadoFuncional" },
            { "data": "nivelAlistamientoParcial" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comescuama - Alistamiento de Material',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comescuama - Alistamiento de Material',
                title: 'Comescuama - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescuama - Alistamiento de Material',
                title: 'Comescuama - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescuama - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
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
    tblComescuamaAlistamientoMaterial.columns(14).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComescuamaAlistamientoMaterial.columns(14).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComescuamaAlistamientoMaterial/Mostrar?Id=' + Id, [], function (AlistamientoMaterialComescuamaDTO) {
        $('#txtCodigo').val(AlistamientoMaterialComescuamaDTO.alistamientoMaterialId);
        $('#cbUnidadNavale').val(AlistamientoMaterialComescuamaDTO.codigoUnidadComescuama);
        $('#cbCapacidadOperativae').val(AlistamientoMaterialComescuamaDTO.codigoCapacidadOperativa);
        $('#cbAlistamientoMaterialRequerido3Ne').val(AlistamientoMaterialComescuamaDTO.codigoAlistamientoMaterialRequerido3N);
        $('#cbAlistMaterialRequeridoComescuamae').val(AlistamientoMaterialComescuamaDTO.codigoAlistamientoMaterialRequeridoComescuama);
        $('#txtPonderadoFuncionale').val(AlistamientoMaterialComescuamaDTO.ponderadoFuncional);
        $('#txtNivelAlistamientoParciale').val(AlistamientoMaterialComescuamaDTO.nivelAlistamientoParcial);
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
                url: '/ComescuamaAlistamientoMaterial/Eliminar',
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
                    $('#tblComescuamaAlistamientoMaterial').DataTable().ajax.reload();
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
                url: '/ComescuamaAlistamientoMaterial/EliminarCarga',
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
                    $('#tblComescuamaAlistamientoMaterial').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComescuamaAlistamientoMaterial() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComescuamaAlistamientoMaterial/MostrarDatos',
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
                            $("<td>").text(item.codigoUnidadComescuama),
                            $("<td>").text(item.codigoCapacidadOperativa),
                            $("<td>").text(item.codigoAlistamientoMaterialRequerido3N),
                            $("<td>").text(item.codigoAlistamientoMaterialRequeridoComescuama),
                            $("<td>").text(item.ponderadoFuncional),
                            $("<td>").text(item.nivelAlistamientoParcial)
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
    fetch("ComescuamaAlistamientoMaterial/EnviarDatos", {
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
    $.getJSON('/ComescuamaAlistamientoMaterial/cargaCombs', [], function (Json) {
        var UnidadComescuama = Json["data1"];
        var CapacidadOperativa = Json["data2"];
        var AlistMaterialRequerido3N = Json["data3"];
        var AlistMaterialRequeridoComescuama = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(UnidadComescuama, function () {
            var RowContent = '<option value=' + this.codigoUnidadComescuama + '>' + this.descUnidadComescuama + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbCapacidadOperativa").html("");
        $("select#cbCapacidadOperativae").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativa + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
            $("select#cbCapacidadOperativae").append(RowContent);
        });

        $("select#cbAlistamientoMaterialRequerido3N").html("");
        $("select#cbAlistamientoMaterialRequerido3Ne").html("");
        $.each(AlistMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido3N + '>' + this.codigoAlistamientoMaterialRequerido3N + '</option>'
            $("select#cbAlistamientoMaterialRequerido3N").append(RowContent);
            $("select#cbAlistamientoMaterialRequerido3Ne").append(RowContent);
        });

        $("select#cbAlistMaterialRequeridoComescuama").html("");
        $("select#cbAlistMaterialRequeridoComescuamae").html("");
        $.each(AlistMaterialRequeridoComescuama, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequeridoComescuama + '>' + this.codigoAlistamientoMaterialRequeridoComescuama + '</option>'
            $("select#cbAlistMaterialRequeridoComescuama").append(RowContent);
            $("select#cbAlistMaterialRequeridoComescuamae").append(RowContent);
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

    reporteSeleccionado = '/ComescuamaAlistamientoMaterial/ReporteARTR';
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

