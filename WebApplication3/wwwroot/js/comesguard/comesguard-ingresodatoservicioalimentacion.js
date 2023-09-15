var tblComesguardIngresoDatoServicioAlimentacion;
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
                                url: '/ComesguardIngresoDatoServicioAlimentacion/Insertar',
                                data: {
                                    'NumeroRacion': $('#txtNumeroRacion').val(),
                                    'MesId': $('#cbMes').val(),
                                    'PeriodoDias': $('#txtPeriodoDias').val(),
                                    'CodigoDependencia ': $('#cbDependencia').val(),
                                    'CantidadPersupe': $('#txtCantidadPersupe').val(),
                                    'CantidadPersuba': $('#txtCantidadPersuba').val(),
                                    'CantidadPermar': $('#txtCantidadPermar').val(),
                                    'TotalPersonalVacaciones': $('#txtTotalPersonalVacaciones').val(),
                                    'TotalPersonalDiaHabil': $('#txtTotalPersonalDiaHabil').val(),
                                    'TotalPersonalDiaNoHabil': $('#txtTotalPersonalDiaNoHabil').val(),
                                    'DiaHabil': $('#txtDiaHabil').val(),
                                    'DiaNoHabil': $('#txtDiaNoHabil').val(), 
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
                                    $('#tblComesguardIngresoDatoServicioAlimentacion').DataTable().ajax.reload();
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
                                url: '/ComesguardIngresoDatoServicioAlimentacion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NumeroRacion': $('#txtNumeroRacione').val(),
                                    'MesId': $('#cbMese').val(),
                                    'PeriodoDias': $('#txtPeriodoDiase').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CantidadPersupe': $('#txtCantidadPersupee').val(),
                                    'CantidadPersuba': $('#txtCantidadPersubae').val(),
                                    'CantidadPermar': $('#txtCantidadPermare').val(),
                                    'TotalPersonalVacaciones': $('#txtTotalPersonalVacacionese').val(),
                                    'TotalPersonalDiaHabil': $('#txtTotalPersonalDiaHabile').val(),
                                    'TotalPersonalDiaNoHabil': $('#txtTotalPersonalDiaNoHabile').val(),
                                    'DiaHabil': $('#txtDiaHabile').val(),
                                    'DiaNoHabil': $('#txtDiaNoHabile').val(),  
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
                                    $('#tblComesguardIngresoDatoServicioAlimentacion').DataTable().ajax.reload();
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

        tblComesguardIngresoDatoServicioAlimentacion = $('#tblComesguardIngresoDatoServicioAlimentacion').DataTable({
        ajax: {
            "url": '/ComesguardIngresoDatoServicioAlimentacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ingresoDatoServicioAlimentacionId" },
            { "data": "numeroRacion" },
            { "data": "descMes" },
            { "data": "periodoDias" },
            { "data": "nombreDependencia" },
            { "data": "cantidadPersupe" },
            { "data": "cantidadPersuba" },
            { "data": "cantidadPermar" },
            { "data": "totalPersonalVacaciones" },
            { "data": "totalPersonalDiaHabil" },
            { "data": "totalPersonalDiaNoHabil" },
            { "data": "diaHabil" },
            { "data": "diaNoHabil" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ingresoDatoServicioAlimentacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ingresoDatoServicioAlimentacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de alimentación',
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
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de alimentación',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de alimentación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de alimentación',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de alimentación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de alimentación',
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
    tblComesguardIngresoDatoServicioAlimentacion.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComesguardIngresoDatoServicioAlimentacion.columns(13).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComesguardIngresoDatoServicioAlimentacion/Mostrar?Id=' + Id, [], function (IngresoDatoServicioAlimentacionDTO) {
        $('#txtCodigo').val(IngresoDatoServicioAlimentacionDTO.ingresoDatoServicioAlimentacionId);
        $('#txtNumeroRacione').val(IngresoDatoServicioAlimentacionDTO.numeroRacion);
        $('#cbMese').val(IngresoDatoServicioAlimentacionDTO.mesId);
        $('#txtPeriodoDiase').val(IngresoDatoServicioAlimentacionDTO.periodoDias);
        $('#cbDependenciae').val(IngresoDatoServicioAlimentacionDTO.codigoDependencia);
        $('#txtCantidadPersupee').val(IngresoDatoServicioAlimentacionDTO.cantidadPersupe);
        $('#txtCantidadPersubae').val(IngresoDatoServicioAlimentacionDTO.cantidadPersuba);
        $('#txtCantidadPermare').val(IngresoDatoServicioAlimentacionDTO.cantidadPermar);
        $('#txtTotalPersonalVacacionese').val(IngresoDatoServicioAlimentacionDTO.totalPersonalVacaciones);
        $('#txtTotalPersonalDiaHabile').val(IngresoDatoServicioAlimentacionDTO.totalPersonalDiaHabil);
        $('#txtTotalPersonalDiaNoHabile').val(IngresoDatoServicioAlimentacionDTO.totalPersonalDiaNoHabil);
        $('#txtDiaHabile').val(IngresoDatoServicioAlimentacionDTO.diaHabil);
        $('#txtDiaNoHabile').val(IngresoDatoServicioAlimentacionDTO.diaNoHabil); 
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
                url: '/ComesguardIngresoDatoServicioAlimentacion/Eliminar',
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
                    $('#tblComesguardIngresoDatoServicioAlimentacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComesguardIngresoDatoServicioAlimentacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComesguardIngresoDatoServicioAlimentacion/MostrarDatos',
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
                            $("<td>").text(item.numeroRacion),
                            $("<td>").text(item.mesId),
                            $("<td>").text(item.periodoDias),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.cantidadPersupe),
                            $("<td>").text(item.cantidadPersuba),
                            $("<td>").text(item.cantidadPermar),
                            $("<td>").text(item.totalPersonalVacaciones),
                            $("<td>").text(item.totalPersonalDiaHabil),
                            $("<td>").text(item.totalPersonalDiaNoHabil),
                            $("<td>").text(item.diaHabil),
                            $("<td>").text(item.diaNoHabil),
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
    fetch("ComesguardIngresoDatoServicioAlimentacion/EnviarDatos", {
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
    $.getJSON('/ComesguardIngresoDatoServicioAlimentacion/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var dependencia = Json["data2"];
        var listaCargas = Json["data3"];


        $("select#cbMes").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
        });


        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
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
        reporteSeleccionado = '/ComesguardIngresoDatoServicioAlimentacion/ReporteCIDSA?idCarga=';
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
