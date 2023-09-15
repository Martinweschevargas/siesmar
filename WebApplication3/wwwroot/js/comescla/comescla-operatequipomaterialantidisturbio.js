var tblComesclaOperativEquipoMaterialAntidisturbio;

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
                                url: '/ComesclaOperativEquipoMaterialAntidisturbio/Insertar',
                                data: {
                                    'DescripcionMaterialId': $('#cbDescripcionMaterial').val(),
                                    'CantidadMaterial': $('#txtCantidadMaterial').val(),
                                    'Ubicacion': $('#txtUbicacion').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeo').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeo').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeo').val(),
                                    'CondicionId': $('#cbCondicion').val(),
                                    'Observacion': $('#txtObservacion').val(), 
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
                                    $('#tblComesclaOperativEquipoMaterialAntidisturbio').DataTable().ajax.reload();
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
                                url: '/ComesclaOperativEquipoMaterialAntidisturbio/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DescripcionMaterialId': $('#cbDescripcionMateriale').val(),
                                    'CantidadMaterial': $('#txtCantidadMateriale').val(),
                                    'Ubicacion': $('#txtUbicacione').val(),
                                    'DepartamentoUbigeoId': $('#cbDepartamentoUbigeoe').val(),
                                    'ProvinciaUbigeoId': $('#cbProvinciaUbigeoe').val(),
                                    'DistritoUbigeoId': $('#cbDistritoUbigeoe').val(),
                                    'CondicionId': $('#cbCondicione').val(),
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
                                    $('#tblComesclaOperativEquipoMaterialAntidisturbio').DataTable().ajax.reload();
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

    $('#tblComesclaOperativEquipoMaterialAntidisturbio').DataTable({
        ajax: {
            "url": '/ComesclaOperativEquipoMaterialAntidisturbio/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "operatividadEquiposMaterialAntidisturbioId" },
            { "data": "descDescripcionMaterial" },
            { "data": "cantidadMaterial" },
            { "data": "ubicacion" },
            { "data": "descDepartamentoUbigeo" },
            { "data": "descProvinciaUbigeo" },
            { "data": "descDistritoUbigeo" },
            { "data": "descCondicion" },
            { "data": "observacion" }, 


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.operatividadEquiposMaterialAntidisturbioId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.operatividadEquiposMaterialAntidisturbioId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comescla - Situación de Operatividad de Equipos y Material Antidisturbio',
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
                filename: 'Comescla - Situación de Operatividad de Equipos y Material Antidisturbio',
                title: 'Comescla - Situación de Operatividad de Equipos y Material Antidisturbio',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comescla - Situación de Operatividad de Equipos y Material Antidisturbio',
                title: 'Comescla - Situación de Operatividad de Equipos y Material Antidisturbio',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comescla - Situación de Operatividad de Equipos y Material Antidisturbio',
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
    $.getJSON('/ComesclaOperativEquipoMaterialAntidisturbio/Mostrar?Id=' + Id, [], function (OperatividadEquipoMaterialAntidisturbioComesclaDTO) {
        $('#txtCodigo').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.operatividadEquiposMaterialAntidisturbioId);
        $('#cbDescripcionMateriale').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.descripcionMaterialId);
        $('#txtCantidadMateriale').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.cantidadMaterial);
        $('#txtUbicacione').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.ubicacion);
        $('#cbDepartamentoUbigeoe').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.departamentoUbigeoId);
        $('#cbProvinciaUbigeoe').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.provinciaUbigeoId);
        $('#cbDistritoUbigeoe').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.distritoUbigeoId);
        $('#cbCondicione').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.condicionId);
        $('#txtObservacione').val(OperatividadEquipoMaterialAntidisturbioComesclaDTO.observacion); 
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
                url: '/ComesclaOperativEquipoMaterialAntidisturbio/Eliminar',
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
                    $('#tblComesclaOperativEquipoMaterialAntidisturbio').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComesclaOperativEquipoMaterialAntidisturbio() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/ComesclaOperativEquipoMaterialAntidisturbio/cargaCombs', [], function (Json) {
        var DescripcionMaterial = Json["data1"];
        var DepartamentoUbigeo = Json["data2"];
        var ProvinciaUbigeo = Json["data3"];
        var DistritoUbigeo = Json["data4"];
        var Condicion = Json["data5"];

        $("select#cbDescripcionMaterial").html("");
        $.each(DescripcionMaterial, function () {
            var RowContent = '<option value=' + this.descripcionMaterialId + '>' + this.descDescripcionMaterial + '</option>'
            $("select#cbDescripcionMaterial").append(RowContent);
        });
        $("select#cbDescripcionMateriale").html("");
        $.each(DescripcionMaterial, function () {
            var RowContent = '<option value=' + this.descripcionMaterialId + '>' + this.descDescripcionMaterial + '</option>'
            $("select#cbDescripcionMateriale").append(RowContent);
        });


        $("select#cbDepartamentoUbigeo").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeo").append(RowContent);
        });
        $("select#cbDepartamentoUbigeoe").html("");
        $.each(DepartamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoUbigeoe").append(RowContent);
        });


        $("select#cbProvinciaUbigeo").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUbigeo").append(RowContent);
        });
        $("select#cbProvinciaUbigeoe").html("");
        $.each(ProvinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaUbigeoe").append(RowContent);
        });


        $("select#cbDistritoUbigeo").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeo").append(RowContent);
        });
        $("select#cbDistritoUbigeoe").html("");
        $.each(DistritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoUbigeoe").append(RowContent);
        });


        $("select#cbCondicion").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#cbCondicion").append(RowContent);
        });
        $("select#cbCondicione").html("");
        $.each(Condicion, function () {
            var RowContent = '<option value=' + this.condicionId + '>' + this.descCondicion + '</option>'
            $("select#cbCondicione").append(RowContent);
        }); 


    });
}

