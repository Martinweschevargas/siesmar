var tblComestreEvaluacionAlistamientoPersonalComestre;

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
                                url: '/ComestreEvaluacionAlistamientoPersonalComestre/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidad').val(),
                                    'FechaEvaluacion': $('#txtFecha').val(),
                                    'DNIPersonal': $('#txtDNI').val(),
                                    'CIPPersonal': $('#txtCIP').val(),
                                    'CargoPersonal': $('#txtCargo').val(),
                                    'GradoPersonalMilitarEsperado': $('#cbGradoEsperado').val(),
                                    'EspecialidadGenericaPersonalEsperado': $('#cbEspecialidadEsperado').val(),
                                    'GradoPersonalMilitarActual': $('#cbGradoActual').val(),
                                    'EspecialidadGenericaPersonalActual': $('#cbEspecialidadActual').val(),
                                    'GradoJerarquico': $('#txtJerarquico').val(),
                                    'ServicioExperiencia': $('#txtServicio').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacion').val(),
                                    'CursoProfesionalRequerido': $('#txtVigencia').val(),
                                    'TotalPuntaje': $('#txtPuntaje').val(), 
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
                                    $('#tblComestreEvaluacionAlistamientoPersonalComestre').DataTable().ajax.reload();
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
                                url: '/ComestreEvaluacionAlistamientoPersonalComestre/Actualizar',
                                data: {

                                    'EvaluacionAlistamientoPersonalComestreId': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidade').val(),
                                    'FechaEvaluacion': $('#txtFechae').val(),
                                    'DNIPersonal': $('#txtDNIe').val(),
                                    'CIPPersonal': $('#txtCIPe').val(),
                                    'CargoPersonal': $('#txtCargoe').val(),
                                    'GradoPersonalMilitarEsperado': $('#cbGradoEsperadoe').val(),
                                    'EspecialidadGenericaPersonalEsperado': $('#cbEspecialidadEsperadoe').val(),
                                    'GradoPersonalMilitarActual': $('#cbGradoActuale').val(),
                                    'EspecialidadGenericaPersonalActual': $('#cbEspecialidadActuale').val(),
                                    'GradoJerarquico': $('#txtJerarquicoe').val(),
                                    'ServicioExperiencia': $('#txtServicioe').val(),
                                    'EspecializacionProfesional': $('#txtEspecializacione').val(),
                                    'CursoProfesionalRequerido': $('#txtVigenciae').val(),
                                    'TotalPuntaje': $('#txtPuntajee').val(),  
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
                                    $('#tblComestreEvaluacionAlistamientoPersonalComestre').DataTable().ajax.reload();
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

    $('#tblComestreEvaluacionAlistamientoPersonalComestre').DataTable({
        ajax: {
            "url": '/ComestreEvaluacionAlistamientoPersonalComestre/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionAlistamientoPersonalComestreId" },
            { "data": "descUnidadNaval" },
            { "data": "fechaEvaluacion" },
            { "data": "dNIPersonal" },
            { "data": "cIPPersonal" },
            { "data": "cargoPersonal" },
            { "data": "descGradoEsperado" },
            { "data": "descEspecialidadGenericaPersonalEsperado" },
            { "data": "descGradoActual" },
            { "data": "descEspecialidadGenericaPersonalActual" },
            { "data": "gradoJerarquico" },
            { "data": "servicioExperiencia" },
            { "data": "especializacionProfesional" },
            { "data": "cursoProfesionalRequerido" },
            { "data": "totalPuntaje" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionAlistamientoPersonalComestreId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionAlistamientoPersonalComestreId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comestre - Evaluacion del Alistamiento del Personal',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comestre - Evaluacion de Alistamiento del Personal',
                title: 'Comestre - Evaluacion de Alistamiento del Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comestre - Evaluacion de Alistamiento del Personal',
                title: 'Comestre - Evaluacion de Alistamiento del Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comestre - Evaluacion de Alistamiento del Personal',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
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
    $.getJSON('/ComestreEvaluacionAlistamientoPersonalComestre/Mostrar?Id=' + Id, [], function (EvaluacionAlistamientoPersonalComestreDTO) {
        $('#txtCodigo').val(EvaluacionAlistamientoPersonalComestreDTO.evaluacionAlistamientoPersonalComestreId);
        $('#cbUnidade').val(EvaluacionAlistamientoPersonalComestreDTO.unidadNavalId);
        $('#txtFechae').val(EvaluacionAlistamientoPersonalComestreDTO.fechaEvaluacion);
        $('#txtDNIe').val(EvaluacionAlistamientoPersonalComestreDTO.dNIPersonal);
        $('#txtCIPe').val(EvaluacionAlistamientoPersonalComestreDTO.cIPPersonal);
        $('#txtCargoe').val(EvaluacionAlistamientoPersonalComestreDTO.cargoPersonal);
        $('#cbGradoEsperadoe').val(EvaluacionAlistamientoPersonalComestreDTO.gradoPersonalMilitarEsperado);
        $('#cbEspecialidadEsperadoe').val(EvaluacionAlistamientoPersonalComestreDTO.especialidadGenericaPersonalEsperado);
        $('#cbGradoActuale').val(EvaluacionAlistamientoPersonalComestreDTO.gradoPersonalMilitarActual);
        $('#cbEspecialidadActuale').val(EvaluacionAlistamientoPersonalComestreDTO.especialidadGenericaPersonalActual);
        $('#txtJerarquicoe').val(EvaluacionAlistamientoPersonalComestreDTO.gradoJerarquico);
        $('#txtServicioe').val(EvaluacionAlistamientoPersonalComestreDTO.servicioExperiencia);
        $('#txtEspecializacione').val(EvaluacionAlistamientoPersonalComestreDTO.especializacionProfesional);
        $('#txtVigenciae').val(EvaluacionAlistamientoPersonalComestreDTO.cursoProfesionalRequerido);
        $('#txtPuntajee').val(EvaluacionAlistamientoPersonalComestreDTO.totalPuntaje); 
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
                url: '/ComestreEvaluacionAlistamientoPersonalComestre/Eliminar',
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
                    $('#tblComestreEvaluacionAlistamientoPersonalComestre').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComestreEvaluacionAlistamientoPersonalComestre() {
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
    $.getJSON('/ComestreEvaluacionAlistamientoPersonalComestre/cargaCombs', [], function (Json) {

        var unidadNaval = Json["data1"];
        var gradoPersonalMilitarEsperado = Json["data2"];
        var especialidadGenericaPersonalEsperado = Json["data3"];
        var gradoPersonalMilitarActual = Json["data4"];
        var especialidadGenericaPersonalActual = Json["data5"];

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

        $("select#cbGradoEsperado").html("");
        $.each(gradoPersonalMilitarEsperado, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoEsperado").append(RowContent);
        });
        $("select#cbGradoEsperadoe").html("");
        $.each(gradoPersonalMilitarEsperado, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoEsperadoe").append(RowContent);
        });

        $("select#cbEspecialidadEsperado").html("");
        $.each(especialidadGenericaPersonalEsperado, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadEsperado").append(RowContent);
        });
        $("select#cbEspecialidadEsperadoe").html("");
        $.each(especialidadGenericaPersonalEsperado, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadEsperadoe").append(RowContent);
        });

        $("select#cbGradoActual").html("");
        $.each(gradoPersonalMilitarActual, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoActual").append(RowContent);
        });
        $("select#cbGradoActuale").html("");
        $.each(gradoPersonalMilitarActual, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoActuale").append(RowContent);
        });

        $("select#cbEspecialidadActual").html("");
        $.each(especialidadGenericaPersonalActual, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadActual").append(RowContent);
        });
        $("select#cbEspecialidadActuale").html("");
        $.each(especialidadGenericaPersonalActual, function () {
            var RowContent = '<option value=' + this.especialidadGenericaPersonalId + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadActuale").append(RowContent);
        });
    }) 
}

