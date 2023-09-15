var tblDihidronavServicioConstruccionInstalacion;

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
                                url: '/DihidronavServicioConstruccionInstalacion/Insertar',
                                data: {
                                    'NumeroOrden': $('#txtOrden').val(),
                                    'CodigoTrabajoSenializacionNautica': $('#cbServicio').val(),
                                    'DescripcionServicio': $('#txtDescripcion').val(),
                                    'FechaInicio': $('#txtFechaIni').val(),
                                    'FechaTermino': $('#txtFechaTer').val(),
                                    'CodigoZonaNautica': $('#cbZona').val(),
                                    'EstadoServicio': $('#txtEstado').val(), 
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
                                    $('#tblDihidronavServicioConstruccionInstalacion').DataTable().ajax.reload();
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
                                url: '/DihidronavServicioConstruccionInstalacion/Actualizar',
                                data: {
                                    'ServicioConstruccionInstalacionId': $('#txtCodigo').val(),
                                    'NumeroOrden': $('#txtOrdene').val(),
                                    'CodigoTrabajoSenializacionNautica': $('#cbServicioe').val(),
                                    'DescripcionServicio': $('#txtDescripcione').val(),
                                    'FechaInicio': $('#txtFechaInie').val(),
                                    'FechaTermino': $('#txtFechaTere').val(),
                                    'CodigoZonaNautica': $('#cbZonae').val(),
                                    'EstadoServicio': $('#txtEstadoe').val(), 
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
                                    $('#tblDihidronavServicioConstruccionInstalacion').DataTable().ajax.reload();
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

  tblDihidronavServicioConstruccionInstalacion =  $('#tblDihidronavServicioConstruccionInstalacion').DataTable({
        ajax: {
            "url": '/DihidronavServicioConstruccionInstalacion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioConstruccionInstalacionId" },
            { "data": "numeroOrden" },
            { "data": "descTrabajoSenializacionNautica" },
            { "data": "descripcionServicio" },
            { "data": "fechaInicioServicio" },
            { "data": "fechaTerminoServicio" },
            { "data": "descZonaNautica" },  
            { "data": "estadoServicio" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioConstruccionInstalacionId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioConstruccionInstalacionId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dihidronav - Servicios de Construcción, Instalación, mantenimiento de señales náuticas',
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
                filename: 'Dihidronav - Servicios de Construcción, Instalación, mantenimiento de señales náuticas',
                title: 'Dihidronav - Servicios de Construcción, Instalación, mantenimiento de señales náuticas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dihidronav - Servicios de Construcción, Instalación, mantenimiento de señales náuticas',
                title: 'Dihidronav - Servicios de Construcción, Instalación, mantenimiento de señales náuticas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dihidronav - Servicios de Construcción, Instalación, mantenimiento de señales náuticas',
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
    tblDihidronavServicioConstruccionInstalacion.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDihidronavServicioConstruccionInstalacion.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DihidronavServicioConstruccionInstalacion/Mostrar?Id=' + Id, [], function (ServicioConstruccionInstalacionDTO) {
        $('#txtCodigo').val(ServicioConstruccionInstalacionDTO.servicioConstruccionInstalacionId);
        $('#txtOrdene').val(ServicioConstruccionInstalacionDTO.numeroOrden);
        $('#cbServicioe').val(ServicioConstruccionInstalacionDTO.codigoTrabajoSenializacionNautica);
        $('#txtDescripcione').val(ServicioConstruccionInstalacionDTO.descripcionServicio);
        $('#txtFechaInie').val(ServicioConstruccionInstalacionDTO.fechaInicio);
        $('#txtFechaTere').val(ServicioConstruccionInstalacionDTO.fechaTermino);
        $('#cbZonae').val(ServicioConstruccionInstalacionDTO.codigoZonaNautica);
        $('#txtEstadoe').val(ServicioConstruccionInstalacionDTO.estadoServicio); 
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
                url: '/DihidronavServicioConstruccionInstalacion/Eliminar',
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
                    $('#tblDihidronavServicioConstruccionInstalacion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDihidronavServicioConstruccionInstalacion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DihidronavServicioConstruccionInstalacion/MostrarDatos',
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
                            $("<td>").text(item.codigoTrabajoSenializacionNautica),
                            $("<td>").text(item.descripcionServicio),
                            $("<td>").text(item.fechaInicio),
                            $("<td>").text(item.fechaTermino),
                            $("<td>").text(item.codigoZonaNautica),
                            $("<td>").text(item.estadoServicio)
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
    fetch("DihidronavServicioConstruccionInstalacion/EnviarDatos", {
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
    $.getJSON('/DihidronavServicioConstruccionInstalacion/cargaCombs', [], function (Json) {
        var trabajoSenializacionNautica = Json["data1"];
        var zonaNautica = Json["data2"];
        var listaCargas = Json["data3"];

        $("select#cbServicio").html("");
        $.each(trabajoSenializacionNautica, function () {
            var RowContent = '<option value=' + this.codigoTrabajoSenializacionNautica + '>' + this.descTrabajoSenializacionNautica + '</option>'
            $("select#cbServicio").append(RowContent);
        });
        $("select#cbServicioe").html("");
        $.each(trabajoSenializacionNautica, function () {
            var RowContent = '<option value=' + this.codigoTrabajoSenializacionNautica + '>' + this.descTrabajoSenializacionNautica + '</option>'
            $("select#cbServicioe").append(RowContent);
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


        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });


    }) 
}

