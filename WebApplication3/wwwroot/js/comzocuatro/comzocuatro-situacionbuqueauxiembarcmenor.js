var tblComzocuatroSituacionBuqueAuxiEmbarcMenor;
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
                                url: '/ComzocuatroSituacionBuqueAuxiEmbarcMenor/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#txtCodigoUnidadNaval').val(),
                                    'CodigoTipoNave': $('#txtCodigoTipoNave').val(),
                                    'CodigoTipoPlataformaNave': $('#cbPlataforma').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'DistritoUbigeo': $('#cbDistrito').val(),
                                    'CodigoCapacidadOperativaRequerida': $('#cbCapacidadOperativaRequerida').val(),
                                    'CodigoCondicion': $('#cbCondicion').val(),
                                    'Observacion': $('#txtObservacion').val(),
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
                                    $('#tblComzocuatroSituacionBuqueAuxiEmbarcMenor').DataTable().ajax.reload();
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
                                url: '/ComzocuatroSituacionBuqueAuxiEmbarcMenor/Actualizar',
                                data: {

                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#txtCodigoUnidadNaval').val(),
                                    'CodigoTipoNave': $('#txtCodigoTipoNave').val(),
                                    'CodigoTipoPlataformaNave': $('#cbPlataformae').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'DistritoUbigeo': $('#cbDistritoe').val(),
                                    'CodigoCapacidadOperativaRequerida': $('#cbCapacidadOperativaRequeridae').val(),
                                    'CodigoCondicion': $('#cbCondicione').val(),
                                    'Observacion': $('#txtObservacione').val(), 
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
                                    $('#tblComzocuatroSituacionBuqueAuxiEmbarcMenor').DataTable().ajax.reload();
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

    tblComzocuatroSituacionBuqueAuxiEmbarcMenor = $('#tblComzocuatroSituacionBuqueAuxiEmbarcMenor').DataTable({
        ajax: {
            "url": '/ComzocuatroSituacionBuqueAuxiEmbarcMenor/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "situacionBuqueAuxiliarEmbarcacionMenorId" },
            { "data": "CodigoUnidadNaval" },
            { "data": "CodigoTipoNave" },
            { "data": "descTipoPlataformaNave" },
            { "data": "descDependencia" },
            { "data": "ubicacion" },
            { "data": "descDistrito" },
            { "data": "capacidadOperativaNave" },
            { "data": "condicionNave" },
            { "data": "observacion" },
            { "data": "cargaId" }

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.situacionBuqueAuxiliarEmbarcacionMenorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.situacionBuqueAuxiliarEmbarcacionMenorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzocuatro - Situación de Buques Auxiliares y Embarcaciones Menores',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comzocuatro - Situación de Buques Auxiliares y Embarcaciones Menores',
                title: 'Comzocuatro - Situación de Buques Auxiliares y Embarcaciones Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzocuatro - Situación de Buques Auxiliares y Embarcaciones Menores',
                title: 'Comzocuatro - Situación de Buques Auxiliares y Embarcaciones Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzocuatro - Situación de Buques Auxiliares y Embarcaciones Menores',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
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

    $.getJSON('/ComzocuatroSituacionBuqueAuxiEmbarcMenor/Mostrar?Id=' + Id, [], function (SituacionBuqueAuxiEmbarcMenorComzocuatroDTO) {
        $('#txtCodigo').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.situacionBuqueAuxiliarEmbarcacionMenorId);
        $('#txtCodigoUnidadNaval').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.codigoUnidadNaval);
        $('#txtCodigoTipoNavee').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.codigoTipoNave);
        $('#cbPlataformae').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.codigoTipoPlataformaNave);
        $('#cbDependenciae').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.codigoDependencia);
        $('#txtUbicacione').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.ubicacion);
        var iddistrito = SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.distritoUbigeo;
       /* $('#cbDistritoe').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.distritoUbigeo);*/
        $('#cbCapacidadOperativaRequeridae').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.capacidadOperativaNave);
        $('#cbCondicione').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.condicionNave);
        $('#txtObservacione').val(SituacionBuqueAuxiEmbarcMenorComzocuatroDTO.observacion); 
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
                url: '/ComzocuatroSituacionBuqueAuxiEmbarcMenor/Eliminar',
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
                    $('#tblComzocuatroSituacionBuqueAuxiEmbarcMenor').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComzocuatroSituacionBuqueAuxiEmbarcMenor() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            console.log(dataJson);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.nombreTemaEstudioInvestigacion),
                        $("<td>").text(item.tipoEstudioInvestigacion),
                        $("<td>").text(item.fechaInicio),
                        $("<td>").text(item.fechaTermino),
                        $("<td>").text(item.responsable),
                        $("<td>").text(item.solicitante)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("Formato/EnviarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            alert(dataJson.mensaje);
        })
}


function cargaDatos() {
    $.getJSON('/ComzocuatroSituacionBuqueAuxiEmbarcMenor/cargaCombs', [], function (Json) {
        var tipoPlataformaNave = Json["data1"];
        var dependencia = Json["data2"];
        var distritoUbigeo = Json["data3"];
        var CapacidadOperativaRequerida = Json["data4"];
        var Condicion = Json["data5"];
        var listaCargas = Json["data6"];


        $("select#cbPlataforma").html("");
        $.each(tipoPlataformaNave, function () {
            var RowContent = '<option value=' + this.codigoTipoPlataformaNave + '>' + this.descTipoPlataformaNave + '</option>'
            $("select#cbPlataforma").append(RowContent);
        });
        $("select#cbPlataformae").html("");
        $.each(tipoPlataformaNave, function () {
            var RowContent = '<option value=' + this.codigoTipoPlataformaNave + '>' + this.descTipoPlataformaNave + '</option>'
            $("select#cbPlataformae").append(RowContent);
        });

        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbDistrito").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.DistritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistrito").append(RowContent);
        });
        $("select#cbDistritoe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.DistritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoe").append(RowContent);
        });


        $("select#cbCapacidadOperativaRequerida").html("");
        $.each(CapacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativaRequerida + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequerida").append(RowContent);
        });
        $("select#cbCapacidadOperativaRequeridae").html("");
        $.each(CapacidadOperativaRequerida, function () {
            var RowContent = '<option value=' + this.codigoCapacidadOperativaRequerida + '>' + this.descCapacidadOperativaRequerida + '</option>'
            $("select#cbCapacidadOperativaRequeridae").append(RowContent);
        });


        $("select#cbCondicion").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.codigoCondicion + '>' + this.descCondicion + '</option>'
            $("select#cbCondicion").append(RowContent);
        });
        $("select#cbCondicione").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.codigoCondicion + '>' + this.descCondicion + '</option>'
            $("select#cbCondicione").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
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