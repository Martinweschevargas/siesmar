var tblBienestarPoblacionEstudiantilMatriculados;
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
                                url: '/BienestarPoblacionEstudiantilMatriculados/Insertar',
                                data: {
                                    'DNIMatriculado': $('#txtDNIMatriculado').val(),
                                    'FechaNacimiento': $('#txtFechaNacimiento').val(),
                                    'SexoMatriculado': $('#txtSexoMatriculado').val(),
                                    'CodigoInstitucionEducativa': $('#cbInstitucionEducativa').val(),
                                    'CodigoNivelEstudio': $('#cbGradoPersonalMilitar').val(),
                                    'GradoEstudio': $('#txtGradoEstudio').val(),
                                    'CodigoSeccionEstudio': $('#cbSeccionEstudio').val(),
                                    'EspecificacionEstudio': $('#txtEspecificacionEstudio').val(),
                                    'CodigoCategoriaPago': $('#cbCategoriaPago').val(),
                                    'CodigoResultadoEjercicioEducativo': $('#cbResultadoEjercicioE').val(),
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
                                    $('#tblBienestarPoblacionEstudiantilMatriculados').DataTable().ajax.reload();
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
                                url: '/BienestarPoblacionEstudiantilMatriculados/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIMatriculado': $('#txtDNIMatriculadoe').val(),
                                    'FechaNacimiento': $('#txtFechaNacimientoe').val(),
                                    'SexoMatriculado': $('#txtSexoMatriculadoe').val(),
                                    'CodigoInstitucionEducativa': $('#cbInstitucionEducativae').val(),
                                    'CodigoNivelEstudio': $('#cbGradoPersonalMilitare').val(),
                                    'GradoEstudio': $('#txtGradoEstudioe').val(),
                                    'CodigoSeccionEstudio': $('#cbSeccionEstudioe').val(),
                                    'EspecificacionEstudio': $('#txtEspecificacionEstudioe').val(),
                                    'CodigoCategoriaPago': $('#cbCategoriaPagoe').val(),
                                    'CodigoResultadoEjercicioEducativo': $('#cbResultadoEjercicioEe').val(), 
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
                                    $('#tblBienestarPoblacionEstudiantilMatriculados').DataTable().ajax.reload();
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

    tblBienestarPoblacionEstudiantilMatriculados=  $('#tblBienestarPoblacionEstudiantilMatriculados').DataTable({
        ajax: {
            "url": '/BienestarPoblacionEstudiantilMatriculados/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "poblacionEstudiantilMatriculadoId" },
            { "data": "dniMatriculado" },
            { "data": "fechaNacimiento" },
            { "data": "sexoMatriculado" },
            { "data": "descInstitucionEducativa" },
            { "data": "descNivelEstudio" },
            { "data": "gradoEstudio" },
            { "data": "descSeccionEstudio" },
            { "data": "especificacionEstudio" },
            { "data": "descCategoriaPago" },
            { "data": "descResultadoEjercicioEducativo" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.poblacionEstudiantilMatriculadoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.poblacionEstudiantilMatriculadoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Población Estudiantil Matriculados',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Bienestar - Población Estudiantil Matriculados',
                title: 'Bienestar - Población Estudiantil Matriculados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Población Estudiantil Matriculados',
                title: 'Bienestar - Población Estudiantil Matriculados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Población Estudiantil Matriculados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
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
    tblBienestarPoblacionEstudiantilMatriculados.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarPoblacionEstudiantilMatriculados.columns(11).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarPoblacionEstudiantilMatriculados/Mostrar?Id=' + Id, [], function (PoblacionEstudiantilMatriculadosDTO) {
        $('#txtCodigo').val(PoblacionEstudiantilMatriculadosDTO.poblacionEstudiantilMatriculadoId);
        $('#txtDNIMatriculadoe').val(PoblacionEstudiantilMatriculadosDTO.dniMatriculado);
        $('#txtFechaNacimientoe').val(PoblacionEstudiantilMatriculadosDTO.fechaNacimiento);
        $('#txtSexoMatriculadoe').val(PoblacionEstudiantilMatriculadosDTO.sexoMatriculado);
        $('#cbInstitucionEducativae').val(PoblacionEstudiantilMatriculadosDTO.codigoInstitucionEducativa);
        $('#cbGradoPersonalMilitare').val(PoblacionEstudiantilMatriculadosDTO.codigoNivelEstudio);
        $('#txtGradoEstudioe').val(PoblacionEstudiantilMatriculadosDTO.gradoEstudio);
        $('#cbSeccionEstudioe').val(PoblacionEstudiantilMatriculadosDTO.codigoSeccionEstudio);
        $('#txtEspecificacionEstudioe').val(PoblacionEstudiantilMatriculadosDTO.especificacionEstudio);
        $('#cbCategoriaPagoe').val(PoblacionEstudiantilMatriculadosDTO.codigoCategoriaPago);
        $('#cbResultadoEjercicioEe').val(PoblacionEstudiantilMatriculadosDTO.codigoResultadoEjercicioEducativo); 
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
                url: '/BienestarPoblacionEstudiantilMatriculados/Eliminar',
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
                    $('#tblBienestarPoblacionEstudiantilMatriculados').DataTable().ajax.reload();
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
                url: '/BienestarPoblacionEstudiantilMatriculados/EliminarCarga',
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
                    $('#tblBienestarPoblacionEstudiantilMatriculados').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaBienestarPoblacionEstudiantilMatriculados() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarPoblacionEstudiantilMatriculados/MostrarDatos',
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

                            $("<td>").text(item.dniMatriculado),
                            $("<td>").text(item.fechaNacimiento),
                            $("<td>").text(item.sexoMatriculado),
                            $("<td>").text(item.codigoInstitucionEducativa),
                            $("<td>").text(item.codigoNivelEstudio),
                            $("<td>").text(item.gradoEstudio),
                            $("<td>").text(item.codigoSeccionEstudio),
                            $("<td>").text(item.especificacionEstudio),
                            $("<td>").text(item.codigoCategoriaPago),
                            $("<td>").text(item.codigoResultadoEjercicioEducativo)
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
    fetch("BienestarPoblacionEstudiantilMatriculados/EnviarDatos", {
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
    $.getJSON('/BienestarPoblacionEstudiantilMatriculados/cargaCombs', [], function (Json) {
        var institucionEducativa = Json["data1"];
        var nivelEstudio = Json["data2"];
        var seccionEstudio = Json["data3"];
        var categoriaPago = Json["data4"];
        var resultadoEjercicioEducativo = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbInstitucionEducativa").html("");
        $("select#cbInstitucionEducativae").html("");
        $.each(institucionEducativa, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativa + '>' + this.descInstitucionEducativa + '</option>'
            $("select#cbInstitucionEducativa").append(RowContent);
            $("select#cbInstitucionEducativae").append(RowContent);
        });

        $("select#cbGradoPersonalMilitar").html("");
        $("select#cbGradoPersonalMilitare").html("");
        $.each(nivelEstudio, function () {
            var RowContent = '<option value=' + this.codigoNivelEstudio + '>' + this.descNivelEstudio + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });

        $("select#cbSeccionEstudio").html("");
        $("select#cbSeccionEstudioe").html("");
        $.each(seccionEstudio, function () {
            var RowContent = '<option value=' + this.codigoSeccionEstudio + '>' + this.descSeccionEstudio + '</option>'
            $("select#cbSeccionEstudio").append(RowContent);
            $("select#cbSeccionEstudioe").append(RowContent);
        });

        $("select#cbCategoriaPago").html("");
        $("select#cbCategoriaPagoe").html("");
        $.each(categoriaPago, function () {
            var RowContent = '<option value=' + this.codigoCategoriaPago + '>' + this.descCategoriaPago + '</option>'
            $("select#cbCategoriaPago").append(RowContent);
            $("select#cbCategoriaPagoe").append(RowContent);
        });

        $("select#cbResultadoEjercicioE").html("");
        $("select#cbResultadoEjercicioEe").html("");
        $.each(resultadoEjercicioEducativo, function () {
            var RowContent = '<option value=' + this.codigoResultadoEjercicioEducativo + '>' + this.descResultadoEjercicioEducativo + '</option>'
            $("select#cbResultadoEjercicioE").append(RowContent);
            $("select#cbResultadoEjercicioEe").append(RowContent);
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

    reporteSeleccionado = '/BienestarPoblacionEstudiantilMatriculados/ReporteARTR';
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