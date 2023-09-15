var tblComfasDiqueoCarenaUnidadNaval;

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
                                url: '/ComfasDiqueoCarenaUnidadNaval/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'FechaIngresoUltimoDiqueo': $('#txtFechaIngresoUltimoDiqueo').val(),
                                    'FechaSalidaUltimoDiqueo': $('#txtFechaSalidaUltimoDiqueo').val(),
                                    'FechaIngresoProximoDiqueo': $('#txtFechaIngresoProximoDiqueo').val(),
                                    'FechaSalidaProximoDiqueo': $('#txtFechaSalidaProximoDiqueo').val(),
                                    'PrioridadProximoDiqueo': $('#txtPrioridadProximoDiqueo').val(),
                                    'Lugar': $('#txtLugar').val(),
                                    'Observaciones': $('#txtObservaciones').val(), 
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
                                    $('#tblComfasDiqueoCarenaUnidadNaval').DataTable().ajax.reload();
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
                                url: '/ComfasDiqueoCarenaUnidadNaval/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'FechaIngresoUltimoDiqueo': $('#txtFechaIngresoUltimoDiqueoe').val(),
                                    'FechaSalidaUltimoDiqueo': $('#txtFechaSalidaUltimoDiqueoe').val(),
                                    'FechaIngresoProximoDiqueo': $('#txtFechaIngresoProximoDiqueoe').val(),
                                    'FechaSalidaProximoDiqueo': $('#txtFechaSalidaProximoDiqueoe').val(),
                                    'PrioridadProximoDiqueo': $('#txtPrioridadProximoDiqueoe').val(),
                                    'Lugar': $('#txtLugare').val(),
                                    'Observaciones': $('#txtObservacionese').val(), 
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
                                    $('#tblComfasDiqueoCarenaUnidadNaval').DataTable().ajax.reload();
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

    $('#tblComfasDiqueoCarenaUnidadNaval').DataTable({
        ajax: {
            "url": '/ComfasDiqueoCarenaUnidadNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "diqueoCarenaUnidadNavalId" },
            { "data": "descUnidadNaval" },
            { "data": "fechaIngresoUltimoDiqueo" },
            { "data": "fechaSalidaUltimoDiqueo" },
            { "data": "fechaIngresoProximoDiqueo" },
            { "data": "fechaSalidaProximoDiqueo" },
            { "data": "prioridadProximoDiqueo" },
            { "data": "lugar" },
            { "data": "observaciones" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.diqueoCarenaUnidadNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.diqueoCarenaUnidadNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Cuadro de Diqueo y Carena de Unidades Navales',
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
                filename: 'Comfas - Cuadro de Diqueo y Carena de Unidades Navales',
                title: 'Comfas - Cuadro de Diqueo y Carena de Unidades Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Cuadro de Diqueo y Carena de Unidades Navales',
                title: 'Comfas - Cuadro de Diqueo y Carena de Unidades Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Cuadro de Diqueo y Carena de Unidades Navales',
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
    $.getJSON('/ComfasDiqueoCarenaUnidadNaval/Mostrar?Id=' + Id, [], function (DiqueoCarenaUnidadNavalComfasDTO) {
        $('#txtCodigo').val(DiqueoCarenaUnidadNavalComfasDTO.diqueoCarenaUnidadNavalId);
        $('#cbUnidadNavale').val(DiqueoCarenaUnidadNavalComfasDTO.unidadNavalId);
        $('#txtFechaIngresoUltimoDiqueoe').val(DiqueoCarenaUnidadNavalComfasDTO.fechaIngresoUltimoDiqueo);
        $('#txtFechaSalidaUltimoDiqueoe').val(DiqueoCarenaUnidadNavalComfasDTO.fechaSalidaUltimoDiqueo);
        $('#txtFechaIngresoProximoDiqueoe').val(DiqueoCarenaUnidadNavalComfasDTO.fechaIngresoProximoDiqueo);
        $('#txtFechaSalidaProximoDiqueoe').val(DiqueoCarenaUnidadNavalComfasDTO.fechaSalidaProximoDiqueo);
        $('#txtPrioridadProximoDiqueoe').val(DiqueoCarenaUnidadNavalComfasDTO.prioridadProximoDiqueo);
        $('#txtLugare').val(DiqueoCarenaUnidadNavalComfasDTO.lugar);
        $('#txtObservacionese').val(DiqueoCarenaUnidadNavalComfasDTO.observaciones); 
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
                url: '/ComfasDiqueoCarenaUnidadNaval/Eliminar',
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
                    $('#tblComfasDiqueoCarenaUnidadNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasDiqueoCarenaUnidadNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasDiqueoCarenaUnidadNaval/cargaCombs', [], function (Json) {
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

