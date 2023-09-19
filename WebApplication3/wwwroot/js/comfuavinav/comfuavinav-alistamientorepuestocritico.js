var tblComfuavinavAlistamientoRepuestoCritico;
var alistamientoRepuestoCritico;

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
                        title: 'Deseas Agregar?',
                        text: "Se agregará a la tabla",
                        icon: 'question',
                        showCancelButton: true,
                        confirmButtonColor: '#3085d6',
                        cancelButtonColor: '#d33',
                        confirmButtonText: 'Si, Agregar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/ComfuavinavAlistamientoRepuestoCritico/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'CodigoAlistamientoRepuestoCritico': $('#cbAlistamientoRepuestoCritico').val(),
                                },
                                beforeSend: function () {
                                    $('#loader-6').show();
                                },
                                success: function (mensaje) {
                                    if (mensaje == "1") {
                                        Swal.fire(
                                            'Agregado!',
                                            'Se Agregó con éxito.',
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
                                    $('#tblComfuavinavAlistamientoRepuestoCritico').DataTable().ajax.reload();
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
                        confirmButtonText: 'Si, Actualizar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/ComfuavinavAlistamientoRepuestoCritico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'CodigoAlistamientoRepuestoCritico': $('#cbAlistamientoRepuestoCriticoe').val(),
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
                                    $('#tblComfuavinavAlistamientoRepuestoCritico').DataTable().ajax.reload();
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

    $('#tblComfuavinavAlistamientoRepuestoCritico').DataTable({
        ajax: {
            "url": '/ComfuavinavAlistamientoRepuestoCritico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoRepuestoCriticoComfuavinavId" },
            { "data": "descUnidadNaval" },
            { "data": "descSistemaRepuestoCritico" },
            { "data": "descSubsistemaRepuestoCritico" },
            { "data": "equipo" },
            { "data": "repuesto" },
            { "data": "existente" },
            { "data": "necesario" },
            { "data": "coeficientePonderacion" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoRepuestoCriticoComfuavinavId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoRepuestoCriticoComfuavinavId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
                }
            }
        ],
        language: {
            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
        },
        dom: 'Bfrtip',
        buttons: [
            //csv,
            {
                extend: 'csvHtml5',
                text: 'Exportar CSV',
                filename: 'Comfuavinav - Alistamiento de repuestos críticos (ARC)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfuavinav - Alistamiento de repuestos críticos (ARC)',
                title: 'Comfuavinav - Alistamiento de repuestos críticos (ARC)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfuavinav - Alistamiento de repuestos críticos (ARC)',
                title: 'Comfuavinav - Alistamiento de repuestos críticos (ARC)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfuavinav - Alistamiento de repuestos críticos (ARC)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-print'

            },
            //extra
            'pageLength'
        ],
        columnDefs: [
            {
                "targets": "_all",
                "className": "text-center",
            },
            {
                "targets": "[7,8]",
                "width": "180px",
            }
        ]
    });
    cargaDatos();
    cargaBusqueda();
});

$('#btn_search').click(function () {
    cargaBusqueda();
});

$('#btn_all').click(function () {
    mostrarTodos();
});

function cargaBusqueda() {
    var CodigoCarga = $('#cargas').val();
    tblComfuavinavAlistamientoRepuestoCritico.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfuavinavAlistamientoRepuestoCritico.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfuavinavAlistamientoRepuestoCritico/Mostrar?Id=' + Id, [], function (AlistamientoRepuestoCriticoComfuavinavDTO) {
        $('#txtCodigo').val(AlistamientoRepuestoCriticoComfuavinavDTO.alistamientoRepuestoCriticoComfuavinavId);
        $('#cbUnidadNavale').val(AlistamientoRepuestoCriticoComfuavinavDTO.unidadNavalId);
        $('#cbAlistamientoRepuestoCriticoe').val(AlistamientoRepuestoCriticoComfuavinavDTO.codigoAlistamientoRepuestoCritico);
        $('#txtSistemaRepuestoe').val(AlistamientoRepuestoCriticoComfuavinavDTO.sistemaRepuestoCritico);
        $('#txtSubsistemaRepuestoe').val(AlistamientoRepuestoCriticoComfuavinavDTO.descSubsistemaRepuestoCritico);
        $('#txtEquipoe').val(AlistamientoRepuestoCriticoComfuavinavDTO.equipo);
        $('#txtRepuestoe').val(AlistamientoRepuestoCriticoComfuavinavDTO.repuesto);
        $('#txtExistentee').val(AlistamientoRepuestoCriticoComfuavinavDTO.existente);
        $('#txtNecesarioe').val(AlistamientoRepuestoCriticoComfuavinavDTO.necesario);
        $('#txtCoeficientePonderacione').val(AlistamientoRepuestoCriticoComfuavinavDTO.coeficientePonderacion);
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
                url: '/ComfuavinavAlistamientoRepuestoCritico/Eliminar',
                data: {
                    'Id': id
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
                    $('#tblComfuavinavAlistamientoRepuestoCritico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfuavinavAlistamientoRepuestoCritico() {
    $('#listar').hide();
    $('#nuevo').show();
}


function cargaDatos() {
    $.getJSON('/ComfuavinavAlistamientoRepuestoCritico/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var alistamientoRepuestoCritico = Json["data2"];


        $("select#cbUnidadNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbAlistamientoRepuestoCritico").html("");
        $.each(alistamientoRepuestoCritico, function () {
            var RowContent = '<option value=' + this.descAlistamientoRepuestoCritico + '>' + this.descAlistamientoRepuestoCritico + '</option>'
            $("select#cbAlistamientoRepuestoCritico").append(RowContent);
        });

        $("select#cbAlistamientoRepuestoCriticoe").html("");
        $.each(alistamientoRepuestoCritico, function () {
            var RowContent = '<option value=' + this.descAlistamientoRepuestoCritico + '>' + this.descAlistamientoRepuestoCritico + '</option>'
            $("select#cbAlistamientoRepuestoCriticoe").append(RowContent);
        });
    });
}

$('select#cbAlistamientoRepuestoCritico').on('change', function () {

    var codigo = $(this).val();

    $.each(alistamientoRepuestoCritico, function () {
        if (this.alistamientoRepuestoCriticoId == codigo) {

            $("input#txtSistemaRepuesto").val(this.descSistemaRepuestoCritico);
            $("input#txtSubsistemaRepuesto").val(this.descSubsistemaRepuestoCritico);
            $("input#txtEquipo").val(this.equipo);
            $("input#txtRepuesto").val(this.repuesto);
            $("input#txtExistente").val(this.existente);
            $("input#txtNecesario").val(this.necesario);
            $("input#txtCoeficientePonderacion").val(this.coeficientePonderacion);
        }
    });
});

$('select#cbAlistamientoRepuestoCritico').on('change', function () {

    var codigo = $(this).val();

    $.each(alistamientoRepuestoCritico, function () {
        if (this.alistamientoRepuestoCriticoId == codigo) {

            $("input#txtSistemaRepuestoe").val(this.descSistemaRepuestoCritico);
            $("input#txtSubsistemaRepuestoe").val(this.descSubsistemaRepuestoCritico);
            $("input#txtEquipoe").val(this.equipo);
            $("input#txtRepuestoe").val(this.repuesto);
            $("input#txtExistentee").val(this.existente);
            $("input#txtNecesarioe").val(this.necesario);
            $("input#txtCoeficientePonderacione").val(this.coeficientePonderacion);
        }
    });
});