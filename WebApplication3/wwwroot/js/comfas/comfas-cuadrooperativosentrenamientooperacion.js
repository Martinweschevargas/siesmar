var tblComfasCuadroOperativosEntrenamientoOperacion;

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
                                url: '/ComfasCuadroOperativosEntrenamientoOperacion/Insertar',
                                data: {
                                    'Fecha': $('#txtFecha').val(),
                                    'HoraInicio': $('#txtHoraInicio').val(),
                                    'HoraTermino': $('#txtHoraTermino').val(),
                                    'Evento': $('#txtEvento').val(),
                                    'OCEConductorControl': $('#txtOCEConductorControl').val(),
                                    'UnidadAeronaveParticipante': $('#txtUnidadAeronaveParticipante').val(),
                                    'Area': $('#txtArea').val(), 
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
                                    $('#tblComfasCuadroOperativosEntrenamientoOperacion').DataTable().ajax.reload();
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
                                url: '/ComfasCuadroOperativosEntrenamientoOperacion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'Fecha': $('#txtFechae').val(),
                                    'HoraInicio': $('#txtHoraInicioe').val(),
                                    'HoraTermino': $('#txtHoraTerminoe').val(),
                                    'Evento': $('#txtEventoe').val(),
                                    'OCEConductorControl': $('#txtOCEConductorControle').val(),
                                    'UnidadAeronaveParticipante': $('#txtUnidadAeronaveParticipantee').val(),
                                    'Area': $('#txtAreae').val(), 
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
                                    $('#tblComfasCuadroOperativosEntrenamientoOperacion').DataTable().ajax.reload();
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

    $('#tblComfasCuadroOperativosEntrenamientoOperacion').DataTable({
        ajax: {
            "url": '/ComfasCuadroOperativosEntrenamientoOperacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cuadroOperativoEntrenamientoOperacionId" },
            { "data": "fecha" },
            { "data": "horaInicio" },
            { "data": "horaTermino" },
            { "data": "evento" },
            { "data": "oceConductorControl" },
            { "data": "unidadAeronaveParticipante" },
            { "data": "area" }, 

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.cuadroOperativoEntrenamientoOperacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.cuadroOperativoEntrenamientoOperacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Cuadro de Operativos y Entrenamiento Operacionales en la Mar',
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
                filename: 'Comfas - Cuadro de Operativos y Entrenamiento Operacionales en la Mar',
                title: 'Comfas - Cuadro de Operativos y Entrenamiento Operacionales en la Mar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Cuadro de Operativos y Entrenamiento Operacionales en la Mar',
                title: 'Comfas - Cuadro de Operativos y Entrenamiento Operacionales en la Mar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Cuadro de Operativos y Entrenamiento Operacionales en la Mar',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    $.getJSON('/ComfasCuadroOperativosEntrenamientoOperacion/Mostrar?Id=' + Id, [], function (CuadroOperativosEntrenamientoOperacionComfasDTO) {
        $('#txtCodigo').val(CuadroOperativosEntrenamientoOperacionComfasDTO.cuadroOperativoEntrenamientoOperacionId);
        $('#txtFechae').val(CuadroOperativosEntrenamientoOperacionComfasDTO.fecha);
        $('#txtHoraInicioe').val(CuadroOperativosEntrenamientoOperacionComfasDTO.horaInicio);
        $('#txtHoraTerminoe').val(CuadroOperativosEntrenamientoOperacionComfasDTO.horaTermino);
        $('#txtEventoe').val(CuadroOperativosEntrenamientoOperacionComfasDTO.evento);
        $('#txtOCEConductorControle').val(CuadroOperativosEntrenamientoOperacionComfasDTO.oceConductorControl);
        $('#txtUnidadAeronaveParticipantee').val(CuadroOperativosEntrenamientoOperacionComfasDTO.unidadAeronaveParticipante);
        $('#txtAreae').val(CuadroOperativosEntrenamientoOperacionComfasDTO.area); 
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
                url: '/ComfasCuadroOperativosEntrenamientoOperacion/Eliminar',
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
                    $('#tblComfasCuadroOperativosEntrenamientoOperacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasCuadroOperativosEntrenamientoOperacion() {
    $('#listar').hide();
    $('#nuevo').show();
}



