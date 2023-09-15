﻿var tblComciberdefAlistamientoIntegComanCiberdefensa;
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
                                url: '/ComciberdefAlistamientoIntegComanCiberdefensa/Insertar',
                                data: {
                                    'AnioAlistamiento': $('#txtAnioAlistamiento').val(),
                                    'SemestreAlistamiento': $('#txtSemestreAlistamiento').val(),
                                    'AlistamientoPersonal': $('#txtAlistamientoPersonal').val(),
                                    'AlistamientoEntretenimiento': $('#txtAlistamientoEntretenimiento').val(),
                                    'AlistamientoMaterial': $('#txtAlistamientoMaterial').val(),
                                    'AlistamientoLogistico': $('#txtAlistamientoLogistico').val(),  
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
                                    $('#tblComciberdefAlistamientoIntegComanCiberdefensa').DataTable().ajax.reload();
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
                                url: '/ComciberdefAlistamientoIntegComanCiberdefensa/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioAlistamiento': $('#txtAnioAlistamientoe').val(),
                                    'SemestreAlistamiento': $('#txtSemestreAlistamientoe').val(),
                                    'AlistamientoPersonal': $('#txtAlistamientoPersonale').val(),
                                    'AlistamientoEntretenimiento': $('#txtAlistamientoEntretenimientoe').val(),
                                    'AlistamientoMaterial': $('#txtAlistamientoMateriale').val(),
                                    'AlistamientoLogistico': $('#txtAlistamientoLogisticoe').val(), 
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
                                    $('#tblComciberdefAlistamientoIntegComanCiberdefensa').DataTable().ajax.reload();
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

    tblComciberdefAlistamientoIntegComanCiberdefensa = $('#tblComciberdefAlistamientoIntegComanCiberdefensa').DataTable({
        ajax: {
            "url": '/ComciberdefAlistamientoIntegComanCiberdefensa/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoIntegralCiberdefensaId" },
            { "data": "anioAlistamiento" },
            { "data": "semestreAlistamiento" },
            { "data": "alistamientoPersonal" },
            { "data": "alistamientoEntretenimiento" },
            { "data": "alistamientoMaterial" },
            { "data": "alistamientoLogistico" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoIntegralCiberdefensaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoIntegralCiberdefensaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comciberdef - Alistamiento Integral de la Comandancia de Ciberdefensa',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comciberdef - Alistamiento Integral de la Comandancia de Ciberdefensa',
                title: 'Comciberdef - Alistamiento Integral de la Comandancia de Ciberdefensa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comciberdef - Alistamiento Integral de la Comandancia de Ciberdefensa',
                title: 'Comciberdef - Alistamiento Integral de la Comandancia de Ciberdefensa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comciberdef - Alistamiento Integral de la Comandancia de Ciberdefensa',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
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
    var IdCarga = $("select#cargas").val();
    tblComciberdefAlistamientoIntegComanCiberdefensa.columns(7).search(IdCarga).draw();
}

function mostrarTodos() {
    tblComciberdefAlistamientoIntegComanCiberdefensa.columns(7).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComciberdefAlistamientoIntegComanCiberdefensa/Mostrar?Id=' + Id, [], function (AlistamientoIntegralComandanciaCiberdefensaDTO) {
        $('#txtCodigo').val(AlistamientoIntegralComandanciaCiberdefensaDTO.alistamientoIntegralCiberdefensaId);
        $('#txtAnioAlistamientoe').val(AlistamientoIntegralComandanciaCiberdefensaDTO.anioAlistamiento);
        $('#txtSemestreAlistamientoe').val(AlistamientoIntegralComandanciaCiberdefensaDTO.semestreAlistamiento);
        $('#txtAlistamientoPersonale').val(AlistamientoIntegralComandanciaCiberdefensaDTO.alistamientoPersonal);
        $('#txtAlistamientoEntretenimientoe').val(AlistamientoIntegralComandanciaCiberdefensaDTO.alistamientoEntretenimiento);
        $('#txtAlistamientoMateriale').val(AlistamientoIntegralComandanciaCiberdefensaDTO.alistamientoMaterial);
        $('#txtAlistamientoLogisticoe').val(AlistamientoIntegralComandanciaCiberdefensaDTO.alistamientoLogistico); 
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
                url: '/ComciberdefAlistamientoIntegComanCiberdefensa/Eliminar',
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
                    $('#tblComciberdefAlistamientoIntegComanCiberdefensa').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComciberdefAlistamientoIntegComanCiberdefensa() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComciberdefAlistamientoIntegComanCiberdefensa/MostrarDatos',
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
                            $("<td>").text(item.anioAlistamiento),
                            $("<td>").text(item.semestreAlistamiento),
                            $("<td>").text(item.alistamientoPersonal),
                            $("<td>").text(item.alistamientoEntretenimiento),
                            $("<td>").text(item.alistamientoMaterial),
                            $("<td>").text(item.alistamientoLogistico)
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
    fetch("ComciberdefAlistamientoIntegComanCiberdefensa/EnviarDatos", {
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
    $.getJSON('/ComciberdefAlistamientoIntegComanCiberdefensa/cargaCombs', [], function (Json) {
        var listaCargas = Json["data1"];


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

    reporteSeleccionado = '/ComciberdefAlistamientoIntegComanCiberdefensa/ReporteACC';
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