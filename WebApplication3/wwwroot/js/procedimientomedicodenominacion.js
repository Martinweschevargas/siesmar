var tblProcedimientoMedicoDenominacions;

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
                                url: '/ProcedimientoMedicoDenominacion/InsertarProcedimientoMedicoDenominacion',
                                data: {
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'Codigo': $('#txtCode').val(),
                                    'ProcedimientoMedicoSubseccionId': $('#cbFK').val()
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
                                    $('#tblProcedimientoMedicoDenominacions').DataTable().ajax.reload();
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
                                url: '/ProcedimientoMedicoDenominacion/ActualizarProcedimientoMedicoDenominacion',
                                data: {
                                    'ProcedimientoMedicoDenominacionId': $('#txtCodigo').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'Codigo': $('#txtCodee').val(),
                                    'ProcedimientoMedicoSubseccionId': $('#cbFKe').val()
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
                                    $('#tblProcedimientoMedicoDenominacions').DataTable().ajax.reload();
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

    $('#tblProcedimientoMedicoDenominacions').DataTable({
        ajax: {
            "url": '/ProcedimientoMedicoDenominacion/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "procedimientoMedicoDenominacionId" },
            { "data": "descProcedimientoMedicoDenominacion" },
            { "data": "codigoProcedimientoMedicoDenominacion" },
            { "data": "descProcedimientoMedicoSubseccion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.procedimientoMedicoDenominacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.procedimientoMedicoDenominacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(ProcedimientoMedicoDenominacionId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ProcedimientoMedicoDenominacion/MostrarProcedimientoMedicoDenominacion?ProcedimientoMedicoDenominacionId=' + ProcedimientoMedicoDenominacionId, [], function (ProcedimientoMedicoDenominacionDTO) {
        $('#txtCodigo').val(ProcedimientoMedicoDenominacionDTO.procedimientoMedicoDenominacionId);
        $('#txtDescripcione').val(ProcedimientoMedicoDenominacionDTO.descProcedimientoMedicoDenominacion);
        $('#txtCodee').val(ProcedimientoMedicoDenominacionDTO.codigoProcedimientoMedicoDenominacion);
        $('#cbFKe').val(ProcedimientoMedicoDenominacionDTO.procedimientoMedicoSubseccionId);
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
                url: '/ProcedimientoMedicoDenominacion/EliminarProcedimientoMedicoDenominacion',
                data: {
                    'ProcedimientoMedicoDenominacionId': id
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
                    $('#tblProcedimientoMedicoDenominacions').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaProcedimientoMedicoDenominacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/ProcedimientoMedicoDenominacion/cargaCombs', [], function (Json) {
        var procedimientoMedicoSubseccion = Json["data"];
        $("select#cbFK").html("");
        $.each(procedimientoMedicoSubseccion, function () {
            var RowContent = '<option value=' + this.procedimientoMedicoSubseccionId + '>' + this.descProcedimientoMedicoSubseccion + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(procedimientoMedicoSubseccion, function () {
            var RowContent = '<option value=' + this.procedimientoMedicoSubseccionId + '>' + this.descProcedimientoMedicoSubseccion + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}