var tblDiabasteConsumoCombustible;
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
                                url: '/DiabasteConsumoCombustible/Insertar',
                                data: {
                                    'Anio': $('#txtAnio').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'CodigoClaseCombustible': $('#cbClaseCombustible').val(),
                                    'CodigoVehiculoServicioGrupo': $('#cbVehiculoGrupo').val(),
                                    'CodigoPuntoDistribucionCombustible': $('#cbPunto').val(),
                                    'CodigoVehiculoServicioTipo': $('#cbVehiculoTipo').val(),
                                    'CodigoTipoPresupuesto': $('#cbPresopuesto').val(),
                                    'CodigoCombustibleEspecificacion': $('#cbCombustible').val(),
                                    'CantidadConsumidaGalon': $('#txtCantidad').val(),
                                    'ValorCantidadConsumida': $('#txtValor').val(),
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
                                    $('#tblDiabasteConsumoCombustible').DataTable().ajax.reload();
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
                                url: '/DiabasteConsumoCombustible/Actualizar',
                                data: {
                                    'ConsumoCombustibleId': $('#txtCodigo').val(),
                                    'Anio': $('#txtAnioe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'CodigoClaseCombustible': $('#cbClaseCombustible').val(),
                                    'CodigoVehiculoServicioGrupo': $('#cbVehiculoGrupoe').val(),
                                    'CodigoPuntoDistribucionCombustible': $('#cbPuntoe').val(),
                                    'CodigoVehiculoServicioTipo': $('#cbVehiculoTipoe').val(),
                                    'CodigoTipoPresupuesto': $('#cbPresopuestoe').val(),
                                    'CodigoCombustibleEspecificacion': $('#cbCombustiblee').val(),
                                    'CantidadConsumidaGalon': $('#txtCantidade').val(),
                                    'ValorCantidadConsumida': $('#txtValore').val(),  
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
                                    $('#tblDiabasteConsumoCombustible').DataTable().ajax.reload();
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

    tblDiabasteConsumoCombustible = $('#tblDiabasteConsumoCombustible').DataTable({
        ajax: {
            "url": '/DiabasteConsumoCombustible/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "consumoCombustibleId" },
            { "data": "anio" },
            { "data": "descMes" },
            { "data": "descClaseCombustible" },
            { "data": "descVehiculoServicioGrupo" },
            { "data": "descPuntoDistribucionCombustible" },
            { "data": "descVehiculoServicioTipo" },
            { "data": "descTipoPresupuesto" },
            { "data": "descCombustibleEspecificacion" },   
            { "data": "cantidadConsumidaGalon" },  
            { "data": "valorCantidadConsumida" },
            { "data": "cargaId" },


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.consumoCombustibleId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.consumoCombustibleId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diabaste - Consumo de Combustible, Aceites y Grasas de las Unidades y Dependencias',
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
                filename: 'Diabaste - Consumo de Combustible, Aceites y Grasas de las Unidades y Dependencias',
                title: 'Diabaste - Consumo de Combustible, Aceites y Grasas de las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diabaste - Consumo de Combustible, Aceites y Grasas de las Unidades y Dependencias',
                title: 'Diabaste - Consumo de Combustible, Aceites y Grasas de las Unidades y Dependencias',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diabaste - Consumo de Combustible, Aceites y Grasas de las Unidades y Dependencias',
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
    tblDiabasteConsumoCombustible.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiabasteConsumoCombustible.columns(11).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiabasteConsumoCombustible/Mostrar?Id=' + Id, [], function (ConsumoCombustibleDTO) {
        $('#txtCodigo').val(ConsumoCombustibleDTO.consumoCombustibleId);
        $('#txtAnioe').val(ConsumoCombustibleDTO.anio);
        $('#cbMese').val(ConsumoCombustibleDTO.numeroMes);
        $('#cbClaseCombustiblee').val(ConsumoCombustibleDTO.codigoClaseCombustible);
        $('#cbVehiculoGrupoe').val(ConsumoCombustibleDTO.codigoVehiculoServicioGrupo);
        $('#cbPuntoe').val(ConsumoCombustibleDTO.codigoPuntoDistribucionCombustible);
        $('#cbVehiculoTipoe').val(ConsumoCombustibleDTO.codigoVehiculoServicioTipo);
        $('#cbPresopuestoe').val(ConsumoCombustibleDTO.codigoTipoPresupuesto);
        $('#cbCombustiblee').val(ConsumoCombustibleDTO.codigoCombustibleEspecificacion);
        $('#txtCantidade').val(ConsumoCombustibleDTO.cantidadConsumidaGalon);
        $('#txtValore').val(ConsumoCombustibleDTO.valorCantidadConsumida); 
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
                url: '/DiabasteConsumoCombustible/Eliminar',
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
                    $('#tblDiabasteConsumoCombustible').DataTable().ajax.reload();
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
                url: '/DiabasteConsumoCombustible/EliminarCarga',
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
                    $('#tblDiabasteConsumoCombustible').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiabasteConsumoCombustible() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiabasteConsumoCombustible/MostrarDatos',
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
                        $("<td>").text(item.anio),
                        $("<td>").text(item.numeroMes),
                        $("<td>").text(item.codigoClaseCombustible),
                        $("<td>").text(item.codigoVehiculoServicioGrupo),
                        $("<td>").text(item.codigoPuntoDistribucionCombustible),
                        $("<td>").text(item.codigoVehiculoServicioTipo),
                        $("<td>").text(item.codigoTipoPresupuesto),
                        $("<td>").text(item.codigoCombustibleEspecificacion),
                        $("<td>").text(item.cantidadConsumidaGalon),
                        $("<td>").text(item.valorCantidadConsumida),
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
    fetch("DiabasteConsumoCombustible/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((mensaje) => {
            if (mensaje == "1") {
                Swal.fire(
                    'Cargado!',
                    'Se Cargo el archivo con éxito. ' + mensaje,
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
    $.getJSON('/DiabasteConsumoCombustible/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var claseCombustible = Json["data2"];
        var vehiculoServicioGrupo = Json["data3"];
        var puntoDistribucionCombustible = Json["data4"];
        var vehiculoServicioTipo = Json["data5"];
        var tipoPresupuesto = Json["data6"];
        var combustibleEspecificacion = Json["data7"];
        var listaCargas = Json["data8"];

        $("select#cbMes").html("");
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
            $("select#cbMes").append(RowContent);
        });

        $("select#cbClaseCombustible").html("");
        $("select#cbClaseCombustiblee").html("");
        $.each(claseCombustible, function () {
            var RowContent = '<option value=' + this.codigoClaseCombustible + '>' + this.descClaseCombustible + '</option>'
            $("select#cbClaseCombustible").append(RowContent);
            $("select#cbClaseCombustiblee").append(RowContent);
        });
   
        $("select#cbVehiculoGrupo").html("");
        $("select#cbVehiculoGrupoe").html("");
        $.each(vehiculoServicioGrupo, function () {
            var RowContent = '<option value=' + this.codigoVehiculoServicioGrupo + '>' + this.descVehiculoServicioGrupo + '</option>'
            $("select#cbVehiculoGrupo").append(RowContent);
            $("select#cbVehiculoGrupoe").append(RowContent);
        });

        $("select#cbPunto").html("");
        $("select#cbPuntoe").html("");
        $.each(puntoDistribucionCombustible, function () {
            var RowContent = '<option value=' + this.codigoPuntoDistribucionCombustible + '>' + this.descPuntoDistribucionCombustible + '</option>'
            $("select#cbPunto").append(RowContent);
            $("select#cbPuntoe").append(RowContent);
        });
        
        $("select#cbVehiculoTipo").html("");
        $("select#cbVehiculoTipoe").html("");
        $.each(vehiculoServicioTipo, function () {
            var RowContent = '<option value=' + this.codigoVehiculoServicioTipo + '>' + this.descVehiculoServicioTipo + '</option>'
            $("select#cbVehiculoTipo").append(RowContent);
            $("select#cbVehiculoTipoe").append(RowContent);
        });

        $("select#cbPresopuesto").html("");
        $("select#cbPresopuestoe").html("");
        $.each(tipoPresupuesto, function () {
            var RowContent = '<option value=' + this.codigoTipoPresupuesto + '>' + this.descTipoPresupuesto + '</option>'
            $("select#cbPresopuesto").append(RowContent);
            $("select#cbPresopuestoe").append(RowContent);
        });

        $("select#cbCombustible").html("");
        $("select#cbCombustiblee").html("");
        $.each(combustibleEspecificacion, function () {
            var RowContent = '<option value=' + this.codigoCombustibleEspecificacion + '>' + this.descCombustibleEspecificacion + '</option>'
            $("select#cbCombustible").append(RowContent);
            $("select#cbCombustiblee").append(RowContent);
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

    reporteSeleccionado = '/DiabasteConsumoCombustible/ReporteARTR';
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

