var tblDiredumarCapacitacionPerfeccionamientoMilitar;
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
                                url: '/DiredumarCapacitacionPerfeccionamientoMilitar/Insertar',
                                data: {
                                    'CIPCapPerf': $('#txtCIPCapPerf').val(),
                                    'DNICapPerf': $('#txtDNICapPerf').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),   
                                    'NumericoPais': $('#cbPaisUbigeo').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitar').val(),
                                    'CodigoEscuela': $('#cbCodigoEscuela').val(),
                                    'MensionCurso': $('#txtMensionCurso').val(),
                                    'HorasCurso': $('#txtHorasCurso').val(), 
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
                                    $('#tblDiredumarCapacitacionPerfeccionamientoMilitar').DataTable().ajax.reload();
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
                                url: '/DiredumarCapacitacionPerfeccionamientoMilitar/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CIPCapPerf': $('#txtCIPCapPerfe').val(),
                                    'DNICapPerf': $('#txtDNICapPerfe').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),                            
                                    'NumericoPais': $('#cbPaisUbigeoe').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadMilitare').val(),
                                    'CodigoEscuela': $('#cbCodigoEscuelae').val(),
                                    'MensionCurso': $('#txtMensionCursoe').val(),
                                    'HorasCurso': $('#txtHorasCursoe').val(), 
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
                                    $('#tblDiredumarCapacitacionPerfeccionamientoMilitar').DataTable().ajax.reload();
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

    tblDiredumarCapacitacionPerfeccionamientoMilitar =  $('#tblDiredumarCapacitacionPerfeccionamientoMilitar').DataTable({
        ajax: {
            "url": '/DiredumarCapacitacionPerfeccionamientoMilitar/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "capacitacionPerfeccionamientoMilitarId" },
            { "data": "cipCapPerf" },
            { "data": "dniCapPerf" },
            { "data": "descTipoPersonalMilitar" }, 
            { "data": "descGrado" },
            { "data": "nombrePais" },
            { "data": "descEntidadMilitar" },
            { "data": "descCodigoEscuela" },
            { "data": "mensionCurso" },
            { "data": "horasCurso" }, 
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.capacitacionPerfeccionamientoMilitarId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.capacitacionPerfeccionamientoMilitarId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diredumar - Capacitación y Perfeccionamiento Institucional del Personal Militar ',
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
                filename: 'Diredumar - Capacitación y Perfeccionamiento Institucional del Personal Militar ',
                title: 'Diredumar - Capacitación y Perfeccionamiento Institucional del Personal Militar ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diredumar - Capacitación y Perfeccionamiento Institucional del Personal Militar ',
                title: 'Diredumar - Capacitación y Perfeccionamiento Institucional del Personal Militar ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diredumar - Capacitación y Perfeccionamiento Institucional del Personal Militar ',
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
    tblDiredumarCapacitacionPerfeccionamientoMilitar.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiredumarCapacitacionPerfeccionamientoMilitar.columns(10).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiredumarCapacitacionPerfeccionamientoMilitar/Mostrar?Id=' + Id, [], function (CapacitacionPerfeccionamientoMilitarDTO) {
        $('#txtCodigo').val(CapacitacionPerfeccionamientoMilitarDTO.capacitacionPerfeccionamientoMilitarId);
        $('#txtCIPCapPerfe').val(CapacitacionPerfeccionamientoMilitarDTO.cipCapPerf);
        $('#txtDNICapPerfe').val(CapacitacionPerfeccionamientoMilitarDTO.dniCapPerf);
        $('#cbTipoPersonalMilitare').val(CapacitacionPerfeccionamientoMilitarDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMilitare').val(CapacitacionPerfeccionamientoMilitarDTO.codigoGradoPersonalMilitar);
        $('#cbPaisUbigeoe').val(CapacitacionPerfeccionamientoMilitarDTO.numericoPais);
        $('#cbEntidadMilitare').val(CapacitacionPerfeccionamientoMilitarDTO.codigoEntidadMilitar);
        $('#cbCodigoEscuelae').val(CapacitacionPerfeccionamientoMilitarDTO.codigoCodigoEscuela);
        $('#txtMensionCursoe').val(CapacitacionPerfeccionamientoMilitarDTO.mensionCurso);
        $('#txtHorasCursoe').val(CapacitacionPerfeccionamientoMilitarDTO.horasCurso); 
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
                url: '/DiredumarCapacitacionPerfeccionamientoMilitar/Eliminar',
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
                    $('#tblDiredumarCapacitacionPerfeccionamientoMilitar').DataTable().ajax.reload();
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
                url: '/DiredumarCapacitacionPerfeccionamientoMilitar/EliminarCarga',
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
                    $('#tblDiredumarCapacitacionPerfeccionamientoMilitar').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiredumarCapacitacionPerfeccionamientoMilitar() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiredumarCapacitacionPerfeccionamientoMilitar/MostrarDatos',
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
                            $("<td>").text(item.cipCapPerf),
                            $("<td>").text(item.dniCapPerf),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.numericoPais),
                            $("<td>").text(item.codigoEntidadMilitar),
                            $("<td>").text(item.codigoCodigoEscuela),
                            $("<td>").text(item.mensionCurso),
                            $("<td>").text(item.horasCurso)
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
    fetch("DiredumarCapacitacionPerfeccionamientoMilitar/EnviarDatos", {
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
    $.getJSON('/DiredumarCapacitacionPerfeccionamientoMilitar/cargaCombs', [], function (Json) {
        var TipoPersonalMilitar = Json["data1"];
        var GradoPersonalMilitar = Json["data2"];
        var PaisUbigeo = Json["data3"];
        var EntidadMilitar = Json["data4"];
        var CodigoEscuela = Json["data5"];
        var listaCargas = Json["data6"];

        $("select#cbTipoPersonalMilitar").html("");
        $("select#cbTipoPersonalMilitare").html("");
        $.each(TipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitar").append(RowContent);
            $("select#cbTipoPersonalMilitare").append(RowContent);
        });

        $("select#cbGradoPersonalMilitar").html("");
        $("select#cbGradoPersonalMilitare").html("");
        $.each(GradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });

        $("select#cbPaisUbigeo").html("");
        $("select#cbPaisUbigeoe").html("");
        $.each(PaisUbigeo, function () {
            var RowContent = '<option value=' + this.numerico + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeo").append(RowContent);
            $("select#cbPaisUbigeoe").append(RowContent);
        });

        $("select#cbEntidadMilitar").html("");
        $("select#cbEntidadMilitare").html("");
        $.each(EntidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadMilitar").append(RowContent);
            $("select#cbEntidadMilitare").append(RowContent);
        });

        $("select#cbCodigoEscuela").html("");
        $("select#cbCodigoEscuelae").html("");
        $.each(CodigoEscuela, function () {
            var RowContent = '<option value=' + this.codigoCodigoEscuela + '>' + this.descCodigoEscuela + '</option>'
            $("select#cbCodigoEscuela").append(RowContent);
            $("select#cbCodigoEscuelae").append(RowContent);
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
        reporteSeleccionado = '/DiredumarCapacitacionPerfeccionamientoMilitar/ReporteDCPMSUB?idCarga=';
        $('#fecha').hide();
    }
    if (id == 2) { 
        reporteSeleccionado = '/DiredumarCapacitacionPerfeccionamientoMilitar/ReporteDCPMSUP?idCarga=';
        $('#fecha').show();
    }
}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect = 1) {
        a.href = reporteSeleccionado + idCarga;
    }
    if (optReporteSelect = 2) {
        a.href = reporteSeleccionado + idCarga;
    }
    a.click();
});