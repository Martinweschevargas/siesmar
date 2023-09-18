var tblBienestarServicioLiturgico;
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
                                url: '/BienestarServicioLiturgico/Insertar',
                                data: {
                                    'FechaServicioLiturgico': $('#txtFechaServicioLiturgico').val(),
                                    'DNISolicitante': $('#txtDNISolicitante').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitante').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitante').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiado').val(),
                                    'CodigoCategoriaPago': $('#cbCategoriaPago').val(),
                                    'CodigoServicioReligioso': $('#cbServicioReligioso').val(), 
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
                                    $('#tblBienestarServicioLiturgico').DataTable().ajax.reload();
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
                                url: '/BienestarServicioLiturgico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaServicioLiturgico': $('#txtFechaServicioLiturgicoe').val(),
                                    'DNISolicitante': $('#txtDNISolicitantee').val(),
                                    'CodigoPersonalSolicitante': $('#cbPersonalSolicitantee').val(),
                                    'CodigoCondicionSolicitante': $('#cbCondicionSolicitantee').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'CodigoPersonalBeneficiado': $('#cbPersonalBeneficiadoe').val(),
                                    'CodigoCategoriaPago': $('#cbCategoriaPagoe').val(),
                                    'CodigoServicioReligioso': $('#cbServicioReligiosoe').val(), 
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
                                    $('#tblBienestarServicioLiturgico').DataTable().ajax.reload();
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


    tblBienestarServicioLiturgico=  $('#tblBienestarServicioLiturgico').DataTable({
        ajax: {
            "url": '/BienestarServicioLiturgico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioLiturgicoId" },
            { "data": "fechaServicioLiturgico" },
            { "data": "dniSolicitante" },
            { "data": "descPersonalSolicitante" },
            { "data": "descCondicionSolicitante" },
            { "data": "descGradoPersonalMilitar" },
            { "data": "descPersonalBeneficiado" },
            { "data": "descCategoriaPago" },
            { "data": "descServicioReligioso" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioLiturgicoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioLiturgicoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Servicio Litúrgico',
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
                filename: 'Bienestar - Servicio Litúrgico',
                title: 'Bienestar - Servicio Litúrgico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Servicio Litúrgico',
                title: 'Bienestar - Servicio Litúrgico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Servicio Litúrgico',
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
    tblBienestarServicioLiturgico.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblBienestarServicioLiturgico.columns(9).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarServicioLiturgico/Mostrar?Id=' + Id, [], function (ServicioLiturgicoDTO) {
        $('#txtCodigo').val(ServicioLiturgicoDTO.servicioLiturgicoId);
        $('#txtFechaServicioLiturgicoe').val(ServicioLiturgicoDTO.fechaServicioLiturgico);
        $('#txtDNISolicitantee').val(ServicioLiturgicoDTO.dniSolicitante);
        $('#cbPersonalSolicitantee').val(ServicioLiturgicoDTO.codigoPersonalSolicitante);
        $('#cbCondicionSolicitantee').val(ServicioLiturgicoDTO.codigoCondicionSolicitante);
        $('#cbGradoPersonalMilitare').val(ServicioLiturgicoDTO.codigoGradoPersonalMilitar);
        $('#cbPersonalBeneficiadoe').val(ServicioLiturgicoDTO.codigoPersonalBeneficiado);
        $('#cbCategoriaPagoe').val(ServicioLiturgicoDTO.codigoCategoriaPago);
        $('#cbServicioReligiosoe').val(ServicioLiturgicoDTO.codigoServicioReligioso); 
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
                url: '/BienestarServicioLiturgico/Eliminar',
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
                    $('#tblBienestarServicioLiturgico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarServicioLiturgico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarServicioLiturgico/MostrarDatos',
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
                            $("<td>").text(item.fechaServicioLiturgico),
                            $("<td>").text(item.dniSolicitante),
                            $("<td>").text(item.codigoPersonalSolicitante),
                            $("<td>").text(item.codigoCondicionSolicitante),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoPersonalBeneficiado),
                            $("<td>").text(item.codigoCategoriaPago),
                            $("<td>").text(item.codigoServicioReligioso)
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
    fetch("BienestarServicioLiturgico/EnviarDatos", {
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
                url: '/BienestarServicioLiturgico/EliminarCarga',
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
                    $('#tblBienestarServicioLiturgico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarServicioLiturgico/cargaCombs', [], function (Json) {
        var personalSolicitante = Json["data1"];
        var condicionSolicitante = Json["data2"];
        var gradoPersonalMilitar = Json["data3"];
        var personalBeneficiado = Json["data4"];
        var categoriaPago = Json["data5"];
        var servicioReligioso = Json["data6"];
        var listaCargas = Json["data7"];

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

        $("select#cbGradoPersonalMilitar").html("");
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.abreviatura + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });

        $("select#cbPersonalBeneficiado").html("");
        $("select#cbPersonalBeneficiadoe").html("");
        $.each(personalBeneficiado, function () {
            var RowContent = '<option value=' + this.codigoPersonalBeneficiado + '>' + this.descPersonalBeneficiado + '</option>'
            $("select#cbPersonalBeneficiado").append(RowContent);
            $("select#cbPersonalBeneficiadoe").append(RowContent);
        });

        $("select#cbCategoriaPago").html("");
        $("select#cbCategoriaPagoe").html("");
        $.each(categoriaPago, function () {
            var RowContent = '<option value=' + this.codigoCategoriaPago + '>' + this.descCategoriaPago + '</option>'
            $("select#cbCategoriaPago").append(RowContent);
            $("select#cbCategoriaPagoe").append(RowContent);
        });

        $("select#cbServicioReligioso").html("");
        $("select#cbServicioReligiosoe").html("");
        $.each(servicioReligioso, function () {
            var RowContent = '<option value=' + this.codigoServicioReligioso + '>' + this.descServicioReligioso + '</option>'
            $("select#cbServicioReligioso").append(RowContent);
            $("select#cbServicioReligiosoe").append(RowContent);
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
        reporteSeleccionado = '/BienestarServicioLiturgico/ReporteSL?idCarga=';
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