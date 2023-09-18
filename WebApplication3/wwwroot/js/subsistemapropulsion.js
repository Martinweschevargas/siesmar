var tblSubSistemaPropulsions;

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
                                url: '/SubSistemaPropulsion/InsertarSubSistemaPropulsion',
                                data: {
                                    'CodigoSubSistemaPropulsion': $('#txtCodSub').val(),
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'CodigoSistemaPropulsion': $('#cbFK').val()
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
                                    $('#tblSubSistemaPropulsions').DataTable().ajax.reload();
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
                                url: '/SubSistemaPropulsion/ActualizarSubSistemaPropulsion',
                                data: {
                                    'SubSistemaPropulsionId': $('#txtCodigo').val(),
                                    'CodigoSubSistemaPropulsion': $('#txtCodSube').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'CodigoSistemaPropulsion': $('#cbFKe').val()
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
                                    $('#tblSubSistemaPropulsions').DataTable().ajax.reload();
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

    $('#tblSubSistemaPropulsions').DataTable({
        ajax: {
            "url": '/SubSistemaPropulsion/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "subSistemaPropulsionId" },
            { "data": "codigoSubSistemaPropulsion" },
            { "data": "descSubSistemaPropulsion" },
            { "data": "descSistemaPropulsion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.subSistemaPropulsionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.subSistemaPropulsionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(SubSistemaPropulsionId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/SubSistemaPropulsion/MostrarSubSistemaPropulsion?SubSistemaPropulsionId=' + SubSistemaPropulsionId, [], function (SubSistemaPropulsionDTO) {
        $('#txtCodigo').val(SubSistemaPropulsionDTO.subSistemaPropulsionId);
        $('#txtCodSube').val(SubSistemaPropulsionDTO.codigoSubSistemaPropulsion);
        $('#txtDescripcione').val(SubSistemaPropulsionDTO.descSubSistemaPropulsion);
        $('#cbFKe').val(SubSistemaPropulsionDTO.codigoSistemaPropulsion);
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
                url: '/SubSistemaPropulsion/EliminarSubSistemaPropulsion',
                data: {
                    'SubSistemaPropulsionId': id
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
                    $('#tblSubSistemaPropulsions').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaSubSistemaPropulsion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/SubSistemaPropulsion/cargaCombs', [], function (Json) {
        var sistemaPropulsion = Json["data"];

        $("select#cbFK").html("");
        $("select#cbFKe").html("");
        $.each(sistemaPropulsion, function () {
            var RowContent = '<option value=' + this.codigoSistemaPropulsion + '>' + this.descSistemaPropulsion + '</option>'
            $("select#cbFK").append(RowContent);
            $("select#cbFKe").append(RowContent);
        });

    });
}