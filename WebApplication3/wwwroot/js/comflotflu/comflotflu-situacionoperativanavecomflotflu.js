var tblComflotfluSituacionOperativaNaveComflotflu;

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
                                url: '/ComflotfluSituacionOperativaNaveComflotflu/Insertar',
                                data: {
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'CascoUnidadNaval': $('#cbCascoUnidadNaval').val(),
                                    'TipoPlataforma': $('#txtTipoPlataforma').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeo').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeo').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeo').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativa').val(),
                                    'Condicion': $('#txtCondicion').val(),
                                    'Observaciones': $('#cbObservaciones').val(), 
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
                                    $('#tblComflotfluSituacionOperativaNaveComflotflu').DataTable().ajax.reload();
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
                                url: '/ComflotfluSituacionOperativaNaveComflotflu/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'CascoUnidadNaval': $('#cbCascoUnidadNavale').val(),
                                    'TipoPlataforma': $('#txtTipoPlataformae').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeoe').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeoe').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativae').val(),
                                    'Condicion': $('#txtCondicione').val(),
                                    'Observaciones': $('#cbObservacionese').val(), 
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
                                    $('#tblComflotfluSituacionOperativaNaveComflotflu').DataTable().ajax.reload();
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

    $('#tblComflotfluSituacionOperativaNaveComflotflu').DataTable({
        ajax: {
            "url": '/ComflotfluSituacionOperativaNaveComflotflu/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionOperativaNaveId" },
            { "data": "descTipoNave" },
            { "data": "descCascoUnidadNaval" },
            { "data": "tipoPlataforma" },
            { "data": "nombreDependencia" },
            { "data": "ubicacion" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDistrito" },
            { "data": "descCapacidadOperativa" },
            { "data": "condicion" },
            { "data": "observacion" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionOperativaNaveId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionOperativaNaveId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comflotflu - Situación de operatividad de naves',
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
                filename: 'Comflotflu - Situación de operatividad de naves',
                title: 'Comflotflu - Situación de operatividad de naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comflotflu - Situación de operatividad de naves',
                title: 'Comflotflu - Situación de operatividad de naves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comflotflu - Situación de operatividad de naves',
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
    $.getJSON('/ComflotfluSituacionOperativaNaveComflotflu/Mostrar?Id=' + Id, [], function (SituacionOperativaNaveComflotfluDTO) {
        $('#txtCodigo').val(SituacionOperativaNaveComflotfluDTO.situacionOperativaNaveId);
        $('#cbTipoNavee').val(SituacionOperativaNaveComflotfluDTO.tipoNaveId);
        $('#cbCascoUnidadNavale').val(SituacionOperativaNaveComflotfluDTO.cascoUnidadNaval);
        $('#txtTipoPlataformae').val(SituacionOperativaNaveComflotfluDTO.tipoPlataforma);
        $('#cbDependenciae').val(SituacionOperativaNaveComflotfluDTO.dependenciaId);
        $('#txtUbicacione').val(SituacionOperativaNaveComflotfluDTO.ubicacion);
        $('#cbDepartamentoUbigeoe').val(SituacionOperativaNaveComflotfluDTO.departamentoUbigeoId);
        $('#cbProvinciaUbigeoe').val(SituacionOperativaNaveComflotfluDTO.provinciaUbigeoId);
        $('#cbDistritoUbigeoe').val(SituacionOperativaNaveComflotfluDTO.distritoUbigeoId);
        $('#cbCapacidadOperativae').val(SituacionOperativaNaveComflotfluDTO.capacidadOperativaId);
        $('#txtCondicione').val(SituacionOperativaNaveComflotfluDTO.condicion);
        $('#cbObservacionese').val(SituacionOperativaNaveComflotfluDTO.observaciones); 
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
                url: '/ComflotfluSituacionOperativaNaveComflotflu/Eliminar',
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
                    $('#tblComflotfluSituacionOperativaNaveComflotflu').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComflotfluSituacionOperativaNaveComflotflu() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComflotfluSituacionOperativaNaveComflotflu/cargaCombs', [], function (Json) {
        var tipoNave = Json["data1"];
        var unidadNaval = Json["data2"];
        var dependencia = Json["data3"];
        var departamentoUbigeo = Json["data4"];
        var provinciaUbigeo = Json["data5"];
        var distritoUbigeo = Json["data6"];
        var capacidadOperativa = Json["data7"];



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


        $("select#cbCascoUnidadNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbCascoUnidadNaval").append(RowContent);
        });
        $("select#cbCascoUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbCascoUnidadNavale").append(RowContent);
        });


        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
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


        $("select#cbCapacidadOperativa").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
        });
        $("select#cbCapacidadOperativae").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativae").append(RowContent);
        });


    });
}

