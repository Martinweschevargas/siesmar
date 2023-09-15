var tblDirespromDocente2daEspecializacion;
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
                                url: '/DirespromDocente2daEspecializacion/Insertar',
                                data: {
                                    'DNIPersonalDocente': $('#txtDNI').val(),
                                    'TipoPersonalDocente': $('#txtTipoPersonalDocente').val(),
                                    'CodigoCondicionLaboralDocente': $('#cbCondicionLaboralD').val(),
                                    'CodigoRegimenLaboral': $('#cbRegimenLaboral').val(),
                                    'DedicacionTiempoDocente': $('#txtDedicacionTiempoDocente').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudio').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarreraUniversitariaEspe').val(),
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
                                    $('#tblDirespromDocente2daEspecializacion').DataTable().ajax.reload();
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
                                url: '/DirespromDocente2daEspecializacion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPersonalDocente': $('#txtDNIe').val(),
                                    'TipoPersonalDocente': $('#txtTipoPersonalDocentee').val(),
                                    'CodigoCondicionLaboralDocente': $('#cbCondicionLaboralDe').val(),
                                    'CodigoRegimenLaboral': $('#cbRegimenLaborale').val(),
                                    'DedicacionTiempoDocente': $('#txtDedicacionTiempoDocentee').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudioe').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarreraUniversitariaEspee').val(), 
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
                                    $('#tblDirespromDocente2daEspecializacion').DataTable().ajax.reload();
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


        tblDirespromDocente2daEspecializacion=  $('#tblDirespromDocente2daEspecializacion').DataTable({
        ajax: {
            "url": '/DirespromDocente2daEspecializacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "docente2daEspecializacionId" },
            { "data": "dniPersonalDocente" },
            { "data": "tipoPersonalDocente" },
            { "data": "descCondicionLaboralDocente" },
            { "data": "descRegimenLaboral" },
            { "data": "dedicacionTiempoDocente" },
            { "data": "descNivelEstudio" },
            { "data": "descCarreraUniversitariaEspecialidad" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.docente2daEspecializacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.docente2daEspecializacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresprom - Docentes de la Escuela Segunda Especialidad Profesional de Oficiales de la Marina',
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
                filename: 'Diresprom - Docentes de la Escuela Segunda Especialidad Profesional de Oficiales de la Marina',
                title: 'Diresprom - Docentes de la Escuela Segunda Especialidad Profesional de Oficiales de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresprom - Docentes de la Escuela Segunda Especialidad Profesional de Oficiales de la Marina',
                title: 'Diresprom - Docentes de la Escuela Segunda Especialidad Profesional de Oficiales de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresprom - Docentes de la Escuela Segunda Especialidad Profesional de Oficiales de la Marina',
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
    tblDirespromDocente2daEspecializacion.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblDirespromDocente2daEspecializacion.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirespromDocente2daEspecializacion/Mostrar?Id=' + Id, [], function (Docente2daEspecializacionDTO) {
        $('#txtCodigo').val(Docente2daEspecializacionDTO.docente2daEspecializacionId);
        $('#txtDNIe').val(Docente2daEspecializacionDTO.dniPersonalDocente);
        $('#txtTipoPersonalDocentee').val(Docente2daEspecializacionDTO.tipoPersonalDocente);
        $('#cbCondicionLaboralDe').val(Docente2daEspecializacionDTO.codigoCondicionLaboralDocente);
        $('#cbRegimenLaborale').val(Docente2daEspecializacionDTO.codigoRegimenLaboral);
        $('#txtDedicacionTiempoDocentee').val(Docente2daEspecializacionDTO.dedicacionTiempoDocente);
        $('#cbNivelEstudioe').val(Docente2daEspecializacionDTO.codigoNivelEstudio);
        $('#cbCarreraUniversitariaEspee').val(Docente2daEspecializacionDTO.codigoCarreraUniversitariaEspecialidad); 
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
                url: '/DirespromDocente2daEspecializacion/Eliminar',
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
                    $('#tblDirespromDocente2daEspecializacion').DataTable().ajax.reload();
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
                url: '/DirespromDocente2daEspecializacion/EliminarCarga',
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
                    $('#tblDirespromDocente2daEspecializacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDirespromDocente2daEspecializacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirespromDocente2daEspecializacion/MostrarDatos',
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
                            $("<td>").text(item.dniPersonalDocente),
                            $("<td>").text(item.tipoPersonalDocente),
                            $("<td>").text(item.codigoCondicionLaboralDocente),
                            $("<td>").text(item.codigoRegimenLaboral),
                            $("<td>").text(item.dedicacionTiempoDocente),
                            $("<td>").text(item.codigoNivelEstudio),
                            $("<td>").text(item.codigoCarreraUniversitariaEspecialidad),
                         
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
    fetch("DirespromDocente2daEspecializacion/EnviarDatos", {
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
    $.getJSON('/DirespromDocente2daEspecializacion/cargaCombs', [], function (Json) {
        var condicionLaboralDocente = Json["data1"];
        var regimenLaboral = Json["data2"];
        var nivelEstudio = Json["data3"];
        var carreraUniversitariaEspecialidad = Json["data4"];
        var listaCargas = Json["data5"];

        $("select#cbCondicionLaboralD").html("");
        $("select#cbCondicionLaboralDe").html("");
        $.each(condicionLaboralDocente, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralDocente + '>' + this.descCondicionLaboralDocente + '</option>'
            $("select#cbCondicionLaboralD").append(RowContent);
            $("select#cbCondicionLaboralDe").append(RowContent);
        });

        $("select#cbRegimenLaboral").html("");
        $("select#cbRegimenLaborale").html("");
        $.each(regimenLaboral, function () {
            var RowContent = '<option value=' + this.codigoRegimenLaboral + '>' + this.descRegimenLaboral + '</option>'
            $("select#cbRegimenLaboral").append(RowContent);
            $("select#cbRegimenLaborale").append(RowContent);
        });

        $("select#cbNivelEstudio").html("");
        $("select#cbNivelEstudioe").html("");
        $.each(nivelEstudio, function () {
            var RowContent = '<option value=' + this.codigoNivelEstudio + '>' + this.descNivelEstudio + '</option>'
            $("select#cbNivelEstudio").append(RowContent);
            $("select#cbNivelEstudioe").append(RowContent);
        });

        $("select#cbCarreraUniversitariaEspe").html("");
        $("select#cbCarreraUniversitariaEspee").html("");
        $.each(carreraUniversitariaEspecialidad, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbCarreraUniversitariaEspe").append(RowContent);
            $("select#cbCarreraUniversitariaEspee").append(RowContent);
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

    reporteSeleccionado = '/DirespromDocente2daEspecializacion/ReporteARTR';
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