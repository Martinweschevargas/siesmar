var tblComfasubNumeroGolpeInterruptorComfasub;

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
                                url: '/ComfasubNumeroGolpeInterruptorComfasub/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidad').val(),
                                    'CodigoEquipoSistemaPropulsion': $('#cbEquipo').val(),
                                    'GolpeFijadoRecorridoTotal': $('#txtTotal').val(),
                                    'GolpeFijadoRecorridoParcial': $('#txtParcial').val(),
                                    'GolpeUltimoRecorrido': $('#txtUltimo').val(),
                                    'GolpeTotalInstalacion': $('#txtInstalacion').val(),
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
                                    $('#tblComfasubNumeroGolpeInterruptorComfasub').DataTable().ajax.reload();
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
                                url: '/ComfasubNumeroGolpeInterruptorComfasub/Actualizar',
                                data: {

                                    'NumeroGolpeInterruptorComfasubId': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidade').val(),
                                    'CodigoEquipoSistemaPropulsion': $('#cbEquipoe').val(),
                                    'GolpeFijadoRecorridoTotal': $('#txtTotale').val(),
                                    'GolpeFijadoRecorridoParcial': $('#txtParciale').val(),
                                    'GolpeUltimoRecorrido': $('#txtUltimoe').val(),
                                    'GolpeTotalInstalacion': $('#txtInstalacione').val(), 
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
                                    $('#tblComfasubNumeroGolpeInterruptorComfasub').DataTable().ajax.reload();
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

   tblComfasubNumeroGolpeInterruptorComfasub = $('#tblComfasubNumeroGolpeInterruptorComfasub').DataTable({
        ajax: {
            "url": '/ComfasubNumeroGolpeInterruptorComfasub/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "numeroGolpeInterruptorComfasubId" },
            { "data": "descUnidadNaval" },
            { "data": "descSistemaPropulsion" },
            { "data": "descSubSistemaPropulsion" },
            { "data": "descEquipoSistemaPropulsion" },
            { "data": "golpeFijadoRecorridoTotal" },
            { "data": "golpeFijadoRecorridoParcial" },  
            { "data": "golpeUltimoRecorrido" },
            { "data": "golpeTotalInstalacion" },
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.numeroGolpeInterruptorComfasubId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.numeroGolpeInterruptorComfasubId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfasub - Número de Golpes de Interruptores Principales',
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
                filename: 'Comfasub - Número de Golpes de Interruptores Principales',
                title: 'Comfasub - Número de Golpes de Interruptores Principales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfasub - Número de Golpes de Interruptores Principales',
                title: 'Comfasub - Número de Golpes de Interruptores Principales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfasub - Número de Golpes de Interruptores Principales',
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
    tblComfasubNumeroGolpeInterruptorComfasub.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfasubNumeroGolpeInterruptorComfasub.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfasubNumeroGolpeInterruptorComfasub/Mostrar?Id=' + Id, [], function (NumeroGolpeInterruptorComfasubDTO) {
        $('#txtCodigo').val(NumeroGolpeInterruptorComfasubDTO.numeroGolpeInterruptorComfasubId);
        $('#cbUnidade').val(NumeroGolpeInterruptorComfasubDTO.codigoUnidadNaval);
        $('#cbEquipoe').val(NumeroGolpeInterruptorComfasubDTO.codigoEquipoSistemaPropulsion);
        $('#txtTotale').val(NumeroGolpeInterruptorComfasubDTO.golpeFijadoRecorridoTotal);
        $('#txtParciale').val(NumeroGolpeInterruptorComfasubDTO.golpeFijadoRecorridoParcial);
        $('#txtUltimoe').val(NumeroGolpeInterruptorComfasubDTO.golpeUltimoRecorrido);
        $('#txtInstalacione').val(NumeroGolpeInterruptorComfasubDTO.golpeTotalInstalacion); 
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
                url: '/ComfasubNumeroGolpeInterruptorComfasub/Eliminar',
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
                    $('#tblComfasubNumeroGolpeInterruptorComfasub').DataTable().ajax.reload();
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
                url: '/ComfasubNumeroGolpeInterruptorComfasub/EliminarCarga',
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
                    $('#tblComfasubNumeroGolpeInterruptorComfasub').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComfasubNumeroGolpeInterruptorComfasub() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfasubNumeroGolpeInterruptorComfasub/MostrarDatos',
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
                            $("<td>").text(item.codigoEquipoSistemaPropulsion),
                            $("<td>").text(item.golpeFijadoRecorridoParcial),
                            $("<td>").text(item.golpeFijadoRecorridoParcial),
                            $("<td>").text(item.golpeUltimoRecorrido),
                            $("<td>").text(item.golpeTotalInstalacion)

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
    fetch("ComfasubNumeroGolpeInterruptorComfasub/EnviarDatos", {
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
    $.getJSON('/ComfasubNumeroGolpeInterruptorComfasub/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var equipoSistemaPropulsion = Json["data2"]; 
        var listaCargas = Json["data3"];


        $("select#cbUnidad").html("");
        $("select#cbUnidade").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidad").append(RowContent);
            $("select#cbUnidade").append(RowContent);
        });

        $("select#cbEquipo").html("");
        $("select#cbEquipoe").html("");
        $.each(equipoSistemaPropulsion, function () {
            var RowContent = '<option value=' + this.codigoEquipoSistemaPropulsion + '>' + this.descEquipoSistemaPropulsion + '</option>'
            $("select#cbEquipo").append(RowContent);
            $("select#cbEquipoe").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    }) 
}

