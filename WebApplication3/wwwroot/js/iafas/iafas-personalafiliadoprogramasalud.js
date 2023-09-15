var tblIafasPersonalAfiliadoProgramaSalud;
var distritoUbigeo;
var provinciaUbigeo;
var reporteSeleccionado;
var optReporteSelect;

$('select#cbProvincia').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
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
                                url: '/IafasPersonalAfiliadoProgramaSalud/Insertar',
                                data: {
                                    'DocumentoAfiliado': $('#txtDocumento').val(),
                                    'SexoPersonalAfiliado': $('#txtSexo').val(),
                                    'CodigoSituacionPersonalNaval': $('#cbSPNaval').val(),
                                    'FechaAfiliacion': $('#txtFechaAfi').val(),
                                    'CodigoParentescoAfiliado': $('#cbParentesco').val(),
                                    'CodigoTipoAfiliacion': $('#cbTipoAfi').val(),
                                    'DistritoUbigeo': $('#cbDistrito').val(),
                                    'CodigoZonaNaval': $('#cbZona').val(),
                                    'MantieneAfiliado': $('#txtMantiene').val(),
                                    'FechaDesafiliacion': $('#txtFechaDesa').val(),
                                    'MotivoDesafiliacion': $('#txtMotivo').val(),
                                    'CodigoFormaContactoAfiliado': $('#cbForma').val(),
                                    'ActivacionSeguroOncologico': $('#txtOncologico').val(),
                                    'ActivacionSeguroSegundaCapa': $('#txtCapa').val(), 
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
                                    $('#tblIafasPersonalAfiliadoProgramaSalud').DataTable().ajax.reload();
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
                                url: '/IafasPersonalAfiliadoProgramaSalud/Actualizar',
                                data: {
                                    'PersonalAfiliadoProgramaSaludId': $('#txtCodigo').val(),
                                    'DocumentoAfiliado': $('#txtDocumentoe').val(),
                                    'SexoPersonalAfiliado': $('#txtSexoe').val(),
                                    'CodigoSituacionPersonalNaval': $('#cbSPNavale').val(),
                                    'FechaAfiliacion': $('#txtFechaAfie').val(),
                                    'CodigoParentescoAfiliado': $('#cbParentescoe').val(),
                                    'CodigoTipoAfiliacion': $('#cbTipoAfie').val(),
                                    'DistritoUbigeo': $('#cbDistritoe').val(),
                                    'CodigoZonaNaval': $('#cbZonae').val(),
                                    'MantieneAfiliado': $('#txtMantienee').val(),
                                    'FechaDesafiliacion': $('#txtFechaDesae').val(),
                                    'MotivoDesafiliacion': $('#txtMotivoe').val(),
                                    'CodigoFormaContactoAfiliado': $('#cbFormae').val(),
                                    'ActivacionSeguroOncologico': $('#txtOncologicoe').val(),
                                    'ActivacionSeguroSegundaCapa': $('#txtCapae').val(),
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
                                    $('#tblIafasPersonalAfiliadoProgramaSalud').DataTable().ajax.reload();
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

    tblIafasPersonalAfiliadoProgramaSalud = $('#tblIafasPersonalAfiliadoProgramaSalud').DataTable({
        ajax: {
            "url": '/IafasPersonalAfiliadoProgramaSalud/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "personalAfiliadoProgramaSaludId" },
            { "data": "documentoAfiliado" },
            { "data": "sexoPersonalAfiliado" },
            { "data": "descSituacionPersonalNaval" },
            { "data": "fechaAfiliacion" },
            { "data": "descParentescoAfiliado" },
            { "data": "descTipoAfiliacion" },
            { "data": "descDistrito" },
            { "data": "descProvincia" },
            { "data": "descZonaNaval" },  
            { "data": "fechaDesafiliacion" },   
            { "data": "motivoDesafiliacion" },
            { "data": "descFormaContactoAfiliado" },  
            { "data": "activacionSeguroOncologico" },
            { "data": "activacionSeguroSegundaCapa" },  
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.personalAfiliadoProgramaSaludId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.personalAfiliadoProgramaSaludId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Iafas - Personal afiliado a los programas de salud basico, oncológico y segunda capa',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Iafas - Personal afiliado a los programas de salud basico, oncológico y segunda capa',
                title: 'Iafas - Personal afiliado a los programas de salud basico, oncológico y segunda capa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Iafas - Personal afiliado a los programas de salud basico, oncológico y segunda capa',
                title: 'Iafas - Personal afiliado a los programas de salud basico, oncológico y segunda capa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Iafas - Personal afiliado a los programas de salud basico, oncológico y segunda capa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
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
    tblIafasPersonalAfiliadoProgramaSalud.columns(15).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblIafasPersonalAfiliadoProgramaSalud.columns(15).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/IafasPersonalAfiliadoProgramaSalud/Mostrar?Id=' + Id, [], function (IafasPersonalAfiliadoProgramaSaludDTO) {
        $('#txtCodigo').val(IafasPersonalAfiliadoProgramaSaludDTO.personalAfiliadoProgramaSaludId);
        $('#txtDocumentoe').val(IafasPersonalAfiliadoProgramaSaludDTO.documentoAfiliado);
        $('#txtSexoe').val(IafasPersonalAfiliadoProgramaSaludDTO.sexoPersonalAfiliado);
        $('#cbSPNavale').val(IafasPersonalAfiliadoProgramaSaludDTO.codigoSituacionPersonalNaval);
        $('#txtFechaAfie').val(IafasPersonalAfiliadoProgramaSaludDTO.fechaAfiliacion);
        $('#cbParentescoe').val(IafasPersonalAfiliadoProgramaSaludDTO.codigoParentescoAfiliado);
        $('#cbTipoAfie').val(IafasPersonalAfiliadoProgramaSaludDTO.codigoTipoAfiliacion);
        $('#cbDistritoe').val(IafasPersonalAfiliadoProgramaSaludDTO.distritoUbigeo);
        $('#cbProvinciae').val(IafasPersonalAfiliadoProgramaSaludDTO.provinciaUbigeoId);
        $('#cbZonae').val(IafasPersonalAfiliadoProgramaSaludDTO.codigoZonaNaval);
        $('#txtMantienee').val(IafasPersonalAfiliadoProgramaSaludDTO.mantieneAfiliado);
        $('#txtFechaDesae').val(IafasPersonalAfiliadoProgramaSaludDTO.fechaDesafiliacion);
        $('#txtMotivoe').val(IafasPersonalAfiliadoProgramaSaludDTO.motivoDesafiliacion);
        $('#cbFormae').val(IafasPersonalAfiliadoProgramaSaludDTO.codigoFormaContactoAfiliado);
        $('#txtOncologicoe').val(IafasPersonalAfiliadoProgramaSaludDTO.activacionSeguroOncologico);
        $('#txtCapae').val(IafasPersonalAfiliadoProgramaSaludDTO.activacionSeguroSegundaCapa);  
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
                url: '/IafasPersonalAfiliadoProgramaSalud/Eliminar',
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
                    $('#tblIafasPersonalAfiliadoProgramaSalud').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaIafasPersonalAfiliadoProgramaSalud() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'IafasPersonalAfiliadoProgramaSalud/MostrarDatos',
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
                            $("<td>").text(item.documentoAfiliado),
                            $("<td>").text(item.sexoPersonalAfiliado),
                            $("<td>").text(item.codigoSituacionPersonalNaval),
                            $("<td>").text(item.fechaAfiliacion),
                            $("<td>").text(item.codigoParentescoAfiliado),
                            $("<td>").text(item.codigoTipoAfiliacion),
                            $("<td>").text(item.distritoUbigeo),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.mantieneAfiliado),
                            $("<td>").text(item.fechaDesafiliacion),
                            $("<td>").text(item.motivoDesafiliacion),
                            $("<td>").text(item.codigoFormaContactoAfiliado),
                            $("<td>").text(item.activacionSeguroOncologico),
                            $("<td>").text(item.activacionSeguroSegundaCapa)
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
    fetch("IafasPersonalAfiliadoProgramaSalud/EnviarDatos", {
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
    $.getJSON('/IafasPersonalAfiliadoProgramaSalud/cargaCombs', [], function (Json) {
        var situacionPersonalNaval = Json["data1"];
        var parentescoAfiliado = Json["data2"];
        var tipoAfiliacion = Json["data3"];
         distritoUbigeo = Json["data4"];
         provinciaUbigeo = Json["data5"];
        var zonaNaval = Json["data6"];
        var formaContactoAfiliado = Json["data7"];
        var listaCargas = Json["data8"];

        $("select#cbSPNaval").html("");
        $.each(situacionPersonalNaval, function () {
            var RowContent = '<option value=' + this.codigoSituacionPersonalNaval + '>' + this.descSituacionPersonalNaval + '</option>'
            $("select#cbSPNaval").append(RowContent);
        });
        $("select#cbSPNavale").html("");
        $.each(situacionPersonalNaval, function () {
            var RowContent = '<option value=' + this.codigoSituacionPersonalNaval + '>' + this.descSituacionPersonalNaval + '</option>'
            $("select#cbSPNavale").append(RowContent);
        });

        $("select#cbParentesco").html("");
        $.each(parentescoAfiliado, function () {
            var RowContent = '<option value=' + this.codigoParentescoAfiliado + '>' + this.descParentescoAfiliado + '</option>'
            $("select#cbParentesco").append(RowContent);
        });
        $("select#cbParentescoe").html("");
        $.each(parentescoAfiliado, function () {
            var RowContent = '<option value=' + this.codigoParentescoAfiliado + '>' + this.descParentescoAfiliado + '</option>'
            $("select#cbParentescoe").append(RowContent);
        });

        $("select#cbTipoAfi").html("");
        $.each(tipoAfiliacion, function () {
            var RowContent = '<option value=' + this.codigoTipoAfiliacion + '>' + this.descTipoAfiliacion + '</option>'
            $("select#cbTipoAfi").append(RowContent);
        });
        $("select#cbTipoAfie").html("");
        $.each(tipoAfiliacion, function () {
            var RowContent = '<option value=' + this.codigoTipoAfiliacion + '>' + this.descTipoAfiliacion + '</option>'
            $("select#cbTipoAfie").append(RowContent);
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

        $("select#cbProvincia").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
            $("select#cbProvincia").append(RowContent);
        });
        $("select#cbProvinciae").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciae").append(RowContent);
        });

        $("select#cbZona").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZona").append(RowContent);
        });
        $("select#cbDiscbZonaetritoe").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonae").append(RowContent);
        });

        $("select#cbForma").html("");
        $.each(formaContactoAfiliado, function () {
            var RowContent = '<option value=' + this.codigoFormaContactoAfiliado + '>' + this.descFormaContactoAfiliado + '</option>'
            $("select#cbForma").append(RowContent);
        });
        $("select#cbFormae").html("");
        $.each(formaContactoAfiliado, function () {
            var RowContent = '<option value=' + this.codigoFormaContactoAfiliado + '>' + this.descFormaContactoAfiliado + '</option>'
            $("select#cbFormae").append(RowContent);
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


$('select#cbProvincia').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistrito").html("");
            $('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
  
          $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistrito").append(RowContent);
                }
            });
        }
    });
});

$('select#cbProvinciae').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoe").html("");
            $('select#cbDistritoe').append('<option selected disabled>Seleccionar Distrito</option>');

            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoe").append(RowContent);
                }
            });
        }
    });
});

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/IafasPersonalAfiliadoProgramaSalud/ReporteIPAPS?idCarga=';
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