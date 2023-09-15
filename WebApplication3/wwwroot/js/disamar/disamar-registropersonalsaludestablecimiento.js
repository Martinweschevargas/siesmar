var tblDisamarRegistroPersonalSaludEstablecimiento;

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
                                url: '/DisamarRegistroPersonalSaludEstablecimiento/Insertar',
                                data: {
                                    'ApellidosNombresPersonalMedico': $('#txtApellidosNombresPersonalMedico').val(),
                                    'CIPPersonalMedico': $('#txtCIPPersonalMedico').val(),
                                    'DNIPersonalMedico': $('#txtDNIPersonalMedico').val(),
                                    'TipoPersonal': $('#txtTipoPersonal').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'NombreColegioProfesional': $('#txtNombreColegioProfesional').val(),
                                    'NumeroColegiatura': $('#txtNumeroColegiatura').val(),
                                    'Especialidad': $('#txtEspecialidad').val(),
                                    'CodigoEstablecimientoSaludMGP': $('#cbEstablecimientoSaludMGP').val(),
                                    'CodigoCondicionLaboral': $('#cbCondicionLaboral').val(),
                                    'TipoLaborRealizar': $('#txtTipoLaborRealizar').val(), 
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
                                    $('#tblDisamarRegistroPersonalSaludEstablecimiento').DataTable().ajax.reload();
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
                                url: '/DisamarRegistroPersonalSaludEstablecimiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'ApellidosNombresPersonalMedico': $('#txtApellidosNombresPersonalMedicoe').val(),
                                    'CIPPersonalMedico': $('#txtCIPPersonalMedicoe').val(),
                                    'DNIPersonalMedico': $('#txtDNIPersonalMedicoe').val(),
                                    'TipoPersonal': $('#txtTipoPersonale').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'NombreColegioProfesional': $('#txtNombreColegioProfesionale').val(),
                                    'NumeroColegiatura': $('#txtNumeroColegiaturae').val(),
                                    'Especialidad': $('#txtEspecialidade').val(),
                                    'CodigoEstablecimientoSaludMGP': $('#cbEstablecimientoSaludMGPe').val(),
                                    'CodigoCondicionLaboral': $('#cbCondicionLaborale').val(),
                                    'TipoLaborRealizar': $('#txtTipoLaborRealizare').val(), 
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
                                    $('#tblDisamarRegistroPersonalSaludEstablecimiento').DataTable().ajax.reload();
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

 tblDisamarRegistroPersonalSaludEstablecimiento = $('#tblDisamarRegistroPersonalSaludEstablecimiento').DataTable({
        ajax: {
            "url": '/DisamarRegistroPersonalSaludEstablecimiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "registroPersonalSaludEstablecimientoId" },
            { "data": "apellidosNombresPersonalMedico" },
            { "data": "cipPersonalMedico" },
            { "data": "dniPersonalMedico" },
            { "data": "tipoPersonal" },
            { "data": "descGrado" },
            { "data": "nombreColegioProfesional" },
            { "data": "numeroColegiatura" },
            { "data": "especialidad" },
            { "data": "descEstablecimientoSalud" },
            { "data": "descCondicionLaboral" },
            { "data": "tipoLaborRealizar" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.registroPersonalSaludEstablecimientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.registroPersonalSaludEstablecimientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dimar - Registro del Personal de la Salud de los Establecimientos de Salud',
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
                filename: 'Dimar - Registro del Personal de la Salud de los Establecimientos de Salud',
                title: 'Dimar - Registro del Personal de la Salud de los Establecimientos de Salud',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dimar - Registro del Personal de la Salud de los Establecimientos de Salud',
                title: 'Dimar - Registro del Personal de la Salud de los Establecimientos de Salud',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dimar - Registro del Personal de la Salud de los Establecimientos de Salud',
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
    tblDisamarRegistroPersonalSaludEstablecimiento.columns(12).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDisamarRegistroPersonalSaludEstablecimiento.columns(12).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DisamarRegistroPersonalSaludEstablecimiento/Mostrar?Id=' + Id, [], function (RegistroPersonalSaludEstablecimientoDTO) {
        $('#txtCodigo').val(RegistroPersonalSaludEstablecimientoDTO.registroPersonalSaludEstablecimientoId);
        $('#txtApellidosNombresPersonalMedicoe').val(RegistroPersonalSaludEstablecimientoDTO.apellidosNombresPersonalMedico);
        $('#txtCIPPersonalMedicoe').val(RegistroPersonalSaludEstablecimientoDTO.cipPersonalMedico);
        $('#txtDNIPersonalMedicoe').val(RegistroPersonalSaludEstablecimientoDTO.dniPersonalMedico);
        $('#txtTipoPersonale').val(RegistroPersonalSaludEstablecimientoDTO.tipoPersonal);
        $('#cbGradoPersonalMilitare').val(RegistroPersonalSaludEstablecimientoDTO.codigoGradoPersonalMilitar);
        $('#txtNombreColegioProfesionale').val(RegistroPersonalSaludEstablecimientoDTO.nombreColegioProfesional);
        $('#txtNumeroColegiaturae').val(RegistroPersonalSaludEstablecimientoDTO.numeroColegiatura);
        $('#txtEspecialidade').val(RegistroPersonalSaludEstablecimientoDTO.especialidad);
        $('#cbEstablecimientoSaludMGPe').val(RegistroPersonalSaludEstablecimientoDTO.codigoEstablecimientoSaludMGP);
        $('#cbCondicionLaborale').val(RegistroPersonalSaludEstablecimientoDTO.codigoCondicionLaboral);
        $('#txtTipoLaborRealizare').val(RegistroPersonalSaludEstablecimientoDTO.tipoLaborRealizar); 
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
                url: '/DisamarRegistroPersonalSaludEstablecimiento/Eliminar',
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
                    $('#tblDisamarRegistroPersonalSaludEstablecimiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDisamarRegistroPersonalSaludEstablecimiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    formData.append("mes", $('select#cbMess').val())
    formData.append("anio", $('select#cbAnios').val())
    $.ajax({
        type: "POST",
        url: 'DisamarRegistroPersonalSaludEstablecimiento/MostrarDatos',
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
                            $("<td>").text(item.apellidosNombresPersonalMedico),
                            $("<td>").text(item.cipPersonalMedico),
                            $("<td>").text(item.dniPersonalMedico),
                            $("<td>").text(item.tipoPersonal),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.nombreColegioProfesional),
                            $("<td>").text(item.numeroColegiatura),
                            $("<td>").text(item.especialidad),
                            $("<td>").text(item.codigoEstablecimientoSaludMGP),
                            $("<td>").text(item.codigoCondicionLaboral),
                            $("<td>").text(item.tipoLaborRealizar)
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
    fetch("DisamarRegistroPersonalSaludEstablecimiento/EnviarDatos", {
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
                url: '/DisamarRegistroPersonalSaludEstablecimiento/EliminarCarga',
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
                    $('#tblDisamarRegistroPersonalSaludEstablecimiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DisamarRegistroPersonalSaludEstablecimiento/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var establecimientoSaludMGP = Json["data2"];
        var condicionLaboral = Json["data3"];
        var listaCargas = Json["data4"];

        $("select#cbGradoPersonalMilitar").html("");
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });

        $("select#cbEstablecimientoSaludMGP").html("");
        $("select#cbEstablecimientoSaludMGPe").html("");
        $.each(establecimientoSaludMGP, function () {
            var RowContent = '<option value=' + this.codigoEstablecimientoRENAES + '>' + this.descEstablecimientoSalud + '</option>'
            $("select#cbEstablecimientoSaludMGP").append(RowContent);
            $("select#cbEstablecimientoSaludMGPe").append(RowContent);
        });

        $("select#cbCondicionLaboral").html("");
        $("select#cbCondicionLaborale").html("");
        $.each(condicionLaboral, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboral + '>' + this.descCondicionLaboral + '</option>'
            $("select#cbCondicionLaboral").append(RowContent);
            $("select#cbCondicionLaborale").append(RowContent);
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

