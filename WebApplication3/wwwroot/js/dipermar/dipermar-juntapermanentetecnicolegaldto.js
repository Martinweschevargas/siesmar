var tblDipermarJuntaPermanenteTecnicoLegal;
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
                                url: '/DipermarJuntaPermanenteTecnicoLegal/Insertar',
                                data: {
                                    'NroDocumentoJunta': $('#txtNDocumento').val(),
                                    'FechaDocumentoJunta': $('#txtFechaD').val(),
                                    'DocumentacionCompleta': $('#txtDocumentacionC').val(),
                                    'FechaIngresoDocumento': $('#txtFechaI').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonal').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGrado').val(),
                                    'SexoPersonal': $('#txtGenero').val(),
                                    'CodigoAfeccion': $('#cbAfeccion').val(),
                                    'SituacionActualJunta': $('#txtSituacionActual').val(),
                                    'NroActa': $('#txtNroActa').val(),
                                    'FechaActa': $('#txtFechaActa').val(),
                                    'ConclusionJunta': $('#txtConclusion').val(),
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
                                    $('#tblDipermarJuntaPermanenteTecnicoLegal').DataTable().ajax.reload();
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
                                url: '/DipermarJuntaPermanenteTecnicoLegal/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NroDocumentoJunta': $('#txtNDocumentoe').val(),
                                    'FechaDocumentoJunta': $('#txtFechaDe').val(),
                                    'DocumentacionCompleta': $('#txtDocumentacionCe').val(),
                                    'FechaIngresoDocumento': $('#txtFechaIe').val(),
                                    'CodigoTipoPersonalMilitar': $('#txtTipoPersonale').val(),
                                    'CodigoGradoPersonalMilitar': $('#txtGradoe').val(),
                                    'SexoPersonal': $('#txtGeneroe').val(),
                                    'CodigoAfeccion': $('#txtAfeccione').val(),
                                    'SituacionActualJunta': $('#txtSituacionActuale').val(),
                                    'NroActa': $('#txtNroActae').val(),
                                    'FechaActa': $('#txtFechaActae').val(),
                                    'ConclusionJunta': $('#txtConclusione').val()
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
                                    $('#tblDipermarJuntaPermanenteTecnicoLegal').DataTable().ajax.reload();
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

    tblDipermarJuntaPermanenteTecnicoLegal = $('#tblDipermarJuntaPermanenteTecnicoLegal').DataTable({
        ajax: {
            "url": '/DipermarJuntaPermanenteTecnicoLegal/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "juntaPermanenteTecnicoLegalId" },
            { "data": "nroDocumentoJunta" },
            { "data": "fechaDocumentoJunta" },
            { "data": "documentacionCompleta" },
            { "data": "fechaIngresoDocumento" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "sexoPersonal" },
            { "data": "descAfeccion" },
            { "data": "situacionActualJunta" },
            { "data": "nroActa" },
            { "data": "fechaActa" },
            { "data": "conclusionJunta" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.juntaPermanenteTecnicoLegalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.juntaPermanenteTecnicoLegalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dipermar - Junta Permanente Tecnico Legal del Personal Superior y Subalterno de la Marina de Guerra del Perú',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11, 12]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dipermar - Junta Permanente Tecnico Legal del Personal Superior y Subalterno de la Marina de Guerra del Perú',
                title: 'Dipermar - Junta Permanente Tecnico Legal del Personal Superior y Subalterno de la Marina de Guerra del Perú',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dipermar - Junta Permanente Tecnico Legal del Personal Superior y Subalterno de la Marina de Guerra del Perú',
                title: 'Dipermar - Junta Permanente Tecnico Legal del Personal Superior y Subalterno de la Marina de Guerra del Perú',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dipermar - Junta Permanente Tecnico Legal del Personal Superior y Subalterno de la Marina de Guerra del Perú',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
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
    tblDipermarJuntaPermanenteTecnicoLegal.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDipermarJuntaPermanenteTecnicoLegal.columns(13).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DipermarJuntaPermanenteTecnicoLegal/Mostrar?Id=' + Id, [], function (JuntaPermanenteTecnicoLegalDTO) {
        $('#txtCodigo').val(JuntaPermanenteTecnicoLegalDTO.juntaPermanenteTecnicoLegalId);
        $('#txtNDocumentoe').val(JuntaPermanenteTecnicoLegalDTO.nroDocumentoJunta);
        $('#txtFechaDe').val(JuntaPermanenteTecnicoLegalDTO.fechaDocumentoJunta);
        $('#txtDocumentacionCe').val(JuntaPermanenteTecnicoLegalDTO.documentacionCompleta);
        $('#txtFechaIe').val(JuntaPermanenteTecnicoLegalDTO.fechaIngresoDocumento);
        $('#cbTipoPersonale').val(JuntaPermanenteTecnicoLegalDTO.codigoTipoPersonalMilitar);
        $('#cbGradoe').val(JuntaPermanenteTecnicoLegalDTO.codigoGradoPersonalMilitar);
        $('#txtGeneroe').val(JuntaPermanenteTecnicoLegalDTO.sexoPersonal);
        $('#cbAfeccione').val(JuntaPermanenteTecnicoLegalDTO.codigoAfeccion);
        $('#txtSituacionActuale').val(JuntaPermanenteTecnicoLegalDTO.situacionActualJunta);
        $('#txtNroActae').val(JuntaPermanenteTecnicoLegalDTO.nroActa);
        $('#txtFechaActae').val(JuntaPermanenteTecnicoLegalDTO.fechaActa);
        $('#txtConclusione').val(JuntaPermanenteTecnicoLegalDTO.conclusionJunta); 
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
                url: '/DipermarJuntaPermanenteTecnicoLegal/Eliminar',
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
                    $('#tblDipermarJuntaPermanenteTecnicoLegal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDipermarJuntaPermanenteTecnicoLegal() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DipermarJuntaPermanenteTecnicoLegal/MostrarDatos',
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
                            $("<td>").text(item.nroDocumentoJunta),
                            $("<td>").text(item.fechaDocumentoJunta),
                            $("<td>").text(item.documentacionCompleta),
                            $("<td>").text(item.fechaIngresoDocumento),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.sexoPersonal),
                            $("<td>").text(item.codigoAfeccion),
                            $("<td>").text(item.situacionActualJunta),
                            $("<td>").text(item.nroActa),
                            $("<td>").text(item.fechaActa),
                            $("<td>").text(item.conclusionJunta)
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
    fetch("DipermarJuntaPermanenteTecnicoLegal/EnviarDatos", {
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
                url: '/DipermarJuntaPermanenteTecnicoLegal/EliminarCarga',
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
                    $('#tblDipermarJuntaPermanenteTecnicoLegal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DipermarJuntaPermanenteTecnicoLegal/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar   = Json["data1"];
        var tipoPersonalMilitar = Json["data2"];
        var afeccion = Json["data3"];
        var listaCargas = Json["data4"];

        $("select#cbGrado").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGrado").append(RowContent);
        });
        $("select#txtGradoe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#txtGradoe").append(RowContent);
        });

        $("select#cbTipoPersonal").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonal").append(RowContent);
        });
        $("select#txtTipoPersonale").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#txtTipoPersonale").append(RowContent);
        });

        $("select#cbAfeccion").html("");
        $.each(afeccion, function () {
            var RowContent = '<option value=' + this.codigoAfeccion + '>' + this.descAfeccion + '</option>'
            $("select#cbAfeccion").append(RowContent);
        });
        $("select#txtAfeccione").html("");
        $.each(afeccion, function () {
            var RowContent = '<option value=' + this.codigoAfeccion + '>' + this.descAfeccion + '</option>'
            $("select#txtAfeccione").append(RowContent);
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

    reporteSeleccionado = '/DipermarJuntaPermanenteTecnicoLegal/ReporteJPTC';
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