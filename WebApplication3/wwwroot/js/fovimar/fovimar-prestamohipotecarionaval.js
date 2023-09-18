var tblFovimarPrestamoHipotecarioNaval;
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
                                url: '/FovimarPrestamoHipotecarioNaval/Insertar',
                                data: {
                                    'DNIPersonalNaval': $('#txtDNI').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGrado').val(),
                                    'CodigoSituacionPersonalNaval': $('#cbSituacion').val(),
                                    'MontoPrestadoOtorgado': $('#txtMonto').val(),
                                    'CodigoMoneda': $('#cbMoneda').val(),
                                    'NroCuota': $('#txtCuotas').val(),
                                    'CodigoModalidadPrestamo': $('#cbModalidad').val(),
                                    'CodigoFinalidadPrestamo': $('#cbFinalidad').val(),
                                    'CodigoEntidadFinanciera': $('#cbEntidad').val(),
                                    'RentabilidadFinanciera': $('#txtRentabilidad').val(),
                                    'CodigoProyectoFovimar': $('#cbProyecto').val(),
                                    'GarantiaConstituida': $('#txtGarantia').val(),
                                    'CuotaPagada': $('#txtCuotasP').val(),
                                    'EstadoDeuda': $('#txtStatus').val(),
                                    'MontoMorosidad': $('#txtMorosidad').val(), 
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
                                    $('#tblFovimarPrestamoHipotecarioNaval').DataTable().ajax.reload();
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
                                url: '/FovimarPrestamoHipotecarioNaval/Actualizar',
                                data: {

                                    'PrestamoHipotecarioNavalId': $('#txtCodigo').val(),
                                    'DNIPersonalNaval': $('#txtDNIe').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoe').val(),
                                    'CodigoSituacionPersonalNaval': $('#cbSituacione').val(),
                                    'MontoPrestadoOtorgado': $('#txtMontoe').val(),
                                    'CodigoMoneda': $('#cbMonedae').val(),
                                    'NroCuota': $('#txtCuotase').val(),
                                    'CodigoModalidadPrestamo': $('#cbModalidade').val(),
                                    'CodigoFinalidadPrestamo': $('#cbFinalidade').val(),
                                    'CodigoEntidadFinanciera': $('#cbEntidade').val(),
                                    'RentabilidadFinanciera': $('#txtRentabilidade').val(),
                                    'CodigoProyectoFovimar': $('#cbProyectoe').val(),
                                    'GarantiaConstituida': $('#txtGarantiae').val(),
                                    'CuotaPagada': $('#txtCuotasPe').val(),
                                    'EstadoDeuda': $('#txtStatuse').val(),
                                    'MontoMorosidad': $('#txtMorosidade').val(), 
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
                                    $('#tblFovimarPrestamoHipotecarioNaval').DataTable().ajax.reload();
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

  tblFovimarPrestamoHipotecarioNaval=   $('#tblFovimarPrestamoHipotecarioNaval').DataTable({
        ajax: {
            "url": '/FovimarPrestamoHipotecarioNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "prestamoHipotecarioNavalId" },
            { "data": "dniPersonalNaval" },
            { "data": "descGrado" },
            { "data": "descSituacionPersonalNaval" },
            { "data": "montoPrestadoOtorgado" },
            { "data": "descMoneda" },
            { "data": "nroCuota" },  
            { "data": "descModalidadPrestamo" },
            { "data": "descFinalidadPrestamo" },  
            { "data": "descEntidadFinanciera" }, 
            { "data": "rentabilidadFinanciera" },
            { "data": "descProyectoFovimar" },
            { "data": "garantiaConstituida" },
            { "data": "cuotaPagada" },
            { "data": "estadoDeuda" },
            { "data": "montoMorosidad" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.prestamoHipotecarioNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.prestamoHipotecarioNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Fovimar - Préstamos Hipotecarios Dados al Personal Naval',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Fovimar - Préstamos Hipotecarios Dados al Personal Naval',
                title: 'Fovimar - Préstamos Hipotecarios Dados al Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Fovimar - Préstamos Hipotecarios Dados al Personal Naval',
                title: 'Fovimar - Préstamos Hipotecarios Dados al Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Fovimar - Préstamos Hipotecarios Dados al Personal Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15]
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
    tblFovimarPrestamoHipotecarioNaval.columns(16).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblFovimarPrestamoHipotecarioNaval.columns(16).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/FovimarPrestamoHipotecarioNaval/Mostrar?Id=' + Id, [], function (PrestamoHipotecarioNavalDTO) {
        $('#txtCodigo').val(PrestamoHipotecarioNavalDTO.prestamoHipotecarioNavalId);
        $('#txtDNIe').val(PrestamoHipotecarioNavalDTO.dniPersonalNaval);
        $('#cbGradoe').val(PrestamoHipotecarioNavalDTO.codigoGradoPersonalMilitar);
        $('#cbSituacione').val(PrestamoHipotecarioNavalDTO.codigoSituacionPersonalNaval);
        $('#txtMontoe').val(PrestamoHipotecarioNavalDTO.montoPrestadoOtorgado);
        $('#cbMonedae').val(PrestamoHipotecarioNavalDTO.codigoMoneda);
        $('#txtCuotase').val(PrestamoHipotecarioNavalDTO.nroCuota);
        $('#cbModalidade').val(PrestamoHipotecarioNavalDTO.codigoModalidadPrestamo);
        $('#cbFinalidade').val(PrestamoHipotecarioNavalDTO.codigoFinalidadPrestamo);
        $('#cbEntidade').val(PrestamoHipotecarioNavalDTO.codigoEntidadFinanciera);
        $('#txtRentabilidade').val(PrestamoHipotecarioNavalDTO.rentabilidadFinanciera);
        $('#cbProyectoe').val(PrestamoHipotecarioNavalDTO.codigoProyectoFovimar);
        $('#txtGarantiae').val(PrestamoHipotecarioNavalDTO.garantiaConstituida);
        $('#txtCuotasPe').val(PrestamoHipotecarioNavalDTO.cuotaPagada);
        $('#txtStatuse').val(PrestamoHipotecarioNavalDTO.estadoDeuda);
        $('#txtMorosidade').val(PrestamoHipotecarioNavalDTO.montoMorosidad); 
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
                url: '/FovimarPrestamoHipotecarioNaval/Eliminar',
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
                    $('#tblFovimarPrestamoHipotecarioNaval').DataTable().ajax.reload();
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
                url: '/FovimarPrestamoHipotecarioNaval/EliminarCarga',
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
                    $('#tblFovimarPrestamoHipotecarioNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaFovimarPrestamoHipotecarioNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'FovimarPrestamoHipotecarioNaval/MostrarDatos',
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
                            $("<td>").text(item.dniPersonalNaval),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoSituacionPersonalNaval),
                            $("<td>").text(item.montoPrestadoOtorgado),
                            $("<td>").text(item.codigoMoneda),
                            $("<td>").text(item.nroCuota),
                            $("<td>").text(item.codigoModalidadPrestamo),
                            $("<td>").text(item.codigoFinalidadPrestamo),
                            $("<td>").text(item.codigoEntidadFinanciera),
                            $("<td>").text(item.rentabilidadFinanciera),
                            $("<td>").text(item.codigoProyectoFovimar),
                            $("<td>").text(item.garantiaConstituida),
                            $("<td>").text(item.cuotaPagada),
                            $("<td>").text(item.estadoDeuda),
                            $("<td>").text(item.montoMorosidad)
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
    fetch("FovimarPrestamoHipotecarioNaval/EnviarDatos", {
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
    $.getJSON('/FovimarPrestamoHipotecarioNaval/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var moneda = Json["data2"];
        var situacionPersonalNaval = Json["data3"];
        var modalidadPrestamo = Json["data4"];
        var finalidadPrestamo = Json["data5"];
        var entidadFinanciera = Json["data6"];
        var proyectoFovimar = Json["data7"];
        var listaCargas = Json["data8"];

        $("select#cbGrado").html("");
        $("select#cbGradoe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGrado").append(RowContent);
            $("select#cbGradoe").append(RowContent);
        });

        $("select#cbMoneda").html("");
        $("select#cbMonedae").html("");
        $.each(moneda, function () {
            var RowContent = '<option value=' + this.codigoMoneda + '>' + this.descMoneda + '</option>'
            $("select#cbMoneda").append(RowContent);
            $("select#cbMonedae").append(RowContent);
        });

        $("select#cbSituacion").html("");
        $("select#cbSituacione").html("");
        $.each(situacionPersonalNaval, function () {
            var RowContent = '<option value=' + this.codigoSituacionPersonalNaval + '>' + this.descSituacionPersonalNaval + '</option>'
            $("select#cbSituacion").append(RowContent);
            $("select#cbSituacione").append(RowContent);
        });

        $("select#cbModalidad").html("");
        $("select#cbModalidade").html("");
        $.each(modalidadPrestamo, function () {
            var RowContent = '<option value=' + this.codigoModalidadPrestamo + '>' + this.descModalidadPrestamo + '</option>'
            $("select#cbModalidad").append(RowContent);
            $("select#cbModalidade").append(RowContent);
        });

        $("select#cbFinalidad").html("");
        $("select#cbFinalidade").html("");
        $.each(finalidadPrestamo, function () {
            var RowContent = '<option value=' + this.codigoFinalidadPrestamo + '>' + this.descFinalidadPrestamo + '</option>'
            $("select#cbFinalidad").append(RowContent);
            $("select#cbFinalidade").append(RowContent);
        });

        $("select#cbEntidad").html("");
        $("select#cbEntidade").html("");
        $.each(entidadFinanciera, function () {
            var RowContent = '<option value=' + this.codigoEntidadFinanciera + '>' + this.descEntidadFinanciera + '</option>'
            $("select#cbEntidad").append(RowContent);
            $("select#cbEntidade").append(RowContent);
        });

        $("select#cbProyecto").html("");
        $("select#cbProyectoe").html("");
        $.each(proyectoFovimar, function () {
            var RowContent = '<option value=' + this.codigoProyectoFovimar + '>' + this.descProyectoFovimar + '</option>'
            $("select#cbProyecto").append(RowContent);
            $("select#cbProyectoe").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    }) 
}

function optReporte(id) {
    optReporteSelect = id;

    reporteSeleccionado = '/FovimarPrestamoHipotecarioNaval/ReportePHN';
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