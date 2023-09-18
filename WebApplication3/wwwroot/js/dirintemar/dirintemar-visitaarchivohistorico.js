var tblDirintemarVisitaArchivoHistorico;

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
                                url: '/DirintemarVisitaArchivoHistorico/Insertar',
                                data: {
                                    'FechaVisitaArchivoHistorico': $('#txtFechaV').val(),
                                    'VisitanteArchivoHistorico': $('#txtVisitante').val(),
                                    'DocIdentidadVisita': $('#txtDocumentoI').val(),
                                    'TipoVisitaGeneralId': $('#cbTipoVisitaG').val(),
                                    'EntidadVisita': $('#txtEntidad').val(),
                                    'TemaArchivoHistorico': $('#txtTema').val(),
                                    'NacionalidadVisitante': $('#txtNacionalidadV').val(),

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
                                    $('#tblDirintemarVisitaArchivoHistorico').DataTable().ajax.reload();
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
                                url: '/DirintemarVisitaArchivoHistorico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaVisitaArchivoHistorico': $('#txtFechaVe').val(),
                                    'VisitanteArchivoHistorico': $('#txtVisitantee').val(),
                                    'DocIdentidadVisita': $('#txtDocumentoIe').val(),
                                    'TipoVisitaGeneralId': $('#cbTipoVisitaGe').val(),
                                    'EntidadVisita': $('#txtEntidade').val(),
                                    'TemaArchivoHistorico': $('#txtTemae').val(),
                                    'NacionalidadVisitante': $('#txtNacionalidadVe').val()
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
                                    $('#tblDirintemarVisitaArchivoHistorico').DataTable().ajax.reload();
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

    $('#tblDirintemarVisitaArchivoHistorico').DataTable({
        ajax: {
            "url": '/DirintemarVisitaArchivoHistorico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "visitaArchivoHistoricoId" },
            { "data": "fechaVisitaArchivoHistorico" },
            { "data": "visitanteArchivoHistorico" },
            { "data": "docIdentidadVisita" },
            { "data": "descTipoVisitaGeneral" },
            { "data": "entidadVisita" },
            { "data": "temaArchivoHistorico" },
            { "data": "nacionalidadVisitante" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.visitaArchivoHistoricoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.visitaArchivoHistoricoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
                }
            }
        ],
        dom: 'Bfrtip',
        buttons: [
            //csv,
            {
                extend: 'csvHtml5',
                text: 'Exportar CSV',
                filename: 'Dirintemar - Visitas al Archivo Histórico de la Marina',
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
                filename: 'Dirintemar - Visitas al Archivo Histórico de la Marina',
                title: 'Dirintemar - Visitas al Archivo Histórico de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Visitas al Archivo Histórico de la Marina',
                title: 'Dirintemar - Visitas al Archivo Histórico de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Visitas al Archivo Histórico de la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-print'

            },
            //extra
            'pageLength'
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
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
    $.getJSON('/DirintemarVisitaArchivoHistorico/Mostrar?Id=' + Id, [], function (VisitaArchivoHistoricoDTO) {
        $('#txtCodigo').val(VisitaArchivoHistoricoDTO.visitaArchivoHistoricoId);
        $('#txtFechaVe').val(VisitaArchivoHistoricoDTO.fechaVisitaArchivoHistorico);
        $('#txtVisitantee').val(VisitaArchivoHistoricoDTO.visitanteArchivoHistorico);
        $('#txtDocumentoIe').val(VisitaArchivoHistoricoDTO.docIdentidadVisita);
        $('#cbTipoVisitaGe').val(VisitaArchivoHistoricoDTO.tipoVisitaGeneralId);
        $('#txtEntidade').val(VisitaArchivoHistoricoDTO.entidadVisita);
        $('#txtTemae').val(VisitaArchivoHistoricoDTO.temaArchivoHistorico);
        $('#txtNacionalidadVe').val(VisitaArchivoHistoricoDTO.nacionalidadVisitante);
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
                url: '/DirintemarVisitaArchivoHistorico/Eliminar',
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
                    $('#tblDirintemarVisitaArchivoHistorico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarVisitaArchivoHistorico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarVisitaArchivoHistorico/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.visitaArchivoHistoricoId),
                        $("<td>").text(item.fechaVisitaArchivoHistorico),
                        $("<td>").text(item.visitanteArchivoHistorico),
                        $("<td>").text(item.docIdentidadVisita),
                        $("<td>").text(item.descTipoVisitaGeneral),
                        $("<td>").text(item.entidadVisita),
                        $("<td>").text(item.temaArchivoHistorico),
                        $("<td>").text(item.nacionalidadVisitante)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarVisitaArchivoHistorico/EnviarDatos", {
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
    $.getJSON('/DirintemarVisitaArchivoHistorico/cargaCombs', [], function (Json) {
        var tipovisita = Json["data"];
        $("select#cbTipoVisitaG").html("");
        $.each(tipovisita, function () {
            var RowContent = '<option value=' + this.tipoVisitaGeneralId + '>' + this.descTipoVisitaGeneral + '</option>'
            $("select#cbTipoVisitaG").append(RowContent);
        });
        $("select#cbTipoVisitaGe").html("");
        $.each(tipovisita, function () {
            var RowContent = '<option value=' + this.tipoVisitaGeneralId + '>' + this.descTipoVisitaGeneral + '</option>'
            $("select#cbTipoVisitaGe").append(RowContent);
        });
    });
}

