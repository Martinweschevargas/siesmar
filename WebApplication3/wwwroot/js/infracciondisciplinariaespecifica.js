var tblInfraccionDisciplinariaEspecificas;

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
                                url: '/InfraccionDisciplinariaEspecifica/InsertarInfraccionDisciplinariaEspecifica',
                                data: {
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'Codigo': $('#txtCode').val(),
                                    'InfraccionDisciplinariaGenericaId': $('#cbFK').val()
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
                                    $('#tblInfraccionDisciplinariaEspecificas').DataTable().ajax.reload();
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
                                url: '/InfraccionDisciplinariaEspecifica/ActualizarInfraccionDisciplinariaEspecifica',
                                data: {
                                    'InfraccionDisciplinariaEspecificaId': $('#txtCodigo').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'Codigo': $('#txtCodee').val(),
                                    'InfraccionDisciplinariaGenericaId': $('#cbFKe').val()
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
                                    $('#tblInfraccionDisciplinariaEspecificas').DataTable().ajax.reload();
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

    $('#tblInfraccionDisciplinariaEspecificas').DataTable({
        ajax: {
            "url": '/InfraccionDisciplinariaEspecifica/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "infraccionDisciplinariaEspecificaId" },
            { "data": "descInfraccionDisciplinariaEspecifica" },
            { "data": "codigoInfraccionDisciplinariaEspecifica" },
            { "data": "descInfraccionDisciplinariaGenerica" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.infraccionDisciplinariaEspecificaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.infraccionDisciplinariaEspecificaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(InfraccionDisciplinariaEspecificaId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/InfraccionDisciplinariaEspecifica/MostrarInfraccionDisciplinariaEspecifica?InfraccionDisciplinariaEspecificaId=' + InfraccionDisciplinariaEspecificaId, [], function (InfraccionDisciplinariaEspecificaDTO) {
        $('#txtCodigo').val(InfraccionDisciplinariaEspecificaDTO.infraccionDisciplinariaEspecificaId);
        $('#txtDescripcione').val(InfraccionDisciplinariaEspecificaDTO.descInfraccionDisciplinariaEspecifica);
        $('#txtCodee').val(InfraccionDisciplinariaEspecificaDTO.codigoInfraccionDisciplinariaEspecifica);
        $('#cbFKe').val(InfraccionDisciplinariaEspecificaDTO.infraccionDisciplinariaGenericaId);
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
                url: '/InfraccionDisciplinariaEspecifica/EliminarInfraccionDisciplinariaEspecifica',
                data: {
                    'InfraccionDisciplinariaEspecificaId': id
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
                    $('#tblInfraccionDisciplinariaEspecificas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaInfraccionDisciplinariaEspecifica() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/InfraccionDisciplinariaEspecifica/cargaCombs', [], function (Json) {
        var infraccionDisciplinariaGenerica = Json["data"];
        $("select#cbFK").html("");
        $.each(infraccionDisciplinariaGenerica, function () {
            var RowContent = '<option value=' + this.infraccionDisciplinariaGenericaId + '>' + this.descInfraccionDisciplinariaGenerica + '</option>'
            $("select#cbFK").append(RowContent);
        });
        $("select#cbFKe").html("");
        $.each(infraccionDisciplinariaGenerica, function () {
            var RowContent = '<option value=' + this.infraccionDisciplinariaGenericaId + '>' + this.descInfraccionDisciplinariaGenerica + '</option>'
            $("select#cbFKe").append(RowContent);
        });
    });
}