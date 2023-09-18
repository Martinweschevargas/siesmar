var tblDirtelRegistroEquipoComunicacionEnlace;

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
                                url: '/DirtelRegistroEquipoComunicacionEnlace/Insertar',
                                data: {
                                    'CodigoIBPEquipoEnlace': $('#txtCodigoIBP').val(),
                                    'MarcaId': $('#cbMarca').val(),
                                    'ModeloEquipoEnlace': $('#txtModelo').val(),
                                    'ModoEquipoEnlace': $('#txtModo').val(),
                                    'NumeroCanalEquipo': $('#txtCanal').val(),
                                    'AnchoBanda': $('#txtBanda').val(),
                                    'TipoEquipoComunicacionEnlace': $('#txtEnlace').val(),
                                    'EstadoOperatividadEnlace': $('#txtEstado').val(),
                                    'AnioAdquisicion': $('#txtAdquisicion').val(),
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
                                    $('#tblDirtelRegistroEquipoComunicacionEnlace').DataTable().ajax.reload();
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
                                url: '/DirtelRegistroEquipoComunicacionEnlace/Actualizar',
                                data: {
                                    'RegistroEquipoComunicacionEnlaceId': $('#txtCodigo').val(),
                                    'CodigoIBPEquipoEnlace': $('#txtCodigoIBPe').val(),
                                    'MarcaId': $('#cbMarcae').val(),
                                    'ModeloEquipoEnlace': $('#txtModeloe').val(),
                                    'ModoEquipoEnlace': $('#txtModoe').val(),
                                    'NumeroCanalEquipo': $('#txtCanale').val(),
                                    'AnchoBanda': $('#txtBandae').val(),
                                    'TipoEquipoComunicacionEnlace': $('#txtEnlacee').val(),
                                    'EstadoOperatividadEnlace': $('#txtEstadoe').val(),
                                    'AnioAdquisicion': $('#txtAdquisicione').val(),
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
                                    $('#tblDirtelRegistroEquipoComunicacionEnlace').DataTable().ajax.reload();
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

    $('#tblDirtelRegistroEquipoComunicacionEnlace').DataTable({
        ajax: {
            "url": '/DirtelRegistroEquipoComunicacionEnlace/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroEquipoComunicacionEnlaceId" },
            { "data": "codigoIBPEquipoEnlace" },
            { "data": "descMarca" },
            { "data": "modeloEquipoEnlace" },
            { "data": "modoEquipoEnlace" },
            { "data": "numeroCanalEquipo" },
            { "data": "anchoBanda" },
            { "data": "tipoEquipoComunicacionEnlace" },
            { "data": "estadoOperatividadEnlace" }, 
            { "data": "anioAdquisicion" },  
            { "data": "descDependencia" },  
            { "data": "descDepartamento" },   
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroEquipoComunicacionEnlaceId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroEquipoComunicacionEnlaceId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirtel - Equipos de Comunicacion de Enlaces',
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
                filename: 'Dirtel - Equipos de Comunicacion de Enlaces',
                title: 'Dirtel - Equipos de Comunicacion de Enlaces',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirtel - Equipos de Comunicacion de Enlaces',
                title: 'Dirtel - Equipos de Comunicacion de Enlaces',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirtel - Equipos de Comunicacion de Enlaces',
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
    $.getJSON('/DirtelRegistroEquipoComunicacionEnlace/Mostrar?Id=' + Id, [], function (RegistroEquipoComunicacionEnlaceDTO) {
        $('#txtCodigo').val(RegistroEquipoComunicacionEnlaceDTO.registroEquipoComunicacionEnlaceId);
        $('#txtCodigoIBPe').val(RegistroEquipoComunicacionEnlaceDTO.codigoIBPEquipoEnlace);
        $('#cbMarcae').val(RegistroEquipoComunicacionEnlaceDTO.marcaId);
        $('#txtModeloe').val(RegistroEquipoComunicacionEnlaceDTO.modeloEquipoEnlace);
        $('#txtModoe').val(RegistroEquipoComunicacionEnlaceDTO.modoEquipoEnlace);
        $('#txtCanale').val(RegistroEquipoComunicacionEnlaceDTO.numeroCanalEquipo);
        $('#txtBandae').val(RegistroEquipoComunicacionEnlaceDTO.anchoBanda);
        $('#txtEnlacee').val(RegistroEquipoComunicacionEnlaceDTO.tipoEquipoComunicacionEnlace);
        $('#txtEstadoe').val(RegistroEquipoComunicacionEnlaceDTO.estadoOperatividadEnlace);
        $('#txtAdquisicione').val(RegistroEquipoComunicacionEnlaceDTO.anioAdquisicion);
        $('#cbDependenciae').val(RegistroEquipoComunicacionEnlaceDTO.dependenciaId);
        $('#cbDepartamentoe').val(RegistroEquipoComunicacionEnlaceDTO.departamentoUbigeoId);   
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
                url: '/DirtelRegistroEquipoComunicacionEnlace/Eliminar',
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
                    $('#tblDirtelRegistroEquipoComunicacionEnlace').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirtelRegistroEquipoComunicacionEnlace() {
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
    $.getJSON('/DirtelRegistroEquipoComunicacionEnlace/cargaCombs', [], function (Json) {
        var marca = Json["data1"];
        var dependencia = Json["data2"];
        var departamentoUbigeo = Json["data3"];

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
    })
}

