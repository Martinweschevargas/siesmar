var tblComzocuatroAlistCombustibleLubricante;
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
                                url: '/ComzocuatroAlistCombustibleLubricante/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoAlistamientoCombustibleLubricante2': $('#cbAlistamientoCombustibleLubricante2e').val(),  
                                    'PromedioPonderado': $('#txtPromedioPonderado').val(),
                                    'SubPromedioParcial': $('#txtSubPromedioParcial').val(),
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
                                    $('#tblComzocuatroAlistCombustibleLubricante').DataTable().ajax.reload();
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
                                url: '/ComzocuatroAlistCombustibleLubricante/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'CodigoAlistamientoCombustibleLubricante2': $('#cbAlistamientoCombustibleLubricante2e').val(),
                                    'PromedioPonderado': $('#txtPromedioPonderado').val(),
                                    'SubPromedioParcial': $('#txtSubPromedioParcial').val(),
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
                                    $('#tblComzocuatroAlistCombustibleLubricante').DataTable().ajax.reload();
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

   tblComzocuatroAlistCombustibleLubricante =  $('#tblComzocuatroAlistCombustibleLubricante').DataTable({
        ajax: {
            "url": '/ComzocuatroAlistCombustibleLubricante/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoCombustibleLubricanteId" },
            { "data": "descUnidadNaval" },
            { "data": "descAlistamientoCombustibleLubricante2" },
            { "data": "articulo" },
            { "data": "equipo" },
            { "data": "unidadMedida" },
            { "data": "cargo" },
            { "data": "aumento" },
            { "data": "consuo" },
            { "data": "existencia" },  
            { "data": "promedioPonderado" },  
            { "data": "subPromedioParcial" },
            { "data": "cargaId" }


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoCombustibleLubricanteId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoCombustibleLubricanteId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comzocuatro - Situación de Combustibles Y Lubricantes (ACL)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9 , 10 , 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comzocuatro - Situación de Combustibles Y Lubricantes (ACL)',
                title: 'Comzocuatro - Situación de Combustibles Y Lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comzocuatro - Situación de Combustibles Y Lubricantes (ACL)',
                title: 'Comzocuatro - Situación de Combustibles Y Lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comzocuatro - Situación de Combustibles Y Lubricantes (ACL)',
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
    $.getJSON('/ComzocuatroAlistCombustibleLubricante/Mostrar?Id=' + Id, [], function (AlistCombustibleLubricanteComzocuatroDTO) {
        $('#txtCodigo').val(AlistCombustibleLubricanteComzocuatroDTO.alistamientoCombustibleLubricanteId);
        $('#cbUnidadNavale').val(AlistCombustibleLubricanteComzocuatroDTO.codigoUnidadNaval);
        $('#cbAlistamientoCombustibleLubricante2e').val(AlistCombustibleLubricanteComzocuatroDTO.codigoAlistamientoCombustibleLubricante2);
        $('#txtArticuloe').val(AlistCombustibleLubricanteComzocuatroDTO.articulo);
        $('#txtEquipoe').val(AlistCombustibleLubricanteComzocuatroDTO.equipo);
        $('#txtUnidadMedidae').val(AlistCombustibleLubricanteComzocuatroDTO.unidadMedida);
        $('#txtCargoe').val(AlistCombustibleLubricanteComzocuatroDTO.cargo);
        $('#txtAumentoe').val(AlistCombustibleLubricanteComzocuatroDTO.aumento);
        $('#txtConsuoe').val(AlistCombustibleLubricanteComzocuatroDTO.consuo);
        $('#txtExistenciae').val(AlistCombustibleLubricanteComzocuatroDTO.existencia); 
        $('#txtPromedioPonderadoe').val(AlistCombustibleLubricanteComzocuatroDTO.promedioPonderado); 
        $('#txtSubPromedioParciale').val(AlistCombustibleLubricanteComzocuatroDTO.subPromedioParcial); 
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
                url: '/ComzocuatroAlistCombustibleLubricante/Eliminar',
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
                    $('#tblComzocuatroAlistCombustibleLubricante').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComzocuatroAlistCombustibleLubricante() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComzocuatroAlistCombustibleLubricante/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var AlistamientoCombustibleLubricante2 = Json["data2"];
        var listaCargas = Json["data3"];



        $("select#cbUnidadNaval").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbAlistamientoCombustibleLubricante2").html("");
        $.each(AlistamientoCombustibleLubricante2, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoCombustibleLubricante2 + '>' + this.descAlistamientoCombustibleLubricante2 + '</option>'
            $("select#cbAlistamientoCombustibleLubricante2").append(RowContent);
        });
        $("select#cbAlistamientoCombustibleLubricante2e").html("");
        $.each(AlistamientoCombustibleLubricante2, function () {
            var RowContent = '<option value=' + this.codigoAlistamientoCombustibleLubricante2 + '>' + this.descAlistamientoCombustibleLubricante2 + '</option>'
            $("select#cbAlistamientoCombustibleLubricante2e").append(RowContent);
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
        reporteSeleccionado = '/ComzocuatroAlistCombustibleLubricante/ReporteME?idCarga=';
        $('#fecha').hide();
    }

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


