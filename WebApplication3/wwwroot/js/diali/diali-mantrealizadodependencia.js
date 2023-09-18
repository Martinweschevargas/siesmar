var tblDialiMantRealizadoDependencia;
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
                                url: '/DialiMantRealizadoDependencia/Insertar',
                                data: {
                                    'TipoUnidadMantenimiento': $('#txtTipoUnidadM').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'TareaProgramada': $('#txtTareaProgramada').val(),
                                    'TareaEjecutada': $('#txtTareaEjecutada').val(),
                                    'TareaNoEjecutada': $('#txtTareaNoE').val(),
                                    'TNEFaltapersonal': $('#txtTNEFaltaP').val(),
                                    'TNEFaltaTiempo': $('#txtTNEFaltaT').val(),
                                    'TNEFaltaRepuesto': $('#txtTNEFaltaR').val(),
                                    'TNEFaltaMaterial': $('#txtTNEFaltaM').val(),
                                    'TNEFaltaPresupuesto': $('#txtTNEFaltaPres').val(),
                                    'TNEFaltaHerramienta': $('#txtTNEFaltaH').val(),
                                    'TNEFaltaInstrumento': $('#txtTNEFaltaInst').val(),
                                    'TNEFaltaConocimiento': $('#txtTNEFaltaC').val(),
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
                                    $('#tblDialiMantRealizadoDependencia').DataTable().ajax.reload();
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
                                url: '/DialiMantRealizadoDependencia/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoUnidadMantenimiento': $('#txtTipoUnidadMe').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'TareaProgramada': $('#txtTareaProgramadae').val(),
                                    'TareaEjecutada': $('#txtTareaEjecutadae').val(),
                                    'TareaNoEjecutada': $('#txtTareaNoEe').val(),
                                    'TNEFaltapersonal': $('#txtTNEFaltaPe').val(),
                                    'TNEFaltaTiempo': $('#txtTNEFaltaTe').val(),
                                    'TNEFaltaRepuesto': $('#txtTNEFaltaRe').val(),
                                    'TNEFaltaMaterial': $('#txtTNEFaltaMe').val(),
                                    'TNEFaltaPresupuesto': $('#txtTNEFaltaPrese').val(),
                                    'TNEFaltaHerramienta': $('#txtTNEFaltaHe').val(),
                                    'TNEFaltaInstrumento': $('#txtTNEFaltaInste').val(),
                                    'TNEFaltaConocimiento': $('#txtTNEFaltaCe').val(),
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
                                    $('#tblDialiMantRealizadoDependencia').DataTable().ajax.reload();
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

    tblDialiMantRealizadoDependencia = $('#tblDialiMantRealizadoDependencia').DataTable({
        ajax: {
            "url": '/DialiMantRealizadoDependencia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "mantenimientoDependUnidId" },
            { "data": "tipoUnidadMantenimiento" },
            { "data": "descUnidadNaval" },
            { "data": "descMes" },
            { "data": "tareaProgramada" },
            { "data": "tareaEjecutada" },
            { "data": "tareaNoEjecutada" },
            { "data": "tneFaltapersonal" },
            { "data": "tneFaltaTiempo" },  
            { "data": "tneFaltaRepuesto" },
            { "data": "tneFaltaMaterial" },
            { "data": "tneFaltaPresupuesto" },
            { "data": "tneFaltaHerramienta" },
            { "data": "tneFaltaInstrumento" },
            { "data": "tneFaltaConocimiento" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.mantenimientoDependUnidId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.mantenimientoDependUnidId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diali - Mantenimiento Realizado a las Unidades y Dependencias Navales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diali - Mantenimiento Realizado a las Unidades y Dependencias Navales',
                title: 'Diali - Mantenimiento Realizado a las Unidades y Dependencias Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diali - Mantenimiento Realizado a las Unidades y Dependencias Navales',
                title: 'Diali - Mantenimiento Realizado a las Unidades y Dependencias Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diali - Mantenimiento Realizado a las Unidades y Dependencias Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
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
    tblDialiMantRealizadoDependencia.columns(15).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDialiMantRealizadoDependencia.columns(15).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DialiMantRealizadoDependencia/Mostrar?Id=' + Id, [], function (MantenimientoRealizadoDependenciaDTO) {
        $('#txtCodigo').val(MantenimientoRealizadoDependenciaDTO.mantenimientoDependUnidId);
        $('#txtTipoUnidadMe').val(MantenimientoRealizadoDependenciaDTO.tipoUnidadMantenimiento);
        $('#cbUnidadNavale').val(MantenimientoRealizadoDependenciaDTO.codigoUnidadNaval);
        $('#cbMese').val(MantenimientoRealizadoDependenciaDTO.numeroMes);
        $('#txtTareaProgramadae').val(MantenimientoRealizadoDependenciaDTO.tareaProgramada);
        $('#txtTareaEjecutadae').val(MantenimientoRealizadoDependenciaDTO.tareaEjecutada);
        $('#txtTareaNoEe').val(MantenimientoRealizadoDependenciaDTO.tareaNoEjecutada);
        $('#txtTNEFaltaPe').val(MantenimientoRealizadoDependenciaDTO.tneFaltapersonal);
        $('#txtTNEFaltaTe').val(MantenimientoRealizadoDependenciaDTO.tneFaltaTiempo);
        $('#txtTNEFaltaRe').val(MantenimientoRealizadoDependenciaDTO.tneFaltaRepuesto);
        $('#txtTNEFaltaMe').val(MantenimientoRealizadoDependenciaDTO.tneFaltaMaterial);
        $('#txtTNEFaltaPrese').val(MantenimientoRealizadoDependenciaDTO.tneFaltaPresupuesto);
        $('#txtTNEFaltaHe').val(MantenimientoRealizadoDependenciaDTO.tneFaltaHerramienta);
        $('#txtTNEFaltaInste').val(MantenimientoRealizadoDependenciaDTO.tneFaltaInstrumento);
        $('#txtTNEFaltaCe').val(MantenimientoRealizadoDependenciaDTO.tneFaltaConocimiento);
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
                url: '/DialiMantRealizadoDependencia/Eliminar',
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
                    $('#tblDialiMantRealizadoDependencia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDialiMantRealizadoDependencia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DialiMantRealizadoDependencia/MostrarDatos',
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
                            $("<td>").text(item.tipoUnidadMantenimiento),
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.numeroMes),
                            $("<td>").text(item.tareaProgramada),
                            $("<td>").text(item.tareaEjecutada),
                            $("<td>").text(item.tareaNoEjecutada),
                            $("<td>").text(item.tneFaltapersonal),
                            $("<td>").text(item.tneFaltaTiempo),
                            $("<td>").text(item.tneFaltaRepuesto),
                            $("<td>").text(item.tneFaltaMaterial),
                            $("<td>").text(item.tneFaltaPresupuesto),
                            $("<td>").text(item.tneFaltaHerramienta),
                            $("<td>").text(item.tneFaltaInstrumento),
                            $("<td>").text(item.tneFaltaConocimiento)
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
    fetch("DialiMantRealizadoDependencia/EnviarDatos", {
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
                url: '/DialiMantRealizadoDependencia/EliminarCarga',
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
                    $('#tblDialiMantRealizadoDependencia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DialiMantRealizadoDependencia/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var mes = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
            $("select#cbMese").append(RowContent);

        });

        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
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

    reporteSeleccionado = '/DialiMantRealizadoDependencia/ReporteARTR';
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