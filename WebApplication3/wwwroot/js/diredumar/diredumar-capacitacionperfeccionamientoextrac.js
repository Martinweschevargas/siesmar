var tblDiredumarCapacitacionPerfeccionamientoExtraC;
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
                                url: '/DiredumarCapacitacionPerfeccionamientoExtraC/Insertar',
                                data: {
                                    'CIPCapaPerfPCivil': $('#txtCIPCapaPerfPCivil').val(),
                                    'TipoDocumento': $('#txtTipoDocumento').val(),
                                    'DNICapaPerfPCivil': $('#txtDNICapaPerfPCivil').val(),
                                    'CodigoGrupoOcupacionalCivil': $('#cbGrupoOcupacionalCivil').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudio').val(),
                                    'CodigoInstitucionEducativaSuperior': $('#cbInstitucionEducativaSuperior').val(),
                                    'MencionCapacitacion': $('#txtMencionCapacitacion').val(),
                                    'FinanciamientoCapacitacion': $('#txtFinanciamiento').val(),
                                    'CodigoCondicionLaboralCivil': $('#cbCondicionLaboralCivil').val(),
                                    'NumericoPais': $('#cbPaisUbigeo').val(), 
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
                                    $('#tblDiredumarCapacitacionPerfeccionamientoExtraC').DataTable().ajax.reload();
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
                                url: '/DiredumarCapacitacionPerfeccionamientoExtraC/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CIPCapaPerfPCivil': $('#txtCIPCapaPerfPCivile').val(),
                                    'TipoDocumento': $('#txtTipoDocumentoe').val(),
                                    'DNICapaPerfPCivil': $('#txtDNICapaPerfPCivile').val(),
                                    'CodigoGrupoOcupacionalCivil': $('#cbGrupoOcupacionalCivile').val(),
                                    'CodigoNivelEstudio': $('#cbNivelEstudioe').val(),
                                    'CodigoInstitucionEducativaSuperior': $('#cbInstitucionEducativaSuperiore').val(),
                                    'MencionCapacitacion': $('#txtMencionCapacitacione').val(),
                                    'FinanciamientoCapacitacion': $('#txtFinanciamientoe').val(),
                                    'CodigoCondicionLaboralCivil': $('#cbCondicionLaboralCivile').val(),
                                    'NumericoPais': $('#cbPaisUbigeoe').val(), 
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
                                    $('#tblDiredumarCapacitacionPerfeccionamientoExtraC').DataTable().ajax.reload();
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

        tblDiredumarCapacitacionPerfeccionamientoExtraC=  $('#tblDiredumarCapacitacionPerfeccionamientoExtraC').DataTable({
        ajax: {
            "url": '/DiredumarCapacitacionPerfeccionamientoExtraC/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "capacitacionPerfeccionamientoExtraCId" },
            { "data": "cipCapaPerfPCivil" },
            { "data": "tipoDocumento" },
            { "data": "dniCapaPerfPCivil" },
            { "data": "descGrupoOcupacionalCivil" },
            { "data": "descNivelEstudio" },
            { "data": "descInstitucionEducativaSuperior" },
            { "data": "mencionCapacitacion" },
            { "data": "financiamientoCapacitacion" },
            { "data": "descCondicionLaboralCivil" },
            { "data": "nombrePais" }, 
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.capacitacionPerfeccionamientoExtraCId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.capacitacionPerfeccionamientoExtraCId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diredumar - Capacitación y Perfeccionamiento del Personal Civil ',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diredumar - Capacitación y Perfeccionamiento del Personal Civil ',
                title: 'Diredumar - Capacitación y Perfeccionamiento del Personal Civil ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diredumar - Capacitación y Perfeccionamiento del Personal Civil ',
                title: 'Diredumar - Capacitación y Perfeccionamiento del Personal Civil ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diredumar - Capacitación y Perfeccionamiento del Personal Civil ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
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
    tblDiredumarCapacitacionPerfeccionamientoExtraC.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiredumarCapacitacionPerfeccionamientoExtraC.columns(11).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiredumarCapacitacionPerfeccionamientoExtraC/Mostrar?Id=' + Id, [], function (CapacitacionPerfeccionamientoExtraCDTO) {
        $('#txtCodigo').val(CapacitacionPerfeccionamientoExtraCDTO.capacitacionPerfeccionamientoExtraCId);
        $('#txtCIPCapaPerfPCivile').val(CapacitacionPerfeccionamientoExtraCDTO.cipCapaPerfPCivil);
        $('#txtTipoDocumentoe').val(CapacitacionPerfeccionamientoExtraCDTO.tipoDocumento);
        $('#txtDNICapaPerfPCivile').val(CapacitacionPerfeccionamientoExtraCDTO.dniCapaPerfPCivil);
        $('#cbGrupoOcupacionalCivile').val(CapacitacionPerfeccionamientoExtraCDTO.codigoGrupoOcupacionalCivil);
        $('#cbNivelEstudioe').val(CapacitacionPerfeccionamientoExtraCDTO.codigoNivelEstudio);
        $('#cbInstitucionEducativaSuperiore').val(CapacitacionPerfeccionamientoExtraCDTO.codigoInstitucionEducativaSuperior);
        $('#txtMencionCapacitacione').val(CapacitacionPerfeccionamientoExtraCDTO.mencionCapacitacion);
        $('#txtFinanciamientoCapacitacione').val(CapacitacionPerfeccionamientoExtraCDTO.financiamientoCapacitacion);
        $('#cbCondicionLaboralCivile').val(CapacitacionPerfeccionamientoExtraCDTO.codigoCondicionLaboralCivil);
        $('#cbPaisUbigeoe').val(CapacitacionPerfeccionamientoExtraCDTO.numericoPais); 
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
                url: '/DiredumarCapacitacionPerfeccionamientoExtraC/Eliminar',
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
                    $('#tblDiredumarCapacitacionPerfeccionamientoExtraC').DataTable().ajax.reload();
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
                url: '/DiredumarCapacitacionPerfeccionamientoExtraC/EliminarCarga',
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
                    $('#tblDiredumarCapacitacionPerfeccionamientoExtraC').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiredumarCapacitacionPerfeccionamientoExtraC() {
    $('#listar').hide();
    $('#nuevo').show();
}



function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiredumarCapacitacionPerfeccionamientoExtraC/MostrarDatos',
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
                            $("<td>").text(item.cipCapaPerfPCivil),
                            $("<td>").text(item.tipoDocumento),
                            $("<td>").text(item.dniCapaPerfPCivil),
                            $("<td>").text(item.codigoGrupoOcupacionalCivil),
                            $("<td>").text(item.codigoNivelEstudio),
                            $("<td>").text(item.codigoInstitucionEducativaSuperior),
                            $("<td>").text(item.mencionCapacitacion),
                            $("<td>").text(item.financiamientoCapacitacion),
                            $("<td>").text(item.codigoCondicionLaboralCivil),
                            $("<td>").text(item.numericoPais)
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
    fetch("DiredumarCapacitacionPerfeccionamientoExtraC/EnviarDatos", {
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
    $.getJSON('/DiredumarCapacitacionPerfeccionamientoExtraC/cargaCombs', [], function (Json) {
        var GrupoOcupacionalCivil = Json["data1"];
        var NivelEstudio = Json["data2"];
        var InstitucionEducativaSuperior = Json["data3"];
        var CondicionLaboralCivil = Json["data4"];
        var PaisUbigeo = Json["data5"];
        var listaCargas = Json["data6"];


        $("select#cbGrupoOcupacionalCivil").html("");
        $("select#cbGrupoOcupacionalCivile").html("");
        $.each(GrupoOcupacionalCivil, function () {
            var RowContent = '<option value=' + this.codigoGrupoOcupacionalCivil + '>' + this.descGrupoOcupacionalCivil + '</option>'
            $("select#cbGrupoOcupacionalCivil").append(RowContent);
            $("select#cbGrupoOcupacionalCivile").append(RowContent);
        });


        $("select#cbNivelEstudio").html("");
        $("select#cbNivelEstudioe").html("");
        $.each(NivelEstudio, function () {
            var RowContent = '<option value=' + this.codigoNivelEstudio + '>' + this.descNivelEstudio + '</option>'
            $("select#cbNivelEstudio").append(RowContent);
            $("select#cbNivelEstudioe").append(RowContent);
        });

        $("select#cbInstitucionEducativaSuperior").html("");
        $("select#cbInstitucionEducativaSuperiore").html("");
        $.each(InstitucionEducativaSuperior, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativaSuperior + '>' + this.descInstitucionEducativaSuperior + '</option>'
            $("select#cbInstitucionEducativaSuperior").append(RowContent);
            $("select#cbInstitucionEducativaSuperiore").append(RowContent);
        });

        $("select#cbCondicionLaboralCivil").html("");
        $("select#cbCondicionLaboralCivile").html("");
        $.each(CondicionLaboralCivil, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralCivil + '>' + this.descCondicionLaboralCivil + '</option>'
            $("select#cbCondicionLaboralCivil").append(RowContent);
            $("select#cbCondicionLaboralCivile").append(RowContent);
        });

        $("select#cbPaisUbigeo").html("");
        $("select#cbPaisUbigeoe").html("");
        $.each(PaisUbigeo, function () {
            var RowContent = '<option value=' + this.numerico + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeo").append(RowContent);
            $("select#cbPaisUbigeoe").append(RowContent);
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
        reporteSeleccionado = '/DiredumarCapacitacionPerfeccionamientoExtraC/ReporteDCPEC?idCarga=';
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