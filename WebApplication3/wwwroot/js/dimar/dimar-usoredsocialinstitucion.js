var tblDimarUsoRedSocialInstitucion;
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
                                url: '/DimarUsoRedSocialInstitucion/Insertar',
                                data: {
                                    'CodigoRedSocial ': $('#cbRedSocial').val(),
                                    'FechaEmision': $('#txtFechaEmision').val(),
                                    'NumeroSeguidores': $('#txtNumeroSeguidores').val(),
                                    'IncrementoSeguidores': $('#txtIncrementoSeguidores').val(),
                                    'TemaMasComentado': $('#txtTemaMasComentado').val(),
                                    'CodigoPublicoObjetivo ': $('#cbPublicoObjetivo').val(),
                                    'NumeroPublicaciones': $('#txtNumeroPublicaciones').val(),
                                    'TotalSeguidoresCreacion': $('#txtTotalSeguidoresCreacion').val(), 
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
                                    $('#tblDimarUsoRedSocialInstitucion').DataTable().ajax.reload();
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
                                url: '/DimarUsoRedSocialInstitucion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoRedSocial ': $('#cbRedSociale').val(),
                                    'FechaEmision': $('#txtFechaEmisione').val(),
                                    'NumeroSeguidores': $('#txtNumeroSeguidorese').val(),
                                    'IncrementoSeguidores': $('#txtIncrementoSeguidorese').val(),
                                    'TemaMasComentado': $('#txtTemaMasComentadoe').val(),
                                    'CodigoPublicoObjetivo ': $('#cbPublicoObjetivoe').val(),
                                    'NumeroPublicaciones': $('#txtNumeroPublicacionese').val(),
                                    'TotalSeguidoresCreacion': $('#txtTotalSeguidoresCreacione').val(), 
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
                                    $('#tblDimarUsoRedSocialInstitucion').DataTable().ajax.reload();
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

        tblDimarUsoRedSocialInstitucion=  $('#tblDimarUsoRedSocialInstitucion').DataTable({
        ajax: {
            "url": '/DimarUsoRedSocialInstitucion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "usoRedSocialInstitucionId" },
            { "data": "descRedSocial" },
            { "data": "fechaEmision" },
            { "data": "numeroSeguidores" },
            { "data": "incrementoSeguidores" },
            { "data": "temaMasComentado" },
            { "data": "descPublicoObjetivo" },
            { "data": "numeroPublicaciones" },
            { "data": "totalSeguidoresCreacion" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.usoRedSocialInstitucionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.usoRedSocialInstitucionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dimar - Uso de Redes Sociales de la Institución',
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
                filename: 'Dimar - Uso de Redes Sociales de la Institución',
                title: 'Dimar - Uso de Redes Sociales de la Institución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dimar - Uso de Redes Sociales de la Institución',
                title: 'Dimar - Uso de Redes Sociales de la Institución',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dimar - Uso de Redes Sociales de la Institución',
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
    tblDimarUsoRedSocialInstitucion.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDimarUsoRedSocialInstitucion.columns(9).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DimarUsoRedSocialInstitucion/Mostrar?Id=' + Id, [], function (UsoRedSocialInstitucionDTO) {
        $('#txtCodigo').val(UsoRedSocialInstitucionDTO.usoRedSocialInstitucionId);
        $('#cbRedSociale').val(UsoRedSocialInstitucionDTO.codigoRedSocial);
        $('#txtFechaEmisione').val(UsoRedSocialInstitucionDTO.fechaEmision);
        $('#txtNumeroSeguidorese').val(UsoRedSocialInstitucionDTO.numeroSeguidores);
        $('#txtIncrementoSeguidorese').val(UsoRedSocialInstitucionDTO.incrementoSeguidores);
        $('#txtTemaMasComentadoe').val(UsoRedSocialInstitucionDTO.temaMasComentado);
        $('#cbPublicoObjetivoe').val(UsoRedSocialInstitucionDTO.codigoPublicoObjetivo);
        $('#txtNumeroPublicacionese').val(UsoRedSocialInstitucionDTO.numeroPublicaciones);
        $('#txtTotalSeguidoresCreacione').val(UsoRedSocialInstitucionDTO.totalSeguidoresCreacion); 
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
                url: '/DimarUsoRedSocialInstitucion/Eliminar',
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
                    $('#tblDimarUsoRedSocialInstitucion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDimarUsoRedSocialInstitucion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DimarUsoRedSocialInstitucion/MostrarDatos',
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
                            $("<td>").text(item.codigoRedSocial),
                            $("<td>").text(item.fechaEmision),
                            $("<td>").text(item.numeroSeguidores),
                            $("<td>").text(item.incrementoSeguidores),
                            $("<td>").text(item.temaMasComentado),
                            $("<td>").text(item.codigoPublicoObjetivo),
                            $("<td>").text(item.numeroPublicaciones),
                            $("<td>").text(item.totalSeguidoresCreacion),
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
    fetch("DimarUsoRedSocialInstitucion/EnviarDatos", {
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
    $.getJSON('/DimarUsoRedSocialInstitucion/cargaCombs', [], function (Json) {
        var redSocial = Json["data1"];
        var publicoObjetivo = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbRedSocial").html("");
        $.each(redSocial, function () {
            var RowContent = '<option value=' + this.codigoRedSocial + '>' + this.descRedSocial + '</option>'
            $("select#cbRedSocial").append(RowContent);
        });
        $("select#cbRedSociale").html("");
        $.each(redSocial, function () {
            var RowContent = '<option value=' + this.codigoRedSocial + '>' + this.descRedSocial + '</option>'
            $("select#cbRedSociale").append(RowContent);
        });


        $("select#cbPublicoObjetivo").html("");
        $.each(publicoObjetivo, function () {
            var RowContent = '<option value=' + this.codigoPublicoObjetivo + '>' + this.descPublicoObjetivo + '</option>'
            $("select#cbPublicoObjetivo").append(RowContent);
        });
        $("select#cbPublicoObjetivoe").html("");
        $.each(publicoObjetivo, function () {
            var RowContent = '<option value=' + this.codigoPublicoObjetivo + '>' + this.descPublicoObjetivo + '</option>'
            $("select#cbPublicoObjetivoe").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
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
        reporteSeleccionado = '/DimarUsoRedSocialInstitucion/ReporteDURSI?idCarga=';
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