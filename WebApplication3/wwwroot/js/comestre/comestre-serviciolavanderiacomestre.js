var tblComestreServicioLavanderiaComestre;

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
                                url: '/ComestreServicioLavanderiaComestre/Insertar',
                                data: {
                                    'FechaIngreso': $('#txtFechaIngre').val(),
                                    'FechaRecojo': $('#txtFechaReco').val(),
                                    'CIP': $('#txtCIP').val(),
                                    'GradoPersonalMilitarId': $('#cbGrado').val(),
                                    'EspecialidadGenericaPersonalId': $('#cbEspecialidad').val(),
                                    'SexoPersonal': $('#txtSexo').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'NumeroPrenda': $('#txtPrendas').val(),
                                    'ServicioLavanderiaId': $('#cbServicio').val(), 
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
                                    $('#tblComestreServicioLavanderiaComestre').DataTable().ajax.reload();
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
                                url: '/ComestreServicioLavanderiaComestre/Actualizar',
                                data: {

                                    'ServicioLavanderiaComestreId': $('#txtCodigo').val(),
                                    'FechaIngreso': $('#txtFechaIngree').val(),
                                    'FechaRecojo': $('#txtFechaRecoe').val(),
                                    'CIP': $('#txtCIPe').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoe').val(),
                                    'EspecialidadGenericaPersonalId': $('#cbEspecialidade').val(),
                                    'SexoPersonal': $('#txtSexoe').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'NumeroPrenda': $('#txtPrendase').val(),
                                    'ServicioLavanderiaId': $('#cbServicioe').val(), 
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
                                    $('#tblComestreServicioLavanderiaComestre').DataTable().ajax.reload();
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

    $('#tblComestreServicioLavanderiaComestre').DataTable({
        ajax: {
            "url": '/ComestreServicioLavanderiaComestre/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioLavanderiaComestreId" },
            { "data": "fechaIngreso" },
            { "data": "fechaRecojo" },
            { "data": "cIP" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "sexoPersonal" },
            { "data": "descDependencia" },
            { "data": "numeroPrenda" },
            { "data": "descServicioLavanderia" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioLavanderiaComestreId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioLavanderiaComestreId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comestre - Servicio de Lavanderia',
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
                filename: 'Comestre - Servicio de Lavanderia',
                title: 'Comestre - Servicio de Lavanderia',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comestre - Servicio de Lavanderia',
                title: 'Comestre - Servicio de Lavanderia',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comestre - Servicio de Lavanderia',
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
    $.getJSON('/ComestreServicioLavanderiaComestre/Mostrar?Id=' + Id, [], function (ServicioLavanderiaComestreDTO) {
        $('#txtCodigo').val(ServicioLavanderiaComestreDTO.servicioLavanderiaComestreId);
        $('#txtFechaIngree').val(ServicioLavanderiaComestreDTO.fechaIngreso);
        $('#txtFechaRecoe').val(ServicioLavanderiaComestreDTO.fechaRecojo);
        $('#txtCIPe').val(ServicioLavanderiaComestreDTO.cIP);
        $('#cbGradoe').val(ServicioLavanderiaComestreDTO.gradoPersonalMilitarId);
        $('#cbEspecialidade').val(ServicioLavanderiaComestreDTO.especialidadGenericaPersonalId);
        $('#txtSexoe').val(ServicioLavanderiaComestreDTO.sexoPersonal);
        $('#cbDependenciae').val(ServicioLavanderiaComestreDTO.dependenciaId);
        $('#txtPrendase').val(ServicioLavanderiaComestreDTO.numeroPrenda);
        $('#cbServicioe').val(ServicioLavanderiaComestreDTO.servicioLavanderiaId); 
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
                url: '/ComestreServicioLavanderiaComestre/Eliminar',
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
                    $('#tblComestreServicioLavanderiaComestre').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComestreServicioLavanderiaComestre() {
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
    $.getJSON('/ComestreServicioLavanderiaComestre/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var especialidadGenericaPersonal = Json["data2"];
        var dependencia = Json["data3"];
        var servicioLavanderia = Json["data4"];


        $("select#cbEspecialidad").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidad").append(RowContent);
        });
        $("select#cbEspecialidade").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidade").append(RowContent);
        });

        $("select#cbGrado").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGrado").append(RowContent);
        });
        $("select#cbGradoe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoe").append(RowContent);
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

        $("select#cbServicio").html("");
        $.each(servicioLavanderia, function () {
            var RowContent = '<option value=' + this.servicioLavanderiaId + '>' + this.descServicioLavanderia + '</option>'
            $("select#cbServicio").append(RowContent);
        });
        $("select#cbServicioe").html("");
        $.each(servicioLavanderia, function () {
            var RowContent = '<option value=' + this.servicioLavanderiaId + '>' + this.descServicioLavanderia + '</option>'
            $("select#cbServicioe").append(RowContent);
        });
    }) 
}

