var tblComesguardIngresoDatoServicioLavanderia;
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
                                url: '/ComesguardIngresoDatoServicioLavanderia/Insertar',
                                data: {
                                    'FechaIngreso': $('#txtFechaIngreso').val(),
                                    'FechaRecojo': $('#txtFechaRecojo').val(),
                                    'CIP': $('#txtCIP').val(),
                                    'CodigoGradoPersonalMilitar ': $('#cbGradoPersonalMilitar').val(),
                                    'CodigoEspecialidadGenericaPersonal ': $('#cbEspecialidadGenericaPersonal').val(),
                                    'Sexo': $('#txtSexo').val(),
                                    'CodigoDependencia ': $('#cbDependencia').val(),
                                    'CantidadPrendas': $('#txtCantidadPrendas').val(), 
                                    'CargaId': $('#cargasR').val(), 
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
                                    $('#tblComesguardIngresoDatoServicioLavanderia').DataTable().ajax.reload();
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
                                url: '/ComesguardIngresoDatoServicioLavanderia/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaIngreso': $('#txtFechaIngresoe').val(),
                                    'FechaRecojo': $('#txtFechaRecojoe').val(),
                                    'CIP': $('#txtCIPe').val(),
                                    'CodigoGradoPersonalMilitar ': $('#cbGradoPersonalMilitare').val(),
                                    'CodigoEspecialidadGenericaPersonal ': $('#cbEspecialidadGenericaPersonale').val(),
                                    'Sexo': $('#txtSexoe').val(),
                                    'CodigoDependencia ': $('#cbDependenciae').val(),
                                    'CantidadPrendas': $('#txtCantidadPrendase').val(), 
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
                                    $('#tblComesguardIngresoDatoServicioLavanderia').DataTable().ajax.reload();
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

        tblComesguardIngresoDatoServicioLavanderia = $('#tblComesguardIngresoDatoServicioLavanderia').DataTable({
        ajax: {
            "url": '/ComesguardIngresoDatoServicioLavanderia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ingresoDatoServicioLavanderiaId" },
            { "data": "fechaIngreso" },
            { "data": "fechaRecojo" },
            { "data": "cip" },
            { "data": "descGrado" },
            { "data": "descEspecialidad" },
            { "data": "sexo" },
            { "data": "nombreDependencia" },
            { "data": "cantidadPrendas" }, 
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ingresoDatoServicioLavanderiaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ingresoDatoServicioLavanderiaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de lavandería',
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
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de lavandería',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de lavandería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comesguard - Formato para el ingreso de datos del servicio de lavandería',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de lavandería',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comesguard - Formato para el ingreso de datos del servicio de lavandería',
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
    tblComesguardIngresoDatoServicioLavanderia.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComesguardIngresoDatoServicioLavanderia.columns(9).search('').draw();
}
function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComesguardIngresoDatoServicioLavanderia/Mostrar?Id=' + Id, [], function (IngresoDatoServicioLavanderiaDTO) {
        $('#txtCodigo').val(IngresoDatoServicioLavanderiaDTO.ingresoDatoServicioLavanderiaId);
        $('#txtFechaIngresoe').val(IngresoDatoServicioLavanderiaDTO.fechaIngreso);
        $('#txtFechaRecojoe').val(IngresoDatoServicioLavanderiaDTO.fechaRecojo);
        $('#txtCIPe').val(IngresoDatoServicioLavanderiaDTO.cip);
        $('#cbGradoPersonalMilitare').val(IngresoDatoServicioLavanderiaDTO.codigoGradoPersonalMilitar);
        $('#cbEspecialidadGenericaPersonale').val(IngresoDatoServicioLavanderiaDTO.codigoEspecialidadGenericaPersonal);
        $('#txtSexoe').val(IngresoDatoServicioLavanderiaDTO.sexo);
        $('#cbDependenciae').val(IngresoDatoServicioLavanderiaDTO.codigoDependencia);
        $('#txtCantidadPrendase').val(IngresoDatoServicioLavanderiaDTO.cantidadPrendas); 
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
                url: '/ComesguardIngresoDatoServicioLavanderia/Eliminar',
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
                    $('#tblComesguardIngresoDatoServicioLavanderia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComesguardIngresoDatoServicioLavanderia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComesguardIngresoDatoServicioLavanderia/MostrarDatos',
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
                            $("<td>").text(item.fechaIngreso),
                            $("<td>").text(item.fechaRecojo),
                            $("<td>").text(item.cip),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.sexo),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.cantidadPrendas),
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
    fetch("ComesguardIngresoDatoServicioLavanderia/EnviarDatos", {
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
    $.getJSON('/ComesguardIngresoDatoServicioLavanderia/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var especialidadGenericaPersonal = Json["data2"];
        var dependencia = Json["data3"];
        var listaCargas = Json["data4"];


        $("select#cbGradoPersonalMilitar").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
        });
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });


        $("select#cbEspecialidadGenericaPersonal").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonal").append(RowContent);
        });
        $("select#cbEspecialidadGenericaPersonale").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialidadGenericaPersonale").append(RowContent);
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
    if (id == 1) {
        reporteSeleccionado = '/ComesguardIngresoDatoServicioLavanderia/ReporteCIDSL?idCarga=';
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