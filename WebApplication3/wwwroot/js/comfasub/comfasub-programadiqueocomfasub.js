var tblComfasubProgramaDiqueoComfasub;

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
                                url: '/ComfasubProgramaDiqueoComfasub/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidad').val(),
                                    'CodigoAlistamientoMaterialRequerido2N': $('#cbAlis2').val(),
                                    'FechaIngreso': $('#txtFechaIngreso').val(),
                                    'FechaSalida': $('#txtFechaSalida').val(),
                                    'PermanenciaDia': $('#txtPermanencia').val(),
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
                                    $('#tblComfasubProgramaDiqueoComfasub').DataTable().ajax.reload();
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
                                url: '/ComfasubProgramaDiqueoComfasub/Actualizar',
                                data: {

                                    'ProgramaDiqueoComfasubId': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidade').val(),
                                    'CodigoAlistamientoMaterialRequerido2N': $('#cbAlis2e').val(),
                                    'FechaIngreso': $('#txtFechaIngresoe').val(),
                                    'FechaSalida': $('#txtFechaSalidae').val(),
                                    'PermanenciaDia': $('#txtPermanenciae').val(), 
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
                                    $('#tblComfasubProgramaDiqueoComfasub').DataTable().ajax.reload();
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

   tblComfasubProgramaDiqueoComfasub = $('#tblComfasubProgramaDiqueoComfasub').DataTable({
        ajax: {
            "url": '/ComfasubProgramaDiqueoComfasub/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "programaDiqueoComfasubId" },
            { "data": "descUnidadNaval" },
            { "data": "capacidadIntrinseca" },
            { "data": "subclasificacion" },
            { "data": "fechaIngreso" },
            { "data": "fechaSalida" },
            { "data": "permanenciaDia" },
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.programaDiqueoComfasubId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.programaDiqueoComfasubId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfasub - Programa de Diqueo',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfasub - Programa de Diqueo',
                title: 'Comfasub - Programa de Diqueo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfasub - Programa de Diqueo',
                title: 'Comfasub - Programa de Diqueo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfasub - Programa de Diqueo',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6]
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
    tblComfasubProgramaDiqueoComfasub.columns(7).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfasubProgramaDiqueoComfasub.columns(7).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfasubProgramaDiqueoComfasub/Mostrar?Id=' + Id, [], function (ProgramaDiqueoComfasubDTO) {
        $('#txtCodigo').val(ProgramaDiqueoComfasubDTO.programaDiqueoComfasubId);
        $('#cbUnidade').val(ProgramaDiqueoComfasubDTO.codigoUnidadNaval);
        $('#cbAlis2e').val(ProgramaDiqueoComfasubDTO.codigoAlistamientoMaterialRequerido2N);
        $('#txtFechaIngresoe').val(ProgramaDiqueoComfasubDTO.fechaIngreso);
        $('#txtFechaSalidae').val(ProgramaDiqueoComfasubDTO.fechaSalida);
        $('#txtPermanenciae').val(ProgramaDiqueoComfasubDTO.permanenciaDia); 
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
                url: '/ComfasubProgramaDiqueoComfasub/Eliminar',
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
                    $('#tblComfasubProgramaDiqueoComfasub').DataTable().ajax.reload();
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
                url: '/ComfasubProgramaDiqueoComfasub/EliminarCarga',
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
                    $('#tblComfasubProgramaDiqueoComfasub').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComfasubProgramaDiqueoComfasub() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfasubProgramaDiqueoComfasub/MostrarDatos',
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
                            $("<td>").text(item.codigoAlistamientoMaterialRequerido2N),
                            $("<td>").text(item.fechaIngreso),
                            $("<td>").text(item.fechaSalida),
                            $("<td>").text(item.permanenciaDia)

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
    fetch("ComfasubProgramaDiqueoComfasub/EnviarDatos", {
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
    $.getJSON('/ComfasubProgramaDiqueoComfasub/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var materialrequerido2N = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbUnidad").html("");
        $("select#cbUnidade").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidad").append(RowContent);
            $("select#cbUnidade").append(RowContent);
        });

        $("select#cbAlis2").html("");
        $("select#cbAlis2e").html("");
        $.each(materialrequerido2N, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoMaterialRequerido2N + '>' + this.codigoAlistamientoMaterialRequerido2N + '</option>'
            $("select#cbAlis2").append(RowContent);
            $("select#cbAlis2e").append(RowContent);
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

