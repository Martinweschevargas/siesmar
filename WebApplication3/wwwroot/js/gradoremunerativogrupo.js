var  tblGradoRemunerativoGrupos;


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
                                url: '/GradoRemunerativoGrupo/InsertarGradoRemunerativoGrupo',
                                data: {
                                    'DescGradoRemunerativoGrupo': $('#txtDescripcion').val(),
                                    'GrupoRemunerativoId': $('#cbGRemunerativo').val()
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
                                    $('#tblGradoRemunerativoGrupos').DataTable().ajax.reload();
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });

                            callback(true);
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
                                url: '/GradoRemunerativoGrupo/ActualizarGradoRemunerativoGrupo',
                                data: {
                                    'GradoRemunerativoGrupoId': $('#txtCodigo').val(),
                                    'DescGradoRemunerativoGrupo': $('#txtDescripcione').val(),
                                    'GrupoRemunerativoId': $('#cbGRemunerativoe').val(),
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
                                    $('#tblGradoRemunerativoGrupos').DataTable().ajax.reload();
                                },
                                complete: function () {
                                    $('#loader-6').hide();
                                }
                            });

                            callback(true);
                        }
                    })
                    
                }
                form.classList.add('was-validated')
            }, false)
        })

    $('#tblGradoRemunerativoGrupos').DataTable({
        ajax: {
            "url": '/GradoRemunerativoGrupo/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "gradoRemunerativoGrupoId" },
            { "data": "descGradoRemunerativoGrupo" },
            { "data": "descGrupoRemunerativo" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.gradoRemunerativoGrupoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.gradoRemunerativoGrupoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(GradoRemunerativoGrupoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/GradoRemunerativoGrupo/MostrarGradoRemunerativoGrupo?GradoRemunerativoGrupoId=' + GradoRemunerativoGrupoId, [], function (GradoRemunerativoGrupoDTO) {
        $('#txtCodigo').val(GradoRemunerativoGrupoDTO.gradoRemunerativoGrupoId);
        $('#txtDescripcione').val(GradoRemunerativoGrupoDTO.descGradoRemunerativoGrupo);
        $('#cbGRemunerativoe').val(GradoRemunerativoGrupoDTO.grupoRemunerativoId);
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
                url: '/GradoRemunerativoGrupo/EliminarGradoRemunerativoGrupo',
                data: {
                    'GradoRemunerativoGrupoId': id
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
                    $('#tblGradoRemunerativoGrupos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaGradoRemunerativoGrupo() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/GradoRemunerativoGrupo/cargaCombs', [], function (Json) {
        var grupoRemunerativo = Json["data"];
        $("select#cbGRemunerativo").html("");
        $.each(grupoRemunerativo, function () {
            var RowContent = '<option value=' + this.grupoRemunerativoId + '>' + this.descGrupoRemunerativo + '</option>'
            $("select#cbGRemunerativo").append(RowContent);
        });
        $("select#cbGRemunerativoe").html("");
        $.each(grupoRemunerativo, function () {
            var RowContent = '<option value=' + this.grupoRemunerativoId + '>' + this.descGrupoRemunerativo + '</option>'
            $("select#cbGRemunerativoe").append(RowContent);
        });
    });
}