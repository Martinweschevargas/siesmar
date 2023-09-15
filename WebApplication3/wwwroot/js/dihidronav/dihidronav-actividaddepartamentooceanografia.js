var tblDihidronavActividadDepartamentoOceanografia;

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
                                url: '/DihidronavActividadDepartamentoOceanografia/Insertar',
                                data: {
                                    'NumeroOrden': $('#txtOrden').val(),
                                    'CodigoTrabajoOceanografico': $('#cbOceanografico').val(),
                                    'DescripcionTrabajoEfectuado': $('#txtEfectuado').val(),
                                    'CodigoZonaNautica': $('#cbZona').val(),
                                    'DistritoUbigeo': $('#cbDistrito').val(),
                                    'FechaInicio': $('#txtFechaIni').val(),
                                    'FechaTermino': $('#txtFechaTer').val(),
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
                                    $('#tblDihidronavActividadDepartamentoOceanografia').DataTable().ajax.reload();
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
                                url: '/DihidronavActividadDepartamentoOceanografia/Actualizar',
                                data: {

                                    'ActividadDepartamentoOceanografiaId': $('#txtCodigo').val(),
                                    'NumeroOrden': $('#txtOrdene').val(),
                                    'CodigoTrabajoOceanografico': $('#cbOceanograficoe').val(),
                                    'DescripcionTrabajoEfectuado': $('#txtEfectuadoe').val(),
                                    'CodigoZonaNautica': $('#cbZonae').val(),
                                    'DistritoUbigeo': $('#cbDistritoe').val(),
                                    'FechaInicio': $('#txtFechaInie').val(),
                                    'FechaTermino': $('#txtFechaTere').val(),
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
                                    $('#tblDihidronavActividadDepartamentoOceanografia').DataTable().ajax.reload();
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

 tblDihidronavActividadDepartamentoOceanografia =   $('#tblDihidronavActividadDepartamentoOceanografia').DataTable({
        ajax: {
            "url": '/DihidronavActividadDepartamentoOceanografia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "actividadDepartamentoOceanografiaId" },
            { "data": "numeroOrden" },
            { "data": "descTrabajoOceanografico" },
            { "data": "descripcionTrabajoEfectuado" },
            { "data": "descZonaNautica" },
            { "data": "descDepartamento" },
            { "data": "descProvincia" },  
            { "data": "descDistrito" },
            { "data": "fechaInicio" },
            { "data": "fechaTermino" },
            { "data": "situacionTrabajoEfectuado" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.actividadDepartamentoOceanografiaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.actividadDepartamentoOceanografiaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dihidronav - Actividades del Departamento de Oceanografia',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dihidronav - Actividades del Departamento de Oceanografia',
                title: 'Dihidronav - Actividades del Departamento de Oceanografia',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dihidronav - Actividades del Departamento de Oceanografia',
                title: 'Dihidronav - Actividades del Departamento de Oceanografia',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dihidronav - Actividades del Departamento de Oceanografia',
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
    tblDihidronavActividadDepartamentoOceanografia.columns(11).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDihidronavActividadDepartamentoOceanografia.columns(11).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DihidronavActividadDepartamentoOceanografia/Mostrar?Id=' + Id, [], function (ActividadDepartamentoOceanografiaDTO) {
        $('#txtCodigo').val(ActividadDepartamentoOceanografiaDTO.actividadDepartamentoOceanografiaId);
        $('#txtOrdene').val(ActividadDepartamentoOceanografiaDTO.numeroOrden);
        $('#cbOceanograficoe').val(ActividadDepartamentoOceanografiaDTO.codigoTrabajoOceanografico);
        $('#txtEfectuadoe').val(ActividadDepartamentoOceanografiaDTO.descripcionTrabajoEfectuado);
        $('#cbZonae').val(ActividadDepartamentoOceanografiaDTO.codigoZonaNautica);
        $('#cbDepartamentoe').val(ActividadDepartamentoOceanografiaDTO.departamentoUbigeoId);
        $('#cbProvinciae').val(ActividadDepartamentoOceanografiaDTO.provinciaUbigeoId);
        $('#cbDistritoe').val(ActividadDepartamentoOceanografiaDTO.distritoUbigeo);
        $('#txtFechaInie').val(ActividadDepartamentoOceanografiaDTO.fechaInicio);
        $('#txtFechaTere').val(ActividadDepartamentoOceanografiaDTO.fechaTermino);
        $('#txtSituacione').val(ActividadDepartamentoOceanografiaDTO.situacionTrabajoEfectuado); 
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
                url: '/DihidronavActividadDepartamentoOceanografia/Eliminar',
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
                    $('#tblDihidronavActividadDepartamentoOceanografia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDihidronavActividadDepartamentoOceanografia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DihidronavActividadDepartamentoOceanografia/MostrarDatos',
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
                            $("<td>").text(item.codigoTrabajoOceanografico),
                            $("<td>").text(item.descripcionTrabajoEfectuado),
                            $("<td>").text(item.codigoZonaNautica),
                            $("<td>").text(item.distritoUbigeo),
                            $("<td>").text(item.fechaInicio),
                            $("<td>").text(item.fechaTermino),
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
    fetch("DihidronavActividadDepartamentoOceanografia/EnviarDatos", {
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
    $.getJSON('/DihidronavActividadDepartamentoOceanografia/cargaCombs', [], function (Json) {
        var trabajoOceanografico = Json["data1"];
        var zonaNautica = Json["data2"];
        var departamentoUbigeo = Json["data3"];
        var provinciaUbigeo = Json["data4"];
        var distritoUbigeo = Json["data5"];
        var listaCargas = Json["data6"];


        $("select#cbOceanografico").html("");
        $.each(trabajoOceanografico, function () {
            var RowContent = '<option value=' + this.codigoTrabajoOceanografico + '>' + this.descTrabajoOceanografico + '</option>'
            $("select#cbOceanografico").append(RowContent);
        });
        $("select#cbOceanograficoe").html("");
        $.each(trabajoOceanografico, function () {
            var RowContent = '<option value=' + this.codigoTrabajoOceanografico + '>' + this.descTrabajoOceanografico + '</option>'
            $("select#cbOceanograficoe").append(RowContent);
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

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    }) 
}

