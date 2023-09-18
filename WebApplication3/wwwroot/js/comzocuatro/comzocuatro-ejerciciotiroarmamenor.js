var tblComzocuatroEjercicioTiroArmaMenor;
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
                                url: '/ComzocuatroEjercicioTiroArmaMenor/Insertar',
                                data: {
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitar').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitar').val(),
                                    'FechaEjercicio': $('#txtFechaEjercicio').val(),
                                    'CodigoTipoArmamento': $('#cbTipoArmamento').val(),
                                    'CodigoPosicionTipoArma': $('#cbPosicionTipoArma').val(),
                                    'DistanciaMetros': $('#txtDistanciaMetros').val(),
                                    'CantidadTiro': $('#txtCantidadTiro').val(),
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
                                    $('#tblComzocuatroEjercicioTiroArmaMenor').DataTable().ajax.reload();
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
                                url: '/ComzocuatroEjercicioTiroArmaMenor/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoTipoPersonalMilitar': $('#cbTipoPersonalMilitare').val(),
                                    'CodigoGradoPersonalMilitar': $('#cbGradoPersonalMilitare').val(),
                                    'FechaEjercicio': $('#txtFechaEjercicioe').val(),
                                    'CodigoTipoArmamento': $('#cbTipoArmamentoe').val(),
                                    'CodigoPosicionTipoArma': $('#cbPosicionTipoArmae').val(),
                                    'DistanciaMetros': $('#txtDistanciaMetrose').val(),
                                    'CantidadTiro': $('#txtCantidadTiroe').val(),
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
                                    $('#tblComzocuatroEjercicioTiroArmaMenor').DataTable().ajax.reload();
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

    tblComzocuatroEjercicioTiroArmaMenor = $('#tblComzocuatroEjercicioTiroArmaMenor').DataTable({
        ajax: {
            "url": '/ComzocuatroEjercicioTiroArmaMenor/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "ejercicioTiroArmaMenorId" },
            { "data": "descTipoPersonalMilitar" },
            { "data": "descGradoPersonalMilitar" },
            { "data": "fechaEjercicio" },
            { "data": "descTipoArmamento" },
            { "data": "descPosicionTipoArma" },
            { "data": "distanciaMetros" },
            { "data": "cantidadTiro" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.ejercicioTiroArmaMenorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.ejercicioTiroArmaMenorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzocuatro - Ejercicios de Tiro con Armas Menores',
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
                filename: 'Comzocuatro - Ejercicios de Tiro con Armas Menores',
                title: 'Comzocuatro - Ejercicios de Tiro con Armas Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzocuatro - Ejercicios de Tiro con Armas Menores',
                title: 'Comzocuatro - Ejercicios de Tiro con Armas Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzocuatro - Ejercicios de Tiro con Armas Menores',
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

});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComzocuatroEjercicioTiroArmaMenor/Mostrar?Id=' + Id, [], function (EjercicioTiroArmaMenorComzocuatroDTO) {
        $('#txtCodigo').val(EjercicioTiroArmaMenorComzocuatroDTO.ejercicioTiroArmaMenorId);
        $('#cbTipoPersonalMilitare').val(EjercicioTiroArmaMenorComzocuatroDTO.codigoTipoPersonalMilitar);
        $('#cbGradoPersonalMilitare').val(EjercicioTiroArmaMenorComzocuatroDTO.codigoGradoPersonalMilitar);
        $('#txtFechaEjercicioe').val(EjercicioTiroArmaMenorComzocuatroDTO.fechaEjercicio);
        $('#cbTipoArmamentoe').val(EjercicioTiroArmaMenorComzocuatroDTO.codigoTipoArmamento);
        $('#cbPosicionTipoArmae').val(EjercicioTiroArmaMenorComzocuatroDTO.codigoPosicionTipoArma);
        $('#txtDistanciaMetrose').val(EjercicioTiroArmaMenorComzocuatroDTO.distanciaMetros);
        $('#txtCantidadTiroe').val(EjercicioTiroArmaMenorComzocuatroDTO.cantidadTiro);
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
                url: '/ComzocuatroEjercicioTiroArmaMenor/Eliminar',
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
                    $('#tblComzocuatroEjercicioTiroArmaMenor').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComzocuatroEjercicioTiroArmaMenor() {
    $('#listar').hide();
    $('#nuevo').show();
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("BienestarMovilidadEscolar/EnviarDatos", {
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
    $.getJSON('/ComzocuatroEjercicioTiroArmaMenor/cargaCombs', [], function (Json) {
        var tipoPersonalMilitar = Json["data1"];
        var gradoPersonalMilitar = Json["data2"];
        var tipoArmamento = Json["data3"];
        var posicionTipoArma = Json["data4"];
        var listaCargas = Json["data4"];

        $("select#cbTipoPersonalMilitar").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.CodigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitar").append(RowContent);
        });
        $("select#cbTipoPersonalMilitare").html("");
        $.each(tipoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.CodigoTipoPersonalMilitar + '>' + this.descTipoPersonalMilitar + '</option>'
            $("select#cbTipoPersonalMilitare").append(RowContent);
        });


        $("select#cbGradoPersonalMilitar").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.CodigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitar").append(RowContent);
        });
        $("select#cbGradoPersonalMilitare").html("");
        $.each(gradoPersonalMilitar, function () {
            var RowContent = '<option value=' + this.CodigoGradoPersonalMilitar + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonalMilitare").append(RowContent);
        });


        $("select#cbTipoArmamento").html("");
        $.each(tipoArmamento, function () {
            var RowContent = '<option value=' + this.CodigoTipoArmamento + '>' + this.descTipoArmamento + '</option>'
            $("select#cbTipoArmamento").append(RowContent);
        });
        $("select#cbTipoArmamentoe").html("");
        $.each(tipoArmamento, function () {
            var RowContent = '<option value=' + this.CodigoTipoArmamento + '>' + this.descTipoArmamento + '</option>'
            $("select#cbTipoArmamentoe").append(RowContent);
        });


        $("select#cbPosicionTipoArma").html("");
        $.each(posicionTipoArma, function () {
            var RowContent = '<option value=' + this.CodigoPosicionTipoArma + '>' + this.descPosicionTipoArma + '</option>'
            $("select#cbPosicionTipoArma").append(RowContent);
        });
        $("select#cbPosicionTipoArmae").html("");
        $.each(posicionTipoArma, function () {
            var RowContent = '<option value=' + this.CodigoPosicionTipoArma + '>' + this.descPosicionTipoArma + '</option>'
            $("select#cbPosicionTipoArmae").append(RowContent);
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

function optReporte(id) {
    optReporteSelect = id;
    if (id == 1) {
        reporteSeleccionado = '/BienestarMovilidadEscolar/ReporteME?idCarga=';
        $('#fecha').hide();
    }
    /*if (id == 2) { 
        reporteSeleccionado = '/BienestarMovilidadEscolar/ReporteME?idCarga=';
        $('#fecha').show();
    }*/
}

$('#btnReportView').click(function () {
    var idCarga = $('select#cargas').val();

    var a = document.createElement('a');

    a.target = "_blank";
    if (optReporteSelect = 1) {
        a.href = reporteSeleccionado + idCarga;
    } else {
        // a.href = reporteSeleccionado + idCarga;
    }
    a.click();
});
