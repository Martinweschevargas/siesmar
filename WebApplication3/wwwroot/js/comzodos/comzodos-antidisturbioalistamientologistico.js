var tblComzodosAntidisturbioAlistamientoLogistico;
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
                                url: '/ComzodosAntidisturbioAlistamientoLogistico/Insertar',
                                data: {
                                    'CodigoDescripcionMaterial': $('#cbDescripcion').val(),
                                    'MaterialRequerido': $('#txtRequerido').val(),
                                    'MaterialAsignado': $('#txtAsignado').val(),
                                    'CodigoCondicionAlistamientoLogistico': $('#cbCondicion').val(),
                                    'ObservacionAlistamientoLogistico': $('#txtObservacion').val(),
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
                                    $('#tblComzodosAntidisturbioAlistamientoLogistico').DataTable().ajax.reload();
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
                                url: '/ComzodosAntidisturbioAlistamientoLogistico/Actualizar',
                                data: {
                                    'AntidisturbioAlistamientoLogisticoId': $('#txtCodigo').val(),
                                    'CodigoDescripcionMaterial': $('#cbDescripcione').val(),
                                    'MaterialRequerido': $('#txtRequeridoe').val(),
                                    'MaterialAsignado': $('#txtAsignadoe').val(),
                                    'CodigoCondicionAlistamientoLogistico': $('#cbCondicione').val(),
                                    'ObservacionAlistamientoLogistico': $('#txtObservacione').val(), 
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
                                    $('#tblComzodosAntidisturbioAlistamientoLogistico').DataTable().ajax.reload();
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

    tblComzodosAntidisturbioAlistamientoLogistico = $('#tblComzodosAntidisturbioAlistamientoLogistico').DataTable({
        ajax: {
            "url": '/ComzodosAntidisturbioAlistamientoLogistico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "antidisturbioAlistamientoLogisticoId" },
            { "data": "clasificacion" },
            { "data": "materialRequerido" },
            { "data": "materialAsignado" },
            { "data": "descCondicionAlistamientoLogistico" },
            { "data": "observacionAlistamientoLogistico" },
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.antidisturbioAlistamientoLogisticoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.antidisturbioAlistamientoLogisticoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzodos - Número de Operaciones Antidisturbios - Nivel de Alistamiento Logístico de la Compañía Antidisturbios',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comzodos - Número de Operaciones Antidisturbios - Nivel de Alistamiento Logístico de la Compañía Antidisturbios',
                title: 'Comzodos - Número de Operaciones Antidisturbios - Nivel de Alistamiento Logístico de la Compañía Antidisturbios',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzodos - Número de Operaciones Antidisturbios - Nivel de Alistamiento Logístico de la Compañía Antidisturbios',
                title: 'Comzodos - Número de Operaciones Antidisturbios - Nivel de Alistamiento Logístico de la Compañía Antidisturbios',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzodos - Número de Operaciones Antidisturbios - Nivel de Alistamiento Logístico de la Compañía Antidisturbios',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
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
    tblComzodosAntidisturbioAlistamientoLogistico.columns(6).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComzodosAntidisturbioAlistamientoLogistico.columns(6).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzodosAntidisturbioAlistamientoLogistico/Mostrar?Id=' + Id, [], function (AntidisturbioAlistamientoLogisticoDTO) {
        $('#txtCodigo').val(AntidisturbioAlistamientoLogisticoDTO.antidisturbioAlistamientoLogisticoId);
        $('#cbDescripcione').val(AntidisturbioAlistamientoLogisticoDTO.codigoDescripcionMaterial);
        $('#txtRequeridoe').val(AntidisturbioAlistamientoLogisticoDTO.materialRequerido);
        $('#txtAsignadoe').val(AntidisturbioAlistamientoLogisticoDTO.materialAsignado);
        $('#cbCondicione').val(AntidisturbioAlistamientoLogisticoDTO.codigoCondicionAlistamientoLogistico);
        $('#txtObservacione').val(AntidisturbioAlistamientoLogisticoDTO.observacionAlistamientoLogistico); 
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
                url: '/ComzodosAntidisturbioAlistamientoLogistico/Eliminar',
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
                    $('#tblComzodosAntidisturbioAlistamientoLogistico').DataTable().ajax.reload();
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
                url: '/ComzodosAntidisturbioAlistamientoLogistico/EliminarCarga',
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
                    $('#tblComzodosAntidisturbioAlistamientoLogistico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComzodosAntidisturbioAlistamientoLogistico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComzodosAntidisturbioAlistamientoLogistico/MostrarDatos',
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
                            $("<td>").text(item.codigoDescripcionMaterial),
                            $("<td>").text(item.materialRequerido),
                            $("<td>").text(item.materialAsignado),
                            $("<td>").text(item.codigoCondicionAlistamientoLogistico),
                            $("<td>").text(item.observacionAlistamientoLogistico)
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
    fetch("ComzodosAntidisturbioAlistamientoLogistico/EnviarDatos", {
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
                    'Ocurrio un problema.' + mensaje,
                    'error'
                )
            }
        })
}


function cargaDatos() {
    $.getJSON('/ComzodosAntidisturbioAlistamientoLogistico/cargaCombs', [], function (Json) {
        var descripcionMaterial = Json["data1"];
        var condicionAlistamientoLogistico = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbDescripcion").html("");
        $.each(descripcionMaterial, function () {
            var RowContent = '<option value=' + this.codigoDescripcionMaterial + '>' + this.clasificacion + '</option>'
            $("select#cbDescripcion").append(RowContent);
        });
        $("select#cbDescripcione").html("");
        $.each(descripcionMaterial, function () {
            var RowContent = '<option value=' + this.codigoDescripcionMaterial + '>' + this.clasificacion + '</option>'
            $("select#cbDescripcione").append(RowContent);
        });

        $("select#cbCondicion").html("");
        $.each(condicionAlistamientoLogistico, function () {
            var RowContent = '<option value=' + this.codigoCondicionAlistamientoLogistico + '>' + this.descCondicionAlistamientoLogistico + '</option>'
            $("select#cbCondicion").append(RowContent);
        });
        $("select#cbCondicione").html("");
        $.each(condicionAlistamientoLogistico, function () {
            var RowContent = '<option value=' + this.codigoCondicionAlistamientoLogistico + '>' + this.descCondicionAlistamientoLogistico + '</option>'
            $("select#cbCondicione").append(RowContent);
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

    reporteSeleccionado = '/ComzodosAntidisturbioAlistamientoLogistico/ReporteARTR';
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
       

