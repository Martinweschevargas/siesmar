var tblDiresnaDocenteEsna;
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
                                url: '/DiresnaDocenteEsna/Insertar',
                                data: {
                                    'DNIDocenteEsna': $('#txtDNI').val(),
                                    'TipoDocente': $('#txtTipoPersonalD').val(),
                                    'CodigoCondicionLaboralDocente': $('#cbCondicionLaboralD').val(),
                                    'CodigoRegimenLaborar': $('#cbRegimenlaboral').val(),
                                    'DedicacionDocente': $('#txtDedicacionDocente').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudios').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarreraUniversitariaEspe').val(),
                                    'ExperienciaDocente': $('#txtExperienciaDocente').val(),
                                    'ExperienciaDocenteMarina': $('#txtExperienciaDocenteMarina').val(), 
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
                                    $('#tblDiresnaDocenteEsna').DataTable().ajax.reload();
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
                                url: '/DiresnaDocenteEsna/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIDocenteEsna': $('#txtDNIe').val(),
                                    'TipoDocente': $('#txtTipoPersonalDe').val(),
                                    'CodigoCondicionLaboralDocente': $('#cbCondicionLaboralDe').val(),
                                    'CodigoRegimenLaborar': $('#cbRegimenlaborale').val(),
                                    'DedicacionDocente': $('#txtDedicacionDocentee').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudiose').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarreraUniversitariaEspee').val(),
                                    'ExperienciaDocente': $('#txtExperienciaDocentee').val(),
                                    'ExperienciaDocenteMarina': $('#txtExperienciaDocenteMarinae').val(), 
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
                                    $('#tblDiresnaDocenteEsna').DataTable().ajax.reload();
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


        tblDiresnaDocenteEsna=  $('#tblDiresnaDocenteEsna').DataTable({
        ajax: {
            "url": '/DiresnaDocenteEsna/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "docenteEsnaId" },
            { "data": "dniDocenteEsna" },
            { "data": "tipoDocente" },
            { "data": "descCondicionLaboralDocente" },
            { "data": "descRegimenLaboral" },
            { "data": "dedicacionDocente" },
            { "data": "descNivelEstudio" },
            { "data": "descCarreraUniversitariaEspecialidad" },
            { "data": "experienciaDocente" },
            { "data": "experienciaDocenteMarina" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.docenteEsnaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.docenteEsnaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresna - Docentes Diresna',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diresna - Docentes Diresna',
                title: 'Diresna - Docentes Diresna',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresna - Docentes Diresna',
                title: 'Diresna - Docentes Diresna',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresna - Docentes Diresna',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9]
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
    tblDiresnaDocenteEsna.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiresnaDocenteEsna.columns(10).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiresnaDocenteEsna/Mostrar?Id=' + Id, [], function (DocenteEsnaDTO) {
        $('#txtCodigo').val(DocenteEsnaDTO.docenteEsnaId);
        $('#txtDNIe').val(DocenteEsnaDTO.dniDocenteEsna);
        $('#txtTipoPersonalDe').val(DocenteEsnaDTO.tipoDocente);
        $('#cbCondicionLaboralDe').val(DocenteEsnaDTO.codigoCondicionLaboralDocente);
        $('#cbRegimenlaborale').val(DocenteEsnaDTO.codigoRegimenLaboral);
        $('#txtDedicacionDocentee').val(DocenteEsnaDTO.dedicacionDocente);
        $('#cbNivelEstudiose').val(DocenteEsnaDTO.codigoNivelEstudio);
        $('#cbCarreraUniversitariaEspee').val(DocenteEsnaDTO.codigoCarreraUniversitariaEspecialidad);
        $('#txtExperienciaDocentee').val(DocenteEsnaDTO.experienciaDocente);
        $('#txtExperienciaDocenteMarinae').val(DocenteEsnaDTO.experienciaDocenteMarina);
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
                url: '/DiresnaDocenteEsna/Eliminar',
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
                    $('#tblDiresnaDocenteEsna').DataTable().ajax.reload();
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
                url: '/DiresnaDocenteEsna/EliminarCarga',
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
                    $('#tblDiresnaDocenteEsna').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiresnaDocenteEsna() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiresnaDocenteEsna/MostrarDatos',
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
                            $("<td>").text(item.dniDocenteEsna),
                            $("<td>").text(item.tipoDocente),
                            $("<td>").text(item.codigoCondicionLaboralDocente),
                            $("<td>").text(item.codigoRegimenLaboral),
                            $("<td>").text(item.dedicacionDocente),
                            $("<td>").text(item.codigoNivelEstudio),
                            $("<td>").text(item.codigoCarreraUniversitariaEspecialidad),
                            $("<td>").text(item.experienciaDocente),
                            $("<td>").text(item.experienciaDocenteMarina),
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
    fetch("DiresnaDocenteEsna/EnviarDatos", {
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
    $.getJSON('/DiresnaDocenteEsna/cargaCombs', [], function (Json) {
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

        $("select#cbRegimenlaboral").html("");
        $("select#cbRegimenlaborale").html("");
        $.each(regimenLaboral, function () {
            var RowContent = '<option value=' + this.codigoRegimenLaboral + '>' + this.descRegimenLaboral + '</option>'
            $("select#cbRegimenlaboral").append(RowContent);
            $("select#cbRegimenlaborale").append(RowContent);
        });


        $("select#cbNivelEstudios").html("");
        $("select#cbNivelEstudiose").html("");
        $.each(nivelEstudio, function () {
            var RowContent = '<option value=' + this.codigoNivelEstudio + '>' + this.descNivelEstudio + '</option>'
            $("select#cbNivelEstudios").append(RowContent);
            $("select#cbNivelEstudiose").append(RowContent);
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
    if (id == 1) {
        reporteSeleccionado = '/DiresnaDocenteEsna/ReporteDDE?idCarga=';
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