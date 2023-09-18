var tblDirnotematProcesoInternamiento;

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
                                url: '/DirnotematProcesoInternamiento/Insertar',
                                data: {
                                    'NombreProceso': $('#txtNombreProceso').val(),
                                    'NroContratoProceso': $('#txtNroContrato').val(),
                                    'CodigoTipoProcesoDirnotemat': $('#cbTipoProceso').val(),
                                    'NroProcesoInternamiento': $('#txtNroProcesoI').val(),
                                    'NroguiaProceso': $('#txtNroGuiaProceso').val(),
                                    'FechaIngresoProceso': $('#txtFechaIngreso').val(),
                                    'TiempoEvaluacion': $('#txtTiempoEvaluacion').val(),
                                    'ResultadoEvaluacion': $('#txtResultadoEvaluacion').val(),
                                    'LaboratorioProcesoInternamiento': $('#txtLaboratorio').val(),
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
                                    $('#tblDirnotematProcesoInternamiento').DataTable().ajax.reload();
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
                                url: '/DirnotematProcesoInternamiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NombreProceso': $('#txtNombreProcesoe').val(),
                                    'NroContratoProceso': $('#txtNroContratoe').val(),
                                    'CodigoTipoProcesoDirnotemat': $('#cbTipoProcesoe').val(),
                                    'NroProcesoInternamiento': $('#txtNroProcesoIe').val(),
                                    'NroguiaProceso': $('#txtNroGuiaProcesoe').val(),
                                    'FechaIngresoProceso': $('#txtFechaIngresoe').val(),
                                    'TiempoEvaluacion': $('#txtTiempoEvaluacione').val(),
                                    'ResultadoEvaluacion': $('#txtResultadoEvaluacione').val(),
                                    'LaboratorioProcesoInternamiento': $('#txtLaboratorioe').val(),
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
                                    $('#tblDirnotematProcesoInternamiento').DataTable().ajax.reload();
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

    tblDirnotematProcesoInternamiento = $('#tblDirnotematProcesoInternamiento').DataTable({
        ajax: {
            "url": '/DirnotematProcesoInternamiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "procesoInternamientoId" },
            { "data": "nombreProceso" },
            { "data": "nroContratoProceso" },
            { "data": "descTipoProcesoDirnotemat" },
            { "data": "nroProcesoInternamiento" },
            { "data": "nroguiaProceso" },
            { "data": "fechaIngresoProceso" },
            { "data": "tiempoEvaluacion" },
            { "data": "resultadoEvaluacion" },
            { "data": "laboratorioProcesoInternamiento" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.procesoInternamientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.procesoInternamientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirnotemat - Proceso de Internamiento',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirnotemat - Proceso de Internamiento',
                title: 'Dirnotemat - Proceso de Internamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirnotemat - Proceso de Internamiento',
                title: 'Dirnotemat - Proceso de Internamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirnotemat - Proceso de Internamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
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
    tblDirnotematProcesoInternamiento.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirnotematProcesoInternamiento.columns(10).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirnotematProcesoInternamiento/Mostrar?Id=' + Id, [], function (ProcesoInternamientoDTO) {
        $('#txtCodigo').val(ProcesoInternamientoDTO.procesoInternamientoId);
        $('#txtNombreProcesoe').val(ProcesoInternamientoDTO.nombreProceso);
        $('#txtNroContratoe').val(ProcesoInternamientoDTO.nroContratoProceso);
        $('#cbTipoProcesoe').val(ProcesoInternamientoDTO.codigoTipoProcesoDirnotemat);
        $('#txtNroProcesoIe').val(ProcesoInternamientoDTO.nroProcesoInternamiento);
        $('#txtNroGuiaProcesoe').val(ProcesoInternamientoDTO.nroguiaProceso);
        $('#txtFechaIngresoe').val(ProcesoInternamientoDTO.fechaIngresoProceso);
        $('#txtTiempoEvaluacione').val(ProcesoInternamientoDTO.tiempoEvaluacion);
        $('#txtResultadoEvaluacione').val(ProcesoInternamientoDTO.resultadoEvaluacion);
        $('#txtLaboratorioe').val(ProcesoInternamientoDTO.laboratorioProcesoInternamiento);
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
                url: '/DirnotematProcesoInternamiento/Eliminar',
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
                    $('#tblDirnotematProcesoInternamiento').DataTable().ajax.reload();
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
                url: '/DirnotematProcesoInternamiento/EliminarCarga',
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
                    $('#tblDirnotematProcesoInternamiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDirnotematProcesoInternamiento() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirnotematProcesoInternamiento/MostrarDatos',
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
                            $("<td>").text(item.nombreProceso),
                            $("<td>").text(item.nroContratoProceso),
                            $("<td>").text(item.codigoTipoProcesoDirnotemat),
                            $("<td>").text(item.nroProcesoInternamiento),
                            $("<td>").text(item.nroguiaProceso),
                            $("<td>").text(item.fechaIngresoProceso),
                            $("<td>").text(item.tiempoEvaluacion),
                            $("<td>").text(item.resultadoEvaluacion),
                            $("<td>").text(item.laboratorioProcesoInternamiento)
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
    fetch("DirnotematProcesoInternamiento/EnviarDatos", {
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
    $.getJSON('/DirnotematProcesoInternamiento/cargaCombs', [], function (Json) {
        var TipoProcesoDirnotemat = Json["data1"];
        var listaCargas = Json["data2"];

        $("select#cbTipoProceso").html("");
        $("select#cbTipoProcesoe").html("");
        $.each(TipoProcesoDirnotemat, function () {
            var RowContent = '<option value=' + this.codigoTipoProcesoDirnotemat + '>' + this.descTipoProcesoDirnotemat + '</option>'
            $("select#cbTipoProceso").append(RowContent);
            $("select#cbTipoProcesoe").append(RowContent);
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

