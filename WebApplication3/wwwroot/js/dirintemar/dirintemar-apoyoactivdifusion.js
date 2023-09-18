var tblDirintemarApoyoActividadesDifusion;

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
                                url: '/DirintemarApoyoActividadesDifusion/Insertar',
                                data: {
                                    'TipoActividadDifusionId': $('#cbTipoActDifusion').val(),
                                    'NombreApoyoActividadDifusion': $('#txtNombreApoyo').val(),
                                    'LugarApoyoActividadDifusion': $('#txtLugarApoyo').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoU').val(),
                                    'DirigidoAId': $('#cbDirigidoApoyo').val(),
                                    'InicioApoyoActividadDifusion': $('#txtFechaI').val(),
                                    'TerminoApoyoActividadDifusion': $('#txtFechaT').val(),
                                    'InversionApoyoActividadDifusion': $('#txtInversion').val()
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
                                    $('#tblDirintemarApoyoActividadesDifusion').DataTable().ajax.reload();
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
                                url: '/DirintemarApoyoActividadesDifusion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoActividadDifusionId': $('#cbTipoActDifusione').val(),
                                    'NombreApoyoActividadDifusion': $('#txtNombreApoyoe').val(),
                                    'LugarApoyoActividadDifusion': $('#txtLugarApoyoe').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUe').val(),
                                    'DirigidoAId': $('#cbDirigidoApoyoe').val(),
                                    'InicioApoyoActividadDifusion': $('#txtFechaIe').val(),
                                    'TerminoApoyoActividadDifusion': $('#txtFechaTe').val(),
                                    'InversionApoyoActividadDifusion': $('#txtInversione').val(),
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
                                    $('#tblDirintemarApoyoActividadesDifusion').DataTable().ajax.reload();
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

    $('#tblDirintemarApoyoActividadesDifusion').DataTable({
        ajax: {
            "url": '/DirintemarApoyoActividadesDifusion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "apoyoActividadDifusionId" },
            { "data": "descTipoActividadDifusion" },
            { "data": "nombreApoyoActividadDifusion" },
            { "data": "lugarApoyoActividadDifusion" },
            { "data": "descDepartamento" },
            { "data": "descDirigidoA" },
            { "data": "inicioApoyoActividadDifusion" },
            { "data": "terminoApoyoActividadDifusion" },
            { "data": "inversionApoyoActividadDifusion" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.apoyoActividadDifusionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.apoyoActividadDifusionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Apoyo a las Actividades de Difusión',
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
                filename: 'Dirintemar - Apoyo a las Actividades de Difusión',
                title: 'Dirintemar - Apoyo a las Actividades de Difusión',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Apoyo a las Actividades de Difusión',
                title: 'Dirintemar - Apoyo a las Actividades de Difusión',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Apoyo a las Actividades de Difusión',
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
});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DirintemarApoyoActividadesDifusion/Mostrar?Id=' + Id , [], function (ApoyoActividadesDifusionDTO) {
        $('#txtCodigo').val(ApoyoActividadesDifusionDTO.apoyoActividadDifusionId);
        $('#cbTipoActDifusione').val(ApoyoActividadesDifusionDTO.tipoActividadDifusionId);
        $('#txtNombreApoyoe').val(ApoyoActividadesDifusionDTO.nombreApoyoActividadDifusion);
        $('#txtLugarApoyoe').val(ApoyoActividadesDifusionDTO.lugarApoyoActividadDifusion);
        $('#cbDepartamentoUe').val(ApoyoActividadesDifusionDTO.departamentoUbigeoId);
        $('#cbDirigidoApoyoe').val(ApoyoActividadesDifusionDTO.dirigidoAId);
        $('#txtFechaIe').val(ApoyoActividadesDifusionDTO.inicioApoyoActividadDifusion);
        $('#txtFechaTe').val(ApoyoActividadesDifusionDTO.terminoApoyoActividadDifusion);
        $('#txtInversione').val(ApoyoActividadesDifusionDTO.inversionApoyoActividadDifusion);
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
                url: '/DirintemarApoyoActividadesDifusion/Eliminar',
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
                    $('#tblDirintemarApoyoActividadesDifusion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarApoyoActividadesDifusion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarApoyoActividadesDifusion/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.apoyoActividadDifusionId),
                        $("<td>").text(item.descTipoActividadDifusion),
                        $("<td>").text(item.nombreApoyoActividadDifusion),
                        $("<td>").text(item.lugarApoyoActividadDifusion),
                        $("<td>").text(item.descDepartamento),
                        $("<td>").text(item.descDirigidoA),
                        $("<td>").text(item.inicioApoyoActividadDifusion),
                        $("<td>").text(item.terminoApoyoActividadDifusion),
                        $("<td>").text(item.inversionApoyoActividadDifusion)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarApoyoActividadesDifusion/EnviarDatos", {
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
    $.getJSON('/DirintemarApoyoActividadesDifusion/cargaCombs', [], function (Json) {
        var tipoactividaddifusion = Json["data1"];
        var departamentoU = Json["data2"];
        var dirigidoa = Json["data3"]

        $("select#cbTipoActDifusion").html("");
        $.each(tipoactividaddifusion, function () {
            var RowContent = '<option value=' + this.tipoActividadDifusionId + '>' + this.descTipoActividadDifusion + '</option>'
            $("select#cbTipoActDifusion").append(RowContent);
        });
        $("select#cbTipoActDifusione").html("");
        $.each(tipoactividaddifusion, function () {
            var RowContent = '<option value=' + this.tipoActividadDifusionId + '>' + this.descTipoActividadDifusion + '</option>'
            $("select#cbTipoActDifusione").append(RowContent);
        });

        $("select#cbDepartamentoU").html("");
        $.each(departamentoU, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoU").append(RowContent);
        });
        $("select#cbDepartamentoUe").html("");
        $.each(departamentoU, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUe").append(RowContent);
        });

        $("select#cbDirigidoApoyo").html("");
        $.each(dirigidoa, function () {
            var RowContent = '<option value=' + this.dirigidoAId + '>' + this.descDirigidoA + '</option>'
            $("select#cbDirigidoApoyo").append(RowContent);
        });
        $("select#cbDirigidoApoyoe").html("");
        $.each(dirigidoa, function () {
            var RowContent = '<option value=' + this.dirigidoAId + '>' + this.descDirigidoA + '</option>'
            $("select#cbDirigidoApoyoe").append(RowContent);
        });
    });
}

