var tblDiperadmonPersonalCivil;
var reporteSeleccionado;
var optReporteSelect;

var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

$('select#cbProvinciaNacimiento').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoNacimientoPCivil').append('<option selected disabled>Seleccionar Distrito</option>');

$('select#cbProvinciaLabora').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoLaboraPCivil').append('<option selected disabled>Seleccionar Distrito</option>');

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
                                url: '/DiperadmonPersonalCivil/Insertar',
                                data: {
                                    'TipoDocumentoPCivil': $('#txtTipoDocumento').val(),
                                    'DNIPCivil': $('#txtDNI').val(),
                                    'SexoPCivil': $('#txtSexo').val(),
                                    'CodigoCondicionLaboralCivil': $('#txtCondicionLaboral').val(),
                                    'CodigoGrupoOcupacionalCivil': $('#txtGrupoOcupaci').val(),
                                    'NivelCargoPCivil': $('#txtNivelCargo').val(),
                                    'CodigoRegimenLaboral': $('#cbGrupoRemunerativo').val(),
                                    'CodigoGradoRemunerativo': $('#cbGradoRemunerativo').val(),
                                    'CodigoRegimenLaboral': $('#cbRegimenLaboral').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarreraUnivEspe').val(),
                                    'CodigoSistemaPension': $('#cbSistemaPension').val(),
                                    'FechaIngresoInstPCivil': $('#txtFechaIinst').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'DistritoLaboraPCivil': $('#cbDistritoLaboraPCivil').val(),
                                    'FechaIngresoPCivil': $('#txtFechaI').val(),
                                    'FechaNacimientoPCivil': $('#txtFechaN').val(),
                                    'DistritoNacimientoPCivil': $('#cbDistritoNacimientoPCivil').val(),
                                    'EstadoCivilPCivil': $('#txtEstadoCivil').val(),
                                    'CodigoGradoEstudioAlcanzado': $('#cbGradoEstudioA').val(),
                                    'GradoAñoEstudioPSPCivil': $('#txtGradoEducacion').val(),
                                    'AnioServicioPCivil': $('#txtAnioServicio').val(),
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
                                    $('#tblDiperadmonPersonalCivil').DataTable().ajax.reload();
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
                                url: '/DiperadmonPersonalCivil/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoDocumentoPCivil': $('#txtTipoDocumentoe').val(),
                                    'DNIPCivil': $('#txtDNIe').val(),
                                    'SexoPCivil': $('#txtSexoe').val(),
                                    'CodigoCondicionLaboralCivil': $('#txtCondicionLaborale').val(),
                                    'CodigoGrupoOcupacionalCivil': $('#txtGrupoOcupacie').val(),
                                    'NivelCargoPCivil': $('#txtNivelCargoe').val(),
                                    'CodigoRegimenLaboral': $('#cbGrupoRemunerativoe').val(),
                                    'CodigoGradoRemunerativo': $('#cbGradoRemunerativoe').val(),
                                    'CodigoRegimenLaboral': $('#cbRegimenLaborale').val(),
                                    'CodigoCarreraUniversitariaEspecialidad': $('#cbCarreraUnivEspee').val(),
                                    'CodigoSistemaPension': $('#cbSistemaPensione').val(),
                                    'FechaIngresoInstPCivil': $('#txtFechaIinste').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'DistritoLaboraPCivil': $('#cbDistritoLaboraPCivile').val(),
                                    'FechaIngresoPCivil': $('#txtFechaIe').val(),
                                    'FechaNacimientoPCivil': $('#txtFechaNe').val(),
                                    'DistritoNacimientoPCivil': $('#cbDistritoNacimientoPCivile').val(),
                                    'EstadoCivilPCivil': $('#txtEstadoCivile').val(),
                                    'CodigoGradoEstudioAlcanzado': $('#cbGradoEstudioAe').val(),
                                    'GradoAñoEstudioPSPCivil': $('#txtGradoEducacione').val(),
                                    'AnioServicioPCivil': $('#txtAnioServicioe').val(),
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
                                    $('#tblDiperadmonPersonalCivil').DataTable().ajax.reload();
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

  tblDiperadmonPersonalCivil=  $('#tblDiperadmonPersonalCivil').DataTable({
        ajax: {
            "url": '/DiperadmonPersonalCivil/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "personalCivilId" },
            { "data": "tipoDocumentoPCivil" },
            { "data": "dnipCivil" },
            { "data": "sexoPCivil" },
            { "data": "descCondicionLaboralPCivil" },
            { "data": "descGrupoOcupacionalPCivil" },  
            { "data": "nivelCargoPCivil" },
            { "data": "descGrupoRemunerativo" },
            { "data": "descGradoRemunerativo" },
            { "data": "descRegimenLaboral" },
            { "data": "descCarreraUniversitariaEspecialidad" },
            { "data": "descSistemaPension" },
            { "data": "fechaIngresoInstPCivil" },
            { "data": "descDependencia" },
            { "data": "descDistritoLaboraPCivil" },
            { "data": "fechaIngresoPCivil" },
            { "data": "fechaNacimientoPCivil" },
            { "data": "descDistritoNacimientoPCivil" },
            { "data": "estadoCivilPCivil" },
            { "data": "descGradoEstudioAlcanzado" },
            { "data": "gradoAñoEstudioPSPCivil" },
            { "data": "anioServicioPCivil" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.personalCivilId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.personalCivilId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diperadmon - Personal Civil',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diperadmon - Personal Civil',
                title: 'Diperadmon - Personal Civil',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diperadmon - Personal Civil',
                title: 'Diperadmon - Personal Civil',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diperadmon - Personal Civil',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21]
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
    tblDiperadmonPersonalCivil.columns(22).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiperadmonPersonalCivil.columns(22).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiperadmonPersonalCivil/Mostrar?Id=' + Id, [], function (PersonalCivilDTO) {
        $('#txtCodigo').val(PersonalCivilDTO.personalCivilId);
        $('#txtTipoDocumentoe').val(PersonalCivilDTO.tipoDocumentoPCivil);
        $('#txtDNIe').val(PersonalCivilDTO.dnipCivil);
        $('#txtSexoe').val(PersonalCivilDTO.sexo);
        $('#txtCondicionLaborale').val(PersonalCivilDTO.codigoCondicionLaboralCivil);
        $('#txtGrupoOcupacie').val(PersonalCivilDTO.codigoGrupoOcupacionalCivil);
        $('#txtNivelCargoe').val(PersonalCivilDTO.nivelCargoPCivil);
        $('#cbGrupoRemunerativoe').val(PersonalCivilDTO.codigoGrupoRemunerativo);
        $('#cbGradoRemunerativoe').val(PersonalCivilDTO.codigoGradoRemunerativo);
        $('#cbRegimenLaborale').val(PersonalCivilDTO.codigoRegimenLaboral);
        $('#cbCarreraUnivEspee').val(PersonalCivilDTO.codigoCarreraUniversitariaEspecialidad);
        $('#cbSistemaPensione').val(PersonalCivilDTO.codigoSistemaPension);
        $('#txtFechaIinste').val(PersonalCivilDTO.fechaIngresoInstPCivil);
        $('#cbDependenciae').val(PersonalCivilDTO.codigoDependencia);
        var iddistrito = PersonalCivilDTO.distritoLaboraPCivil;
        $('#cbDistritoLaboraPCivile').val(PersonalCivilDTO.distritoLaboraPCivil);
        $('#txtFechaIe').val(PersonalCivilDTO.fechaIngresoPCivil);
        $('#txtFechaNe').val(PersonalCivilDTO.fechaNacimientoPCivil);
        var iddistrito2 = PersonalCivilDTO.distritoNacimientoPCivil;
        $('#cbDistritoNacimientoPCivile').val(PersonalCivilDTO.distritoNacimientoPCivil);
        $('#txtEstadoCivile').val(PersonalCivilDTO.estadoCivilPCivil);
        $('#cbGradoEstudioAe').val(PersonalCivilDTO.codigoGradoEstudioAlcanzado);
        $('#txtGradoEducacione').val(PersonalCivilDTO.gradoAñoEstudioPSPCivil);
        $('#txtAnioServicioe').val(PersonalCivilDTO.anioServicioPCivil);
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
                url: '/DiperadmonPersonalCivil/Eliminar',
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
                    $('#tblDiperadmonPersonalCivil').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDiperadmonPersonalCivil() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiperadmonPersonalCivil/MostrarDatos',
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
                            $("<td>").text(item.tipoDocumentoPCivil),
                            $("<td>").text(item.dnipCivil),
                            $("<td>").text(item.sexoPCivil),
                            $("<td>").text(item.codigoCondicionLaboralCivil),
                            $("<td>").text(item.codigoGrupoOcupacionalCivil),
                            $("<td>").text(item.nivelCargoPCivil),
                            $("<td>").text(item.codigoGrupoRemunerativo),
                            $("<td>").text(item.codigoGradoRemunerativo),
                            $("<td>").text(item.codigoRegimenLaboral),
                            $("<td>").text(item.codigoCarreraUniversitariaEspecialidad),
                            $("<td>").text(item.codigoSistemaPension),
                            $("<td>").text(item.fechaIngresoInstPCivil),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.distritoLaboraPCivil),
                            $("<td>").text(item.fechaIngresoPCivil),
                            $("<td>").text(item.fechaNacimientoPCivil),
                            $("<td>").text(item.distritoNacimientoPCivil),
                            $("<td>").text(item.estadoCivilPCivil),
                            $("<td>").text(item.codigoGradoEstudioAlcanzado),
                            $("<td>").text(item.gradoAñoEstudioPSPCivil),
                            $("<td>").text(item.anioServicioPCivil)
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
    fetch("DiperadmonPersonalCivil/EnviarDatos", {
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
                url: '/DiperadmonPersonalCivil/EliminarCarga',
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
                    $('#tblDiperadmonPersonalCivil').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function cargaDatos() {
    $.getJSON('/DiperadmonPersonalCivil/cargaCombs', [], function (Json) {
        var grupoRemunerativo = Json["data1"];
        var gradoRemunerativo = Json["data2"];
        var regimenLaboral = Json["data3"];
        var carreraUniversitariaEspecialidad = Json["data4"];
        var sistemaPension = Json["data5"];
        var dependencia = Json["data6"];
        var gradoEstudioAlcanzado = Json["data7"];
        distritoUbigeo = Json["data8"];
        provinciaUbigeo = Json["data9"];
        departamentoUbigeo = Json["data10"];
        var condicionLaboralCivil = Json["data11"];
        var grupoOcupacionalCivil = Json["data12"];
        var listaCargas = Json["data13"];
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

        $("select#txtCondicionLaboral").html("");
        $.each(condicionLaboralCivil, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralCivil + '>' + this.descCondicionLaboralCivil + '</option>'
            $("select#txtCondicionLaboral").append(RowContent);
        });

        $("select#txtCondicionLaborale").html("");
        $.each(condicionLaboralCivil, function () {
            var RowContent = '<option value=' + this.codigoCondicionLaboralCivil + '>' + this.descCondicionLaboralCivil + '</option>'
            $("select#txtCondicionLaborale").append(RowContent);
        });

        $("select#txtGrupoOcupaci").html("");
        $.each(grupoOcupacionalCivil, function () {
            var RowContent = '<option value=' + this.codigoGrupoOcupacionalCivil + '>' + this.descGrupoOcupacionalCivil + '</option>'
            $("select#txtGrupoOcupaci").append(RowContent);
        });
        $("select#txtGrupoOcupacie").html("");
        $.each(grupoOcupacionalCivil, function () {
            var RowContent = '<option value=' + this.codigoGrupoOcupacionalCivil + '>' + this.descGrupoOcupacionalCivil + '</option>'
            $("select#txtGrupoOcupacie").append(RowContent);
        });


        $("select#cbGrupoRemunerativo").html("");
        $.each(grupoRemunerativo, function () {
            var RowContent = '<option value=' + this.codigoGrupoRemunerativo + '>' + this.descGrupoRemunerativo + '</option>'
            $("select#cbGrupoRemunerativo").append(RowContent);
        });
        $("select#cbGrupoRemunerativoe").html("");
        $.each(grupoRemunerativo, function () {
            var RowContent = '<option value=' + this.codigoGrupoRemunerativo + '>' + this.descGrupoRemunerativo + '</option>'
            $("select#cbGrupoRemunerativoe").append(RowContent);
        });

        $("select#cbGradoRemunerativo").html("");
        $.each(gradoRemunerativo, function () {
            var RowContent = '<option value=' + this.codigoGradoRemunerativo + '>' + this.descGradoRemunerativo + '</option>'
            $("select#cbGradoRemunerativo").append(RowContent);
        });
        $("select#cbGradoRemunerativoe").html("");
        $.each(gradoRemunerativo, function () {
            var RowContent = '<option value=' + this.codigoGradoRemunerativo + '>' + this.descGradoRemunerativo + '</option>'
            $("select#cbGradoRemunerativoe").append(RowContent);
        });

        $("select#cbRegimenLaboral").html("");
        $.each(regimenLaboral, function () {
            var RowContent = '<option value=' + this.codigoRegimenLaboral + '>' + this.descRegimenLaboral + '</option>'
            $("select#cbRegimenLaboral").append(RowContent);
        });
        $("select#cbRegimenLaborale").html("");
        $.each(regimenLaboral, function () {
            var RowContent = '<option value=' + this.codigoRegimenLaboral + '>' + this.descRegimenLaboral + '</option>'
            $("select#cbRegimenLaborale").append(RowContent);
        });

        $("select#cbCarreraUnivEspe").html("");
        $.each(carreraUniversitariaEspecialidad, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbCarreraUnivEspe").append(RowContent);
        });
        $("select#cbCarreraUnivEspee").html("");
        $.each(carreraUniversitariaEspecialidad, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbCarreraUnivEspee").append(RowContent);
        });

        $("select#cbSistemaPension").html("");
        $.each(sistemaPension, function () {
            var RowContent = '<option value=' + this.codigoSistemaPension + '>' + this.descSistemaPension + '</option>'
            $("select#cbSistemaPension").append(RowContent);
        });
        $("select#cbSistemaPensione").html("");
        $.each(sistemaPension, function () {
            var RowContent = '<option value=' + this.codigoSistemaPension + '>' + this.descSistemaPension + '</option>'
            $("select#cbSistemaPensione").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
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
            var provincia = this.provinciaUbigeoId;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeoId == provincia) {
                    var departamento = this.departamentoUbigeoId;
                    $("select#cbDepartamentoNacimientoe").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoNacimientoe").append(RowContent);

                    });
                    $('#cbDepartamentoNacimientoe').val(departamento);
                    $("select#cbProvinciaNacimientoe").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeoId == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaNacimientoe").append(RowContent);
                        }
                    });
                    $('#cbProvinciaNacimientoe').val(provincia);
                    $("select#cbDistritoNacimientoPCivile").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeoId == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoNacimientoPCivile").append(RowContent);
                        }
                    });
                    $('#cbDistritoNacimientoPCivile').val(iddistrito);
                }
            });


        }
    });
}


function encontrardatocombo2(id) {
    var iddistrito = id;

    $.each(distritoUbigeo, function () {
        if (this.distritoUbigeo == iddistrito) {
            var provincia = this.provinciaUbigeoId;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeoId == provincia) {
                    var departamento = this.departamentoUbigeoId;
                    $("select#cbDepartamentoLaborae").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoLaborae").append(RowContent);

                    });
                    $('#cbDepartamentoLaborae').val(departamento);
                    $("select#cbProvinciaLaborae").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeoId == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaLaborae").append(RowContent);
                        }
                    });
                    $('#cbProvinciaLaborae').val(provincia);
                    $("select#cbDistritoLaboraPCivile").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeoId == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoLaboraPCivile").append(RowContent);
                        }
                    });
                    $('#cbDistritoLaboraPCivile').val(iddistrito);
                }
            });


        }
    });
}


$('select#cbDepartamentoNacimiento').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeoId == codigo) {
            $("select#cbProvinciaNacimiento").html("");
            $('select#cbProvinciaNacimiento').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaNacimiento").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoNacimientoPCivil").html("");
    $('select#cbDistritoNacimientoPCivil').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaNacimiento').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistritoNacimientoPCivil").html("");
            $('select#cbDistritoNacimientoPCivil').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoNacimientoPCivil").append(RowContent);
                }
            });
        }
    });
});


$('select#cbDepartamentoLabora').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeoId == codigo) {
            $("select#cbProvinciaLabora").html("");
            $('select#cbProvinciaLabora').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaLabora").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoLaboraPCivil").html("");
    $('select#cbDistritoLaboraPCivil').append('<option selected disabled>Seleccionar Distrito</option>');
});
$('select#cbProvinciaLabora').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistritoLaboraPCivil").html("");
            $('select#cbDistritoLaboraPCivil').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoLaboraPCivil").append(RowContent);
                }
            });
        }
    });
});

$('select#cbDepartamentoNacimientoe').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeoId == codigo) {
            $("select#cbProvinciaNacimientoe").html("");
            $('select#cbProvinciaNacimientoe').append('<option selected disabled>Seleccionar Provincia</option>');
            $('select#cbDistritoNacimientoPCivile').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeoId == codigo) {
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
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistritoNacimientoPCivile").html("");
            $('select#cbDistritoNacimientoPCivile').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoNacimientoPCivile").append(RowContent);
                }
            });
        }
    });
});



$('select#cbDepartamentoLaborae').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeoId == codigo) {
            $("select#cbProvinciaLaborae").html("");
            $('select#cbProvinciaLaborae').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeoId == codigo) {
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
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistritoLaboraPCivile").html("");
            $('select#cbDistritoLaboraPCivile').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("cbDistritoLaboraPCivile#cbDistritoe").append(RowContent);
                }
            });
        }
    });
});

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DiperadmonPersonalCivil/ReporteDPC';
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
