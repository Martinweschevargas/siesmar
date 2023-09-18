var tblDiredumarCapacitacionPerfecDeberPSupSub;
var reporteSeleccionado;
var optReporteSelect;

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
                                url: '/DiredumarCapacitacionPerfecDeberPSupSub/Insertar',
                                data: {
                                    'CIPCapaPerfDeber': $('#txtCIP').val(),
                                    'DNICapaPerfDeber': $('#txtDNI').val(),
                                    'NombreCapaPerfDeber': $('#txtNombre').val(),
                                    'FechaNacimientoCapaPerfDeber': $('#txtFechaN').val(),
                                    'SexoCapaPerfDeber': $('#txtSexo').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoTipoPersonalMilitar': $('#txtTipoPersonal').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalM').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericaP').val(),
                                    'CapacitacioLineaCapaPerfDeber': $('#txtCapacitacionC').val(),
                                    'InscripcionCapaPerfDeber': $('#txtInscripcion').val(),
                                    'TipoProgramaCapaPerfDeber': $('#txtTipoPrograma').val(),
                                    'NumericoPais': $('#cbPaisU').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadaMilitar').val(),
                                    'CodigoCodigoEscuela': $('#cbCodigoEscuela').val(),
                                    'MencionCursoCapacitacion': $('#txtMencionCurso').val(),
                                    'CodigoClasificacionCurso': $('#cbClasificacionCurso').val(),
                                    'FinanciamientoCapaPerfDeber': $('#txtFinanciamiento').val(),
                                    'FechaInicioCapaPerfDeber': $('#txtFechaIinicio').val(),
                                    'FechaTerminoCapaPerfDeber': $('#txtFechaTermino').val(),
                                    'FechaRegistroCapaPerfDeber': $('#txtFechaRegistro').val(),
                                    'HoraCapacitacionCapaPerfDeber': $('#txtHoraCapacitacion').val(),
                                    'CodigoMotivoTerminoCurso': $('#cbMotivoTerminoC').val(),
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
                                    $('#tblDiredumarCapacitacionPerfecDeberPSupSub').DataTable().ajax.reload();
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
                                url: '/DiredumarCapacitacionPerfecDeberPSupSub/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CIPCapaPerfDeber': $('#txtCIPe').val(),
                                    'DNICapaPerfDeber': $('#txtDNIe').val(),
                                    'NombreCapaPerfDeber': $('#txtNombree').val(),
                                    'FechaNacimientoCapaPerfDeber': $('#txtFechaNe').val(),
                                    'SexoCapaPerfDeber': $('#txtSexoe').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoTipoPersonalMilitar': $('#txtTipoPersonale').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMe').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialidadGenericaPe').val(),
                                    'CapacitacioLineaCapaPerfDeber': $('#txtCapacitacionCe').val(),
                                    'InscripcionCapaPerfDeber': $('#txtInscripcione').val(),
                                    'TipoProgramaCapaPerfDeber': $('#txtTipoProgramae').val(),
                                    'NumericoPais': $('#cbPaisUe').val(),
                                    'CodigoEntidadMilitar': $('#cbEntidadaMilitare').val(),
                                    'CodigoCodigoEscuela': $('#cbCodigoEscuelae').val(),
                                    'MencionCursoCapacitacion': $('#txtMencionCursoe').val(),
                                    'CodigoClasificacionCurso': $('#cbClasificacionCursoe').val(),
                                    'FinanciamientoCapaPerfDeber': $('#txtFinanciamientoe').val(),
                                    'FechaInicioCapaPerfDeber': $('#txtFechaIinicioe').val(),
                                    'FechaTerminoCapaPerfDeber': $('#txtFechaTerminoe').val(),
                                    'FechaRegistroCapaPerfDeber': $('#txtFechaRegistroe').val(),
                                    'HoraCapacitacionCapaPerfDeber': $('#txtHoraCapacitacione').val(),
                                    'CodigoMotivoTerminoCurso': $('#cbMotivoTerminoCe').val(),
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
                                    $('#tblDiredumarCapacitacionPerfecDeberPSupSub').DataTable().ajax.reload();
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


    tblDiredumarCapacitacionPerfecDeberPSupSub = $('#tblDiredumarCapacitacionPerfecDeberPSupSub').DataTable({
        ajax: {
            "url": '/DiredumarCapacitacionPerfecDeberPSupSub/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "capacitacionPerfeccionamientoDeberId" },
            { "data": "cipCapaPerfDeber" },
            { "data": "dniCapaPerfDeber" },
            { "data": "nombreCapaPerfDeber" },
            { "data": "fechaNacimientoCapaPerfDeber" },
            { "data": "sexoCapaPerfDeber" },
            { "data": "descDependencia" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "capacitacioLineaCapaPerfDeber" },
            { "data": "inscripcionCapaPerfDeber" },
            { "data": "tipoProgramaCapaPerfDeber" },
            { "data": "nombrePais" },
            { "data": "descEntidadMilitar" },
            { "data": "descCodigoEscuela" },
            { "data": "mencionCursoCapacitacion" },
            { "data": "descClasificacionCurso" },
            { "data": "financiamientoCapaPerfDeber" },
            { "data": "fechaInicioCapaPerfDeber" },
            { "data": "fechaTerminoCapaPerfDeber" },
            { "data": "fechaRegistroCapaPerfDeber" },
            { "data": "horaCapacitacionCapaPerfDeber" },
            { "data": "descMotivoTerminoCurso" },
            { "data": "cargaId" }, 

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.capacitacionPerfeccionamientoDeberId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.capacitacionPerfeccionamientoDeberId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diredumar - Capacitación y Perfeccionamiento del Personal Superior y Subalterno que Debe Capacitarse de Acuerdo Linea de Carrera ',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diredumar - Capacitación y Perfeccionamiento del Personal Superior y Subalterno que Debe Capacitarse de Acuerdo Linea de Carrera ',
                title: 'Diredumar - Capacitación y Perfeccionamiento del Personal Superior y Subalterno que Debe Capacitarse de Acuerdo Linea de Carrera ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diredumar - Capacitación y Perfeccionamiento del Personal Superior y Subalterno que Debe Capacitarse de Acuerdo Linea de Carrera ',
                title: 'Diredumar - Capacitación y Perfeccionamiento del Personal Superior y Subalterno que Debe Capacitarse de Acuerdo Linea de Carrera ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diredumar - Capacitación y Perfeccionamiento del Personal Superior y Subalterno que Debe Capacitarse de Acuerdo Linea de Carrera ',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22, 23]
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
    tblDiredumarCapacitacionPerfecDeberPSupSub.columns(24).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiredumarCapacitacionPerfecDeberPSupSub.columns(24).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiredumarCapacitacionPerfecDeberPSupSub/Mostrar?Id=' + Id, [], function (CapacitacionPerfecDeberPSupSubDTO) {
        $('#txtCodigo').val(CapacitacionPerfecDeberPSupSubDTO.capacitacionPerfeccionamientoDeberId);
        $('#txtCIPe').val(CapacitacionPerfecDeberPSupSubDTO.cipCapaPerfDeber);
        $('#txtDNIe').val(CapacitacionPerfecDeberPSupSubDTO.dniCapaPerfDeber);
        $('#txtNombree').val(CapacitacionPerfecDeberPSupSubDTO.nombreCapaPerfDeber);
        $('#txtFechaNe').val(CapacitacionPerfecDeberPSupSubDTO.fechaNacimientoCapaPerfDeber);
        $('#txtSexoe').val(CapacitacionPerfecDeberPSupSubDTO.sexoCapaPerfDeber);
        $('#cbDependenciae').val(CapacitacionPerfecDeberPSupSubDTO.codigoDependencia);
        $('#txtTipoPersonale').val(CapacitacionPerfecDeberPSupSubDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMe').val(CapacitacionPerfecDeberPSupSubDTO.codigoGradoPersonalMilitar);
        $('#cbEspecialidadGenericaPe').val(CapacitacionPerfecDeberPSupSubDTO.codigoEspecialidadGenericaPersonal);
        $('#txtCapacitacionCe').val(CapacitacionPerfecDeberPSupSubDTO.capacitacioLineaCapaPerfDeber);
        $('#txtInscripcione').val(CapacitacionPerfecDeberPSupSubDTO.inscripcionCapaPerfDeber);
        $('#txtTipoProgramae').val(CapacitacionPerfecDeberPSupSubDTO.tipoProgramaCapaPerfDeber);
        $('#cbPaisUe').val(CapacitacionPerfecDeberPSupSubDTO.numericoPais);
        $('#cbEntidadaMilitare').val(CapacitacionPerfecDeberPSupSubDTO.codigoEntidadMilitar);
        $('#cbCodigoEscuelae').val(CapacitacionPerfecDeberPSupSubDTO.codigoCodigoEscuela);
        $('#txtMencionCursoe').val(CapacitacionPerfecDeberPSupSubDTO.mencionCursoCapacitacion);
        $('#cbClasificacionCursoe').val(CapacitacionPerfecDeberPSupSubDTO.codigoClasificacionCurso);
        $('#txtFinanciamientoe').val(CapacitacionPerfecDeberPSupSubDTO.financiamientoCapaPerfDeber);
        $('#txtFechaIinicioe').val(CapacitacionPerfecDeberPSupSubDTO.fechaInicioCapaPerfDeber);
        $('#txtFechaTerminoe').val(CapacitacionPerfecDeberPSupSubDTO.fechaTerminoCapaPerfDeber);
        $('#txtFechaRegistroe').val(CapacitacionPerfecDeberPSupSubDTO.fechaRegistroCapaPerfDeber);
        $('#txtHoraCapacitacione').val(CapacitacionPerfecDeberPSupSubDTO.horaCapacitacionCapaPerfDeber);
        $('#cbMotivoTerminoCe').val(CapacitacionPerfecDeberPSupSubDTO.codigoMotivoTerminoCurso);
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
                url: '/DiredumarCapacitacionPerfecDeberPSupSub/Eliminar',
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
                    $('#tblDiredumarCapacitacionPerfecDeberPSupSub').DataTable().ajax.reload();
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
                url: '/DiredumarCapacitacionPerfecDeberPSupSub/EliminarCarga',
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
                    $('#tblDiredumarCapacitacionPerfecDeberPSupSub').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiredumarCapacitacionPerfecDeberPSupSub() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiredumarCapacitacionPerfecDeberPSupSub/MostrarDatos',
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
                            $("<td>").text(item.cipCapaPerfDeber),
                            $("<td>").text(item.dniCapaPerfDeber),
                            $("<td>").text(item.nombreCapaPerfDeber),
                            $("<td>").text(item.fechaNacimientoCapaPerfDeber),
                            $("<td>").text(item.sexoCapaPerfDeber),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoTipoPersonalMilitar),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.capacitacioLineaCapaPerfDeber),
                            $("<td>").text(item.inscripcionCapaPerfDeber),
                            $("<td>").text(item.tipoProgramaCapaPerfDeber),
                            $("<td>").text(item.numericoPais),
                            $("<td>").text(item.codigoEntidadMilitar),
                            $("<td>").text(item.codigoCodigoEscuela),
                            $("<td>").text(item.mencionCursoCapacitacion),
                            $("<td>").text(item.codigoClasificacionCurso),
                            $("<td>").text(item.financiamientoCapaPerfDeber),
                            $("<td>").text(item.fechaInicioCapaPerfDeber),
                            $("<td>").text(item.fechaTerminoCapaPerfDeber),
                            $("<td>").text(item.fechaRegistroCapaPerfDeber),
                            $("<td>").text(item.horaCapacitacionCapaPerfDeber),
                            $("<td>").text(item.codigoMotivoTerminoCurso)
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
    fetch("DiredumarCapacitacionPerfecDeberPSupSub/EnviarDatos", {
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
                    'Ocurrio un problema. '+ mensaje,
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/DiredumarCapacitacionPerfecDeberPSupSub/cargaCombs', [], function (Json) {
        var dependencia = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var especialidadGenericaPersonal = Json["data3"];
        var paisUbigeo = Json["data4"];
        var entidadMilitar = Json["data5"];
        var codigoEscuela = Json["data6"];
        var clasificacionCurso = Json["data7"];
        var motivoTerminoCurso = Json["data8"];
        var tipoPersonalMilitar = Json["data9"];
        var listaCargas = Json["data10"];

        $("select#cbDependencia").html("");
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
            $("select#cbDependenciae").append(RowContent);
        });

        $("select#cbGradoPersonalM").html("");
        $("select#cbGradoPersonalMe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalM").append(RowContent);
            $("select#cbGradoPersonalMe").append(RowContent);
        });

        $("select#cbEspecialidadGenericaP").html("");
        $("select#cbEspecialidadGenericaPe").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaP").append(RowContent);
            $("select#cbEspecialidadGenericaPe").append(RowContent);
        });

        $("select#cbPaisU").html("");
        $("select#cbPaisUe").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.numerico + '>' + this.nombrePais + '</option>'
            $("select#cbPaisU").append(RowContent);
            $("select#cbPaisUe").append(RowContent);
        });


        $("select#cbEntidadaMilitar").html("");
        $("select#cbEntidadaMilitare").html("");
        $.each(entidadMilitar, function () {
            var RowContent = '<option value=' + this.codigoEntidadMilitar + '>' + this.descEntidadMilitar + '</option>'
            $("select#cbEntidadaMilitar").append(RowContent);
            $("select#cbEntidadaMilitare").append(RowContent);
        });

        $("select#cbCodigoEscuela").html("");
        $("select#cbCodigoEscuelae").html("");
        $.each(codigoEscuela, function () {
            var RowContent = '<option value=' + this.codigoCodigoEscuela + '>' + this.descCodigoEscuela + '</option>'
            $("select#cbCodigoEscuela").append(RowContent);
            $("select#cbCodigoEscuelae").append(RowContent);
        });

        $("select#cbClasificacionCurso").html("");
        $("select#cbClasificacionCursoe").html("");
        $.each(clasificacionCurso, function () {
            var RowContent = '<option value=' + this.codigoClasificacionCurso + '>' + this.descClasificacionCurso + '</option>'
            $("select#cbClasificacionCurso").append(RowContent);
            $("select#cbClasificacionCursoe").append(RowContent);
        });

        $("select#cbMotivoTerminoC").html("");
        $("select#cbMotivoTerminoCe").html("");
        $.each(motivoTerminoCurso, function () {
            var RowContent = '<option value=' + this.codigoMotivoTerminoCurso + '>' + this.descMotivoTerminoCurso + '</option>'
            $("select#cbMotivoTerminoC").append(RowContent);
            $("select#cbMotivoTerminoCe").append(RowContent);
        });

        $("select#txtTipoPersonal").html("");
        $("select#txtTipoPersonale").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#txtTipoPersonal").append(RowContent);
            $("select#txtTipoPersonale").append(RowContent);
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

function optReporte(id) {
    optReporteSelect = id;

    reporteSeleccionado = '/DiredumarCapacitacionPerfecDeberPSupSub/ReporteARTR';
}


$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();
    var a = document.createElement('a');
    a.target = "_blank";

    var numCarga;
    if (idCarga == "0") {
        numCarga = '?CargaId=' + "";
    } else {
        numCarga = '?CargaId=' + idCarga;
    }

    if (optReporteSelect == 1) {
        a.href = reporteSeleccionado + numCarga;
    }
    a.click();
});
