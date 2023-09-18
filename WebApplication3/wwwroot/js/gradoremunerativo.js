
var tblGradoRemunerativos;


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
                                url: '/GradoRemunerativo/InsertarGradoRemunerativo',
                                data: {
                                    'CodigoGradoRemunerativo': $('#txtCode').val(),
                                    'DescGradoRemunerativo': $('#txtDescripcion').val(),
                                    'GradoRemunerativoGrupoId': $('#cbGRemunerativoGrupo').val()
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
                                    $('#tblGradoRemunerativos').DataTable().ajax.reload();
                                    $('.needs-validation :input').val('');
                                    $(".needs-validation").find("select").prop("selectedIndex", 0);
                                    form.classList.remove('was-validated')
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
                                url: '/GradoRemunerativo/ActualizarGradoRemunerativo',
                                data: {
                                    'GradoRemunerativoId': $('#txtCodigo').val(),
                                    'CodigoGradoRemunerativo': $('#txtCodee').val(),
                                    'DescGradoRemunerativo': $('#txtDescripcione').val(),
                                    'GradoRemunerativoGrupoId': $('#cbGRemunerativoGrupoe').val(),
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
                                    $('#tblGradoRemunerativos').DataTable().ajax.reload();
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

    $('#tblGradoRemunerativos').DataTable({
        ajax: {
            "url": '/GradoRemunerativo/CargarDatos',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "gradoRemunerativoId" },
            { "data": "codigoGradoRemunerativo" },
            { "data": "descGradoRemunerativo" },
            { "data": "descGradoRemunerativoGrupo" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.gradoRemunerativoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.gradoRemunerativoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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

function edit(GradoRemunerativoId) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/GradoRemunerativo/MostrarGradoRemunerativo?GradoRemunerativoId=' + GradoRemunerativoId, [], function (GradoRemunerativoDTO) {
        $('#txtCodigo').val(GradoRemunerativoDTO.gradoRemunerativoId);
        $('#txtCodee').val(GradoRemunerativoDTO.codigoGradoRemunerativo);
        $('#txtDescripcione').val(GradoRemunerativoDTO.descGradoRemunerativo);
        $('#cbGRemunerativoGrupoe').val(GradoRemunerativoDTO.gradoRemunerativoGrupoId);
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
                url: '/GradoRemunerativo/EliminarGradoRemunerativo',
                data: {
                    'GradoRemunerativoId': id
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
                    $('#tblGradoRemunerativos').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaGradoRemunerativo() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaCombo() {
    $.getJSON('/GradoRemunerativo/cargaCombs', [], function (Json) {
        var gradoRemunerativoGrupo = Json["data"];
        $("select#cbGRemunerativoGrupo").html("");
        $.each(gradoRemunerativoGrupo, function () {
            var RowContent = '<option value=' + this.gradoRemunerativoGrupoId + '>' + this.descGradoRemunerativoGrupo + '</option>'
            $("select#cbGRemunerativoGrupo").append(RowContent);
        });
        $("select#cbGRemunerativoGrupoe").html("");
        $.each(gradoRemunerativoGrupo, function () {
            var RowContent = '<option value=' + this.gradoRemunerativoGrupoId + '>' + this.descGradoRemunerativoGrupo + '</option>'
            $("select#cbGRemunerativoGrupoe").append(RowContent);
        });
    });
}