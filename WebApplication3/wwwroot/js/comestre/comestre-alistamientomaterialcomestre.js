var tblComestreAlistamientoMaterialComestre;
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
                                url: '/ComestreAlistamientoMaterialComestre/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativa').val(),
                                    'AlistamientoMaterialRequerido3NId': $('#txtAlistamientoMaterialRequerido3N').val(),
                                    'Requerido': $('#txtRequerido').val(),
                                    'Operativo': $('#txtOperativo').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperativo').val(),
                                    'PonderadoFuncional': $('#txtPonderadoFuncional').val(),
                                    'NivelAlistamientoParcial': $('#txtNivelAlistamientoParcial').val(),
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
                                    $('#tblComestreAlistamientoMaterialComestre').DataTable().ajax.reload();
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
                                url: '/ComestreAlistamientoMaterialComestre/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativae').val(),
                                    'AlistamientoMaterialRequerido3NId': $('#txtAlistamientoMaterialRequerido3Ne').val(),
                                    'Requerido': $('#txtRequeridoe').val(),
                                    'Operativo': $('#txtOperativoe').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperativoe').val(),
                                    'PonderadoFuncional': $('#txtPonderadoFuncionale').val(),
                                    'NivelAlistamientoParcial': $('#txtNivelAlistamientoParciale').val(),
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
                                    $('#tblComestreAlistamientoMaterialComestre').DataTable().ajax.reload();
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

    $('#tblComestreAlistamientoMaterialComestre').DataTable({
        ajax: {
            "url": '/ComestreAlistamientoMaterialComestre/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialId" },
            { "data": "descUnidadNaval" },
            { "data": "descCapacidadOperativa" },
            { "data": "capacidadIntrinseca" },
            { "data": "ponderado1N" },
            { "data": "subclasificacion2" },
            { "data": "ponderado2Nivel" },
            { "data": "subclasificacion3" },
            { "data": "ponderado3Nivel" },
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "porcentajeOperatividad" },
            { "data": "ponderadoFuncional" },
            { "data": "nivelAlistamientoParcial" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comestre - Alistamiento de material',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comestre - Alistamiento de material',
                title: 'Comestre - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comestre - Alistamiento de material',
                title: 'Comestre - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comestre - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    $.getJSON('/ComestreAlistamientoMaterialComestre/Mostrar?Id=' + Id, [], function (AlistamientoMaterialComestreDTO) {
        $('#txtCodigo').val(AlistamientoMaterialComestreDTO.alistamientoMaterialId);
        $('#cbUnidadNavale').val(AlistamientoMaterialComestreDTO.unidadNavalId);
        $('#cbCapacidadOperativa').val(AlistamientoMaterialComestreDTO.capacidadOperativaId);
        $('#txtAlistamientoMaterialRequerido3N').val(AlistamientoMaterialComestreDTO.alistamientoMaterialRequerido3NId);
        $('#txtCapacidadIntrinsecae').val(AlistamientoMaterialComestreDTO.capacidadIntrinseca);
        $('#txtPonderacion1e').val(AlistamientoMaterialComestreDTO.ponderacion1);
        $('#txtSubclasificacion2e').val(AlistamientoMaterialComestreDTO.subclasificacion2);
        $('#txtPonderado2Nivele').val(AlistamientoMaterialComestreDTO.ponderado2Nivel);
        $('#txtSubclasificacion3e').val(AlistamientoMaterialComestreDTO.subclasificacion3);
        $('#txtPonderado3Nivele').val(AlistamientoMaterialComestreDTO.ponderado3Nivel);
        $('#txtRequeridoe').val(AlistamientoMaterialComestreDTO.requerido);
        $('#txtOperativoe').val(AlistamientoMaterialComestreDTO.operativo);
        $('#txtPorcentajeOperativoe').val(AlistamientoMaterialComestreDTO.porcentajeOperatividad);
        $('#txtPonderadoFuncionale').val(AlistamientoMaterialComestreDTO.ponderadoFuncional);
        $('#txtNivelAlistamientoParciale').val(AlistamientoMaterialComestreDTO.nivelAlistamientoParcial);
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
                url: '/ComestreAlistamientoMaterialComestre/Eliminar',
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
                    $('#tblComestreAlistamientoMaterialComestre').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComestreAlistamientoMaterialComestre() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComestreAlistamientoMaterialComestre/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var capacidadOperativa = Json["data2"];
        alistamientoMaterialRequerido3N = Json["data3"];


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

        $("select#cbCapacidadOperativa").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
        });
        $("select#cbCapacidadOperativae").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativae").append(RowContent);
        });

        $("select#txtAlistamientoMaterialRequerido3N").html("");
        $.each(alistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.alistamientoMaterialRequerido3NId + '>' + this.alistamientoMaterialRequerido3NId + '</option>'
            $("select#txtAlistamientoMaterialRequerido3N").append(RowContent);

            $("input#txtCapacidadIntrinseca").val(alistamientoMaterialRequerido3N[0].capacidadIntrinseca);
            $("input#txtPonderado1N").val(alistamientoMaterialRequerido3N[0].ponderado1N);
            $("input#txtSubclasificacion2").val(alistamientoMaterialRequerido3N[0].subclasificacion2);
            $("input#txtPonderado2Nivel").val(alistamientoMaterialRequerido3N[0].ponderado2Nivel);
            $("input#txtSubclasificacion3").val(alistamientoMaterialRequerido3N[0].subclasificacion);
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
