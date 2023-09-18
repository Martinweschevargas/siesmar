var tblComescuamaSituacionOperatividadAeronave;

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
                                url: '/ComescuamaSituacionOperatividadAeronave/Insertar',
                                data: {
                                    'CategoriaAeronaveId': $('#cbCategoriaAeronave').val(),
                                    'NumeroCola': $('#txtNumeroCola').val(),
                                    'TipoPlataformaAeronaveId': $('#cbTipoPlataformaAeronave').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeo').val(),
                                    'CapacidadOperativaRequeridaId': $('#cbCapacidadOperativaRequerida').val(),
                                    'CondicionId': $('#cbCondicion').val(),
                                    'Observaciones': $('#txtObservacion').val(), 
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
                                    $('#tblComescuamaSituacionOperatividadAeronave').DataTable().ajax.reload();
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
                                url: '/ComescuamaSituacionOperatividadAeronave/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CategoriaAeronaveId': $('#cbCategoriaAeronavee').val(),
                                    'NumeroCola': $('#txtNumeroColae').val(),
                                    'TipoPlataformaAeronaveId': $('#cbTipoPlataformaAeronavee').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeoe').val(),
                                    'CapacidadOperativaRequeridaId': $('#cbCapacidadOperativaRequeridae').val(),
                                    'CondicionId': $('#cbCondicione').val(),
                                    'Observaciones': $('#txtObservacione').val(), 
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
                                    $('#tblComescuamaSituacionOperatividadAeronave').DataTable().ajax.reload();
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

    $('#tblComescuamaSituacionOperatividadAeronave').DataTable({
        ajax: {
            "url": '/ComescuamaSituacionOperatividadAeronave/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionOperatividadAeronaveId" },
            { "data": "descCategoriaAeronave" },
            { "data": "numeroCola" },
            { "data": "descTipoPlataformaAeronave" },
            { "data": "descDependencia" },
            { "data": "ubicacion" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDistritoUbigeo" },
            { "data": "descCapacidadOperativaRequerida" },
            { "data": "descCondicion" },
            { "data": "observaciones" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionOperatividadAeronaveId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionOperatividadAeronaveId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comescuama - Situación de Operatividad de Aeronaves',
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
                filename: 'Comescuama - Situación de Operatividad de Aeronaves',
                title: 'Comescuama - Situación de Operatividad de Aeronaves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescuama - Situación de Operatividad de Aeronaves',
                title: 'Comescuama - Situación de Operatividad de Aeronaves',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescuama - Situación de Operatividad de Aeronaves',
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
    $.getJSON('/ComescuamaSituacionOperatividadAeronave/Mostrar?Id=' + Id, [], function (SituacionOperatividadAeronaveComescuamaDTO) {
        $('#txtCodigo').val(SituacionOperatividadAeronaveComescuamaDTO.evaluacionAlistamientoPersonalId);
        $('#cbCategoriaAeronavee').val(SituacionOperatividadAeronaveComescuamaDTO.categoriaAeronaveId);
        $('#txtNumeroColae').val(SituacionOperatividadAeronaveComescuamaDTO.numeroCola);
        $('#cbTipoPlataformaAeronavee').val(SituacionOperatividadAeronaveComescuamaDTO.tipoPlataformaAeronaveId);
        $('#cbDependenciae').val(SituacionOperatividadAeronaveComescuamaDTO.dependenciaId);
        $('#txtUbicacione').val(SituacionOperatividadAeronaveComescuamaDTO.ubicacion);
        $('#cbDepartamentoUbigeoe').val(SituacionOperatividadAeronaveComescuamaDTO.descDepartamento);
        $('#cbProvinciaUbigeoe').val(SituacionOperatividadAeronaveComescuamaDTO.descProvincia);
        $('#cbDistritoUbigeoe').val(SituacionOperatividadAeronaveComescuamaDTO.distritoUbigeoId);
        $('#cbCapacidadOperativaRequeridae').val(SituacionOperatividadAeronaveComescuamaDTO.capacidadOperativaRequeridaId);
        $('#cbCondicione').val(SituacionOperatividadAeronaveComescuamaDTO.condicionId);
        $('#txtObservacione').val(SituacionOperatividadAeronaveComescuamaDTO.observaciones); 
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
                url: '/ComescuamaSituacionOperatividadAeronave/Eliminar',
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
                    $('#tblComescuamaSituacionOperatividadAeronave').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComescuamaSituacionOperatividadAeronave() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComescuamaSituacionOperatividadAeronave/cargaCombs', [], function (Json) {
        var CategoriaAeronave = Json["data1"];
        var TipoPlataformaAeronave = Json["data2"];
        var Dependencia = Json["data3"];
        var DistritoUbigeo = Json["data4"];
        var CapacidadOperativaRequerida = Json["data5"];
        var Condicion = Json["data6"];


        $("select#cbCategoriaAeronave").html("");
        $.each(CategoriaAeronave, function () {
            var RowContent = '<option value=' + this.categoriaAeronaveId + '>' + this.descCategoriaAeronave + '</option>'
            $("select#cbCategoriaAeronave").append(RowContent);
        });
        $("select#cbCategoriaAeronavee").html("");
        $.each(CategoriaAeronave, function () {
            var RowContent = '<option value=' + this.categoriaAeronaveId + '>' + this.descCategoriaAeronave + '</option>'
            $("select#cbCategoriaAeronavee").append(RowContent);
        });


        $("select#cbTipoPlataformaAeronave").html("");
        $.each(TipoPlataformaAeronave, function () {
            var RowContent = '<option value=' + this.tipoPlataformaAeronaveId + '>' + this.descTipoPlataformaAeronave + '</option>'
            $("select#cbTipoPlataformaAeronave").append(RowContent);
        });
        $("select#cbTipoPlataformaAeronavee").html("");
        $.each(TipoPlataformaAeronave, function () {
            var RowContent = '<option value=' + this.tipoPlataformaAeronaveId + '>' + this.descTipoPlataformaAeronave + '</option>'
            $("select#cbTipoPlataformaAeronavee").append(RowContent);
        });


        $("select#cbDependencia").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbDistritoUbigeo").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeo").append(RowContent);
        });
        $("select#cbDistritoUbigeoe").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });


        $("select#cbCapacidadOperativaRequerida").html("");
        $.each(CapacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.capacidadOperativaRequeridaId + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequerida").append(RowContent);
        });
        $("select#cbCapacidadOperativaRequeridae").html("");
        $.each(CapacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.capacidadOperativaRequeridaId + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequeridae").append(RowContent);
        });


        $("select#cbCondicion").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#cbCondicion").append(RowContent);
        });
        $("select#cbCondicione").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#cbCondicione").append(RowContent);
        }); 

    });
}

