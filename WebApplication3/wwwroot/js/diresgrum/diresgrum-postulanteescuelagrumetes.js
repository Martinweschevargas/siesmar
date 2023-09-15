var tblDiresgrumPostulanteEscuelaGrumetes;

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
                                url: '/DiresgrumPostulanteEscuelaGrumetes/Insertar',
                                data: {
                                    'DNIPostulanteEscuela': $('#txtDNI').val(),
                                    'SexoPostulanteEscuela': $('#txtGenero').val(),
                                    'LugarNacimiento': $('#cbLugarNacimiento').val(),
                                    'FechaNacimiento': $('#txtFechaNacimiento').val(),
                                    'LugarDomicilio': $('#cbLugarDomicilio').val(),
                                    'LugarPresentacionPostulante': $('#cbLugarPresento').val(),
                                    'ZonaNavalId': $('#cbZonaNaval').val(),
                                    'GradoEstudioAlcanzadoId': $('#cbNivelEstudios').val(),
                                    'GradoEstudioEspecifId': $('#cbGradoEstudio').val(),
                                    'NumeroContingenciaPostulante': $('#txtNumeroContingente').val(),
                                    'ResultadoPostulacion': $('#cbResultadoPostular').val(), 
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
                                    $('#tblDiresgrumPostulanteEscuelaGrumetes').DataTable().ajax.reload();
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
                                url: '/DiresgrumPostulanteEscuelaGrumetes/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPostulanteEscuela': $('#txtDNIe').val(),
                                    'SexoPostulanteEscuela': $('#txtGeneroe').val(),
                                    'LugarNacimiento': $('#cbLugarNacimientoe').val(),
                                    'FechaNacimiento': $('#txtFechaNacimientoe').val(),
                                    'LugarDomicilio': $('#cbLugarDomicilioe').val(),
                                    'LugarPresentacionPostulante': $('#cbLugarPresentoe').val(),
                                    'ZonaNavalId': $('#cbZonaNavale').val(),
                                    'GradoEstudioAlcanzadoId': $('#cbNivelEstudiose').val(),
                                    'GradoEstudioEspecifId': $('#cbGradoEstudioe').val(),
                                    'NumeroContingenciaPostulante': $('#txtNumeroContingentee').val(),
                                    'ResultadoPostulacion': $('#cbResultadoPostulare').val(), 
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
                                    $('#tblDiresgrumPostulanteEscuelaGrumetes').DataTable().ajax.reload();
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

    $('#tblDiresgrumPostulanteEscuelaGrumetes').DataTable({
        ajax: {
            "url": '/DiresgrumPostulanteEscuelaGrumetes/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "postulanteEscuelaGrumeteId" },
            { "data": "dniPostulanteEscuela" },
            { "data": "sexoPostulanteEscuela" },
            { "data": "lugarNacimiento" },
            { "data": "fechaNacimiento" },
            { "data": "lugarDomicilio" },
            { "data": "lugarPresentacionPostulante" },
            { "data": "descZonaNaval" },
            { "data": "descEstudioAlcanzado" },
            { "data": "descGradoEstudioEspecif" },
            { "data": "numeroContingenciaPostulante" },
            { "data": "resultadoPostulacion" },


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.postulanteEscuelaGrumeteId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.postulanteEscuelaGrumeteId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresgrum - Postulantes a la Escuela de Grumetes',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diresgrum - Postulantes a la Escuela de Grumetes',
                title: 'Diresgrum - Postulantes a la Escuela de Grumetes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresgrum - Postulantes a la Escuela de Grumetes',
                title: 'Diresgrum - Postulantes a la Escuela de Grumetes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresgrum - Postulantes a la Escuela de Grumetes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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
    $.getJSON('/DiresgrumPostulanteEscuelaGrumetes/Mostrar?Id=' + Id, [], function (PostulanteEscuelaGrumetesDTO) {
        $('#txtCodigo').val(PostulanteEscuelaGrumetesDTO.postulanteEscuelaGrumeteId);
        $('#txtDNIe').val(PostulanteEscuelaGrumetesDTO.dniPostulanteEscuela);
        $('#txtGeneroe').val(PostulanteEscuelaGrumetesDTO.sexoPostulanteEscuela);
        $('#cbLugarNacimientoe').val(PostulanteEscuelaGrumetesDTO.lugarNacimiento);
        $('#txtFechaNacimientoe').val(PostulanteEscuelaGrumetesDTO.fechaNacimiento);
        $('#cbLugarDomicilioe').val(PostulanteEscuelaGrumetesDTO.lugarDomicilio);
        $('#cbLugarPresentoe').val(PostulanteEscuelaGrumetesDTO.lugarPresentacionPostulante);
        $('#cbZonaNavale').val(PostulanteEscuelaGrumetesDTO.zonaNavalId);
        $('#cbNivelEstudiose').val(PostulanteEscuelaGrumetesDTO.gradoEstudioAlcanzadoId);
        $('#cbGradoEstudioe').val(PostulanteEscuelaGrumetesDTO.gradoEstudioEspecifId);
        $('#txtNumeroContingentee').val(PostulanteEscuelaGrumetesDTO.numeroContingenciaPostulante);
        $('#cbResultadoPostulare').val(PostulanteEscuelaGrumetesDTO.resultadopostulacion); 
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
                url: '/DiresgrumPostulanteEscuelaGrumetes/Eliminar',
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
                    $('#tblDiresgrumPostulanteEscuelaGrumetes').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDiresgrumPostulanteEscuelaGrumetes() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/DiresgrumPostulanteEscuelaGrumetes/cargaCombs', [], function (Json) {
        var Mes = Json["data1"];
        var SubUnidadEjecutora = Json["data2"];
        var FuenteFinanciamiento = Json["data3"];



        $("select#cbMes").html("");
        $.each(Mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });
        $("select#cbMese").html("");
        $.each(Mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
        });

        $("select#cbSUE").html("");
        $.each(SubUnidadEjecutora, function () {
            var RowContent = '<option value=' + this.subUnidadEjecutoraId + '>' + this.descSubUnidadEjecutora + '</option>'
            $("select#cbSUE").append(RowContent);
        });
        $("select#cbSUEe").html("");
        $.each(SubUnidadEjecutora, function () {
            var RowContent = '<option value=' + this.subUnidadEjecutoraId + '>' + this.descSubUnidadEjecutora + '</option>'
            $("select#cbSUEe").append(RowContent);
        });

        $("select#cbFuenteFinanc").html("");
        $.each(FuenteFinanciamiento, function () {
            var RowContent = '<option value=' + this.fuenteFinanciamientoId + '>' + this.descFuenteFinanciamiento + '</option>'
            $("select#cbFuenteFinanc").append(RowContent);
        });
        $("select#cbFuenteFinance").html("");
        $.each(FuenteFinanciamiento, function () {
            var RowContent = '<option value=' + this.fuenteFinanciamientoId + '>' + this.descFuenteFinanciamiento + '</option>'
            $("select#cbFuenteFinance").append(RowContent);
        });


    });
}

