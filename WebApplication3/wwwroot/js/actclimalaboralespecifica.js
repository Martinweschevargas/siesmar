var tblActClimaLaboralEspecificas;

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
                                url: '/ActClimaLaboralEspecifica/InsertarActClimaLaboralEspecifica',
                                data: {
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'ActClimaLaboralGeneralId': $('#cbFK').val(),
                                    'CodigoActClimaLaboralEspecifica': $('#txtCodigo').val()
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
                                    $('#tblActClimaLaboralEspecificas').DataTable().ajax.reload();
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
                                url: '/ActClimaLaboralEspecifica/ActualizarActClimaLaboralEspecifica',
                                data: {
                                    'ActClimaLaboralEspecificaId': $('#txtCodigo').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'ActClimaLaboralGeneralId': $('#cbFKe').val(),
                                    'CodigoActClimaLaboralEspecifica': $('#txtCodigoe').val()
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
                                    $('#tblActClimaLaboralEspecificas').DataTable().ajax.reload();
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

    $('#tblActClimaLaboralEspecificas').DataTable({
        ajax: {
            "url": '/ActClimaLaboralEspecifica/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "actClimaLaboralEspecificaId" },
            { "data": "descActClimaLaboralEspecifica" },
            { "data": "descActClimaLaboralGeneral" },
            { "data": "codigoActClimaLaboralEspecifica" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.actClimaLaboralEspecificaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.actClimaLaboralEspecificaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(ActClimaLaboralEspecificaId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ActClimaLaboralEspecifica/MostrarActClimaLaboralEspecifica?ActClimaLaboralEspecificaId=' + ActClimaLaboralEspecificaId, [], function (ActClimaLaboralEspecificaDTO) {
        $('#txtCodigo').val(ActClimaLaboralEspecificaDTO.actClimaLaboralEspecificaId);
        $('#txtDescripcione').val(ActClimaLaboralEspecificaDTO.descActClimaLaboralEspecifica);
        $('#cbFKe').val(ActClimaLaboralEspecificaDTO.actClimaLaboralGeneralId);
        $('#txtCodigoe').val(ActClimaLaboralEspecificaDTO.CodigoActClimaLaboralEspecifica);
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
                url: '/ActClimaLaboralEspecifica/EliminarActClimaLaboralEspecifica',
                data: {
                    'ActClimaLaboralEspecificaId': id
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
                    $('#tblActClimaLaboralEspecificas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaActClimaLaboralEspecifica() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/ActClimaLaboralEspecifica/cargaCombs', [], function (Json) {
        var actClimaLaboralGeneral = Json["data"];
        $("select#cbFK").html("");
        $.each(actClimaLaboralGeneral, function () {
            var RowContent = '<option value=' + this.actClimaLaboralGeneralId + '>' + this.descActClimaLaboralGeneral + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(actClimaLaboralGeneral, function () {
            var RowContent = '<option value=' + this.actClimaLaboralGeneralId + '>' + this.descActClimaLaboralGeneral + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}