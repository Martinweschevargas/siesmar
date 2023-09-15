var tblComestreServicioMovilidadComestre;

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
                                url: '/ComestreServicioMovilidadComestre/Insertar',
                                data: {
                                    'FechaInicio': $('#txtFechaIni').val(),
                                    'FechaTermino': $('#txtFechaTer').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'ClaseVehiculoId': $('#cbClase').val(),
                                    'MarcaVehiculoId': $('#cbMarca').val(),
                                    'Carroceria': $('#txtCarroceria').val(),
                                    'PlacaRodaje': $('#txtPlaca').val(),
                                    'EstadoOperatividad': $('#txtEstado').val(), 
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
                                    $('#tblComestreServicioMovilidadComestre').DataTable().ajax.reload();
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
                                url: '/ComestreServicioMovilidadComestre/Actualizar',
                                data: {

                                    'ServicioMovilidadComestreId': $('#txtCodigo').val(),
                                    'FechaInicio': $('#txtFechaInie').val(),
                                    'FechaTermino': $('#txtFechaTere').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'ClaseVehiculoId': $('#cbClasee').val(),
                                    'MarcaVehiculoId': $('#cbMarcae').val(),
                                    'Carroceria': $('#txtCarroceriae').val(),
                                    'PlacaRodaje': $('#txtPlacae').val(),
                                    'EstadoOperatividad': $('#txtEstadoe').val(),
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
                                    $('#tblComestreServicioMovilidadComestre').DataTable().ajax.reload();
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

    $('#tblComestreServicioMovilidadComestre').DataTable({
        ajax: {
            "url": '/ComestreServicioMovilidadComestre/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioMovilidadComestreId" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "descDependencia" },
            { "data": "descClaseVehiculo" },
            { "data": "descMarcaVehiculo" },
            { "data": "carroceria" },
            { "data": "placaRodaje" },
            { "data": "estadoOperatividad" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioMovilidadComestreId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioMovilidadComestreId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comestre - Servicio de Apoyo con Movilidades',
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
                filename: 'Comestre - Servicio de Apoyo con Movilidades',
                title: 'Comestre - Servicio de Apoyo con Movilidades',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comestre - Servicio de Apoyo con Movilidades',
                title: 'Comestre - Servicio de Apoyo con Movilidades',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comestre - Servicio de Apoyo con Movilidades',
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
    $.getJSON('/ComestreServicioMovilidadComestre/Mostrar?Id=' + Id, [], function (ServicioMovilidadComestreDTO) {
        $('#txtCodigo').val(ServicioMovilidadComestreDTO.servicioMovilidadComestreId);
        $('#txtFechaInie').val(ServicioMovilidadComestreDTO.fechaInicio);
        $('#txtFechaTere').val(ServicioMovilidadComestreDTO.fechaTermino);
        $('#cbDependenciae').val(ServicioMovilidadComestreDTO.dependenciaId);
        $('#cbClasee').val(ServicioMovilidadComestreDTO.claseVehiculoId);
        $('#cbMarcae').val(ServicioMovilidadComestreDTO.marcaVehiculoId);
        $('#txtCarroceriae').val(ServicioMovilidadComestreDTO.carroceria);
        $('#txtPlacae').val(ServicioMovilidadComestreDTO.placaRodaje);
        $('#txtEstadoe').val(ServicioMovilidadComestreDTO.estadoOperatividad); 
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
                url: '/ComestreServicioMovilidadComestre/Eliminar',
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
                    $('#tblComestreServicioMovilidadComestre').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComestreServicioMovilidadComestre() {
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
    $.getJSON('/ComestreServicioMovilidadComestre/cargaCombs', [], function (Json) {
        var dependencia = Json["data1"];
        var claseVehiculo = Json["data2"];
        var marcaVehiculo = Json["data3"];


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

        $("select#cbClase").html("");
        $.each(claseVehiculo, function () {
            var RowContent = '<option value=' + this.claseVehiculoId + '>' + this.descClaseVehiculo + '</option>'
            $("select#cbClase").append(RowContent);
        });
        $("select#cbClasee").html("");
        $.each(claseVehiculo, function () {
            var RowContent = '<option value=' + this.claseVehiculoId + '>' + this.descClaseVehiculo + '</option>'
            $("select#cbClasee").append(RowContent);
        });

        $("select#cbMarca").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.marcaVehiculoId + '>' + this.descMarcaVehiculo + '</option>'
            $("select#cbMarca").append(RowContent);
        });
        $("select#cbMarcae").html("");
        $.each(marcaVehiculo, function () {
            var RowContent = '<option value=' + this.marcaVehiculoId + '>' + this.descMarcaVehiculo + '</option>'
            $("select#cbMarcae").append(RowContent);
        });
    }) 
}

