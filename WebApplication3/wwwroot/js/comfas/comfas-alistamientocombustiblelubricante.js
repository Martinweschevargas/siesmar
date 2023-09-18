var tblComfasAlistamientoCombustibleLubricante;

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
                                url: '/ComfasAlistamientoCombustibleLubricante/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'SistemaCombustibleLubricanteId': $('#cbSistemaCombustibleLubricante').val(),
                                    'SubsistemaCombustibleLubricanteId': $('#cbSubsistemaCombustibleLubricante').val(),
                                    'Equipo': $('#txtEquipo').val(),
                                    'CombustibleLubricante': $('#txtCombustibleLubricante').val(),
                                    'ExistenteGLS': $('#txtExistenteGLS').val(),
                                    'NecesariasGLS': $('#txtNecesariasGLS').val(),
                                    'CoeficientePonderacion': $('#txtCoeficientePonderacion').val(), 
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
                                    $('#tblComfasAlistamientoCombustibleLubricante').DataTable().ajax.reload();
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
                                url: '/ComfasAlistamientoCombustibleLubricante/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'SistemaCombustibleLubricanteId': $('#cbSistemaCombustibleLubricantee').val(),
                                    'SubsistemaCombustibleLubricanteId': $('#cbSubsistemaCombustibleLubricantee').val(),
                                    'Equipo': $('#txtEquipoe').val(),
                                    'CombustibleLubricante': $('#txtCombustibleLubricantee').val(),
                                    'ExistenteGLS': $('#txtExistenteGLSe').val(),
                                    'NecesariasGLS': $('#txtNecesariasGLSe').val(),
                                    'CoeficientePonderacion': $('#txtCoeficientePonderacione').val(), 
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
                                    $('#tblComfasAlistamientoCombustibleLubricante').DataTable().ajax.reload();
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

    $('#tblComfasAlistamientoCombustibleLubricante').DataTable({
        ajax: {
            "url": '/ComfasAlistamientoCombustibleLubricante/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoCombustibleLubricanteId" },
            { "data": "descUnidadNaval" },
            { "data": "descSistemaCombustibleLubricante" },
            { "data": "descSubsistemaCombustibleLubricante" },
            { "data": "equipo" },
            { "data": "combustibleLubricante" },
            { "data": "existenteGLS" },
            { "data": "necesariasGLS" },
            { "data": "coeficientePonderacion" }, 


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
                filename: 'Comfas - Alistamiento de Combustibles y Lubricantes (ACL)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comfas - Alistamiento de Combustibles y Lubricantes (ACL)',
                title: 'Comfas - Alistamiento de Combustibles y Lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Alistamiento de Combustibles y Lubricantes (ACL)',
                title: 'Comfas - Alistamiento de Combustibles y Lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Alistamiento de Combustibles y Lubricantes (ACL)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
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
    $.getJSON('/ComfasAlistamientoCombustibleLubricante/Mostrar?Id=' + Id, [], function (AlistamientoCombustibleLubricanteComfasDTO) {
        $('#txtCodigo').val(AlistamientoCombustibleLubricanteComfasDTO.alistamientoCombustibleLubricanteId);
        $('#cbUnidadNavale').val(AlistamientoCombustibleLubricanteComfasDTO.unidadNavalId);
        $('#cbSistemaCombustibleLubricantee').val(AlistamientoCombustibleLubricanteComfasDTO.sistemaCombustibleLubricanteId);
        $('#cbSubsistemaCombustibleLubricantee').val(AlistamientoCombustibleLubricanteComfasDTO.subsistemaCombustibleLubricanteId);
        $('#txtEquipoe').val(AlistamientoCombustibleLubricanteComfasDTO.equipo);
        $('#txtCombustibleLubricantee').val(AlistamientoCombustibleLubricanteComfasDTO.combustibleLubricante);
        $('#txtExistenteGLSe').val(AlistamientoCombustibleLubricanteComfasDTO.existenteGLS);
        $('#txtNecesariasGLSe').val(AlistamientoCombustibleLubricanteComfasDTO.necesariasGLS);
        $('#txtCoeficientePonderacione').val(AlistamientoCombustibleLubricanteComfasDTO.coeficientePonderacion); 
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
                url: '/ComfasAlistamientoCombustibleLubricante/Eliminar',
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
                    $('#tblComfasAlistamientoCombustibleLubricante').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasAlistamientoCombustibleLubricante() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasAlistamientoCombustibleLubricante/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var sistemaCombustibleLubricante = Json["data2"];
        var subsistemaCombustibleLubricante = Json["data3"];

        $("select#cbUnidadNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.unidadNavalId + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbSistemaCombustibleLubricante").html("");
        $.each(sistemaCombustibleLubricante, function () {
            var RowContent = '<option value=' + this.sistemaCombustibleLubricanteId + '>' + this.descSistemaCombustibleLubricante + '</option>'
            $("select#cbSistemaCombustibleLubricante").append(RowContent);
        });
        $("select#cbSistemaCombustibleLubricantee").html("");
        $.each(sistemaCombustibleLubricante, function () {
            var RowContent = '<option value=' + this.sistemaCombustibleLubricanteId + '>' + this.descSistemaCombustibleLubricante + '</option>'
            $("select#cbSistemaCombustibleLubricantee").append(RowContent);
        });


        $("select#cbSubsistemaCombustibleLubricante").html("");
        $.each(subsistemaCombustibleLubricante, function () {
            var RowContent = '<option value=' + this.subsistemaCombustibleLubricanteId + '>' + this.descSubsistemaCombustibleLubricante + '</option>'
            $("select#cbSubsistemaCombustibleLubricante").append(RowContent);
        });
        $("select#cbSubsistemaCombustibleLubricantee").html("");
        $.each(subsistemaCombustibleLubricante, function () {
            var RowContent = '<option value=' + this.subsistemaCombustibleLubricanteId + '>' + this.descSubsistemaCombustibleLubricante + '</option>'
            $("select#cbSubsistemaCombustibleLubricantee").append(RowContent);
        }); 


    });
}

