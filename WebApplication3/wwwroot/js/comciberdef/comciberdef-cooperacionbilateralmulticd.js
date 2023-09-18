var tblComciberdefCooperacionBilateralMultilateralCiberdefensa;
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
                                url: '/ComciberdefCooperacionBilateralMultilateralCiberdefensa/Insertar',
                                data: {
                                    'FechaCooperacion': $('#txtFechaCooperacion').val(),
                                    'CodigoTipoAcuerdo': $('#cbTipoAcuerdoId').val(),
                                    'AsuntoCooperacion': $('#txtAsuntoCooperacion').val(),  
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
                                    $('#tblComciberdefCooperacionBilateralMultilateralCiberdefensa').DataTable().ajax.reload();
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
                                url: '/ComciberdefCooperacionBilateralMultilateralCiberdefensa/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaCooperacion': $('#txtFechaCooperacione').val(),
                                    'CodigoTipoAcuerdo': $('#cbTipoAcuerdoIde').val(),
                                    'AsuntoCooperacion': $('#txtAsuntoCooperacione').val(), 
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
                                    $('#tblComciberdefCooperacionBilateralMultilateralCiberdefensa').DataTable().ajax.reload();
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

  tblComciberdefCooperacionBilateralMultilateralCiberdefensa=   $('#tblComciberdefCooperacionBilateralMultilateralCiberdefensa').DataTable({
        ajax: {
            "url": '/ComciberdefCooperacionBilateralMultilateralCiberdefensa/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cooperacionBilateralMultilateralId" },
            { "data": "fechaCooperacion" },
            { "data": "descTipoAcuerdo" },
            { "data": "asuntoCooperacion" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.cooperacionBilateralMultilateralId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.cooperacionBilateralMultilateralId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comciberdef - Cooperación Bilateral y Multilateral en Ciberdefensa',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comciberdef - Cooperación Bilateral y Multilateral en Ciberdefensa',
                title: 'Comciberdef - Cooperación Bilateral y Multilateral en Ciberdefensa',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comciberdef - Cooperación Bilateral y Multilateral en Ciberdefensa',
                title: 'Comciberdef - Cooperación Bilateral y Multilateral en Ciberdefensa',
                exportOptions: {
                    columns: [0, 1, 2, 3]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comciberdef - Cooperación Bilateral y Multilateral en Ciberdefensa',
                exportOptions: {
                    columns: [0, 1, 2, 3]
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
    tblComciberdefCooperacionBilateralMultilateralCiberdefensa.columns(4).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComciberdefCooperacionBilateralMultilateralCiberdefensa.columns(4).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComciberdefCooperacionBilateralMultilateralCiberdefensa/Mostrar?Id=' + Id, [], function (CooperacionBilateralMultilateralCiberdefensaDTO) {
        $('#txtCodigo').val(CooperacionBilateralMultilateralCiberdefensaDTO.cooperacionBilateralMultilateralId);
        $('#txtFechaCooperacione').val(CooperacionBilateralMultilateralCiberdefensaDTO.fechaCooperacion);
        $('#cbTipoAcuerdoIde').val(CooperacionBilateralMultilateralCiberdefensaDTO.codigoTipoAcuerdo);
        $('#txtAsuntoCooperacione').val(CooperacionBilateralMultilateralCiberdefensaDTO.asuntoCooperacion); 
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
                url: '/ComciberdefCooperacionBilateralMultilateralCiberdefensa/Eliminar',
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
                    $('#tblComciberdefCooperacionBilateralMultilateralCiberdefensa').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComciberdefCooperacionBilateralMultilateralCiberdefensa() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComciberdefCooperacionBilateralMultilateralCiberdefensa/MostrarDatos',
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
                            $("<td>").text(item.fechaCooperacion),
                            $("<td>").text(item.codigoTipoAcuerdo),
                            $("<td>").text(item.asuntoCooperacion)
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
    fetch("ComciberdefCooperacionBilateralMultilateralCiberdefensa/EnviarDatos", {
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
    $.getJSON('/ComciberdefCooperacionBilateralMultilateralCiberdefensa/cargaCombs', [], function (Json) {
        var tipoAcuerdo = Json["data1"];
        var listaCargas = Json["data2"];

        $("select#cbTipoAcuerdoId").html("");
        $.each(tipoAcuerdo, function () {
            var RowContent = '<option value=' + this.codigoTipoAcuerdo + '>' + this.descTipoAcuerdo + '</option>'
            $("select#cbTipoAcuerdoId").append(RowContent);
        });
        $("select#cbTipoAcuerdoIde").html("");
        $.each(tipoAcuerdo, function () {
            var RowContent = '<option value=' + this.codigoTipoAcuerdo + '>' + this.descTipoAcuerdo + '</option>'
            $("select#cbTipoAcuerdoIde").append(RowContent);
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
        reporteSeleccionado = '/ComciberdefCooperacionBilateralMultilateralCiberdefensa/ReporteCBMC?CargaId=';
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