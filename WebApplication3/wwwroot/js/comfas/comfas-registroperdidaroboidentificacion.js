var tblComfasRegistroPerdidaRoboIdentificacion;

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
                                url: '/ComfasRegistroPerdidaRoboIdentificacion/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'FechaInforme': $('#txtFechaInforme').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoPersonalMilitar').val(),
                                    'EspecialidadGenericaPersonalId': $('#cbEspecialidadGenericaPersonal').val(),
                                    'CIPPersonal': $('#txtCIPPersonal').val(),
                                    'FechaIncidente': $('#txtFechaIncidente').val(),
                                    'Motivo': $('#txtMotivo').val(),
                                    'MensajeNavalReferencia': $('#txtMensajeNavalReferencia').val(), 
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
                                    $('#tblComfasRegistroPerdidaRoboIdentificacion').DataTable().ajax.reload();
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
                                url: '/ComfasRegistroPerdidaRoboIdentificacion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'FechaInforme': $('#txtFechaInformee').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoPersonalMilitare').val(),
                                    'EspecialidadGenericaPersonalId': $('#cbEspecialidadGenericaPersonale').val(),
                                    'CIPPersonal': $('#txtCIPPersonale').val(),
                                    'FechaIncidente': $('#txtFechaIncidentee').val(),
                                    'Motivo': $('#txtMotivoe').val(),
                                    'MensajeNavalReferencia': $('#txtMensajeNavalReferenciae').val(), 
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
                                    $('#tblComfasRegistroPerdidaRoboIdentificacion').DataTable().ajax.reload();
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

    $('#tblComfasRegistroPerdidaRoboIdentificacion').DataTable({
        ajax: {
            "url": '/ComfasRegistroPerdidaRoboIdentificacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroPerdidaRoboIdentificacionId" },
            { "data": "descUnidadNaval" },
            { "data": "fechaInforme" },
            { "data": "descGradoPersonalMilitar" },
            { "data": "descEspecialidadGenericaPersonal" },
            { "data": "cipPersonal" },
            { "data": "fechaIncidente" },
            { "data": "motivo" },
            { "data": "mensajeNavalReferencia" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroPerdidaRoboIdentificacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroPerdidaRoboIdentificacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Cuadro de Registro de Perdida o Robo de Tarjeta de Identidad Naval del Personal de la Fuerza de Superficie',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfas - Cuadro de Registro de Perdida o Robo de Tarjeta de Identidad Naval del Personal de la Fuerza de Superficie',
                title: 'Comfas - Cuadro de Registro de Perdida o Robo de Tarjeta de Identidad Naval del Personal de la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Cuadro de Registro de Perdida o Robo de Tarjeta de Identidad Naval del Personal de la Fuerza de Superficie',
                title: 'Comfas - Cuadro de Registro de Perdida o Robo de Tarjeta de Identidad Naval del Personal de la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Cuadro de Registro de Perdida o Robo de Tarjeta de Identidad Naval del Personal de la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
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
    $.getJSON('/ComfasRegistroPerdidaRoboIdentificacion/Mostrar?Id=' + Id, [], function (RegistroPerdidaRoboIdentificacionComfasDTO) {
        $('#txtCodigo').val(RegistroPerdidaRoboIdentificacionComfasDTO.registroPerdidaRoboIdentificacionId);
        $('#cbUnidadNavale').val(RegistroPerdidaRoboIdentificacionComfasDTO.unidadNavalId);
        $('#txtFechaInformee').val(RegistroPerdidaRoboIdentificacionComfasDTO.fechaInforme);
        $('#cbGradoPersonalMilitare').val(RegistroPerdidaRoboIdentificacionComfasDTO.gradoPersonalMilitarId);
        $('#cbEspecialidadGenericaPersonale').val(RegistroPerdidaRoboIdentificacionComfasDTO.especialidadGenericaPersonalId);
        $('#txtCIPPersonale').val(RegistroPerdidaRoboIdentificacionComfasDTO.cipPersonal);
        $('#txtFechaIncidentee').val(RegistroPerdidaRoboIdentificacionComfasDTO.fechaIncidente);
        $('#txtMotivoe').val(RegistroPerdidaRoboIdentificacionComfasDTO.motivo);
        $('#txtMensajeNavalReferenciae').val(RegistroPerdidaRoboIdentificacionComfasDTO.mensajeNavalReferencia); 
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
                url: '/ComfasRegistroPerdidaRoboIdentificacion/Eliminar',
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
                    $('#tblComfasRegistroPerdidaRoboIdentificacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasRegistroPerdidaRoboIdentificacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasRegistroPerdidaRoboIdentificacion/cargaCombs', [], function (Json) {
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

