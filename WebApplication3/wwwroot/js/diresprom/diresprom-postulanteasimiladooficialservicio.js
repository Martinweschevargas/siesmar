var tblDirespromPostulanteAsimiladoOficialServicio;
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
                                url: '/DirespromPostulanteAsimiladoOficialServicio/Insertar',
                                data: {
                                    'DNIPostulanteAsimilado': $('#txtDNI').val(),
                                    'SexoPostulanteAsimilado': $('#txtGenero').val(),
                                    'FechaNacimiento': $('#txtFechaNacimiento').val(),
                                    'DistritoNacimiento': $('#txtLugarNacimiento').val(),
                                    'CodigoInstitucionEducativaSuperior': $('#cbInstitucionEducativaS').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarreraUniversitariaEspe').val(),
                                    'CodigoEspecialidadPostulacion': $('#cbEspecialidadPostulacion').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'SituacionIngreso': $('#txtSituacionIngreso').val(),
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
                                    $('#tblDirespromPostulanteAsimiladoOficialServicio').DataTable().ajax.reload();
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
                                url: '/DirespromPostulanteAsimiladoOficialServicio/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPostulanteAsimilado': $('#txtDNIe').val(),
                                    'SexoPostulanteAsimilado': $('#txtGeneroe').val(),
                                    'FechaNacimiento': $('#txtFechaNacimientoe').val(),
                                    'DistritoNacimiento': $('#txtLugarNacimientoe').val(),
                                    'CodigoInstitucionEducativaSuperior': $('#cbInstitucionEducativaSe').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarreraUniversitariaEspee').val(),
                                    'CodigoEspecialidadPostulacion': $('#cbEspecialidadPostulacione').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'SituacionIngreso': $('#txtSituacionIngresoe').val(), 
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
                                    $('#tblDirespromPostulanteAsimiladoOficialServicio').DataTable().ajax.reload();
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

    $('#tblDirespromPostulanteAsimiladoOficialServicio').DataTable({
        ajax: {
            "url": '/DirespromPostulanteAsimiladoOficialServicio/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "postulanteAsimiladoOficialServicioId" },
            { "data": "dniPostulanteAsimilado" },
            { "data": "sexoPostulanteAsimilado" },
            { "data": "fechaNacimiento" },
            { "data": "distritoNacimiento" },
            { "data": "descInstitucionEducativaSuperior" },
            { "data": "descCarreraUniversitariaEspecialidad" },
            { "data": "descEspecialidadPostulacionI" },
            { "data": "descZonaNaval" },
            { "data": "situacionIngreso" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.postulanteAsimiladoOficialServicioId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.postulanteAsimiladoOficialServicioId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresprom - Postulantes como Asimilados como Oficiales de Servicio',
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
                filename: 'Diresprom - Postulantes como Asimilados como Oficiales de Servicio',
                title: 'Diresprom - Postulantes como Asimilados como Oficiales de Servicio',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresprom - Postulantes como Asimilados como Oficiales de Servicio',
                title: 'Diresprom - Postulantes como Asimilados como Oficiales de Servicio',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresprom - Postulantes como Asimilados como Oficiales de Servicio',
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
    tblDirespromPostulanteAsimiladoOficialServicio.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblDirespromPostulanteAsimiladoOficialServicio.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirespromPostulanteAsimiladoOficialServicio/Mostrar?Id=' + Id, [], function (PostulanteAsimiladoOficialServicioDTO) {
        $('#txtCodigo').val(PostulanteAsimiladoOficialServicioDTO.postulanteAsimiladoOficialServicioId);
        $('#txtDNIe').val(PostulanteAsimiladoOficialServicioDTO.dniPostulanteAsimilado);
        $('#txtGeneroe').val(PostulanteAsimiladoOficialServicioDTO.sexoPostulanteAsimilado);
        $('#txtFechaNacimientoe').val(PostulanteAsimiladoOficialServicioDTO.fechaNacimiento);
        $('#txtLugarNacimientoe').val(PostulanteAsimiladoOficialServicioDTO.distritoNacimiento);
        $('#cbInstitucionEducativaSe').val(PostulanteAsimiladoOficialServicioDTO.codigoInstitucionEducativaSuperior);
        $('#cbCarreraUniversitariaEspee').val(PostulanteAsimiladoOficialServicioDTO.codigoCarreraUniversitariaEspecialidad);
        $('#cbEspecialidadPostulacione').val(PostulanteAsimiladoOficialServicioDTO.codigoEspecialidadPostulacion);
        $('#cbZonaNavale').val(PostulanteAsimiladoOficialServicioDTO.codigoZonaNaval);
        $('#txtSituacionIngresoe').val(PostulanteAsimiladoOficialServicioDTO.situacionIngreso); 
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
                url: '/DirespromPostulanteAsimiladoOficialServicio/Eliminar',
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
                    $('#tblDirespromPostulanteAsimiladoOficialServicio').DataTable().ajax.reload();
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
                url: '/DirespromPostulanteAsimiladoOficialServicio/EliminarCarga',
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
                    $('#tblDirespromPostulanteAsimiladoOficialServicio').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDirespromPostulanteAsimiladoOficialServicio() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirespromPostulanteAsimiladoOficialServicio/MostrarDatos',
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
                            $("<td>").text(item.dniPostulanteAsimilado),
                            $("<td>").text(item.sexoPostulanteAsimilado),
                            $("<td>").text(item.fechaNacimiento),
                            $("<td>").text(item.distritoNacimiento),
                            $("<td>").text(item.codigoInstitucionEducativaSuperior),
                            $("<td>").text(item.codigoCarreraUniversitariaEspecialidad),
                            $("<td>").text(item.codigoEspecialidadPostulacion),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.situacionIngreso)

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
    fetch("DirespromPostulanteAsimiladoOficialServicio/EnviarDatos", {
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
    $.getJSON('/DirespromPostulanteAsimiladoOficialServicio/cargaCombs', [], function (Json) {
        var institucionEducativaSu = Json["data1"];
        var carreraUniversitariaEspecialidad = Json["data2"];
        var especialidadPostulacion = Json["data3"];
        var zonaNaval = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbInstitucionEducativaS").html("");
        $("select#cbInstitucionEducativaSe").html("");
        $.each(institucionEducativaSu, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativaSuperior + '>' + this.descInstitucionEducativaSuperior + '</option>'
            $("select#cbInstitucionEducativaS").append(RowContent);
            $("select#cbInstitucionEducativaSe").append(RowContent);
        });

        $("select#cbCarreraUniversitariaEspe").html("");
        $("select#cbCarreraUniversitariaEspee").html("");
        $.each(carreraUniversitariaEspecialidad, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbCarreraUniversitariaEspe").append(RowContent);
            $("select#cbCarreraUniversitariaEspee").append(RowContent);
        });

        $("select#cbEspecialidadPostulacion").html("");
        $("select#cbEspecialidadPostulacione").html("");
        $.each(especialidadPostulacion, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadPostulacion + '>' + this.descEspecialidadPostulacion + '</option>'
            $("select#cbEspecialidadPostulacion").append(RowContent);
            $("select#cbEspecialidadPostulacione").append(RowContent);
        });

        $("select#cbZonaNaval").html("");
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
            $("select#cbZonaNavale").append(RowContent);
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

    reporteSeleccionado = '/DirespromPostulanteAsimiladoOficialServicio/ReporteARTR';
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

