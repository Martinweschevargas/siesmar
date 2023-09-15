var tblIpecamarAsuntosDisciplinarios;

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
                                url: '/IpecamarAsuntosDisciplinarios/Insertar',
                                data: {
                                    'UUDDConvocante': $('#txtUUDDConvocante').val(),
                                    'CodigoMotivoInvestigacion': $('#cbMotivo').val(),
                                    'CodigoDetalleInfraccion': $('#cbDetalleI').val(),
                                    'FechaInicioInvestigacion': $('#txtFechaI').val(),
                                    'FechaTerminoInvestigacion': $('#txtFechaT').val(),
                                    'PlazoInvestigacion': $('#txtPlazoInv').val(),
                                    'CodigoZonaNaval': $('#cbZonanaval').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbCartegoriaPersonal').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonal').val(),
                                    'SituacionInvestigacion': $('#txtSituacionInv').val(),
                                    'CodigoResultadoInvestigacion': $('#cbResultadiInv').val(),
                                    'CargaId': $('#cargasR').val()

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
                                    $('#tblIpecamarAsuntosDisciplinarios').DataTable().ajax.reload();
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
                                url: '/IpecamarAsuntosDisciplinarios/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoMotivoInvestigacion': $('#cbMotivoe').val(),
                                    'CodigoDetalleInfraccion': $('#cbDetalleIe').val(),
                                    'FechaInicioInvestigacion': $('#txtFechaIe').val(),
                                    'FechaTerminoInvestigacion': $('#txtFechaTe').val(),
                                    'PlazoInvestigacion': $('#txtPlazoInve').val(),
                                    'CodigoZonaNaval': $('#cbZonanavale').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbCartegoriaPersonale').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonale').val(),
                                    'SituacionInvestigacion': $('#txtSituacionInve').val(),
                                    'CodigoResultadoInvestigacion': $('#cbResultadiInve').val(),
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
                                    $('#tblIpecamarAsuntosDisciplinarios').DataTable().ajax.reload();
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

 tblIpecamarAsuntosDisciplinarios =   $('#tblIpecamarAsuntosDisciplinarios').DataTable({
        ajax: {
            "url": '/IpecamarAsuntosDisciplinarios/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "asuntoDisciplinarioId" },
            { "data": "uudDConvocante" },
            { "data": "descMotivoInvestigacion" },
            { "data": "descDetalleInfraccion" },
            { "data": "fechaInicioInvestigacion" },
            { "data": "fechaTerminoInvestigacion" },
            { "data": "plazoInvestigacion" },
            { "data": "descZonaNaval" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "situacionInvestigacion" },
            { "data": "descResultadoInvestigacion" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.asuntoDisciplinarioId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.asuntoDisciplinarioId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Ipecamar - Asuntos Disciplinarios (Investigaciones en Etapa Preliminar)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 ,11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Ipecamar - Asuntos Disciplinarios (Investigaciones en Etapa Preliminar)',
                title: 'Ipecamar - Asuntos Disciplinarios (Investigaciones en Etapa Preliminar)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Ipecamar - Asuntos Disciplinarios (Investigaciones en Etapa Preliminar)',
                title: 'Ipecamar - Asuntos Disciplinarios (Investigaciones en Etapa Preliminar)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Ipecamar - Asuntos Disciplinarios (Investigaciones en Etapa Preliminar)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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
    tblIpecamarAsuntosDisciplinarios.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblIpecamarAsuntosDisciplinarios.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/IpecamarAsuntosDisciplinarios/Mostrar?Id=' + Id, [], function (AsuntosDisciplinariosDTO) {
        $('#txtCodigo').val(AsuntosDisciplinariosDTO.asuntoDisciplinarioId);
        $('#txtUUDDConvocantee').val(AsuntosDisciplinariosDTO.uudDConvocante);
        $('#cbMotivoe').val(AsuntosDisciplinariosDTO.motivoinvestigacionId);
        $('#cbDetalleIe').val(AsuntosDisciplinariosDTO.codigoDetalleInfraccion);
        $('#txtFechaIe').val(AsuntosDisciplinariosDTO.fechaInicioInvestigacion);
        $('#txtFechaTe').val(AsuntosDisciplinariosDTO.fechaTerminoInvestigacion);
        $('#txtPlazoInve').val(AsuntosDisciplinariosDTO.plazoInvestigacion);
        $('#cbZonanavale').val(AsuntosDisciplinariosDTO.codigoZonaNaval);
        $('#cbCartegoriaPersonale').val(AsuntosDisciplinariosDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonale').val(AsuntosDisciplinariosDTO.codigoGradoPersonalMilitar);
        $('#txtSituacionInve').val(AsuntosDisciplinariosDTO.situacionInvestigacion);
        $('#cbResultadiInve').val(AsuntosDisciplinariosDTO.codigoResultadoInvestigacion);
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
                url: '/IpecamarAsuntosDisciplinarios/Eliminar',
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
                    $('#tblIpecamarAsuntosDisciplinarios').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaIpecamarAsuntosDisciplinarios() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'IpecamarAsuntosDisciplinarios/MostrarDatos',
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
                            $("<td>").text(item.uudDConvocante),
                            $("<td>").text(item.codigoMotivoinvestigacion),
                            $("<td>").text(item.codigoDetalleInfraccion),
                            $("<td>").text(item.fechaInicioInvestigacion),
                            $("<td>").text(item.fechaTerminoInvestigacion),
                            $("<td>").text(item.plazoInvestigacion),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.situacionInvestigacion),
                            $("<td>").text(item.codigoResultadoInvestigacion)
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
    fetch("IpecamarAsuntosDisciplinarios/EnviarDatos", {
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
    $.getJSON('/IpecamarAsuntosDisciplinarios/cargaCombs', [], function (Json) {
        var motivoInvestigacion   = Json["data1"];
        var detalleInfraccion= Json["data2"];
        var zonaNaval = Json["data3"];
        var tipoPersonalMilitar= Json["data4"];
        var gradoPersonalMilitar= Json["data5"];
        var resultadoInvestigacion = Json["data6"];
        var listaCargas = Json["data7"];

        $("select#cbMotivo").html("");
        $.each(motivoInvestigacion, function () {
            var RowContent = '<option value=' + this.motivoInvestigacionId + '>' + this.descMotivoInvestigacion + '</option>'
            $("select#cbMotivo").append(RowContent);
        });
        $("select#cbMotivoe").html("");
        $.each(motivoInvestigacion, function () {
            var RowContent = '<option value=' + this.motivoInvestigacionId + '>' + this.descMotivoInvestigacion + '</option>'
            $("select#cbMotivoe").append(RowContent);
        });

        $("select#cbDetalleI").html("");
        $.each(detalleInfraccion, function () {
            var RowContent = '<option value=' + this.codigoDetalleInfraccion + '>' + this.descDetalleInfraccion + '</option>'
            $("select#cbDetalleI").append(RowContent);
        });
        $("select#cbDetalleIe").html("");
        $.each(detalleInfraccion, function () {
            var RowContent = '<option value=' + this.codigoDetalleInfraccion + '>' + this.descDetalleInfraccion + '</option>'
            $("select#cbDetalleIe").append(RowContent);
        });

        $("select#cbZonanaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanaval").append(RowContent);
        });
        $("select#cbZonanavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonanavale").append(RowContent);
        });

        $("select#cbCartegoriaPersonal").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbCartegoriaPersonal").append(RowContent);
        });
        $("select#cbCartegoriaPersonale").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbCartegoriaPersonale").append(RowContent);
        });

        $("select#cbGradoPersonal").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonal").append(RowContent);
        });
        $("select#cbGradoPersonale").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonale").append(RowContent);
        });

        $("select#cbResultadiInv").html("");
        $.each(resultadoInvestigacion, function () {
            var RowContent = '<option value=' + this.codigoResultadoInvestigacion + '>' + this.descResultadoInvestigacion + '</option>'
            $("select#cbResultadiInv").append(RowContent);
        });
        $("select#cbResultadiInve").html("");
        $.each(resultadoInvestigacion, function () {
            var RowContent = '<option value=' + this.codigoResultadoInvestigacion + '>' + this.descResultadoInvestigacion + '</option>'
            $("select#cbResultadiInve").append(RowContent);
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

