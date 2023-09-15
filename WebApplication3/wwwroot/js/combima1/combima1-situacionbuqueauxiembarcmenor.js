var tblCombima1SituacionBuqueAuxiEmbarcMenor;

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
                                url: '/Combima1SituacionBuqueAuxiEmbarcMenor/Insertar',
                                data: {
                                    'CodigoUnidad': $('#txtCodigoUnidad').val(),
                                    'Categoria': $('#txtCategoria').val(),
                                    'TipoPlataformaNaveId': $('#cbPlataforma').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamento').val(),
                                    'ProvinciaUbigeoId': $('#cbProvincia').val(),
                                    'DistritoUbigeoId': $('#cbDistrito').val(),
                                    'CapacidadOperativaRequeridaId': $('#cbCapacidadOperativaRequerida').val(),
                                    'CondicionId': $('#cbCondicion').val(),
                                    'Observacion': $('#txtObservacion').val(), 
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
                                    $('#tblCombima1SituacionBuqueAuxiEmbarcMenor').DataTable().ajax.reload();
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
                                url: '/Combima1SituacionBuqueAuxiEmbarcMenor/Actualizar',
                                data: {

                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidad': $('#txtCodigoUnidad').val(),
                                    'Categoria': $('#txtCategoria').val(),
                                    'TipoPlataformaNaveId': $('#cbPlataformae').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciae').val(),
                                    'DistritoUbigeoId': $('#cbDistritoe').val(),
                                    'CapacidadOperativaRequeridaId': $('#cbCapacidadOperativaRequeridae').val(),
                                    'CondicionId': $('#cbCondicione').val(),
                                    'Observacion': $('#txtObservacione').val(), 
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
                                    $('#tblCombima1SituacionBuqueAuxiEmbarcMenor').DataTable().ajax.reload();
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

    $('#tblCombima1SituacionBuqueAuxiEmbarcMenor').DataTable({
        ajax: {
            "url": '/Combima1SituacionBuqueAuxiEmbarcMenor/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionBuqueAuxiliarEmbarcacionMenorId" },
            { "data": "codigoUnidad" },
            { "data": "categoria" },
            { "data": "descTipoPlataformaNave" },
            { "data": "descDependencia" },
            { "data": "ubicacion" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },  
            { "data": "descDistrito" },
            { "data": "capacidadOperativaNave" },
            { "data": "condicionNave" },
            { "data": "observacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionBuqueAuxiliarEmbarcacionMenorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionBuqueAuxiliarEmbarcacionMenorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Combima1 - Situación de Buques Auxiliares y Embarcaciones Menores',
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
                filename: 'Combima1 - Situación de Buques Auxiliares y Embarcaciones Menores',
                title: 'Combima1 - Situación de Buques Auxiliares y Embarcaciones Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Combima1 - Situación de Buques Auxiliares y Embarcaciones Menores',
                title: 'Combima1 - Situación de Buques Auxiliares y Embarcaciones Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Combima1 - Situación de Buques Auxiliares y Embarcaciones Menores',
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
    $.getJSON('/Combima1SituacionBuqueAuxiEmbarcMenor/Mostrar?Id=' + Id, [], function (SituacionBuqueAuxiEmbarcMenorCombima1DTO) {
        $('#txtCodigo').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.situacionBuqueAuxiliarEmbarcacionMenorId);
        $('#txtCodigoUnidade').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.codigoUnidad);
        $('#txtCategoriae').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.categoria);
        $('#cbPlataformae').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.tipoPlataformaNaveId);
        $('#cbDependenciae').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.dependenciaId);
        $('#txtUbicacione').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.ubicacion);
        $('#cbDepartamentoe').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.departamentoUbigeoId);
        $('#cbProvinciae').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.provinciaUbigeoId);
        $('#cbDistritoe').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.distritoUbigeoId);
        $('#cbCapacidadOperativaRequeridae').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.capacidadOperativaNave);
        $('#cbCondicione').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.condicionNave);
        $('#txtObservacione').val(SituacionBuqueAuxiEmbarcMenorCombima1DTO.observacion); 
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
                url: '/Combima1SituacionBuqueAuxiEmbarcMenor/Eliminar',
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
                    $('#tblCombima1SituacionBuqueAuxiEmbarcMenor').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaCombima1SituacionBuqueAuxiEmbarcMenor() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            console.log(dataJson);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.nombreTemaEstudioInvestigacion),
                        $("<td>").text(item.tipoEstudioInvestigacion),
                        $("<td>").text(item.fechaInicio),
                        $("<td>").text(item.fechaTermino),
                        $("<td>").text(item.responsable),
                        $("<td>").text(item.solicitante)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            alert(dataJson.mensaje);
        })
}


function cargaDatos() {
    $.getJSON('/Combima1SituacionBuqueAuxiEmbarcMenor/cargaCombs', [], function (Json) {
        var tipoPlataformaNave = Json["data1"];
        var dependencia = Json["data2"];
        var departamentoUbigeo = Json["data3"];
        var provinciaUbigeo = Json["data4"];
        var distritoUbigeo = Json["data5"]; 
        var CapacidadOperativaRequerida = Json["data6"];
        var Condicion = Json["data7"];


        $("select#cbPlataforma").html("");
        $.each(tipoPlataformaNave, function () {
            var RowContent = '<option value=' + this.tipoPlataformaNaveId + '>' + this.descTipoPlataformaNave + '</option>'
            $("select#cbPlataforma").append(RowContent);
        });
        $("select#cbPlataformae").html("");
        $.each(tipoPlataformaNave, function () {
            var RowContent = '<option value=' + this.tipoPlataformaNaveId + '>' + this.descTipoPlataformaNave + '</option>'
            $("select#cbPlataformae").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.descDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbDepartamento").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamento").append(RowContent);
        });
        $("select#cbDepartamentoe").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoe").append(RowContent);
        });

        $("select#cbProvincia").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvincia").append(RowContent);
        });
        $("select#cbProvinciae").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciae").append(RowContent);
        });

        $("select#cbDistrito").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistrito").append(RowContent);
        });
        $("select#cbDistritoe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoe").append(RowContent);
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
    }) 
}

