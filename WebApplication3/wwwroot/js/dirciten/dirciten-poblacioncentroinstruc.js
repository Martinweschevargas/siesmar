var tblDircitenPoblacionCentroIntruccionTNaval;

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
                                url: '/DircitenPoblacionCentroIntruccionTNaval/Insertar',
                                data: {
                                    'DNIIntruccionTNaval': $('#txtDNI').val(),
                                    'GeneroIntruccionTNaval': $('#txtGenero').val(),
                                    'FechaNacimientoIntruccionTNaval': $('#txtFechaNacimiento').val(),
                                    'LugarNacimiento': $('#txtLugarNacimiento').val(),
                                    'LugarDomicilio': $('#txtLugarDomicilio').val(),
                                    'FechaIngresoIntruccionTNaval': $('#txtFechaIngresoIntr').val(),
                                    'AnoAcademico': $('#txtAnoAcademico').val(),
                                    'SemestreAcademico': $('#txtSemestreA').val(),
                                    'IndiceRendimientoIRAS': $('#txtIndiceRendimientoIRAS').val(),
                                    'NotaCaracterMilitar': $('#txtNotaCaracter').val(),
                                    'NotaFormacionFisica': $('#txtNotaFormacionF').val(),
                                    'NotaConductaIntruccionTNaval': $('#txtNotaConducta').val(),
                                    'ResultadoTerminoTrimestre': $('#txtResultadoTerminoT').val(),
                                    'CodigoCausalBaja': $('#cbCausalBaja').val(),
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
                                    $('#tblDircitenPoblacionCentroIntruccionTNaval').DataTable().ajax.reload();
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
                                url: '/DircitenPoblacionCentroIntruccionTNaval/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIIntruccionTNaval': $('#txtDNIe').val(),
                                    'GeneroIntruccionTNaval': $('#txtGeneroe').val(),
                                    'FechaNacimientoIntruccionTNaval': $('#txtFechaNacimientoe').val(),
                                    'LugarNacimiento': $('#txtLugarNacimientoe').val(),
                                    'LugarDomicilio': $('#txtLugarDomicilioe').val(),
                                    'FechaIngresoIntruccionTNaval': $('#txtFechaIngresoIntre').val(),
                                    'AnoAcademico': $('#txtAnoAcademicoe').val(),
                                    'SemestreAcademico': $('#txtSemestreAe').val(),
                                    'IndiceRendimientoIRAS': $('#txtIndiceRendimientoIRASe').val(),
                                    'NotaCaracterMilitar': $('#txtNotaCaractere').val(),
                                    'NotaFormacionFisica': $('#txtNotaFormacionFe').val(),
                                    'NotaConductaIntruccionTNaval': $('#txtNotaConductae').val(),
                                    'ResultadoTerminoTrimestre': $('#txtResultadoTerminoTe').val(),
                                    'CodigoCausalBaja': $('#cbCausalBajae').val(),
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
                                    $('#tblDircitenPoblacionCentroIntruccionTNaval').DataTable().ajax.reload();
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

    $('#tblDircitenPoblacionCentroIntruccionTNaval').DataTable({
        ajax: {
            "url": '/DircitenPoblacionCentroIntruccionTNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "poblacionCentroIntruccionTNavalId" },
            { "data": "dniIntruccionTNaval" },
            { "data": "generoIntruccionTNaval" },
            { "data": "fechaNacimientoIntruccionTNaval" },
            { "data": "lugarNacimiento" },
            { "data": "lugarDomicilio" },
            { "data": "fechaIngresoIntruccionTNaval" },
            { "data": "anoAcademico" },
            { "data": "semestreAcademico" },
            { "data": "indiceRendimientoIRAS" },
            { "data": "notaCaracterMilitar" },
            { "data": "notaFormacionFisica" },
            { "data": "notaConductaIntruccionTNaval" },
            { "data": "resultadoTerminoTrimestre" },
            { "data": "descCausalBaja" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.poblacionCentroIntruccionTNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.poblacionCentroIntruccionTNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirciten - Población Centro Instrucción Técnica Naval',
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
                filename: 'Dirciten - Población Centro Instrucción Técnica Naval',
                title: 'Dirciten - Población Centro Instrucción Técnica Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirciten - Población Centro Instrucción Técnica Naval',
                title: 'Dirciten - Población Centro Instrucción Técnica Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirciten - Población Centro Instrucción Técnica Naval',
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
    $.getJSON('/DircitenPoblacionCentroIntruccionTNaval/Mostrar?Id=' + Id, [], function (PoblacionCentroIntruccionTNavalDTO) {
        $('#txtCodigo').val(PoblacionCentroIntruccionTNavalDTO.poblacionCentroIntruccionTNavalId);
        $('#txtDNIe').val(PoblacionCentroIntruccionTNavalDTO.dniIntruccionTNaval);
        $('#txtGeneroe').val(PoblacionCentroIntruccionTNavalDTO.generoIntruccionTNaval);
        $('#txtFechaNacimientoe').val(PoblacionCentroIntruccionTNavalDTO.fechaNacimientoIntruccionTNaval);
        $('#txtLugarNacimientoe').val(PoblacionCentroIntruccionTNavalDTO.lugarNacimiento);
        $('#txtLugarDomicilioe').val(PoblacionCentroIntruccionTNavalDTO.lugarDomicilio);
        $('#txtFechaIngresoIntre').val(PoblacionCentroIntruccionTNavalDTO.fechaIngresoIntruccionTNaval);
        $('#txtAnoAcademicoe').val(PoblacionCentroIntruccionTNavalDTO.anoAcademico);
        $('#txtSemestreAe').val(PoblacionCentroIntruccionTNavalDTO.semestreAcademico);
        $('#txtIndiceRendimientoIRASe').val(PoblacionCentroIntruccionTNavalDTO.indiceRendimientoIRAS);
        $('#txtNotaCaractere').val(PoblacionCentroIntruccionTNavalDTO.notaCaracterMilitar);
        $('#txtNotaFormacionFe').val(PoblacionCentroIntruccionTNavalDTO.notaFormacionFisica);
        $('#txtNotaConductae').val(PoblacionCentroIntruccionTNavalDTO.notaConductaIntruccionTNaval);
        $('#txtResultadoTerminoTe').val(PoblacionCentroIntruccionTNavalDTO.resultadoTerminoTrimestre);
        $('#cbCausalBajae').val(PoblacionCentroIntruccionTNavalDTO.codigoCausalBaja);
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
                url: '/DircitenPoblacionCentroIntruccionTNaval/Eliminar',
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
                    $('#tblDircitenPoblacionCentroIntruccionTNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDircitenPoblacionCentroIntruccionTNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/DircitenPoblacionCentroIntruccionTNaval/cargaCombs', [], function (Json) {
        var causalbaja = Json["data1"];
        var listaCargas = Json["data2"];
 

        $("select#cbCausalBaja").html("");
        $.each(causalbaja, function () {
            var RowContent = '<option value=' + this.causalBajaId + '>' + this.descCausalBaja + '</option>'
            $("select#cbCausalBaja").append(RowContent);
        });
        $("select#cbCausalBajae").html("");
        $.each(causalbaja, function () {
            var RowContent = '<option value=' + this.causalBajaId + '>' + this.descCausalBaja + '</option>'
            $("select#cbCausalBajae").append(RowContent);
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

