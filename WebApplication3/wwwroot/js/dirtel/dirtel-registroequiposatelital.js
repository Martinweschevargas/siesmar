var tblDirtelRegistroEquipoSatelital;

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
                                url: '/DirtelRegistroEquipoSatelital/Insertar',
                                data: {
                                    'CodigoIBPEquipoSatelital': $('#txtCodigoIBP').val(),
                                    'ModeloBienServicioSubcampoId': $('#cbSubcampo').val(),
                                    'ModeloBienServicioDenominacionId': $('#cbDenominacion').val(),
                                    'MarcaId': $('#cbMarca').val(),
                                    'ModeloEquipoSatelital': $('#cbEquipo').val(),
                                    'AnioAdquisicionSatelital': $('#txtAnioAdquisicion').val(),
                                    'EstadoOperatividadTelefonia': $('#txtEstadoOperatividad').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamento').val(), 
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
                                    $('#tblDirtelRegistroEquipoSatelital').DataTable().ajax.reload();
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
                                url: '/DirtelRegistroEquipoSatelital/Actualizar',
                                data: {
                                    'RegistroEquipoSatelitalId': $('#txtCodigo').val(),
                                    'CodigoIBPEquipoSatelital': $('#txtCodigoIBPe').val(),
                                    'ModeloBienServicioSubcampoId': $('#cbSubcampoe').val(),
                                    'ModeloBienServicioDenominacionId': $('#cbDenominacione').val(),
                                    'MarcaId': $('#cbMarcae').val(),
                                    'ModeloEquipoSatelital': $('#cbEquipoe').val(),
                                    'AnioAdquisicionSatelital': $('#txtAnioAdquisicione').val(),
                                    'EstadoOperatividadTelefonia': $('#txtEstadoOperatividade').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoe').val(),  
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
                                    $('#tblDirtelRegistroEquipoSatelital').DataTable().ajax.reload();
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

    $('#tblDirtelRegistroEquipoSatelital').DataTable({
        ajax: {
            "url": '/DirtelRegistroEquipoSatelital/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroEquipoSatelitalId" },
            { "data": "codigoIBPEquipoSatelital" },
            { "data": "descModeloBienServicioSubcampo" },
            { "data": "descModeloBienServicioDenominacion" },
            { "data": "descMarca" },
            { "data": "descModeloEquipoSatelital" },
            { "data": "anioAdquisicionEquipoSatelital" },
            { "data": "estadoOperatividadEquipoSatelital" },
            { "data": "descDependencia" },  
            { "data": "descDepartamento" },   
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroEquipoSatelitalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroEquipoSatelitalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirtel - Equipos Satelitales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirtel - Equipos Satelitales',
                title: 'Dirtel - Equipos Satelitales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirtel - Equipos Satelitales',
                title: 'Dirtel - Equipos Satelitales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirtel - Equipos Satelitales',
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
    $.getJSON('/DirtelRegistroEquipoSatelital/Mostrar?Id=' + Id, [], function (RegistroEquipoSatelitalDTO) {
        $('#txtCodigo').val(RegistroEquipoSatelitalDTO.registroEquipoSatelitalId);
        $('#txtCodigoIBPe').val(RegistroEquipoSatelitalDTO.codigoIBPEquipoSatelital);
        $('#cbSubcampoe').val(RegistroEquipoSatelitalDTO.modeloBienServicioSubcampoId);
        $('#cbDenominacione').val(RegistroEquipoSatelitalDTO.modeloBienServicioDenominacionId);
        $('#cbMarcae').val(RegistroEquipoSatelitalDTO.marcaId);
        $('#cbEquipoe').val(RegistroEquipoSatelitalDTO.modeloEquipoSatelital);
        $('#txtAnioAdquisicione').val(RegistroEquipoSatelitalDTO.anioAdquisicionSatelital);
        $('#txtEstadoOperatividade').val(RegistroEquipoSatelitalDTO.estadoOperatividadTelefonia);
        $('#cbDependenciae').val(RegistroEquipoSatelitalDTO.dependenciaId);
        $('#cbDepartamentoe').val(RegistroEquipoSatelitalDTO.departamentoUbigeoId);  
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
                url: '/DirtelRegistroEquipoSatelital/Eliminar',
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
                    $('#tblDirtelRegistroEquipoSatelital').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirtelRegistroEquipoSatelital() {
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
    $.getJSON('/DirtelRegistroEquipoSatelital/cargaCombs', [], function (Json) {
        var modeloBienServicioSubcampo = Json["data1"];
        var modeloBienServicioDenominacion = Json["data2"];
        var marca = Json["data3"];
        var dependencia = Json["data4"];
        var departamentoUbigeo = Json["data5"];
        var modeloEquipoSatelital = Json["data6"];

        $("select#cbMarca").html("");
        $.each(marca, function () {
            var RowContent = '<option value=' + this.marcaId + '>' + this.descMarca + '</option>'
            $("select#cbMarca").append(RowContent);
        });
        $("select#cbMarcae").html("");
        $.each(marca, function () {
            var RowContent = '<option value=' + this.marcaId + '>' + this.descMarca + '</option>'
            $("select#cbMarcae").append(RowContent);
        });

        $("select#cbSubcampo").html("");
        $.each(modeloBienServicioSubcampo, function () {
            var RowContent = '<option value=' + this.modeloBienServicioSubcampoId + '>' + this.descModeloBienServicioSubcampo + '</option>'
            $("select#cbSubcampo").append(RowContent);
        });
        $("select#cbSubcampoe").html("");
        $.each(modeloBienServicioSubcampo, function () {
            var RowContent = '<option value=' + this.modeloBienServicioSubcampoId + '>' + this.descModeloBienServicioSubcampo + '</option>'
            $("select#cbSubcampoe").append(RowContent);
        });

        $("select#cbDenominacion").html("");
        $.each(modeloBienServicioDenominacion, function () {
            var RowContent = '<option value=' + this.modeloBienServicioDenominacionId + '>' + this.descModeloBienServicioDenominacion + '</option>'
            $("select#cbDenominacion").append(RowContent);
        });
        $("select#cbDenominacione").html("");
        $.each(modeloBienServicioDenominacion, function () {
            var RowContent = '<option value=' + this.modeloBienServicioDenominacionId + '>' + this.descModeloBienServicioDenominacion + '</option>'
            $("select#cbDenominacione").append(RowContent);
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

        $("select#cbEquipo").html("");
        $.each(modeloEquipoSatelital, function () {
            var RowContent = '<option value=' + this.modeloEquipoSatelitalId + '>' + this.descModeloEquipoSatelital + '</option>'
            $("select#cbEquipo").append(RowContent);
        });
        $("select#cbEquipoe").html("");
        $.each(modeloEquipoSatelital, function () {
            var RowContent = '<option value=' + this.modeloEquipoSatelitalId + '>' + this.descModeloEquipoSatelital + '</option>'
            $("select#cbEquipoe").append(RowContent);
        }); 
    })
}

