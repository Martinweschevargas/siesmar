var tblComesnapiServicioLavanderiaComesnapi;

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
                                url: '/ComesnapiServicioLavanderiaComesnapi/Insertar',
                                data: {
                                    'FechaIngreso': $('#txtFechaIngreso').val(),
                                    'FechaRecojo': $('#txtFechaRecojo').val(),
                                    'CIP': $('#txtCIP').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericaPersonal').val(),
                                    'SexoPersonal': $('#txtSexoPersonal').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'NumeroPrenda': $('#txtNumeroPrenda').val(),
                                    'CodigoServicioLavanderia': $('#cbServicioLavanderia').val(), 
                                    'CargaId': $('#cargasR').val()
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
                                    $('#tblComesnapiServicioLavanderiaComesnapi').DataTable().ajax.reload();
                                    $('.needs-validation :input').val('');
                                    $(".needs-validation").find("select").prop("selectedIndex", 0);
                                    form.classList.remove('was-validated')
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
                                url: '/ComesnapiServicioLavanderiaComesnapi/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaIngreso': $('#txtFechaIngresoe').val(),
                                    'FechaRecojo': $('#txtFechaRecojoe').val(),
                                    'CIP': $('#txtCIPe').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericaPersonale').val(),
                                    'SexoPersonal': $('#txtSexoPersonale').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'NumeroPrenda': $('#txtNumeroPrendae').val(),
                                    'CodigoServicioLavanderia': $('#cbServicioLavanderiae').val(), 
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
                                    $('#tblComesnapiServicioLavanderiaComesnapi').DataTable().ajax.reload();
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

   tblComesnapiServicioLavanderiaComesnapi = $('#tblComesnapiServicioLavanderiaComesnapi').DataTable({
        ajax: {
            "url": '/ComesnapiServicioLavanderiaComesnapi/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioLavanderiaComesnapiId" },
            { "data": "fechaIngreso" },
            { "data": "fechaRecojo" },
            { "data": "cip" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "sexoPersonal" },
            { "data": "nombreDependencia" },
            { "data": "numeroPrenda" },
            { "data": "descServicioLavanderia" }, 
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioLavanderiaComesnapiId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioLavanderiaComesnapiId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comesnapi - Servicios de lavandería',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7 ,8 ,9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comesnapi - Servicios de lavandería',
                title: 'Comesnapi - Servicios de lavandería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comesnapi - Servicios de lavandería',
                title: 'Comesnapi - Servicios de lavandería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comesnapi - Servicios de lavandería',
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
    $.getJSON('/ComesnapiServicioLavanderiaComesnapi/Mostrar?Id=' + Id, [], function (ServicioLavanderiaComesnapiDTO) {
        $('#txtCodigo').val(ServicioLavanderiaComesnapiDTO.servicioLavanderiaComesnapiId);
        $('#txtFechaIngresoe').val(ServicioLavanderiaComesnapiDTO.fechaIngreso);
        $('#txtFechaRecojoe').val(ServicioLavanderiaComesnapiDTO.fechaRecojo);
        $('#txtCIPe').val(ServicioLavanderiaComesnapiDTO.cip);
        $('#cbGradoPersonalMilitare').val(ServicioLavanderiaComesnapiDTO.codigoGradoPersonalMilitar);
        $('#cbEspecialidadGenericaPersonale').val(ServicioLavanderiaComesnapiDTO.codigoEspecialidadGenericaPersonal);
        $('#txtSexoPersonale').val(ServicioLavanderiaComesnapiDTO.sexoPersonal);
        $('#cbDependenciae').val(ServicioLavanderiaComesnapiDTO.codigoDependencia);
        $('#txtNumeroPrendae').val(ServicioLavanderiaComesnapiDTO.numeroPrenda);
        $('#cbServicioLavanderiae').val(ServicioLavanderiaComesnapiDTO.codigoServicioLavanderia);
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
                url: '/ComesnapiServicioLavanderiaComesnapi/Eliminar',
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
                    $('#tblComesnapiServicioLavanderiaComesnapi').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComesnapiServicioLavanderiaComesnapi() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComesnapiServicioLavanderiaComesnapi/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            console.log(dataJson);
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.fechaIngreso),
                            $("<td>").text(item.fechaRecojo),
                            $("<td>").text(item.cip),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.sexoPersonal),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.numeroPrenda),
                            $("<td>").text(item.codigoServicioLavanderia)
                        )
                    )
                })
                Swal.fire(
                    'Cargado!',
                    'Vista previa con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema.',
                    'error'
                )
            }
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("ComesnapiServicioLavanderiaComesnapi/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((mensaje) => {
            if (mensaje == "1") {
                Swal.fire(
                    'Cargado!',
                    'Se Cargo el archivo con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema.',
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/ComesnapiServicioLavanderiaComesnapi/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var especialidadGenericaPersonal = Json["data2"];
        var dependencia = Json["data3"];
        var servicioLavanderia = Json["data4"];
        var listaCargas = Json["data5"];


        $("select#cbGradoPersonalMilitar").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
        });
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });


        $("select#cbEspecialidadGenericaPersonal").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonal").append(RowContent);
        });
        $("select#cbEspecialidadGenericaPersonale").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonale").append(RowContent);
        });


        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbServicioLavanderia").html("");
        $.each(servicioLavanderia, function () {
            var RowContent = '<option value=' + this.codigoServicioLavanderia + '>' + this.descServicioLavanderia + '</option>'
            $("select#cbServicioLavanderia").append(RowContent);
        });
        $("select#cbServicioLavanderiae").html("");
        $.each(servicioLavanderia, function () {
            var RowContent = '<option value=' + this.codigoServicioLavanderia + '>' + this.descServicioLavanderia + '</option>'
            $("select#cbServicioLavanderiae").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    });
}

