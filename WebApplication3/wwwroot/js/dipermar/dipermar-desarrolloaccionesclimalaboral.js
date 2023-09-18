var tblDipermarDesarrolloAccionesClimaLaboral;
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
                                url: '/DipermarDesarrolloAccionesClimaLaboral/Insertar',
                                data: {
                                    'CodigoActClimaLaboralGeneral': $('#cbProgramaACima').val(),
                                    'CodigoActClimaLaboralEspecifica': $('#cbActividad').val(),
                                    'TematicaActividad': $('#txtTematica').val(),
                                    'LugarActividad': $('#txtLugarActividad').val(),
                                    'FechaInicioActividad': $('#txtFechaInicio').val(),
                                    'FechaTerminoActividad': $('#txtFechaTermino').val(),
                                    'NroHorasActividad': $('#txtNumeroActividad').val(),
                                    'NumeroPersonalSuperior': $('#txtNumeroPersonalS').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'NroPersonalSubalterno': $('#txtNumeroPersonalSP').val(),
                                    'NroPersonalMarineria': $('#txtNumeroPersonalM').val(),
                                    'NroPersonalCivil': $('#txtNumeroPersonalC').val(),
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
                                    $('#tblDipermarDesarrolloAccionesClimaLaboral').DataTable().ajax.reload();
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
                                url: '/DipermarDesarrolloAccionesClimaLaboral/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoActClimaLaboralGeneral': $('#cbProgramaACimae').val(),
                                    'CodigoActClimaLaboralEspecifica': $('#cbActividade').val(),
                                    'TematicaActividad': $('#txtTematicae').val(),
                                    'LugarActividad': $('#txtLugarActividade').val(),
                                    'FechaInicioActividad': $('#txtFechaInicioe').val(),
                                    'FechaTerminoActividad': $('#txtFechaTerminoe').val(),
                                    'NroHorasActividad': $('#txtNumeroActividade').val(),
                                    'NumeroPersonalSuperior': $('#txtNumeroPersonalSe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'NroPersonalSubalterno': $('#txtNumeroPersonalSPe').val(),
                                    'NroPersonalMarineria': $('#txtNumeroPersonalMe').val(),
                                    'NroPersonalCivil': $('#txtNumeroPersonalCe').val(), 
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
                                    $('#tblDipermarDesarrolloAccionesClimaLaboral').DataTable().ajax.reload();
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

    tblDipermarDesarrolloAccionesClimaLaboral = $('#tblDipermarDesarrolloAccionesClimaLaboral').DataTable({
        ajax: {
            "url": '/DipermarDesarrolloAccionesClimaLaboral/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "desarrolloAccionClimaLaboralId" },
            { "data": "descActClimaLaboralGeneral" },
            { "data": "descActClimaLaboralEspecifica" },
            { "data": "tematicaActividad" },
            { "data": "lugarActividad" },
            { "data": "fechaInicioActividad" },
            { "data": "fechaTerminoActividad" },
            { "data": "nroHorasActividad" },
            { "data": "numeroPersonalSuperior" },
            { "data": "nombreDependencia" },
            { "data": "nroPersonalSubalterno" },
            { "data": "nroPersonalMarineria" },
            { "data": "nroPersonalCivil" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.desarrolloAccionClimaLaboralId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.desarrolloAccionClimaLaboralId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
    tblDipermarDesarrolloAccionesClimaLaboral.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDipermarDesarrolloAccionesClimaLaboral.columns(13).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DipermarDesarrolloAccionesClimaLaboral/Mostrar?Id=' + Id, [], function (DesarrolloAccionesClimaLaboralDTO) {
        $('#txtCodigo').val(DesarrolloAccionesClimaLaboralDTO.desarrolloAccionClimaLaboralId);
        $('#cbProgramaACimae').val(DesarrolloAccionesClimaLaboralDTO.codigoActClimaLaboralGeneral);
        $('#cbActividade').val(DesarrolloAccionesClimaLaboralDTO.codigoActClimaLaboralEspecifica);
        $('#txtTematicae').val(DesarrolloAccionesClimaLaboralDTO.tematicaActividad);
        $('#txtLugarActividade').val(DesarrolloAccionesClimaLaboralDTO.lugarActividad);
        $('#txtFechaInicioe').val(DesarrolloAccionesClimaLaboralDTO.fechaInicioActividad);
        $('#txtFechaTerminoe').val(DesarrolloAccionesClimaLaboralDTO.fechaTerminoActividad);
        $('#txtNumeroActividade').val(DesarrolloAccionesClimaLaboralDTO.nroHorasActividad);
        $('#txtNumeroPersonalSe').val(DesarrolloAccionesClimaLaboralDTO.numeroPersonalSuperior);
        $('#cbDependenciae').val(DesarrolloAccionesClimaLaboralDTO.codigoDependencia);
        $('#txtNumeroPersonalSPe').val(DesarrolloAccionesClimaLaboralDTO.nroPersonalSubalterno);
        $('#txtNumeroPersonalMe').val(DesarrolloAccionesClimaLaboralDTO.nroPersonalMarineria);
        $('#txtNumeroPersonalCe').val(DesarrolloAccionesClimaLaboralDTO.nroPersonalCivil); 
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
                url: '/DipermarDesarrolloAccionesClimaLaboral/Eliminar',
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
                    $('#tblDipermarDesarrolloAccionesClimaLaboral').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDipermarDesarrolloAccionesClimaLaboral() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DipermarDesarrolloAccionesClimaLaboral/MostrarDatos',
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
                            $("<td>").text(item.codigoActClimaLaboralGeneral),
                            $("<td>").text(item.codigoActClimaLaboralEspecifica),
                            $("<td>").text(item.tematicaActividad),
                            $("<td>").text(item.lugarActividad),
                            $("<td>").text(item.fechaInicioActividad),
                            $("<td>").text(item.fechaTerminoActividad),
                            $("<td>").text(item.nroHorasActividad),
                            $("<td>").text(item.numeroPersonalSuperior),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.nroPersonalSubalterno),
                            $("<td>").text(item.nroPersonalMarineria),
                            $("<td>").text(item.nroPersonalCivil)
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
    fetch("DipermarDesarrolloAccionesClimaLaboral/EnviarDatos", {
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
                url: '/DipermarDesarrolloAccionesClimaLaboral/EliminarCarga',
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
                    $('#tblDipermarDesarrolloAccionesClimaLaboral').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DipermarDesarrolloAccionesClimaLaboral/cargaCombs', [], function (Json) {
        var actClimaLaboralGeneral   = Json["data1"];
        var actClimaLaboralEspecifica = Json["data2"];
        var dependencia = Json["data3"];
        var listaCargas = Json["data4"];

        $("select#cbProgramaACima").html("");
        $.each(actClimaLaboralGeneral, function () {
            var RowContent = '<option value=' + this.codigoActClimaLaboralGeneral + '>' + this.descActClimaLaboralGeneral + '</option>'
            $("select#cbProgramaACima").append(RowContent);
        });
        $("select#cbProgramaACimae").html("");
        $.each(actClimaLaboralGeneral, function () {
            var RowContent = '<option value=' + this.codigoActClimaLaboralGeneral + '>' + this.descActClimaLaboralGeneral + '</option>'
            $("select#cbProgramaACimae").append(RowContent);
        });

        $("select#cbActividad").html("");
        $.each(actClimaLaboralEspecifica, function () {
            var RowContent = '<option value=' + this.codigoActClimaLaboralEspecifica + '>' + this.descActClimaLaboralEspecifica + '</option>'
            $("select#cbActividad").append(RowContent);
        });
        $("select#cbActividade").html("");
        $.each(actClimaLaboralEspecifica, function () {
            var RowContent = '<option value=' + this.codigoActClimaLaboralEspecifica + '>' + this.descActClimaLaboralEspecifica + '</option>'
            $("select#cbActividade").append(RowContent);
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

    reporteSeleccionado = '/DipermarDesarrolloAccionesClimaLaboral/ReporteDACL';
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
