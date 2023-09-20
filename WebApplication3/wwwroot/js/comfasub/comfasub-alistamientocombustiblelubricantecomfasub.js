var tblComfasubAlistamientoCombustibleLubricanteComfasub;


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
                                url: '/ComfasubAlistamientoCombustibleLubricanteComfasub/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'CodigoAlistamientoCombustibleLubricante': $('#cbAlistamientoCombustibleLubricante').val(),
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
                                    $('#tblComfasubAlistamientoCombustibleLubricanteComfasub').DataTable().ajax.reload();
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
                                url: '/ComfasubAlistamientoCombustibleLubricanteComfasub/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoAlistamientoCombustibleLubricante': $('#cbAlistamientoCombustibleLubricantee').val(),
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
                                    $('#tblComfasubAlistamientoCombustibleLubricanteComfasub').DataTable().ajax.reload();
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

   tblComfasubAlistamientoCombustibleLubricanteComfasub = $('#tblComfasubAlistamientoCombustibleLubricanteComfasub').DataTable({
        ajax: {
            "url": '/ComfasubAlistamientoCombustibleLubricanteComfasub/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoCombustibleLubricanteComfasubId" },
            { "data": "descUnidadNaval" },
            { "data": "descSistemaCombustibleLubricante" },
            { "data": "descSubsistemaCombustibleLubricante" },
            { "data": "equipo" },
            { "data": "combustibleLubricante" },
            { "data": "existente" },
            { "data": "necesariasGLS" },
            { "data": "coeficientePonderacion" },
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoCombustibleLubricanteComfasubId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoCombustibleLubricanteComfasubId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfasub - Alistamiento de combustibles y lubricantes (ACL)',
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
                filename: 'Comfasub - Alistamiento de combustibles y lubricantes (ACL)',
                title: 'Comfasub - Alistamiento de combustibles y lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfasub - Alistamiento de combustibles y lubricantes (ACL)',
                title: 'Comfasub - Alistamiento de combustibles y lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfasub - Alistamiento de combustibles y lubricantes (ACL)',
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
    tblComfasubAlistamientoCombustibleLubricanteComfasub.columns(3).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfasubAlistamientoCombustibleLubricanteComfasub.columns(3).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfasubAlistamientoCombustibleLubricanteComfasub/Mostrar?Id=' + Id, [], function (AlistamientoCombustibleLubricanteComfasubDTO) {
        $('#txtCodigo').val(AlistamientoCombustibleLubricanteComfasubDTO.alistamientoCombustibleLubricanteComfasubId);
        $('#cbUnidadNavale').val(AlistamientoCombustibleLubricanteComfasubDTO.codigoUnidadNaval);
        $('#cbAlistamientoCombustibleLubricantee').val(AlistamientoCombustibleLubricanteComfasubDTO.codigoAlistamientoCombustibleLubricante);

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
                url: '/ComfasubAlistamientoCombustibleLubricanteComfasub/Eliminar',
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
                    $('#tblComfasubAlistamientoCombustibleLubricanteComfasub').DataTable().ajax.reload();
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
                url: '/ComfasubAlistamientoCombustibleLubricanteComfasub/EliminarCarga',
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
                    $('#tblComfasubAlistamientoCombustibleLubricanteComfasub').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfasubAlistamientoCombustibleLubricanteComfasub/MostrarDatos',
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
                            $("<td>").text(item.codigoAlistamientoCombustibleLubricante)

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
    fetch("ComfasubAlistamientoCombustibleLubricanteComfasub/EnviarDatos", {
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

function nuevaComfasubAlistamientoCombustibleLubricanteComfasub() {
    $('#listar').hide();
    $('#nuevo').show();
}


function cargaDatos() {
    $.getJSON('/ComfasubAlistamientoCombustibleLubricanteComfasub/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var alistamientoCombustibleLubricante = Json["data2"];
        var listaCargas = Json["data3"];


        $("select#cbUnidadNaval").html("");
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
            $("select#cbUnidadNavale").append(RowContent);
        });

        $("select#cbAlistamientoCombustibleLubricante").html("");
        $("select#cbAlistamientoCombustibleLubricantee").html("");
        $.each(alistamientoCombustibleLubricante, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoCombustibleLubricante + '>' + this.codigoAlistamientoCombustibleLubricante + '</option>'
            $("select#cbAlistamientoCombustibleLubricante").append(RowContent);
            $("select#cbAlistamientoCombustibleLubricantee").append(RowContent);
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

//$('select#cbAlistamientoCombustibleLubricante').on('change', function () {

//    var codigo = $(this).val();

//    $.each(alistamientoCombustibleLubricante, function () {
//        if (this.CodigoAlistamientoCombustibleLubricante == codigo) {
//            $("input#txtSubsistemaCombustibleLubricante").val(this.descSubsistemaCombustibleLubricante);
//            $("input#txtEquipo").val(this.equipo);
//            $("input#txtCombustibleLubricante").val(this.combustibleLubricante);
//            $("input#txtExistente").val(this.existente);
//            $("input#txtNecesariasGLS").val(this.necesariasGLS);
//            $("input#txtCoeficientePonderacion").val(this.coeficientePonderacion);
//        }
//    });
//});

//$('select#cbAlistamientoCombustibleLubricante').on('change', function () {

//    var codigo = $(this).val();

//    $.each(alistamientoCombustibleLubricante, function () {
//        if (this.CodigoAlistamientoCombustibleLubricante == codigo) {
//            $("input#txtSubsistemaCombustibleLubricantee").val(this.descSubsistemaCombustibleLubricante);
//            $("input#txtEquipoe").val(this.equipo);
//            $("input#txtCombustibleLubricantee").val(this.combustibleLubricante);
//            $("input#txtExistentee").val(this.existente);
//            $("input#txtNecesariasGLSe").val(this.necesariasGLS);
//            $("input#txtCoeficientePonderacione").val(this.coeficientePonderacion);
//        }
//    });
//});