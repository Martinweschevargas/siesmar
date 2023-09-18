var tblDihidronavImpresionPublicacionAyudaNavegacion;

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
                                url: '/DihidronavImpresionPublicacionAyudaNavegacion/Insertar',
                                data: {
                                    'NumeroOrden': $('#txtOrden').val(),
                                    'CodigoProducto': $('#cbProducto').val(),
                                    'HidronavNumero': $('#txtHidronav').val(),
                                    'FechaEmision': $('#txtFecha').val(),
                                    'NumeroEdicion': $('#txtEdicion').val(),
                                    'CantidadProducida': $('#txtCantidad').val(),
                                    'CodigoFrecuencia': $('#cbFrecuencia').val(), 
                                    'CargaId': $('#cargasR').val()
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
                                    $('#tblDihidronavImpresionPublicacionAyudaNavegacion').DataTable().ajax.reload();
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
                                url: '/DihidronavImpresionPublicacionAyudaNavegacion/Actualizar',
                                data: {

                                    'ImpresionPublicacionAyudaNavegacionId': $('#txtCodigo').val(),
                                    'NumeroOrden': $('#txtOrdene').val(),
                                    'CodigoProducto': $('#cbProductoe').val(),
                                    'HidronavNumero': $('#txtHidronave').val(),
                                    'FechaEmision': $('#txtFechae').val(),
                                    'NumeroEdicion': $('#txtEdicione').val(),
                                    'CantidadProducida': $('#txtCantidade').val(),
                                    'CodigoFrecuencia': $('#cbFrecuenciae').val(), 
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
                                    $('#tblDihidronavImpresionPublicacionAyudaNavegacion').DataTable().ajax.reload();
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

 tblDihidronavImpresionPublicacionAyudaNavegacion =   $('#tblDihidronavImpresionPublicacionAyudaNavegacion').DataTable({
        ajax: {
            "url": '/DihidronavImpresionPublicacionAyudaNavegacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "impresionPublicacionAyudaNavegacionId" },
            { "data": "numeroOrden" },
            { "data": "descTipoProducto" },
            { "data": "hidronavNumero" },
            { "data": "fechaEmision" },
            { "data": "numeroEdicion" },
            { "data": "cantidadProducida" },  
            { "data": "descFrecuencia" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.impresionPublicacionAyudaNavegacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.impresionPublicacionAyudaNavegacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dihidronav - Impresión de publicaciones de ayudas a la navegación',
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
                filename: 'Dihidronav - Impresión de publicaciones de ayudas a la navegación',
                title: 'Dihidronav - Impresión de publicaciones de ayudas a la navegación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dihidronav - Impresión de publicaciones de ayudas a la navegación',
                title: 'Dihidronav - Impresión de publicaciones de ayudas a la navegación',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dihidronav - Actividades del Departamento de Cartografía',
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
    tblDihidronavImpresionPublicacionAyudaNavegacion.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDihidronavImpresionPublicacionAyudaNavegacion.columns(8).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DihidronavImpresionPublicacionAyudaNavegacion/Mostrar?Id=' + Id, [], function (ImpresionPublicacionAyudaNavegacionDTO) {
        $('#txtCodigo').val(ImpresionPublicacionAyudaNavegacionDTO.impresionPublicacionAyudaNavegacionId);
        $('#txtOrdene').val(ImpresionPublicacionAyudaNavegacionDTO.numeroOrden);
        $('#cbProductoe').val(ImpresionPublicacionAyudaNavegacionDTO.codigoProducto);
        $('#txtHidronave').val(ImpresionPublicacionAyudaNavegacionDTO.hidronavNumero);
        $('#txtFechae').val(ImpresionPublicacionAyudaNavegacionDTO.fechaEmision);
        $('#txtEdicione').val(ImpresionPublicacionAyudaNavegacionDTO.numeroEdicion);
        $('#txtCantidade').val(ImpresionPublicacionAyudaNavegacionDTO.cantidadProducida);
        $('#cbFrecuenciae').val(ImpresionPublicacionAyudaNavegacionDTO.codigoFrecuencia); 
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
                url: '/DihidronavImpresionPublicacionAyudaNavegacion/Eliminar',
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
                    $('#tblDihidronavImpresionPublicacionAyudaNavegacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDihidronavImpresionPublicacionAyudaNavegacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DihidronavImpresionPublicacionAyudaNavegacion/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            console.log(dataJson);
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.numeroOrden),
                            $("<td>").text(item.codigoProducto),
                            $("<td>").text(item.hidronavNumero),
                            $("<td>").text(item.fechaEmision),
                            $("<td>").text(item.numeroEdicion),
                            $("<td>").text(item.cantidadProducida),
                            $("<td>").text(item.codigoFrecuencia)
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
    fetch("DihidronavImpresionPublicacionAyudaNavegacion/EnviarDatos", {
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
                    'Ocurrio un problema.',
                    'error'
                )
            }
        })
}


function cargaDatos() {
    $.getJSON('/DihidronavImpresionPublicacionAyudaNavegacion/cargaCombs', [], function (Json) {
        var Producto = Json["data1"];
        var frecuencuia = Json["data2"];
        var listaCargas = Json["data3"];
    
        $("select#cbProducto").html("");
        $.each(Producto, function () {
            var RowContent = '<option value=' + this.codigoProducto + '>' + this.descTipoProducto + '</option>'
            $("select#cbProducto").append(RowContent);
        });
        $("select#cbProductoe").html("");
        $.each(Producto, function () {
            var RowContent = '<option value=' + this.codigoProducto + '>' + this.descTipoProducto + '</option>'
            $("select#cbProductoe").append(RowContent);
        }); 

        $("select#cbFrecuencia").html("");
        $.each(frecuencuia, function () {
            var RowContent = '<option value=' + this.codigoFrecuencia + '>' + this.descFrecuencia + '</option>'
            $("select#cbFrecuencia").append(RowContent);
        });
        $("select#cbFrecuenciae").html("");
        $.each(frecuencuia, function () {
            var RowContent = '<option value=' + this.codigoFrecuencia + '>' + this.descFrecuencia + '</option>'
            $("select#cbFrecuenciae").append(RowContent);
        });


        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });


    }) 
}

