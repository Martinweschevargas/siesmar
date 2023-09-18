var tblComfasAsignacionConsumoLubricanteMotor;

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
                                url: '/ComfasAsignacionConsumoLubricanteMotor/Insertar',
                                data: {
                                    'AnioAsignacion': $('#txtAnioAsignacion').val(),
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'CapacidadMaximaAlmacen': $('#txtCapacidadMaximaAlmacen').val(),
                                    'Asignado': $('#txtAsignado').val(),
                                    'ConsumoTotalAnualPuerto': $('#txtConsumoTotalAnualPuerto').val(),
                                    'ConsumoTotalAnualNavegacion': $('#txtConsumoTotalAnualNavegacion').val(), 
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
                                    $('#tblComfasAsignacionConsumoLubricanteMotor').DataTable().ajax.reload();
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
                                url: '/ComfasAsignacionConsumoLubricanteMotor/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'AnioAsignacion': $('#txtAnioAsignacione').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'CapacidadMaximaAlmacen': $('#txtCapacidadMaximaAlmacene').val(),
                                    'Asignado': $('#txtAsignadoe').val(),
                                    'ConsumoTotalAnualPuerto': $('#txtConsumoTotalAnualPuertoe').val(),
                                    'ConsumoTotalAnualNavegacion': $('#txtConsumoTotalAnualNavegacione').val(), 
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
                                    $('#tblComfasAsignacionConsumoLubricanteMotor').DataTable().ajax.reload();
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

    $('#tblComfasAsignacionConsumoLubricanteMotor').DataTable({
        ajax: {
            "url": '/ComfasAsignacionConsumoLubricanteMotor/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "asignacionConsumoLubricanteMotorId" },
            { "data": "anioAsignacion" },
            { "data": "descUnidadNaval" },
            { "data": "capacidadMaximaAlmacen" },
            { "data": "asignado" },
            { "data": "consumoTotalAnualPuerto" },
            { "data": "consumoTotalAnualNavegacion" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.asignacionConsumoLubricanteMotorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.asignacionConsumoLubricanteMotorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Asignación  Lubricantes de Motores',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfas - Asignación  Lubricantes de Motores',
                title: 'Comfas - Asignación  Lubricantes de Motores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Asignación  Lubricantes de Motores',
                title: 'Comfas - Asignación  Lubricantes de Motores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Asignación  Lubricantes de Motores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
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
    $.getJSON('/ComfasAsignacionConsumoLubricanteMotor/Mostrar?Id=' + Id, [], function (AsignacionConsumoLubricanteMotorComfasDTO) {
        $('#txtCodigo').val(AsignacionConsumoLubricanteMotorComfasDTO.asignacionConsumoLubricanteMotorId);
        $('#txtAnioAsignacione').val(AsignacionConsumoLubricanteMotorComfasDTO.anioAsignacion);
        $('#cbUnidadNavale').val(AsignacionConsumoLubricanteMotorComfasDTO.unidadNavalId);
        $('#txtCapacidadMaximaAlmacene').val(AsignacionConsumoLubricanteMotorComfasDTO.capacidadMaximaAlmacen);
        $('#txtAsignadoe').val(AsignacionConsumoLubricanteMotorComfasDTO.asignado);
        $('#txtConsumoTotalAnualPuertoe').val(AsignacionConsumoLubricanteMotorComfasDTO.consumoTotalAnualPuerto);
        $('#txtConsumoTotalAnualNavegacione').val(AsignacionConsumoLubricanteMotorComfasDTO.consumoTotalAnualNavegacion); 
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
                url: '/ComfasAsignacionConsumoLubricanteMotor/Eliminar',
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
                    $('#tblComfasAsignacionConsumoLubricanteMotor').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasAsignacionConsumoLubricanteMotor() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasAsignacionConsumoLubricanteMotor/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];


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



    });
}

