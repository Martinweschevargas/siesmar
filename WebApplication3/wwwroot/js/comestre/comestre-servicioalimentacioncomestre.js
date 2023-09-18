var tblComestreServicioAlimentacionComestre;

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
                                url: '/ComestreServicioAlimentacionComestre/Insertar',
                                data: {
                                    'NumeroRacion': $('#txtRacion').val(),
                                    'MesId': $('#cbMes').val(),
                                    'PeriodoDias': $('#txtPeriodo').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'CantidadPersupe': $('#txtPersube').val(),
                                    'CantidadPersuba': $('#txtPersuba').val(),
                                    'CantidadPermar': $('#txtPermar').val(),
                                    'Vacacion': $('#txtVacacion').val(),
                                    'TotalPersonalDiaHabil': $('#txtHabiles').val(),
                                    'TotalPersonalDiaNoHabil': $('#txtNoHabiles').val(),
                                    'DiaHabil': $('#txtDiaHabi').val(),
                                    'DiaNoHabil': $('#txtDiaNoHabi').val(),
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
                                    $('#tblComestreServicioAlimentacionComestre').DataTable().ajax.reload();
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
                                url: '/ComestreServicioAlimentacionComestre/Actualizar',
                                data: {

                                    'ServicioAlimentacionComestreId': $('#txtCodigo').val(),
                                    'NumeroRacion': $('#txtRacione').val(),
                                    'MesId': $('#cbMese').val(),
                                    'PeriodoDias': $('#txtPeriodoe').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'CantidadPersupe': $('#txtPersubee').val(),
                                    'CantidadPersuba': $('#txtPersubae').val(),
                                    'CantidadPermar': $('#txtPermare').val(),
                                    'Vacacion': $('#txtVacacione').val(),
                                    'TotalPersonalDiaHabil': $('#txtHabilese').val(),
                                    'TotalPersonalDiaNoHabil': $('#txtNoHabilese').val(),
                                    'DiaHabil': $('#txtDiaHabie').val(),
                                    'DiaNoHabil': $('#txtDiaNoHabie').val(),
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
                                    $('#tblComestreServicioAlimentacionComestre').DataTable().ajax.reload();
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

    $('#tblComestreServicioAlimentacionComestre').DataTable({
        ajax: {
            "url": '/ComestreServicioAlimentacionComestre/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioAlimentacionComestreId" },
            { "data": "numeroRacion" },
            { "data": "descMes" },
            { "data": "periodoDias" },
            { "data": "descDependencia" },
            { "data": "cantidadPersupe" },
            { "data": "cantidadPersuba" },
            { "data": "cantidadPermar" },
            { "data": "vacacion" },
            { "data": "totalPersonalDiaHabil" },
            { "data": "totalPersonalDiaNoHabil" },
            { "data": "diaHabil" },
            { "data": "diaNoHabil" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioAlimentacionComestreId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioAlimentacionComestreId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comestre - Servicio de Alimentacion',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comestre - Servicio de Alimentacion',
                title: 'Comestre - Servicio de Alimentacion',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comestre - Servicio de Alimentacion',
                title: 'Comestre - Servicio de Alimentacion',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comestre - Servicio de Alimentacion',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12]
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
    $.getJSON('/ComestreServicioAlimentacionComestre/Mostrar?Id=' + Id, [], function (ServicioAlimentacionComestreDTO) {
        $('#txtCodigo').val(ServicioAlimentacionComestreDTO.servicioAlimentacionComestreId);
        $('#txtRacione').val(ServicioAlimentacionComestreDTO.numeroRacion);
        $('#cbMese').val(ServicioAlimentacionComestreDTO.mesId);
        $('#txtPeriodoe').val(ServicioAlimentacionComestreDTO.periodoDias);
        $('#cbDependenciae').val(ServicioAlimentacionComestreDTO.dependenciaId);
        $('#txtPersubee').val(ServicioAlimentacionComestreDTO.cantidadPersupe);
        $('#txtPersubae').val(ServicioAlimentacionComestreDTO.cantidadPersuba);
        $('#txtPermare').val(ServicioAlimentacionComestreDTO.cantidadPermar);
        $('#txtVacacione').val(ServicioAlimentacionComestreDTO.vacacion);
        $('#txtHabilese').val(ServicioAlimentacionComestreDTO.totalPersonalDiaHabil);
        $('#txtNoHabilese').val(ServicioAlimentacionComestreDTO.totalPersonalDiaNoHabil);
        $('#txtDiaHabie').val(ServicioAlimentacionComestreDTO.diaHabil);
        $('#txtDiaNoHabie').val(ServicioAlimentacionComestreDTO.diaNoHabil);  
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
                url: '/ComestreServicioAlimentacionComestre/Eliminar',
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
                    $('#tblComestreServicioAlimentacionComestre').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComestreServicioAlimentacionComestre() {
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
    $.getJSON('/ComestreServicioAlimentacionComestre/cargaCombs', [], function (Json) {
        var mes = Json["data1"];
        var dependencia = Json["data2"];

        $("select#cbMes").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
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

    }) 
}

