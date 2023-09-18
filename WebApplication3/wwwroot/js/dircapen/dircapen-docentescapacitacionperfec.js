var tblDircapenDocentesCapacitacionPerfeccionamiento;
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
                                url: '/DircapenDocentesCapacitacionPerfeccionamiento/Insertar',
                                data: {
                                    'DNIDocente': $('#txtDNI').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalD').val(),
                                    'CodigoCondicionLaboralDocente': $('#cbCondicionLaboral').val(),
                                    'CodigoRegimenLaboral': $('#cbRegimenLaboral').val(),
                                    'DedicacionDocente': $('#txtDedicacion').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudio').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarrerasEducacion').val(), 
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
                                    $('#tblDircapenDocentesCapacitacionPerfeccionamiento').DataTable().ajax.reload();
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
                                url: '/DircapenDocentesCapacitacionPerfeccionamiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIDocente': $('#txtDNIe').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalDe').val(),
                                    'CodigoCondicionLaboralDocente': $('#cbCondicionLaborale').val(),
                                    'CodigoRegimenLaboral': $('#cbRegimenLaborale').val(),
                                    'DedicacionDocente': $('#txtDedicacione').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudioe').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarrerasEducacione').val(), 
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
                                    $('#tblDircapenDocentesCapacitacionPerfeccionamiento').DataTable().ajax.reload();
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


        tblDircapenDocentesCapacitacionPerfeccionamiento=  $('#tblDircapenDocentesCapacitacionPerfeccionamiento').DataTable({
        ajax: {
            "url": '/DircapenDocentesCapacitacionPerfeccionamiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "docenteCapacitacionPerfeccionamientoId" },
            { "data": "dniDocente" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descCondicionLaboralDocente" },
            { "data": "descRegimenLaboral" },
            { "data": "dedicacionDocente" },
            { "data": "descNivelEstudio" },
            { "data": "descCarreraUniversitariaEspecialidad" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.docenteCapacitacionPerfeccionamientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.docenteCapacitacionPerfeccionamientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dircapen - Docentes del Departamento de Capacitación y Perfeccionamiento',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dircapen - Docentes del Departamento de Capacitación y Perfeccionamiento',
                title: 'Dircapen - Docentes del Departamento de Capacitación y Perfeccionamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dircapen - Docentes del Departamento de Capacitación y Perfeccionamiento',
                title: 'Dircapen - Docentes del Departamento de Capacitación y Perfeccionamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dircapen - Docentes del Departamento de Capacitación y Perfeccionamiento',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    tblDircapenDocentesCapacitacionPerfeccionamiento.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDircapenDocentesCapacitacionPerfeccionamiento.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DircapenDocentesCapacitacionPerfeccionamiento/Mostrar?Id=' + Id, [], function (DocentesCapacitacionPerfeccionamientoDTO) {
        $('#txtCodigo').val(DocentesCapacitacionPerfeccionamientoDTO.docenteCapacitacionPerfeccionamientoId);
        $('#txtDNIe').val(DocentesCapacitacionPerfeccionamientoDTO.dniDocente);
        $('#cbTipoPersonalDe').val(DocentesCapacitacionPerfeccionamientoDTO.codigoTipoPersonalMilitar);
        $('#cbCondicionLaborale').val(DocentesCapacitacionPerfeccionamientoDTO.codigoCondicionLaboralDocente);
        $('#cbRegimenLaborale').val(DocentesCapacitacionPerfeccionamientoDTO.codigoRegimenLaboral);
        $('#txtDedicacione').val(DocentesCapacitacionPerfeccionamientoDTO.dedicacionDocente);
        $('#cbNivelEstudioe').val(DocentesCapacitacionPerfeccionamientoDTO.codigoNivelEstudio);
        $('#cbCarrerasEducacione').val(DocentesCapacitacionPerfeccionamientoDTO.codigoCarreraUniversitariaEspecialidad); 
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
                url: '/DircapenDocentesCapacitacionPerfeccionamiento/Eliminar',
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
                    $('#tblDircapenDocentesCapacitacionPerfeccionamiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDircapenDocentesCapacitacionPerfeccionamiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DircapenDocentesCapacitacionPerfeccionamiento/MostrarDatos',
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
                            $("<td>").text(item.dniDocente),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoCondicionLaboralDocente),
                            $("<td>").text(item.codigoRegimenLaboral),
                            $("<td>").text(item.dedicacionDocente),
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
    fetch("DircapenDocentesCapacitacionPerfeccionamiento/EnviarDatos", {
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
                    'Ocurrio un problema.' +mensaje,
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
                url: '/DircapenDocentesCapacitacionPerfeccionamiento/EliminarCarga',
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
                    $('#tblDircapenDocentesCapacitacionPerfeccionamiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DircapenDocentesCapacitacionPerfeccionamiento/cargaCombs', [], function (Json) {
        var tipoPersonalMilitar = Json["data1"];
        var condicionLaboralDocente = Json["data2"];
        var regimenLaboral = Json["data3"];
        var nivelEstudio = Json["data4"];
        var carreraUniversitariaEspecialidad = Json["data5"];
        var listaCargas = Json["data6"];


        $("select#cbTipoPersonalD").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalD").append(RowContent);
        });
        $("select#cbTipoPersonalDe").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalDe").append(RowContent);
        });

        $("select#cbCondicionLaboral").html("");
        $.each(condicionLaboralDocente, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralDocente + '>' + this.descCondicionLaboralDocente + '</option>'
            $("select#cbCondicionLaboral").append(RowContent);
        });
        $("select#cbCondicionLaborale").html("");
        $.each(condicionLaboralDocente, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralDocente + '>' + this.descCondicionLaboralDocente + '</option>'
            $("select#cbCondicionLaborale").append(RowContent);
        });

        $("select#cbRegimenLaboral").html("");
        $.each(regimenLaboral, function () {
            var RowContent = '<option value=' + this.codigoRegimenLaboral + '>' + this.descRegimenLaboral + '</option>'
            $("select#cbRegimenLaboral").append(RowContent);
        });
        $("select#cbRegimenLaborale").html("");
        $.each(regimenLaboral, function () {
            var RowContent = '<option value=' + this.codigoRegimenLaboral + '>' + this.descRegimenLaboral + '</option>'
            $("select#cbRegimenLaborale").append(RowContent);
        });

        $("select#cbNivelEstudio").html("");
        $.each(nivelEstudio, function () {
            var RowContent = '<option value=' + this.codigoNivelEstudio + '>' + this.descNivelEstudio + '</option>'
            $("select#cbNivelEstudio").append(RowContent);
        });
        $("select#cbNivelEstudioe").html("");
        $.each(nivelEstudio, function () {
            var RowContent = '<option value=' + this.codigoNivelEstudio + '>' + this.descNivelEstudio + '</option>'
            $("select#cbNivelEstudioe").append(RowContent);
        });

        $("select#cbCarrerasEducacion").html("");
        $.each(carreraUniversitariaEspecialidad, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbCarrerasEducacion").append(RowContent);
        });
        $("select#cbCarrerasEducacione").html("");
        $.each(carreraUniversitariaEspecialidad, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbCarrerasEducacione").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
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
        reporteSeleccionado = '/DircapenDocentesCapacitacionPerfeccionamiento/ReporteDDCP?idCarga=';
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