﻿var tblJesehinEjercicioTipoArmaMenorJesehin;

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
                                url: '/JesehinEjercicioTipoArmaMenorJesehin/Insertar',
                                data: {
                                    'TipoPersonalMilitarId': $('#cbPersonal').val(),
                                    'GradoPersonalMilitarId': $('#cbGrado').val(),
                                    'FechaEjercicioTipo': $('#txtFecha').val(),
                                    'TipoArmamentoId': $('#cbArmamento').val(),
                                    'PosicionTipoArmaId': $('#cbPosicion').val(),
                                    'DistanciaMetros': $('#txtDistancia').val(),
                                    'CantidadTiro': $('#txtTiro').val(), 
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
                                    $('#tblJesehinEjercicioTipoArmaMenorJesehin').DataTable().ajax.reload();
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
                                url: '/JesehinEjercicioTipoArmaMenorJesehin/Actualizar',
                                data: {
                                    'EjercicioTipoArmaMenorJesehinId': $('#txtCodigo').val(), 
                                    'TipoPersonalMilitarId': $('#cbPersonale').val(),
                                    'GradoPersonalMilitarId': $('#cbGradoe').val(),
                                    'FechaEjercicioTipo': $('#txtFechae').val(),
                                    'TipoArmamentoId': $('#cbArmamentoe').val(),
                                    'PosicionTipoArmaId': $('#cbPosicione').val(),
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
                                    $('#tblJesehinEjercicioTipoArmaMenorJesehin').DataTable().ajax.reload();
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

    $('#tblJesehinEjercicioTipoArmaMenorJesehin').DataTable({
        ajax: {
            "url": '/JesehinEjercicioTipoArmaMenorJesehin/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ejercicioTipoArmaMenorJesehinId" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "fechaEjercicioTipo" },
            { "data": "descTipoArmamento" },
            { "data": "descPosicionTipoArma" },
            { "data": "distanciaMetros" },  
            { "data": "cantidadTiro" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ejercicioTipoArmaMenorJesehinId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ejercicioTipoArmaMenorJesehinId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Jesehin - Ejercicios de Tiro con Armas Menores',
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
                filename: 'Jesehin - Ejercicios de Tiro con Armas Menores',
                title: 'Jesehin - Ejercicios de Tiro con Armas Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Jesehin - Ejercicios de Tiro con Armas Menores',
                title: 'Jesehin - Ejercicios de Tiro con Armas Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Jesehin - Ejercicios de Tiro con Armas Menores',
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/JesehinEjercicioTipoArmaMenorJesehin/Mostrar?Id=' + Id, [], function (EjercicioTipoArmaMenorJesehinDTO) {
        $('#txtCodigo').val(EjercicioTipoArmaMenorJesehinDTO.ejercicioTipoArmaMenorJesehinId);
        $('#cbPersonale').val(EjercicioTipoArmaMenorJesehinDTO.tipoPersonalMilitarId);
        $('#cbGradoe').val(EjercicioTipoArmaMenorJesehinDTO.gradoPersonalMilitarId);
        $('#txtFechae').val(EjercicioTipoArmaMenorJesehinDTO.fechaEjercicioTipo);
        $('#cbArmamentoe').val(EjercicioTipoArmaMenorJesehinDTO.tipoArmamentoId);
        $('#cbPosicione').val(EjercicioTipoArmaMenorJesehinDTO.posicionTipoArmaId);
        $('#txtDistanciae').val(EjercicioTipoArmaMenorJesehinDTO.distanciaMetros);
        $('#txtTiroe').val(EjercicioTipoArmaMenorJesehinDTO.cantidadTiro); 
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
                url: '/JesehinEjercicioTipoArmaMenorJesehin/Eliminar',
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
                    $('#tblJesehinEjercicioTipoArmaMenorJesehin').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaJesehinEjercicioTipoArmaMenorJesehin() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            console.log(dataJson);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.nombreTemaEstudioInvestigacion),
                        $("<td>").text(item.tipoEstudioInvestigacion),
                        $("<td>").text(item.fechaInicio),
                        $("<td>").text(item.fechaTermino),
                        $("<td>").text(item.responsable),
                        $("<td>").text(item.solicitante)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            alert(dataJson.mensaje);
        })
}


function cargaDatos() {
    $.getJSON('/JesehinEjercicioTipoArmaMenorJesehin/cargaCombs', [], function (Json) {
        var tipoPersonalMilitar = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var tipoArmamento = Json["data3"];
        var posicionTipoArma = Json["data4"];

        $("select#cbPersonal").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.tipoPersonalMilitarId + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbPersonal").append(RowContent);
        });
        $("select#cbPersonale").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.tipoPersonalMilitarId + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbPersonale").append(RowContent);
        });

        $("select#cbGrado").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGrado").append(RowContent);
        });
        $("select#cbGradoe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.gradoPersonalMilitarId + '>' + this.descGrado + '</option>'
            $("select#cbGradoe").append(RowContent);
        });

        $("select#cbArmamento").html("");
        $.each(tipoArmamento, function () {
            var RowContent = '<option value=' + this.tipoArmamentoId + '>' + this.descTipoArmamento + '</option>'
            $("select#cbArmamento").append(RowContent);
        });
        $("select#cbArmamentoe").html("");
        $.each(tipoArmamento, function () {
            var RowContent = '<option value=' + this.tipoArmamentoId + '>' + this.descTipoArmamento + '</option>'
            $("select#cbArmamentoe").append(RowContent);
        });

        $("select#cbPosicion").html("");
        $.each(posicionTipoArma, function () {
            var RowContent = '<option value=' + this.posicionTipoArmaId + '>' + this.descPosicionTipoArma + '</option>'
            $("select#cbPosicion").append(RowContent);
        });
        $("select#cbPosicione").html("");
        $.each(posicionTipoArma, function () {
            var RowContent = '<option value=' + this.posicionTipoArmaId + '>' + this.descPosicionTipoArma + '</option>'
            $("select#cbPosicione").append(RowContent);
        });


    }) 
}

