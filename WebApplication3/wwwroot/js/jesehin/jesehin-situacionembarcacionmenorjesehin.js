var tblJesehinSituacionEmbarcacionMenorJesehin;

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
                                url: '/JesehinSituacionEmbarcacionMenorJesehin/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'TipoPlataforma': $('#txtTipoPlataforma').val(),
                                    'UnidadNavalDestino': $('#txtUnidadNavalDestino').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeo').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeo').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeo').val(),
                                    'CapacidadOperativaRequeridaId': $('#cbCapacidadOperativaRequerida').val(),
                                    'CondicionId': $('#txtCondicion').val(),
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
                                    $('#tblJesehinSituacionEmbarcacionMenorJesehin').DataTable().ajax.reload();
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
                                url: '/JesehinSituacionEmbarcacionMenorJesehin/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'TipoPlataforma': $('#txtTipoPlataformae').val(),
                                    'UnidadNavalDestino': $('#txtUnidadNavalDestinoe').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeoe').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeoe').val(),
                                    'CapacidadOperativaRequeridaId': $('#cbCapacidadOperativaRequeridae').val(),
                                    'CondicionId': $('#txtCondicione').val(),
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
                                    $('#tblJesehinSituacionEmbarcacionMenorJesehin').DataTable().ajax.reload();
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

    $('#tblJesehinSituacionEmbarcacionMenorJesehin').DataTable({
        ajax: {
            "url": '/JesehinSituacionEmbarcacionMenorJesehin/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionEmbarcacionMenorId" },
            { "data": "descUnidadNaval" },
            { "data": "descTipoNave" },
            { "data": "tipoPlataforma" },
            { "data": "descUnidadNavalDestino" },
            { "data": "ubicacion" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDistrito" },
            { "data": "descCondicion" },
            { "data": "descCapacidadOperativaRequerida" },
            { "data": "observaciones" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionEmbarcacionMenorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionEmbarcacionMenorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'comgoe-3 - Situación de buques auxiliares y embarcaciones menores',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'comgoe-3 - Situación de buques auxiliares y embarcaciones menores',
                title: 'comgoe-3 - Situación de buques auxiliares y embarcaciones menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'comgoe-3 - Situación de buques auxiliares y embarcaciones menores',
                title: 'comgoe-3 - Situación de buques auxiliares y embarcaciones menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'comgoe-3 - Situación de buques auxiliares y embarcaciones menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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
    $.getJSON('/JesehinSituacionEmbarcacionMenorJesehin/Mostrar?Id=' + Id, [], function (SituacionEmbarcacionMenorJesehinDTO) {
        $('#txtCodigo').val(SituacionEmbarcacionMenorJesehinDTO.situacionEmbarcacionMenorId);
        $('#cbUnidadNavale').val(SituacionEmbarcacionMenorJesehinDTO.unidadNavalId);
        $('#cbTipoNavee').val(SituacionEmbarcacionMenorJesehinDTO.tipoNaveId);
        $('#txtTipoPlataformae').val(SituacionEmbarcacionMenorJesehinDTO.tipoPlataforma);
        $('#txtUnidadNavalDestinoe').val(SituacionEmbarcacionMenorJesehinDTO.unidadNavalDestino);
        $('#txtUbicacione').val(SituacionEmbarcacionMenorJesehinDTO.ubicacion);
        $('#cbDepartamentoUbigeoe').val(SituacionEmbarcacionMenorJesehinDTO.departamentoUbigeoId);
        $('#cbProvinciaUbigeoe').val(SituacionEmbarcacionMenorJesehinDTO.provinciaUbigeoId);
        $('#cbDistritoUbigeoe').val(SituacionEmbarcacionMenorJesehinDTO.distritoUbigeoId);
        $('#cbCapacidadOperativaRequeridae').val(SituacionEmbarcacionMenorJesehinDTO.capacidadOperativaRequeridaId);
        $('#txtCondicione').val(SituacionEmbarcacionMenorJesehinDTO.condicion);
        $('#txtObservacionese').val(SituacionEmbarcacionMenorJesehinDTO.observaciones); 
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
                url: '/JesehinSituacionEmbarcacionMenorJesehin/Eliminar',
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
                    $('#tblJesehinSituacionEmbarcacionMenorJesehin').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaJesehinSituacionEmbarcacionMenorJesehin() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/JesehinSituacionEmbarcacionMenorJesehin/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var tipoNave = Json["data2"];
        var departamentoUbigeo = Json["data3"];
        var provinciaUbigeo = Json["data4"];
        var distritoUbigeo = Json["data5"];
        var condicion = Json["data6"];
        var capacidadOperativaRequerida = Json["data7"];



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


        $("select#cbTipoNave").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbTipoNave").append(RowContent);
        });
        $("select#cbTipoNavee").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbTipoNavee").append(RowContent);
        });


        $("select#txtUnidadNavalDestino").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#txtUnidadNavalDestino").append(RowContent);
        });
        $("select#txtUnidadNavalDestinoe").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#txtUnidadNavalDestinoe").append(RowContent);
        });


        $("select#cbDepartamentoUbigeo").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeo").append(RowContent);
        });
        $("select#cbDepartamentoUbigeoe").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeoe").append(RowContent);
        });


        $("select#cbProvinciaUbigeo").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUbigeo").append(RowContent);
        });
        $("select#cbProvinciaUbigeoe").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUbigeoe").append(RowContent);
        });


        $("select#cbDistritoUbigeo").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeo").append(RowContent);
        });
        $("select#cbDistritoUbigeoe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });

        $("select#txtCondicion").html("");
        $.each(condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#txtCondicion").append(RowContent);
        });
        $("select#txtCondicione").html("");
        $.each(condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#txtCondicione").append(RowContent);
        });

        $("select#cbCapacidadOperativaRequerida").html("");
        $.each(capacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.capacidadOperativaRequeridaId + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequerida").append(RowContent);
        });
        $("select#cbCapacidadOperativaRequeridae").html("");
        $.each(capacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.capacidadOperativaRequeridaId + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequeridae").append(RowContent);
        });


    });
}

