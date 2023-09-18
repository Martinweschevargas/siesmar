var tblDicapiOtorgamientoDerechoAreaAcuatica;
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
                                url: '/DicapiOtorgamientoDerechoAreaAcuatica/Insertar',
                                data: {
                                    'NumeroDocumento': $('#txtNumero').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngreso').val(),
                                    'CodigoDptoRiberaZocaloCont': $('#cbDptoMaterial').val(),
                                    'PropietarioNave': $('#txtPropietario').val(),
                                    'CodigoInstalacionTerrestreAcuatica': $('#cbTerrestre').val(),
                                    'DistritoUbigeo': $('#cbDistrito').val(),
                                    'TiempoConcesion': $('#txtConsecion').val(),
                                    'TipoTiempo': $('#txtTipo').val(),
                                    'FechaAtencionSolicitud': $('#txtFechaAtencion').val(),
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
                                    $('#tblDicapiOtorgamientoDerechoAreaAcuatica').DataTable().ajax.reload();
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
                                url: '/DicapiOtorgamientoDerechoAreaAcuatica/Actualizar',
                                data: {
                                    'OtorgamientoDerechoAreaAcuaticaId': $('#txtCodigo').val(),
                                    'NumeroDocumento': $('#txtNumeroe').val(),
                                    'FechaIngresoSolicitud': $('#txtFechaIngresoe').val(),
                                    'CodigoDptoRiberaZocaloCont': $('#cbDptoMateriale').val(),
                                    'DocumentoExpedido': $('#txtDocumentoe').val(),
                                    'PropietarioNave': $('#txtPropietarioe').val(),
                                    'CodigoInstalacionTerrestreAcuatica': $('#cbTerrestree').val(),
                                    'DistritoUbigeo': $('#cbDistritoe').val(),
                                    'TiempoConcesion': $('#txtConsecione').val(),
                                    'TipoTiempo': $('#txtTipoe').val(),
                                    'FechaAtencionSolicitud': $('#txtFechaAtencione').val(), 
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
                                    $('#tblDicapiOtorgamientoDerechoAreaAcuatica').DataTable().ajax.reload();
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

   tblDicapiOtorgamientoDerechoAreaAcuatica = $('#tblDicapiOtorgamientoDerechoAreaAcuatica').DataTable({
        ajax: {
            "url": '/DicapiOtorgamientoDerechoAreaAcuatica/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "otorgamientoDerechoAreaAcuaticaId" },
            { "data": "numeroDocumento" },
            { "data": "fechaIngresoSolicitud" },
            { "data": "descDptoRiberaZocaloCont" },
            { "data": "documentoExpedido" },
            { "data": "propietarioNave" },
            { "data": "descInstalacionTerrestreAcuatica" },
            { "data": "descDepartamentoUbigeo" },
            { "data": "descProvinciaUbigeo" },  
            { "data": "descDistritoUbigeo" }, 
            { "data": "tiempoConcesion" },
            { "data": "tipoTiempo" },
            { "data": "fechaAtencionSolicitud" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.otorgamientoDerechoAreaAcuaticaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.otorgamientoDerechoAreaAcuaticaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dicapi - Otorgamiento de Derecho de uso de Areas Acuaticas',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dicapi - Otorgamiento de Derecho de uso de Areas Acuaticas',
                title: 'Dicapi - Otorgamiento de Derecho de uso de Areas Acuaticas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dicapi - Otorgamiento de Derecho de uso de Areas Acuaticas',
                title: 'Dicapi - Otorgamiento de Derecho de uso de Areas Acuaticas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dicapi - Otorgamiento de Derecho de uso de Areas Acuaticas',
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DicapiOtorgamientoDerechoAreaAcuatica/Mostrar?Id=' + Id, [], function (OtorgamientoDerechoAreaAcuaticaDTO) {
        $('#txtCodigo').val(OtorgamientoDerechoAreaAcuaticaDTO.otorgamientoDerechoAreaAcuaticaId);
        $('#txtNumeroe').val(OtorgamientoDerechoAreaAcuaticaDTO.numeroDocumento);
        $('#txtFechaIngresoe').val(OtorgamientoDerechoAreaAcuaticaDTO.fechaIngresoSolicitud);
        $('#cbDptoMateriale').val(OtorgamientoDerechoAreaAcuaticaDTO.codigoDptoRiberaZocaloCont);
        $('#txtPropietarioe').val(OtorgamientoDerechoAreaAcuaticaDTO.propietarioNave);
        $('#cbTerrestree').val(OtorgamientoDerechoAreaAcuaticaDTO.codigoInstalacionTerrestreAcuatica);
        $('#cbDistritoe').val(OtorgamientoDerechoAreaAcuaticaDTO.distritoUbigeo);
        $('#txtConsecione').val(OtorgamientoDerechoAreaAcuaticaDTO.tiempoConcesion);
        $('#txtTipoe').val(OtorgamientoDerechoAreaAcuaticaDTO.tipoTiempo);
        $('#txtFechaAtencione').val(OtorgamientoDerechoAreaAcuaticaDTO.fechaAtencionSolicitud); 
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
                url: '/DicapiOtorgamientoDerechoAreaAcuatica/Eliminar',
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
                    $('#tblDicapiOtorgamientoDerechoAreaAcuatica').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDicapiOtorgamientoDerechoAreaAcuatica() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            console.log(dataJson);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.nombreTemaEstudioInvestigacion),
                        $("<td>").text(item.tipoEstudioInvestigacion),
                        $("<td>").text(item.fechaInicio),
                        $("<td>").text(item.fechaTermino),
                        $("<td>").text(item.responsable),
                        $("<td>").text(item.solicitante)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            alert(dataJson.mensaje);
        })
}


function cargaDatos() {
    $.getJSON('/DicapiOtorgamientoDerechoAreaAcuatica/cargaCombs', [], function (Json) {
        var dptoRiberaZocaloContinental = Json["data1"];
        var instalacionTerrestreAcuatica = Json["data2"]; 
        var distritoUbigeo = Json["data3"];
        var listaCargas = Json["data4"];


        $("select#cbDptoMaterial").html("");
        $.each(dptoRiberaZocaloContinental, function () {
            var RowContent = '<option value=' + this.codigoDptoRiberaZocaloCont + '>' + this.descDptoRiberaZocaloCont + '</option>'
            $("select#cbDptoMaterial").append(RowContent);
        });
        $("select#cbDptoMateriale").html("");
        $.each(dptoRiberaZocaloContinental, function () {
            var RowContent = '<option value=' + this.codigoDptoRiberaZocaloCont + '>' + this.descDptoRiberaZocaloCont + '</option>'
            $("select#cbDptoMateriale").append(RowContent);
        });

        $("select#cbTerrestre").html("");
        $.each(instalacionTerrestreAcuatica, function () {
            var RowContent = '<option value=' + this.codigoInstalacionTerrestreAcuatica + '>' + this.descInstalacionTerrestreAcuatica + '</option>'
            $("select#cbTerrestre").append(RowContent);
        });
        $("select#cbTerrestree").html("");
        $.each(instalacionTerrestreAcuatica, function () {
            var RowContent = '<option value=' + this.codigoInstalacionTerrestreAcuatica + '>' + this.descInstalacionTerrestreAcuatica + '</option>'
            $("select#cbTerrestree").append(RowContent);
        });

        $("select#cbDistrito").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistrito").append(RowContent);
        });
        $("select#cbDistritoe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoe").append(RowContent);
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
        reporteSeleccionado = '/BienestarMovilidadEscolar/ReporteME?idCarga=';
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