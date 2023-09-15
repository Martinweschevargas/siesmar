var tblComfasAlistamientoRepuestoCritico;

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
                                url: '/ComfasAlistamientoRepuestoCritico/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'SistemaRespuestoCriticoId': $('#cbSistemaRespuestoCritico').val(),
                                    'SubsistemaRepuestoCriticoId': $('#cbSubsistemaRepuestoCritico').val(),
                                    'EquipoRepuestoCritico': $('#txtEquipoRepuestoCritico').val(),
                                    'Repuesto': $('#txtRepuesto').val(),
                                    'RepuestoExistente': $('#txtRepuestoExistente').val(),
                                    'RepuestoNecesario': $('#txtRepuestoNecesario').val(),
                                    'CoeficientePonderacion': $('#txtCoeficientePonderacion').val(), 
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
                                    $('#tblComfasAlistamientoRepuestoCritico').DataTable().ajax.reload();
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
                                url: '/ComfasAlistamientoRepuestoCritico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'SistemaRespuestoCriticoId': $('#cbSistemaRespuestoCriticoe').val(),
                                    'SubsistemaRepuestoCriticoId': $('#cbSubsistemaRepuestoCriticoe').val(),
                                    'EquipoRepuestoCritico': $('#txtEquipoRepuestoCriticoe').val(),
                                    'Repuesto': $('#txtRepuestoe').val(),
                                    'RepuestoExistente': $('#txtRepuestoExistentee').val(),
                                    'RepuestoNecesario': $('#txtRepuestoNecesarioe').val(),
                                    'CoeficientePonderacion': $('#txtCoeficientePonderacione').val(), 
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
                                    $('#tblComfasAlistamientoRepuestoCritico').DataTable().ajax.reload();
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

    $('#tblComfasAlistamientoRepuestoCritico').DataTable({
        ajax: {
            "url": '/ComfasAlistamientoRepuestoCritico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoRepuestoCriticoId" },
            { "data": "descUnidadNaval" },
            { "data": "descSistemaRespuestoCritico" },
            { "data": "descSubsistemaRepuestoCritico" },
            { "data": "equipoRepuestoCritico" },
            { "data": "repuesto" },
            { "data": "repuestoExistente" },
            { "data": "repuestoNecesario" },
            { "data": "coeficientePonderacion" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoRepuestoCriticoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoRepuestoCriticoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Alistamiento de Repuestos Críticos (ARC)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfas - Alistamiento de Repuestos Críticos (ARC)',
                title: 'Comfas - Alistamiento de Repuestos Críticos (ARC)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Alistamiento de Repuestos Críticos (ARC)',
                title: 'Comfas - Alistamiento de Repuestos Críticos (ARC)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Alistamiento de Repuestos Críticos (ARC)',
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
    $.getJSON('/ComfasAlistamientoRepuestoCritico/Mostrar?Id=' + Id, [], function (AlistamientoRepuestoCriticoComfasDTO) {
        $('#txtCodigo').val(AlistamientoRepuestoCriticoComfasDTO.alistamientoRepuestoCriticoId);
        $('#cbUnidadNavale').val(AlistamientoRepuestoCriticoComfasDTO.unidadNavalId);
        $('#cbSistemaRespuestoCriticoe').val(AlistamientoRepuestoCriticoComfasDTO.sistemaRespuestoCriticoId);
        $('#cbSubsistemaRepuestoCriticoe').val(AlistamientoRepuestoCriticoComfasDTO.subsistemaRepuestoCriticoId);
        $('#txtEquipoRepuestoCriticoe').val(AlistamientoRepuestoCriticoComfasDTO.equipoRepuestoCritico);
        $('#txtRepuestoe').val(AlistamientoRepuestoCriticoComfasDTO.repuesto);
        $('#txtRepuestoExistentee').val(AlistamientoRepuestoCriticoComfasDTO.repuestoExistente);
        $('#txtRepuestoNecesarioe').val(AlistamientoRepuestoCriticoComfasDTO.repuestoNecesario);
        $('#txtCoeficientePonderacione').val(AlistamientoRepuestoCriticoComfasDTO.coeficientePonderacion); 
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
                url: '/ComfasAlistamientoRepuestoCritico/Eliminar',
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
                    $('#tblComfasAlistamientoRepuestoCritico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasAlistamientoRepuestoCritico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasAlistamientoRepuestoCritico/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var sistemaRepuestoCritico = Json["data2"];
        var subsistemaRepuestoCritico = Json["data3"];

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


        $("select#cbSistemaRespuestoCritico").html("");
        $.each(sistemaRepuestoCritico, function () {
            var RowContent = '<option value=' + this.sistemaRepuestoCriticoId + '>' + this.descSistemaRepuestoCritico + '</option>'
            $("select#cbSistemaRespuestoCritico").append(RowContent);
        });
        $("select#cbSistemaRespuestoCriticoe").html("");
        $.each(sistemaRepuestoCritico, function () {
            var RowContent = '<option value=' + this.sistemaRepuestoCriticoId + '>' + this.descSistemaRepuestoCritico + '</option>'
            $("select#cbSistemaRespuestoCriticoe").append(RowContent);
        });


        $("select#cbSubsistemaRepuestoCritico").html("");
        $.each(subsistemaRepuestoCritico, function () {
            var RowContent = '<option value=' + this.subsistemaRepuestoCriticoId + '>' + this.descSubsistemaRepuestoCritico + '</option>'
            $("select#cbSubsistemaRepuestoCritico").append(RowContent);
        });
        $("select#cbSubsistemaRepuestoCriticoe").html("");
        $.each(subsistemaRepuestoCritico, function () {
            var RowContent = '<option value=' + this.subsistemaRepuestoCriticoId + '>' + this.descSubsistemaRepuestoCritico + '</option>'
            $("select#cbSubsistemaRepuestoCriticoe").append(RowContent);
        }); 


    });
}

