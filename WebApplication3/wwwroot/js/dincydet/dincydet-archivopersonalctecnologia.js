var tblDincydetArchivoPersonalCTecnologia;
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
                                url: '/DincydetArchivoPersonalCTecnologia/Insertar',
                                data: {
                                    'DNIPersonalCT': $('#txtDNI').val(),
                                    'AniosTrabajoPersonalCT': $('#txtAnioTrabajo').val(),
                                    'SexoPersonalCT': $('#txtSexo').val(),
                                    'CodigoFormacionAcademica': $('#cbFormacionAcademica').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalM').val(),
                                    'CodigoTituloProfesionalObtenido': $('#cbTituloProfesionalO').val(),
                                    'NaturalezaTrabajoPersonalCT': $('#txtNaturalezaTrabajo').val(),
                                    'EspecializacionPersonaCT': $('#txtEspecializacion').val(),
                                    'CodigoAreaCT': $('#cbAreasCT').val(),
                                    'DedicacionTiempoPersonalCT': $('#txtDedicacionT').val(),
                                    'ParticipacionProgramas': $('#txtParticipacionProg').val(),
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
                                    $('#tblDincydetArchivoPersonalCTecnologia').DataTable().ajax.reload();
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
                                url: '/DincydetArchivoPersonalCTecnologia/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPersonalCT': $('#txtDNIe').val(),
                                    'AniosTrabajoPersonalCT': $('#txtAnioTrabajoe').val(),
                                    'SexoPersonalCT': $('#txtSexoe').val(),
                                    'CodigoFormacionAcademica': $('#cbFormacionAcademicae').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMe').val(),
                                    'CodigoTituloProfesionalObtenido': $('#cbTituloProfesionalOe').val(),
                                    'NaturalezaTrabajoPersonalCT': $('#txtNaturalezaTrabajoe').val(),
                                    'EspecializacionPersonaCT': $('#txtEspecializacione').val(),
                                    'CodigoAreaCT': $('#cbAreasCTe').val(),
                                    'DedicacionTiempoPersonalCT': $('#txtDedicacionTe').val(),
                                    'ParticipacionProgramas': $('#txtParticipacionProge').val(),
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
                                    $('#tblDincydetArchivoPersonalCTecnologia').DataTable().ajax.reload();
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

   tblDincydetArchivoPersonalCTecnologia =  $('#tblDincydetArchivoPersonalCTecnologia').DataTable({
        ajax: {
            "url": '/DincydetArchivoPersonalCTecnologia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "archivoPersonalCienciaTecnologiaId" },
            { "data": "dniPersonalCT" },
            { "data": "aniosTrabajoPersonalCT" },
            { "data": "sexoPersonalCT" },
            { "data": "descFormacionAcademica" },
            { "data": "descGrado" },
            { "data": "descTituloProfesionalObtenido" },
            { "data": "naturalezaTrabajoPersonalCT" },
            { "data": "especializacionPersonaCT" },
            { "data": "descAreaCT" },
            { "data": "dedicacionTiempoPersonalCT" },
            { "data": "participacionProgramas" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.archivoPersonalCienciaTecnologiaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.archivoPersonalCienciaTecnologiaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dincydet - Archivo para Personal en Ciencia y Tecnología',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dincydet - Archivo para Personal en Ciencia y Tecnología',
                title: 'Dincydet - Archivo para Personal en Ciencia y Tecnología',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dincydet - Archivo para Personal en Ciencia y Tecnología',
                title: 'Dincydet - Archivo para Personal en Ciencia y Tecnología',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dincydet - Archivo para Personal en Ciencia y Tecnología',
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
    tblDincydetArchivoPersonalCTecnologia.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDincydetArchivoPersonalCTecnologia.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DincydetArchivoPersonalCTecnologia/Mostrar?Id=' + Id, [], function (ArchivoPersonalCienciaTecnologiaDTO) {
        $('#txtCodigo').val(ArchivoPersonalCienciaTecnologiaDTO.archivoPersonalCienciaTecnologiaId);
        $('#txtDNIe').val(ArchivoPersonalCienciaTecnologiaDTO.dniPersonalCT);
        $('#txtAnioTrabajoe').val(ArchivoPersonalCienciaTecnologiaDTO.aniosTrabajoPersonalCT);
        $('#txtSexoe').val(ArchivoPersonalCienciaTecnologiaDTO.sexoPersonalCT);
        $('#cbFormacionAcademicae').val(ArchivoPersonalCienciaTecnologiaDTO.codigoFormacionAcademica);
        $('#cbGradoPersonalMe').val(ArchivoPersonalCienciaTecnologiaDTO.codigoGradoPersonalMilitar);
        $('#cbTituloProfesionalOe').val(ArchivoPersonalCienciaTecnologiaDTO.codigoTituloProfesionalObtenido);
        $('#txtNaturalezaTrabajoe').val(ArchivoPersonalCienciaTecnologiaDTO.naturalezaTrabajoPersonalCT);
        $('#txtEspecializacione').val(ArchivoPersonalCienciaTecnologiaDTO.especializacionPersonaCT);
        $('#cbAreasCTe').val(ArchivoPersonalCienciaTecnologiaDTO.codigoAreaCT);
        $('#txtDedicacionTe').val(ArchivoPersonalCienciaTecnologiaDTO.dedicacionTiempoPersonalCT);
        $('#txtParticipacionProge').val(ArchivoPersonalCienciaTecnologiaDTO.participacionProgramas);
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
                url: '/DincydetArchivoPersonalCTecnologia/Eliminar',
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
                    $('#tblDincydetArchivoPersonalCTecnologia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDincydetArchivoPersonalCTecnologia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DincydetArchivoPersonalCTecnologia/MostrarDatos',
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
                            $("<td>").text(item.dniPersonalCT),
                            $("<td>").text(item.aniosTrabajoPersonalCT),
                            $("<td>").text(item.sexoPersonalCT),
                            $("<td>").text(item.codigoFormacionAcademica),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoTituloProfesionalObtenido),
                            $("<td>").text(item.naturalezaTrabajoPersonalCT),
                            $("<td>").text(item.especializacionPersonaCT),
                            $("<td>").text(item.codigoAreaCT),
                            $("<td>").text(item.dedicacionTiempoPersonalCT),
                            $("<td>").text(item.participacionProgramas)
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
    fetch("DincydetArchivoPersonalCTecnologia/EnviarDatos", {
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
                url: '/DincydetArchivoPersonalCTecnologia/EliminarCarga',
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
                    $('#tblDincydetArchivoPersonalCTecnologia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DincydetArchivoPersonalCTecnologia/cargaCombs', [], function (Json) {
        var formacionAcademica= Json["data1"];
        var gradoPersonalMilitar= Json["data2"];
        var tituloProfesionalObtenido= Json["data3"];
        var areaCT= Json["data4"];
        var listaCargas = Json["data5"];


        $("select#cbFormacionAcademica").html("");
        $.each(formacionAcademica, function () {
            var RowContent = '<option value=' + this.codigoFormacionAcademica + '>' + this.descFormacionAcademica + '</option>'
            $("select#cbFormacionAcademica").append(RowContent);
        });
        $("select#cbFormacionAcademicae").html("");
        $.each(formacionAcademica, function () {
            var RowContent = '<option value=' + this.codigoFormacionAcademica + '>' + this.descFormacionAcademica + '</option>'
            $("select#cbFormacionAcademicae").append(RowContent);
        });

        $("select#cbGradoPersonalM").html("");
        $("select#cbGradoPersonalMe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalM").append(RowContent);
            $("select#cbGradoPersonalMe").append(RowContent);
        });

        $("select#cbTituloProfesionalO").html("");
        $.each(tituloProfesionalObtenido, function () {
            var RowContent = '<option value=' + this.codigoTituloProfesionalObtenido + '>' + this.descTituloProfesionalObtenido + '</option>'
            $("select#cbTituloProfesionalO").append(RowContent);
        });
        $("select#cbTituloProfesionalOe").html("");
        $.each(tituloProfesionalObtenido, function () {
            var RowContent = '<option value=' + this.codigoTituloProfesionalObtenido + '>' + this.descTituloProfesionalObtenido + '</option>'
            $("select#cbTituloProfesionalOe").append(RowContent);
        });

        $("select#cbAreasCT").html("");
        $.each(areaCT, function () {
            var RowContent = '<option value=' + this.codigoAreaCT + '>' + this.descAreaCT + '</option>'
            $("select#cbAreasCT").append(RowContent);
        });
        $("select#cbAreasCTe").html("");
        $.each(areaCT, function () {
            var RowContent = '<option value=' + this.codigoAreaCT + '>' + this.descAreaCT + '</option>'
            $("select#cbAreasCTe").append(RowContent);
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

    reporteSeleccionado = '/DincydetArchivoPersonalCTecnologia/ReporteAPCT';
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