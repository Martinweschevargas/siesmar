var tblComoperamaApoyoTransporteMantenimiento;

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
                                url: '/ComoperamaApoyoTransporteMantenimiento/Insertar',
                                data: {
                                    'CodigoZonaNaval': $('#cbZonaNaval').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeo').val(),
                                    'CodigoTipoActividadDenominacion': $('#cbTipoActividadDenominacion').val(),
                                    'FechaInicio': $('#txtFechaInicio').val(),
                                    'FechaTermino': $('#txtFechaTermino').val(),
                                    'NumeroBeneficiados': $('#txtNumeroBeneficiados').val(),
                                    'Valor': $('#txtValor').val(),
                                    'CodigoTipoAccionCivica': $('#cbTipoAccionCivica').val(), 
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
                                    $('#tblComoperamaApoyoTransporteMantenimiento').DataTable().ajax.reload();
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
                                url: '/ComoperamaApoyoTransporteMantenimiento/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoZonaNaval': $('#cbZonaNavale').val(),
                                    'DistritoUbigeo': $('#cbDistritoUbigeoe').val(),
                                    'CodigoTipoActividadDenominacion': $('#cbTipoActividadDenominacione').val(),
                                    'FechaInicio': $('#txtFechaInicioe').val(),
                                    'FechaTermino': $('#txtFechaTerminoe').val(),
                                    'NumeroBeneficiados': $('#txtNumeroBeneficiadose').val(),
                                    'Valor': $('#txtValore').val(),
                                    'CodigoTipoAccionCivica': $('#cbTipoAccionCivicae').val(), 
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
                                    $('#tblComoperamaApoyoTransporteMantenimiento').DataTable().ajax.reload();
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

 tblComoperamaApoyoTransporteMantenimiento =   $('#tblComoperamaApoyoTransporteMantenimiento').DataTable({
        ajax: {
            "url": '/ComoperamaApoyoTransporteMantenimiento/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "apoyoTransporteMantenimientoId" },
            { "data": "descZonaNaval" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },
            { "data": "descDistrito" },
            { "data": "descTipoActividadDenominacion" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "numeroBeneficiados" },
            { "data": "valor" },
            { "data": "descTipoAccionCivica" }, 
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.apoyoTransporteMantenimientoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.apoyoTransporteMantenimientoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperama - Archivo para Apoyo de Transporte y Mantenimiento por Tipo de Actividad de las Instituciones Armadas',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8,9,10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperama - Archivo para Apoyo de Transporte y Mantenimiento por Tipo de Actividad de las Instituciones Armadas',
                title: 'Comoperama - Archivo para Apoyo de Transporte y Mantenimiento por Tipo de Actividad de las Instituciones Armadas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperama - Archivo para Apoyo de Transporte y Mantenimiento por Tipo de Actividad de las Instituciones Armadas',
                title: 'Comoperama - Archivo para Apoyo de Transporte y Mantenimiento por Tipo de Actividad de las Instituciones Armadas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperama - Archivo para Apoyo de Transporte y Mantenimiento por Tipo de Actividad de las Instituciones Armadas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
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
    tblComoperamaApoyoTransporteMantenimiento.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComoperamaApoyoTransporteMantenimiento.columns(11).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComoperamaApoyoTransporteMantenimiento/Mostrar?Id=' + Id, [], function (ApoyoSocialIntitucionArmadaDTO) {
        $('#txtCodigo').val(ApoyoSocialIntitucionArmadaDTO.apoyoTransporteMantenimientoId);
        $('#cbZonaNavale').val(ApoyoSocialIntitucionArmadaDTO.codigoZonaNaval);
        $('#cbDistritoUbigeoe').val(ApoyoSocialIntitucionArmadaDTO.distritoUbigeo);
        $('#cbTipoActividadDenominacione').val(ApoyoSocialIntitucionArmadaDTO.codigoTipoActividadDenominacion);
        $('#txtFechaInicioe').val(ApoyoSocialIntitucionArmadaDTO.fechaInicio);
        $('#txtFechaTerminoe').val(ApoyoSocialIntitucionArmadaDTO.fechaTermino);
        $('#txtNumeroBeneficiadose').val(ApoyoSocialIntitucionArmadaDTO.numeroBeneficiados);
        $('#txtValore').val(ApoyoSocialIntitucionArmadaDTO.valor);
        $('#cbTipoAccionCivicae').val(ApoyoSocialIntitucionArmadaDTO.codigoTipoAccionCivica); 
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
                url: '/ComoperamaApoyoTransporteMantenimiento/Eliminar',
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
                    $('#tblComoperamaApoyoTransporteMantenimiento').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperamaApoyoTransporteMantenimiento() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComoperamaApoyoTransporteMantenimiento/MostrarDatos',
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
                            $("<td>").text(item.codigoZonaNaval),
                            $("<td>").text(item.distritoUbigeo),
                            $("<td>").text(item.codigoTipoActividadDenominacion),
                            $("<td>").text(item.fechaInicio),
                            $("<td>").text(item.fechaTermino),
                            $("<td>").text(item.numeroBeneficiados),
                            $("<td>").text(item.valor),
                            $("<td>").text(item.codigoTipoAccionCivica)
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
    fetch("ComoperamaApoyoTransporteMantenimiento/EnviarDatos", {
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
    $.getJSON('/ComoperamaApoyoTransporteMantenimiento/cargaCombs', [], function (Json) {
        var ZonaNaval = Json["data1"];
        var DepartamentoUbigeo = Json["data2"];
        var ProvinciaUbigeo = Json["data3"];
        var DistritoUbigeo = Json["data4"];
        var TipoActividadDenominacion = Json["data5"];
        var TipoAccionCivica = Json["data6"];
        var listaCargas = Json["data7"];

        $("select#cbZonaNaval").html("");
        $.each(ZonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNaval").append(RowContent);
        });
        $("select#cbZonaNavale").html("");
        $.each(ZonaNaval, function () {
            var RowContent = '<option value=' + this.codigoZonaNaval + '>' + this.descZonaNaval + '</option>'
            $("select#cbZonaNavale").append(RowContent);
        });


        $("select#cbDepartamentoUbigeo").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamentoUbigeo + '</option>'
            $("select#cbDepartamentoUbigeo").append(RowContent);
        });
        $("select#cbDepartamentoUbigeoe").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeo + '>' + this.descDepartamentoUbigeo + '</option>'
            $("select#cbDepartamentoUbigeoe").append(RowContent);
        });


        $("select#cbProvinciaUbigeo").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvinciaUbigeo + '</option>'
            $("select#cbProvinciaUbigeo").append(RowContent);
        });
        $("select#cbProvinciaUbigeoe").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeo + '>' + this.descProvinciaUbigeo + '</option>'
            $("select#cbProvinciaUbigeoe").append(RowContent);
        });


        $("select#cbDistritoUbigeo").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistritoUbigeo + '</option>'
            $("select#cbDistritoUbigeo").append(RowContent);
        });
        $("select#cbDistritoUbigeoe").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistritoUbigeo + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });


        $("select#cbTipoActividadDenominacion").html("");
        $.each(TipoActividadDenominacion, function () {
            var RowContent = '<option value=' + this.codigoTipoActividadDenominacion + '>' + this.descTipoActividadDenominacion + '</option>'
            $("select#cbTipoActividadDenominacion").append(RowContent);
        });
        $("select#cbTipoActividadDenominacione").html("");
        $.each(TipoActividadDenominacion, function () {
            var RowContent = '<option value=' + this.codigoTipoActividadDenominacion + '>' + this.descTipoActividadDenominacion + '</option>'
            $("select#cbTipoActividadDenominacione").append(RowContent);
        });


        $("select#cbTipoAccionCivica").html("");
        $.each(TipoAccionCivica, function () {
            var RowContent = '<option value=' + this.codigoTipoAccionCivica + '>' + this.descTipoAccionCivica + '</option>'
            $("select#cbTipoAccionCivica").append(RowContent);
        });
        $("select#cbTipoAccionCivicae").html("");
        $.each(TipoAccionCivica, function () {
            var RowContent = '<option value=' + this.codigoTipoAccionCivica + '>' + this.descTipoAccionCivica + '</option>'
            $("select#cbTipoAccionCivicae").append(RowContent);
        }); 

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });

    });
}

