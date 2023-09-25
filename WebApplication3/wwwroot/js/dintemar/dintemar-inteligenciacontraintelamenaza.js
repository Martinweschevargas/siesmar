var tblDintemarInteligenciaContraintelAmenaza;
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
                                url: '/DintemarInteligenciaContraintelAmenaza/Insertar',
                                data: {
                                    'CodigoAmenazaSeguridadNacional': $('#cbAmenazasSN').val(),
                                    'NotasInteligentes': $('#txtNotasInteligencia').val(),
                                    'EstudiosInteligencia': $('#txtEstudiosInteligencia').val(),
                                    'ApreciacionesInteligencia': $('#txtApreciacionesI').val(),
                                    'NotasInformacion': $('#txtNotasI').val(),
                                    'NotasContrainteligencia': $('#txtNotasContraI').val(),
                                    'EstudiosContrainteligencia': $('#txtEstudiosContra').val(),
                                    'ApreciacionesContrainteligencia': $('#txtApreciacionesContra').val(),
                                    'NotasInformacionContrainteligencia': $('#txtNotasInfoContra').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'Fecha': $('#txtFecha').val(),
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
                                    $('#tblDintemarInteligenciaContraintelAmenaza').DataTable().ajax.reload();
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
                                url: '/DintemarInteligenciaContraintelAmenaza/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoAmenazaSeguridadNacional': $('#cbAmenazasSNe').val(),
                                    'NotasInteligentes': $('#txtNotasInteligenciae').val(),
                                    'EstudiosInteligencia': $('#txtEstudiosInteligenciae').val(),
                                    'ApreciacionesInteligencia': $('#txtApreciacionesIe').val(),
                                    'NotasInformacion': $('#txtNotasIe').val(),
                                    'NotasContrainteligencia': $('#txtNotasContraIe').val(),
                                    'EstudiosContrainteligencia': $('#txtEstudiosContrae').val(),
                                    'ApreciacionesContrainteligencia': $('#txtApreciacionesContrae').val(),
                                    'NotasInformacionContrainteligencia': $('#txtNotasInfoContrae').val(),
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
                                    $('#tblDintemarInteligenciaContraintelAmenaza').DataTable().ajax.reload();
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

        tblDintemarInteligenciaContraintelAmenaza = $('#tblDintemarInteligenciaContraintelAmenaza').DataTable({
        ajax: {
            "url": '/DintemarInteligenciaContraintelAmenaza/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "inteligenciaContrainteligenciaAmenazaId" },
            { "data": "descAmenazaSeguridadNacional" },
            { "data": "notasInteligentes" },
            { "data": "estudiosInteligencia" },
            { "data": "apreciacionesInteligencia" },
            { "data": "notasInformacion" },
            { "data": "notasContrainteligencia" },
            { "data": "estudiosContrainteligencia" },
            { "data": "apreciacionesContrainteligencia" },
            { "data": "notasInformacionContrainteligencia" },
            { "data": "cargaId" }, 

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.inteligenciaContrainteligenciaAmenazaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.inteligenciaContrainteligenciaAmenazaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dintemar - Producción de Documentos de Inteligencia y Contrainteligencia por Amenaza',
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
                filename: 'Dintemar - Producción de Documentos de Inteligencia y Contrainteligencia por Amenaza',
                title: 'Dintemar - Producción de Documentos de Inteligencia y Contrainteligencia por Amenaza',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dintemar - Producción de Documentos de Inteligencia y Contrainteligencia por Amenaza',
                title: 'Dintemar - Producción de Documentos de Inteligencia y Contrainteligencia por Amenaza',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dintemar - Producción de Documentos de Inteligencia y Contrainteligencia por Amenaza',
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
    tblDintemarInteligenciaContraintelAmenaza.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDintemarInteligenciaContraintelAmenaza.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DintemarInteligenciaContraintelAmenaza/Mostrar?Id=' + Id, [], function (InteligenciaContraintelAmenazaDTO) {
        $('#txtCodigo').val(InteligenciaContraintelAmenazaDTO.inteligenciaContrainteligenciaAmenazaId);
        $('#cbAmenazasSNe').val(InteligenciaContraintelAmenazaDTO.codigoAmenazaSeguridadNacional);
        $('#txtNotasInteligenciae').val(InteligenciaContraintelAmenazaDTO.notasInteligentes);
        $('#txtEstudiosInteligenciae').val(InteligenciaContraintelAmenazaDTO.estudiosInteligencia);
        $('#txtApreciacionesIe').val(InteligenciaContraintelAmenazaDTO.apreciacionesInteligencia);
        $('#txtNotasIe').val(InteligenciaContraintelAmenazaDTO.notasInformacion);
        $('#txtNotasContraIe').val(InteligenciaContraintelAmenazaDTO.notasContrainteligencia);
        $('#txtEstudiosContrae').val(InteligenciaContraintelAmenazaDTO.estudiosContrainteligencia);
        $('#txtApreciacionesContrae').val(InteligenciaContraintelAmenazaDTO.apreciacionesContrainteligencia);
        $('#txtNotasInfoContrae').val(InteligenciaContraintelAmenazaDTO.notasInformacionContrainteligencia);
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
                url: '/DintemarInteligenciaContraintelAmenaza/Eliminar',
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
                    $('#tblDintemarInteligenciaContraintelAmenaza').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDintemarInteligenciaContraintelAmenaza() {
    $('#listar').hide();
    $('#nuevo').show();
}
function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DintemarInteligenciaContraintelAmenaza/MostrarDatos',
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
                            $("<td>").text(item.codigoAmenazaSeguridadNacional),
                            $("<td>").text(item.notasInteligentes),
                            $("<td>").text(item.estudiosInteligencia),
                            $("<td>").text(item.apreciacionesInteligencia),
                            $("<td>").text(item.notasInformacion),
                            $("<td>").text(item.notasContrainteligencia),
                            $("<td>").text(item.estudiosContrainteligencia),
                            $("<td>").text(item.apreciacionesContrainteligencia),
                            $("<td>").text(item.notasInformacionContrainteligencia),
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
    fetch("DintemarInteligenciaContraintelAmenaza/EnviarDatos", {
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
    $.getJSON('/DintemarInteligenciaContraintelAmenaza/cargaCombs', [], function (Json) {
        var AmenazaSeguridadNacional = Json["data1"];
        var listaCargas = Json["data2"];


        $("select#cbAmenazasSN").html("");
        $.each(AmenazaSeguridadNacional, function () {
            var RowContent = '<option value=' + this.codigoAmenazaSeguridadNacional + '>' + this.descAmenazaSeguridadNacional + '</option>'
            $("select#cbAmenazasSN").append(RowContent);
        });
        $("select#cbAmenazasSNe").html("");
        $.each(AmenazaSeguridadNacional, function () {
            var RowContent = '<option value=' + this.codigoAmenazaSeguridadNacional + '>' + this.descAmenazaSeguridadNacional + '</option>'
            $("select#cbAmenazasSNe").append(RowContent);
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
                url: '/DintemarInteligenciaContraintelAmenaza/EliminarCarga',
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
                    $('#tblDintemarInteligenciaContraintelAmenaza').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DintemarInteligenciaContraintelAmenaza/ReporteDICA?idCarga=';
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