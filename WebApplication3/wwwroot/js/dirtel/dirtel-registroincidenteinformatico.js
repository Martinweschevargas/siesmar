var tblDirtelRegistroIncidenteInformatico;
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
                                url: '/DirtelRegistroIncidenteInformatico/Insertar',
                                data: {
                                    'CodigoDependencia ': $('#cbDependencia').val(),
                                    'FechaHoraIncidente': $('#txtFechaRe').val(),
                                    'NombreQuienReporta': $('#txtNombre').val(),
                                    'DescripcionIncidente': $('#txtDescripcion').val(),
                                    'CodigoTipoIncidenteSGS ': $('#cbTipoInci').val(),
                                    'NivelPrioridad': $('#txtNivel').val(),
                                    'EstrategiaErradicacion': $('#txtErradicacion').val(), 
                                    'CargaId': $('#cargasR').val(),
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
                                    $('#tblDirtelRegistroIncidenteInformatico').DataTable().ajax.reload();
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
                                url: '/DirtelRegistroIncidenteInformatico/Actualizar',
                                data: {
                                    'RegistroIncidenteInformaticoId': $('#txtCodigo').val(),
                                    'CodigoDependencia ': $('#cbDependenciae').val(),
                                    'FechaHoraIncidente': $('#txtFechaRee').val(),
                                    'NombreQuienReporta': $('#txtNombree').val(),
                                    'DescripcionIncidente': $('#txtDescripcione').val(),
                                    'CodigoTipoIncidenteSGS ': $('#cbTipoIncie').val(),
                                    'NivelPrioridad': $('#txtNivele').val(),
                                    'EstrategiaErradicacion': $('#txtErradicacione').val(), 
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
                                    $('#tblDirtelRegistroIncidenteInformatico').DataTable().ajax.reload();
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

        tblDirtelRegistroIncidenteInformatico = $('#tblDirtelRegistroIncidenteInformatico').DataTable({
        ajax: {
            "url": '/DirtelRegistroIncidenteInformatico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroIncidenteInformaticoId" },
            { "data": "descDependencia" },  
            { "data": "fechaHoraIncidente" },
            { "data": "nombreQuienReporta" },
            { "data": "descripcionIncidente" },
            { "data": "descTipoIncidenteSGSI" },
            { "data": "nivelPrioridad" },
            { "data": "estrategiaErradicacion" },  
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroIncidenteInformaticoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroIncidenteInformaticoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirtel - Incidentes Informaticos',
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
                filename: 'Dirtel - Incidentes Informaticos',
                title: 'Dirtel - Incidentes Informaticos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirtel - Incidentes Informaticos',
                title: 'Dirtel - Incidentes Informaticos',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirtel - Incidentes Informaticos',
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
    tblDirtelRegistroIncidenteInformatico.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirtelRegistroIncidenteInformatico.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirtelRegistroIncidenteInformatico/Mostrar?Id=' + Id, [], function (RegistroIncidenteInformaticoDTO) {
        $('#txtCodigo').val(RegistroIncidenteInformaticoDTO.registroIncidenteInformaticoId);
        $('#cbDependenciae').val(RegistroIncidenteInformaticoDTO.codigoDependencia);
        $('#txtFechaRee').val(RegistroIncidenteInformaticoDTO.fechaHoraIncidente);
        $('#txtNombree').val(RegistroIncidenteInformaticoDTO.nombreQuienReporta);
        $('#txtDescripcione').val(RegistroIncidenteInformaticoDTO.descripcionIncidente);
        $('#cbTipoIncie').val(RegistroIncidenteInformaticoDTO.codigoTipoIncidenteSGS);
        $('#txtNivele').val(RegistroIncidenteInformaticoDTO.nivelPrioridad);
        $('#txtErradicacione').val(RegistroIncidenteInformaticoDTO.estrategiaErradicacion);   
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
                url: '/DirtelRegistroIncidenteInformatico/Eliminar',
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
                    $('#tblDirtelRegistroIncidenteInformatico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirtelRegistroIncidenteInformatico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirtelRegistroIncidenteInformatico/MostrarDatos',
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
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.fechaHoraIncidente),
                            $("<td>").text(item.nombreQuienReporta),
                            $("<td>").text(item.descripcionIncidente),
                            $("<td>").text(item.codigoTipoIncidenteSGS),
                            $("<td>").text(item.nivelPrioridad),
                            $("<td>").text(item.estrategiaErradicacion),
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
    fetch("DirtelRegistroIncidenteInformatico/EnviarDatos", {
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
    $.getJSON('/DirtelRegistroIncidenteInformatico/cargaCombs', [], function (Json) {
        var dependencia = Json["data1"];
        var tipoIncidenteSGSI = Json["data2"];
        var listaCargas = Json["data3"];


        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbTipoInci").html("");
        $.each(tipoIncidenteSGSI, function () {
            var RowContent = '<option value=' + this.codigoTipoIncidenteSGS + '>' + this.descTipoIncidenteSGSI + '</option>'
            $("select#cbTipoInci").append(RowContent);
        });
        $("select#cbTipoIncie").html("");
        $.each(tipoIncidenteSGSI, function () {
            var RowContent = '<option value=' + this.codigoTipoIncidenteSGS + '>' + this.descTipoIncidenteSGSI + '</option>'
            $("select#cbTipoIncie").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    })
}

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DirtelRegistroIncidenteInformatico/ReporteDRII?idCarga=';
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
