var tblDirintemarPubliInteresInsti;



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
                                url: '/DirintemarPubliInteresInsti/Insertar',
                                data: {
                                    'TipoPublicacionId': $('#cbTipoPublicacion').val(),
                                    'DenominacionTemaPublicacion': $('#txtDenominacionTemaP').val(),
                                    'NroPublicacion': $('#txtNPublicacion').val(),
                                    'FechaPublicacion': $('#txtFechaPublicacion').val(),
                                    'NumeroEjemplaresPublicados': $('#txtNumeroEjemplresP').val(),
                                    'NroSuscriptores': $('#txtNSuscripctores').val(),
                                    'PromotorPublicaciones': $('#txtPromotorPublic').val(),
                                    'ResponsablePublicacion': $('#txtResponsable').val(),
                                    'InversionPublicacion': $('#txtInversion').val(),
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
                                    $('#tblDirintemarPubliInteresInsti').DataTable().ajax.reload();
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
                                url: '/DirintemarPubliInteresInsti/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoPublicacionId': $('#cbTipoPublicacione').val(),
                                    'DenominacionTemaPublicacion': $('#txtDenominacionTemaPe').val(),
                                    'NroPublicacion': $('#txtNPublicacione').val(),
                                    'FechaPublicacion': $('#txtFechaPublicacione').val(),
                                    'NumeroEjemplaresPublicados': $('#txtNumeroEjemplresPe').val(),
                                    'NroSuscriptores': $('#txtNSuscripctorese').val(),
                                    'PromotorPublicaciones': $('#txtPromotorPublice').val(),
                                    'ResponsablePublicacion': $('#txtResponsablee').val(),
                                    'InversionPublicacion': $('#txtInversione').val(),
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
                                    $('#tblDirintemarPubliInteresInsti').DataTable().ajax.reload();
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

    $('#tblDirintemarPubliInteresInsti').DataTable({
        ajax: {
            "url": '/DirintemarPubliInteresInsti/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "publicacionInteresInstitucionalId" },
            { "data": "descTipoPublicacion" },
            { "data": "denominacionTemaPublicacion" },
            { "data": "nroPublicacion" },
            { "data": "fechaPublicacion" },
            { "data": "numeroEjemplaresPublicados" },
            { "data": "nroSuscriptores" },
            { "data": "promotorPublicaciones" },
            { "data": "responsablePublicacion" },  
            { "data": "inversionPublicacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.publicacionInteresInstitucionalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.publicacionInteresInstitucionalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Publicaciones de Interés Institucional',
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
                filename: 'Dirintemar - Publicaciones de Interés Institucional',
                title: 'Dirintemar - Publicaciones de Interés Institucional',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Publicaciones de Interés Institucional',
                title: 'Dirintemar - Publicaciones de Interés Institucional',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Publicaciones de Interés Institucional',
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
    $.getJSON('/DirintemarPubliInteresInsti/Mostrar?Id=' + Id, [], function (PublicacionInteresInstitucionalDTO) {
        $('#txtCodigo').val(PublicacionInteresInstitucionalDTO.publicacionInteresInstitucionalId);
        $('#cbTipoPublicacione').val(PublicacionInteresInstitucionalDTO.tipoPublicacionId);
        $('#txtDenominacionTemaPe').val(PublicacionInteresInstitucionalDTO.denominacionTemaPublicacion);
        $('#txtNPublicacione').val(PublicacionInteresInstitucionalDTO.nroPublicacion);
        $('#txtFechaPublicacione').val(PublicacionInteresInstitucionalDTO.fechaPublicacion);
        $('#txtNumeroEjemplresPe').val(PublicacionInteresInstitucionalDTO.numeroEjemplaresPublicados);
        $('#txtNSuscripctorese').val(PublicacionInteresInstitucionalDTO.nroSuscriptores);
        $('#txtPromotorPublice').val(PublicacionInteresInstitucionalDTO.promotorPublicaciones);
        $('#txtResponsablee').val(PublicacionInteresInstitucionalDTO.responsablePublicacion);
        $('#txtInversione').val(PublicacionInteresInstitucionalDTO.inversionPublicacion);
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
                url: '/DirintemarPubliInteresInsti/Eliminar',
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
                    $('#tblDirintemarPubliInteresInsti').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarPubliInteresInsti() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarPubliInteresInsti/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.publicacionInteresInstitucionalId),
                        $("<td>").text(item.descTipoPublicacion),
                        $("<td>").text(item.denominacionTemaPublicacion),
                        $("<td>").text(item.nroPublicacion),
                        $("<td>").text(item.fechaPublicacion),
                        $("<td>").text(item.numeroEjemplaresPublicados),
                        $("<td>").text(item.nroSuscriptores),
                        $("<td>").text(item.promotorPublicaciones),
                        $("<td>").text(item.responsablePublicacion),
                        $("<td>").text(item.inversionPublicacion)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarPubliInteresInsti/EnviarDatos", {
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
    $.getJSON('/DirintemarPubliInteresInsti/cargaCombs', [], function (Json) {
        var TipoTema = Json["data"];
        $("select#cbTipoPublicacion ").html("");
        $.each(TipoTema, function () {
            var RowContent = '<option value=' + this.tipoPublicacionId + '>' + this.descTipoPublicacion + '</option>'
            $("select#cbTipoPublicacion").append(RowContent);
        });
        $("select#cbTipoPublicacione ").html("");
        $.each(TipoTema, function () {
            var RowContent = '<option value=' + this.tipoPublicacionId + '>' + this.descTipoPublicacion + '</option>'
            $("select#cbTipoPublicacione").append(RowContent);
        });
    });
}

