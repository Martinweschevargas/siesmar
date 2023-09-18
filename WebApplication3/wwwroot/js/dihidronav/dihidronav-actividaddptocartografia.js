var tblDihidronavActividadDptoCartografia;

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
                                url: '/DihidronavActividadDptoCartografia/Insertar',
                                data: {
                                    'NumeroOrden': $('#txtOrden').val(),
                                    'Requerimiento': $('#txtRequerimiento').val(),
                                    'CodigoTipoCarta': $('#cbCarta').val(),
                                    'Proceso': $('#txtProceso').val(),
                                    'Clasificacion': $('#txtClasificacion').val(),
                                    'CodigoNombre': $('#txtNombre').val(),
                                    'Edicion': $('#txtEdicion').val(),
                                    'Escala': $('#txtEscala').val(),
                                    'SituacionPorcentaje': $('#txtSituacion').val(),
                                    'FechaAutorizacionProduccion': $('#txtFechaAutori').val(),
                                    'FechaTerminoCarta': $('#txtFechaTer').val(),
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
                                    $('#tblDihidronavActividadDptoCartografia').DataTable().ajax.reload();
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
                                url: '/DihidronavActividadDptoCartografia/Actualizar',
                                data: {

                                    'ActividadDptoCartografiaId': $('#txtCodigo').val(),
                                    'NumeroOrden': $('#txtOrdene').val(),
                                    'Requerimiento': $('#txtRequerimientoe').val(),
                                    'CodigoTipoCarta': $('#cbCartae').val(),
                                    'Proceso': $('#txtProcesoe').val(),
                                    'Clasificacion': $('#txtClasificacione').val(),
                                    'CodigoNombre': $('#txtNombree').val(),
                                    'Edicion': $('#txtEdicione').val(),
                                    'Escala': $('#txtEscalae').val(),
                                    'SituacionPorcentaje': $('#txtSituacione').val(),
                                    'FechaAutorizacionProduccion': $('#txtFechaAutorie').val(),
                                    'FechaTerminoCarta': $('#txtFechaTere').val(), 
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
                                    $('#tblDihidronavActividadDptoCartografia').DataTable().ajax.reload();
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

tblDihidronavActividadDptoCartografia =    $('#tblDihidronavActividadDptoCartografia').DataTable({
        ajax: {
            "url": '/DihidronavActividadDptoCartografia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "actividadDptoCartografiaId" },
            { "data": "numeroOrden" },
            { "data": "requerimiento" },
            { "data": "descTipoCarta" },
            { "data": "proceso" },
            { "data": "clasificacion" },
            { "data": "codigoNombre" },  
            { "data": "edicion" },
            { "data": "escala" }, 
            { "data": "situacionPorcentaje" },
            { "data": "fechaAutorizacionProduccion" },
            { "data": "fechaTerminoCarta" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.actividadDptoCartografiaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.actividadDptoCartografiaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dihidronav - Actividades del Departamento de Cartografía',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dihidronav - Actividades del Departamento de Cartografía',
                title: 'Dihidronav - Actividades del Departamento de Cartografía',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dihidronav - Actividades del Departamento de Cartografía',
                title: 'Dihidronav - Actividades del Departamento de Cartografía',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dihidronav - Actividades del Departamento de Cartografía',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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
    tblDihidronavActividadDptoCartografia.columns(13).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDihidronavActividadDptoCartografia.columns(13).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DihidronavActividadDptoCartografia/Mostrar?Id=' + Id, [], function (ActividadDptoCartografiaDTO) {
        $('#txtCodigo').val(ActividadDptoCartografiaDTO.actividadDptoCartografiaId);
        $('#txtOrdene').val(ActividadDptoCartografiaDTO.numeroOrden);
        $('#txtRequerimientoe').val(ActividadDptoCartografiaDTO.requerimiento);
        $('#cbCartae').val(ActividadDptoCartografiaDTO.codigoTipoCarta);
        $('#txtProcesoe').val(ActividadDptoCartografiaDTO.proceso);
        $('#txtClasificacione').val(ActividadDptoCartografiaDTO.clasificacion);
        $('#txtNombree').val(ActividadDptoCartografiaDTO.codigoNombre);
        $('#txtEdicione').val(ActividadDptoCartografiaDTO.edicion);
        $('#txtEscalae').val(ActividadDptoCartografiaDTO.escala);
        $('#txtSituacione').val(ActividadDptoCartografiaDTO.situacionPorcentaje);
        $('#txtFechaAutorie').val(ActividadDptoCartografiaDTO.fechaAutorizacionProduccion);
        $('#txtFechaTere').val(ActividadDptoCartografiaDTO.fechaTerminoCarta); 
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
                url: '/DihidronavActividadDptoCartografia/Eliminar',
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
                    $('#tblDihidronavActividadDptoCartografia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDihidronavActividadDptoCartografia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DihidronavActividadDptoCartografia/MostrarDatos',
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
                            $("<td>").text(item.requerimiento),
                            $("<td>").text(item.codigoTipoCarta),
                            $("<td>").text(item.proceso),
                            $("<td>").text(item.clasificacion),
                            $("<td>").text(item.codigoNombre),
                            $("<td>").text(item.edicion),
                            $("<td>").text(item.escala),
                            $("<td>").text(item.situacionPorcentaje),
                            $("<td>").text(item.fechaAutorizacionProduccion),
                            $("<td>").text(item.fechaTerminoCarta)
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
    fetch("DihidronavActividadDptoCartografia/EnviarDatos", {
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
    $.getJSON('/DihidronavActividadDptoCartografia/cargaCombs', [], function (Json) {
        var tipoCarta = Json["data1"];
        var listaCargas = Json["data2"];

        $("select#cbCarta").html("");
        $.each(tipoCarta, function () {
            var RowContent = '<option value=' + this.codigoTipoCarta + '>' + this.descTipoCarta + '</option>'
            $("select#cbCarta").append(RowContent);
        });
        $("select#cbCartae").html("");
        $.each(tipoCarta, function () {
            var RowContent = '<option value=' + this.codigoTipoCarta + '>' + this.descTipoCarta + '</option>'
            $("select#cbCartae").append(RowContent);
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

