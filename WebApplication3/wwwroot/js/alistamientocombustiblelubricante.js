var tblAlistamientoCombustibleLubricantes;

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
                                url: '/AlistamientoCombustibleLubricante/InsertarAlistamientoCombustibleLubricante',
                                data: {
                                    'CodigoAlistamientoCombustibleLubricante': $('#txtCombus').val(),
                                    'CodigoSistemaCombustibleLubricante': $('#cbSistema').val(),
                                    'CodigoSubsistemaCombustibleLubricante': $('#cbSubsistema').val(),
                                    'Equipo': $('#txtEquipo').val(),
                                    'CombustibleLubricante': $('#txtCombustible').val(),
                                    'Existente': $('#txtExistente').val(),
                                    'Necesaria': $('#txtNecesaria').val(),
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
                                    $('#tblAlistamientoCombustibleLubricantes').DataTable().ajax.reload();
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
                                url: '/AlistamientoCombustibleLubricante/ActualizarAlistamientoCombustibleLubricante',
                                data: {
                                    'AlistamientoCombustibleLubricanteId': $('#txtCodigo').val(),
                                    'CodigoAlistamientoCombustibleLubricante': $('#txtCombuse').val(),
                                    'CodigoSistemaCombustibleLubricante': $('#cbSistemae').val(),
                                    'CodigoSubsistemaCombustibleLubricante': $('#cbSubsistemae').val(),
                                    'Equipo': $('#txtEquipoe').val(),
                                    'Combustible': $('#txtCombustiblee').val(),
                                    'Existente': $('#txtExistentee').val(),
                                    'Necesaria': $('#txtNecesariae').val(),
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
                                    $('#tblAlistamientoCombustibleLubricantes').DataTable().ajax.reload();
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

    $('#tblAlistamientoCombustibleLubricantes').DataTable({
        ajax: {
            "url": '/AlistamientoCombustibleLubricante/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoCombustibleLubricanteId" },
            { "data": "codigoAlistamientoCombustibleLubricante" },
            { "data": "descSistemaCombustibleLubricante" },
            { "data": "descSubsistemaCombustibleLubricante" },
            { "data": "equipo" },
            { "data": "combustibleLubricante" },
            { "data": "existente" },
            { "data": "necesariasGLS" },
            { "data": "coeficientePonderacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoCombustibleLubricanteId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoCombustibleLubricanteId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
    cargaComboSubsistema();

});

function edit(AlistamientoCombustibleLubricanteId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/AlistamientoCombustibleLubricante/MostrarAlistamientoCombustibleLubricante?AlistamientoCombustibleLubricanteId=' + AlistamientoCombustibleLubricanteId, [], function (AlistamientoCombustibleLubricanteDTO) {
        $('#txtCodigo').val(AlistamientoCombustibleLubricanteDTO.alistamientoCombustibleLubricanteId);
        $('#txtCombuse').val(AlistamientoCombustibleLubricanteDTO.codigoAlistamientoCombustibleLubricante);
        $('#cbSistemae').val(AlistamientoCombustibleLubricanteDTO.codigoSistemaCombustibleLubricante);
        $('#cbSubsistemae').val(AlistamientoCombustibleLubricanteDTO.codigoSubsistemaCombustibleLubricante);
        $('#txtEquipoe').val(AlistamientoCombustibleLubricanteDTO.equipo);
        $('#txtCombustiblee').val(AlistamientoCombustibleLubricanteDTO.combustibleLubricante);
        $('#txtExistentee').val(AlistamientoCombustibleLubricanteDTO.existente);
        $('#txtNecesariae').val(AlistamientoCombustibleLubricanteDTO.necesariasGLS);
        $('#txtCoeficientee').val(AlistamientoCombustibleLubricanteDTO.coeficientePonderacion);
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
                url: '/AlistamientoCombustibleLubricante/EliminarAlistamientoCombustibleLubricante',
                data: {
                    'AlistamientoCombustibleLubricanteId': id
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
                    $('#tblAlistamientoCombustibleLubricantes').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaAlistamientoCombustibleLubricante() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaComboSistema() {
    $.getJSON('/AlistamientoCombustibleLubricante/cargaCombsSistemas', [], function (Json) {
        var sistemaCombustibleLubricante = Json["data1"];
        var subsistemaCombustibleLubricante = Json["data2"];

        $("select#cbSistema").html("");
        $("select#cbSistemae").html("");
        $.each(sistemaCombustibleLubricante, function () {
            var RowContent = '<option value=' + this.codigoSistemaCombustibleLubricante + '>' + this.descSistemaCombustibleLubricante + '</option>'
            $("select#cbSistema").append(RowContent);
            $("select#cbSistemae").append(RowContent);
        });

        $("select#cbSubsistema").html("");
        $("select#cbSubsistemae").html("");
        $.each(subsistemaCombustibleLubricante, function () {
            var RowContent = '<option value=' + this.codigoSubsistemaCombustibleLubricante + '>' + this.descSubsistemaCombustibleLubricante + '</option>'
            $("select#cbSubsistema").append(RowContent);
            $("select#cbSubsistemae").append(RowContent);
        });

    });

}
