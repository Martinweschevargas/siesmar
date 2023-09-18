var tblDiperadmonPersonalMilitarMarineria;
var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

var reporteSeleccionado;
var optReporteSelect;

$('select#cbProvinciaNacimiento').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoNacimiento').append('<option selected disabled>Seleccionar Distrito</option>');

$('select#cbProvinciaLabora').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoLabora').append('<option selected disabled>Seleccionar Distrito</option>');

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
                                url: '/DiperadmonPersonalMilitarMarineria/Insertar',
                                data: {
                                    'DNIPMilitarMar': $('#txtDNI').val(),
                                    'SexoPMilitarMar': $('#txtSexo').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalM').val(),
                                    'UbigeoNacimiento': $('#cbDistritoNacimiento').val(),
                                    'FechaNacimientoPMilitarMar': $('#txtFechaN').val(),
                                    'UbigeoLabora': $('#cbDistritoLabora').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'FechaIngresoInstPMilitarMar': $('#txtFechaI').val(),
                                    'EstadoCivilPMilitarMar': $('#txtEstadoCivil').val(),
                                    'CodigoGradoEstudioAlcanzado': $('#cbGradoEstudioA').val(),
                                    'GradoAñoEstudioPSPMilitarMar': $('#txtGradoEducacion').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialdiadG').val(),
                                    'FechaAltaPMilitarMar': $('#txtFechaAlta').val(),
                                    'FechaIngresoDepPMilitarMar': $('#txtFechaIdep').val(),
                                    'FechaUltimoAscensoPMilitarMar': $('#txtFechaUAsce').val(),
                                    'FechaUltimoReenganchePMilitarMar': $('#txtFechaUReng').val(),
                                    'PeriodoReenganchadoPMilitarMar': $('#txtPeriodoReeng').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbOcupacion').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'mes': $('select#cbMes').val(),
                                    'anio': $('select#cbAnio').val()
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
                                    $('#tblDiperadmonPersonalMilitarMarineria').DataTable().ajax.reload();
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
                                url: '/DiperadmonPersonalMilitarMarineria/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPMilitarMar': $('#txtDNIe').val(),
                                    'SexoPMilitarMar': $('#txtSexoe').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMe').val(),
                                    'UbigeoNacimiento': $('#cbDistritoNacimientoe').val(),
                                    'FechaNacimientoPMilitarMar': $('#txtFechaNe').val(),
                                    'UbigeoLabora': $('#cbDistritoLaborae').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'FechaIngresoInstPMilitarMar': $('#txtFechaIe').val(),
                                    'EstadoCivilPMilitarMar': $('#txtEstadoCivile').val(),
                                    'CodigoGradoEstudioAlcanzado': $('#cbGradoEstudioAe').val(),
                                    'GradoAñoEstudioPSPMilitarMar': $('#txtGradoEducacione').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialdiadGe').val(),
                                    'FechaAltaPMilitarMar': $('#txtFechaAltae').val(),
                                    'FechaIngresoDepPMilitarMar': $('#txtFechaIdepe').val(),
                                    'FechaUltimoAscensoPMilitarMar': $('#txtFechaUAscee').val(),
                                    'FechaUltimoReenganchePMilitarMar': $('#txtFechaURenge').val(),
                                    'PeriodoReenganchadoPMilitarMar': $('#txtPeriodoReenge').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbOcupacione').val(),
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
                                    $('#tblDiperadmonPersonalMilitarMarineria').DataTable().ajax.reload();
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

tblDiperadmonPersonalMilitarMarineria=  $('#tblDiperadmonPersonalMilitarMarineria').DataTable({
        ajax: {
            "url": '/DiperadmonPersonalMilitarMarineria/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "personalMilitarMarineriaId" },
            { "data": "dnipMilitarMar" },
            { "data": "sexoPMilitarMar" },
            { "data": "descGrado" },
            { "data": "descDistritoNacimiento" },
            { "data": "fechaNacimientoPMilitarMar" },
            { "data": "descDistritoLabora" },
            { "data": "descDependencia" },
            { "data": "fechaIngresoInstPMilitarMar" },
            { "data": "estadoCivilPMilitarMar" },
            { "data": "descGradoEstudioAlcanzado" },
            { "data": "gradoAñoEstudioPSPMilitarMar" },
            { "data": "descEspecialidad" },
            { "data": "fechaAltaPMilitarMar" },
            { "data": "fechaIngresoDepPMilitarMar" },
            { "data": "fechaUltimoAscensoPMilitarMar" },
            { "data": "fechaUltimoReenganchePMilitarMar" },
            { "data": "periodoReenganchadoPMilitarMar" },
            { "data": "descCarreraUniversitariaEspecialidad" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.personalMilitarMarineriaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.personalMilitarMarineriaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diperadmon - Personal Militar De Marinería',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diperadmon - Personal Militar De Marinería',
                title: 'Diperadmon - Personal Militar De Marinería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diperadmon - Personal Militar De Marinería',
                title: 'Diperadmon - Personal Militar De Marinería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diperadmon - Personal Militar De Marinería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
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
    tblDiperadmonPersonalMilitarMarineria.columns(19).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblDiperadmonPersonalMilitarMarineria.columns(19).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiperadmonPersonalMilitarMarineria/Mostrar?Id=' + Id, [], function (PersonalMilitarMarineriaDTO) {
        $('#txtCodigo').val(PersonalMilitarMarineriaDTO.personalMilitarMarineriaId);
        $('#txtDNIe').val(PersonalMilitarMarineriaDTO.dnipMilitarMar);
        $('#txtSexoe').val(PersonalMilitarMarineriaDTO.sexoPMilitarMar);
        $('#cbGradoPersonalMe').val(PersonalMilitarMarineriaDTO.codigoGradoPersonalMilitar);
        var iddistrito = PersonalMilitarMarineriaDTO.ubigeoNacimiento;
        $('#cbDistritoNacimientoe').val(PersonalMilitarMarineriaDTO.ubigeoNacimiento);
        $('#txtFechaNe').val(PersonalMilitarMarineriaDTO.fechaNacimientoPMilitarMar);
        var iddistrito2 = PersonalMilitarMarineriaDTO.ubigeoLabora;
        $('#cbDistritoLaborae').val(PersonalMilitarMarineriaDTO.ubigeoLabora);
        $('#cbDependenciae').val(PersonalMilitarMarineriaDTO.codigoDependencia);
        $('#txtFechaIe').val(PersonalMilitarMarineriaDTO.fechaIngresoInstPMilitarMar);
        $('#txtEstadoCivile').val(PersonalMilitarMarineriaDTO.estadoCivilPMilitarMar);
        $('#cbGradoEstudioAe').val(PersonalMilitarMarineriaDTO.CodigoGradoEstudioAlcanzado);
        $('#txtGradoEducacione').val(PersonalMilitarMarineriaDTO.gradoAñoEstudioPSPMilitarMar);
        $('#cbEspecialdiadGe').val(PersonalMilitarMarineriaDTO.codigoEspecialidadGenericaPersonal);
        $('#txtFechaAltae').val(PersonalMilitarMarineriaDTO.fechaAltaPMilitarMar);
        $('#txtFechaIdepe').val(PersonalMilitarMarineriaDTO.fechaIngresoDepPMilitarMar);
        $('#txtFechaUAscee').val(PersonalMilitarMarineriaDTO.fechaUltimoAscensoPMilitarMar);
        $('#txtFechaURenge').val(PersonalMilitarMarineriaDTO.fechaUltimoReenganchePMilitarMar);
        $('#txtPeriodoReenge').val(PersonalMilitarMarineriaDTO.periodoReenganchadoPMilitarMar);
        $('#cbOcupacione').val(PersonalMilitarMarineriaDTO.codigoCarreraUniversitariaEspecialidad);
        encontrardatocombo(iddistrito);
        encontrardatocombo2(iddistrito2);
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
                url: '/DiperadmonPersonalMilitarMarineria/Eliminar',
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
                    $('#tblDiperadmonPersonalMilitarMarineria').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDiperadmonPersonalMilitarMarineria() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiperadmonPersonalMilitarMarineria/MostrarDatos',
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
                            $("<td>").text(item.dniPMilitarMar),
                            $("<td>").text(item.sexoPMilitarMar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.ubigeoNacimiento),
                            $("<td>").text(item.fechaNacimientoPMilitarMar),
                            $("<td>").text(item.ubigeoLabora),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.fechaIngresoInstPMilitarMar),
                            $("<td>").text(item.estadoCivilPMilitarMar),
                            $("<td>").text(item.codigoGradoEstudioAlcanzado),
                            $("<td>").text(item.gradoAñoEstudioPSPMilitarMar),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.fechaAltaPMilitarMar),
                            $("<td>").text(item.fechaIngresoDepPMilitarMar),
                            $("<td>").text(item.fechaUltimoAscensoPMilitarMar),
                            $("<td>").text(item.fechaUltimoReenganchePMilitarMar),
                            $("<td>").text(item.periodoReenganchadoPMilitarMar),
                            $("<td>").text(item.codigoCarreraUniversitariaEspecialidad)
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
    formData.append("mes", $('select#cbMes').val())
    formData.append("anio", $('select#cbAnio').val())
    fetch("DiperadmonPersonalMilitarMarineria/EnviarDatos", {
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
                url: '/DiperadmonPersonalMilitarMarineria/EliminarCarga',
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
                    $('#tblDiperadmonPersonalMilitarMarineria').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DiperadmonPersonalMilitarMarineria/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var dependencia = Json["data2"];
        var gradoEstudioAlcanzado = Json["data3"];
        var especialidadGenericaPersonal = Json["data4"];
        var carreraUniversitariaespecial = Json["data5"];
        distritoUbigeo = Json["data6"];
        provinciaUbigeo = Json["data7"];
        departamentoUbigeo = Json["data8"];
        var listaCargas = Json["data9"];
        var listaMes = Json["mes"];
        var listaAnio = Json["anio"];

        $("select#cbMes").html("");
        $.each(listaMes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });

        $("select#cbAnio").html("");
        $.each(listaAnio, function () {
            var RowContent = '<option value=' + this.codigoAnio + '>' + this.descAnio + '</option>'
            $("select#cbAnio").append(RowContent);
        });

        $("select#cbGradoPersonalM").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalM").append(RowContent);
        });
        $("select#cbGradoPersonalMe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMe").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbDepartamentoNacimiento").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoNacimiento").append(RowContent);
        });
        $('select#cbDepartamentoNacimiento').append('<option selected disabled>Seleccionar Departamento</option>');

        $("select#cbDepartamentoLabora").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoLabora").append(RowContent);
        });
        $('select#cbDepartamentoLabora').append('<option selected disabled>Seleccionar Departamento</option>');



        $("select#cbGradoEstudioA").html("");
        $.each(gradoEstudioAlcanzado, function () {
            var RowContent = '<option value=' + this.codigoGradoEstudioAlcanzado + '>' + this.descGradoEstudioAlcanzado + '</option>'
            $("select#cbGradoEstudioA").append(RowContent);
        });
        $("select#cbGradoEstudioAe").html("");
        $.each(gradoEstudioAlcanzado, function () {
            var RowContent = '<option value=' + this.codigoGradoEstudioAlcanzado + '>' + this.descGradoEstudioAlcanzado + '</option>'
            $("select#cbGradoEstudioAe").append(RowContent);
        });

        $("select#cbEspecialdiadG").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialdiadG").append(RowContent);
        });
        $("select#cbEspecialdiadGe").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialdiadGe").append(RowContent);
        });

        $("select#cbOcupacion").html("");
        $.each(carreraUniversitariaespecial, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbOcupacion").append(RowContent);
        });
        $("select#cbOcupacione").html("");
        $.each(carreraUniversitariaespecial, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbOcupacione").append(RowContent);
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


function encontrardatocombo(id) {
    var iddistrito = id;

    $.each(distritoUbigeo, function () {
        if (this.distritoUbigeo == iddistrito) {
            var provincia = this.provinciaUbigeo;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoNacimientoe").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoNacimientoe").append(RowContent);

                    });
                    $('#cbDepartamentoNacimientoe').val(departamento);
                    $("select#cbProvinciaNacimientoe").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaNacimientoe").append(RowContent);
                        }
                    });
                    $('#cbProvinciaNacimientoe').val(provincia);
                    $("select#cbDistritoNacimientoe").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoNacimientoe").append(RowContent);
                        }
                    });
                    $('#cbDistritoNacimientoe').val(iddistrito);
                }
            });


        }
    });
}

function encontrardatocombo2(id) {
    var iddistrito = id;

    $.each(distritoUbigeo, function () {
        if (this.distritoUbigeo == iddistrito) {
            var provincia = this.provinciaUbigeo;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoLaborae").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoLaborae").append(RowContent);

                    });
                    $('#cbDepartamentoLaborae').val(departamento);
                    $("select#cbProvinciaLaborae").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaLaborae").append(RowContent);
                        }
                    });
                    $('#cbProvinciaLaborae').val(provincia);
                    $("select#cbDistritoLaborae").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoLaborae").append(RowContent);
                        }
                    });
                    $('#cbDistritoLaborae').val(iddistrito);
                }
            });


        }
    });
}

$('select#cbDepartamentoNacimiento').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaNacimiento").html("");
            $('select#cbProvinciaNacimiento').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaNacimiento").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoNacimiento").html("");
    $('select#cbDistritoNacimiento').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaNacimiento').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoNacimiento").html("");
            $('select#cbDistritoNacimiento').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoNacimiento").append(RowContent);
                }
            });
        }
    });
});


$('select#cbDepartamentoLabora').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaLabora").html("");
            $('select#cbProvinciaLabora').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaLabora").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoLabora").html("");
    $('select#cbDistritoLabora').append('<option selected disabled>Seleccionar Distrito</option>');
});
$('select#cbProvinciaLabora').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoLabora").html("");
            $('select#cbDistritoLabora').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoLabora").append(RowContent);
                }
            });
        }
    });
});





$('select#cbDepartamentoNacimientoe').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaNacimientoe").html("");
            $('select#cbProvinciaNacimientoe').append('<option selected disabled>Seleccionar Provincia</option>');
            $('select#cbDistritoNacimientoe').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaNacimientoe").append(RowContent);
                }
            });
        }
    });
});
$('select#cbProvinciaNacimientoe').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoNacimientoe").html("");
            $('select#cbDistritoNacimientoe').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoNacimientoe").append(RowContent);
                }
            });
        }
    });
});



$('select#cbDepartamentoLaborae').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaLaborae").html("");
            $('select#cbProvinciaLaborae').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaLaborae").append(RowContent);
                }
            });
        }
    });
});
$('select#cbProvinciaLaborae').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoLaborae").html("");
            $('select#cbDistritoLaborae').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("cbDistritoLaborae#cbDistritoe").append(RowContent);
                }
            });
        }
    });
});

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DiperadmonPersonalMilitarMarineria/ReporteDPMM';
        $('#fecha').hide();
    }

}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var numCarga;
    if (idCarga == "0") {
        numCarga = "";
    } else {
        numCarga = 'CargaId=' + idCarga;
    }
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect == 1) {
        a.href = reporteSeleccionado + '?' + numCarga;
    }
    a.click();
});