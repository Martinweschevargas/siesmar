var tblCombima1AlistCombustibleLubricante;

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
                                url: '/Combima1AlistCombustibleLubricante/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'AlistamientoCombustibleLubricante2Id': $('#cbAlistamientoCombustibleLubricante2e').val(),  
                                    'PromedioPonderado': $('#txtPromedioPonderado').val(),
                                    'SubPromedioParcial': $('#txtSubPromedioParcial').val(),

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
                                    $('#tblCombima1AlistCombustibleLubricante').DataTable().ajax.reload();
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
                                url: '/Combima1AlistCombustibleLubricante/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'AlistamientoCombustibleLubricante2Id': $('#cbAlistamientoCombustibleLubricante2e').val(),
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
                                    $('#tblCombima1AlistCombustibleLubricante').DataTable().ajax.reload();
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

    $('#tblCombima1AlistCombustibleLubricante').DataTable({
        ajax: {
            "url": '/Combima1AlistCombustibleLubricante/CargaTabla',
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
                filename: 'Combasnai - Situación de Combustibles Y Lubricantes (ACL)',
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
                filename: 'Combasnai - Situación de Combustibles Y Lubricantes (ACL)',
                title: 'Combasnai - Situación de Combustibles Y Lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Combasnai - Situación de Combustibles Y Lubricantes (ACL)',
                title: 'Combasnai - Situación de Combustibles Y Lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Combasnai - Situación de Combustibles Y Lubricantes (ACL)',
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
    $.getJSON('/Combima1AlistCombustibleLubricante/Mostrar?Id=' + Id, [], function (AlistCombustibleLubricanteCombima1DTO) {
        $('#txtCodigo').val(AlistCombustibleLubricanteCombima1DTO.alistamientoCombustibleLubricanteId);
        $('#cbUnidadNavale').val(AlistCombustibleLubricanteCombima1DTO.unidadNavalId);
        $('#cbAlistamientoCombustibleLubricante2e').val(AlistCombustibleLubricanteCombima1DTO.alistamientoCombustibleLubricante2Id);
        $('#txtArticuloe').val(AlistCombustibleLubricanteCombima1DTO.articulo);
        $('#txtEquipoe').val(AlistCombustibleLubricanteCombima1DTO.equipo);
        $('#txtUnidadMedidae').val(AlistCombustibleLubricanteCombima1DTO.unidadMedida);
        $('#txtCargoe').val(AlistCombustibleLubricanteCombima1DTO.cargo);
        $('#txtAumentoe').val(AlistCombustibleLubricanteCombima1DTO.aumento);
        $('#txtConsuoe').val(AlistCombustibleLubricanteCombima1DTO.consuo);
        $('#txtExistenciae').val(AlistCombustibleLubricanteCombima1DTO.existencia); 
        $('#txtPromedioPonderadoe').val(AlistCombustibleLubricanteCombima1DTO.promedioPonderado); 
        $('#txtSubPromedioParciale').val(AlistCombustibleLubricanteCombima1DTO.subPromedioParcial); 
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
                url: '/Combima1AlistCombustibleLubricante/Eliminar',
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
                    $('#tblCombima1AlistCombustibleLubricante').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaCombima1AlistCombustibleLubricante() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/Combima1AlistCombustibleLubricante/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var AlistamientoCombustibleLubricante2 = Json["data2"];



        $("select#cbUnidadNaval").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(UnidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbAlistamientoCombustibleLubricante2").html("");
        $.each(AlistamientoCombustibleLubricante2, function () {
            var RowContent = '<option value=' + this.alistamientoCombustibleLubricante2Id + '>' + this.descAlistamientoCombustibleLubricante2 + '</option>'
            $("select#cbAlistamientoCombustibleLubricante2").append(RowContent);
        });
        $("select#cbAlistamientoCombustibleLubricante2e").html("");
        $.each(AlistamientoCombustibleLubricante2, function () {
            var RowContent = '<option value=' + this.alistamientoCombustibleLubricante2Id + '>' + this.descAlistamientoCombustibleLubricante2 + '</option>'
            $("select#cbAlistamientoCombustibleLubricante2e").append(RowContent);
        }); 


    });
}

