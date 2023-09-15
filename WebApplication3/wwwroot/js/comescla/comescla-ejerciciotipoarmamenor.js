var tblComesclaEjercicioTipoArmaMenor;

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
                                url: '/ComesclaEjercicioTipoArmaMenor/Insertar',
                                data: {
                                    'TipoPersonalMilitarId': $('#cbTipoPersonalMilitar').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoPersonalMilitar').val(),
                                    'FechaEjercicio': $('#txtFechaEjercicio').val(),
                                    'TipoArmamentoId': $('#cbTipoArmamento').val(),
                                    'PosicionTipoArmaId': $('#cbPosicionTipoArma').val(),
                                    'DistanciaMetros': $('#txtDistanciaMetros').val(),
                                    'CantidadTiro': $('#txtCantidadTiro').val(),
                                    'PorcentajeEvaluacion': $('#txtPorcentajeEvaluacion').val(), 
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
                                    $('#tblComesclaEjercicioTipoArmaMenor').DataTable().ajax.reload();
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
                                url: '/ComesclaEjercicioTipoArmaMenor/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoPersonalMilitarId': $('#cbTipoPersonalMilitare').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoPersonalMilitare').val(),
                                    'FechaEjercicio': $('#txtFechaEjercicioe').val(),
                                    'TipoArmamentoId': $('#cbTipoArmamentoe').val(),
                                    'PosicionTipoArmaId': $('#cbPosicionTipoArmae').val(),
                                    'DistanciaMetros': $('#txtDistanciaMetrose').val(),
                                    'CantidadTiro': $('#txtCantidadTiroe').val(),
                                    'PorcentajeEvaluacion': $('#txtPorcentajeEvaluacione').val(), 
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
                                    $('#tblComesclaEjercicioTipoArmaMenor').DataTable().ajax.reload();
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

    $('#tblComesclaEjercicioTipoArmaMenor').DataTable({
        ajax: {
            "url": '/ComesclaEjercicioTipoArmaMenor/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ejercicioTipoArmaMenorId" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGradoPersonalMilitar" },
            { "data": "fechaEjercicio" },
            { "data": "descTipoArmamento" },
            { "data": "descPosicionTipoArma" },
            { "data": "distanciaMetros" },
            { "data": "cantidadTiro" },
            { "data": "porcentajeEvaluacion" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ejercicioTipoArmaMenorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ejercicioTipoArmaMenorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comescla - Ejercicios de Tiro con Armas Menores',
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
                filename: 'Comescla - Ejercicios de Tiro con Armas Menores',
                title: 'Comescla - Ejercicios de Tiro con Armas Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescla - Ejercicios de Tiro con Armas Menores',
                title: 'Comescla - Ejercicios de Tiro con Armas Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescla - Ejercicios de Tiro con Armas Menores',
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
    $.getJSON('/ComesclaEjercicioTipoArmaMenor/Mostrar?Id=' + Id, [], function (EjercicioTipoArmaMenorComesclaDTO) {
        $('#txtCodigo').val(EjercicioTipoArmaMenorComesclaDTO.ejercicioTipoArmaMenorId);
        $('#cbTipoPersonalMilitare').val(EjercicioTipoArmaMenorComesclaDTO.tipoPersonalMilitarId);
        $('#cbGradoPersonalMilitare').val(EjercicioTipoArmaMenorComesclaDTO.gradoPersonalMilitarId);
        $('#txtFechaEjercicioe').val(EjercicioTipoArmaMenorComesclaDTO.fechaEjercicio);
        $('#cbTipoArmamentoe').val(EjercicioTipoArmaMenorComesclaDTO.tipoArmamentoId);
        $('#cbPosicionTipoArmae').val(EjercicioTipoArmaMenorComesclaDTO.posicionTipoArmaId);
        $('#txtDistanciaMetrose').val(EjercicioTipoArmaMenorComesclaDTO.distanciaMetros);
        $('#txtCantidadTiroe').val(EjercicioTipoArmaMenorComesclaDTO.cantidadTiro);
        $('#txtPorcentajeEvaluacione').val(EjercicioTipoArmaMenorComesclaDTO.porcentajeEvaluacion); 
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
                url: '/ComesclaEjercicioTipoArmaMenor/Eliminar',
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
                    $('#tblComesclaEjercicioTipoArmaMenor').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComesclaEjercicioTipoArmaMenor() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComesclaEjercicioTipoArmaMenor/cargaCombs', [], function (Json) {
        var tipoPersonalMilitar = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var tipoArmamento = Json["data3"];
        var posicionTipoArma = Json["data4"];

        $("select#cbTipoPersonalMilitar").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.tipoPersonalMilitarId + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitar").append(RowContent);
        });
        $("select#cbTipoPersonalMilitare").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.tipoPersonalMilitarId + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitare").append(RowContent);
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


        $("select#cbTipoArmamento").html("");
        $.each(tipoArmamento, function () {
            var RowContent = '<option value=' + this.tipoArmamentoId + '>' + this.descTipoArmamento + '</option>'
            $("select#cbTipoArmamento").append(RowContent);
        });
        $("select#cbTipoArmamentoe").html("");
        $.each(tipoArmamento, function () {
            var RowContent = '<option value=' + this.tipoArmamentoId + '>' + this.descTipoArmamento + '</option>'
            $("select#cbTipoArmamentoe").append(RowContent);
        });


        $("select#cbPosicionTipoArma").html("");
        $.each(posicionTipoArma, function () {
            var RowContent = '<option value=' + this.posicionTipoArmaId + '>' + this.descPosicionTipoArma + '</option>'
            $("select#cbPosicionTipoArma").append(RowContent);
        });
        $("select#cbPosicionTipoArmae").html("");
        $.each(posicionTipoArma, function () {
            var RowContent = '<option value=' + this.posicionTipoArmaId + '>' + this.descPosicionTipoArma + '</option>'
            $("select#cbPosicionTipoArmae").append(RowContent);
        });



    });
}

