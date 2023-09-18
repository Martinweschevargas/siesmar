var tblComciberdefCiberataque;
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
                                url: '/ComciberdefCiberataque/Insertar',
                                data: {
                                    'IdentificadorCiberataque': $('#txtIdentificadorCiberataque').val(),
                                    'CodigoAccionAnteCiberataque': $('#cbAccionAnteCiberataque').val(),
                                    'FechaCiberataques': $('#txtFechaCiberataques').val(),
                                    'CodigoTipoCiberataque': $('#cbTipoCiberataque').val(),
                                    'CodigoSeveridadCiberataque': $('#cbSeveridadCiberataque').val(),  
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
                                    $('#tblComciberdefCiberataque').DataTable().ajax.reload();
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
                                url: '/ComciberdefCiberataque/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'IdentificadorCiberataque': $('#txtIdentificadorCiberataquee').val(),
                                    'CodigoAccionAnteCiberataque': $('#cbAccionAnteCiberataquee').val(),
                                    'FechaCiberataques': $('#txtFechaCiberataquese').val(),
                                    'CodigoTipoCiberataque': $('#cbTipoCiberataquee').val(),
                                    'CodigoSeveridadCiberataque': $('#cbSeveridadCiberataquee').val(), 
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
                                    $('#tblComciberdefCiberataque').DataTable().ajax.reload();
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

    tblComciberdefCiberataque = $('#tblComciberdefCiberataque').DataTable({
        ajax: {
            "url": '/ComciberdefCiberataque/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ciberataqueId" },
            { "data": "identificadorCiberataque" },
            { "data": "descAccionAnteCiberataque" },
            { "data": "fechaCiberataques" },
            { "data": "descTipoCiberataque" },
            { "data": "descSeveridadCiberataque" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ciberataqueId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ciberataqueId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comciberdef - Ciberataques',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comciberdef - Ciberataques',
                title: 'Comciberdef - Ciberataques',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comciberdef - Ciberataques',
                title: 'Comciberdef - Ciberataques',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comciberdef - Ciberataques',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
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
    tblComciberdefCiberataque.columns(6).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComciberdefCiberataque.columns(6).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComciberdefCiberataque/Mostrar?Id=' + Id, [], function (CiberataqueDTO) {
        $('#txtCodigo').val(CiberataqueDTO.ciberataqueId);
        $('#txtIdentificadorCiberataquee').val(CiberataqueDTO.identificadorCiberataque);
        $('#cbAccionAnteCiberataquee').val(CiberataqueDTO.codigoAccionAnteCiberataque);
        $('#txtFechaCiberataquese').val(CiberataqueDTO.fechaCiberataques);
        $('#cbTipoCiberataquee').val(CiberataqueDTO.codigoTipoCiberataque);
        $('#cbSeveridadCiberataquee').val(CiberataqueDTO.codigoSeveridadCiberataque); 
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
                url: '/ComciberdefCiberataque/Eliminar',
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
                    $('#tblComciberdefCiberataque').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComciberdefCiberataque() {
    $('#listar').hide();
    $('#nuevo').show();
}



function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComciberdefCiberataque/MostrarDatos',
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
                            $("<td>").text(item.identificadorCiberataque),
                            $("<td>").text(item.codigoAccionAnteCiberataque),
                            $("<td>").text(item.fechaCiberataques),
                            $("<td>").text(item.codigoTipoCiberataque),
                            $("<td>").text(item.codigoSeveridadCiberataque)
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
    fetch("ComciberdefCiberataque/EnviarDatos", {
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
    $.getJSON('/ComciberdefCiberataque/cargaCombs', [], function (Json) {
        var accionAnteCiberataque = Json["data1"];
        var tipoCiberataque = Json["data2"];
        var severidadCiberataque = Json["data3"];
        var listaCargas = Json["data4"];



        $("select#cbAccionAnteCiberataque").html("");
        $.each(accionAnteCiberataque, function () {
            var RowContent = '<option value=' + this.codigoAccionAnteCiberataque + '>' + this.descAccionAnteCiberataque + '</option>'
            $("select#cbAccionAnteCiberataque").append(RowContent);
        });
        $("select#cbAccionAnteCiberataquee").html("");
        $.each(accionAnteCiberataque, function () {
            var RowContent = '<option value=' + this.codigoAccionAnteCiberataque + '>' + this.descAccionAnteCiberataque + '</option>'
            $("select#cbAccionAnteCiberataquee").append(RowContent);
        });


        $("select#cbTipoCiberataque").html("");
        $.each(tipoCiberataque, function () {
            var RowContent = '<option value=' + this.codigoTipoCiberataque + '>' + this.descTipoCiberataque + '</option>'
            $("select#cbTipoCiberataque").append(RowContent);
        });
        $("select#cbTipoCiberataquee").html("");
        $.each(tipoCiberataque, function () {
            var RowContent = '<option value=' + this.codigoTipoCiberataque + '>' + this.descTipoCiberataque + '</option>'
            $("select#cbTipoCiberataquee").append(RowContent);
        });


        $("select#cbSeveridadCiberataque").html("");
        $.each(severidadCiberataque, function () {
            var RowContent = '<option value=' + this.codigoSeveridadCiberataque + '>' + this.descSeveridadCiberataque + '</option>'
            $("select#cbSeveridadCiberataque").append(RowContent);
        });
        $("select#cbSeveridadCiberataquee").html("");
        $.each(severidadCiberataque, function () {
            var RowContent = '<option value=' + this.codigoSeveridadCiberataque + '>' + this.descSeveridadCiberataque + '</option>'
            $("select#cbSeveridadCiberataquee").append(RowContent);
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
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCA';
        $('#accionAnteCiberataque').hide();
        $('#tipoCiberataque').hide();
        $('#fechaInicio').hide();
        $('#fechaTermino').hide();
    }
    if (id == 2) {
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCXSSA';
        $('#accionAnteCiberataque').show();
        $('#tipoCiberataque').hide();
        $('#fechaInicio').show();
        $('#fechaTermino').show();
    }
    if (id == 3) {
        reporteSeleccionado = '/ComciberdefCiberataque/ReporteCCATCA';
        $('#tipoCiberataque').show();
        $('#accionAnteCiberataque').hide();
        $('#fechaInicio').show();
        $('#fechaTermino').show();
    }
}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var numCarga;
    if (idCarga == "0") {
        numCarga = "";
    } else {
        numCarga = 'CargaId=' + idCarga;
    }
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect == 1) {
        a.href = reporteSeleccionado +'?'+ numCarga;
    }
    if (optReporteSelect == 2) {
        a.href = reporteSeleccionado + '?accionAnteCiberataque=' + $('#txtAccionAnteCiberA').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
    }
    if (optReporteSelect == 3) {
        a.href = reporteSeleccionado + '?tipoCiberataque=' + $('#txtCiberAtaque').val() + '&fecha_Inicio=' + $('#txtFechaInicio').val() + '&fecha_fin=' + $('#txtFechaFin').val() + '&' + numCarga;
    } 
    a.click();
});