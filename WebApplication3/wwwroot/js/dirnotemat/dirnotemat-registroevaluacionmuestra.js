var tblDirnotematRegistroEvaluacionMuestra;

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
                                url: '/DirnotematRegistroEvaluacionMuestra/Insertar',
                                data: {
                                    'DescProcesoEvaluacion': $('#txtNombreProceso').val(),
                                    'NroProcesoEvaluacion': $('#txtNroProceso').val(),
                                    'NroMuestrasEvaluacion': $('#txtNroMuestra').val(),
                                    'MuestrasCumpleEvaluacion': $('#txtMuestrasCumple').val(),
                                    'MuestaNoCumpleEvaluacion': $('#txtMuestrasNoCumple').val(),
                                    'FechaInicioEvaluacion': $('#txtFechaInicio').val(),
                                    'FechaTerminoEvaluacion': $('#txtFechaTermino').val(),
                                    'LaboratorioEvaluacion': $('#txtLaboratorio').val(),
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
                                    $('#tblDirnotematRegistroEvaluacionMuestra').DataTable().ajax.reload();
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
                                url: '/DirnotematRegistroEvaluacionMuestra/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DescProcesoEvaluacion': $('#txtNombreProcesoe').val(),
                                    'NroProcesoEvaluacion': $('#txtNroProcesoe').val(),
                                    'NroMuestrasEvaluacion': $('#txtNroMuestrae').val(),
                                    'MuestrasCumpleEvaluacion': $('#txtMuestrasCumplee').val(),
                                    'MuestaNoCumpleEvaluacion': $('#txtMuestrasNoCumplee').val(),
                                    'FechaInicioEvaluacion': $('#txtFechaInicioe').val(),
                                    'FechaTerminoEvaluacion': $('#txtFechaTerminoe').val(),
                                    'LaboratorioEvaluacion': $('#txtLaboratorioe').val(),
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
                                    $('#tblDirnotematRegistroEvaluacionMuestra').DataTable().ajax.reload();
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

   tblDirnotematRegistroEvaluacionMuestra = $('#tblDirnotematRegistroEvaluacionMuestra').DataTable({
        ajax: {
            "url": '/DirnotematRegistroEvaluacionMuestra/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroEvaluacionMuestraId" },
            { "data": "descProcesoEvaluacion" },
            { "data": "nroProcesoEvaluacion" },
            { "data": "nroMuestrasEvaluacion" },
            { "data": "muestrasCumpleEvaluacion" },
            { "data": "muestaNoCumpleEvaluacion" },
            { "data": "fechaInicioEvaluacion" },
            { "data": "fechaTerminoEvaluacion" },
            { "data": "laboratorioEvaluacion" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroEvaluacionMuestraId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroEvaluacionMuestraId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirnotemat - Registro de Evaluacíón de Muestra',
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
                filename: 'Dirnotemat - Registro de Evaluacíón de Muestra',
                title: 'Dirnotemat - Registro de Evaluacíón de Muestra',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirnotemat - Registro de Evaluacíón de Muestra',
                title: 'Dirnotemat - Registro de Evaluacíón de Muestra',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirnotemat - Registro de Evaluacíón de Muestra',
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
    tblDirnotematRegistroEvaluacionMuestra.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirnotematRegistroEvaluacionMuestra.columns(9).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirnotematRegistroEvaluacionMuestra/Mostrar?Id=' + Id, [], function (RegistroEvaluacionMuestraDTO) {
        $('#txtCodigo').val(RegistroEvaluacionMuestraDTO.registroEvaluacionMuestraId);
        $('#txtNombreProcesoe').val(RegistroEvaluacionMuestraDTO.descProcesoEvaluacion);
        $('#txtNroProcesoe').val(RegistroEvaluacionMuestraDTO.nroProcesoEvaluacion);
        $('#txtNroMuestrae').val(RegistroEvaluacionMuestraDTO.nroMuestrasEvaluacion);
        $('#txtMuestrasCumplee').val(RegistroEvaluacionMuestraDTO.muestrasCumpleEvaluacion);
        $('#txtMuestrasNoCumplee').val(RegistroEvaluacionMuestraDTO.muestaNoCumpleEvaluacion);
        $('#txtFechaInicioe').val(RegistroEvaluacionMuestraDTO.fechaInicioEvaluacion);
        $('#txtFechaTerminoe').val(RegistroEvaluacionMuestraDTO.fechaTerminoEvaluacion);
        $('#txtLaboratorioe').val(RegistroEvaluacionMuestraDTO.laboratorioEvaluacion);
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
                url: '/DirnotematRegistroEvaluacionMuestra/Eliminar',
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
                    $('#tblDirnotematRegistroEvaluacionMuestra').DataTable().ajax.reload();
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
                url: '/DirnotematRegistroEvaluacionMuestra/EliminarCarga',
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
                    $('#tblDirnotematRegistroEvaluacionMuestra').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDirnotematRegistroEvaluacionMuestra() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirnotematRegistroEvaluacionMuestra/MostrarDatos',
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
                            $("<td>").text(item.descProcesoEvaluacion),
                            $("<td>").text(item.nroProcesoEvaluacion),
                            $("<td>").text(item.nroMuestrasEvaluacion),
                            $("<td>").text(item.muestrasCumpleEvaluacion),
                            $("<td>").text(item.muestaNoCumpleEvaluacion),
                            $("<td>").text(item.fechaInicioEvaluacion),
                            $("<td>").text(item.fechaTerminoEvaluacion),
                            $("<td>").text(item.laboratorioEvaluacion)
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
    fetch("DirnotematRegistroEvaluacionMuestra/EnviarDatos", {
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
    $.getJSON('/DirnotematRegistroEvaluacionMuestra/cargaCombs', [], function (Json) {

        var listaCargas = Json["data1"];


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