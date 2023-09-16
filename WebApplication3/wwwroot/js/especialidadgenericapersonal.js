var tblEspecialidadGenericaPersonals;

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
                        title: 'Deseas agregar?',
                        text: "Se agregara a la tabla!",
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si,agregar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/EspecialidadGenericaPersonal/InsertarEspecialidadGenericaPersonal',
                                data: {
                                    'DescEspecialidad': $('#txtDescripcion').val(),
                                    'Abreviatura': $('#txtAbreviatura').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#txtCode').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGPMilitar').val()
                                },
                                beforeSend: function () {
                                    $('#loader-6').show();
                                },
                                success: function (mensaje) {
                                    if (mensaje == "1") {
                                        Swal.fire(
                                            'Agregado!',
                                            'Se agregó con éxito.',
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
                                    $('#tblEspecialidadGenericaPersonals').DataTable().ajax.reload();
                                    $('.needs-validation :input').val('');
                                    $(".needs-validation").find("select").prop("selectedIndex", 0);
                                    form.classList.remove('was-validated')
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });
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
                        confirmButtonText: 'Si,actualizar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/EspecialidadGenericaPersonal/ActualizarEspecialidadGenericaPersonal',
                                data: {
                                    'EspecialidadGenericaPersonalId': $('#txtCodigo').val(),
                                    'DescEspecialidad': $('#txtDescripcione').val(),
                                    'Abreviatura': $('#txtAbreviaturae').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#txtCodee').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGPMilitare').val()
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
                                    $('#tblEspecialidadGenericaPersonals').DataTable().ajax.reload();
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });
                        }
                    })
                }
                form.classList.add('was-validated')
            }, false)
        })

    $('#tblEspecialidadGenericaPersonals').DataTable({
        ajax: {
            "url": '/EspecialidadGenericaPersonal/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "especialidadGenericaPersonalId" },
            { "data": "descEspecialidad" },
            { "data": "abreviatura" },
            { "data": "codigoEspecialidadGenericaPersonal" },
            { "data": "descGrado" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.especialidadGenericaPersonalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.especialidadGenericaPersonalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
                }
            }
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        columnDefs: [
            {
                "targets": "_all",
                "className": "text-center",
            },
            {
                "targets": "[3,4]",
                "width": "120px",
            }
        ]
    });

    cargaCombo();

});

function edit(EspecialidadGenericaPersonalId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/EspecialidadGenericaPersonal/MostrarEspecialidadGenericaPersonal?EspecialidadGenericaPersonalId=' + EspecialidadGenericaPersonalId, [], function (EspecialidadGenericaPersonalDTO) {
        $('#txtCodigo').val(EspecialidadGenericaPersonalDTO.especialidadGenericaPersonalId);
        $('#txtDescripcione').val(EspecialidadGenericaPersonalDTO.descEspecialidad);
        $('#txtAbreviaturae').val(EspecialidadGenericaPersonalDTO.abreviatura);
        $('#txtCodee').val(EspecialidadGenericaPersonalDTO.codigoEspecialidadGenericaPersonal);
        $('#cbGPMilitare').val(EspecialidadGenericaPersonalDTO.codigoGradoPersonalMilitar);
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
                url: '/EspecialidadGenericaPersonal/EliminarEspecialidadGenericaPersonal',
                data: {
                    'EspecialidadGenericaPersonalId': id
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
                    $('#tblEspecialidadGenericaPersonals').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaEspecialidadGenericaPersonal() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/EspecialidadGenericaPersonal/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data"];
        $("select#cbGPMilitar").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGPMilitar").append(RowContent);
        });
        $("select#cbGPMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGPMilitare").append(RowContent);
        });
    });
}