var tblDirtelRegistroDesarrolloSistemaInstitucional;
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
                                url: '/DirtelRegistroDesarrolloSistemaInstitucional/Insertar',
                                data: {
                                    'NombreSistema': $('#txtNomSitema').val(),
                                    'SiglaSoftware': $('#txtSiglaSoft').val(),
                                    'CodigoAreaSatisfaceDirtel ': $('#cbArea').val(),
                                    'DescripcionFuncionalidad': $('#cbDescFun').val(),
                                    'FechaDesarrollo': $('#txtFechaDe').val(),
                                    'CodigoCicloDesarrolloSoftware ': $('#cbCicloDe').val(),
                                    'AvanceDesarrollo': $('#txtAvanceDe').val(),
                                    'ServicioWeb': $('#txtServicio').val(),
                                    'AlcanceSistemaInstitucional': $('#txtAlcanceSis').val(),
                                    'ModalidadDesarrollo': $('#txtModalidad').val(),
                                    'CodigoDenominacionBaseDato ': $('#cbDenominacionBase').val(),
                                    'CodigoDenominacionLenguajeProgramacion ': $('#cbDenominacionLengu').val(),
                                    'ServidorWeb': $('#txtServidor').val(), 
                                    'CodigoDependencia ': $('#cbDependencia').val(),
                                    'FechaPuestaProduccion': $('#txtFechaPues').val(), 
                                    'ServidorBD': $('#txtServidorBD').val(),
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
                                    $('#tblDirtelRegistroDesarrolloSistemaInstitucional').DataTable().ajax.reload();
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
                                url: '/DirtelRegistroDesarrolloSistemaInstitucional/Actualizar',
                                data: {
                                    'RegistroDesarrolloSistemaInstitucionalId': $('#txtCodigo').val(),
                                    'NombreSistema': $('#txtNomSitemae').val(),
                                    'SiglaSoftware': $('#txtSiglaSofte').val(),
                                    'CodigoAreaSatisfaceDirtel ': $('#cbAreae').val(),
                                    'DescripcionFuncionalidad': $('#cbDescFune').val(),
                                    'FechaDesarrollo': $('#txtFechaDee').val(),
                                    'CodigoCicloDesarrolloSoftware ': $('#cbCicloDee').val(),
                                    'AvanceDesarrollo': $('#txtAvanceDee').val(),
                                    'ServicioWeb': $('#txtServicioe').val(),
                                    'AlcanceSistemaInstitucional': $('#txtAlcanceSise').val(),
                                    'ModalidadDesarrollo': $('#txtModalidade').val(),
                                    'CodigoDenominacionBaseDato ': $('#cbDenominacionBasee').val(),
                                    'CodigoDenominacionLenguajeProgramacion ': $('#cbDenominacionLengue').val(),
                                    'ServidorWeb': $('#txtServidore').val(),
                                    'CodigoDependencia ': $('#cbDependenciae').val(),
                                    'FechaPuestaProduccion': $('#txtFechaPuese').val(),
                                    'ServidorBD': $('#txtServidorBDe').val(),
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
                                    $('#tblDirtelRegistroDesarrolloSistemaInstitucional').DataTable().ajax.reload();
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

        tblDirtelRegistroDesarrolloSistemaInstitucional = $('#tblDirtelRegistroDesarrolloSistemaInstitucional').DataTable({
        ajax: {
            "url": '/DirtelRegistroDesarrolloSistemaInstitucional/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroDesarrolloSistemaInstitucionalId" },
            { "data": "nombreSistema" },
            { "data": "siglaSoftware" },
            { "data": "descAreaSatisfaceDirtel" },
            { "data": "descripcionFuncionalidad" },
            { "data": "fechaDesarrollo" },
            { "data": "descCicloDesarrolloSoftware" },
            { "data": "avanceDesarrollo" },
            { "data": "servicioWeb" },
            { "data": "alcanceSistemaInstitucional" },  
            { "data": "modalidadDesarrollo" },   
            { "data": "descDenominacionBaseDato" },
            { "data": "descDenominacionLenguajeProgramacion" },
            { "data": "servidorWeb" },
            { "data": "descDependencia" },
            { "data": "fechaPuestaProduccion" },   
            { "data": "servidorBD" },
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroDesarrolloSistemaInstitucionalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroDesarrolloSistemaInstitucionalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirtel - Registro de Desarrollo de Sistemas Institucionales',
                title: 'Dirtel - Registro de Desarrollo de Sistemas Institucionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirtel - Registro de Desarrollo de Sistemas Institucionales',
                title: 'Dirtel - Registro de Desarrollo de Sistemas Institucionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirtel - Registro de Desarrollo de Sistemas Institucionales',
                title: 'Dirtel - Registro de Desarrollo de Sistemas Institucionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirtel - Registro de Desarrollo de Sistemas Institucionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
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
    tblDirtelRegistroDesarrolloSistemaInstitucional.columns(17).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDirtelRegistroDesarrolloSistemaInstitucional.columns(17).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirtelRegistroDesarrolloSistemaInstitucional/Mostrar?Id=' + Id, [], function (RegistroDesarrolloSistemaInstitucionalDTO) {
        $('#txtCodigo').val(RegistroDesarrolloSistemaInstitucionalDTO.registroDesarrolloSistemaInstitucionalId);
        $('#txtNomSitemae').val(RegistroDesarrolloSistemaInstitucionalDTO.nombreSistema);
        $('#txtSiglaSofte').val(RegistroDesarrolloSistemaInstitucionalDTO.siglaSoftware);
        $('#cbAreae').val(RegistroDesarrolloSistemaInstitucionalDTO.codigoAreaSatisfaceDirtel);
        $('#cbDescFune').val(RegistroDesarrolloSistemaInstitucionalDTO.descripcionFuncionalidad);
        $('#txtFechaDee').val(RegistroDesarrolloSistemaInstitucionalDTO.fechaDesarrollo);
        $('#cbCicloDee').val(RegistroDesarrolloSistemaInstitucionalDTO.codigoCicloDesarrolloSoftware);
        $('#txtAvanceDee').val(RegistroDesarrolloSistemaInstitucionalDTO.avanceDesarrollo);
        $('#txtServicioe').val(RegistroDesarrolloSistemaInstitucionalDTO.servicioWeb);
        $('#txtAlcanceSise').val(RegistroDesarrolloSistemaInstitucionalDTO.alcanceSistemaInstitucional);
        $('#txtModalidade').val(RegistroDesarrolloSistemaInstitucionalDTO.modalidadDesarrollo);
        $('#cbDenominacionBasee').val(RegistroDesarrolloSistemaInstitucionalDTO.codigoDenominacionBaseDato);
        $('#cbDenominacionLengue').val(RegistroDesarrolloSistemaInstitucionalDTO.codigoDenominacionLenguajeProgramacion);
        $('#txtServidore').val(RegistroDesarrolloSistemaInstitucionalDTO.servidorWeb);
        $('#cbDependenciae').val(RegistroDesarrolloSistemaInstitucionalDTO.codigoDependencia);
        $('#txtFechaPuese').val(RegistroDesarrolloSistemaInstitucionalDTO.fechaPuestaProduccion); 
        $('#txtServidorBDe').val(RegistroDesarrolloSistemaInstitucionalDTO.servidorBD); 
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
                url: '/DirtelRegistroDesarrolloSistemaInstitucional/Eliminar',
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
                    $('#tblDirtelRegistroDesarrolloSistemaInstitucional').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirtelRegistroDesarrolloSistemaInstitucional() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirtelRegistroDesarrolloSistemaInstitucional/MostrarDatos',
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
                            $("<td>").text(item.nombreSistema),
                            $("<td>").text(item.siglaSoftware),
                            $("<td>").text(item.codigoAreaSatisfaceDirtel),
                            $("<td>").text(item.descripcionFuncionalidad),
                            $("<td>").text(item.fechaDesarrollo),
                            $("<td>").text(item.codigoCicloDesarrolloSoftware),
                            $("<td>").text(item.avanceDesarrollo),
                            $("<td>").text(item.servicioWeb),
                            $("<td>").text(item.alcanceSistemaInstitucional),
                            $("<td>").text(item.modalidadDesarrollo),
                            $("<td>").text(item.codigoDenominacionBaseDato),
                            $("<td>").text(item.codigoDenominacionLenguajeProgramacion),
                            $("<td>").text(item.servidorWeb),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.fechaPuestaProduccion),
                            $("<td>").text(item.servidorBD),
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
    fetch("DirtelRegistroDesarrolloSistemaInstitucional/EnviarDatos", {
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
    $.getJSON('/DirtelRegistroDesarrolloSistemaInstitucional/cargaCombs', [], function (Json) {
        var areaSatisfaceDirtel = Json["data1"];
        var cicloDesarrolloSoftware = Json["data2"];
        var denominacionBaseDato = Json["data3"];
        var denominacionLenguajeProgramacion = Json["data4"];
        var dependencia = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbArea").html("");
        $.each(areaSatisfaceDirtel, function () {
            var RowContent = '<option value=' + this.codigoAreaSatisfaceDirtel + '>' + this.descAreaSatisfaceDirtel + '</option>'
            $("select#cbArea").append(RowContent);
        });
        $("select#cbAreae").html("");
        $.each(areaSatisfaceDirtel, function () {
            var RowContent = '<option value=' + this.codigoAreaSatisfaceDirtel + '>' + this.descAreaSatisfaceDirtel + '</option>'
            $("select#cbAreae").append(RowContent);
        });

        $("select#cbCicloDe").html("");
        $.each(cicloDesarrolloSoftware, function () {
            var RowContent = '<option value=' + this.codigoCicloDesarrolloSoftware + '>' + this.descCicloDesarrolloSoftware + '</option>'
            $("select#cbCicloDe").append(RowContent);
        });
        $("select#cbCicloDee").html("");
        $.each(cicloDesarrolloSoftware, function () {
            var RowContent = '<option value=' + this.codigoCicloDesarrolloSoftware + '>' + this.descCicloDesarrolloSoftware + '</option>'
            $("select#cbCicloDee").append(RowContent);
        });

        $("select#cbDenominacionBase").html("");
        $.each(denominacionBaseDato, function () {
            var RowContent = '<option value=' + this.codigoDenominacionBaseDato + '>' + this.descDenominacionBaseDato + '</option>'
            $("select#cbDenominacionBase").append(RowContent);
        });
        $("select#cbDenominacionBasee").html("");
        $.each(denominacionBaseDato, function () {
            var RowContent = '<option value=' + this.codigoDenominacionBaseDato + '>' + this.descDenominacionBaseDato + '</option>'
            $("select#cbDenominacionBasee").append(RowContent);
        });

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

        $("select#cbDenominacionLengu").html("");
        $.each(denominacionLenguajeProgramacion, function () {
            var RowContent = '<option value=' + this.codigoDenominacionLenguajeProgramacion + '>' + this.descDenominacionLenguajeProgramacion + '</option>'
            $("select#cbDenominacionLengu").append(RowContent);
        });
        $("select#cbDenominacionLengue").html("");
        $.each(denominacionLenguajeProgramacion, function () {
            var RowContent = '<option value=' + this.codigoDenominacionLenguajeProgramacion + '>' + this.descDenominacionLenguajeProgramacion + '</option>'
            $("select#cbDenominacionLengue").append(RowContent);
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
        reporteSeleccionado = '/DirtelRegistroDesarrolloSistemaInstitucional/ReporteDRDSI?idCarga=';
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