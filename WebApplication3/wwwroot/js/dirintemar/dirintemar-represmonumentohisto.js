var tblDirintemarRepresMonumentoHistorico;
var DistritoUbigeo;
var ProvinciaUbigeo;
var DepartamentoUbigeo;
var PaisUbigeo;

$('select#cbDepartamentoU').append('<option selected disabled>Seleccionar Departamento</option>');
$('select#cbProvinciaU').append('<option selected disabled>Seleccionar Provincia</option>');
$('select#cbDistritoU').append('<option selected disabled>Seleccionar Distrito</option>');

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
                                url: '/DirintemarRepresMonumentoHistorico/Insertar',
                                data: {
                                    'TipoRepresentacionBienHistoricoId': $('#cbTipoRepres').val(),
                                    'DenominacionRepresMonumentoHistorico': $('#txtDenominacion').val(),
                                    'TipoMaterialBienHistoricoId': $('#cbTipoMaterialB').val(),
                                    'EstadoConservacion': $('#txtEstadoC').val(),
                                    'NombreEscultor': $('#txtNombreEscultor').val(),
                                    'FechaEntregaInaguracion': $('#txtFechaEntrega').val(),
                                    'UbicacionRepresentacion': $('#txtUbicacionR').val(),
                                    'DistritoUbigeoId': $('#cbDistritoU').val(),
                                  
                                    'CustorioMonumentoHistorico': $('#txtCustoMonumento').val(),
                                    'ReferenciaMonumentoHistorico': $('#txtReferencia').val(),
                                    'InversionMonumentoHistorico': $('#txtInversion').val(),

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
                                    $('#tblDirintemarRepresMonumentoHistorico').DataTable().ajax.reload();
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
                                url: '/DirintemarRepresMonumentoHistorico/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'TipoRepresentacionBienHistoricoId': $('#cbTipoReprese').val(),
                                    'DenominacionRepresMonumentoHistorico': $('#txtDenominacione').val(),
                                    'TipoMaterialBienHistoricoId': $('#cbTipoMaterialBe').val(),
                                    'EstadoConservacion': $('#txtEstadoCe').val(),
                                    'NombreEscultor': $('#txtNombreEscultore').val(),
                                    'FechaEntregaInaguracion': $('#txtFechaEntregae').val(),
                                    'UbicacionRepresentacion': $('#txtUbicacionRe').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUe').val(),
                                    
                                    'CustorioMonumentoHistorico': $('#txtCustoMonumentoe').val(),
                                    'ReferenciaMonumentoHistorico': $('#txtReferenciae').val(),
                                    'InversionMonumentoHistorico': $('#txtInversione').val(),
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
                                    $('#tblDirintemarRepresMonumentoHistorico').DataTable().ajax.reload();
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

    $('#tblDirintemarRepresMonumentoHistorico').DataTable({
        ajax: {
            "url": '/DirintemarRepresMonumentoHistorico/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "represMonumentoHistoricoId" },
            { "data": "descTipoRepresentacionBienHistorico" },
            { "data": "denominacionRepresMonumentoHistorico" },
            { "data": "descTipoMaterialBienHistorico" },
            { "data": "estadoConservacion" },
            { "data": "nombreEscultor" },
            { "data": "fechaEntregaInaguracion" },
            { "data": "ubicacionRepresentacion" },
            { "data": "distrito" },  
            { "data": "descProvincia" },
            { "data": "descDepartamento" },
            { "data": "pais" },
            { "data": "custorioMonumentoHistorico" },
            { "data": "referenciaMonumentoHistorico" },
            { "data": "inversionMonumentoHistorico" },  
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.represMonumentoHistoricoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.represMonumentoHistoricoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Representación y/o Monumentos Historicos en el Pais Relacionados a la Marina',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirintemar - Representación y/o Monumentos Historicos en el Pais Relacionados a la Marina',
                title: 'Dirintemar - Representación y/o Monumentos Historicos en el Pais Relacionados a la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Representación y/o Monumentos Historicos en el Pais Relacionados a la Marina',
                title: 'Dirintemar - Representación y/o Monumentos Historicos en el Pais Relacionados a la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Representación y/o Monumentos Historicos en el Pais Relacionados a la Marina',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14]
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
    $.getJSON('/DirintemarRepresMonumentoHistorico/Mostrar?Id=' + Id, [], function (RepresMonumentoHistoricoDAO) {
        $('#txtCodigo').val(RepresMonumentoHistoricoDAO.represMonumentoHistoricoId);
        $('#cbTipoReprese').val(RepresMonumentoHistoricoDAO.tipoRepresentacionBienHistoricoId);
        $('#txtDenominacione').val(RepresMonumentoHistoricoDAO.denominacionRepresMonumentoHistorico);
        $('#cbTipoMaterialBe').val(RepresMonumentoHistoricoDAO.tipoMaterialBienHistoricoId);
        $('#txtEstadoCe').val(RepresMonumentoHistoricoDAO.estadoConservacion);
        $('#txtNombreEscultore').val(RepresMonumentoHistoricoDAO.nombreEscultor);
        $('#txtFechaEntregae').val(RepresMonumentoHistoricoDAO.fechaEntregaInaguracion);
        $('#txtUbicacionRe').val(RepresMonumentoHistoricoDAO.ubicacionRepresentacion);
        var iddistrito = RepresMonumentoHistoricoDAO.distritoUbigeoId;
        $('#cbDistritoUe').val(RepresMonumentoHistoricoDAO.distritoUbigeoId);
        $('#txtCustoMonumentoe').val(RepresMonumentoHistoricoDAO.custorioMonumentoHistorico);
        $('#txtReferenciae').val(RepresMonumentoHistoricoDAO.referenciaMonumentoHistorico);
        $('#txtInversione').val(RepresMonumentoHistoricoDAO.inversionMonumentoHistorico);

        encontrardatocombo(iddistrito);
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
                url: '/DirintemarRepresMonumentoHistorico/Eliminar',
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
                    $('#tblDirintemarRepresMonumentoHistorico').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDirintemarRepresMonumentoHistorico() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarRepresMonumentoHistorico/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.tipoRepresentacionBienHistoricoId),
                        $("<td>").text(item.denominacionRepresMonumentoHistorico),
                        $("<td>").text(item.tipoMaterialBienHistoricoId),
                        $("<td>").text(item.estadoConservacion),
                        $("<td>").text(item.nombreEscultor),
                        $("<td>").text(item.fechaEntregaInaguracion),
                        $("<td>").text(item.ubicacionRepresentacion),
                        $("<td>").text(item.distritoUbigeoId),
                        $("<td>").text(item.descProvincia),
                        $("<td>").text(item.descDepartamento),
                        $("<td>").text(item.pais),
                        $("<td>").text(item.custorioMonumentoHistorico),
                        $("<td>").text(item.referenciaMonumentoHistorico),
                        $("<td>").text(item.inversionMonumentoHistorico)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarRepresMonumentoHistorico/EnviarDatos", {
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
    $.getJSON('/DirintemarRepresMonumentoHistorico/cargaCombs', [], function (Json) {
        var TipoMaterialBienHistorico = Json["data1"];
         DistritoUbigeo = Json["data2"];
         ProvinciaUbigeo = Json["data3"];
         PaisUbigeo = Json["data4"];
         DepartamentoUbigeo = Json["data5"];
        var TipoRepresentacionBienHistorico = Json["data6"];

        $("select#cbTipoMaterialB").html("");
        $.each(TipoMaterialBienHistorico, function () {
            var RowContent = '<option value=' + this.tipoMaterialBienHistoricoId + '>' + this.descTipoMaterialBienHistorico + '</option>'
            $("select#cbTipoMaterialB").append(RowContent);
        });
        $("select#cbTipoMaterialBe").html("");
        $.each(TipoMaterialBienHistorico, function () {
            var RowContent = '<option value=' + this.tipoMaterialBienHistoricoId + '>' + this.descTipoMaterialBienHistorico + '</option>'
            $("select#cbTipoMaterialBe").append(RowContent);
        });




        $("select#cbPaisU").html("");
        $.each(PaisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisU").append(RowContent);
        });
        $("select#cbPaisUe").html("");
        $.each(PaisUbigeo, function () {
            var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
            $("select#cbPaisUe").append(RowContent);
        });

        $("select#cbTipoRepres").html("");
        $.each(TipoRepresentacionBienHistorico, function () {
            var RowContent = '<option value=' + this.tipoRepresentacionBienHistoricoId + '>' + this.descTipoRepresentacionBienHistorico + '</option>'
            $("select#cbTipoRepres").append(RowContent);
        });
        $("select#cbTipoReprese").html("");
        $.each(TipoRepresentacionBienHistorico, function () {
            var RowContent = '<option value=' + this.tipoRepresentacionBienHistoricoId + '>' + this.descTipoRepresentacionBienHistorico + '</option>'
            $("select#cbTipoReprese").append(RowContent);
        });
    });
}

$('select#cbPaisU').on('change', function () {

    var codigo = $(this).val();
    $.each(PaisUbigeo, function () {
        if (this.paisUbigeoId == codigo) {
            $("select#cbDepartamentoU").html("");
            $('select#cbDepartamentoU').append('<option selected disabled>Seleccionar Departamento</option>');

            $.each(DepartamentoUbigeo, function (index) {
                if (this.paisUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
                    $("select#cbDepartamentoU").append(RowContent);
                }
            });
        }
    });
    $("select#cbProvinciaU").html("");
    $('select#cbProvinciaU').append('<option selected disabled>Seleccionar Provincia</option>');
    $("select#cbDistritoU").html("");
    $('select#cbDistritoU').append('<option selected disabled>Seleccionar Distrito</option>');
   
});

$('select#cbDepartamentoU').on('change', function () {

    var codigo = $(this).val();

    $.each(DepartamentoUbigeo, function () {
        if (this.departamentoUbigeoId == codigo) {
            $("select#cbProvinciaU").html("");
            $('select#cbProvinciaU').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(ProvinciaUbigeo, function (index) {
                if (this.departamentoUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaU").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoU").html("");
    $('select#cbDistritoU').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaU').on('change', function () {

    var codigo = $(this).val();

    $.each(ProvinciaUbigeo, function () {
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistritoU").html("");
            $('select#cbDistritoU').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(DistritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoU").append(RowContent);
                }
            });
        }
    });
});


//Para actualizar
$('select#cbPaisUe').on('change', function () {

    var codigo = $(this).val();
    $.each(PaisUbigeo, function () {
        if (this.paisUbigeoId == codigo) {
            $("select#cbDepartamentoUe").html("");
            $('select#cbDepartamentoUe').append('<option selected disabled>Seleccionar Departamento</option>');

            $.each(DepartamentoUbigeo, function (index) {
                if (this.paisUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
                    $("select#cbDepartamentoUe").append(RowContent);
                }
            });
        }
    });
    $("select#cbProvinciaUe").html("");
    $('select#cbProvinciaUe').append('<option selected disabled>Seleccionar Provincia</option>');
    $("select#cbDistritoUe").html("");
    $('select#cbDistritoUe').append('<option selected disabled>Seleccionar Distrito</option>');

});

$('select#cbDepartamentoUe').on('change', function () {

    var codigo = $(this).val();

    $.each(DepartamentoUbigeo, function () {
        if (this.departamentoUbigeoId == codigo) {
            $("select#cbProvinciaUe").html("");
            $('select#cbProvinciaUe').append('<option selected disabled>Seleccionar Provincia</option>');

            $.each(ProvinciaUbigeo, function (index) {
                if (this.departamentoUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                    $("select#cbProvinciaUe").append(RowContent);
                }
            });
        }
    });
    $("select#cbDistritoUe").html("");
    $('select#cbDistritoUe').append('<option selected disabled>Seleccionar Distrito</option>');
});

$('select#cbProvinciaUe').on('change', function () {

    var codigo = $(this).val();

    $.each(ProvinciaUbigeo, function () {
        if (this.provinciaUbigeoId == codigo) {
            $("select#cbDistritoUe").html("");
            $('select#cbDistritoUe').append('<option selected disabled>Seleccionar Distrito</option>');
            $.each(DistritoUbigeo, function () {
                if (this.provinciaUbigeoId == codigo) {
                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                    $("select#cbDistritoUe").append(RowContent);
                }
            });
        }
    });
});



function encontrardatocombo(id) {
    var iddistrito = id;

    $.each(DistritoUbigeo, function () {
        if (this.distritoUbigeoId == iddistrito) {
            var provincia = this.provinciaUbigeoId;

            $.each(ProvinciaUbigeo, function () {
                if (this.provinciaUbigeoId == provincia) {
                    var departamento = this.departamentoUbigeoId;

                    $.each(DepartamentoUbigeo, function () {
                        if (this.departamentoUbigeoId == departamento) {
                            var pais = this.paisUbigeoId;

                            $("select#cbPaisUe").html("");
                            $.each(PaisUbigeo, function () {
                                var RowContent = '<option value=' + this.paisUbigeoId + '>' + this.nombrePais + '</option>'
                                $("select#cbPaisUe").append(RowContent);

                            });
                            $('#cbPaisUe').val(pais);

                            $("select#cbDepartamentoUe").html("");
                            $.each(DepartamentoUbigeo, function () {
                                if (this.paisUbigeoId == pais) {
                                    var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
                                    $("select#cbDepartamentoUe").append(RowContent);
                                }
                            });
                            $('#cbDepartamentoUe').val(departamento);

                            $("select#cbProvinciaUe").html("");
                            $.each(ProvinciaUbigeo, function (index) {
                                if (this.departamentoUbigeoId == departamento) {
                                    var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
                                    $("select#cbProvinciaUe").append(RowContent);
                                }
                            });
                            $('#cbProvinciaUe').val(provincia);

                            $("select#cbDistritoUe").html("");
                            $.each(DistritoUbigeo, function () {
                                if (this.provinciaUbigeoId == provincia) {
                                    var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
                                    $("select#cbDistritoUe").append(RowContent);
                                }
                            });
                            $('#cbDistritoUe').val(iddistrito);


                        }
                    });
                }
            });


        }
    });
}