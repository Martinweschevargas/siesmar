var tblComoperguardAvisoInfraccionImpuesto;

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
                                url: '/ComoperguardAvisoInfraccionImpuesto/Insertar',
                                data: {
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitania').val(),
                                    'CapitaniaId': $('#cbCapitania').val(),
                                    'HoraInfraccion': $('#txtHoraInfraccion').val(),
                                    'FechaInfraccion': $('#txtFechaInfraccion').val(),
                                    'NombreNoveInfractora': $('#txtNombreNoveInfractora').val(),
                                    'MatriculaNaveInfractora': $('#txtMatriculaNaveInfractora').val(),
                                    'TipoNaveId': $('#cbTipoNave').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeo').val(),
                                    'PropietarioNave': $('#txtPropietarioNave').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacion').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacion').val(),
                                    'AreaIntervencion': $('#txtAreaIntervencion').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNave').val(),
                                    'SectorExtrainstitucional': $('#txtSectorExtrainstitucional').val(),
                                    'Tenor': $('#txtTenor').val(),
                                    'Articulo': $('#txtArticulo').val(),
                                    'AvisosInfraccion': $('#txtAvisosInfraccion').val(),
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
                                    $('#tblComoperguardAvisoInfraccionImpuesto').DataTable().ajax.reload();
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
                                url: '/ComoperguardAvisoInfraccionImpuesto/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'JefaturaDistritoCapitaniaId': $('#cbJefaturaDistritoCapitaniae').val(),
                                    'CapitaniaId': $('#cbCapitaniae').val(),
                                    'HoraInfraccion': $('#txtHoraInfraccione').val(),
                                    'FechaInfraccion': $('#txtFechaInfraccione').val(),
                                    'NombreNoveInfractora': $('#txtNombreNoveInfractorae').val(),
                                    'MatriculaNaveInfractora': $('#txtMatriculaNaveInfractorae').val(),
                                    'TipoNaveId': $('#cbTipoNavee').val(),
                                    'PaisUbigeoId': $('#cbPaisUbigeoe').val(),
                                    'PropietarioNave': $('#txtPropietarioNavee').val(),
                                    'LatitudUbicacionNave': $('#txtLatitudUbicacione').val(),
                                    'LongitudUbicacionNave': $('#txtLongitudUbicacione').val(),
                                    'AreaIntervencion': $('#txtAreaIntervencione').val(),
                                    'AmbitoNaveId': $('#cbAmbitoNavee').val(),
                                    'SectorExtrainstitucional': $('#txtSectorExtrainstitucionale').val(),
                                    'Tenor': $('#txtTenore').val(),
                                    'Articulo': $('#txtArticuloe').val(),
                                    'AvisosInfraccion': $('#txtAvisosInfraccione').val(),
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
                                    $('#tblComoperguardAvisoInfraccionImpuesto').DataTable().ajax.reload();
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

    $('#tblComoperguardAvisoInfraccionImpuesto').DataTable({
        ajax: {
            "url": '/ComoperguardAvisoInfraccionImpuesto/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "avisoInfraccionImpuestoId" },
            { "data": "descJefaturaDistritoCapitania" },
            { "data": "nombreCapitania" },
            { "data": "horaInfraccion" },
            { "data": "fechaInfraccion" },
            { "data": "nombreNoveInfractora" },
            { "data": "matriculaNaveInfractora" },
            { "data": "descTipoNave" },
            { "data": "nombrePais" },
            { "data": "propietarioNave" },
            { "data": "latitudUbicacionNave" },
            { "data": "longitudUbicacionNave" },
            { "data": "areaIntervencion" },
            { "data": "descAmbitoNave" },
            { "data": "sectorExtrainstitucional" },
            { "data": "tenor" },
            { "data": "articulo" },
            { "data": "avisosInfraccion" },
            { "data": "observaciones" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.avisoInfraccionImpuestoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.avisoInfraccionImpuestoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperguard - Avisos de Infracción Impuestos por la Autoridad Maritima',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperguard - Avisos de Infracción Impuestos por la Autoridad Maritima',
                title: 'Comoperguard - Avisos de Infracción Impuestos por la Autoridad Maritima',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperguard - Avisos de Infracción Impuestos por la Autoridad Maritima',
                title: 'Comoperguard - Avisos de Infracción Impuestos por la Autoridad Maritima',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperguard - Avisos de Infracción Impuestos por la Autoridad Maritima',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18]
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
    $.getJSON('/ComoperguardAvisoInfraccionImpuesto/Mostrar?Id=' + Id, [], function (AvisoInfraccionImpuestoDTO) {
        $('#txtCodigo').val(AvisoInfraccionImpuestoDTO.avisoInfraccionImpuestoId);
        $('#cbJefaturaDistritoCapitaniae').val(AvisoInfraccionImpuestoDTO.jefaturaDistritoCapitaniaId);
        $('#cbCapitaniae').val(AvisoInfraccionImpuestoDTO.capitaniaId);
        $('#txtHoraInfraccione').val(AvisoInfraccionImpuestoDTO.horaInfraccion);
        $('#txtFechaInfraccione').val(AvisoInfraccionImpuestoDTO.fechaInfraccion);
        $('#txtNombreNoveInfractorae').val(AvisoInfraccionImpuestoDTO.nombreNoveInfractora);
        $('#txtMatriculaNaveInfractorae').val(AvisoInfraccionImpuestoDTO.matriculaNaveInfractora);
        $('#cbTipoNavee').val(AvisoInfraccionImpuestoDTO.tipoNaveId);
        $('#cbPaisUbigeoe').val(AvisoInfraccionImpuestoDTO.paisUbigeoId);
        $('#txtPropietarioNavee').val(AvisoInfraccionImpuestoDTO.propietarioNave);
        $('#txtLatitudUbicacione').val(AvisoInfraccionImpuestoDTO.latitudUbicacionNave);
        $('#txtLongitudUbicacione').val(AvisoInfraccionImpuestoDTO.longitudUbicacionNave);
        $('#txtAreaIntervencione').val(AvisoInfraccionImpuestoDTO.areaIntervencion);
        $('#cbAmbitoNavee').val(AvisoInfraccionImpuestoDTO.ambitoNaveId);
        $('#txtSectorExtrainstitucionale').val(AvisoInfraccionImpuestoDTO.sectorExtrainstitucional);
        $('#txtTenore').val(AvisoInfraccionImpuestoDTO.tenor);
        $('#txtArticuloe').val(AvisoInfraccionImpuestoDTO.articulo);
        $('#txtAvisosInfraccione').val(AvisoInfraccionImpuestoDTO.avisosInfraccion);
        $('#txtObservacionese').val(AvisoInfraccionImpuestoDTO.observaciones); 
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
                url: '/ComoperguardAvisoInfraccionImpuesto/Eliminar',
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
                    $('#tblComoperguardAvisoInfraccionImpuesto').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperguardAvisoInfraccionImpuesto() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComoperguardAvisoInfraccionImpuesto/cargaCombs', [], function (Json) {
        var jefaturaDistritoCapitania = Json["data1"];
        var capitania = Json["data2"];
        var tipoNave = Json["data3"];
        var paisUbigeo = Json["data4"];
        var ambitoNave = Json["data5"];

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


        $("select#cbCapitania").html("");
        $.each(capitania, function () {
            var RowContent = '<option value=' + this.capitaniaId + '>' + this.nombre + '</option>'
            $("select#cbCapitaniae").append(RowContent);
        });
        $("select#cbCapitaniae").html("");
        $.each(capitania, function () {
            var RowContent = '<option value=' + this.capitaniaId + '>' + this.nombre + '</option>'
            $("select#cbCapitaniae").append(RowContent);
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


        $("select#cbPaisUbigeo").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeoe").append(RowContent);
        });
        $("select#cbPaisUbigeoe").html("");
        $.each(paisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUbigeoe").append(RowContent);
        });


        $("select#cbAmbitoNave").html("");
        $.each(ambitoNave, function () {
            var RowContent = '<option value=' + this.ambitoNaveId + '>' + this.descAmbitoNave + '</option>'
            $("select#cbAmbitoNavee").append(RowContent);
        });
        $("select#cbAmbitoNavee").html("");
        $.each(ambitoNave, function () {
            var RowContent = '<option value=' + this.ambitoNaveId + '>' + this.descAmbitoNave + '</option>'
            $("select#cbAmbitoNavee").append(RowContent);
        }); 
    });
}

