var tblComfasCuadroRegistroVisita;

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
                                url: '/ComfasCuadroRegistroVisita/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'FechaVisita': $('#txtFecha').val(),
                                    'HoraIngreso': $('#txtHoraIngreso').val(),
                                    'HoraSalida': $('#txtHoraSalida').val(),
                                    'DNIVisitante': $('#txtDNIVisitante').val(),
                                    'PasaporteVisitante': $('#txtPasaporteVisitante').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'ClaseVisitaId': $('#cbClaseVisita').val(),
                                    'MotivoViaje': $('#txtMotivoViaje').val(), 
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
                                    $('#tblComfasCuadroRegistroVisita').DataTable().ajax.reload();
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
                                url: '/ComfasCuadroRegistroVisita/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'FechaVisita': $('#txtFechae').val(),
                                    'HoraIngreso': $('#txtHoraIngresoe').val(),
                                    'HoraSalida': $('#txtHoraSalidae').val(),
                                    'DNIVisitante': $('#txtDNIVisitantee').val(),
                                    'PasaporteVisitante': $('#txtPasaporteVisitantee').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'ClaseVisitaId': $('#cbClaseVisitae').val(),
                                    'MotivoViaje': $('#txtMotivoViajee').val(), 
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
                                    $('#tblComfasCuadroRegistroVisita').DataTable().ajax.reload();
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

    $('#tblComfasCuadroRegistroVisita').DataTable({
        ajax: {
            "url": '/ComfasCuadroRegistroVisita/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "cuadroRegistroVisitaComfasId" },
            { "data": "descUnidadNaval" },
            { "data": "fechaVisita" },
            { "data": "horaIngreso" },
            { "data": "horaSalida" },
            { "data": "dniVisitante" },
            { "data": "pasaporteVisitante" },
            { "data": "descPaisUbigeo" },
            { "data": "descClaseVisita" },
            { "data": "motivoViaje" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.cuadroRegistroVisitaComfasId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.cuadroRegistroVisitaComfasId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Cuadro de Registro de Visitas a la Fuerza de Superficie',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfas - Cuadro de Registro de Visitas a la Fuerza de Superficie',
                title: 'Comfas - Cuadro de Registro de Visitas a la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Cuadro de Registro de Visitas a la Fuerza de Superficie',
                title: 'Comfas - Cuadro de Registro de Visitas a la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Cuadro de Registro de Visitas a la Fuerza de Superficie',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
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
    $.getJSON('/ComfasCuadroRegistroVisita/Mostrar?Id=' + Id, [], function (CuadroRegistroVisitaComfasDTO) {
        $('#txtCodigo').val(CuadroRegistroVisitaComfasDTO.cuadroRegistroVisitaComfasId);
        $('#cbUnidadNavale').val(CuadroRegistroVisitaComfasDTO.unidadNavalId);
        $('#txtFechae').val(CuadroRegistroVisitaComfasDTO.fechaVisita);
        $('#txtHoraIngresoe').val(CuadroRegistroVisitaComfasDTO.horaIngreso);
        $('#txtHoraSalidae').val(CuadroRegistroVisitaComfasDTO.horaSalida);
        $('#txtDNIVisitantee').val(CuadroRegistroVisitaComfasDTO.dniVisitante);
        $('#txtPasaporteVisitantee').val(CuadroRegistroVisitaComfasDTO.pasaporteVisitante);
        $('#cbPaisUbigeoe').val(CuadroRegistroVisitaComfasDTO.paisUbigeoId);
        $('#cbClaseVisitae').val(CuadroRegistroVisitaComfasDTO.claseVisitaId);
        $('#txtMotivoViajee').val(CuadroRegistroVisitaComfasDTO.motivoViaje); 
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
                url: '/ComfasCuadroRegistroVisita/Eliminar',
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
                    $('#tblComfasCuadroRegistroVisita').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasCuadroRegistroVisita() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasCuadroRegistroVisita/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var paisUbigeo = Json["data2"];
        var claseVisita = Json["data3"];

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


        $("select#cbPaisUbigeo").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeo").append(RowContent);
        });
        $("select#cbPaisUbigeoe").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeoe").append(RowContent);
        });


        $("select#cbClaseVisita").html("");
        $.each(claseVisita, function () {
            var RowContent = '<option value=' + this.claseVisitaId + '>' + this.descClaseVisita + '</option>'
            $("select#cbClaseVisita").append(RowContent);
        });
        $("select#cbClaseVisitae").html("");
        $.each(claseVisita, function () {
            var RowContent = '<option value=' + this.claseVisitaId + '>' + this.descClaseVisita + '</option>'
            $("select#cbClaseVisitae").append(RowContent);
        }); 


    });
}

