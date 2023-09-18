var tblInventarioSIProduccion;
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
                                url: '/DirtelInventarioSIProduccion/Insertar',
                                data: {
                                    'NombreSIProduccion': $('#txtNomSitema').val(),
                                    'SiglasSIProduccion': $('#txtSiglaSoft').val(),
                                    'CodigoAreaSatisfaceDirtel ': $('#cbArea').val(),
                                    'DescripcionFuncionalidad': $('#txtDescFun').val(),
                                    'CodigoCicloDesarrolloSoftware ': $('#cbCicloDe').val(),
                                    'AlcanceSIProduccion': $('#txtAlcanceSis').val(),
                                    'ProcedenciaSIProduccion': $('#txtProcedencia').val(),
                                    'CodigoDenominacionBaseDato ': $('#cbDenominacionBase').val(),
                                    'ServidorBDSIProduccion': $('#txtServidorBD').val(),
                                    'CodigoDenominacionLenguajeProgramacion ': $('#cbDenominacionLengu').val(),
                                    'ServidorWebSIProduccion': $('#txtServidorWeb').val(),
                                    'CodigoDependencia ': $('#cbDependencia').val(), 
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
                                    $('#tblInventarioSIProduccion').DataTable().ajax.reload();
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
                                url: '/DirtelInventarioSIProduccion/Actualizar',
                                data: {
                                    'InventarioSIProduccionId': $('#txtCodigo').val(),
                                    'NombreSIProduccion': $('#txtNomSitemae').val(),
                                    'SiglasSIProduccion': $('#txtSiglaSofte').val(),
                                    'CodigoAreaSatisfaceDirtel ': $('#cbAreae').val(),
                                    'DescripcionFuncionalidad': $('#txtDescFune').val(),
                                    'CodigoCicloDesarrolloSoftware ': $('#cbCicloDee').val(),
                                    'AlcanceSIProduccion': $('#txtAlcanceSise').val(),
                                    'ProcedenciaSIProduccion': $('#txtProcedenciae').val(),
                                    'CodigoDenominacionBaseDato ': $('#cbDenominacionBasee').val(),
                                    'ServidorBDSIProduccion': $('#txtServidorBDe').val(),
                                    'CodigoDenominacionLenguajeProgramacion ': $('#cbDenominacionLengue').val(),
                                    'ServidorWebSIProduccion': $('#txtServidorWebe').val(),
                                    'CodigoDependencia ': $('#cbDependenciae').val(), 
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
                                    $('#tblInventarioSIProduccion').DataTable().ajax.reload();
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


        tblInventarioSIProduccion = $('#tblInventarioSIProduccion').DataTable({
        ajax: {
            "url": '/DirtelInventarioSIProduccion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "inventarioSIProduccionId" },
            { "data": "nombreSIProduccion" },
            { "data": "siglasSIProduccion" },
            { "data": "descAreaSatisfaceDirtel" },
            { "data": "descripcionFuncionalidad" },
            { "data": "descCicloDesarrolloSoftware" },
            { "data": "alcanceSIProduccion" },
            { "data": "procedenciaSIProduccion" },
            { "data": "descDenominacionBaseDato" },
            { "data": "servidorBDSIProduccion" },  
            { "data": "descDenominacionLenguajeProgramacion" },   
            { "data": "servidorWebSIProducción" },
            { "data": "descDependencia" },
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.inventarioSIProduccionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.inventarioSIProduccionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirtel - Inventario de Sistemas de Informacion en Producción',
                title: 'Dirtel - Inventario de Sistemas de Informacion en Producción',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirtel - Inventario de Sistemas de Informacion en Producción',
                title: 'Dirtel - Inventario de Sistemas de Informacion en Producción',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirtel - Inventario de Sistemas de Informacion en Producción',
                title: 'Dirtel - Inventario de Sistemas de Informacion en Producción',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirtel - Inventario de Sistemas de Informacion en Producción',
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
    tblInventarioSIProduccion.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblInventarioSIProduccion.columns(13).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirtelInventarioSIProduccion/Mostrar?Id=' + Id, [], function (InventarioSIProduccionDTO) {
        $('#txtCodigo').val(InventarioSIProduccionDTO.inventarioSIProduccionId);
        $('#txtNomSitemae').val(InventarioSIProduccionDTO.nombreSIProduccion);
        $('#txtSiglaSofte').val(InventarioSIProduccionDTO.siglasSIProduccion);
        $('#cbAreae').val(InventarioSIProduccionDTO.codigoAreaSatisfaceDirtel);
        $('#txtDescFune').val(InventarioSIProduccionDTO.descripcionFuncionalidad);
        $('#cbCicloDee').val(InventarioSIProduccionDTO.codigoCicloDesarrolloSoftware);
        $('#txtAlcanceSise').val(InventarioSIProduccionDTO.alcanceSIProduccion);
        $('#txtProcedenciae').val(InventarioSIProduccionDTO.procedenciaSIProduccion);
        $('#cbDenominacionBasee').val(InventarioSIProduccionDTO.codigoDenominacionBaseDato);
        $('#txtServidorBDe').val(InventarioSIProduccionDTO.servidorBDSIProduccion);
        $('#cbDenominacionLengue').val(InventarioSIProduccionDTO.codigoDenominacionLenguajeProgramacion);
        $('#txtServidorWebe').val(InventarioSIProduccionDTO.servidorWebSIProduccion);
        $('#cbDependenciae').val(InventarioSIProduccionDTO.codigoDependencia); 
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
                url: '/DirtelInventarioSIProduccion/Eliminar',
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
                    $('#tblInventarioSIProduccion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaInventarioSIProduccion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DirtelInventarioSIProduccion/MostrarDatos',
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
                            $("<td>").text(item.nombreSIProduccion),
                            $("<td>").text(item.siglasSIProduccion),
                            $("<td>").text(item.codigoAreaSatisfaceDirtel),
                            $("<td>").text(item.descripcionFuncionalidad),
                            $("<td>").text(item.codigoCicloDesarrolloSoftware),
                            $("<td>").text(item.alcanceSIProduccion),
                            $("<td>").text(item.procedenciaSIProduccion),
                            $("<td>").text(item.codigoDenominacionBaseDato),
                            $("<td>").text(item.servidorBDSIProduccion),
                            $("<td>").text(item.codigoDenominacionLenguajeProgramacion),
                            $("<td>").text(item.servidorWebSIProduccion),
                            $("<td>").text(item.codigoDependencia),
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
    fetch("DirtelInventarioSIProduccion/EnviarDatos", {
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
    $.getJSON('/DirtelInventarioSIProduccion/cargaCombs', [], function (Json) {
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
        reporteSeleccionado = '/DirtelInventarioSIProduccion/ReporteDISIP?idCarga=';
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