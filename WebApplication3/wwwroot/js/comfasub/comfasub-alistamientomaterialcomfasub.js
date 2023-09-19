var tblComfasubAlistamientoMaterialComfasub;

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
                                url: '/ComfasubAlistamientoMaterialComfasub/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'FechaAlistamiento': $('#txtFecha').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativa').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3N').val(),
                                    'Requerido': $('#txtRequerido').val(),
                                    'Operativo': $('#txtOperativo').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperativo').val(),
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
                                    $('#tblComfasubAlistamientoMaterialComfasub').DataTable().ajax.reload();
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
                                url: '/ComfasubAlistamientoMaterialComfasub/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'FechaAlistamiento': $('#txtFechae').val(),
                                    'CodigoCapacidadOperativa': $('#cbCapacidadOperativae').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3Ne').val(),
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
                                    $('#tblComfasubAlistamientoMaterialComfasub').DataTable().ajax.reload();
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

    tblComfasubAlistamientoMaterialComfasub = $('#tblComfasubAlistamientoMaterialComfasub').DataTable({
        ajax: {
            "url": '/ComfasubAlistamientoMaterialComfasub/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialId" },
            { "data": "descUnidadNaval" },
            { "data": "fechaAlistamiento" },
            { "data": "descCapacidadOperativa" },
            { "data": "capacidadIntrinseca" },
            { "data": "ponderado1N" },
            { "data": "subclasificacion" },
            { "data": "ponderado2Nivel" },
            { "data": "subclasificacion2" },
            { "data": "ponderado3Nivel" },
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "porcentajeOperatividad" },
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
                filename: 'Comfasub - Alistamiento de material',
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
                filename: 'Comfasub - Alistamiento de material',
                title: 'Comfasub - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfasub - Alistamiento de material',
                title: 'Comfasub - Alistamiento de material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfasub - Alistamiento de material',
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
    tblComfasubAlistamientoMaterialComfasub.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfasubAlistamientoMaterialComfasub.columns(8).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfasubAlistamientoMaterialComfasub/Mostrar?Id=' + Id, [], function (AlistamientoMaterialComfasubDTO) {
        $('#txtCodigo').val(AlistamientoMaterialComfasubDTO.alistamientoMaterialId);
        $('#cbUnidadNavale').val(AlistamientoMaterialComfasubDTO.codigoUnidadNaval);
        $('#txtFechae').val(AlistamientoMaterialComfasubDTO.fechaAlistamiento);
        $('#cbCapacidadOperativae').val(AlistamientoMaterialComfasubDTO.codigoCapacidadOperativa);
        $('#cbAlistamientoMaterialRequerido3Ne').val(AlistamientoMaterialComfasubDTO.codigoAlistamientoMaterialRequerido3N);
        $('#txtRequeridoe').val(AlistamientoMaterialComfasubDTO.requerido);
        $('#txtOperativoe').val(AlistamientoMaterialComfasubDTO.operativo);
        $('#txtPorcentajeOperativoe').val(AlistamientoMaterialComfasubDTO.porcentajeOperatividad);
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
                url: '/ComfasubAlistamientoMaterialComfasub/Eliminar',
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
                    $('#tblComfasubAlistamientoMaterialComfasub').DataTable().ajax.reload();
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
                url: '/ComfasubAlistamientoMaterialComfasub/EliminarCarga',
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
                    $('#tblComfasubAlistamientoMaterialComfasub').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComfasubAlistamientoMaterialComfasub() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfasubAlistamientoMaterialComfasub/MostrarDatos',
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
                            $("<td>").text(item.fechaAlistamiento),
                            $("<td>").text(item.codigoCapacidadOperativa),
                            $("<td>").text(item.codigoAlistamientoMaterialRequerido3N),
                            $("<td>").text(item.requerido),
                            $("<td>").text(item.operativo),
                            $("<td>").text(item.porcentajeOperatividad)

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
    fetch("ComfasubAlistamientoMaterialComfasub/EnviarDatos", {
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
    $.getJSON('/ComfasubAlistamientoMaterialComfasub/cargaCombs', [], function (Json) {
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


