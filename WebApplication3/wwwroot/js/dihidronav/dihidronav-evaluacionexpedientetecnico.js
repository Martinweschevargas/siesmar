var tblDihidronavEvaluacionExpedienteTecnico;
var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

$('select#cbProvincia').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
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
                                url: '/DihidronavEvaluacionExpedienteTecnico/Insertar',
                                data: {
                                    'NumeroOrden': $('#txtOrden').val(),
                                    'CodigoTipoEstudio': $('#cbEstudio').val(),
                                    'DescripcionEstudio': $('#txtDescripcion').val(),
                                    'DocumentoRespuesta': $('#txtDocumento').val(),
                                    'FechaTerminoEvaluacion': $('#txtFechaTer').val(),
                                    'EmpresaPersonaSolicitante': $('#txtSolicitante').val(),
                                    'EmpresaRealizaTrabajo': $('#txtRealiza').val(),
                                    'DistritoUbigeo': $('#cbDistrito').val(),
                                    'CondicionEvaluacion': $('#txtCondicion').val(), 
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
                                    $('#tblDihidronavEvaluacionExpedienteTecnico').DataTable().ajax.reload();
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
                                url: '/DihidronavEvaluacionExpedienteTecnico/Actualizar',
                                data: {
                                    'EvaluacionExpedienteTecnicoId': $('#txtCodigo').val(),
                                    'NumeroOrden': $('#txtOrdene').val(),
                                    'CodigoTipoEstudio': $('#cbEstudioe').val(),
                                    'DescripcionEstudio': $('#txtDescripcione').val(),
                                    'DocumentoRespuesta': $('#txtDocumentoe').val(),
                                    'FechaTerminoEvaluacion': $('#txtFechaTere').val(),
                                    'EmpresaPersonaSolicitante': $('#txtSolicitantee').val(),
                                    'EmpresaRealizaTrabajo': $('#txtRealizae').val(),
                                    'DistritoUbigeo': $('#cbDistritoe').val(),
                                    'CondicionEvaluacion': $('#txtCondicione').val(), 
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
                                    $('#tblDihidronavEvaluacionExpedienteTecnico').DataTable().ajax.reload();
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

 tblDihidronavEvaluacionExpedienteTecnico =   $('#tblDihidronavEvaluacionExpedienteTecnico').DataTable({
        ajax: {
            "url": '/DihidronavEvaluacionExpedienteTecnico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "evaluacionExpedienteTecnicoId" },
            { "data": "numeroOrden" },
            { "data": "descTipoEstudio" },
            { "data": "descripcionEstudio" },
            { "data": "documentoRespuesta" },
            { "data": "fechaTerminoEvaluacion" },
            { "data": "empresaPersonaSolicitante" },  
            { "data": "empresaRealizaTrabajo" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDistrito" },
            { "data": "condicionEvaluacion" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.evaluacionExpedienteTecnicoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.evaluacionExpedienteTecnicoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dihidronav - Evaluación de Expediente Técnico',
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
                filename: 'Dihidronav - Evaluación de Expediente Técnico',
                title: 'Dihidronav - Evaluación de Expediente Técnico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dihidronav - Evaluación de Expediente Técnico',
                title: 'Dihidronav - Evaluación de Expediente Técnico',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dihidronav - Evaluación de Expediente Técnico',
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
    tblDihidronavEvaluacionExpedienteTecnico.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDihidronavEvaluacionExpedienteTecnico.columns(11).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DihidronavEvaluacionExpedienteTecnico/Mostrar?Id=' + Id, [], function (EvaluacionExpedienteTecnicoDTO) {
        $('#txtCodigo').val(EvaluacionExpedienteTecnicoDTO.evaluacionExpedienteTecnicoId);
        $('#txtOrdene').val(EvaluacionExpedienteTecnicoDTO.numeroOrden);
        $('#cbEstudioe').val(EvaluacionExpedienteTecnicoDTO.codigoTipoEstudio);
        $('#txtDescripcione').val(EvaluacionExpedienteTecnicoDTO.descripcionEstudio);
        $('#txtDocumentoe').val(EvaluacionExpedienteTecnicoDTO.documentoRespuesta);
        $('#txtFechaTere').val(EvaluacionExpedienteTecnicoDTO.fechaTerminoEvaluacion);
        $('#txtSolicitantee').val(EvaluacionExpedienteTecnicoDTO.empresaPersonaSolicitante);
        $('#txtRealizae').val(EvaluacionExpedienteTecnicoDTO.empresaRealizaTrabajo);
        var iddistrito = EvaluacionExpedienteTecnicoDTO.distritoUbigeo;
        $('#txtCondicione').val(EvaluacionExpedienteTecnicoDTO.condicionEvaluacion); 
        encontrardatocombo(iddistrito);
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
                url: '/DihidronavEvaluacionExpedienteTecnico/Eliminar',
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
                    $('#tblDihidronavEvaluacionExpedienteTecnico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDihidronavEvaluacionExpedienteTecnico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DihidronavEvaluacionExpedienteTecnico/MostrarDatos',
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
                            $("<td>").text(item.codigoTipoEstudio),
                            $("<td>").text(item.descripcionEstudio),
                            $("<td>").text(item.documentoRespuesta),
                            $("<td>").text(item.fechaTerminoEvaluacion),
                            $("<td>").text(item.empresaPersonaSolicitante),
                            $("<td>").text(item.empresaRealizaTrabajo),
                            $("<td>").text(item.distritoUbigeo),
                            $("<td>").text(item.condicionEvaluacion)
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
    fetch("DihidronavEvaluacionExpedienteTecnico/EnviarDatos", {
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
    $.getJSON('/DihidronavEvaluacionExpedienteTecnico/cargaCombs', [], function (Json) {
        var tipoEstudio = Json["data1"];
        departamentoUbigeo = Json["data2"];
        provinciaUbigeo = Json["data3"];
        distritoUbigeo = Json["data4"];
        var listaCargas = Json["data5"];


        $("select#cbEstudio").html("");
        $.each(tipoEstudio, function () {
            var RowContent = '<option value=' + this.codigoTipoEstudio + '>' + this.descTipoEstudio + '</option>'
            $("select#cbEstudio").append(RowContent);
        });
        $("select#cbEstudioe").html("");
        $.each(tipoEstudio, function () {
            var RowContent = '<option value=' + this.codigoTipoEstudio + '>' + this.descTipoEstudio + '</option>'
            $("select#cbEstudioe").append(RowContent);
        });

        $("select#cbDepartamento").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamento").append(RowContent);
        });


        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });

    }); 
}



$('select#cbDepartamento').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvincia").html("");
            $('select#cbProvincia').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvincia").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistrito").html("");
    $('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvincia').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistrito").html("");
            $('select#cbDistrito').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistrito").append(RowContent);
                }
            });
        }
    });
});



$('select#cbDepartamentoe').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciae").html("");
            $('select#cbProvinciae').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciae").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoe").html("");
    $('select#cbDistritoe').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciae').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoe").html("");
            $('select#cbDistritoe').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoe").append(RowContent);
                }
            });
        }
    });
});



function encontrardatocombo(id) {
    var iddistrito = id;

    $.each(distritoUbigeo, function () {
        if (this.distritoUbigeo == iddistrito) {
            var provincia = this.provinciaUbigeo;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoe").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoe").append(RowContent);

                    });
                    $('#cbDepartamentoNacimientoe').val(departamento);
                    $("select#cbProvinciae").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciae").append(RowContent);
                        }
                    });
                    $('#cbProvinciaNacimientoe').val(provincia);
                    $("select#cbDistritoe").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoNacimientoe").append(RowContent);
                        }
                    });
                    $('#cbDistritoe').val(iddistrito);
                }
            });


        }
    });
}
