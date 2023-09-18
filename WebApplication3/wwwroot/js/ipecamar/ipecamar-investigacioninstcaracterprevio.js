var tblIpecamarInvestigacionInstCaracterPrevio;

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
                                url: '/IpecamarInvestigacionInstCaracterPrevio/Insertar',
                                data: {
                                    'CodigoTipoInvestigacion': $('#cbTipoInv').val(),
                                    'CodigoMedioInvestigacion': $('#cbMedio').val(),
                                    'CodigoMotivoInvestigacion': $('#cbMotivo').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDep').val(),
                                    'FechaInicioInvestigacion': $('#txtFechaI').val(),
                                    'FechaTermino': $('#txtFechaT').val(),
                                    'CodigoZonaNaval': $('#cbZonanaval').val(),
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
                                    $('#tblIpecamarInvestigacionInstCaracterPrevio').DataTable().ajax.reload();
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
                                url: '/IpecamarInvestigacionInstCaracterPrevio/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoTipoInvestigacion': $('#cbTipoInve').val(),
                                    'CodigoMedioInvestigacion': $('#cbMedioe').val(),
                                    'CodigoMotivoInvestigacion': $('#cbMotivoe').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDepe').val(),
                                    'FechaInicioInvestigacion': $('#txtFechaIe').val(),
                                    'FechaTermino': $('#txtFechaTe').val(),
                                    'CodigoZonaNaval': $('#cbZonanavale').val(),
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
                                    $('#tblIpecamarInvestigacionInstCaracterPrevio').DataTable().ajax.reload();
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

   tblIpecamarInvestigacionInstCaracterPrevio =  $('#tblIpecamarInvestigacionInstCaracterPrevio').DataTable({
        ajax: {
            "url": '/IpecamarInvestigacionInstCaracterPrevio/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "investigacionInstCaracterPrevioId" },
            { "data": "descTipoInvestigacion" },
            { "data": "descMedioInvestigacion" },
            { "data": "descMotivoInvestigacion" },
            { "data": "descComandanciaDependencia" },
            { "data": "fechaInicioInvestigacion" },
            { "data": "fechaTermino" },
            { "data": "descZonaNaval" },
            { "data": "situacionInvestigacion" },
            { "data": "descResultadoInvestigacion" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.investigacionInstCaracterPrevioId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.investigacionInstCaracterPrevioId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Ipecamar - Investigaciones Institucionales de Carácter Previo',
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
                filename: 'Ipecamar - Investigaciones Institucionales de Carácter Previo',
                title: 'Ipecamar - Investigaciones Institucionales de Carácter Previo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Ipecamar - Investigaciones Institucionales de Carácter Previo',
                title: 'Ipecamar - Investigaciones Institucionales de Carácter Previo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Ipecamar - Investigaciones Institucionales de Carácter Previo',
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
    tblIpecamarInvestigacionInstCaracterPrevio.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblIpecamarInvestigacionInstCaracterPrevio.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/IpecamarInvestigacionInstCaracterPrevio/Mostrar?Id=' + Id, [], function (InvestigacionInstCaracterPrevioDTO) {
        $('#txtCodigo').val(InvestigacionInstCaracterPrevioDTO.investigacionInstCaracterPrevioId);
        $('#cbTipoInve').val(InvestigacionInstCaracterPrevioDTO.codigoTipoInvestigacion);
        $('#cbMedioe').val(InvestigacionInstCaracterPrevioDTO.codigoMedioInvestigacion);
        $('#cbMotivoe').val(InvestigacionInstCaracterPrevioDTO.codigoMotivoInvestigacion);
        $('#cbComandanciaDepe').val(InvestigacionInstCaracterPrevioDTO.codigoComandanciaDependencia);
        $('#txtFechaIe').val(InvestigacionInstCaracterPrevioDTO.fechaInicioInvestigacion);
        $('#txtFechaTe').val(InvestigacionInstCaracterPrevioDTO.fechaTermino);
        $('#cbZonanavale').val(InvestigacionInstCaracterPrevioDTO.codigoZonaNaval);
        $('#txtSituacionInve').val(InvestigacionInstCaracterPrevioDTO.situacionInvestigacion);
        $('#cbResultadiInve').val(InvestigacionInstCaracterPrevioDTO.codigoResultadoInvestigacion);
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
                url: '/IpecamarInvestigacionInstCaracterPrevio/Eliminar',
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
                    $('#tblIpecamarInvestigacionInstCaracterPrevio').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaIpecamarInvestigacionInstCaracterPrevio() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'IpecamarInvestigacionInstCaracterPrevio/MostrarDatos',
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
                            $("<td>").text(item.codigoTipoInvestigacion),
                            $("<td>").text(item.codigoMedioInvestigacion),
                            $("<td>").text(item.codigoMotivoInvestigacion),
                            $("<td>").text(item.codigoComandanciaDependencia),
                            $("<td>").text(item.fechaInicioInvestigacion),
                            $("<td>").text(item.fechaTermino),
                            $("<td>").text(item.codigoZonaNaval),
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
    fetch("IpecamarInvestigacionInstCaracterPrevio/EnviarDatos", {
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
    $.getJSON('/IpecamarInvestigacionInstCaracterPrevio/cargaCombs', [], function (Json) {
        var tipoInvestigacion    = Json["data1"];
        var medioInvestigacion = Json["data2"];
        var motivoInvestigacion = Json["data3"];
        var comandanciadependencia = Json["data4"];
        var zonaNaval = Json["data5"];
        var resultadoInvestigacion = Json["data6"];
        var listaCargas = Json["data7"];

        $("select#cbTipoInv").html("");
        $.each(tipoInvestigacion, function () {
            var RowContent = '<option value=' + this.codigoTipoInvestigacion + '>' + this.descTipoInvestigacion + '</option>'
            $("select#cbTipoInv").append(RowContent);
        });
        $("select#cbTipoInve").html("");
        $.each(tipoInvestigacion, function () {
            var RowContent = '<option value=' + this.codigoTipoInvestigacion + '>' + this.descTipoInvestigacion + '</option>'
            $("select#cbTipoInve").append(RowContent);
        });

        $("select#cbMedio").html("");
        $.each(medioInvestigacion, function () {
            var RowContent = '<option value=' + this.codigoMedioInvestigacion + '>' + this.descMedioInvestigacion + '</option>'
            $("select#cbMedio").append(RowContent);
        });
        $("select#cbMedioe").html("");
        $.each(medioInvestigacion, function () {
            var RowContent = '<option value=' + this.codigoMedioInvestigacion + '>' + this.descMedioInvestigacion + '</option>'
            $("select#cbMedioe").append(RowContent);
        });

        $("select#cbMotivo").html("");
        $.each(motivoInvestigacion, function () {
            var RowContent = '<option value=' + this.codigoMotivoInvestigacion + '>' + this.descMotivoInvestigacion + '</option>'
            $("select#cbMotivo").append(RowContent);
        });
        $("select#cbMotivoe").html("");
        $.each(motivoInvestigacion, function () {
            var RowContent = '<option value=' + this.codigoMotivoInvestigacion + '>' + this.descMotivoInvestigacion + '</option>'
            $("select#cbMotivoe").append(RowContent);
        });

        $("select#cbComandanciaDep").html("");
        $.each(comandanciadependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDep").append(RowContent);
        });
        $("select#cbComandanciaDepe").html("");
        $.each(comandanciadependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDepe").append(RowContent);
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

