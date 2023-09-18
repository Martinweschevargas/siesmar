var tblDircitenPostulanteCiten;

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
                                url: '/DircitenPostulanteCiten/Insertar',
                                data: {
                                    'DNIPostulanteCiten': $('#txtDNI').val(),
                                    'GeneroPostulanteCiten': $('#txtGenero').val(),
                                    'FechaNacimientoPostulanteCiten': $('#txtFechaNacimiento').val(),
                                    'LugarNacimiento': $('#txtLugarDomicilio').val(),
                                    'ProcedenciaPostulanteCiten': $('#txtProcedencia').val(),
                                    'TipoColegioProveniente': $('#txtTipoColegio').val(),
                                    'ColegioProcedencia': $('#txtColegioProcedencia').val(),
                                    'LugarColegio': $('#txtLugarColegio').val(),
                                    'PadresEntidadMilitar': $('#txtPadresPertenenecen').val(),
                                    'ModalidadIngreso': $('#txtModalidadIngreso').val(),
                                    'TipoPreparacion': $('#txtTipoPreparacion').val(),
                                    'LugarPostulacion': $('#txtLugarPostulacion').val(),
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'SituacionIngreso': $('#txtLSituacionIngreso').val(),
                                    'CargaId': $('#cargasR').val()
                                    
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
                                    $('#tblDircitenPostulanteCiten').DataTable().ajax.reload();
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
                                url: '/DircitenPostulanteCiten/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPostulanteCiten': $('#txtDNIe').val(),
                                    'GeneroPostulanteCiten': $('#txtGeneroe').val(),
                                    'FechaNacimientoPostulanteCiten': $('#txtFechaNacimientoe').val(),
                                    'LugarNacimiento': $('#txtLugarDomicilioe').val(),
                                    'ProcedenciaPostulanteCiten': $('#txtProcedenciae').val(),
                                    'TipoColegioProveniente': $('#txtTipoColegioe').val(),
                                    'ColegioProcedencia': $('#txtColegioProcedenciae').val(),
                                    'LugarColegio': $('#txtLugarColegioe').val(),
                                    'PadresEntidadMilitar': $('#txtPadresPertenenecene').val(),
                                    'ModalidadIngreso': $('#txtModalidadIngresoe').val(),
                                    'TipoPreparacion': $('#txtTipoPreparacione').val(),
                                    'LugarPostulacion': $('#txtLugarPostulacione').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'SituacionIngreso': $('#txtLSituacionIngresoe').val(),
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
                                    $('#tblDircitenPostulanteCiten').DataTable().ajax.reload();
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

    $('#tblDircitenPostulanteCiten').DataTable({
        ajax: {
            "url": '/DircitenPostulanteCiten/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "postulanteCitenId" },
            { "data": "dniPostulanteCiten" },
            { "data": "generoPostulanteCiten" },
            { "data": "fechaNacimientoPostulanteCiten" },
            { "data": "lugarNacimiento" },
            { "data": "procedenciaPostulanteCiten" },
            { "data": "tipoColegioProveniente" },
            { "data": "colegioProcedencia" },
            { "data": "lugarColegio" },
            { "data": "padresEntidadMilitar" },
            { "data": "modalidadIngreso" },
            { "data": "tipoPreparacion" },
            { "data": "lugarPostulacion" },
            { "data": "descZonaNaval" },
            { "data": "situacionIngreso" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.postulanteCitenId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.postulanteCitenId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirciten - Postulantes al CITEN',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirciten - Postulantes al CITEN',
                title: 'Dirciten - Postulantes al CITEN',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirciten - Postulantes al CITEN',
                title: 'Dirciten - Postulantes al CITEN',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirciten - Postulantes al CITEN',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
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
    $.getJSON('/DircitenPostulanteCiten/Mostrar?Id=' + Id, [], function (PostulanteCitenDTO) {
        $('#txtCodigo').val(PostulanteCitenDTO.postulanteCitenId);
        $('#txtDNIe').val(PostulanteCitenDTO.dniPostulanteCiten);
        $('#txtGeneroe').val(PostulanteCitenDTO.generoPostulanteCiten);
        $('#txtFechaNacimientoe').val(PostulanteCitenDTO.fechaNacimientoPostulanteCiten);
        $('#txtLugarDomicilioe').val(PostulanteCitenDTO.lugarNacimiento);
        $('#txtProcedenciae').val(PostulanteCitenDTO.procedenciaPostulanteCiten);
        $('#txtTipoColegioe').val(PostulanteCitenDTO.tipoColegioProveniente);
        $('#txtColegioProcedenciae').val(PostulanteCitenDTO.colegioProcedencia);
        $('#txtLugarColegioe').val(PostulanteCitenDTO.lugarColegio);
        $('#txtPadresPertenenecene').val(PostulanteCitenDTO.padresEntidadMilitar);
        $('#txtModalidadIngresoe').val(PostulanteCitenDTO.modalidadIngreso);
        $('#txtTipoPreparacione').val(PostulanteCitenDTO.tipoPreparacion);
        $('#txtLugarPostulacione').val(PostulanteCitenDTO.lugarPostulacion);
        $('#cbZonaNavale').val(PostulanteCitenDTO.codigoZonaNaval);
        $('#txtLSituacionIngresoe').val(PostulanteCitenDTO.situacionIngreso);
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
                url: '/DircitenPostulanteCiten/Eliminar',
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
                    $('#tblDircitenPostulanteCiten').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDircitenPostulanteCiten() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/DircitenPostulanteCiten/cargaCombs', [], function (Json) {
        var Zonanaval = Json["data1"];
        var listaCargas = Json["data2"];
 

        $("select#cbZonaNaval").html("");
        $.each(Zonanaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(Zonanaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
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

