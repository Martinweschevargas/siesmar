var tblDiresgrumCubrimientoVacantesGrumete;
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
                                url: '/DiresgrumCubrimientoVacantesGrumete/Insertar',
                                data: {
                                    'AnioCubrimientoVacante': $('#txtAnio').val(),
                                    'NumeroContingente': $('#txtNumeroContingente').val(),
                                    'CodigoEspecialidadGrumete': $('#cbEspecialidad').val(),
                                    'SexoGrumete': $('#txtGenero').val(),
                                    'NumeroRequerido': $('#txtNumeroRequerido').val(),
                                    'NumeroEfectivo': $('#txtNumeroEfectivo').val(),
                                    'DeficitVacante': $('#txtDeficit').val(), 
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
                                    $('#tblDiresgrumCubrimientoVacantesGrumete').DataTable().ajax.reload();
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
                                url: '/DiresgrumCubrimientoVacantesGrumete/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioCubrimientoVacante': $('#txtAnioe').val(),
                                    'NumeroContingente': $('#txtNumeroContingentee').val(),
                                    'CodigoEspecialidadGrumete': $('#cbEspecialidade').val(),
                                    'SexoGrumete': $('#txtGeneroe').val(),
                                    'NumeroRequerido': $('#txtNumeroRequeridoe').val(),
                                    'NumeroEfectivo': $('#txtNumeroEfectivoe').val(),
                                    'DeficitVacante': $('#txtDeficite').val(), 
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
                                    $('#tblDiresgrumCubrimientoVacantesGrumete').DataTable().ajax.reload();
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

        tblDiresgrumCubrimientoVacantesGrumete=  $('#tblDiresgrumCubrimientoVacantesGrumete').DataTable({
        ajax: {
            "url": '/DiresgrumCubrimientoVacantesGrumete/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cubrimientoVacanteGrumeteId" },
            { "data": "anioCubrimientoVacante" },
            { "data": "numeroContingente" },
            { "data": "descEspecialidadGrumete" },
            { "data": "sexoGrumete" },
            { "data": "numeroRequerido" },
            { "data": "numeroEfectivo" },
            { "data": "deficitVacante" },         
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.cubrimientoVacanteGrumeteId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.cubrimientoVacanteGrumeteId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresgrum - Cubrimiento de Vacantes de Grumetes',
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
                filename: 'Diresgrum - Cubrimiento de Vacantes de Grumetes',
                title: 'Diresgrum - Cubrimiento de Vacantes de Grumetes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresgrum - Cubrimiento de Vacantes de Grumetes',
                title: 'Diresgrum - Cubrimiento de Vacantes de Grumetes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresgrum - Cubrimiento de Vacantes de Grumetes',
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
    tblDiresgrumCubrimientoVacantesGrumete.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiresgrumCubrimientoVacantesGrumete.columns(8).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiresgrumCubrimientoVacantesGrumete/Mostrar?Id=' + Id, [], function (CubrimientoVacantesGrumeteDTO) {
        $('#txtCodigo').val(CubrimientoVacantesGrumeteDTO.cubrimientoVacanteGrumeteId);
        $('#txtAnioe').val(CubrimientoVacantesGrumeteDTO.anioCubrimientoVacante);
        $('#txtNumeroContingentee').val(CubrimientoVacantesGrumeteDTO.numeroContingente);
        $('#cbEspecialidade').val(CubrimientoVacantesGrumeteDTO.codigoEspecialidadGrumete);
        $('#txtGeneroe').val(CubrimientoVacantesGrumeteDTO.sexoGrumete);
        $('#txtNumeroRequeridoe').val(CubrimientoVacantesGrumeteDTO.numeroRequerido);
        $('#txtNumeroEfectivoe').val(CubrimientoVacantesGrumeteDTO.numeroEfectivo);
        $('#txtDeficite').val(CubrimientoVacantesGrumeteDTO.deficitVacante); 
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
                url: '/DiresgrumCubrimientoVacantesGrumete/Eliminar',
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
                    $('#tblDiresgrumCubrimientoVacantesGrumete').DataTable().ajax.reload();
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
                url: '/DiresgrumCubrimientoVacantesGrumete/EliminarCarga',
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
                    $('#tblDiresgrumCubrimientoVacantesGrumete').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiresgrumCubrimientoVacantesGrumete() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiresgrumCubrimientoVacantesGrumete/MostrarDatos',
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
                            $("<td>").text(item.anioCubrimientoVacante),
                            $("<td>").text(item.numeroContingente),
                            $("<td>").text(item.codigoEspecialidadGrumete),
                            $("<td>").text(item.sexoGrumete),
                            $("<td>").text(item.numeroRequerido),
                            $("<td>").text(item.numeroEfectivo),
                            $("<td>").text(item.deficitVacante),
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
    fetch("DiresgrumCubrimientoVacantesGrumete/EnviarDatos", {
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
    $.getJSON('/DiresgrumCubrimientoVacantesGrumete/cargaCombs', [], function (Json) {
        var especiadidadgrumete = Json["data1"];
        var listaCargas = Json["data2"];

        $("select#cbEspecialidad").html("");
        $("select#cbEspecialidade").html("");
        $.each(especiadidadgrumete, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGrumete + '>' + this.descEspecialidadGrumete + '</option>'
            $("select#cbEspecialidad").append(RowContent);
            $("select#cbEspecialidade").append(RowContent);
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

    reporteSeleccionado = '/DiresgrumCubrimientoVacantesGrumete/ReporteARTR';
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