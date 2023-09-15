var tblBienestarMovilidadEscolar;
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
                                url: '/BienestarMovilidadEscolar/Insertar',
                                data: {
                                    'Fecha': $('#txtFecha').val(),
                                    'NumeroPlaca': $('#txtNumeroPlaca').val(),
                                    'CodigoMarcaVehiculo': $('#cbMarcaUnidad').val(),
                                    'AnioFabricacion': $('#txtAnioFabricacion').val(),
                                    'CapacidadTransporte': $('#txtCapacidadTransporte').val(),
                                    'CodigoInstitucionEducativa': $('#cbInstitucionEducativa').val(),
                                    'CantidadPersonasTransportadas': $('#txtCantidadPersonasTrans').val(), 
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
                                    $('#tblBienestarMovilidadEscolar').DataTable().ajax.reload();

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
                                url: '/BienestarMovilidadEscolar/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'Fecha': $('#txtFechae').val(),
                                    'NumeroPlaca': $('#txtNumeroPlacae').val(),
                                    'CodigoMarcaVehiculo': $('#cbMarcaUnidade').val(),
                                    'AnioFabricacion': $('#txtAnioFabricacione').val(),
                                    'CapacidadTransporte': $('#txtCapacidadTransportee').val(),
                                    'CodigoInstitucionEducativa': $('#cbInstitucionEducativae').val(),
                                    'CantidadPersonasTransportadas': $('#txtCantidadPersonasTranse').val(), 
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
                                    $('#tblBienestarMovilidadEscolar').DataTable().ajax.reload();
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

   tblBienestarMovilidadEscolar=  $('#tblBienestarMovilidadEscolar').DataTable({
        ajax: {
            "url": '/BienestarMovilidadEscolar/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "movilidadEscolarId" },
            { "data": "fecha" },
            { "data": "numeroPlaca" },
            { "data": "clasificacionVehiculo" },
            { "data": "anioFabricacion" },
            { "data": "capacidadTransporte" },
            { "data": "descInstitucionEducativa" },
            { "data": "cantidadPersonasTransportadas" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.movilidadEscolarId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.movilidadEscolarId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Bienestar - Movilidad Escolar',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Bienestar - Movilidad Escolar',
                title: 'Bienestar - Movilidad Escolar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Bienestar - Movilidad Escolar',
                title: 'Bienestar - Movilidad Escolar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Bienestar - Movilidad Escolar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    tblBienestarMovilidadEscolar.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {
    
    tblBienestarMovilidadEscolar.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/BienestarMovilidadEscolar/Mostrar?Id=' + Id, [], function (MovilidadEscolarDTO) {
        $('#txtCodigo').val(MovilidadEscolarDTO.movilidadEscolarId);
        $('#txtFechae').val(MovilidadEscolarDTO.fecha);
        $('#txtNumeroPlacae').val(MovilidadEscolarDTO.numeroPlaca);
        $('#cbMarcaUnidade').val(MovilidadEscolarDTO.codigoMarcaVehiculo);
        $('#txtAnioFabricacione').val(MovilidadEscolarDTO.anioFabricacion);
        $('#txtCapacidadTransportee').val(MovilidadEscolarDTO.capacidadTransporte);
        $('#cbInstitucionEducativae').val(MovilidadEscolarDTO.codigoInstitucionEducativa);
        $('#txtCantidadPersonasTranse').val(MovilidadEscolarDTO.cantidadPersonasTransportadas); 
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
                url: '/BienestarMovilidadEscolar/Eliminar',
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
                    $('#tblBienestarMovilidadEscolar').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaBienestarMovilidadEscolar() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'BienestarMovilidadEscolar/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.fecha),
                            $("<td>").text(item.numeroPlaca),
                            $("<td>").text(item.codigoMarcaVehiculo),
                            $("<td>").text(item.anioFabricacion),
                            $("<td>").text(item.capacidadTransporte),
                            $("<td>").text(item.codigoInstitucionEducativa),
                            $("<td>").text(item.cantidadPersonasTransportadas)
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
    fetch("BienestarMovilidadEscolar/EnviarDatos", {
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
                url: '/BienestarMovilidadEscolar/EliminarCarga',
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
                    $('#tblBienestarMovilidadEscolar').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/BienestarMovilidadEscolar/cargaCombs', [], function (Json) {
        var institucionEducativa = Json["data1"];
        var marcaVehiculo = Json["data2"];
        var listaCargas = Json["data3"];
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

        $("select#cbInstitucionEducativa").html("");
        $("select#cbInstitucionEducativae").html("");
        $.each(institucionEducativa, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativa + '>' + this.descInstitucionEducativa + '</option>'
            $("select#cbInstitucionEducativa").append(RowContent);
            $("select#cbInstitucionEducativae").append(RowContent);
        });

        $("select#cbMarcaUnidad").html("");
        $("select#cbMarcaUnidade").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.codigoMarcaVehiculo + '>' + this.clasificacionVehiculo + '</option>'
            $("select#cbMarcaUnidad").append(RowContent);
            $("select#cbMarcaUnidade").append(RowContent);
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
        reporteSeleccionado = '/BienestarMovilidadEscolar/ReporteME?idCarga=';
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
        a.href = reporteSeleccionado + idCarga ;
    } else {
       // a.href = reporteSeleccionado + idCarga;
    }
    a.click();
});
