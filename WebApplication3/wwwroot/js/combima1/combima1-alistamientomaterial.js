var tblCombima1AlistamientoMaterial;

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
                                url: '/Combima1AlistamientoMaterial/Insertar',
                                data: {
                                    'CapacidadOperativa': $('#txtCapacidadOperativa').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3N').val(),
                                    'Requerido': $('#txtNivelAlistamientoParcial').val(),
                                    'Operativo': $('#txtOperativo').val(),
                                    'Existencia': $('#txtExistencia').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperatividad').val(),
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
                                    $('#tblCombima1AlistamientoMaterial').DataTable().ajax.reload();
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
                                url: '/Combima1AlistamientoMaterial/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CapacidadOperativa': $('#txtCapacidadOperativae').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoAlistamientoMaterialRequerido3N': $('#cbAlistamientoMaterialRequerido3N').val(),
                                    'Requerido': $('#txtNivelAlistamientoParciale').val(),
                                    'Operativo': $('#txtOperativoe').val(),
                                    'Existencia': $('#txtExistenciae').val(),
                                    'PorcentajeOperativo': $('#txtPorcentajeOperatividade').val(),
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
                                    $('#tblCombima1AlistamientoMaterial').DataTable().ajax.reload();
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

   tblCombima1AlistamientoMaterial = $('#tblCombima1AlistamientoMaterial').DataTable({
        ajax: {
            "url": '/Combima1AlistamientoMaterial/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialId" },
            { "data": "descUnidadNaval" },
            { "data": "capacidadOperativa" },
            { "data": "codigoAlistamientoMaterialRequerido3N" },
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "existencia" },
            { "data": "porcentajeOperatividad" },
            { "data": "porcentajeFuncional" },
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
                filename: 'Combima1 - Alistamiento de Material',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Combima1 - Alistamiento de Material',
                title: 'Combima1 - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Combima1 - Alistamiento de Material',
                title: 'Combima1 - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Combima1 - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9]
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
    tblCombima1AlistamientoMaterial.columns(10).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblCombima1AlistamientoMaterial.columns(10).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/Combima1AlistamientoMaterial/Mostrar?Id=' + Id, [], function (AlistamientoMaterialCombima1DTO) {
        $('#txtCodigo').val(AlistamientoMaterialCombima1DTO.alistamientoMaterialId);
        $('#txtCapacidadOperativae').val(AlistamientoMaterialCombima1DTO.capacidadOperativa);
        $('#cbUnidadNavale').val(AlistamientoMaterialCombima1DTO.codigoUnidadNaval);
        $('#cbAlistamientoMaterialRequerido3Ne').val(AlistamientoMaterialCombima1DTO.codigoAlistamientoMaterialRequerido3N);
        $('#txtRequeridoe').val(AlistamientoMaterialCombima1DTO.requerido);
        $('#txtOperativoe').val(AlistamientoMaterialCombima1DTO.operativo);
        $('#txtExistenciae').val(AlistamientoMaterialCombima1DTO.existencia);
        $('#txtPorcentajeOperatividade').val(AlistamientoMaterialCombima1DTO.porcentajeOperatividad);
        $('#txtPonderadoFuncional').val(AlistamientoMaterialCombima1DTO.porcentajeFuncional);
        $('#txtNivelAlistamientoParciale').val(AlistamientoMaterialCombima1DTO.nivelAlistamientoParcial);
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
                url: '/Combima1AlistamientoMaterial/Eliminar',
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
                    $('#tblCombima1AlistamientoMaterial').DataTable().ajax.reload();
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
                url: '/Combima1AlistamientoMaterial/EliminarCarga',
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
                    $('#tblCombima1AlistamientoMaterial').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaCombima1AlistamientoMaterial() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'Combima1AlistamientoMaterial/MostrarDatos',
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
                            $("<td>").text(item.capacidadOperativa),
                            $("<td>").text(item.codigoAlistamientoMaterialRequerido3N),
                            $("<td>").text(item.requerido),
                            $("<td>").text(item.existencia),
                            $("<td>").text(item.operativo),
                            $("<td>").text(item.porcentajeOperatividad),
                            $("<td>").text(item.ponderadoFuncional)
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
    fetch("Combima1AlistamientoMaterial/EnviarDatos", {
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
    $.getJSON('/Combima1AlistamientoMaterial/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var AlistamientoMaterialRequerido3N = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbAlistamientoMaterialRequerido3N").html("");
        $("select#cbAlistamientoMaterialRequerido3Ne").html("");
        $.each(AlistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido3N + '>' + this.descAlistamientoMaterialRequerido3N + '</option>'
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

