﻿var tblCombasnaiMovilidadFlotaPesadaLiviana;

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
                                url: '/CombasnaiMovilidadFlotaPesadaLiviana/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'ClaseFlotaId': $('#cbClaseFlota').val(),
                                    'DependenciaId': $('#cbDependencia').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeo').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeo').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeo').val(),
                                    'CapacidadOperativaRequeridaId': $('#cbCapacidadOperativaRequerida').val(),
                                    'CondicionId': $('#cbCondicion').val(),
                                    'Observacion': $('#txtObservacion').val(), 
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
                                    $('#tblCombasnaiMovilidadFlotaPesadaLiviana').DataTable().ajax.reload();
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
                                url: '/CombasnaiMovilidadFlotaPesadaLiviana/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'ClaseFlotaId': $('#cbClaseFlotae').val(),
                                    'DependenciaId': $('#cbDependenciae').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeoe').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeoe').val(),
                                    'CapacidadOperativaRequeridaId': $('#cbCapacidadOperativaRequeridae').val(),
                                    'CondicionId': $('#cbCondicione').val(),
                                    'Observacion': $('#txtObservacione').val(), 
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
                                    $('#tblCombasnaiMovilidadFlotaPesadaLiviana').DataTable().ajax.reload();
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

    $('#tblCombasnaiMovilidadFlotaPesadaLiviana').DataTable({
        ajax: {
            "url": '/CombasnaiMovilidadFlotaPesadaLiviana/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "movilidadFlotaPesadaLivianaId" },
            { "data": "descUnidadNaval" },
            { "data": "descClaseFlota" },
            { "data": "descDependencia" },
            { "data": "ubicacion" },
            { "data": "descDepartamentoUbigeo" },
            { "data": "descProvinciaUbigeo" },
            { "data": "descDistritoUbigeo" },
            { "data": "descCapacidadOperativaRequerida" },
            { "data": "descCondicion" },
            { "data": "observacion" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.movilidadFlotaPesadaLivianaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.movilidadFlotaPesadaLivianaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresuval - Situación de Movilidades de Flota Pesada y Liviana',
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
                filename: 'Diresuval - Situación de Movilidades de Flota Pesada y Liviana',
                title: 'Diresuval - Situación de Movilidades de Flota Pesada y Liviana',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresuval - Situación de Movilidades de Flota Pesada y Liviana',
                title: 'Diresuval - Situación de Movilidades de Flota Pesada y Liviana',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresuval - Situación de Movilidades de Flota Pesada y Liviana',
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

});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/CombasnaiMovilidadFlotaPesadaLiviana/Mostrar?Id=' + Id, [], function (MovilidadFlotaPesadaLivianaCombasnaiDTO) {
        $('#txtCodigo').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.movilidadFlotaPesadaLivianaId);
        $('#cbUnidadNavale').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.unidadNavalId);
        $('#cbClaseFlotae').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.claseFlotaId);
        $('#cbDependenciae').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.dependenciaId);
        $('#txtUbicacione').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.ubicacion);
        $('#cbDepartamentoUbigeoe').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.departamentoUbigeoId);
        $('#cbProvinciaUbigeoe').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.provinciaUbigeoId);
        $('#cbDistritoUbigeoe').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.distritoUbigeoId);
        $('#cbCapacidadOperativaRequeridae').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.capacidadOperativaRequeridaId);
        $('#cbCondicione').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.condicionId);
        $('#txtObservacione').val(MovilidadFlotaPesadaLivianaCombasnaiDTO.observacion); 
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
                url: '/CombasnaiMovilidadFlotaPesadaLiviana/Eliminar',
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
                    $('#tblCombasnaiMovilidadFlotaPesadaLiviana').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaCombasnaiMovilidadFlotaPesadaLiviana() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("CombasnaiMovilidadFlotaPesadaLiviana/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.unidadNavalId),
                        $("<td>").text(item.claseFlotaId),
                        $("<td>").text(item.dependenciaId),
                        $("<td>").text(item.ubicacion),
                        $("<td>").text(item.departamentoUbigeoId),
                        $("<td>").text(item.provinciaUbigeoId),
                        $("<td>").text(item.distritoUbigeoId),
                        $("<td>").text(item.capacidadOperativaRequeridaId),
                        $("<td>").text(item.condicionId),
                        $("<td>").text(item.observacion),
                    )
                )
            })
        })

}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("CombasnaiMovilidadFlotaPesadaLiviana/EnviarDatos", {
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
    $.getJSON('/CombasnaiMovilidadFlotaPesadaLiviana/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var ClaseFlota = Json["data2"];
        var Dependencia = Json["data3"];
        var DepartamentoUbigeo = Json["data4"];
        var ProvinciaUbigeo = Json["data5"];
        var DistritoUbigeo = Json["data6"];
        var CapacidadOperativaRequerida = Json["data7"];
        var Condicion = Json["data8"];

        $("select#cbUnidadNaval").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbClaseFlota").html("");
        $.each(ClaseFlota, function () {
            var RowContent = '<option value=' + this.claseFlotaId + '>' + this.descClaseFlota + '</option>'
            $("select#cbClaseFlota").append(RowContent);
        });
        $("select#cbClaseFlotae").html("");
        $.each(ClaseFlota, function () {
            var RowContent = '<option value=' + this.claseFlotaId + '>' + this.descClaseFlota + '</option>'
            $("select#cbClaseFlotae").append(RowContent);
        });


        $("select#cbDependencia").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.dependenciaId + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbDepartamentoUbigeo").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeo").append(RowContent);
        });
        $("select#cbDepartamentoUbigeoe").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeoe").append(RowContent);
        });


        $("select#cbProvinciaUbigeo").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUbigeo").append(RowContent);
        });
        $("select#cbProvinciaUbigeoe").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUbigeoe").append(RowContent);
        });


        $("select#cbDistritoUbigeo").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeo").append(RowContent);
        });
        $("select#cbDistritoUbigeoe").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });


        $("select#cbCapacidadOperativaRequerida").html("");
        $.each(CapacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.capacidadOperativaRequeridaId + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequerida").append(RowContent);
        });
        $("select#cbCapacidadOperativaRequeridae").html("");
        $.each(CapacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.capacidadOperativaRequeridaId + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequeridae").append(RowContent);
        });


        $("select#cbCondicion").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#cbCondicion").append(RowContent);
        });
        $("select#cbCondicione").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#cbCondicione").append(RowContent);
        }); 

    });
}

