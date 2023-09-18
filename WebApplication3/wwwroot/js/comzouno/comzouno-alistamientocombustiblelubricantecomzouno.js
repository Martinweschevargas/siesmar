var tblComzounoAlistamientoCombustibleLubricanteComzouno;

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
                                url: '/ComzounoAlistamientoCombustibleLubricanteComzouno/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'CodigoAlistamientoCombustibleLubricante2': $('#cbAlistamientoCombustibleLubricante2').val(),
                                    'PromedioPonderado': $('#txtPromedioPonderado').val(),
                                    'SubPromedioParcial': $('#txtSubPromedio').val(),
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
                                    $('#tblComzounoAlistamientoCombustibleLubricanteComzouno').DataTable().ajax.reload();
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
                                url: '/ComzounoAlistamientoCombustibleLubricanteComzouno/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoAlistamientoCombustibleLubricante2': $('#cbAlistamientoCombustibleLubricante2e').val(),
                                    'PromedioPonderado': $('#txtPromedioPonderadoe').val(),
                                    'SubPromedioParcial': $('#txtSubPromedioe').val(),
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
                                    $('#tblComzounoAlistamientoCombustibleLubricanteComzouno').DataTable().ajax.reload();
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

   tblComzounoAlistamientoCombustibleLubricanteComzouno = $('#tblComzounoAlistamientoCombustibleLubricanteComzouno').DataTable({
        ajax: {
            "url": '/ComzounoAlistamientoCombustibleLubricanteComzouno/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoCombustibleLubricanteId" },
            { "data": "descUnidadNaval" },
            { "data": "articulo" },
            { "data": "equipo" },
            { "data": "descUnidadMedida" },
            { "data": "cargo" },
            { "data": "aumento" },
            { "data": "consumo" },
            { "data": "existencia" },
            { "data": "promedioPonderado" },
            { "data": "subPromedioParcial" },
            { "data": "cargaId" }, 
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
                filename: 'Comzouno - Alistamiento de combustibles y lubricantes (ACL)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comzouno - Alistamiento de combustibles y lubricantes (ACL)',
                title: 'Comzouno - Alistamiento de combustibles y lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzouno - Alistamiento de combustibles y lubricantes (ACL)',
                title: 'Comzouno - Alistamiento de combustibles y lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzouno - Alistamiento de combustibles y lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
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
    tblComzounoAlistamientoCombustibleLubricanteComzouno.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComzounoAlistamientoCombustibleLubricanteComzouno.columns(11).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzounoAlistamientoCombustibleLubricanteComzouno/Mostrar?Id=' + Id, [], function (AlistamientoCombustibleLubricanteComzounoDTO) {
        $('#txtCodigo').val(AlistamientoCombustibleLubricanteComzounoDTO.alistamientoCombustibleLubricanteId);
        $('#cbUnidadNavale').val(AlistamientoCombustibleLubricanteComzounoDTO.codigoUnidadNaval);
        $('#cbAlistamientoCombustibleLubricante2e').val(AlistamientoCombustibleLubricanteComzounoDTO.codigoAlistamientoCombustibleLubricante2);
        $('#txtPromedioPonderadoe').val(AlistamientoCombustibleLubricanteComzounoDTO.promedioPonderado);
        $('#txtSubPromedioe').val(AlistamientoCombustibleLubricanteComzounoDTO.subPromedioParcial);
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
                url: '/ComzounoAlistamientoCombustibleLubricanteComzouno/Eliminar',
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
                    $('#tblComzounoAlistamientoCombustibleLubricanteComzouno').DataTable().ajax.reload();
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
                url: '/ComzounoAlistamientoCombustibleLubricanteComzouno/EliminarCarga',
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
                    $('#tblComzounoAlistamientoCombustibleLubricanteComzouno').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComzounoAlistamientoCombustibleLubricanteComzouno() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComzounoAlistamientoCombustibleLubricanteComzouno/MostrarDatos',
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
                            $("<td>").text(item.codigoAlistamientoCombustibleLubricante2),
                            $("<td>").text(item.promedioPonderado),
                            $("<td>").text(item.subPromedioParcial)

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
    fetch("ComzounoAlistamientoCombustibleLubricanteComzouno/EnviarDatos", {
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
    $.getJSON('/ComzounoAlistamientoCombustibleLubricanteComzouno/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var alistamientoCombustibleLubricante2 = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbAlistamientoCombustibleLubricante2").html("");
        $("select#cbAlistamientoCombustibleLubricante2e").html("");
        $.each(alistamientoCombustibleLubricante2, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoCombustibleLubricante2 + '>' + this.codigoAlistamientoCombustibleLubricante2 + '</option>'
            $("select#cbAlistamientoCombustibleLubricante2").append(RowContent);
            $("select#cbAlistamientoCombustibleLubricante2e").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });

        //$("select#cbAlistamientoCombustibleLubricante2").html("");
        //$.each(alistamientoCombustibleLubricante2, function () {
        //    var RowContent = '<option value=' + this.alistamientoCombustibleLubricante2Id + '>' + this.alistamientoCombustibleLubricante2Id + '</option>'
        //    $("select#cbAlistamientoCombustibleLubricante2").append(RowContent);

        //    $("input#txtArticuloAlistamiento").val(alistamientoCombustibleLubricante2[0].articulo);
        //    $("input#txtEquipoAlistamiento").val(alistamientoCombustibleLubricante2[0].equipo);
        //    $("input#txtUnidadMedidaAlistamiento").val(alistamientoCombustibleLubricante2[0].unidadMedida);
        //    $("input#txtCargoAlistamiento").val(alistamientoCombustibleLubricante2[0].cargo);
        //    $("input#txtAumentoAlistamiento").val(alistamientoCombustibleLubricante2[0].aumento);
        //    $("input#txtConsumoAlistamiento").val(alistamientoCombustibleLubricante2[0].consumo);
        //    $("input#txtExistenciaAlistamiento").val(alistamientoCombustibleLubricante2[0].existencia);

        //});

        //$("select#cbAlistamientoCombustibleLubricante2e").html("");
        //$.each(alistamientoCombustibleLubricante2, function () {
        //    var RowContent = '<option value=' + this.alistamientoCombustibleLubricante2Id + '>' + this.alistamientoCombustibleLubricante2Id + '</option>'
        //    $("select#cbAlistamientoCombustibleLubricante2e").append(RowContent);
        //});
    });
}

//$('select#cbAlistamientoCombustibleLubricante2').on('change', function () {

//    var codigo = $(this).val();

//    $.each(alistamientoCombustibleLubricante2, function () {
//        if (this.alistamientoCombustibleLubricante2Id == codigo) {
//            $("input#txtArticuloAlistamiento").val(this.articulo);
//            $("input#txtEquipoAlistamiento").val(this.equipo);
//            $("input#txtUnidadMedidaAlistamiento").val(this.unidadMedida);
//            $("input#txtCargoAlistamiento").val(this.cargo);
//            $("input#txtAumentoAlistamiento").val(this.aumento);
//            $("input#txtConsumoAlistamiento").val(this.consumo);
//            $("input#txtExistenciaAlistamiento").val(this.existencia);
//        }
//    });
//});

//$('select#cbAlistamientoCombustibleLubricante2e').on('change', function () {

//    var codigo = $(this).val();

//    $.each(alistamientoCombustibleLubricante2, function () {
//        if (this.alistamientoCombustibleLubricante2Id == codigo) {

//            $("input#txtArticuloAlistamientoe").val(this.articulo);
//            $("input#txtEquipoAlistamientoe").val(this.equipo);
//            $("input#txtUnidadMedidaAlistamientoe").val(this.unidadMedida);
//            $("input#txtCargoAlistamientoe").val(this.cargo);
//            $("input#txtAumentoAlistamientoe").val(this.aumento);
//            $("input#txtConsumoAlistamientoe").val(this.consumo);
//            $("input#txtExistenciaAlistamientoe").val(this.existencia);

//        }
//    });
//});
