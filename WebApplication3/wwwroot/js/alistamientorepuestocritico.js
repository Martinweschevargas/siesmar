var tblAlistamientoRepuestoCriticos;

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
                                url: '/AlistamientoRepuestoCritico/InsertarAlistamientoRepuestoCritico',
                                data: {
                                    'CodigoAlistamientoRepuestoCritico': $('#txtCodR').val(),
                                    'CodigoSistemaRepuestoCritico': $('#cbSistema').val(),
                                    'CodigoSubsistemaRepuestoCritico': $('#cbSubsistema').val(),
                                    'Equipo': $('#txtEquipo').val(),
                                    'Repuesto': $('#txtRepuesto').val(),
                                    'Existente': $('#txtExistente').val(),
                                    'Necesario': $('#txtNecesario').val(),
                                    'Coeficiente': $('#txtCoeficiente').val(),
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
                                    $('#tblAlistamientoRepuestoCriticos').DataTable().ajax.reload();
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
                                url: '/AlistamientoRepuestoCritico/ActualizarAlistamientoRepuestoCritico',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoAlistamientoRepuestoCritico': $('#txtCodRe').val(),
                                    'CodigoSistemaRepuestoCritico': $('#cbSistemae').val(),
                                    'CodigoSubsistemaRepuestoCritico': $('#cbSubsistemae').val(),
                                    'Equipo': $('#txtEquipoe').val(),
                                    'Repuesto': $('#txtRepuestoe').val(),
                                    'Existente': $('#txtExistentee').val(),
                                    'Necesario': $('#txtNecesarioe').val(),
                                    'Coeficiente': $('#txtCoeficientee').val(),
                                },
                                beforeSend: function () {
                                    $('#loader-6').show();
                                },
                                success: function (mensaje) {
                                    if (mensaje == "1") {
                                        Swal.fire(
                                            'Actualizado!',
                                            'Se actualizo con éxito.',
                                            'success',
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
                                    $('#tblAlistamientoRepuestoCriticos').DataTable().ajax.reload();
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

    tblAlistamientoRepuestoCriticos = $('#tblAlistamientoRepuestoCriticos').DataTable({
        ajax: {
            "url": '/AlistamientoRepuestoCritico/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoRepuestoCriticoId" },
            { "data": "codigoAlistamientoRepuestoCritico" },
            { "data": "descSistemaRepuestoCritico" },
            { "data": "descSubsistemaRepuestoCritico" },
            { "data": "equipo" },
            { "data": "repuesto" },
            { "data": "existente" },
            { "data": "necesario" },
            { "data": "coeficientePonderacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoRepuestoCriticoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoRepuestoCriticoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
    cargaComboSistema();
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/AlistamientoRepuestoCritico/MostrarAlistamientoRepuestoCritico?Id=' + Id, [], function (AlistamientoRepuestoCriticoDTO) {
        $('#txtCodigo').val(AlistamientoRepuestoCriticoDTO.alistamientoRepuestoCriticoId);
        $('#txtCodRe').val(AlistamientoRepuestoCriticoDTO.codigoAlistamientoRepuestoCritico);
        $('#cbSistemae').val(AlistamientoRepuestoCriticoDTO.codigoSistemaRepuestoCritico);
        $('#cbSubsistemae').val(AlistamientoRepuestoCriticoDTO.codigoSubsistemaRepuestoCritico);
        $('#txtEquipoe').val(AlistamientoRepuestoCriticoDTO.equipo);
        $('#txtRepuestoe').val(AlistamientoRepuestoCriticoDTO.repuesto);
        $('#txtExistentee').val(AlistamientoRepuestoCriticoDTO.existente);
        $('#txtNecesarioe').val(AlistamientoRepuestoCriticoDTO.necesario);
        $('#txtCoeficientee').val(AlistamientoRepuestoCriticoDTO.coeficientePonderacion);
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
                url: '/AlistamientoRepuestoCritico/EliminarAlistamientoRepuestoCritico',
                data: {
                    'AlistamientoRepuestoCriticoId': id
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
                    $('#tblAlistamientoRepuestoCriticos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaAlistamientoRepuestoCritico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaComboSistema() {
    $.getJSON('/AlistamientoRepuestoCritico/cargaCombsSistemas', [], function (Json) {
        var sistemaRepuestoCritico = Json["data1"];
        var subsistemaRepuestoCritico = Json["data2"];

        $("select#cbSubsistema").html("");
        $("select#cbSubsistemae").html("");
        $.each(subsistemaRepuestoCritico, function () {
            var RowContent = '<option value=' + this.codigoSubsistemaRepuestoCritico + '>' + this.descSubsistemaRepuestoCritico + '</option>'
            $("select#cbSubsistema").append(RowContent);
            $("select#cbSubsistemae").append(RowContent);
        });

        $("select#cbSistema").html("");
        $("select#cbSistemae").html("");
        $.each(sistemaRepuestoCritico, function () {
            var RowContent = '<option value=' + this.codigoSistemaRepuestoCritico + '>' + this.descSistemaRepuestoCritico + '</option>'
            $("select#cbSistema").append(RowContent);
            $("select#cbSistemae").append(RowContent);
        });
    });
}
