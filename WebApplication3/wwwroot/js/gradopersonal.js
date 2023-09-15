var tblGradoPersonals;

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
                                url: '/GradoPersonal/InsertarGradoPersonal',
                                data: {
                                    'DescGradoPersonal': $('#txtDescripcion').val(),
                                    'CodigoGradoPersonal': $('#txtCode').val(),
                                    'EntidadMilitarId': $('#cbEMilitar').val()
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
                                    $('#tblGradoPersonals').DataTable().ajax.reload();
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
                                url: '/GradoPersonal/ActualizarGradoPersonal',
                                data: {
                                    'GradoPersonalId': $('#txtCodigo').val(),
                                    'DescGradoPersonal': $('#txtDescripcione').val(),
                                    'CodigoGradoPersonal': $('#txtCodee').val(),
                                    'EntidadMilitarId': $('#cbEMilitare').val()
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
                                    $('#tblGradoPersonals').DataTable().ajax.reload();
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

    $('#tblGradoPersonals').DataTable({
        ajax: {
            "url": '/GradoPersonal/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "gradoPersonalId" },
            { "data": "descGradoPersonal" },
            { "data": "codigoGradoPersonal" },
            { "data": "descEntidadMilitar" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.gradoPersonalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.gradoPersonalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(GradoPersonalId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/GradoPersonal/MostrarGradoPersonal?GradoPersonalId=' + GradoPersonalId, [], function (GradoPersonalDTO) {
        $('#txtCodigo').val(GradoPersonalDTO.gradoPersonalId);
        $('#txtDescripcione').val(GradoPersonalDTO.descGradoPersonal);
        $('#txtCodee').val(GradoPersonalDTO.codigoGradoPersonal);
        $('#cbEMilitare').val(GradoPersonalDTO.entidadMilitarId);
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
                url: '/GradoPersonal/EliminarGradoPersonal',
                data: {
                    'GradoPersonalId': id
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
                    $('#tblGradoPersonals').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaGradoPersonal() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/GradoPersonal/cargaCombs', [], function (Json) {
        var entidadMilitar = Json["data"];
        $("select#cbEMilitar").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.entidadMilitarId + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEMilitar").append(RowContent);
        });
        $("select#cbEMilitare").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.entidadMilitarId + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEMilitare").append(RowContent);
        });
    });
}