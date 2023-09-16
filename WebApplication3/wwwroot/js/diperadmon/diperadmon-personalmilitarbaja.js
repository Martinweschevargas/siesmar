var tblDiperadmonPersonalMilitarRetiroBaja;
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
                                url: '/DiperadmonPersonalMilitarRetiroBaja/Insertar',
                                data: {
                                    'DNIPMilitarRetBaja': $('#txtDNI').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalM').val(),
                                    'SexoPMilitarRetBaja': $('#txtSexo').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialdadG').val(),
                                    'CodigoMotivoBajaPersonal': $('#cbMotivoBajaP').val(),
                                    'FechaIngresoInsPMilitarRetBaja': $('#txtFechaI').val(),
                                    'FechaRetiroPMilitarRetBaja': $('#txtFechaR').val(),
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
                                    $('#tblDiperadmonPersonalMilitarRetiroBaja').DataTable().ajax.reload();
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
                                url: '/DiperadmonPersonalMilitarRetiroBaja/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIPMilitarRetBaja': $('#txtDNIe').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMe').val(),
                                    'SexoPMilitarRetBaja': $('#txtSexoe').val(),
                                    'CodigoEspecialidadGenericaPersonal': $('#cbEspecialdadGe').val(),
                                    'CodigoMotivoBajaPersonal': $('#cbMotivoBajaPe').val(),
                                    'FechaIngresoInsPMilitarRetBaja': $('#txtFechaIe').val(),
                                    'FechaRetiroPMilitarRetBaja': $('#txtFechaRe').val(),
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
                                    $('#tblDiperadmonPersonalMilitarRetiroBaja').DataTable().ajax.reload();
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

    tblDiperadmonPersonalMilitarRetiroBaja=$('#tblDiperadmonPersonalMilitarRetiroBaja').DataTable({
        ajax: {
            "url": '/DiperadmonPersonalMilitarRetiroBaja/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "personalMilitarRetiroBajaId" },
            { "data": "dnipMilitarRetBaja" },
            { "data": "descGrado" },
            { "data": "sexoPMilitarRetBaja" },
            { "data": "descEspecialidad" },
            { "data": "descMotivoBajaPersonal" },
            { "data": "fechaIngresoInsPMilitarRetBaja" },
            { "data": "fechaRetiroPMilitarRetBaja" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.personalMilitarRetiroBajaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.personalMilitarRetiroBajaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Diperadmon - Personal Militar Superior, Subalterno Y Marinería En Situación De Retiro o Baja',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Diperadmon - Personal Militar Superior, Subalterno Y Marinería En Situación De Retiro o Baja',
                title: 'Diperadmon - Personal Militar Superior, Subalterno Y Marinería En Situación De Retiro o Baja',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Diperadmon - Personal Militar Superior, Subalterno Y Marinería En Situación De Retiro o Baja',
                title: 'Diperadmon - Personal Militar Superior, Subalterno Y Marinería En Situación De Retiro o Baja',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Diperadmon - Personal Militar Superior, Subalterno Y Marinería En Situación De Retiro o Baja',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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
    tblDiperadmonPersonalMilitarRetiroBaja.columns(8).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDiperadmonPersonalMilitarRetiroBaja.columns(8).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DiperadmonPersonalMilitarRetiroBaja/Mostrar?Id=' + Id, [], function (PersonalMilitarRetiroBajaDTO) {
        $('#txtCodigo').val(PersonalMilitarRetiroBajaDTO.personalMilitarRetiroBajaId);
        $('#txtDNIe').val(PersonalMilitarRetiroBajaDTO.dnipMilitarRetBaja);
        $('#cbGradoPersonalMe').val(PersonalMilitarRetiroBajaDTO.codigoGradoPersonalMilitar);
        $('#txtSexoe').val(PersonalMilitarRetiroBajaDTO.sexoPMilitarRetBaja);
        $('#cbEspecialdadGe').val(PersonalMilitarRetiroBajaDTO.codigoEspecialidadGenericaPersonal);
        $('#cbMotivoBajaPe').val(PersonalMilitarRetiroBajaDTO.codigoMotivoBajaPersonal);
        $('#txtFechaIe').val(PersonalMilitarRetiroBajaDTO.fechaIngresoInsPMilitarRetBaja);
        $('#txtFechaRe').val(PersonalMilitarRetiroBajaDTO.fechaRetiroPMilitarRetBaja);
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
                url: '/DiperadmonPersonalMilitarRetiroBaja/Eliminar',
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
                    $('#tblDiperadmonPersonalMilitarRetiroBaja').DataTable().ajax.reload();
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
                url: '/DiperadmonPersonalMilitarRetiroBaja/EliminarCarga',
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
                    $('#tblDiperadmonPersonalMilitarRetiroBaja').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDiperadmonPersonalMilitarRetiroBaja() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DiperadmonPersonalMilitarRetiroBaja/MostrarDatos',
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
                            $("<td>").text(item.dnipMilitarRetBaja),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.sexoPMilitarRetBaja),
                            $("<td>").text(item.codigoEspecialidadGenericaPersonal),
                            $("<td>").text(item.codigoMotivoBajaPersonal),
                            $("<td>").text(item.fechaIngresoInsPMilitarRetBaja),
                            $("<td>").text(item.fechaRetiroPMilitarRetBaja),
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
    fetch("DiperadmonPersonalMilitarRetiroBaja/EnviarDatos", {
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
                    'Ocurrio un problema. ' + mensaje,
                    'error'
                )
            }
        })
}


function cargaDatos() {
    $.getJSON('/DiperadmonPersonalMilitarRetiroBaja/cargaCombs', [], function (Json) {
        var gradoPersonalMilitar = Json["data1"];
        var especialidadGenericaPersonal = Json["data2"];
        var motivoBajaPersonal = Json["data3"];
        var listaCargas = Json["data4"];

        $("select#cbGradoPersonalM").html("");
        $("select#cbGradoPersonalMe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.abreviatura + '</option>'
            $("select#cbGradoPersonalM").append(RowContent);
            $("select#cbGradoPersonalMe").append(RowContent);
        });

        $("select#cbEspecialdadG").html("");
        $("select#cbEspecialdadGe").html("");
        $.each(especialidadGenericaPersonal, function () {
            var RowContent = '<option value=' + this.codigoEspecialidadGenericaPersonal + '>' + this.descEspecialidad + '</option>'
            $("select#cbEspecialdadG").append(RowContent);
            $("select#cbEspecialdadGe").append(RowContent);
        });

        $("select#cbMotivoBajaP").html("");
        $("select#cbMotivoBajaPe").html("");
        $.each(motivoBajaPersonal, function () {
            var RowContent = '<option value=' + this.codigoMotivoBajaPersonal + '>' + this.descMotivoBajaPersonal + '</option>'
            $("select#cbMotivoBajaP").append(RowContent);
            $("select#cbMotivoBajaPe").append(RowContent);
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

    reporteSeleccionado = '/DiperadmonPersonalMilitarRetiroBaja/ReporteARTR';
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