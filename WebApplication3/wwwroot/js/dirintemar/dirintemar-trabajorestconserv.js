﻿var tblDirintemarTrabajoRestauracionConservacion;


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
                                url: '/DirintemarTrabajoRestConserv/Insertar',
                                data: {
                                    'TrabajoRealizadoBienHistoricoId': $('#cbTrabajoBienH').val(),
                                    'NroTrabajo': $('#txtNTrabajo').val(),
                                    'NroPiezaTratada': $('#txtNPiezaT').val(),
                                    'NroPersonaRealizanTrabajo': $('#txtPersonaRealizaT').val(),
                                    'FechaInicioTrabajoRestConserv': $('#txtFechaI').val(),
                                    'FechaTerminoTrabajoRestConserv': $('#txtFechaT').val(),
                                    'EncargadoTrabajoRestConserv': $('#txtencargado').val(),
                                    'DescripcionTrabajoRealizado': $('#txtdescripcion').val(),
                                    'InversionTrabajoRestConserv': $('#txtInversion').val(),

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
                                    $('#tblDirintemarTrabajoRestauracionConservacion').DataTable().ajax.reload();
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
                                url: '/DirintemarTrabajoRestConserv/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TrabajoRealizadoBienHistoricoId': $('#cbTrabajoBienHe').val(),
                                    'NroTrabajo': $('#txtNTrabajoe').val(),
                                    'NroPiezaTratada': $('#txtNPiezaTe').val(),
                                    'NroPersonaRealizanTrabajo': $('#txtPersonaRealizaTe').val(),
                                    'FechaInicioTrabajoRestConserv': $('#txtFechaIe').val(),
                                    'FechaTerminoTrabajoRestConserv': $('#txtFechaTe').val(),
                                    'EncargadoTrabajoRestConserv': $('#txtencargadoe').val(),
                                    'DescripcionTrabajoRealizado': $('#txtdescripcione').val(),
                                    'InversionTrabajoRestConserv': $('#txtInversione').val(),
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
                                    $('#tblDirintemarTrabajoRestauracionConservacion').DataTable().ajax.reload();
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

    $('#tblDirintemarTrabajoRestauracionConservacion').DataTable({
        ajax: {
            "url": '/DirintemarTrabajoRestConserv/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "trabajoRestauracionId" },
            { "data": "descTrabajoRealizadoBienHistorico" },
            { "data": "nroTrabajo" },
            { "data": "nroPiezaTratada" },
            { "data": "nroPersonaRealizanTrabajo" },
            { "data": "fechaInicioTrabajoRestConserv" },
            { "data": "fechaTerminoTrabajoRestConserv" },
            { "data": "encargadoTrabajoRestConserv" },
            { "data": "descripcionTrabajoRealizado" },  
            { "data": "inversionTrabajoRestConserv" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.trabajoRestauracionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.trabajoRestauracionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Trabajos de Restauración y/o Conservación',
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
                filename: 'Dirintemar - Trabajos de Restauración y/o Conservación',
                title: 'Dirintemar - Trabajos de Restauración y/o Conservación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Trabajos de Restauración y/o Conservación',
                title: 'Dirintemar - Trabajos de Restauración y/o Conservación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Trabajos de Restauración y/o Conservación',
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirintemarTrabajoRestConserv/Mostrar?Id=' + Id , [], function (TrabajoRestauracionConservacionDTO) {
        $('#txtCodigo').val(TrabajoRestauracionConservacionDTO.trabajoRestauracionId);
        $('#cbTrabajoBienHe').val(TrabajoRestauracionConservacionDTO.trabajoRealizadoBienHistoricoId);
        $('#txtNTrabajoe').val(TrabajoRestauracionConservacionDTO.nroTrabajo);
        $('#txtNPiezaTe').val(TrabajoRestauracionConservacionDTO.nroPiezaTratada);
        $('#txtPersonaRealizaTe').val(TrabajoRestauracionConservacionDTO.nroPersonaRealizanTrabajo);
        $('#txtFechaIe').val(TrabajoRestauracionConservacionDTO.fechaInicioTrabajoRestConserv);
        $('#txtFechaTe').val(TrabajoRestauracionConservacionDTO.fechaTerminoTrabajoRestConserv);
        $('#txtencargadoe').val(TrabajoRestauracionConservacionDTO.encargadoTrabajoRestConserv);
        $('#txtdescripcione').val(TrabajoRestauracionConservacionDTO.descripcionTrabajoRealizado);
        $('#txtInversione').val(TrabajoRestauracionConservacionDTO.inversionTrabajoRestConserv);
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
                url: '/DirintemarTrabajoRestConserv/Eliminar',
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
                    $('#tblDirintemarTrabajoRestauracionConservacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarTrabajoRestauracionConservacion() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarTrabajoRestConserv/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.trabajoRealizadoBienHistoricoId),
                        $("<td>").text(item.nroTrabajo),
                        $("<td>").text(item.nroPiezaTratada),
                        $("<td>").text(item.nroPersonaRealizanTrabajo),
                        $("<td>").text(item.fechaInicioTrabajoRestConserv),
                        $("<td>").text(item.fechaTerminoTrabajoRestConserv),
                        $("<td>").text(item.encargadoTrabajoRestConserv),
                        $("<td>").text(item.descripcionTrabajoRealizado),
                        $("<td>").text(item.inversionTrabajoRestConserv)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarTrabajoRestConserv/EnviarDatos", {
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
    $.getJSON('/DirintemarTrabajoRestConserv/cargaCombs', [], function (Json) {
        var TrabajoRealizadoBienH = Json["data"];
        $("select#cbTrabajoBienH").html("");
        $.each(TrabajoRealizadoBienH, function () {
            var RowContent = '<option value=' + this.trabajoRealizadoBienHistoricoId + '>' + this.descTrabajoRealizadoBienHistorico + '</option>'
            $("select#cbTrabajoBienH").append(RowContent);
        });
        $("select#cbTrabajoBienHe").html("");
        $.each(TrabajoRealizadoBienH, function () {
            var RowContent = '<option value=' + this.trabajoRealizadoBienHistoricoId + '>' + this.descTrabajoRealizadoBienHistorico + '</option>'
            $("select#cbTrabajoBienHe").append(RowContent);
        });
    });0
}

