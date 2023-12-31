﻿var tblSubsistemaCombustibleLubricantes;

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
                                url: '/SubsistemaCombustibleLubricante/InsertarSubsistemaCombustibleLubricante',
                                data: {
                                    'CodigoSubsistemaCombustibleLubricante': $('#txtCodSu').val(),
                                    'Descripcion': $('#txtDescripcion').val(),
                                    'CodigoSistemaCombustibleLubricante': $('#cbFK').val()
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
                                    $('#tblSubsistemaCombustibleLubricantes').DataTable().ajax.reload();
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
                                url: '/SubsistemaCombustibleLubricante/ActualizarSubsistemaCombustibleLubricante',
                                data: {
                                    'SubsistemaCombustibleLubricanteId': $('#txtCodigo').val(),
                                    'CodigoSubsistemaCombustibleLubricante': $('#txtCodSue').val(),
                                    'Descripcion': $('#txtDescripcione').val(),
                                    'CodigoSistemaCombustibleLubricante': $('#cbFKe').val()
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
                                    $('#tblSubsistemaCombustibleLubricantes').DataTable().ajax.reload();
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

    $('#tblSubsistemaCombustibleLubricantes').DataTable({
        ajax: {
            "url": '/SubsistemaCombustibleLubricante/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "subsistemaCombustibleLubricanteId" },
            { "data": "codigoSubsistemaCombustibleLubricante" },
            { "data": "descSubsistemaCombustibleLubricante" },
            { "data": "descSistemaCombustibleLubricante" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.subsistemaCombustibleLubricanteId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.subsistemaCombustibleLubricanteId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(SubsistemaCombustibleLubricanteId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/SubsistemaCombustibleLubricante/MostrarSubsistemaCombustibleLubricante?SubsistemaCombustibleLubricanteId=' + SubsistemaCombustibleLubricanteId, [], function (SubsistemaCombustibleLubricanteDTO) {
        $('#txtCodigo').val(SubsistemaCombustibleLubricanteDTO.subsistemaCombustibleLubricanteId);
        $('#txtCodSue').val(SubsistemaCombustibleLubricanteDTO.codigoSubsistemaCombustibleLubricante);
        $('#txtDescripcione').val(SubsistemaCombustibleLubricanteDTO.descSubsistemaCombustibleLubricante);
        $('#cbFKe').val(SubsistemaCombustibleLubricanteDTO.sistemaCombustibleLubricanteId);
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
                url: '/SubsistemaCombustibleLubricante/EliminarSubsistemaCombustibleLubricante',
                data: {
                    'SubsistemaCombustibleLubricanteId': id
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
                    $('#tblSubsistemaCombustibleLubricantes').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaSubsistemaCombustibleLubricante() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/SubsistemaCombustibleLubricante/cargaCombs', [], function (Json) {
        var sistemaCombustibleLubricante = Json["data"];

        $("select#cbFK").html("");
        $("select#cbFKe").html("");
        $.each(sistemaCombustibleLubricante, function () {
            var RowContent = '<option value=' + this.sistemaCombustibleLubricanteId + '>' + this.descSistemaCombustibleLubricante + '</option>'
            $("select#cbFK").append(RowContent);
            $("select#cbFKe").append(RowContent);
        });

    });
}