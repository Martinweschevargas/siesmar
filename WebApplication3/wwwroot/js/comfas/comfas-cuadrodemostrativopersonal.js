var tblComfasCuadroDemostrativoPersonal;

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
                                url: '/ComfasCuadroDemostrativoPersonal/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'Fecha': $('#txtFecha').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoPersonalMilitar').val(),
                                    'EspecialidadGenericaPersonalId': $('#cbEspecialidadGenericaPersonal').val(),
                                    'CIPPersonal': $('#txtCIPPersonal').val(),
                                    'Condicion': $('#txtCondicion').val(),
                                    'UbigeoOrigen': $('#txtUbigeoOrigen').val(),
                                    'UbigeoDestino': $('#txtUbigeoDestino').val(),
                                    'FechaInicio': $('#txtFechaInicio').val(),
                                    'FechaTermino': $('#txtFechaTermino').val(),
                                    'DuracionDias': $('#txtDuracionDias').val(),
                                    'DocumentoReferencia': $('#txtDocumentoReferencia').val(),
                                    'Motivo': $('#txtMotivo').val(), 
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
                                    $('#tblComfasCuadroDemostrativoPersonal').DataTable().ajax.reload();
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
                                url: '/ComfasCuadroDemostrativoPersonal/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'Fecha': $('#txtFechae').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoPersonalMilitare').val(),
                                    'EspecialidadGenericaPersonalId': $('#cbEspecialidadGenericaPersonale').val(),
                                    'CIPPersonal': $('#txtCIPPersonale').val(),
                                    'Condicion': $('#txtCondicione').val(),
                                    'UbigeoOrigen': $('#txtUbigeoOrigene').val(),
                                    'UbigeoDestino': $('#txtUbigeoDestinoe').val(),
                                    'FechaInicio': $('#txtFechaInicioe').val(),
                                    'FechaTermino': $('#txtFechaTerminoe').val(),
                                    'DuracionDias': $('#txtDuracionDiase').val(),
                                    'DocumentoReferencia': $('#txtDocumentoReferenciae').val(),
                                    'Motivo': $('#txtMotivoe').val(), 
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
                                    $('#tblComfasCuadroDemostrativoPersonal').DataTable().ajax.reload();
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

    $('#tblComfasCuadroDemostrativoPersonal').DataTable({
        ajax: {
            "url": '/ComfasCuadroDemostrativoPersonal/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cuadroDemostrativoPersonalComfasId" },
            { "data": "descUnidadNaval" },
            { "data": "fecha" },
            { "data": "descGradoPersonalMilitar" },
            { "data": "descEspecialidadGenericaPersonal" },
            { "data": "cipPersonal" },
            { "data": "condicion" },
            { "data": "ubigeoOrigen" },
            { "data": "ubigeoDestino" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "duracionDias" },
            { "data": "documentoReferencia" },
            { "data": "motivo" },
 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.cuadroDemostrativoPersonalComfasId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.cuadroDemostrativoPersonalComfasId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Cuadro Demostrativo DEL Personal de la Fuerza de Superficie',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13 ]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfas - Cuadro Demostrativo DEL Personal de la Fuerza de Superficie',
                title: 'Comfas - Cuadro Demostrativo DEL Personal de la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Cuadro Demostrativo DEL Personal de la Fuerza de Superficie',
                title: 'Comfas - Cuadro Demostrativo DEL Personal de la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Cuadro Demostrativo DEL Personal de la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
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
    $.getJSON('/ComfasCuadroDemostrativoPersonal/Mostrar?Id=' + Id, [], function (CuadroDemostrativoPersonalComfasDTO) {
        $('#txtCodigo').val(CuadroDemostrativoPersonalComfasDTO.cuadroDemostrativoPersonalComfasId);
        $('#cbUnidadNavale').val(CuadroDemostrativoPersonalComfasDTO.unidadNavalId);
        $('#txtFechae').val(CuadroDemostrativoPersonalComfasDTO.fecha);
        $('#cbGradoPersonalMilitare').val(CuadroDemostrativoPersonalComfasDTO.gradoPersonalMilitarId);
        $('#cbEspecialidadGenericaPersonale').val(CuadroDemostrativoPersonalComfasDTO.especialidadGenericaPersonalId);
        $('#txtCIPPersonale').val(CuadroDemostrativoPersonalComfasDTO.cipPersonal);
        $('#txtCondicione').val(CuadroDemostrativoPersonalComfasDTO.condicion);
        $('#txtUbigeoOrigene').val(CuadroDemostrativoPersonalComfasDTO.ubigeoOrigen);
        $('#txtUbigeoDestinoe').val(CuadroDemostrativoPersonalComfasDTO.ubigeoDestino);
        $('#txtFechaInicioe').val(CuadroDemostrativoPersonalComfasDTO.fechaInicio);
        $('#txtFechaTerminoe').val(CuadroDemostrativoPersonalComfasDTO.fechaTermino);
        $('#txtDuracionDiase').val(CuadroDemostrativoPersonalComfasDTO.duracionDias);
        $('#txtDocumentoReferenciae').val(CuadroDemostrativoPersonalComfasDTO.documentoReferencia);
        $('#txtMotivoe').val(CuadroDemostrativoPersonalComfasDTO.motivo); 
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
                url: '/ComfasCuadroDemostrativoPersonal/Eliminar',
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
                    $('#tblComfasCuadroDemostrativoPersonal').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasCuadroDemostrativoPersonal() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasCuadroDemostrativoPersonal/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var especialidadGenericaPersonal = Json["data3"];




        $("select#cbUnidadNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbGradoPersonalMilitar").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
        });
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });


        $("select#cbEspecialidadGenericaPersonal").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonal").append(RowContent);
        });
        $("select#cbEspecialidadGenericaPersonale").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonale").append(RowContent);
        });



    });
}

