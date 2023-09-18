var tblDihidronavActividadDepartamentoHidrografia;

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
                                url: '/DihidronavActividadDepartamentoHidrografia/Insertar',
                                data: {
                                    'NumeroOrden': $('#txtOrden').val(),
                                    'TrabajoEfectuado': $('#txtEfectuado').val(),
                                    'CodigoTrabajoHidrografico': $('#cbHidrografico').val(),
                                    'CodigoZonaNautica': $('#cbZona').val(),
                                    'DistritoUbigeo': $('#cbDistrito').val(),
                                    'CodigoProductoResultadoObtenido': $('#cbProducto').val(),
                                    'FechaInicio': $('#txtFechaIni').val(),
                                    'FechaTermino': $('#txtFechaTer').val(),
                                    'ResponsableActividad': $('#txtResponsable').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGrado').val(),
                                    'SituacionTrabajoEfectuado': $('#txtSituacion').val(),
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
                                    $('#tblDihidronavActividadDepartamentoHidrografia').DataTable().ajax.reload();
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
                                url: '/DihidronavActividadDepartamentoHidrografia/Actualizar',
                                data: {

                                    'ActividadDepartamentoHidrografiaId': $('#txtCodigo').val(),
                                    'NumeroOrden': $('#txtOrdene').val(),
                                    'TrabajoEfectuado': $('#txtEfectuadoe').val(),
                                    'CodigoTrabajoHidrografico': $('#cbHidrograficoe').val(),
                                    'CodigoZonaNautica': $('#cbZonae').val(),
                                    'DistritoUbigeo': $('#cbDistritoe').val(),
                                    'CodigoProductoResultadoObtenido': $('#cbProductoe').val(),
                                    'FechaInicio': $('#txtFechaInie').val(),
                                    'FechaTermino': $('#txtFechaTere').val(),
                                    'ResponsableActividad': $('#txtResponsablee').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoe').val(),
                                    'SituacionTrabajoEfectuado': $('#txtSituacione').val(), 
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
                                    $('#tblDihidronavActividadDepartamentoHidrografia').DataTable().ajax.reload();
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

  tblDihidronavActividadDepartamentoHidrografia =  $('#tblDihidronavActividadDepartamentoHidrografia').DataTable({
        ajax: {
            "url": '/DihidronavActividadDepartamentoHidrografia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "actividadDepartamentoHidrografiaId" },
            { "data": "numeroOrden" },
            { "data": "trabajoEfectuado" },
            { "data": "descTrabajoHidrografico" },
            { "data": "descZonaNautica" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },  
            { "data": "descDistrito" },
            { "data": "descProductoResultadoObtenido" }, 
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "responsableActividad" },
            { "data": "descGrado" },
            { "data": "situacionTrabajoEfectuado" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.actividadDepartamentoHidrografiaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.actividadDepartamentoHidrografiaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dihidronav - Actividades del Departamento de Hidrografía',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dihidronav - Actividades del Departamento de Hidrografía',
                title: 'Dihidronav - Actividades del Departamento de Hidrografía',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dihidronav - Actividades del Departamento de Hidrografía',
                title: 'Dihidronav - Actividades del Departamento de Hidrografía',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dihidronav - Actividades del Departamento de Hidrografía',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13]
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
    tblDihidronavActividadDepartamentoHidrografia.columns(14).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDihidronavActividadDepartamentoHidrografia.columns(14).search('').draw();
}


function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DihidronavActividadDepartamentoHidrografia/Mostrar?Id=' + Id, [], function (ActividadDepartamentoHidrografiaDTO) {
        $('#txtCodigo').val(ActividadDepartamentoHidrografiaDTO.actividadDepartamentoHidrografiaId);
        $('#txtOrdene').val(ActividadDepartamentoHidrografiaDTO.numeroOrden);
        $('#txtEfectuadoe').val(ActividadDepartamentoHidrografiaDTO.trabajoEfectuado);
        $('#cbHidrograficoe').val(ActividadDepartamentoHidrografiaDTO.codigoTrabajoHidrografico);
        $('#cbZonae').val(ActividadDepartamentoHidrografiaDTO.codigoZonaNautica);
        $('#cbDepartamentoe').val(ActividadDepartamentoHidrografiaDTO.departamentoUbigeoId);
        $('#cbProvinciae').val(ActividadDepartamentoHidrografiaDTO.provinciaUbigeoId);
        $('#cbDistritoe').val(ActividadDepartamentoHidrografiaDTO.distritoUbigeo);
        $('#cbProductoe').val(ActividadDepartamentoHidrografiaDTO.codigoProductoResultadoObtenido);
        $('#txtFechaInie').val(ActividadDepartamentoHidrografiaDTO.fechaInicio);
        $('#txtFechaTere').val(ActividadDepartamentoHidrografiaDTO.fechaTermino);
        $('#txtResponsablee').val(ActividadDepartamentoHidrografiaDTO.responsableActividad);
        $('#cbGradoe').val(ActividadDepartamentoHidrografiaDTO.codigoGradoPersonalMilitar);
        $('#txtSituacione').val(ActividadDepartamentoHidrografiaDTO.situacionTrabajoEfectuado); 
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
                url: '/DihidronavActividadDepartamentoHidrografia/Eliminar',
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
                    $('#tblDihidronavActividadDepartamentoHidrografia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDihidronavActividadDepartamentoHidrografia() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DihidronavActividadDepartamentoHidrografia/MostrarDatos',
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
                            $("<td>").text(item.numeroOrden),
                            $("<td>").text(item.trabajoEfectuado),
                            $("<td>").text(item.codigoTrabajoHidrografico),
                            $("<td>").text(item.codigoZonaNautica),
                            $("<td>").text(item.distritoUbigeo),
                            $("<td>").text(item.codigoProductoResultadoObtenido),
                            $("<td>").text(item.fechaInicio),
                            $("<td>").text(item.fechaTermino),
                            $("<td>").text(item.responsableActividad),
                            $("<td>").text(item.codigoGradoPersonalMilitar),
                            $("<td>").text(item.situacionTrabajoEfectuado)
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
    fetch("DihidronavActividadDepartamentoHidrografia/EnviarDatos", {
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
    $.getJSON('/DihidronavActividadDepartamentoHidrografia/cargaCombs', [], function (Json) {
        var trabajoHidrografico = Json["data1"];
        var zonaNautica = Json["data2"];
        var departamentoUbigeo = Json["data3"];
        var provinciaUbigeo = Json["data4"];
        var distritoUbigeo = Json["data5"];
        var productoResultadoObtenido = Json["data6"];
        var gradoPersonalMilitar = Json["data7"];
        var listaCargas = Json["data8"];


        $("select#cbGrado").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGrado").append(RowContent);
        });
        $("select#cbGradoe").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoe").append(RowContent);
        });

        $("select#cbHidrografico").html("");
        $.each(trabajoHidrografico, function () {
            var RowContent = '<option value=' + this.codigoTrabajoHidrografico + '>' + this.descTrabajoHidrografico + '</option>'
            $("select#cbHidrografico").append(RowContent);
        });
        $("select#cbHidrograficoe").html("");
        $.each(trabajoHidrografico, function () {
            var RowContent = '<option value=' + this.codigoTrabajoHidrografico + '>' + this.descTrabajoHidrografico + '</option>'
            $("select#cbHidrograficoe").append(RowContent);
        });

        $("select#cbZona").html("");
        $.each(zonaNautica, function () {
            var RowContent = '<option value=' + this.codigoZonaNautica + '>' + this.descZonaNautica + '</option>'
            $("select#cbZona").append(RowContent);
        });
        $("select#cbZonae").html("");
        $.each(zonaNautica, function () {
            var RowContent = '<option value=' + this.codigoZonaNautica + '>' + this.descZonaNautica + '</option>'
            $("select#cbZonae").append(RowContent);
        });

        $("select#cbDepartamento").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamento").append(RowContent);
        });
        $("select#cbDepartamentoe").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoe").append(RowContent);
        });

        $("select#cbProvincia").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvincia").append(RowContent);
        });
        $("select#cbProvinciae").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciae").append(RowContent);
        });

        $("select#cbDistrito").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistrito").append(RowContent);
        });
        $("select#cbDistritoe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoe").append(RowContent);
        });

        $("select#cbProducto").html("");
        $.each(productoResultadoObtenido, function () {
            var RowContent = '<option value=' + this.codigoProductoResultadoObtenido + '>' + this.descProductoResultadoObtenido + '</option>'
            $("select#cbProducto").append(RowContent);
        });
        $("select#cbProductoe").html("");
        $.each(productoResultadoObtenido, function () {
            var RowContent = '<option value=' + this.codigoProductoResultadoObtenido + '>' + this.descProductoResultadoObtenido + '</option>'
            $("select#cbProductoe").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    }) 
}

