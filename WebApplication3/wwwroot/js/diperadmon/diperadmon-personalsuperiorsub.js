var tblDiperadmonPersonalSuperiorSubalterno;
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
                                url: '/DiperadmonPersonalSuperiorSubalterno/Insertar',
                                data: {
                                    'DNIPSupSub': $('#txtDNI').val(),
                                    'CodigoProcedencia': $('#txtProcedencia').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalM').val(),
                                    'SexoPSupSub': $('#txtSexo').val(),
                                    'UbigeoNacimiento': $('#cbDistritoNacimiento').val(),
                                    'FechaNacimientoPSupSub': $('#txtFechaN').val(),
                                    'UbigeoLabora': $('#cbDistritoLabora').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'FechaIngresoDepPSupSub': $('#txtFechaI').val(),
                                    'EstadoCivilPSupSub': $('#txtEstadoCivil').val(),
                                    'CodigoGradoEstudioAlcanzado': $('#cbGradoEstudioA').val(),
                                    'CodigoSistemaPension': $('#cbSistemaP').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialdiadG').val(),
                                    'FechaIngresoInstitucionPSupSub': $('#txtFechaIaInst').val(),
                                    'FechaAltaPSupSub': $('#txtFechaAlta').val(),
                                    'FechaUltimoAscensoPSupSub': $('#txtFechaUAsce').val(),
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
                                    $('#tblDiperadmonPersonalSuperiorSubalterno').DataTable().ajax.reload();
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
                                url: '/DiperadmonPersonalSuperiorSubalterno/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPSupSub': $('#txtDNIe').val(),
                                    'CodigoProcedencia': $('#txtProcedenciae').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMe').val(),
                                    'SexoPSupSub': $('#txtSexoe').val(),
                                    'UbigeoNacimiento': $('#cbDistritoNacimientoe').val(),
                                    'FechaNacimientoPSupSub': $('#txtFechaNe').val(),
                                    'UbigeoLabora': $('#cbDistritoLaborae').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'FechaIngresoDepPSupSub': $('#txtFechaIe').val(),
                                    'EstadoCivilPSupSub': $('#txtEstadoCivile').val(),
                                    'CodigoGradoEstudioAlcanzado': $('#cbGradoEstudioAe').val(),
                                    'CodigoSistemaPension': $('#cbSistemaPe').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialdiadGe').val(),
                                    'FechaIngresoInstitucionPSupSub': $('#txtFechaIaInste').val(),
                                    'FechaAltaPSupSub': $('#txtFechaAltae').val(),
                                    'FechaUltimoAscensoPSupSub': $('#txtFechaUAscee').val(),
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
                                    $('#tblDiperadmonPersonalSuperiorSubalterno').DataTable().ajax.reload();
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

   tblDiperadmonPersonalSuperiorSubalterno=  $('#tblDiperadmonPersonalSuperiorSubalterno').DataTable({
        ajax: {
            "url": '/DiperadmonPersonalSuperiorSubalterno/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "personalSuperiorSubalternoId" },
            { "data": "dnipSupSub" },
            { "data": "descProcedencia" },
            { "data": "descGrado" },
            { "data": "sexo" },
            { "data": "descDistritoNacimiento" },
            { "data": "fechaNacimientoPSupSub" },
            { "data": "descDistritoLabora" },
            { "data": "nombreDependencia" },  
            { "data": "fechaIngresoDepPSupSub" },
            { "data": "estadoCivilPSupSub" },
            { "data": "descGradoEstudioAlcanzado" },
            { "data": "descSistemaPension" },
            { "data": "descEspecialidad" },
            { "data": "fechaIngresoInstitucion" },
            { "data": "fechaAltaPSupSub" },
            { "data": "fechaUltimoAscensoPSupSub" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.personalSuperiorSubalternoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.personalSuperiorSubalternoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diperadmon - Personal Militar Superior Y Subalterno',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diperadmon - Personal Militar Superior Y Subalterno',
                title: 'Diperadmon - Personal Militar Superior Y Subalterno',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diperadmon - Personal Militar Superior Y Subalterno',
                title: 'Diperadmon - Personal Militar Superior Y Subalterno',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diperadmon - Personal Militar Superior Y Subalterno',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16]
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
    tblDiperadmonPersonalSuperiorSubalterno.columns(17).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiperadmonPersonalSuperiorSubalterno.columns(17).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiperadmonPersonalSuperiorSubalterno/Mostrar?Id=' + Id, [], function (PersonalSuperiorSubalternoDTO) {
        $('#txtCodigo').val(PersonalSuperiorSubalternoDTO.personalSuperiorSubalternoId);
        $('#txtDNIe').val(PersonalSuperiorSubalternoDTO.dnipSupSub);
        $('#txtProcedenciae').val(PersonalSuperiorSubalternoDTO.codigoProcedencia);
        $('#cbGradoPersonalMe').val(PersonalSuperiorSubalternoDTO.codigoGradoPersonalMilitar);
        $('#txtSexoe').val(PersonalSuperiorSubalternoDTO.sexo);
        var iddistrito = PersonalSuperiorSubalternoDTO.ubigeoNacimiento;
        $('#cbDistritoNacimientoe').val(PersonalSuperiorSubalternoDTO.ubigeoNacimiento);
        $('#txtFechaNe').val(PersonalSuperiorSubalternoDTO.fechaNacimientoPSupSub);
        var iddistrito2 = PersonalSuperiorSubalternoDTO.ubigeoLabora;
        $('#cbDistritoLaborae').val(PersonalSuperiorSubalternoDTO.ubigeoLabora);
        $('#cbDependenciae').val(PersonalSuperiorSubalternoDTO.codigoDependencia);
        $('#txtFechaIe').val(PersonalSuperiorSubalternoDTO.fechaIngresoDepPSupSub);
        $('#txtEstadoCivile').val(PersonalSuperiorSubalternoDTO.estadoCivilPSupSub);
        $('#cbGradoEstudioAe').val(PersonalSuperiorSubalternoDTO.codigoGradoEstudioAlcanzado);
        $('#cbSistemaPe').val(PersonalSuperiorSubalternoDTO.codigoSistemaPension);
        $('#cbEspecialdiadGe').val(PersonalSuperiorSubalternoDTO.codigoEspecialidadGenericaPersonal);
        $('#txtFechaIaInste').val(PersonalSuperiorSubalternoDTO.fechaIngresoInstitucion);
        $('#txtFechaAltae').val(PersonalSuperiorSubalternoDTO.fechaAltaPSupSub);
        $('#txtFechaUAscee').val(PersonalSuperiorSubalternoDTO.fechaUltimoAscensoPSupSub);
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
                url: '/DiperadmonPersonalSuperiorSubalterno/Eliminar',
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
                    $('#tblDiperadmonPersonalSuperiorSubalterno').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDiperadmonPersonalSuperiorSubalterno() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiperadmonPersonalSuperiorSubalterno/MostrarDatos',
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
                            $("<td>").text(item.dnipSupSub),
                            $("<td>").text(item.codigoProcedencia),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.sexo),
                            $("<td>").text(item.ubigeoNacimiento),
                            $("<td>").text(item.fechaNacimientoPSupSub),
                            $("<td>").text(item.ubigeoLabora),
                            $("<td>").text(item.descDependencia),
                            $("<td>").text(item.fechaIngresoDepPSupSub),
                            $("<td>").text(item.estadoCivilPSupSub),
                            $("<td>").text(item.codigoGradoEstudioAlcanzado),
                            $("<td>").text(item.codigoSistemaPension),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.fechaIngresoInstitucion),
                            $("<td>").text(item.fechaAltaPSupSub),
                            $("<td>").text(item.fechaUltimoAscensoPSupSub)
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
    fetch("DiperadmonPersonalSuperiorSubalterno/EnviarDatos", {
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
    $.getJSON('/DiperadmonPersonalSuperiorSubalterno/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var dependencia = Json["data2"];
        var gradoEstudioAlcanzado = Json["data3"];
        var sistemaPension = Json["data4"];
        var especialidadGenericaPersonal = Json["data5"];
        distritoUbigeo = Json["data6"];
        provinciaUbigeo = Json["data7"];
        departamentoUbigeo = Json["data8"];
        var listaCargas = Json["data9"];
        var procedencia = Json["data10"];

        $("select#cbGradoPersonalM").html("");
        $("select#cbGradoPersonalMe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalM").append(RowContent);
            $("select#cbGradoPersonalMe").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");    
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbGradoEstudioA").html("");
        $("select#cbGradoEstudioAe").html("");
        $.each(gradoEstudioAlcanzado, function () {
            var RowContent = '<option value=' + this.codigoGradoEstudioAlcanzado + '>' + this.descGradoEstudioAlcanzado + '</option>'
            $("select#cbGradoEstudioA").append(RowContent);
            $("select#cbGradoEstudioAe").append(RowContent);
        });


        $("select#cbSistemaP").html("");
        $("select#cbSistemaPe").html("");
        $.each(sistemaPension, function () {
            var RowContent = '<option value=' + this.codigoSistemaPension + '>' + this.descSistemaPension + '</option>'
            $("select#cbSistemaP").append(RowContent);
            $("select#cbSistemaPe").append(RowContent);
        });

        $("select#cbEspecialdiadG").html("");
        $("select#cbEspecialdiadGe").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialdiadG").append(RowContent);
            $("select#cbEspecialdiadGe").append(RowContent);
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


        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });

        $("select#txtProcedencia").html("");
        $("select#txtProcedenciae").html("");
        $.each(procedencia, function () {
            var RowContent = '<option value=' + this.codigoProcedencia + '>' + this.descProcedencia + '</option>'
            $("select#txtProcedencia").append(RowContent);
            $("select#txtProcedenciae").append(RowContent);
        });
    });
}

function encontrardatocombo(id) {
    var iddistrito = '010101';

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
                    $("select#cbDistritoNacimientoe").html("");
                    $.each(distritoUbigeo, function () {
                        if (this.provinciaUbigeoId == provincia) {
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
    $("select#cbDistritoNacimiento").html("");
    $('select#cbDistritoNacimiento').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaNacimiento').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistritoNacimiento").html("");
            $('select#cbDistritoNacimiento').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
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
    $("select#cbDistritoLabora").html("");
    $('select#cbDistritoLabora').append('<option selected disabled>Seleccionar Distrito</option>');
});
$('select#cbProvinciaLabora').on('change', function () {

    var codigo = $(this).val();

    $.each(provinciaUbigeo, function () {
        if (this.provinciaUbigeoId == codigo) {
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
        if (this.departamentoUbigeoId == codigo) {
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
        if (this.provinciaUbigeoId == codigo) {
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
            $("select#cbDistritoLaborae").html("");
            $('select#cbDistritoLaborae').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(distritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoLaborae").append(RowContent);
                }
            });
        } 
    });
});
function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/DiperadmonPersonalSuperiorSubalterno/ReporteDPSS';
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