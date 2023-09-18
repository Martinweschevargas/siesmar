var tblComoperpacEvacuadoTiempoPaz;
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
                                url: '/ComoperpacEvacuadoTiempoPaz/Insertar',
                                data: {
                                    'ZonaNavalId': $('#cbZonaNaval').val(),
                                    'DistritoUbigeoId': $('#cbDistrito').val(),
                                    'GradoPersonalId': $('#cbGradoPersonal').val(),
                                    'TipoBajaId': $('#cbTipoBaja').val(),
                                    'MotivoEvacuadoTiempoPaz': $('#txtMotivoEvacuadoTiempoPaz').val(), 
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
                                    $('#tblComoperpacEvacuadoTiempoPaz').DataTable().ajax.reload();
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
                                url: '/ComoperpacEvacuadoTiempoPaz/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'ZonaNavalId': $('#cbZonaNavale').val(),
                                    'DistritoUbigeoId': $('#cbDistritoe').val(),
                                    'GradoPersonalId': $('#cbGradoPersonale').val(),
                                    'TipoBajaId': $('#cbTipoBajae').val(),
                                    'MotivoEvacuadoTiempoPaz': $('#txtMotivoEvacuadoTiempoPaze').val(), 
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
                                    $('#tblComoperpacEvacuadoTiempoPaz').DataTable().ajax.reload();
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

    $('#tblComoperpacEvacuadoTiempoPaz').DataTable({
        ajax: {
            "url": '/ComoperpacEvacuadoTiempoPaz/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evacuadoTiempoPazId" },
            { "data": "descZonaNaval" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDistrito" },
            { "data": "descGradoPersonal" },
            { "data": "descTipoBaja" },
            { "data": "motivoEvacuadoTiempoPaz" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evacuadoTiempoPazId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evacuadoTiempoPazId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperpac - Evacuados en Tiempo de Paz',
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
                filename: 'Comoperpac - Evacuados en Tiempo de Paz',
                title: 'Comoperpac - Evacuados en Tiempo de Paz',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperpac - Evacuados en Tiempo de Paz',
                title: 'Comoperpac - Evacuados en Tiempo de Paz',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperpac - Evacuados en Tiempo de Paz',
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
    $.getJSON('/ComoperpacEvacuadoTiempoPaz/Mostrar?Id=' + Id, [], function (EvacuadoTiempoPazDTO) {
        $('#txtCodigo').val(EvacuadoTiempoPazDTO.evacuadoTiempoPazId);
        $('#cbZonaNavale').val(EvacuadoTiempoPazDTO.zonaNavalId);
        $('#cbDepartamentoe').val(EvacuadoTiempoPazDTO.departamentoUbigeoId);
        $('#cbProvinciae').val(EvacuadoTiempoPazDTO.provinciaUbigeoId);
        $('#cbDistritoe').val(EvacuadoTiempoPazDTO.distritoUbigeoId);
        $('#cbGradoPersonale').val(EvacuadoTiempoPazDTO.gradoPersonalId);
        $('#cbTipoBajae').val(EvacuadoTiempoPazDTO.tipoBajaId);
        $('#txtMotivoEvacuadoTiempoPaze').val(EvacuadoTiempoPazDTO.motivoEvacuadoTiempoPaz); 
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
                url: '/ComoperpacEvacuadoTiempoPaz/Eliminar',
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
                    $('#tblComoperpacEvacuadoTiempoPaz').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperpacEvacuadoTiempoPaz() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("ComoperpacEvacuadoTiempoPaz/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.zonaNavalId),
                        $("<td>").text(item.distritoUbigeoId),
                        $("<td>").text(item.gradoPersonalId),
                        $("<td>").text(item.tipoBajaId),
                        $("<td>").text(item.motivoEvacuadoTiempoPaz),
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("ComoperpacEvacuadoTiempoPaz/EnviarDatos", {
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
    $.getJSON('/ComoperpacEvacuadoTiempoPaz/cargaCombs', [], function (Json) {
        var zonaNaval = Json["data1"];
        distritoUbigeo = Json["data2"];
        provinciaUbigeo = Json["data3"];
        departamentoUbigeo = Json["data4"];
        var gradoPersonal = Json["data5"];
        var tipoBaja = Json["data6"];


        $("select#cbZonaNaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.zonaNavalId + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.zonaNavalId + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
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


        $("select#cbTipoBaja").html("");
        $.each(tipoBaja, function () {
            var RowContent = '<option value=' + this.tipoBajaId + '>' + this.descTipoBaja + '</option>'
            $("select#cbTipoBaja").append(RowContent);
        });
        $("select#cbTipoBajae").html("");
        $.each(tipoBaja, function () {
            var RowContent = '<option value=' + this.tipoBajaId + '>' + this.descTipoBaja + '</option>'
            $("select#cbTipoBajae").append(RowContent);
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


