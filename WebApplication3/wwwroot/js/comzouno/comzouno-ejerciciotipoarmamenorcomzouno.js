var tblComzounoEjercicioTipoArmaMenorComzouno;

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
                                url: '/ComzounoEjercicioTipoArmaMenorComzouno/Insertar',
                                data: {
                                    'CodigoTipoPersonalMilitar': $('#cbPersonal').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGrado').val(),
                                    'FechaEjercicioTipo': $('#txtFecha').val(),
                                    'CodigoTipoArmamento': $('#cbArmamento').val(),
                                    'CodigoPosicionTipoArma': $('#cbPosicion').val(),
                                    'DistanciaMetros': $('#txtDistancia').val(),
                                    'CantidadTiro': $('#txtTiro').val(),
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
                                    $('#tblComzounoEjercicioTipoArmaMenorComzouno').DataTable().ajax.reload();
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
                                url: '/ComzounoEjercicioTipoArmaMenorComzouno/Actualizar',
                                data: {
                                    'EjercicioTipoArmaMenorComzounoId': $('#txtCodigo').val(), 
                                    'CodigoTipoPersonalMilitar': $('#cbPersonale').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoe').val(),
                                    'FechaEjercicioTipo': $('#txtFechae').val(),
                                    'CodigoTipoArmamento': $('#cbArmamentoe').val(),
                                    'CodigoPosicionTipoArma': $('#cbPosicione').val(),
                                    'DistanciaMetros': $('#txtDistanciae').val(),
                                    'CantidadTiro': $('#txtTiroe').val(), 
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
                                    $('#tblComzounoEjercicioTipoArmaMenorComzouno').DataTable().ajax.reload();
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

    tblComzounoEjercicioTipoArmaMenorComzouno = $('#tblComzounoEjercicioTipoArmaMenorComzouno').DataTable({
        ajax: {
            "url": '/ComzounoEjercicioTipoArmaMenorComzouno/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ejercicioTipoArmaMenorComzounoId" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "fechaEjercicioTipo" },
            { "data": "descTipoArmamento" },
            { "data": "descPosicionTipoArma" },
            { "data": "distanciaMetros" },  
            { "data": "cantidadTiro" },
            { "data": "cargaId" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ejercicioTipoArmaMenorComzounoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ejercicioTipoArmaMenorComzounoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzouno - Ejercicios de Tiro con Armas Menores',
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
                filename: 'Comzouno - Ejercicios de Tiro con Armas Menores',
                title: 'Comzouno - Ejercicios de Tiro con Armas Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzouno - Ejercicios de Tiro con Armas Menores',
                title: 'Comzouno - Ejercicios de Tiro con Armas Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzouno - Ejercicios de Tiro con Armas Menores',
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
    tblComzounoEjercicioTipoArmaMenorComzouno.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComzounoEjercicioTipoArmaMenorComzouno.columns(8).search('').draw();
}



function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzounoEjercicioTipoArmaMenorComzouno/Mostrar?Id=' + Id, [], function (EjercicioTipoArmaMenorComzounoDTO) {
        $('#txtCodigo').val(EjercicioTipoArmaMenorComzounoDTO.ejercicioTipoArmaMenorComzounoId);
        $('#cbPersonale').val(EjercicioTipoArmaMenorComzounoDTO.codigoTipoPersonalMilitar);
        $('#cbGradoe').val(EjercicioTipoArmaMenorComzounoDTO.codigoGradoPersonalMilitar);
        $('#txtFechae').val(EjercicioTipoArmaMenorComzounoDTO.fechaEjercicioTipo);
        $('#cbArmamentoe').val(EjercicioTipoArmaMenorComzounoDTO.codigoTipoArmamento);
        $('#cbPosicione').val(EjercicioTipoArmaMenorComzounoDTO.codigoPosicionTipoArma);
        $('#txtDistanciae').val(EjercicioTipoArmaMenorComzounoDTO.distanciaMetros);
        $('#txtTiroe').val(EjercicioTipoArmaMenorComzounoDTO.cantidadTiro); 
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
                url: '/ComzounoEjercicioTipoArmaMenorComzouno/Eliminar',
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
                    $('#tblComzounoEjercicioTipoArmaMenorComzouno').DataTable().ajax.reload();
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
                url: '/ComzounoEjercicioTipoArmaMenorComzouno/EliminarCarga',
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
                    $('#tblComzounoEjercicioTipoArmaMenorComzouno').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComzounoEjercicioTipoArmaMenorComzouno() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComzounoEjercicioTipoArmaMenorComzouno/MostrarDatos',
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
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.fechaEjercicioTipo),
                            $("<td>").text(item.codigoTipoArmamento),
                            $("<td>").text(item.codigoPosicionTipoArma),
                            $("<td>").text(item.distanciaMetros),
                            $("<td>").text(item.cantidadTiro)

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
    fetch("ComzounoEjercicioTipoArmaMenorComzouno/EnviarDatos", {
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
    $.getJSON('/ComzounoEjercicioTipoArmaMenorComzouno/cargaCombs', [], function (Json) {
        var tipoPersonalMilitar = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var tipoArmamento = Json["data3"];
        var posicionTipoArma = Json["data4"];
        var listaCargas = Json["data5"];

            $("select#cbPersonal").html("");
            $("select#cbPersonale").html("");
            $.each(tipoPersonalMilitar, function () {
                var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
                $("select#cbPersonal").append(RowContent);
                $("select#cbPersonale").append(RowContent);
            });

            $("select#cbGrado").html("");
            $("select#cbGradoe").html("");
            $.each(gradoPersonalMilitar, function () {
                var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
                $("select#cbGrado").append(RowContent);
                $("select#cbGradoe").append(RowContent);
            });

            $("select#cbArmamento").html("");
            $("select#cbArmamentoe").html("");
            $.each(tipoArmamento, function () {
                var RowContent = '<option value=' + this.codigoTipoArmamento + '>' + this.descTipoArmamento + '</option>'
                $("select#cbArmamento").append(RowContent);
                $("select#cbArmamentoe").append(RowContent);
            });

            $("select#cbPosicion").html("");
            $("select#cbPosicione").html("");
            $.each(posicionTipoArma, function () {
                var RowContent = '<option value=' + this.codigoPosicionTipoArma + '>' + this.descPosicionTipoArma + '</option>'
                $("select#cbPosicion").append(RowContent);
                $("select#cbPosicione").append(RowContent);
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

