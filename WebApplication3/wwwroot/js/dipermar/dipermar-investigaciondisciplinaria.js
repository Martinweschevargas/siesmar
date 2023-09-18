var tblDipermarInvestigacionDisciplinaria;
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
                                url: '/DipermarInvestigacionDisciplinaria/Insertar',
                                data: {
                                    'FechaInicioInvestigacion': $('#txtFechaI').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonal').val(),
                                    'SexoPersonal': $('#txtSexo').val(),
                                    'CodigoInfraccionDisciplinariaGenerica': $('#cbInfraccionDG').val(),
                                    'CodigoInfraccionDisciplinariaEspecifica': $('#cbInfraccionDE').val(),
                                    'NivelInfraccion': $('#txtNivelInfraccion').val(),
                                    'CodigoGradoPresidenteJunta': $('#txtGradoPresidenteJunta').val(),
                                    'NombrePresidenteJunta': $('#txtNombrePresidenteJunta').val(),
                                    'ConclusionFinal': $('#txtConclusionFinal').val(),
                                    'ConclusionFinalDescripcion': $('#txtConclusionFinalDesc').val(),
                                    'CodigoSancionDisciplinariaNaval': $('#cbSancionDisc').val(),
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
                                    $('#tblDipermarInvestigacionDisciplinaria').DataTable().ajax.reload();
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
                                url: '/DipermarInvestigacionDisciplinaria/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaInicioInvestigacion': $('#txtFechaIe').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonale').val(),
                                    'SexoPersonal': $('#txtSexoe').val(),
                                    'CodigoInfraccionDisciplinariaGenerica': $('#cbInfraccionDGe').val(),
                                    'CodigoInfraccionDisciplinariaEspecifica': $('#cbInfraccionDEe').val(),
                                    'NivelInfraccion': $('#txtNivelInfraccione').val(),
                                    'CodigoGradoPresidenteJunta': $('#txtGradoPresidenteJuntae').val(),
                                    'NombrePresidenteJunta': $('#txtNombrePresidenteJuntae').val(),
                                    'ConclusionFinal': $('#txtConclusionFinale').val(),
                                    'ConclusionFinalDescripcion': $('#txtConclusionFinalDesce').val(),
                                    'CodigoSancionDisciplinariaNaval': $('#cbSancionDisce').val(),
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
                                    $('#tblDipermarInvestigacionDisciplinaria').DataTable().ajax.reload();
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

    tblDipermarInvestigacionDisciplinaria = $('#tblDipermarInvestigacionDisciplinaria').DataTable({
        ajax: {
            "url": '/DipermarInvestigacionDisciplinaria/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "investigacionDisciplinariaId" },
            { "data": "fechaInicioInvestigacion" },
            { "data": "descGrado" },
            { "data": "sexoPersonal" },
            { "data": "descInfraccionDisciplinariaGenerica" },
            { "data": "descInfraccionDisciplinariaEspecifica" },
            { "data": "nivelInfraccion" },
            { "data": "descGradoPresidenteJunta" },
            { "data": "nombrePresidenteJunta" },
            { "data": "conclusionFinal" },
            { "data": "conclusionFinalDescripcion" },
            { "data": "descSancionDisciplinariaNaval" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.investigacionDisciplinariaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.investigacionDisciplinariaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dipermar - Investigación Disciplinarias (PERSUPE-PERSUBA)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dipermar - Investigación Disciplinarias (PERSUPE-PERSUBA)',
                title: 'Dipermar - Investigación Disciplinarias (PERSUPE-PERSUBA)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dipermar - Investigación Disciplinarias (PERSUPE-PERSUBA)',
                title: 'Dipermar - Investigación Disciplinarias (PERSUPE-PERSUBA)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dipermar - Investigación Disciplinarias (PERSUPE-PERSUBA)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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
    tblDipermarInvestigacionDisciplinaria.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDipermarInvestigacionDisciplinaria.columns(12).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DipermarInvestigacionDisciplinaria/Mostrar?Id=' + Id, [], function (InvestigacionDisciplinariaDTO) {
        $('#txtCodigo').val(InvestigacionDisciplinariaDTO.investigacionDisciplinariaId);
        $('#txtFechaIe').val(InvestigacionDisciplinariaDTO.fechaInicioInvestigacion);
        $('#cbGradoPersonale').val(InvestigacionDisciplinariaDTO.codigoGradoPersonalMilitar);
        $('#txtSexoe').val(InvestigacionDisciplinariaDTO.sexoPersonal);
        $('#cbInfraccionDGe').val(InvestigacionDisciplinariaDTO.codigoInfraccionDisciplinariaGenerica);
        $('#cbInfraccionDEe').val(InvestigacionDisciplinariaDTO.codigoInfraccionDisciplinariaEspecifica);
        $('#txtNivelInfraccione').val(InvestigacionDisciplinariaDTO.nivelInfraccion);
        $('#txtGradoPresidenteJuntae').val(InvestigacionDisciplinariaDTO.codigoGradoPresidenteJunta);
        $('#txtNombrePresidenteJuntae').val(InvestigacionDisciplinariaDTO.nombrePresidenteJunta);
        $('#txtConclusionFinale').val(InvestigacionDisciplinariaDTO.conclusionFinal);
        $('#txtConclusionFinalDesce').val(InvestigacionDisciplinariaDTO.conclusionFinalDescripcion);
        $('#cbSancionDisce').val(InvestigacionDisciplinariaDTO.codigoSancionDisciplinariaNaval);
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
                url: '/DipermarInvestigacionDisciplinaria/Eliminar',
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
                    $('#tblDipermarInvestigacionDisciplinaria').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDipermarInvestigacionDisciplinaria() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DipermarInvestigacionDisciplinaria/MostrarDatos',
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
                            $("<td>").text(item.fechaInicioInvestigacion),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.sexoPersonal),
                            $("<td>").text(item.codigoInfraccionDisciplinariaGenerica),
                            $("<td>").text(item.codigoInfraccionDisciplinariaEspecifica),
                            $("<td>").text(item.nivelInfraccion),
                            $("<td>").text(item.codigoGradoPresidenteJunta),
                            $("<td>").text(item.nombrePresidenteJunta),
                            $("<td>").text(item.conclusionFinal),
                            $("<td>").text(item.conclusionFinalDescripcion),
                            $("<td>").text(item.codigoSancionDisciplinariaNaval)
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
    fetch("DipermarInvestigacionDisciplinaria/EnviarDatos", {
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
                url: '/DipermarInvestigacionDisciplinaria/EliminarCarga',
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
                    $('#tblDipermarInvestigacionDisciplinaria').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DipermarInvestigacionDisciplinaria/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar   = Json["data1"];
        var infraccionDisciplinariaGenerica = Json["data2"];
        var sancionDisciplinariaNaval = Json["data3"];
        var infraccionDisciplinariaEspecifica = Json["data4"];
        var listaCargas = Json["data5"];


        $("select#cbGradoPersonal").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonal").append(RowContent);
        });
        $("select#cbGradoPersonale").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonale").append(RowContent);
        });


        $("select#txtGradoPresidenteJunta").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#txtGradoPresidenteJunta").append(RowContent);
        });
        $("select#txtGradoPresidenteJuntae").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#txtGradoPresidenteJuntae").append(RowContent);
        });


        $("select#cbInfraccionDG").html("");
        $.each(infraccionDisciplinariaGenerica, function () {
            var RowContent = '<option value=' + this.codigoInfraccionDisciplinariaGenerica + '>' + this.descInfraccionDisciplinariaGenerica + '</option>'
            $("select#cbInfraccionDG").append(RowContent);
        });
        $("select#cbInfraccionDGe").html("");
        $.each(infraccionDisciplinariaGenerica, function () {
            var RowContent = '<option value=' + this.codigoInfraccionDisciplinariaGenerica + '>' + this.descInfraccionDisciplinariaGenerica + '</option>'
            $("select#cbInfraccionDGe").append(RowContent);
        });

        $("select#cbSancionDisc").html("");
        $.each(sancionDisciplinariaNaval, function () {
            var RowContent = '<option value=' + this.codigoSancionDisciplinariaNaval + '>' + this.descSancionDisciplinariaNaval + '</option>'
            $("select#cbSancionDisc").append(RowContent);
        });
        $("select#cbSancionDisce").html("");
        $.each(sancionDisciplinariaNaval, function () {
            var RowContent = '<option value=' + this.codigoSancionDisciplinariaNaval + '>' + this.descSancionDisciplinariaNaval + '</option>'
            $("select#cbSancionDisce").append(RowContent);
        });

        $("select#cbInfraccionDE").html("");
        $.each(infraccionDisciplinariaEspecifica, function () {
            var RowContent = '<option value=' + this.codigoInfraccionDisciplinariaEspecifica + '>' + this.descInfraccionDisciplinariaEspecifica + '</option>'
            $("select#cbInfraccionDE").append(RowContent);
        });
        $("select#cbInfraccionDEe").html("");
        $.each(infraccionDisciplinariaEspecifica, function () {
            var RowContent = '<option value=' + this.codigoInfraccionDisciplinariaEspecifica + '>' + this.descInfraccionDisciplinariaEspecifica + '</option>'
            $("select#cbInfraccionDEe").append(RowContent);
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

    reporteSeleccionado = '/DipermarInvestigacionDisciplinaria/ReporteID';
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