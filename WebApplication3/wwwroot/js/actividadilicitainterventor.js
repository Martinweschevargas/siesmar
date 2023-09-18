var tblActividadIlicitaInterventors;

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
                                url: '/ActividadIlicitaInterventor/InsertarActividadIlicitaInterventor',
                                data: {
                                    'Codigo': $('#txtCode').val(),
                                    'ActividadIlicitaId': $('#cbFK').val()
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
                                    $('#tblActividadIlicitaInterventors').DataTable().ajax.reload();
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
                                url: '/ActividadIlicitaInterventor/ActualizarActividadIlicitaInterventor',
                                data: {
                                    'ActividadIlicitaInterventorId': $('#txtCodigo').val(),
                                    'Codigo': $('#txtCodee').val(),
                                    'ActividadIlicitaId': $('#cbFKe').val()
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
                                    $('#tblActividadIlicitaInterventors').DataTable().ajax.reload();
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

    $('#tblActividadIlicitaInterventors').DataTable({
        ajax: {
            "url": '/ActividadIlicitaInterventor/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "actividadIlicitaInterventorId" },
            { "data": "codUnidad" },
            { "data": "descActividadIlicita" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.actividadIlicitaInterventorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.actividadIlicitaInterventorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(ActividadIlicitaInterventorId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ActividadIlicitaInterventor/MostrarActividadIlicitaInterventor?ActividadIlicitaInterventorId=' + ActividadIlicitaInterventorId, [], function (ActividadIlicitaInterventorDTO) {
        $('#txtCodigo').val(ActividadIlicitaInterventorDTO.actividadIlicitaInterventorId);
        $('#txtCodee').val(ActividadIlicitaInterventorDTO.codUnidad);
        $('#cbFKe').val(ActividadIlicitaInterventorDTO.actividadIlicitaId);
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
                url: '/ActividadIlicitaInterventor/EliminarActividadIlicitaInterventor',
                data: {
                    'ActividadIlicitaInterventorId': id
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
                    $('#tblActividadIlicitaInterventors').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaActividadIlicitaInterventor() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/ActividadIlicitaInterventor/cargaCombs', [], function (Json) {
        var actividadIlicita = Json["data"];
        $("select#cbFK").html("");
        $.each(actividadIlicita, function () {
            var RowContent = '<option value=' + this.actividadIlicitaId + '>' + this.descActividadIlicita + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(actividadIlicita, function () {
            var RowContent = '<option value=' + this.actividadIlicitaId + '>' + this.descActividadIlicita + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}