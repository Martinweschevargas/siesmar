
var tblDirintemarEstInvHistoricasNavales;

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
                                url: '/DirintemarEstInvHistoricasNavales/Insertar',
                                data: {
                                    'NombreEstudio': $('#txtNombre').val(),
                                    'TipoEstudioInvestigacionId': $('#cbTipoEstudio').val(),
                                    'FechaInicio': $('#txtFechaI').val(),
                                    'FechaTermino': $('#txtFechaT').val(),
                                    'Responsable': $('#txtResponsable').val(),
                                    'Solicitante': $('#txtSolicitante').val(),
                                    'year': $('#txtyear').val(),
                                    'mes': $('#txtMes').val(),
                                    'dia': $('#txtDia').val()
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
                                    $('#tblDirintemarActividadCultural').DataTable().ajax.reload();
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
                                url: '/DirintemarEstInvHistoricasNavales/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NombreEstudio': $('#txtNombree').val(),
                                    'TipoEstudioInvestigacionId': $('#cbTipoEstudioe').val(),
                                    'FechaInicio': $('#txtFechaIe').val(),
                                    'FechaTermino': $('#txtFechaTe').val(),
                                    'Responsable': $('#txtResponsablee').val(),
                                    'Solicitante': $('#txtSolicitantee').val(),
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
                                    $('#tblDirintemarEstInvHistoricasNavales').DataTable().ajax.reload();
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

    tblDirintemarEstInvHistoricasNavales= $('#tblDirintemarEstInvHistoricasNavales').DataTable({
        ajax: {
            'url': '/DirintemarEstInvHistoricasNavales/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "estudioInvestigacionHistNavalId" },
            { "data": "nombreTemaEstudioInvestigacion" },
            { "data": "descTipoEstudioInvestigacion" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "responsable" },
            { "data": "solicitante" },
            { "data": "codigoCargo"},
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.estudioInvestigacionHistNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.estudioInvestigacionHistNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Estudios e Investigaciones Históricas Navales',
                title: '',
                exportOptions: {
                    columns: [ 0,1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirintemar - Estudios e Investigaciones Históricas Navales',
                title: 'Dirintemar - Estudios e Investigaciones Históricas Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Estudios e Investigaciones Históricas Navales',
                title: 'Dirintemar - Estudios e Investigaciones Históricas Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Estudios e Investigaciones Históricas Navales',
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
                "targets": "[8,9]",
                "width": "180px",
            }
        ]
    });
    cargaDatos();
    cargaBusqueda();
    mostrarTodos();
});

$('#btn_search').click(function () {
    cargaBusqueda();
});


$('#btn_all').click(function () {
    mostrarTodos();
});


function cargaBusqueda() {
    var CodigoCarga = $('#cargas').val();
    tblDirintemarEstInvHistoricasNavales.columns(7).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblDirintemarEstInvHistoricasNavales.columns(7).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirintemarEstInvHistoricasNavales/Mostrar?Id=' + Id, [], function (EstudioInvestigacionesHistoricasNavalesDTO) {
        $('#txtCodigo').val(EstudioInvestigacionesHistoricasNavalesDTO.estudioInvestigacionHistNavalId);
        $('#txtNombree').val(EstudioInvestigacionesHistoricasNavalesDTO.nombreTemaEstudioInvestigacion);
        $('#cbTipoEstudioe').val(EstudioInvestigacionesHistoricasNavalesDTO.tipoEstudioInvestigacionId);
        $('#txtFechaIe').val(EstudioInvestigacionesHistoricasNavalesDTO.fechaInicio);
        $('#txtFechaTe').val(EstudioInvestigacionesHistoricasNavalesDTO.fechaTermino);
        $('#txtResponsablee').val(EstudioInvestigacionesHistoricasNavalesDTO.responsable);
        $('#txtSolicitantee').val(EstudioInvestigacionesHistoricasNavalesDTO.solicitante);
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
                url: '/DirintemarEstInvHistoricasNavales/Eliminar',
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
                    $('#tblDirintemarEstInvHistoricasNavales').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
            callback(true);
        }
    })
}

function nuevaDirintemarEstInvHistoricasNavales() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarEstInvHistoricasNavales/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.nombreTemaEstudioInvestigacion),
                        $("<td>").text(item.tipoEstudioInvestigacionId),
                        $("<td>").text(item.fechaInicio),
                        $("<td>").text(item.fechaTermino),
                        $("<td>").text(item.responsable),
                        $("<td>").text(item.solicitante)
                    )
                )
            })            
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarEstInvHistoricasNavales/EnviarDatos", {
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
    $.getJSON('/DirintemarEstInvHistoricasNavales/cargaCombs', [], function (Json) {
        var tipoEstudioInvestigacion = Json["data"];
        var listaCargas = Json["data1"];

        $("select#cbTipoEstudio").html("");
        $("select#cbTipoEstudioe").html("");
        $.each(tipoEstudioInvestigacion, function () {
            var RowContent = '<option value=' + this.tipoEstudioInvestigacionId + '>' + this.descTipoEstudioInvestigacion + '</option>'
            $("select#cbTipoEstudio").append(RowContent);
            $("select#cbTipoEstudioe").append(RowContent);
        });

        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargas").append(RowContent);
        });
    });
}


