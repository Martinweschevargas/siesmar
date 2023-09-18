var tblComfoeAlistamientoMaterialComfoe;

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
                                url: '/ComfoeAlistamientoMaterialComfoe/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativa').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3N').val(),
                                    'Requerido': $('#txtRequerido').val(),
                                    'Operativo': $('#txtOperativo').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperativo').val(),
                                    'PonderadoFuncional': $('#txtPonderadoFuncional').val(),
                                    'NivelAlistamientoParcial': $('#txtNivelAlistamientoParcial').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'Fecha': $('#txtFecha').val()
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
                                    $('#tblComfoeAlistamientoMaterialComfoe').DataTable().ajax.reload();
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
                        confirmButtonText: 'Si, Actualizar!'
                    }).then((result) => {
                        if (result.isConfirmed) {
                            $.ajax({
                                type: "POST",
                                url: '/ComfoeAlistamientoMaterialComfoe/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativae').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3Ne').val(),
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
                                    $('#tblComfoeAlistamientoMaterialComfoe').DataTable().ajax.reload();
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

   tblComfoeAlistamientoMaterialComfoe = $('#tblComfoeAlistamientoMaterialComfoe').DataTable({
        ajax: {
            "url": '/ComfoeAlistamientoMaterialComfoe/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialId" },
            { "data": "descUnidadNaval" },
            { "data": "descCapacidadOperativa" },
            { "data": "codigoAlistamientoMaterialRequerido3N" },
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "porcentajeOperatividad" },
            { "data": "ponderadoFuncional" },
            { "data": "nivelAlistamientoParcial" },
            { "data": "cargaId" },  
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
                filename: 'Comfoe-3 - Alistamiento de material',
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
                filename: 'Comfoe-3 - Alistamiento de material',
                title: 'Comfoe-3 - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7 ,8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfoe-3 - Alistamiento de material',
                title: 'Comfoe-3 - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfoe-3 - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7 , 8]
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
    tblComfoeAlistamientoMaterialComfoe.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfoeAlistamientoMaterialComfoe.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfoeAlistamientoMaterialComfoe/Mostrar?Id=' + Id, [], function (AlistamientoMaterialComfoeDTO) {
        $('#txtCodigo').val(AlistamientoMaterialComfoeDTO.alistamientoMaterialId);
        $('#cbUnidadNavale').val(AlistamientoMaterialComfoeDTO.codigoUnidadNaval);
        $('#cbCapacidadOperativae').val(AlistamientoMaterialComfoeDTO.codigoCapacidadOperativa);
        $('#cbAlistamientoMaterialRequerido3Ne').val(AlistamientoMaterialComfoeDTO.codigoAlistamientoMaterialRequerido3N);
        $('#txtRequeridoe').val(AlistamientoMaterialComfoeDTO.requerido);
        $('#txtOperativoe').val(AlistamientoMaterialComfoeDTO.operativo);
        $('#txtPorcentajeOperativoe').val(AlistamientoMaterialComfoeDTO.porcentajeOperatividad);
        $('#txtPonderadoFuncionale').val(AlistamientoMaterialComfoeDTO.ponderadoFuncional);
        $('#txtNivelAlistamientoParciale').val(AlistamientoMaterialComfoeDTO.nivelAlistamientoParcial);
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
                url: '/ComfoeAlistamientoMaterialComfoe/Eliminar',
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
                    $('#tblComfoeAlistamientoMaterialComfoe').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function eliminarCarga() {
    var id = $('select#cargas').val();
    Swal.fire({
        title: 'Estas seguro?',
        text: "No podras revertir!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si,borralo!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '/ComfoeAlistamientoMaterialComfoe/EliminarCarga',
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
                    cargaDatos();
                    $('#tblComfoeAlistamientoMaterialComfoe').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComfoeAlistamientoMaterialComfoe() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfoeAlistamientoMaterialComfoe/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.codigoCapacidadOperativa),
                            $("<td>").text(item.codigoAlistamientoMaterialRequerido3N),
                            $("<td>").text(item.requerido),
                            $("<td>").text(item.operativo),
                            $("<td>").text(item.porcentajeOperatividad),
                            $("<td>").text(item.ponderadoFuncional),
                            $("<td>").text(item.nivelAlistamientoParcial)

                        )
                    )
                })
                Swal.fire(
                    'Cargado!',
                    'Vista previa con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema.',
                    'error'
                )
            }
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    formData.append("Fecha", $('#txtFecha').val())
    fetch("ComfoeAlistamientoMaterialComfoe/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((mensaje) => {
            if (mensaje == "1") {
                Swal.fire(
                    'Cargado!',
                    'Se Cargo el archivo con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema. ' + mensaje,
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/ComfoeAlistamientoMaterialComfoe/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var capacidadOperativa = Json["data2"];
        var alistamientoMaterialRequerido3N = Json["data3"];
        var listaCargas = Json["data4"];


        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbCapacidadOperativa").html("");
        $("select#cbCapacidadOperativae").html("");
        $.each(capacidadOperativa, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativa + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
            $("select#cbCapacidadOperativae").append(RowContent);
        });

        $("select#cbAlistamientoMaterialRequerido3N").html("");
        $("select#cbAlistamientoMaterialRequerido3Ne").html("");
        $.each(alistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido3N + '>' + this.codigoAlistamientoMaterialRequerido3N + '</option>'
            $("select#cbAlistamientoMaterialRequerido3N").append(RowContent);
            $("select#cbAlistamientoMaterialRequerido3Ne").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
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
