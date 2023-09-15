var tblComoperpacEfectivoAccionMilitar;
var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

$('select#cbProvincia').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');

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
                                url: '/ComoperpacEfectivoAccionMilitar/Insertar',
                                data: {
                                    'ComandanciaNavalId': $('#cbComandanciaNaval').val(),
                                    'DistritoUbigeoId': $('#cbDistrito').val(),
                                    'UnidadParticipante': $('#txtUnidadParticipante').val(),
                                    'GradoPersonalId': $('#cbGradoPersonal').val(),
                                    'ObservacionesEfectivoAccionMilitar': $('#txtObservaciones').val(), 
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
                                    $('#tblComoperpacEfectivoAccionMilitar').DataTable().ajax.reload();
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
                                url: '/ComoperpacEfectivoAccionMilitar/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'ComandanciaNavalId': $('#cbComandanciaNavale').val(),
                                    'DistritoUbigeoId': $('#cbDistritoe').val(),
                                    'UnidadParticipante': $('#txtUnidadParticipantee').val(),
                                    'GradoPersonalId': $('#cbGradoPersonale').val(),
                                    'ObservacionesEfectivoAccionMilitar': $('#txtObservacionese').val(), 
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
                                    $('#tblComoperpacEfectivoAccionMilitar').DataTable().ajax.reload();
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

    $('#tblComoperpacEfectivoAccionMilitar').DataTable({
        ajax: {
            "url": '/ComoperpacEfectivoAccionMilitar/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "efectivoAccionMilitarId" },
            { "data": "descComandanciaNaval" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDistrito" },
            { "data": "unidadParticipante" },
            { "data": "descGradoPersonal" },
            { "data": "observacionesEfectivoAccionMilitar" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.efectivoAccionMilitarId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.efectivoAccionMilitarId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperpac - Efectivos que Participan en Acciones Militares',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperpac - Efectivos que Participan en Acciones Militares',
                title: 'Comoperpac - Efectivos que Participan en Acciones Militares',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperpac - Efectivos que Participan en Acciones Militares',
                title: 'Comoperpac - Efectivos que Participan en Acciones Militares',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperpac - Efectivos que Participan en Acciones Militares',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    $.getJSON('/ComoperpacEfectivoAccionMilitar/Mostrar?Id=' + Id, [], function (EfectivoAccionMilitarDTO) {
        $('#txtCodigo').val(EfectivoAccionMilitarDTO.efectivoAccionMilitarId);
        $('#cbComandanciaNavale').val(EfectivoAccionMilitarDTO.comandanciaNavalId);
        $('#cbDepartamentoe').val(EfectivoAccionMilitarDTO.departamentoUbigeoId);
        $('#cbProvinciae').val(EfectivoAccionMilitarDTO.provinciaUbigeoId);
        $('#cbDistritoe').val(EfectivoAccionMilitarDTO.distritoUbigeoId);
        $('#txtUnidadParticipantee').val(EfectivoAccionMilitarDTO.unidadParticipante);
        $('#cbGradoPersonale').val(EfectivoAccionMilitarDTO.gradoPersonalId);
        $('#txtObservacionese').val(EfectivoAccionMilitarDTO.observacionesEfectivoAccionMilitar); 
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
                url: '/ComoperpacEfectivoAccionMilitar/Eliminar',
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
                    $('#tblComoperpacEfectivoAccionMilitar').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperpacEfectivoAccionMilitar() {
    $('#listar').hide();
    $('#nuevo').show();
}




function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("ComoperpacEfectivoAccionMilitar/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.comandanciaNavalId),
                        $("<td>").text(item.distritoUbigeoId),
                        $("<td>").text(item.unidadParticipante),
                        $("<td>").text(item.gradoPersonalId),
                        $("<td>").text(item.observacionesEfectivoAccionMilitar),
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("ComoperpacEfectivoAccionMilitar/EnviarDatos", {
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
    $.getJSON('/ComoperpacEfectivoAccionMilitar/cargaCombs', [], function (Json) {
        var comandanciaNaval = Json["data1"];
        departamentoUbigeo = Json["data2"];
        provinciaUbigeo = Json["data3"];
        distritoUbigeo = Json["data4"];
        var gradoPersonal = Json["data5"];

        $("select#cbComandanciaNaval").html("");
        $.each(comandanciaNaval, function () {
            var RowContent = '<option value=' + this.comandanciaNavalId + '>' + this.descComandanciaNaval + '</option>'
            $("select#cbComandanciaNaval").append(RowContent);
        });
        $("select#cbComandanciaNavale").html("");
        $.each(comandanciaNaval, function () {
            var RowContent = '<option value=' + this.comandanciaNavalId + '>' + this.descComandanciaNaval + '</option>'
            $("select#cbComandanciaNavale").append(RowContent);
        });


        $("select#cbDepartamento").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamento").append(RowContent);
        });

        $("select#cbDepartamentoe").html("");
        $('select#cbDepartamento').append('<option selected disabled>Seleccionar Departamento</option>');

        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoe").append(RowContent);
        });

        $("select#cbProvinciae").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciae").append(RowContent);

        });

        $("select#cbDistritoe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoe").append(RowContent);

        });


        $("select#cbGradoPersonal").html("");
        $.each(gradoPersonal, function () {
            var RowContent = '<option value=' + this.gradoPersonalId + '>' + this.descGradoPersonal + '</option>'
            $("select#cbGradoPersonal").append(RowContent);
        });
        $("select#cbGradoPersonale").html("");
        $.each(gradoPersonal, function () {
            var RowContent = '<option value=' + this.gradoPersonalId + '>' + this.descGradoPersonal + '</option>'
            $("select#cbGradoPersonale").append(RowContent);
        });
  
    });
}



$('select#cbDepartamento').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeoId == codigo) {
            $("select#cbProvincia").html("");
            $('select#cbProvincia').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvincia").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistrito").html("");
    $('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvincia').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistrito").html("");
            $('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("select#cbDistrito").append(RowContent);
                }
            });
        }
    });
});




$('select#cbDepartamentoe').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeoId == codigo) {
            $("select#cbProvinciae").html("");
            $('select#cbProvinciae').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciae").append(RowContent);
                }
            });
        }
    });
});

$('select#cbProvinciae').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistritoe").html("");
            $('select#cbDistritoe').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoe").append(RowContent);
                }
            });
        }
    });
});


