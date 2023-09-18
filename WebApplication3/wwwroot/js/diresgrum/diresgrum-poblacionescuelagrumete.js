var tblDiresgrumPoblacionEscuelaGrumet;

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
                                url: '/DiresgrumPoblacionEscuelaGrumet/Insertar',
                                data: {
                                    'DNIGrumete': $('#txtDNI').val(),
                                    'SexoGrumete': $('#txtGenero').val(),
                                    'LugarNacimiento': $('#cbLugarNacimiento').val(),
                                    'FechaNacimiento': $('#txtFechaNacimiento').val(),
                                    'LugarDomicilio': $('#cbLugarDomicilio').val(),
                                    'LugarFormacionServicioMilitarId': $('#cbLugarFormacionSM').val(),
                                    'ZonaNavalId': $('#cbZonaNaval').val(),
                                    'FechaPresentacionGrumete': $('#txtFechaPresentacion').val(),
                                    'NumeroContingenciaGrumete': $('#txtNContingente').val(),
                                    'GradoEstudioAlcanzadoId': $('#cbNivelEstudios').val(),
                                    'GradoEstudioEspecifId': $('#cbGradoEstudio').val(),
                                    'EspecialidadGrumeteId': $('#cbEspecialidad').val(),
                                    'CertificacionCETPROId': $('#cbCertificacionCETPRO').val(),
                                    'CalificacionCETPRO': $('#txtCalificacionCETPRO').val(),
                                    'PromedioFormacionFisdepaica1ra': $('#txtPromedioFormaciónF').val(),
                                    'PromedioRendimientoAcademico1ra': $('#txtPRendimientoPrimera').val(),
                                    'PromedioConducta1ra': $('#txtPConductaPrimera').val(),
                                    'PromedioCaracterMilitar1ra': $('#txtPCaracterPrimera').val(),
                                    'PromedioFormacionFisica2da': $('#txtPFormacionFisicaSeg').val(),
                                    'PromedioRendimientoFinal2da': $('#txtPRendimientoSeg').val(),
                                    'PromedioConducta2da': $('#txtPConductaSeg').val(),
                                    'PromedioCaracterMilitar2da': $('#txtPCaracterSeg').val(),
                                    'ResultadoTerminoEjercicio': $('#txtResultadoTermino').val(), 
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
                                    $('#tblDiresgrumPoblacionEscuelaGrumet').DataTable().ajax.reload();
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
                                url: '/DiresgrumPoblacionEscuelaGrumet/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIGrumete': $('#txtDNIe').val(),
                                    'SexoGrumete': $('#txtGeneroe').val(),
                                    'LugarNacimiento': $('#cbLugarNacimientoe').val(),
                                    'FechaNacimiento': $('#txtFechaNacimientoe').val(),
                                    'LugarDomicilio': $('#cbLugarDomicilioe').val(),
                                    'LugarFormacionServicioMilitarId': $('#cbLugarFormacionSMe').val(),
                                    'ZonaNavalId': $('#cbZonaNavale').val(),
                                    'FechaPresentacionGrumete': $('#txtFechaPresentacione').val(),
                                    'NumeroContingenciaGrumete': $('#txtNContingentee').val(),
                                    'GradoEstudioAlcanzadoId': $('#cbNivelEstudiose').val(),
                                    'GradoEstudioEspecifId': $('#cbGradoEstudioe').val(),
                                    'EspecialidadGrumeteId': $('#cbEspecialidade').val(),
                                    'CertificacionCETPROId': $('#cbCertificacionCETPROe').val(),
                                    'CalificacionCETPRO': $('#txtCalificacionCETPROe').val(),
                                    'PromedioFormacionFisdepaica1ra': $('#txtPromedioFormaciónFe').val(),
                                    'PromedioRendimientoAcademico1ra': $('#txtPRendimientoPrimerae').val(),
                                    'PromedioConducta1ra': $('#txtPConductaPrimerae').val(),
                                    'PromedioCaracterMilitar1ra': $('#txtPCaracterPrimerae').val(),
                                    'PromedioFormacionFisica2da': $('#txtPFormacionFisicaSege').val(),
                                    'PromedioRendimientoFinal2da': $('#txtPRendimientoSege').val(),
                                    'PromedioConducta2da': $('#txtPConductaSege').val(),
                                    'PromedioCaracterMilitar2da': $('#txtPCaracterSege').val(),
                                    'ResultadoTerminoEjercicio': $('#txtResultadoTerminoe').val(), 
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
                                    $('#tblDiresgrumPoblacionEscuelaGrumet').DataTable().ajax.reload();
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

    $('#tblDiresgrumPoblacionEscuelaGrumet').DataTable({
        ajax: {
            "url": '/DiresgrumPoblacionEscuelaGrumet/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "poblacionEscuelaGrumeteId" },
            { "data": "dniGrumete" },
            { "data": "sexoGrumete" },
            { "data": "lugarNacimiento" },
            { "data": "fechaNacimiento" },
            { "data": "lugarDomicilio" },
            { "data": "descLugarFormacionServicioMilitar" },
            { "data": "descZonaNaval" },
            { "data": "fechaPresentacionGrumete" },
            { "data": "numeroContingenciaGrumete" },
            { "data": "descEstudioAlcanzado" },
            { "data": "descGradoEstudioEspecif" },
            { "data": "descEspecialidadGrumete" },
            { "data": "descCertificacionCETPRO" },
            { "data": "calificacionCETPRO" },
            { "data": "promedioFormacionFisdepaica1ra" },
            { "data": "promedioRendimientoAcademico1ra" },
            { "data": "promedioConducta1ra" },
            { "data": "promedioCaracterMilitar1ra" },
            { "data": "promedioFormacionFisica2da" },
            { "data": "promedioRendimientoFinal2da" },
            { "data": "promedioConducta2da" },
            { "data": "promedioCaracterMilitar2da" },
            { "data": "resultadoTerminoEjercicio" },


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.poblacionEscuelaGrumeteId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.poblacionEscuelaGrumeteId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresgrum - Población de la Dirección de las Escuelas de Grumetes',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diresgrum - Población de la Dirección de las Escuelas de Grumetes',
                title: 'Diresgrum - Población de la Dirección de las Escuelas de Grumetes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresgrum - Población de la Dirección de las Escuelas de Grumetes',
                title: 'Diresgrum - Población de la Dirección de las Escuelas de Grumetes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresgrum - Población de la Dirección de las Escuelas de Grumetes',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
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
    $.getJSON('/DiresgrumPoblacionEscuelaGrumet/Mostrar?Id=' + Id, [], function (PoblacionEscuelaGrumeteDTO) {
        $('#txtCodigo').val(PoblacionEscuelaGrumeteDTO.poblacionEscuelaGrumeteId);
        $('#txtDNIe').val(PoblacionEscuelaGrumeteDTO.dniGrumete);
        $('#txtGeneroe').val(PoblacionEscuelaGrumeteDTO.SexoGrumete);
        $('#cbLugarNacimientoe').val(PoblacionEscuelaGrumeteDTO.lugarNacimiento);
        $('#txtFechaNacimientoe').val(PoblacionEscuelaGrumeteDTO.fechaNacimiento);
        $('#cbLugarDomicilioe').val(PoblacionEscuelaGrumeteDTO.lugarDomicilio);
        $('#cbLugarFormacionSMe').val(PoblacionEscuelaGrumeteDTO.lugarFormacionServicioMilitarId);
        $('#cbZonaNavale').val(PoblacionEscuelaGrumeteDTO.zonaNavalId);
        $('#txtFechaPresentacione').val(PoblacionEscuelaGrumeteDTO.fechaPresentacionGrumete);
        $('#txtNContingentee').val(PoblacionEscuelaGrumeteDTO.numeroContingenciaGrumete);
        $('#cbNivelEstudiose').val(PoblacionEscuelaGrumeteDTO.gradoEstudioAlcanzadoId);
        $('#cbGradoEstudioe').val(PoblacionEscuelaGrumeteDTO.gradoEstudioEspecifId);
        $('#cbEspecialidade').val(PoblacionEscuelaGrumeteDTO.especialidadGrumeteId);
        $('#cbCertificacionCETPROe').val(PoblacionEscuelaGrumeteDTO.certificacionCETPROId);
        $('#txtCalificacionCETPROe').val(PoblacionEscuelaGrumeteDTO.calificacionCETPRO);
        $('#txtPromedioFormaciónFe').val(PoblacionEscuelaGrumeteDTO.promedioFormacionFisdepaica1ra);
        $('#txtPRendimientoPrimerae').val(PoblacionEscuelaGrumeteDTO.promedioRendimientoAcademico1ra);
        $('#txtPConductaPrimerae').val(PoblacionEscuelaGrumeteDTO.promedioConducta1ra);
        $('#txtPCaracterPrimerae').val(PoblacionEscuelaGrumeteDTO.promedioCaracterMilitar1ra);
        $('#txtPFormacionFisicaSege').val(PoblacionEscuelaGrumeteDTO.promedioFormacionFisica2da);
        $('#txtPRendimientoSege').val(PoblacionEscuelaGrumeteDTO.promedioRendimientoFinal2da);
        $('#txtPConductaSege').val(PoblacionEscuelaGrumeteDTO.promedioConducta2da);
        $('#txtPCaracterSege').val(PoblacionEscuelaGrumeteDTO.promedioCaracterMilitar2da);
        $('#txtResultadoTerminoe').val(PoblacionEscuelaGrumeteDTO.resultadoTerminoEjercicio); 
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
                url: '/DiresgrumPoblacionEscuelaGrumet/Eliminar',
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
                    $('#tblDiresgrumPoblacionEscuelaGrumet').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDiresgrumPoblacionEscuelaGrumet() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/DiresgrumPoblacionEscuelaGrumet/cargaCombs', [], function (Json) {
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

