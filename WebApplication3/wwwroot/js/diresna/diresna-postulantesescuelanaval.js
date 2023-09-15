var tblDiresnaPostulantesEscuelaNaval;
var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

var reporteSeleccionado;
var optReporteSelect;
$('select#cbProvinciaNacimiento').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoNacimiento').append('<option selected disabled>Seleccionar Distrito</option>');

$('select#cbProvinciaDomicilio').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoDomicilio').append('<option selected disabled>Seleccionar Distrito</option>');

$('select#cbProvinciaInstitucion').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoInstitucion').append('<option selected disabled>Seleccionar Distrito</option>');

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
                                url: '/DiresnaPostulantesEscuelaNaval/Insertar',
                                data: {
                                    'DNIGrumete': $('#txtDNI').val(),
                                    'DNIPostulante': $('#txtDNI').val(),
                                    'SexoPostulante': $('#txtGenero').val(),
                                    'FechaNacimientoPostulante': $('#txtFechaNacimiento').val(),
                                    'TallaPostulante': $('#txtTalla').val(),
                                    'PesoPostulante': $('#txtPeso').val(),
                                    'UbigeoNacimiento ': $('#cbDistritoNacimiento').val(),
                                    'UbigeoDomicilio ': $('#cbDistritoDomicilio').val(),
                                    'TipoInstitucionEducativa': $('#txtTipoinstitucionEP').val(),
                                    'CodigoInstitucionEducativa ': $('#cbInstitucionEP').val(),
                                    'UbigeoInstitucion ': $('#cbDistritoInstitucion').val(),
                                    'PadresMilitar': $('#txtPadresPertenecen').val(),
                                    'CodigoEntidadMilitar ': $('#cbInstitucionPertenecePP').val(),
                                    'CodigoTipoPersonalMilitar ': $('#cbTipoPersonalM').val(),
                                    'CodigoCarreraUniversitariaEspecialidad ': $('#cbCarreraUni').val(),
                                    'ConcursoAdmision': $('#txtConcursoAdmision').val(),
                                    'CodigoModalidadIngresoEsna ': $('#cbModalidadIngreso').val(),
                                    'TipoPreparacion': $('#txtTipoPreparacion').val(),
                                    'DeportistaCalificado': $('#txtDeportistaCalificado').val(),
                                    'CodigoZonaNaval ': $('#cbZonaNaval').val(),
                                    'QVecesPostulacion': $('#txtQVecesPostulo').val(),
                                    'CodigoPublicidadEsna ': $('#cbPublicidadEs').val(),
                                    'SituacionIngreso': $('#txtSituacionIngreso').val(), 
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
                                    $('#tblDiresnaPostulantesEscuelaNaval').DataTable().ajax.reload();
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
                                url: '/DiresnaPostulantesEscuelaNaval/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPostulante': $('#txtDNIe').val(),
                                    'SexoPostulante': $('#txtGeneroe').val(),
                                    'FechaNacimientoPostulante': $('#txtFechaNacimientoe').val(),
                                    'TallaPostulante': $('#txtTallae').val(),
                                    'PesoPostulante': $('#txtPesoe').val(),
                                    'UbigeoNacimiento ': $('#cbDistritoNacimientoe').val(),
                                    'UbigeoDomicilio ': $('#cbDistritoDomicilioe').val(),
                                    'TipoInstitucionEducativa': $('#txtTipoinstitucionEPe').val(),
                                    'CodigoInstitucionEducativa ': $('#cbInstitucionEPe').val(),
                                    'UbigeoInstitucion ': $('#cbDistritoInstitucione').val(),
                                    'PadresMilitar': $('#txtPadresPertenecene').val(),
                                    'CodigoEntidadMilitar ': $('#cbInstitucionPertenecePPe').val(),
                                    'CodigoTipoPersonalMilitar ': $('#cbTipoPersonalMe').val(),
                                    'CodigoCarreraUniversitariaEspecialidad ': $('#cbCarreraUnie').val(),
                                    'ConcursoAdmision': $('#txtConcursoAdmisione').val(),
                                    'CodigoModalidadIngresoEsna ': $('#cbModalidadIngresoe').val(),
                                    'TipoPreparacion': $('#txtTipoPreparacione').val(),
                                    'DeportistaCalificado': $('#txtDeportistaCalificadoe').val(),
                                    'CodigoZonaNaval ': $('#cbZonaNavale').val(),
                                    'QVecesPostulacion': $('#txtQVecesPostuloe').val(),
                                    'CodigoPublicidadEsna ': $('#cbPublicidadEse').val(),
                                    'SituacionIngreso': $('#txtSituacionIngresoe').val(), 
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
                                    $('#tblDiresnaPostulantesEscuelaNaval').DataTable().ajax.reload();
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

        tblDiresnaPostulantesEscuelaNaval=  $('#tblDiresnaPostulantesEscuelaNaval').DataTable({
        ajax: {
            "url": '/DiresnaPostulantesEscuelaNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "postulanteEscuelaNavalId" },
            { "data": "dniPostulante" },
            { "data": "sexoPostulante" },
            { "data": "fechaNacimientoPostulante" },
            { "data": "tallaPostulante" },
            { "data": "pesoPostulante" },
            { "data": "descDistritoNacimiento" },
            { "data": "descDistritoDomicilio" },
            { "data": "tipoInstitucionEducativa" },
            { "data": "descInstitucionEducativa" },
            { "data": "descDistritoInstitucion" },
            { "data": "padresMilitar" },
            { "data": "descEntidadMilitar" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descCarreraUniversitariaEspecialidad" },
            { "data": "concursoAdmision" },
            { "data": "descModalidadIngresoEsna" },
            { "data": "tipoPreparacion" },
            { "data": "deportistaCalificado" },
            { "data": "descZonaNaval" },
            { "data": "qvecesPostulacion" },
            { "data": "descPublicidadEsna" },
            { "data": "situacionIngreso" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.postulanteEscuelaNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.postulanteEscuelaNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresna - Postulantes a la Escuela Naval',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diresna - Postulantes a la Escuela Naval',
                title: 'Diresna - Postulantes a la Escuela Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresna - Postulantes a la Escuela Naval',
                title: 'Diresna - Postulantes a la Escuela Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresna - Postulantes a la Escuela Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
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
    tblDiresnaPostulantesEscuelaNaval.columns(23).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiresnaPostulantesEscuelaNaval.columns(23).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiresnaPostulantesEscuelaNaval/Mostrar?Id=' + Id, [], function (PostulantesEscuelaNavalDTO) {
        $('#txtCodigo').val(PostulantesEscuelaNavalDTO.postulanteEscuelaNavalId);
        $('#txtDNIe').val(PostulantesEscuelaNavalDTO.dniPostulante);
        $('#txtGeneroe').val(PostulantesEscuelaNavalDTO.sexoPostulante);
        $('#txtFechaNacimientoe').val(PostulantesEscuelaNavalDTO.fechaNacimientoPostulante);
        $('#txtTallae').val(PostulantesEscuelaNavalDTO.tallaPostulante);
        $('#txtPesoe').val(PostulantesEscuelaNavalDTO.pesoPostulante);
        var iddistrito = PostulantesEscuelaNavalDTO.ubigeoNacimiento;
        var iddistrito2 = PostulantesEscuelaNavalDTO.ubigeoDomicilio;
        $('#txtTipoinstitucionEPe').val(PostulantesEscuelaNavalDTO.TipoInstitucionEducativa);
        $('#cbInstitucionEPe').val(PostulantesEscuelaNavalDTO.codigoInstitucionEducativa);
        var iddistrito3 = PostulantesEscuelaNavalDTO.ubigeoInstitucion;
        $('#txtPadresPertenecene').val(PostulantesEscuelaNavalDTO.padresMilitar);
        $('#cbInstitucionPertenecePPe').val(PostulantesEscuelaNavalDTO.codigoEntidadMilitar);
        $('#cbTipoPersonalMe').val(PostulantesEscuelaNavalDTO.codigoTipoPersonalMilitar);
        $('#cbCarreraUnie').val(PostulantesEscuelaNavalDTO.codigoCarreraUniversitariaEspecialidad);
        $('#txtConcursoAdmisione').val(PostulantesEscuelaNavalDTO.concursoAdmision);
        $('#cbModalidadIngresoe').val(PostulantesEscuelaNavalDTO.codigoModalidadIngresoEsna);
        $('#txtTipoPreparacione').val(PostulantesEscuelaNavalDTO.tipoPreparacion);
        $('#txtDeportistaCalificadoe').val(PostulantesEscuelaNavalDTO.deportistaCalificado);
        $('#cbZonaNavale').val(PostulantesEscuelaNavalDTO.codigoZonaNaval);
        $('#txtQVecesPostuloe').val(PostulantesEscuelaNavalDTO.qVecesPostulacion);
        $('#cbPublicidadEse').val(PostulantesEscuelaNavalDTO.codigoPublicidadEsna);
        $('#txtSituacionIngresoe').val(PostulantesEscuelaNavalDTO.situacionIngreso);  
        encontrardatocombo(iddistrito);
        encontrardatocombo2(iddistrito2);
        encontrardatocombo(iddistrito3);
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
                url: '/DiresnaPostulantesEscuelaNaval/Eliminar',
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
                    $('#tblDiresnaPostulantesEscuelaNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDiresnaPostulantesEscuelaNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiresnaPostulantesEscuelaNaval/MostrarDatos',
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
                            $("<td>").text(item.dniPostulante),
                            $("<td>").text(item.sexoPostulante),
                            $("<td>").text(item.fechaNacimientoPostulante),
                            $("<td>").text(item.tallaPostulante),
                            $("<td>").text(item.pesoPostulante),
                            $("<td>").text(item.ubigeoNacimiento),
                            $("<td>").text(item.ubigeoDomicilio),
                            $("<td>").text(item.tipoInstitucionEducativa),
                            $("<td>").text(item.codigoInstitucionEducativa),
                            $("<td>").text(item.ubigeoInstitucion),
                            $("<td>").text(item.padresMilitar),
                            $("<td>").text(item.codigoEntidadMilitar),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoCarreraUniversitariaEspecialidad),
                            $("<td>").text(item.concursoAdmision),
                            $("<td>").text(item.codigoModalidadIngresoEsna),
                            $("<td>").text(item.tipoPreparacion),
                            $("<td>").text(item.deportistaCalificado),
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.qVecesPostulacion),
                            $("<td>").text(item.codigoPublicidadEsna),
                            $("<td>").text(item.situacionIngreso),
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
    fetch("DiresnaPostulantesEscuelaNaval/EnviarDatos", {
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
    $.getJSON('/DiresnaPostulantesEscuelaNaval/cargaCombs', [], function (Json) {
        var institucionEducativa = Json["data1"];
        var entidadMilitar = Json["data2"];
        var tipoPersonalMilitar = Json["data3"];
        var carreraUniversitariaEspecialidad = Json["data4"];
        var modalidadIngresoEsna = Json["data5"];
        var zonaNaval = Json["data6"];
        var publicidadEsna = Json["data7"];
        distritoUbigeo = Json["data8"];
        provinciaUbigeo = Json["data9"];
        departamentoUbigeo = Json["data10"];
        var listaCargas = Json["data9"];


        $("select#cbInstitucionEP").html("");
        $.each(institucionEducativa, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativa + '>' + this.descInstitucionEducativa + '</option>'
            $("select#cbInstitucionEP").append(RowContent);
        });
        $("select#cbInstitucionEPe").html("");
        $.each(institucionEducativa, function () {
            var RowContent = '<option value=' + this.codigoInstitucionEducativa + '>' + this.descInstitucionEducativa + '</option>'
            $("select#cbInstitucionEPe").append(RowContent);
        });


        $("select#cbInstitucionPertenecePP").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbInstitucionPertenecePP").append(RowContent);
        });
        $("select#cbInstitucionPertenecePPe").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbInstitucionPertenecePPe").append(RowContent);
        });


        $("select#cbTipoPersonalM").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalM").append(RowContent);
        });
        $("select#cbTipoPersonalMe").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMe").append(RowContent);
        });


        $("select#cbCarreraUni").html("");
        $.each(carreraUniversitariaEspecialidad, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbCarreraUni").append(RowContent);
        });
        $("select#cbCarreraUnie").html("");
        $.each(carreraUniversitariaEspecialidad, function () {
            var RowContent = '<option value=' + this.codigoCarreraUniversitariaEspecialidad + '>' + this.descCarreraUniversitariaEspecialidad + '</option>'
            $("select#cbCarreraUnie").append(RowContent);
        });


        $("select#cbModalidadIngreso").html("");
        $.each(modalidadIngresoEsna, function () {
            var RowContent = '<option value=' + this.codigoModalidadIngresoEsna + '>' + this.descModalidadIngresoEsna + '</option>'
            $("select#cbModalidadIngreso").append(RowContent);
        });
        $("select#cbModalidadIngresoe").html("");
        $.each(modalidadIngresoEsna, function () {
            var RowContent = '<option value=' + this.codigoModalidadIngresoEsna + '>' + this.descModalidadIngresoEsna + '</option>'
            $("select#cbModalidadIngresoe").append(RowContent);
        });


        $("select#cbZonaNaval").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(zonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
        });


        $("select#cbPublicidadEs").html("");
        $.each(publicidadEsna, function () {
            var RowContent = '<option value=' + this.codigoPublicidadEsna + '>' + this.descPublicidadEsna + '</option>'
            $("select#cbPublicidadEs").append(RowContent);
        });
        $("select#cbPublicidadEse").html("");
        $.each(publicidadEsna, function () {
            var RowContent = '<option value=' + this.codigoPublicidadEsna + '>' + this.descPublicidadEsna + '</option>'
            $("select#cbPublicidadEse").append(RowContent);
        });

        $("select#cbDepartamentoNacimiento").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoNacimiento").append(RowContent);
        });
        $('select#cbDepartamentoNacimiento').append('<option selected disabled>Seleccionar Departamento</option>');

        $("select#cbDepartamentoDomicilio").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoDomicilio").append(RowContent);
        });
        $('select#cbDepartamentoDomicilio').append('<option selected disabled>Seleccionar Departamento</option>');

        $("select#cbDepartamentoInstitucion").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoInstitucion").append(RowContent);
        });
        $('select#cbDepartamentoInstitucion').append('<option selected disabled>Seleccionar Departamento</option>');


        $("select#cargasR").html("");
        $("select#cargas").html("");
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
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoNacimientoe").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoNacimientoe").append(RowContent);

                    });
                    $('#cbDepartamentoNacimientoe').val(departamento);
                    $("select#cbProvinciaNacimientoe").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaNacimientoe").append(RowContent);
                        }
                    });
                    $('#cbProvinciaNacimientoe').val(provincia);
                    $("select#cbDistritoNacimientoe").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
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
            var provincia = this.provinciaUbigeoId;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoDomicilioe").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoDomicilioe").append(RowContent);

                    });
                    $('#cbDepartamentoDomicilioe').val(departamento);
                    $("select#cbProvinciaDomicilioe").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaDomicilioe").append(RowContent);
                        }
                    });
                    $('#cbProvinciaDomicilioe').val(provincia);
                    $("select#cbDistritoDomicilioe").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoDomicilioe").append(RowContent);
                        }
                    });
                    $('#cbDistritoDomicilioe').val(iddistrito);
                }
            });


        }
    });
}



function encontrardatocombo3(id) {
    var iddistrito = id;

    $.each(distritoUbigeo, function () {
        if (this.distritoUbigeo == iddistrito) {
            var provincia = this.provinciaUbigeoId;

            $.each(provinciaUbigeo, function () {
                if (this.provinciaUbigeo == provincia) {
                    var departamento = this.departamentoUbigeo;
                    $("select#cbDepartamentoInstitucione").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoInstitucione").append(RowContent);

                    });
                    $('#cbDepartamentoInstitucione').val(departamento);
                    $("select#cbProvinciaInstitucione").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaInstitucione").append(RowContent);
                        }
                    });
                    $('#cbProvinciaInstitucione').val(provincia);
                    $("select#cbDistritoInstitucione").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoInstitucione").append(RowContent);
                        }
                    });
                    $('#cbDistritoInstitucione').val(iddistrito);
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
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
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
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoNacimiento").append(RowContent);
                }
            });
        }
    });
});

$('select#cbDepartamentoDomicilio').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaDomicilio").html("");
            $('select#cbProvinciaDomicilio').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaDomicilio").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoDomicilio").html("");
    $('select#cbDistritoDomicilio').append('<option selected disabled>Seleccionar Distrito</option>');
});
$('select#cbProvinciaDomicilio').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoDomicilio").html("");
            $('select#cbDistritoDomicilio').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoDomicilio").append(RowContent);
                }
            });
        }
    });
});

$('select#cbDepartamentoInstitucion').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaInstitucion").html("");
            $('select#cbProvinciaInstitucion').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaInstitucion").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoInstitucion").html("");
    $('select#cbDistritoInstitucion').append('<option selected disabled>Seleccionar Distrito</option>');
});
$('select#cbProvinciaInstitucion').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoInstitucion").html("");
            $('select#cbDistritoInstitucion').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoInstitucion").append(RowContent);
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
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
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
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoNacimientoe").append(RowContent);
                }
            });
        }
    });
});

$('select#cbDepartamentoDomicilioe').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaDomicilioe").html("");
            $('select#cbProvinciaDomicilioe').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaDomicilioe").append(RowContent);
                }
            });
        }
    });
});
$('select#cbProvinciaDomicilioe').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoDomicilioe").html("");
            $('select#cbDistritoDomicilioe').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoDomicilioe").append(RowContent);
                }
            });
        }
    });
});

$('select#cbDepartamentoInstitucione').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaInstitucione").html("");
            $('select#cbProvinciaInstitucione').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaInstitucione").append(RowContent);
                }
            });
        }
    });
});
$('select#cbProvinciaInstitucione').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoInstitucione").html("");
            $('select#cbDistritoInstitucione').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoInstitucione").append(RowContent);
                }
            });
        }
    });
});


function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DiresnaPostulantesEscuelaNaval/ReporteDPEN?idCarga=';
        $('#fecha').hide();
    }

}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";
    if (optReporteSelect = 1) {
        a.href = reporteSeleccionado + idCarga;
    }

    a.click();
});