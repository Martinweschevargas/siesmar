var tblTiempoServicioExperiencias;

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
                                url: '/TiempoServicioExperiencia/InsertarTiempoServicioExperiencia',
                                data: {
                                    'BAPAmazonas': $('#txtBAPAmazonas').val(),
                                    'BAPLoreto': $('#txtBAPLoreto').val(),
                                    'BAPMaranon': $('#txtBAPMaranon').val(),
                                    'BAPUcayali': $('#txtBAPUcayali').val(),
                                    'BAPClavero': $('#txtBAPClavero').val(),
                                    'BAPCastillo': $('#txtBAPCastillo').val(),
                                    'BAPMorona': $('#txtBAPMorona').val(),
                                    'BAPCorrientes': $('#txtBAPCorrientes').val(),
                                    'BAPPastaza': $('#txtBAPPastaza').val(),
                                    'Personal': $('#txtPersonal').val(),
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
                                    $('#tblTiempoServicioExperiencias').DataTable().ajax.reload();
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
                                url: '/TiempoServicioExperiencia/ActualizarTiempoServicioExperiencia',
                                data: {
                                    'TiempoServicioExperienciaId': $('#txtCodigo').val(),
                                    'BAPAmazonas': $('#txtBAPAmazonase').val(),
                                    'BAPLoreto': $('#txtBAPLoretoe').val(),
                                    'BAPMaranon': $('#txtBAPMaranone').val(),
                                    'BAPUcayali': $('#txtBAPUcayalie').val(),
                                    'BAPClavero': $('#txtBAPClaveroe').val(),
                                    'BAPCastillo': $('#txtBAPCastilloe').val(),
                                    'BAPMorona': $('#txtBAPMoronae').val(),
                                    'BAPCorrientes': $('#txtBAPCorrientese').val(),
                                    'BAPPastaza': $('#txtBAPPastazae').val(),
                                    'Personal': $('#txtPersonale').val(),
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
                                    $('#tblTiempoServicioExperiencias').DataTable().ajax.reload();
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

    $('#tblTiempoServicioExperiencias').DataTable({
        ajax: {
            "url": '/TiempoServicioExperiencia/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "tiempoServicioExperienciaId" },
            { "data": "bapAmazonas" },
            { "data": "bapLoreto" },
            { "data": "bapMaranon" },
            { "data": "bapUcayali" },
            { "data": "bapClavero" },
            { "data": "bapCastillo" },
            { "data": "bapMorona" },
            { "data": "bapCorrientes" },
            { "data": "bapPastaza" },
            { "data": "personal" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.tiempoServicioExperienciaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.tiempoServicioExperienciaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
});

function edit(TiempoServicioExperienciaId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/TiempoServicioExperiencia/MostrarTiempoServicioExperiencia?TiempoServicioExperienciaId=' + TiempoServicioExperienciaId, [], function (TiempoServicioExperienciaDTO) {
        $('#txtCodigo').val(TiempoServicioExperienciaDTO.tiempoServicioExperienciaId);
        $('#txtBAPAmazonase').val(TiempoServicioExperienciaDTO.bapAmazonas);
        $('#txtBAPLoretoe').val(TiempoServicioExperienciaDTO.bapLoreto);
        $('#txtBAPMaranone').val(TiempoServicioExperienciaDTO.bapMaranon);
        $('#txtBAPUcayalie').val(TiempoServicioExperienciaDTO.bapUcayali);
        $('#txtBAPClaveroe').val(TiempoServicioExperienciaDTO.bapClavero);
        $('#txtBAPCastilloe').val(TiempoServicioExperienciaDTO.bapCastillo);
        $('#txtBAPMoronae').val(TiempoServicioExperienciaDTO.bapMorona);
        $('#txtBAPCorrientese').val(TiempoServicioExperienciaDTO.bapCorrientes);
        $('#txtBAPPastazae').val(TiempoServicioExperienciaDTO.bapPastaza);
        $('#txtPersonale').val(TiempoServicioExperienciaDTO.personal);
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
                url: '/TiempoServicioExperiencia/EliminarTiempoServicioExperiencia',
                data: {
                    'TiempoServicioExperienciaId': id
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
                    $('#tblTiempoServicioExperiencias').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaTiempoServicioExperiencia() {
    $('#listar').hide();
    $('#nuevo').show();
}

