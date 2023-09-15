var tblComfasAlistamientoMunicion;

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
                                url: '/ComfasAlistamientoMunicion/Insertar',
                                data: {
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'SistemaMunicionId': $('#cbSistemaMunicion').val(),
                                    'SubsistemaMunicionId': $('#cbSubsistemaMunicion').val(),
                                    'Equipo': $('#txtEquipo').val(),
                                    'Municion': $('#txtCombustibleLubricante').val(),
                                    'Existente': $('#txtExistenteGLS').val(),
                                    'Necesaria': $('#txtNecesariasGLS').val(),
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
                                    $('#tblComfasAlistamientoMunicion').DataTable().ajax.reload();
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
                                url: '/ComfasAlistamientoMunicion/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'SistemaMunicionId': $('#cbSistemaMunicione').val(),
                                    'SubsistemaMunicionId': $('#cbSubsistemaMunicione').val(),
                                    'Equipo': $('#txtEquipoe').val(),
                                    'Municion': $('#txtCombustibleLubricantee').val(),
                                    'Existente': $('#txtExistenteGLSe').val(),
                                    'Necesaria': $('#txtNecesariasGLSe').val(),
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
                                    $('#tblComfasAlistamientoMunicion').DataTable().ajax.reload();
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

    $('#tblComfasAlistamientoMunicion').DataTable({
        ajax: {
            "url": '/ComfasAlistamientoMunicion/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMunicionComfasId" },
            { "data": "descUnidadNaval" },
            { "data": "descSistemaMunicion" },
            { "data": "descSubsistemaMunicion" },
            { "data": "equipo" },
            { "data": "municion" },
            { "data": "existente" },
            { "data": "necesaria" },
            { "data": "coeficientePonderacion" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMunicionComfasId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMunicionComfasId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfas - Alistamiento de Munición (AMU)',
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
                filename: 'Comfas - Alistamiento de Munición (AMU)',
                title: 'Comfas - Alistamiento de Munición (AMU)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfas - Alistamiento de Munición (AMU)',
                title: 'Comfas - Alistamiento de Munición (AMU)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfas - Alistamiento de Munición (AMU)',
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
    $.getJSON('/ComfasAlistamientoMunicion/Mostrar?Id=' + Id, [], function (AlistamientoMunicionComfasDTO) {
        $('#txtCodigo').val(AlistamientoMunicionComfasDTO.alistamientoMunicionComfasId);
        $('#cbUnidadNavale').val(AlistamientoMunicionComfasDTO.unidadNavalId);
        $('#cbSistemaMunicione').val(AlistamientoMunicionComfasDTO.sistemaMunicionId);
        $('#cbSubsistemaMunicione').val(AlistamientoMunicionComfasDTO.subsistemaMunicionId);
        $('#txtEquipoe').val(AlistamientoMunicionComfasDTO.equipo);
        $('#txtCombustibleLubricantee').val(AlistamientoMunicionComfasDTO.municion);
        $('#txtExistenteGLSe').val(AlistamientoMunicionComfasDTO.existente);
        $('#txtNecesariasGLSe').val(AlistamientoMunicionComfasDTO.necesaria);
        $('#txtCoeficientePonderacione').val(AlistamientoMunicionComfasDTO.coeficientePonderacion); 
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
                url: '/ComfasAlistamientoMunicion/Eliminar',
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
                    $('#tblComfasAlistamientoMunicion').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComfasAlistamientoMunicion() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComfasAlistamientoMunicion/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var sistemaMunicion = Json["data2"];
        var subsistemaMunicion = Json["data3"];

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


        $("select#cbSistemaMunicion").html("");
        $.each(sistemaMunicion, function () {
            var RowContent = '<option value=' + this.sistemaMunicionId + '>' + this.descSistemaMunicion + '</option>'
            $("select#cbSistemaMunicion").append(RowContent);
        });
        $("select#cbSistemaMunicione").html("");
        $.each(sistemaMunicion, function () {
            var RowContent = '<option value=' + this.sistemaMunicionId + '>' + this.descSistemaMunicion + '</option>'
            $("select#cbSistemaMunicione").append(RowContent);
        });


        $("select#cbSubsistemaMunicion").html("");
        $.each(subsistemaMunicion, function () {
            var RowContent = '<option value=' + this.subsistemaMunicionId + '>' + this.descSubsistemaMunicion + '</option>'
            $("select#cbSubsistemaMunicion").append(RowContent);
        });
        $("select#cbSubsistemaMunicione").html("");
        $.each(subsistemaMunicion, function () {
            var RowContent = '<option value=' + this.subsistemaMunicionId + '>' + this.descSubsistemaMunicion + '</option>'
            $("select#cbSubsistemaMunicione").append(RowContent);
        }); 


    });
}

