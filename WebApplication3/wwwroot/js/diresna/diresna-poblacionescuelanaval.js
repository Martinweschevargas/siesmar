var tblDiresnaPoblacionEscuelaNaval;
var distritoUbigeo;
var provinciaUbigeo;
var departamentoUbigeo;

var reporteSeleccionado;
var optReporteSelect;
$('select#cbProvinciaNacimiento').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoNacimiento').append('<option selected disabled>Seleccionar Distrito</option>');

$('select#cbProvinciaDomicilio').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoDomicilio').append('<option selected disabled>Seleccionar Distrito</option>');

$('select#cbProvinciaProcedencia').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoProcedencia').append('<option selected disabled>Seleccionar Distrito</option>');

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
                                url: '/DiresnaPoblacionEscuelaNaval/Insertar',
                                data: {
                                    'DNIEstudianteEsna': $('#txtDNI').val(),
                                    'SexoEstudianteEsna': $('#txtGenero').val(),
                                    'FechaNacimientoEstudiante': $('#txtFechaNacimiento').val(),
                                    'TallaEstudianteEsna': $('#txtTalla').val(),
                                    'PesoEstudianteEsna': $('#txtPeso').val(),
                                    'DistritoNacimientoEstudiante': $('#cbDistritoNacimiento').val(),
                                    'DistritoDomicilioEstudiante': $('#cbUDistritoDomicilio').val(),
                                    'FechaIngresoEstudiante': $('#txtFechaI').val(),
                                    'BecadoEsna': $('#txtBecadoESNA').val(),
                                    'DistritoProcedencia': $('#cbDistritoProcedencia').val(),
                                    'CodigoAnioAcademicoEsna': $('#cbAnioAcademico').val(),
                                    'SemestreAcademico': $('#txtSemestreAcademico').val(),
                                    'IRASEstudianteEsna': $('#txtIRASEstudiante').val(),
                                    'NotaCaracterMilitar': $('#txtNotaCaracterM').val(),
                                    'NotaFormacionFisica': $('#txtNotaFormacionF').val(),
                                    'NotaConductaEstudiante': $('#txtNotaConducta').val(),
                                    'IRGSEstudianteEsna': $('#txtIRGS').val(),
                                    'IRGASEstudianteEsna': $('#txtIRGS').val(),
                                    'OrdenMerito': $('#txtOrdenMerito').val(),
                                    'CodigoResultadoTerminoSemestre': $('#cbResultadoTSemestre').val(),
                                    'CodigoCausalBaja': $('#cbCausasBaja').val(),
                                    'CodigoTipoAdmisionIngreso': $('#cbTipoAdmisionI').val(), 
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
                                    $('#tblDiresnaPoblacionEscuelaNaval').DataTable().ajax.reload();
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
                                url: '/DiresnaPoblacionEscuelaNaval/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIEstudianteEsna': $('#txtDNIe').val(),
                                    'SexoEstudianteEsna': $('#txtGeneroe').val(),
                                    'FechaNacimientoEstudiante': $('#txtFechaNacimientoe').val(),
                                    'TallaEstudianteEsna': $('#txtTallae').val(),
                                    'PesoEstudianteEsna': $('#txtPesoe').val(),
                                    'DistritoNacimientoEstudiante': $('#cbDistritoNacimientoe').val(),
                                    'DistritoDomicilioEstudiante': $('#cbUDistritoDomicilioe').val(),
                                    'FechaIngresoEstudiante': $('#txtFechaIe').val(),
                                    'BecadoEsna': $('#txtBecadoESNAe').val(),
                                    'DistritoProcedencia': $('#cbUDistritoProcedenciae').val(),
                                    'CodigoAnioAcademicoEsna': $('#cbAnioAcademicoe').val(),
                                    'SemestreAcademico': $('#txtSemestreAcademicoe').val(),
                                    'IRASEstudianteEsna': $('#txtIRASEstudiantee').val(),
                                    'NotaCaracterMilitar': $('#txtNotaCaracterMe').val(),
                                    'NotaFormacionFisica': $('#txtNotaFormacionFe').val(),
                                    'NotaConductaEstudiante': $('#txtNotaConductae').val(),
                                    'IRGSEstudianteEsna': $('#txtIRGSe').val(),
                                    'IRGASEstudianteEsna': $('#txtIRGSe').val(),
                                    'OrdenMerito': $('#txtOrdenMeritoe').val(),
                                    'CodigoResultadoTerminoSemestre': $('#cbResultadoTSemestree').val(),
                                    'CodigoCausalBaja': $('#cbCausasBajae').val(),
                                    'CodigoTipoAdmisionIngreso': $('#cbTipoAdmisionIe').val(), 
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
                                    $('#tblDiresnaPoblacionEscuelaNaval').DataTable().ajax.reload();
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

        tblDiresnaPoblacionEscuelaNaval=  $('#tblDiresnaPoblacionEscuelaNaval').DataTable({
        ajax: {
            "url": '/DiresnaPoblacionEscuelaNaval/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "poblacionEscuelaNavalId" },
            { "data": "dniEstudianteEsna" },
            { "data": "sexoEstudianteEsna" },
            { "data": "fechaNacimientoEstudiante" },
            { "data": "tallaEstudianteEsna" },
            { "data": "pesoEstudianteEsna" },
            { "data": "descDistrito" },
            { "data": "descDistrito" },
            { "data": "fechaIngresoEstudiante" },
            { "data": "becadoEsna" },
            { "data": "descDistrito" },
            { "data": "anioAcademicoEsnaId" },
            { "data": "semestreAcademico" },
            { "data": "iraSEstudianteEsna" },
            { "data": "notaCaracterMilitar" },
            { "data": "notaFormacionFisica" },
            { "data": "notaConductaEstudiante" },
            { "data": "irgSEstudianteEsna" },
            { "data": "irgASEstudianteEsna" },
            { "data": "ordenMerito" },
            { "data": "resultadoTerminoSemestreId" },
            { "data": "causalBajaId" },
            { "data": "tipoAdmisionIngresoId" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.poblacionEscuelaNavalId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.poblacionEscuelaNavalId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diresna - Población Escuela Naval',
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
                filename: 'Diresna - Población Escuela Naval',
                title: 'Diresna - Población Escuela Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diresna - Población Escuela Naval',
                title: 'Diresna - Población Escuela Naval',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7,8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diresna - Población Escuela Naval',
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
    tblDiresnaPoblacionEscuelaNaval.columns(23).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiresnaPoblacionEscuelaNaval.columns(23).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiresnaPoblacionEscuelaNaval/Mostrar?Id=' + Id, [], function (PoblacionEscuelaNavalDTO) {
        $('#txtCodigo').val(PoblacionEscuelaNavalDTO.poblacionEscuelaNavalId);
        $('#txtDNIe').val(PoblacionEscuelaNavalDTO.dniEstudianteEsna);
        $('#txtGeneroe').val(PoblacionEscuelaNavalDTO.sexoEstudianteEsna);
        $('#txtFechaNacimientoe').val(PoblacionEscuelaNavalDTO.fechaNacimientoEstudiante);
        $('#txtTallae').val(PoblacionEscuelaNavalDTO.tallaEstudianteEsna);
        $('#txtPesoe').val(PoblacionEscuelaNavalDTO.pesoEstudianteEsna);
        var iddistrito = PoblacionEscuelaNavalDTO.distritoNacimientoEstudiante;
        var iddistrito2 = PoblacionEscuelaNavalDTO.distritoDomicilioEstudiante;
        $('#txtFechaIe').val(PoblacionEscuelaNavalDTO.fechaIngresoEstudiante);
        $('#txtBecadoESNAe').val(PoblacionEscuelaNavalDTO.becadoEsna);
        var iddistrito3 = PoblacionEscuelaNavalDTO.distritoProcedencia;
        $('#cbAnioAcademicoe').val(PoblacionEscuelaNavalDTO.codigoAnioAcademicoEsna);
        $('#txtSemestreAcademicoe').val(PoblacionEscuelaNavalDTO.semestreAcademico);
        $('#txtIRASEstudiantee').val(PoblacionEscuelaNavalDTO.iraSEstudianteEsna);
        $('#txtNotaCaracterMe').val(PoblacionEscuelaNavalDTO.notaCaracterMilitar);
        $('#txtNotaFormacionFe').val(PoblacionEscuelaNavalDTO.notaFormacionFisica);
        $('#txtNotaConductae').val(PoblacionEscuelaNavalDTO.notaConductaEstudiante);
        $('#txtIRGSe').val(PoblacionEscuelaNavalDTO.irgSEstudianteEsna);
        $('#txtIRGSe').val(PoblacionEscuelaNavalDTO.irgASEstudianteEsna);
        $('#txtOrdenMeritoe').val(PoblacionEscuelaNavalDTO.ordenMerito);
        $('#cbResultadoTSemestree').val(PoblacionEscuelaNavalDTO.codigoResultadoTerminoSemestre);
        $('#cbCausasBajae').val(PoblacionEscuelaNavalDTO.codigoCausalBaja);
        $('#cbTipoAdmisionIe').val(PoblacionEscuelaNavalDTO.codigoTipoAdmisionIngreso);
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
                url: '/DiresnaPoblacionEscuelaNaval/Eliminar',
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
                    $('#tblDiresnaPoblacionEscuelaNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
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
                url: '/DiresnaPoblacionEscuelaNaval/EliminarCarga',
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
                    cargaDatos();
                    $('#tblDiresnaPoblacionEscuelaNaval').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiresnaPoblacionEscuelaNaval() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiresnaPoblacionEscuelaNaval/MostrarDatos',
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
                            $("<td>").text(item.dniEstudianteEsna),
                            $("<td>").text(item.sexoEstudianteEsna),
                            $("<td>").text(item.fechaNacimientoEstudiante),
                            $("<td>").text(item.tallaEstudianteEsna),
                            $("<td>").text(item.pesoEstudianteEsna),
                            $("<td>").text(item.ubigeoNacimiento),
                            $("<td>").text(item.ubigeoDomicilio),
                            $("<td>").text(item.fechaIngresoEstudiante),
                            $("<td>").text(item.becadoEsna),
                            $("<td>").text(item.ubigeoProcedencia),
                            $("<td>").text(item.codigoAnioAcademicoEsna),
                            $("<td>").text(item.semestreAcademico),
                            $("<td>").text(item.irasEstudianteEsna),
                            $("<td>").text(item.notaCaracterMilitar),
                            $("<td>").text(item.notaFormacionFisica),
                            $("<td>").text(item.notaConductaEstudiante),
                            $("<td>").text(item.irgsEstudianteEsna),
                            $("<td>").text(item.irgasEstudianteEsna),
                            $("<td>").text(item.ordenMerito),
                            $("<td>").text(item.codigoResultadoTerminoSemestre),
                            $("<td>").text(item.codigoCausalBaja),
                            $("<td>").text(item.codigoTipoAdmisionIngreso),
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
    fetch("DiresnaPoblacionEscuelaNaval/EnviarDatos", {
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
    $.getJSON('/DiresnaPoblacionEscuelaNaval/cargaCombs', [], function (Json) {
        var añoAcademicoEsna = Json["data1"];
        var resultadoTerminoSemestre = Json["data2"];
        var causalBaja = Json["data3"];
        var tipoAdmisionIngreso = Json["data4"];
        distritoUbigeo = Json["data5"];
        provinciaUbigeo = Json["data6"];
        departamentoUbigeo = Json["data7"];
        var listaCargas = Json["data8"];

        $("select#cbAnioAcademico").html("");
        $("select#cbAnioAcademicoe").html("");
        $.each(añoAcademicoEsna, function () {
            var RowContent = '<option value=' + this.codigoAnioAcademicoEsna + '>' + this.descAnioAcademicoEsna + '</option>'
            $("select#cbAnioAcademico").append(RowContent);
            $("select#cbAnioAcademicoe").append(RowContent);
        });

        $("select#cbResultadoTSemestre").html("");
        $("select#cbResultadoTSemestree").html("");
        $.each(resultadoTerminoSemestre, function () {
            var RowContent = '<option value=' + this.codigoResultadoTerminoSemestre + '>' + this.descResultadoTerminoSemestre + '</option>'
            $("select#cbResultadoTSemestre").append(RowContent);
            $("select#cbResultadoTSemestree").append(RowContent);
        });

        $("select#cbCausasBaja").html("");
        $("select#cbCausasBajae").html("");
        $.each(causalBaja, function () {
            var RowContent = '<option value=' + this.codigoCausalBaja + '>' + this.descCausalBaja + '</option>'
            $("select#cbCausasBaja").append(RowContent);
            $("select#cbCausasBajae").append(RowContent);
        });

        $("select#cbTipoAdmisionI").html("");
        $("select#cbTipoAdmisionIe").html("");
        $.each(tipoAdmisionIngreso, function () {
            var RowContent = '<option value=' + this.codigoTipoAdmisionIngreso + '>' + this.descTipoAdmisionIngreso + '</option>'
            $("select#cbTipoAdmisionI").append(RowContent);
            $("select#cbTipoAdmisionIe").append(RowContent);
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

        $("select#cbDepartamentoProcedencia").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoProcedencia").append(RowContent);
        });
        $('select#cbDepartamentoProcedencia').append('<option selected disabled>Seleccionar Departamento</option>');


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
                    $("select#cbDepartamentoProcedenciae").html("");
                    $.each(departamentoUbigeo, function () {
                        var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamento + '</option>'
                        $("select#cbDepartamentoProcedenciae").append(RowContent);

                    });
                    $('#cbDepartamentoProcedenciae').val(departamento);
                    $("select#cbProvinciaProcedenciae").html("");
                    $.each(provinciaUbigeo, function (index) {
                        if (this.departamentoUbigeo == departamento) {
                            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                            $("select#cbProvinciaProcedenciae").append(RowContent);
                        }
                    });
                    $('#cbProvinciaProcedenciae').val(provincia);
                    $("select#cbDistritoProcedenciae").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeo == provincia) {
                            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                            $("select#cbDistritoProcedenciae").append(RowContent);
                        }
                    });
                    $('#cbDistritoProcedenciae').val(iddistrito);
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

$('select#cbDepartamentoProcedencia').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaProcedencia").html("");
            $('select#cbProvinciaProcedencia').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaProcedencia").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoProcedencia").html("");
    $('select#cbDistritoProcedencia').append('<option selected disabled>Seleccionar Distrito</option>');
});
$('select#cbProvinciaProcedencia').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoProcedencia").html("");
            $('select#cbDistritoProcedencia').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoProcedencia").append(RowContent);
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

$('select#cbDepartamentoProcedenciae').on('change', function () {

    var codigo = $(this).val();

    $.each(departamentoUbigeo, function () {
        if (this.departamentoUbigeo == codigo) {
            $("select#cbProvinciaProcedenciae").html("");
            $('select#cbProvinciaProcedenciae').append('<option selected disabled>Seleccionar Provincia</option>');
            $.each(provinciaUbigeo, function (index) {
                if (this.departamentoUbigeo == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaProcedenciae").append(RowContent);
                }
            });
        }
    });
});
$('select#cbProvinciaProcedenciae').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeo == codigo) {
            $("select#cbDistritoProcedenciae").html("");
            $('select#cbDistritoProcedenciae').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeo == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoProcedenciae").append(RowContent);
                }
            });
        }
    });
});

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DiresnaPoblacionEscuelaNaval/ReporteDPEN?idCarga=';
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