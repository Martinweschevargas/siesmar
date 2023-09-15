var tblDirintemarActividadCultural;

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
                                url: '/DirintemarActividadCultural/Insertar',
                                data: {
                                    'NombreActividadCultural': $('#txtNombre').val(),
                                    'TipoActividadCulturalId': $('#cbTipoActividad').val(),
                                    'FechaInicioActCultural': $('#txtFechaI').val(),
                                    'FechaTerminoActCultural': $('#txtFechaT').val(),
                                    'LugarActCultural': $('#txtLugar').val(),
                                    'AuspiciadoresActCultural': $('#txtAuspiciadores').val(),
                                    'NParticipantesActCultural': $('#txtNParticipantes').val(),
                                    'InversionActCultural': $('#txtInversion').val(),
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
                                    $('#tblDirintemarActividadCultural').DataTable().ajax.reload();
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
                                url: '/DirintemarActividadCultural/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'NombreActividadCultural': $('#txtNombree').val(),
                                    'TipoActividadCulturalId': $('#cbTipoActividade').val(),
                                    'FechaInicioActCultural': $('#txtFechaIe').val(),
                                    'FechaTerminoActCultural': $('#txtFechaTe').val(),
                                    'LugarActCultural': $('#txtLugare').val(),
                                    'AuspiciadoresActCultural': $('#txtAuspiciadorese').val(),
                                    'NParticipantesActCultural': $('#txtNParticipantese').val(),
                                    'InversionActCultural': $('#txtInversione').val(),
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
                                    $('#tblDirintemarActividadCultural').DataTable().ajax.reload();
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

    $('#tblDirintemarActividadCultural').DataTable({
        ajax: {
            "url": '/DirintemarActividadCultural/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "actividadCulturalId" },
            { "data": "nombreActividadCultural" },
            { "data": "descTipoActividadCultural" },
            { "data": "fechaInicioActCultural" },
            { "data": "fechaTerminoActCultural" },
            { "data": "lugarActCultural" },
            { "data": "auspiciadoresActCultural" },
            { "data": "nParticipantesActCultural" },
            { "data": "inversionActCultural" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.actividadCulturalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.actividadCulturalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Actividd Cultural',
                title: '',
                exportOptions: {
                    columns: [0,1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirintemar - Actividd Cultural',
                title: 'Dirintemar - Actividd Cultural',
                exportOptions: {
                    columns: [0,1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Actividd Cultural',
                title: 'Dirintemar - Actividd Cultural',
                exportOptions: {
                    columns: [0,1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Actividd Cultural',
                exportOptions: {
                    columns: [0,1, 2, 3, 4, 5, 6, 7, 8]
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
    $.getJSON('/DirintemarActividadCultural/Mostrar?Id=' + Id , [], function (ActividadCulturalDTO) {
        $('#txtCodigo').val(ActividadCulturalDTO.actividadCulturalId);
        $('#txtNombree').val(ActividadCulturalDTO.nombreActividadCultural);
        $('#cbTipoActividade').val(ActividadCulturalDTO.tipoActividadCulturalId);
        $('#txtFechaIe').val(ActividadCulturalDTO.fechaInicioActCultural);
        $('#txtFechaTe').val(ActividadCulturalDTO.fechaTerminoActCultural);
        $('#txtLugare').val(ActividadCulturalDTO.lugarActCultural);
        $('#txtAuspiciadorese').val(ActividadCulturalDTO.auspiciadoresActCultural);
        $('#txtNParticipantese').val(ActividadCulturalDTO.nParticipantesActCultural);
        $('#txtInversione').val(ActividadCulturalDTO.inversionActCultural);
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
                url: '/DirintemarActividadCultural/Eliminar',
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
                    $('#tblDirintemarActividadCultural').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarActividadCultural() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarActividadCultural/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.actividadCulturalId),
                        $("<td>").text(item.nombreActividadCultural),
                        $("<td>").text(item.descTipoActividadCultural),
                        $("<td>").text(item.fechaInicioActCultural),
                        $("<td>").text(item.fechaTerminoActCultural),
                        $("<td>").text(item.lugarActCultural),
                        $("<td>").text(item.auspiciadoresActCultural),
                        $("<td>").text(item.nParticipantesActCultural),
                        $("<td>").text(item.inversionActCultural)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarActividadCultural/EnviarDatos", {
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
    $.getJSON('/DirintemarActividadCultural/cargaCombs', [], function (Json) {
        var actividadCultural = Json["data"];

        $("select#cbTipoActividad").html("");
        $.each(actividadCultural, function () {
            var RowContent = '<option value=' + this.tipoActividadCulturalId + '>' + this.descTipoActividadCultural + '</option>'
            $("select#cbTipoActividad").append(RowContent);
        });
        $("select#cbTipoActividade").html("");
        $.each(actividadCultural, function () {
            var RowContent = '<option value=' + this.tipoActividadCulturalId + '>' + this.descTipoActividadCultural + '</option>'
            $("select#cbTipoActividade").append(RowContent);
        });


    });
}
