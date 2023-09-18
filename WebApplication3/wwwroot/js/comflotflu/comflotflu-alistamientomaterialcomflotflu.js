var tblComflotfluAlistamientoMaterialComflotflu;
var alistamientoMaterialRequerido3N;

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
                                url: '/ComflotfluAlistamientoMaterialComflotflu/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'AlistamientoMaterialRequerido3NId': $('#txtAlistamientoMaterialRequerido3N').val(),                           
                                    'Requerido': $('#txtRequerido').val(),
                                    'Operativo': $('#txtOperativo').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperativo').val(), 
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
                                    $('#tblComflotfluAlistamientoMaterialComflotflu').DataTable().ajax.reload();
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
                                url: '/ComflotfluAlistamientoMaterialComflotflu/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'AlistamientoMaterialRequerido3NId': $('#txtAlistamientoMaterialRequerido3Ne').val(),                           
                                    'Requerido': $('#txtRequeridoe').val(),
                                    'Operativo': $('#txtOperativoe').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperativoe').val(), 
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
                                    $('#tblComflotfluAlistamientoMaterialComflotflu').DataTable().ajax.reload();
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

    $('#tblComflotfluAlistamientoMaterialComflotflu').DataTable({
        ajax: {
            "url": '/ComflotfluAlistamientoMaterialComflotflu/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialComflotfluId" },
            { "data": "descUnidadNaval" },
            { "data": "capacidadIntrinseca" },
            { "data": "ponderado1N" },
            { "data": "subclasificacion2" },
            { "data": "ponderado2Nivel" },
            { "data": "subclasificacion3" },
            { "data": "ponderado3Nivel" },
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "porcentajeOperatividad" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialComflotfluId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialComflotfluId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comflotflu - Alistamiento de material',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comflotflu - Alistamiento de material',
                title: 'Comflotflu - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comflotflu - Alistamiento de material',
                title: 'Comflotflu - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comflotflu - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
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
    $.getJSON('/ComflotfluAlistamientoMaterialComflotflu/Mostrar?Id=' + Id, [], function (AlistamientoMaterialComflotfluDTO) {
        $('#txtCodigo').val(AlistamientoMaterialComflotfluDTO.alistamientoMaterialComflotfluId);
        $('#cbUnidadNavale').val(AlistamientoMaterialComflotfluDTO.unidadNavalId);
        $('#txtAlistamientoMaterialRequerido3Ne').val(AlistamientoMaterialComflotfluDTO.alistamientoMaterialRequerido3NId);
        $('#txtCapacidadIntrinsecae').val(AlistamientoMaterialComflotfluDTO.capacidadIntrinseca);
        $('#txtPonderado1Ne').val(AlistamientoMaterialComflotfluDTO.ponderacion1);
        $('#txtSubclasificacion2e').val(AlistamientoMaterialComflotfluDTO.subclasificacion2);
        $('#txtPonderado2Nivele').val(AlistamientoMaterialComflotfluDTO.ponderado2Nivel);
        $('#txtSubclasificacion3e').val(AlistamientoMaterialComflotfluDTO.subclasificacion3);
        $('#txtPonderado3Nivele').val(AlistamientoMaterialComflotfluDTO.ponderado3Nivel);
        $('#txtRequeridoe').val(AlistamientoMaterialComflotfluDTO.requerido);
        $('#txtOperativoe').val(AlistamientoMaterialComflotfluDTO.operativo);
        $('#txtPorcentajeOperativoe').val(AlistamientoMaterialComflotfluDTO.porcentajeOperatividad); 
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
                url: '/ComflotfluAlistamientoMaterialComflotflu/Eliminar',
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
                    $('#tblComflotfluAlistamientoMaterialComflotflu').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComflotfluAlistamientoMaterialComflotflu() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComflotfluAlistamientoMaterialComflotflu/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        alistamientoMaterialRequerido3N = Json["data2"];


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

        $("select#txtAlistamientoMaterialRequerido3N").html("");
        $.each(alistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.alistamientoMaterialRequerido3NId + '>' + this.subclasificacion + '</option>'
            $("select#txtAlistamientoMaterialRequerido3N").append(RowContent);

            $("input#txtCapacidadIntrinseca").val(alistamientoMaterialRequerido3N[0].capacidadIntrinseca);
            $("input#txtPonderado1N").val(alistamientoMaterialRequerido3N[0].ponderado1N);
            $("input#txtSubclasificacion2").val(alistamientoMaterialRequerido3N[0].subclasificacion2);
            $("input#txtPonderado2Nivel").val(alistamientoMaterialRequerido3N[0].ponderado2Nivel);
            $("input#txtSubclasificacion3").val(alistamientoMaterialRequerido3N[0].subclasificacion3);
            $("input#txtPonderado3Nivel").val(alistamientoMaterialRequerido3N[0].ponderado3Nivel);

        });
        $("select#txtalistamientoMaterialRequerido3Ne").html("");
        $.each(alistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.alistamientoMaterialRequerido3NId + '>' + this.alistamientoMaterialRequerido3NId + '</option>'
            $("select#txtAlistamientoMaterialRequerido3Ne").append(RowContent);
        });

    });
}

$('select#txtAlistamientoMaterialRequerido3N').on('change', function () {

    var codigo = $(this).val();

    $.each(alistamientoCombustibleLubricante2, function () {
        if (this.alistamientoCombustibleLubricante2Id == codigo) {
            $("input#txtCapacidadIntrinseca").val(this.capacidadIntrinseca);
            $("input#txtPonderado1N").val(this.ponderado1N);
            $("input#txtSubclasificacion2").val(this.subclasificacion2);
            $("input#txtPonderado2Nivel").val(this.ponderado2Nivel);
            $("input#txtSubclasificacion3").val(this.subclasificacion3);
            $("input#txtPonderado3Nivel").val(this.ponderado3Nivel);
        }
    });
});

$('select#txtAlistamientoMaterialRequerido3Ne').on('change', function () {

    var codigo = $(this).val();

    $.each(alistamientoCombustibleLubricante2, function () {
        if (this.alistamientoCombustibleLubricante2Id == codigo) {
            $("input#txtCapacidadIntrinsecae").val(this.capacidadIntrinseca);
            $("input#txtPonderado1Ne").val(this.ponderado1N);
            $("input#txtSubclasificacion2e").val(this.subclasificacion2);
            $("input#txtPonderado2Nivele").val(this.ponderado2Nivel);
            $("input#txtSubclasificacion3e").val(this.subclasificacion3);
            $("input#txtPonderado3Nivele").val(this.ponderado3Nivel);
        }
    });
});