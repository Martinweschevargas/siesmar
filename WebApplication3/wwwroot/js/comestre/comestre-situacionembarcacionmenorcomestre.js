var tblComestreSituacionEmbarcacionMenorComestre;

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
                                url: '/ComestreSituacionEmbarcacionMenorComestre/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidad').val(),
                                    'TipoNaveId': $('#cbCategoria').val(),
                                    'TipoPlataformaNaveId': $('#cbPlataforma').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamento').val(),
                                    'ProvinciaUbigeoId': $('#cbProvincia').val(),
                                    'DistritoUbigeoId': $('#cbDistrito').val(),
                                    'CapacidadOperativaNave': $('#txtCapacidad').val(),
                                    'CondicionAeronave': $('#txtCondicion').val(),
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
                                    $('#tblComestreSituacionEmbarcacionMenorComestre').DataTable().ajax.reload();
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
                                url: '/ComestreSituacionEmbarcacionMenorComestre/Actualizar',
                                data: {

                                    'SituacionEmbarcacionMenorComestreId': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidade').val(),
                                    'TipoNaveId': $('#cbCategoriae').val(),
                                    'TipoPlataformaNaveId': $('#cbPlataformae').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciae').val(),
                                    'DistritoUbigeoId': $('#cbDistritoe').val(),
                                    'CapacidadOperativaNave': $('#txtCapacidade').val(),
                                    'CondicionAeronave': $('#txtCondicione').val(),
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
                                    $('#tblComestreSituacionEmbarcacionMenorComestre').DataTable().ajax.reload();
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

    $('#tblComestreSituacionEmbarcacionMenorComestre').DataTable({
        ajax: {
            "url": '/ComestreSituacionEmbarcacionMenorComestre/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionEmbarcacionMenorComestreId" },
            { "data": "descUnidadNaval" },
            { "data": "descTipoNave" },
            { "data": "descTipoPlataformaNave" },
            { "data": "descDependencia" },
            { "data": "ubicacion" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },  
            { "data": "descDistrito" },
            { "data": "capacidadOperativaNave" },
            { "data": "condicionAeronave" },
            { "data": "observacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionEmbarcacionMenorComestreId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionEmbarcacionMenorComestreId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comestre - Situacion de Embarcaciones Menores',
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
                filename: 'Comestre - Situacion de Embarcaciones Menores',
                title: 'Comestre - Situacion de Embarcaciones Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comestre - Situacion de Embarcaciones Menores',
                title: 'Comestre - Situacion de Embarcaciones Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comestre - Situacion de Embarcaciones Menores',
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
    $.getJSON('/ComestreSituacionEmbarcacionMenorComestre/Mostrar?Id=' + Id, [], function (SituacionEmbarcacionMenorComestreDTO) {
        $('#txtCodigo').val(SituacionEmbarcacionMenorComestreDTO.situacionEmbarcacionMenorId);
        $('#cbUnidade').val(SituacionEmbarcacionMenorComestreDTO.unidadNavalId);
        $('#cbCategoriae').val(SituacionEmbarcacionMenorComestreDTO.tipoNaveId);
        $('#cbPlataformae').val(SituacionEmbarcacionMenorComestreDTO.tipoPlataformaNaveId);
        $('#cbDependenciae').val(SituacionEmbarcacionMenorComestreDTO.dependenciaId);
        $('#txtUbicacione').val(SituacionEmbarcacionMenorComestreDTO.ubicacion);
        $('#cbDepartamentoe').val(SituacionEmbarcacionMenorComestreDTO.departamentoUbigeoId);
        $('#cbProvinciae').val(SituacionEmbarcacionMenorComestreDTO.provinciaUbigeoId);
        $('#cbDistritoe').val(SituacionEmbarcacionMenorComestreDTO.distritoUbigeoId);
        $('#txtCapacidade').val(SituacionEmbarcacionMenorComestreDTO.capacidadOperativaNave);
        $('#txtCondicione').val(SituacionEmbarcacionMenorComestreDTO.condicionAeronave);
        $('#txtObservacione').val(SituacionEmbarcacionMenorComestreDTO.observacion); 
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
                url: '/ComestreSituacionEmbarcacionMenorComestre/Eliminar',
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
                    $('#tblComestreSituacionEmbarcacionMenorComestre').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComestreSituacionEmbarcacionMenorComestre() {
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
    $.getJSON('/ComestreSituacionEmbarcacionMenorComestre/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var tipoNave = Json["data2"];
        var tipoPlataformaNave = Json["data3"];
        var dependencia = Json["data4"];
        var departamentoUbigeo = Json["data5"];
        var provinciaUbigeo = Json["data6"];
        var distritoUbigeo = Json["data7"]; 

        $("select#cbUnidad").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidad").append(RowContent);
        });
        $("select#cbUnidade").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidade").append(RowContent);
        });

        $("select#cbCategoria").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbCategoria").append(RowContent);
        });
        $("select#cbCategoriae").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbCategoriae").append(RowContent);
        });

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
    }) 
}

