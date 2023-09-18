var tblBienestarHospedajeAdultoMayor;
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
                                url: '/BienestarHospedajeAdultoMayor/Insertar',
                                data: {
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitante').val(),
                                    'DNIHospedado': $('#txtDNIHospedado').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitante').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiado').val(),
                                    'CondicionHospedado': $('#txtCategoriaPago option:selected').val(),
                                    'TipoPermanencia': $('#txtTipoPermanencia option:selected').val(),
                                    'ResultadoSolicitud': $('#txtResultadoSolicitud option:selected').val(),
                                    'FechaIngreso': $('#txtFechaIngreso').val(), 
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
                                    $('#tblBienestarHospedajeAdultoMayor').DataTable().ajax.reload();
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
                                url: '/BienestarHospedajeAdultoMayor/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitantee').val(),
                                    'DNIHospedado': $('#txtDNIHospedadoe').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitantee').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiadoe').val(),
                                    'CondicionHospedado': $('#txtCategoriaPagoe option:selected').val(),
                                    'TipoPermanencia': $('#txtTipoPermanenciae option:selected').val(),
                                    'ResultadoSolicitud': $('#txtResultadoSolicitude option:selected').val(),
                                    'FechaIngreso': $('#txtFechaIngresoe').val(), 
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
                                    $('#tblBienestarHospedajeAdultoMayor').DataTable().ajax.reload();
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

    tblBienestarHospedajeAdultoMayor=  $('#tblBienestarHospedajeAdultoMayor').DataTable({
        ajax: {
            "url": '/BienestarHospedajeAdultoMayor/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "hospedajeAdultoMayorId" },
            { "data": "descPersonalSolicitante" },
            { "data": "dniHospedado" },
            { "data": "descCondicionSolicitante" },
            { "data": "descPersonalBeneficiado" },
            { "data": "condicionHospedado" },
            { "data": "tipoPermanencia" },
            { "data": "resultadoSolicitud" },
            { "data": "fechaIngreso" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.hospedajeAdultoMayorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.hospedajeAdultoMayorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Hospedaje Adulto Mayor Señor del Mar',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Bienestar - Hospedaje Adulto Mayor Señor del Mar',
                title: 'Bienestar - Hospedaje Adulto Mayor Señor del Mar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Hospedaje Adulto Mayor Señor del Mar',
                title: 'Bienestar - Hospedaje Adulto Mayor Señor del Mar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Hospedaje Adulto Mayor Señor del Mar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
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
    tblBienestarHospedajeAdultoMayor.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarHospedajeAdultoMayor.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarHospedajeAdultoMayor/Mostrar?Id=' + Id, [], function (HospedajeAdultoMayorDTO) {
        $('#txtCodigo').val(HospedajeAdultoMayorDTO.hospedajeAdultoMayorId);
        $('#cbPersonalSolicitantee').val(HospedajeAdultoMayorDTO.codigoPersonalSolicitante);
        $('#txtDNIHospedadoe').val(HospedajeAdultoMayorDTO.dniHospedado);
        $('#cbCondicionSolicitantee').val(HospedajeAdultoMayorDTO.codigoCondicionSolicitante);
        $('#cbPersonalBeneficiadoe').val(HospedajeAdultoMayorDTO.codigoPersonalBeneficiado);
        $('#txtCategoriaPagoe').val(HospedajeAdultoMayorDTO.condicionHospedado);
        $('#txtTipoPermanenciae').val(HospedajeAdultoMayorDTO.tipoPermanencia);
        $('#txtResultadoSolicitude').val(HospedajeAdultoMayorDTO.resultadoSolicitud);
        $('#txtFechaIngresoe').val(HospedajeAdultoMayorDTO.fechaIngreso); 
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
                url: '/BienestarHospedajeAdultoMayor/Eliminar',
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
                    $('#tblBienestarHospedajeAdultoMayor').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarHospedajeAdultoMayor() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarHospedajeAdultoMayor/MostrarDatos',
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
                            $("<td>").text(item.codigoPersonalSolicitante),
                            $("<td>").text(item.dniHospedado),
                            $("<td>").text(item.codigoCondicionSolicitante),
                            $("<td>").text(item.codigoPersonalBeneficiado),
                            $("<td>").text(item.condicionHospedado),
                            $("<td>").text(item.tipoPermanencia),
                            $("<td>").text(item.resultadoSolicitud),
                            $("<td>").text(item.fechaIngreso)
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
    fetch("BienestarHospedajeAdultoMayor/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((mensaje) => {
;            if (mensaje == "1") {
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
                url: '/BienestarHospedajeAdultoMayor/EliminarCarga',
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
                    $('#tblBienestarHospedajeAdultoMayor').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarHospedajeAdultoMayor/cargaCombs', [], function (Json) {
        var personalSolicitante = Json["data1"];
        var condicionSolicitante = Json["data2"];
        var personalBeneficiado = Json["data3"];
        var listaCargas = Json["data4"];
        var listaMes = Json["mes"];
        var listaAnio = Json["anio"];

        $("select#cbMes").html("");
        $.each(listaMes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });

        $("select#cbAnio").html("");
        $.each(listaAnio, function () {
            var RowContent = '<option value=' + this.codigoAnio + '>' + this.descAnio + '</option>'
            $("select#cbAnio").append(RowContent);
        });

        $("select#cbPersonalSolicitante").html("");
        $("select#cbPersonalSolicitantee").html("");
        $.each(personalSolicitante, function () {
            var RowContent = '<option value=' + this.codigoPersonalSolicitante + '>' + this.descPersonalSolicitante + '</option>'
            $("select#cbPersonalSolicitante").append(RowContent);
            $("select#cbPersonalSolicitantee").append(RowContent);
        });

        $("select#cbCondicionSolicitante").html("");
        $("select#cbCondicionSolicitantee").html("");
        $.each(condicionSolicitante, function () {
            var RowContent = '<option value=' + this.codigoCondicionSolicitante + '>' + this.descCondicionSolicitante + '</option>'
            $("select#cbCondicionSolicitante").append(RowContent);
            $("select#cbCondicionSolicitantee").append(RowContent);
        });

        $("select#cbPersonalBeneficiado").html("");
        $("select#cbPersonalBeneficiadoe").html(""); 
        $.each(personalBeneficiado, function () {
            var RowContent = '<option value=' + this.codigoPersonalBeneficiado + '>' + this.descPersonalBeneficiado + '</option>'
            $("select#cbPersonalBeneficiado").append(RowContent);
            $("select#cbPersonalBeneficiadoe").append(RowContent);
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
        reporteSeleccionado = '/BienestarHospedajeAdultoMayor/ReporteHAM?idCarga=';
        $('#fecha').hide();
    }
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