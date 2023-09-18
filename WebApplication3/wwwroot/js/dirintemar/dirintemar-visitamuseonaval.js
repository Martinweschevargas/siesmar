var tblDirintemarVisitaMuseoNaval;

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
                                url: '/DirintemarVisitaMuseoNaval/Insertar',
                                data: {
                                    'MuseoNavalId': $('#cbMuseoNaval').val(),
                                    'PeriodoVisitaMuseoNaval': $('#txtPeriodoVisitaMuseo').val(),
                                    'QNinos': $('#txtNinos').val(),
                                    'QAdultos': $('#txtAdultos').val(),
                                    'QEstudianteEscolar': $('#txtEstudiantesE').val(),
                                    'QEstudianteUniversitario': $('#txtEstudiantesUniversitarios').val(),
                                    'QDocente': $('#txtDocente').val(),
                                    'QMilitar': $('#txtMilitar').val(),
                                    'QFamiliaNavalAdulto': $('#txtFamiliaNavalA').val(),
                                    'QFamiliaNavalNino': $('#txtFamiliaNavalN').val(),
                                    'QPersonaDiscapacitada': $('#txtPersonaDiscapacitada').val(),
                                    'QAdultosCivilMayor65': $('#txtAdultoMayor').val(),
                                    'QExtranjera': $('#txtExtranjeros').val(),
                                    'QOtroExtranjero': $('#txtOtrosExtran').val(),
                                    'QNochesLima': $('#txtNocheLima').val(),
                                    'TotalQVisita': $('#txtTotalVisita').val(),
                                    'RacaudacionTotal': $('#txtRecaudacionT').val(),


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
                                    $('#tblDirintemarVisitaMuseoNaval').DataTable().ajax.reload();
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
                                url: '/DirintemarVisitaMuseoNaval/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'MuseoNavalId': $('#cbMuseoNavale').val(),
                                    'PeriodoVisitaMuseoNaval': $('#txtPeriodoVisitaMuseoe').val(),
                                    'QNinos': $('#txtNinose').val(),
                                    'QAdultos': $('#txtAdultose').val(),
                                    'QEstudianteEscolar': $('#txtEstudiantesEe').val(),
                                    'QEstudianteUniversitario': $('#txtEstudiantesUniversitariose').val(),
                                    'QDocente': $('#txtDocentee').val(),
                                    'QMilitar': $('#txtMilitare').val(),
                                    'QFamiliaNavalAdulto': $('#txtFamiliaNavalAe').val(),
                                    'QFamiliaNavalNino': $('#txtFamiliaNavalNe').val(),
                                    'QPersonaDiscapacitada': $('#txtPersonaDiscapacitadae').val(),
                                    'QAdultosCivilMayor65': $('#txtAdultoMayore').val(),
                                    'QExtranjera': $('#txtExtranjerose').val(),
                                    'QOtroExtranjero': $('#txtOtrosExtrane').val(),
                                    'QNochesLima': $('#txtNocheLimae').val(),
                                    'TotalQVisita': $('#txtTotalVisitae').val(),
                                    'RacaudacionTotal': $('#txtRecaudacionTe').val(),
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
                                    $('#tblDirintemarVisitaMuseoNaval').DataTable().ajax.reload();
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

    $('#tblDirintemarVisitaMuseoNaval').DataTable({
        ajax: {
            "url": '/DirintemarVisitaMuseoNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "visitaMuseoNavalId" },
            { "data": "descMuseoNaval" },
            { "data": "periodoVisitaMuseoNaval" },
            { "data": "qNinos" },
            { "data": "qAdultos" },
            { "data": "qEstudianteEscolar" },
            { "data": "qEstudianteUniversitario" },
            { "data": "qDocente" },
            { "data": "qMilitar" },  
            { "data": "qFamiliaNavalAdulto" },
            { "data": "qFamiliaNavalNino" },
            { "data": "qPersonaDiscapacitada" },
            { "data": "qAdultosCivilMayor65" },
            { "data": "qExtranjera" },
            { "data": "qOtroExtranjero" },
            { "data": "qNochesLima" },
            { "data": "totalQVisita" },
            { "data": "racaudacionTotal" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.visitaMuseoNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.visitaMuseoNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Visitas Registradas a los Museos Navales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirintemar - Visitas Registradas a los Museos Navales',
                title: 'Dirintemar - Visitas Registradas a los Museos Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Visitas Registradas a los Museos Navales',
                title: 'Dirintemar - Visitas Registradas a los Museos Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Visitas Registradas a los Museos Navales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
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
    $.getJSON('/DirintemarVisitaMuseoNaval/Mostrar?Id=' + Id, [], function (VisitaMuseoNavalDTO) {
        $('#txtCodigo').val(VisitaMuseoNavalDTO.visitaMuseoNavalId);
        $('#cbMuseoNavale').val(VisitaMuseoNavalDTO.museoNavalId);
        $('#txtPeriodoVisitaMuseoe').val(VisitaMuseoNavalDTO.periodoVisitaMuseoNaval);
        $('#txtNinose').val(VisitaMuseoNavalDTO.qNinos);
        $('#txtAdultose').val(VisitaMuseoNavalDTO.qAdultos);
        $('#txtEstudiantesEe').val(VisitaMuseoNavalDTO.qEstudianteEscolar);
        $('#txtEstudiantesUniversitariose').val(VisitaMuseoNavalDTO.qEstudianteUniversitario);
        $('#txtDocentee').val(VisitaMuseoNavalDTO.qDocente);
        $('#txtMilitare').val(VisitaMuseoNavalDTO.qMilitar);
        $('#txtFamiliaNavalAe').val(VisitaMuseoNavalDTO.qFamiliaNavalAdulto);
        $('#txtFamiliaNavalNe').val(VisitaMuseoNavalDTO.qFamiliaNavalNino);
        $('#txtPersonaDiscapacitadae').val(VisitaMuseoNavalDTO.qPersonaDiscapacitada);
        $('#txtAdultoMayore').val(VisitaMuseoNavalDTO.qAdultosCivilMayor65);
        $('#txtExtranjerose').val(VisitaMuseoNavalDTO.qExtranjera);
        $('#txtOtrosExtrane').val(VisitaMuseoNavalDTO.qOtroExtranjero);
        $('#txtNocheLimae').val(VisitaMuseoNavalDTO.qNochesLima);
        $('#txtTotalVisitae').val(VisitaMuseoNavalDTO.totalQVisita);
        $('#txtRecaudacionTe').val(VisitaMuseoNavalDTO.racaudacionTotal);
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
                url: '/DirintemarVisitaMuseoNaval/Eliminar',
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
                    $('#tblDirintemarVisitaMuseoNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarVisitaMuseoNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarVisitaMuseoNaval/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.visitaMuseoNavalId),
                        $("<td>").text(item.descMuseoNaval),
                        $("<td>").text(item.periodoVisitaMuseoNaval),
                        $("<td>").text(item.qNinos),
                        $("<td>").text(item.qAdultos),
                        $("<td>").text(item.qEstudianteEscolar),
                        $("<td>").text(item.qEstudianteUniversitario),
                        $("<td>").text(item.qDocente),
                        $("<td>").text(item.qMilitar),
                        $("<td>").text(item.qFamiliaNavalAdulto),
                        $("<td>").text(item.qFamiliaNavalNino),
                        $("<td>").text(item.qPersonaDiscapacitada),
                        $("<td>").text(item.qAdultosCivilMayor65),
                        $("<td>").text(item.qExtranjera),
                        $("<td>").text(item.qOtroExtranjero),
                        $("<td>").text(item.qNochesLima),
                        $("<td>").text(item.totalQVisita),
                        $("<td>").text(item.racaudacionTotal)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarVisitaMuseoNaval/EnviarDatos", {
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
    $.getJSON('/DirintemarVisitaMuseoNaval/cargaCombs', [], function (Json) {
        var museonaval = Json["data"];
        $("select#cbMuseoNaval").html("");
        $.each(museonaval, function () {
            var RowContent = '<option value=' + this.museoNavalId + '>' + this.descMuseoNaval + '</option>'
            $("select#cbMuseoNaval").append(RowContent);
        });
        $("select#cbMuseoNavale").html("");
        $.each(museonaval, function () {
            var RowContent = '<option value=' + this.museoNavalId + '>' + this.descMuseoNaval + '</option>'
            $("select#cbMuseoNavale").append(RowContent);
        });
    })
}

