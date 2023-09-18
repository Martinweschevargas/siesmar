var tblComgoe3AlistamientoCombustibleLubricanteComgoe;
var alistamientoCombustibleLubricante2;

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
                                url: '/Comgoe3AlistamientoCombustibleLubricanteComgoe/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'AlistamientoCombustibleLubricante2Id': $('#cbAlistamientoCombustibleLubricante2').val(),
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
                                    $('#tblComgoe3AlistamientoCombustibleLubricanteComgoe').DataTable().ajax.reload();
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
                                url: '/Comgoe3AlistamientoCombustibleLubricanteComgoe/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'AlistamientoCombustibleLubricante2Id': $('#cbAlistamientoCombustibleLubricante2e').val(),
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
                                    $('#tblComgoe3AlistamientoCombustibleLubricanteComgoe').DataTable().ajax.reload();
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

    $('#tblComgoe3AlistamientoCombustibleLubricanteComgoe').DataTable({
        ajax: {
            "url": '/Comgoe3AlistamientoCombustibleLubricanteComgoe/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoCombustibleLubricanteId" },
            { "data": "descUnidadNaval" },
            { "data": "articulo" },
            { "data": "equipo" },
            { "data": "unidadMedida" },
            { "data": "cargo" },
            { "data": "aumento" },
            { "data": "consumo" },
            { "data": "existencia" },
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
        dom: 'Bfrtip',
        buttons: [
            //csv,
            {
                extend: 'csvHtml5',
                text: 'Exportar CSV',
                filename: 'Comgoe-3 - Alistamiento de combustibles y lubricantes (ACL)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comgoe-3 - Alistamiento de combustibles y lubricantes (ACL)',
                title: 'Comgoe-3 - Alistamiento de combustibles y lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comgoe-3 - Alistamiento de combustibles y lubricantes (ACL)',
                title: 'Comgoe-3 - Alistamiento de combustibles y lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comgoe-3 - Alistamiento de combustibles y lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2]
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/Comgoe3AlistamientoCombustibleLubricanteComgoe/Mostrar?Id=' + Id, [], function (AlistamientoCombustibleLubricanteComgoeDTO) {
        $('#txtCodigo').val(AlistamientoCombustibleLubricanteComgoeDTO.alistamientoCombustibleLubricanteId);
        $('#cbUnidadNavale').val(AlistamientoCombustibleLubricanteComgoeDTO.unidadNavalId);
        $('#cbAlistamientoCombustibleLubricante2e').val(AlistamientoCombustibleLubricanteComgoeDTO.alistamientoCombustibleLubricante2Id);
        $('#txtArticuloAlistamientoe').val(AlistamientoCombustibleLubricanteComgoeDTO.articulo);
        $('#txtEquipoAlistamientoe').val(AlistamientoCombustibleLubricanteComgoeDTO.equipo);
        $('#txtUnidadMedidaAlistamientoe').val(AlistamientoCombustibleLubricanteComgoeDTO.unidadMedida);
        $('#txtCargoAlistamientoe').val(AlistamientoCombustibleLubricanteComgoeDTO.cargo);
        $('#txtAumentoAlistamientoe').val(AlistamientoCombustibleLubricanteComgoeDTO.aumento);
        $('#txtConsumoAlistamientoe').val(AlistamientoCombustibleLubricanteComgoeDTO.consumo);
        $('#txtExistenciaAlistamientoe').val(AlistamientoCombustibleLubricanteComgoeDTO.existencia);
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
                url: '/Comgoe3AlistamientoCombustibleLubricanteComgoe/Eliminar',
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
                    $('#tblComgoe3AlistamientoCombustibleLubricanteComgoe').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComgoe3AlistamientoCombustibleLubricanteComgoe() {
    $('#listar').hide();
    $('#nuevo').show();
}


function cargaDatos() {
    $.getJSON('/Comgoe3AlistamientoCombustibleLubricanteComgoe/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        alistamientoCombustibleLubricante2 = Json["data2"];


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

        $("select#cbAlistamientoCombustibleLubricante2").html("");
        $.each(alistamientoCombustibleLubricante2, function () {
            var RowContent = '<option value=' + this.alistamientoCombustibleLubricante2Id + '>' + this.alistamientoCombustibleLubricante2Id + '</option>'
            $("select#cbAlistamientoCombustibleLubricante2").append(RowContent);

            $("input#txtArticuloAlistamiento").val(alistamientoCombustibleLubricante2[0].articulo);
            $("input#txtEquipoAlistamiento").val(alistamientoCombustibleLubricante2[0].equipo);
            $("input#txtUnidadMedidaAlistamiento").val(alistamientoCombustibleLubricante2[0].unidadMedida);
            $("input#txtCargoAlistamiento").val(alistamientoCombustibleLubricante2[0].cargo);
            $("input#txtAumentoAlistamiento").val(alistamientoCombustibleLubricante2[0].aumento);
            $("input#txtConsumoAlistamiento").val(alistamientoCombustibleLubricante2[0].consumo);
            $("input#txtExistenciaAlistamiento").val(alistamientoCombustibleLubricante2[0].existencia);

        });

        $("select#cbAlistamientoCombustibleLubricante2e").html("");
        $.each(alistamientoCombustibleLubricante2, function () {
            var RowContent = '<option value=' + this.alistamientoCombustibleLubricante2Id + '>' + this.alistamientoCombustibleLubricante2Id + '</option>'
            $("select#cbAlistamientoCombustibleLubricante2e").append(RowContent);
        });
    });
}

$('select#cbAlistamientoCombustibleLubricante2').on('change', function () {

    var codigo = $(this).val();

    $.each(alistamientoCombustibleLubricante2, function () {
        if (this.alistamientoCombustibleLubricante2Id == codigo) {
            $("input#txtArticuloAlistamiento").val(this.articulo);
            $("input#txtEquipoAlistamiento").val(this.equipo);
            $("input#txtUnidadMedidaAlistamiento").val(this.unidadMedida);
            $("input#txtCargoAlistamiento").val(this.cargo);
            $("input#txtAumentoAlistamiento").val(this.aumento);
            $("input#txtConsumoAlistamiento").val(this.consumo);
            $("input#txtExistenciaAlistamiento").val(this.existencia);
        }
    });
});

$('select#cbAlistamientoCombustibleLubricante2e').on('change', function () {

    var codigo = $(this).val();

    $.each(alistamientoCombustibleLubricante2, function () {
        if (this.alistamientoCombustibleLubricante2Id == codigo) {

            $("input#txtArticuloAlistamientoe").val(this.articulo);
            $("input#txtEquipoAlistamientoe").val(this.equipo);
            $("input#txtUnidadMedidaAlistamientoe").val(this.unidadMedida);
            $("input#txtCargoAlistamientoe").val(this.cargo);
            $("input#txtAumentoAlistamientoe").val(this.aumento);
            $("input#txtConsumoAlistamientoe").val(this.consumo);
            $("input#txtExistenciaAlistamientoe").val(this.existencia);

        }
    });
});
