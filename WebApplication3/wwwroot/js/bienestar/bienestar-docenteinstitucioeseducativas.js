var tblBienestarDocenteInstitucioesEducativas;
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
                                url: '/BienestarDocenteInstitucioesEducativas/Insertar',
                                data: {
                                    'DNIDocente': $('#txtDNIMatriculado').val(),
                                    'SexoDocente': $('#txtSexoDocente option:selected').val(),
                                    'JornadaLaboral': $('#txtJornadaLaboral option:selected').val(),
                                    'CodigoCondicionLaboralDocente': $('#cbCondicionLaboralDocente').val(),
                                    'CodigoDocenteCategoria': $('#cbDocenteCategoria').val(),
                                    'CodigoGradoEstudioAlcanzado': $('#cbGradoEstudioAlcanzado').val(),
                                    'CodigoInstitucionEducativa': $('#cbInstitucionEducativa').val(),
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
                                    $('#tblBienestarDocenteInstitucioesEducativas').DataTable().ajax.reload();
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
                                url: '/BienestarDocenteInstitucioesEducativas/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIDocente': $('#txtDNIMatriculadoe').val(),
                                    'SexoDocente': $('#txtSexoDocentee option:selected').val(),
                                    'JornadaLaboral': $('#txtJornadaLaborale option:selected').val(),
                                    'CodigoCondicionLaboralDocente': $('#cbCondicionLaboralDocentee').val(),
                                    'CodigoDocenteCategoria': $('#cbDocenteCategoriae').val(),
                                    'CodigoGradoEstudioAlcanzado': $('#cbGradoEstudioAlcanzadoe').val(),
                                    'CodigoInstitucionEducativa': $('#cbInstitucionEducativae').val(), 
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
                                    $('#tblBienestarDocenteInstitucioesEducativas').DataTable().ajax.reload();
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

    tblBienestarDocenteInstitucioesEducativas=  $('#tblBienestarDocenteInstitucioesEducativas').DataTable({
        ajax: {
            "url": '/BienestarDocenteInstitucioesEducativas/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "docenteInstitucionEducativaId" },
            { "data": "dniDocente" },
            { "data": "sexoDocente" },
            { "data": "jornadaLaboral" },
            { "data": "descCondicionLaboralDocente" },
            { "data": "descDocenteCategoria" },
            { "data": "descGradoEstudioAlcanzado" },
            { "data": "descInstitucionEducativa" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.docenteInstitucionEducativaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.docenteInstitucionEducativaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Docentes de las Instituciones Educativas',
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
                filename: 'Bienestar - Docentes de las Instituciones Educativas',
                title: 'Bienestar - Docentes de las Instituciones Educativas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Docentes de las Instituciones Educativas',
                title: 'Bienestar - Docentes de las Instituciones Educativas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Docentes de las Instituciones Educativas',
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
    tblBienestarDocenteInstitucioesEducativas.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarDocenteInstitucioesEducativas.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarDocenteInstitucioesEducativas/Mostrar?Id=' + Id, [], function (DocenteInstitucioesEducativasDTO) {
        $('#txtCodigo').val(DocenteInstitucioesEducativasDTO.docenteInstitucionEducativaId);
        $('#txtDNIMatriculadoe').val(DocenteInstitucioesEducativasDTO.dniDocente);
        $('#txtSexoDocentee').val(DocenteInstitucioesEducativasDTO.sexoDocente);
        $('#txtJornadaLaborale').val(DocenteInstitucioesEducativasDTO.jornadaLaboral);
        $('#cbCondicionLaboralDocentee').val(DocenteInstitucioesEducativasDTO.codigoCondicionLaboralDocente);
        $('#cbDocenteCategoriae').val(DocenteInstitucioesEducativasDTO.codigoDocenteCategoria);
        $('#cbGradoEstudioAlcanzadoe').val(DocenteInstitucioesEducativasDTO.codigoGradoEstudioAlcanzado);
        $('#cbInstitucionEducativae').val(DocenteInstitucioesEducativasDTO.codigoInstitucionEducativa); 
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
                url: '/BienestarDocenteInstitucioesEducativas/Eliminar',
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
                    $('#tblBienestarDocenteInstitucioesEducativas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarDocenteInstitucioesEducativas() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarDocenteInstitucioesEducativas/MostrarDatos',
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
                            $("<td>").text(item.sexoDocente),
                            $("<td>").text(item.jornadaLaboral),
                            $("<td>").text(item.codigoCondicionLaboralDocente),
                            $("<td>").text(item.codigoDocenteCategoria),
                            $("<td>").text(item.codigoGradoEstudioAlcanzado),
                            $("<td>").text(item.codigoInstitucionEducativa)
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
    fetch("BienestarDocenteInstitucioesEducativas/EnviarDatos", {
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
                url: '/BienestarDocenteInstitucioesEducativas/EliminarCarga',
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
                    $('#tblBienestarDocenteInstitucioesEducativas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarDocenteInstitucioesEducativas/cargaCombs', [], function (Json) {
        var condicionLaboralDocente = Json["data1"];
        var docenteCategoria = Json["data2"];
        var gradoEstudioAlcanzado = Json["data3"];
        var institucionEducativa = Json["data4"];
        var listaCargas = Json["data5"];
        var listaMes = Json["mes"];
        var listaAnio = Json["anio"];

        $("select#cbMes").html("");
        $.each(listaMes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });

        $("select#cbAnio").html("");
        $.each(listaAnio, function () {
            var RowContent = '<option value=' + this.codigoAnio + '>' + this.descAnio + '</option>'
            $("select#cbAnio").append(RowContent);
        });

        $("select#cbCondicionLaboralDocente").html("");
        $("select#cbCondicionLaboralDocentee").html("");
        $.each(condicionLaboralDocente, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralDocente + '>' + this.descCondicionLaboralDocente + '</option>'
            $("select#cbCondicionLaboralDocente").append(RowContent);
            $("select#cbCondicionLaboralDocentee").append(RowContent);
        });

        $("select#cbDocenteCategoria").html("");
        $("select#cbDocenteCategoriae").html("");
        $.each(docenteCategoria, function () {
            var RowContent = '<option value=' + this.codigoDocenteCategoria + '>' + this.descDocenteCategoria + '</option>'
            $("select#cbDocenteCategoria").append(RowContent);
            $("select#cbDocenteCategoriae").append(RowContent);
        });

        $("select#cbGradoEstudioAlcanzado").html("");
        $("select#cbGradoEstudioAlcanzadoe").html("");
        $.each(gradoEstudioAlcanzado, function () {
            var RowContent = '<option value=' + this.codigoGradoEstudioAlcanzado + '>' + this.descGradoEstudioAlcanzado + '</option>'
            $("select#cbGradoEstudioAlcanzado").append(RowContent);
            $("select#cbGradoEstudioAlcanzadoe").append(RowContent);
        });

        $("select#cbInstitucionEducativa").html("");
        $("select#cbInstitucionEducativae").html("");
        $.each(institucionEducativa, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativa + '>' + this.descInstitucionEducativa + '</option>'
            $("select#cbInstitucionEducativa").append(RowContent);
            $("select#cbInstitucionEducativae").append(RowContent);
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
        reporteSeleccionado = '/BienestarDocenteInstitucioesEducativas/ReporteDIE?idCarga=';
        $('#fecha').hide();
    }
    /*if (id == 2) { 
        reporteSeleccionado = '/BienestarMovilidadEscolar/ReporteME?idCarga=';
        $('#fecha').show();
    }*/
}
$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect = 1) {
        a.href = reporteSeleccionado + idCarga;
    } else {
        // a.href = reporteSeleccionado + idCarga;
    }
    a.click();
});