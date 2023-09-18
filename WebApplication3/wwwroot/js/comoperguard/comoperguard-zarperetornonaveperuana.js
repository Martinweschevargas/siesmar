var tbltblComoperguardZarpeRetornoNavePeruana;

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
                                url: '/tblComoperguardZarpeRetornoNavePeruana/Insertar',
                                data: {
                                    'Numero': $('#txtNumero').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'HoraCaptura': $('#txtHoraCaptura').val(),
                                    'DiaCaptura': $('#txtDiaCaptura').val(),
                                    'MesId': $('#cbMes').val(),
                                    'AnioCaptura': $('#txtAnioCaptura').val(),
                                    'NombreNavePeruana': $('#txtNombreNave').val(),
                                    'MatriculaNavePeruana': $('#txtMatriculaNave').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'AutoridadEmiteZarpeId': $('#cbAutoridadEmiteZarpe').val(),
                                    'HoraArribo': $('#txtHoraArribo').val(),
                                    'DiaArribo': $('#txtDiaArribo').val(),
                                    'MesArribo': $('#cbMesArribo').val(),
                                    'AnioArribo': $('#txtAnioArribo').val(),
                                    'PuertoPeruId': $('#cbPuertoPeru').val(),
                                    'JefaturaCapitaniaId': $('#cbJefaturaCapitania').val(),
                                    'Observaciones': $('#txtObservaciones').val(), 
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
                                    $('#tbltblComoperguardZarpeRetornoNavePeruana').DataTable().ajax.reload();
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
                                url: '/tblComoperguardZarpeRetornoNavePeruana/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'Numero': $('#txtNumeroe').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'HoraCaptura': $('#txtHoraCapturae').val(),
                                    'DiaCaptura': $('#txtDiaCapturae').val(),
                                    'MesId': $('#cbMese').val(),
                                    'AnioCaptura': $('#txtAnioCapturae').val(),
                                    'NombreNavePeruana': $('#txtNombreNavee').val(),
                                    'MatriculaNavePeruana': $('#txtMatriculaNavee').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'AutoridadEmiteZarpeId': $('#cbAutoridadEmiteZarpee').val(),
                                    'HoraArribo': $('#txtHoraArriboe').val(),
                                    'DiaArribo': $('#txtDiaArriboe').val(),
                                    'MesArribo': $('#cbMesArriboe').val(),
                                    'AnioArribo': $('#txtAnioArriboe').val(),
                                    'PuertoPeruId': $('#cbPuertoPerue').val(),
                                    'JefaturaCapitaniaId': $('#cbJefaturaCapitaniae').val(),
                                    'Observaciones': $('#txtObservacionese').val(), 
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
                                    $('#tbltblComoperguardZarpeRetornoNavePeruana').DataTable().ajax.reload();
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

    $('#tbltblComoperguardZarpeRetornoNavePeruana').DataTable({
        ajax: {
            "url": '/tblComoperguardZarpeRetornoNavePeruana/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "zarpeRetornoNavePeruanaId" },
            { "data": "numero" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "horaCaptura" },
            { "data": "diaCaptura" },
            { "data": "descMes" },
            { "data": "anioCaptura" },
            { "data": "nombreNavePeruana" },
            { "data": "matriculaNavePeruana" },
            { "data": "descTipoNave" },
            { "data": "descAutoridadEmiteZarpe" },
            { "data": "horaArribo" },
            { "data": "diaArribo" },
            { "data": "descMesArribo" },
            { "data": "anioArribo" },
            { "data": "descPuertoPeru" },
            { "data": "descJefaturaCapitania" },
            { "data": "observaciones" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.zarpeRetornoNavePeruanaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.zarpeRetornoNavePeruanaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Zarpe de Retorno de Naves Peruanas Capturadas en Aguas Internacionales',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Zarpe de Retorno de Naves Peruanas Capturadas en Aguas Internacionales',
                title: 'Comoperguard - Zarpe de Retorno de Naves Peruanas Capturadas en Aguas Internacionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Zarpe de Retorno de Naves Peruanas Capturadas en Aguas Internacionales',
                title: 'Comoperguard - Zarpe de Retorno de Naves Peruanas Capturadas en Aguas Internacionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Zarpe de Retorno de Naves Peruanas Capturadas en Aguas Internacionales',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
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
    $.getJSON('/tblComoperguardZarpeRetornoNavePeruana/Mostrar?Id=' + Id, [], function (ZarpeRetornoNavePeruanaDTO) {
        $('#txtCodigo').val(ZarpeRetornoNavePeruanaDTO.mineriaIlegalId);
        $('#txtNumeroe').val(ZarpeRetornoNavePeruanaDTO.numero);
        $('#cbJefaturaDistritoCapitaniae').val(ZarpeRetornoNavePeruanaDTO.jefaturaDistritoCapitaniaId);
        $('#txtHoraCapturae').val(ZarpeRetornoNavePeruanaDTO.horaCaptura);
        $('#txtDiaCapturae').val(ZarpeRetornoNavePeruanaDTO.diaCaptura);
        $('#cbMese').val(ZarpeRetornoNavePeruanaDTO.mesId);
        $('#txtAnioCapturae').val(ZarpeRetornoNavePeruanaDTO.anioCaptura);
        $('#txtNombreNavee').val(ZarpeRetornoNavePeruanaDTO.nombreNavePeruana);
        $('#txtMatriculaNavee').val(ZarpeRetornoNavePeruanaDTO.matriculaNavePeruana);
        $('#cbTipoNavee').val(ZarpeRetornoNavePeruanaDTO.tipoNaveId);
        $('#cbAutoridadEmiteZarpee').val(ZarpeRetornoNavePeruanaDTO.autoridadEmiteZarpeId);
        $('#txtHoraArriboe').val(ZarpeRetornoNavePeruanaDTO.horaArribo);
        $('#txtDiaArriboe').val(ZarpeRetornoNavePeruanaDTO.diaArribo);
        $('#cbMesArriboe').val(ZarpeRetornoNavePeruanaDTO.mesArribo);
        $('#txtAnioArriboe').val(ZarpeRetornoNavePeruanaDTO.anioArribo);
        $('#cbPuertoPerue').val(ZarpeRetornoNavePeruanaDTO.puertoPeruId);
        $('#cbJefaturaCapitaniae').val(ZarpeRetornoNavePeruanaDTO.jefaturaCapitaniaId);
        $('#txtObservacionese').val(ZarpeRetornoNavePeruanaDTO.observaciones); 
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
                url: '/tblComoperguardZarpeRetornoNavePeruana/Eliminar',
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
                    $('#tbltblComoperguardZarpeRetornoNavePeruana').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevatblComoperguardZarpeRetornoNavePeruana() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/tblComoperguardZarpeRetornoNavePeruana/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var mes = Json["data2"];
        var tipoNave = Json["data3"];
        var autoridadEmiteZarpe = Json["data4"];
        var puertoPeru = Json["data5"];

        $("select#cbJefaturaDistritoCapitania").html("");
        $.each(jefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.jefaturaDistritoCapitaniaId + '>' + this.descJefaturaDistritoCapitania + '</option>'
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });
        $("select#cbJefaturaDistritoCapitaniae").html("");
        $.each(jefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.jefaturaDistritoCapitaniaId + '>' + this.descJefaturaDistritoCapitania + '</option>'
            $("select#cbJefaturaDistritoCapitaniae").append(RowContent);
        });


        $("select#cbMes").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
        });
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
        });

        $("select#cbTipoNave").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbTipoNavee").append(RowContent);
        });
        $("select#cbTipoNavee").html("");
        $.each(tipoNave, function () {
            var RowContent = '<option value=' + this.tipoNaveId + '>' + this.descTipoNave + '</option>'
            $("select#cbTipoNavee").append(RowContent);
        });


        $("select#cbAutoridadEmiteZarpe").html("");
        $.each(autoridadEmiteZarpe, function () {
            var RowContent = '<option value=' + this.autoridadEmiteZarpeId + '>' + this.descAutoridadEmiteZarpe + '</option>'
            $("select#cbAutoridadEmiteZarpee").append(RowContent);
        });
        $("select#cbAutoridadEmiteZarpee").html("");
        $.each(autoridadEmiteZarpe, function () {
            var RowContent = '<option value=' + this.autoridadEmiteZarpeId + '>' + this.descAutoridadEmiteZarpe + '</option>'
            $("select#cbAutoridadEmiteZarpee").append(RowContent);
        });


        $("select#cbMesArribo").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMesArriboe").append(RowContent);
        });
        $("select#cbMesArriboe").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.mesId + '>' + this.descMes + '</option>'
            $("select#cbMesArriboe").append(RowContent);
        });


        $("select#cbPuertoPeru").html("");
        $.each(puertoPeru, function () {
            var RowContent = '<option value=' + this.puertoPeruId + '>' + this.descPuertoPeru + '</option>'
            $("select#cbPuertoPerue").append(RowContent);
        });
        $("select#cbPuertoPerue").html("");
        $.each(puertoPeru, function () {
            var RowContent = '<option value=' + this.puertoPeruId + '>' + this.descPuertoPeru + '</option>'
            $("select#cbPuertoPerue").append(RowContent);
        });


        $("select#cbJefaturaCapitania").html("");
        $.each(jefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.jefaturaDistritoCapitaniaId + '>' + this.descJefaturaDistritoCapitania + '</option>'
            $("select#cbJefaturaCapitaniae").append(RowContent);
        });
        $("select#cbJefaturaCapitaniae").html("");
        $.each(jefaturaDistritoCapitania, function () {
            var RowContent = '<option value=' + this.jefaturaDistritoCapitaniaId + '>' + this.descJefaturaDistritoCapitania + '</option>'
            $("select#cbJefaturaCapitaniae").append(RowContent);
        }); 
    });
}

