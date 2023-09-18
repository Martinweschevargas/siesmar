var tblCombasnaiAlistamientoMaterial;

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
                                url: '/CombasnaiAlistamientoMaterial/Insertar',
                                data: {
                                    'CapacidadOperativaId': $('#cbCapacidadOperativa').val(),
                                    'UnidadNavalId': $('#cbUnidadNaval').val(),
                                    'AlistamientoMaterialRequerido3NId': $('#cbAlistamientoMaterialRequerido3N').val(), 
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
                                    $('#tblCombasnaiAlistamientoMaterial').DataTable().ajax.reload();
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
                                url: '/CombasnaiAlistamientoMaterial/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CapacidadOperativaId': $('#cbCapacidadOperativae').val(),
                                    'UnidadNavalId': $('#cbUnidadNavale').val(),
                                    'AlistamientoMaterialRequerido3NId': $('#cbAlistamientoMaterialRequerido3Ne').val(), 
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
                                    $('#tblCombasnaiAlistamientoMaterial').DataTable().ajax.reload();
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

    $('#tblCombasnaiAlistamientoMaterial').DataTable({
        ajax: {
            "url": '/CombasnaiAlistamientoMaterial/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "alistamientoMaterialId" },
            { "data": "descUnidadNaval" },
            { "data": "descCapacidadOperativa" },
            { "data": "capacidadIntrinseca" },
            { "data": "ponderado1N" },
            { "data": "subclasificacion2" },
            { "data": "ponderado2Nivel" },
            { "data": "subclasificacion3" },
            { "data": "ponderado3Nivel" }, 
            { "data": "requerido" },
            { "data": "operativo" },
            { "data": "porcentajeOperatividad" },


            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.alistamientoMaterialId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.alistamientoMaterialId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Combasnai - Alistamiento de Material',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8 ,9, 10, 11]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Combasnai - Alistamiento de Material',
                title: 'Combasnai - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Combasnai - Alistamiento de Material',
                title: 'Combasnai - Alistamiento de Material',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Combasnai - Alistamiento de Material',
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
    $.getJSON('/CombasnaiAlistamientoMaterial/Mostrar?Id=' + Id, [], function (AlistamientoMaterialCombasnaiDTO) {
        $('#txtCodigo').val(AlistamientoMaterialCombasnaiDTO.alistamientoMaterialId);
        $('#cbCapacidadOperativae').val(AlistamientoMaterialCombasnaiDTO.capacidadOperativaId);
        $('#cbUnidadNavale').val(AlistamientoMaterialCombasnaiDTO.unidadNavalId);
        $('#cbAlistamientoMaterialRequerido3Ne').val(AlistamientoMaterialCombasnaiDTO.alistamientoMaterialRequerido3NId);
        $('#txtRequeridoe').val(AlistamientoMaterialCombasnaiDTO.requerido);
        $('#txtOperativoe').val(AlistamientoMaterialCombasnaiDTO.operativo);
        $('#txtPorcentajeOperatividade').val(AlistamientoMaterialCombasnaiDTO.porcentajeOperatividad);
        $('#txtCapacidadIntrinsecae').val(AlistamientoMaterialCombasnaiDTO.capacidadIntrinseca);
        $('#txtPonderado1Ne').val(AlistamientoMaterialCombasnaiDTO.ponderado1N);
        $('#txtSubclasificacion2e').val(AlistamientoMaterialCombasnaiDTO.subclasificacion2);
        $('#txtPonderado2Nivele').val(AlistamientoMaterialCombasnaiDTO.ponderado2Nivel);
        $('#txtPonderado3Nivele').val(AlistamientoMaterialCombasnaiDTO.ponderado3Nivel); 
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
                url: '/CombasnaiAlistamientoMaterial/Eliminar',
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
                    $('#tblCombasnaiAlistamientoMaterial').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaCombasnaiAlistamientoMaterial() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("CombasnaiAlistamientoMaterial/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.descUnidadNaval),
                        $("<td>").text(item.descCapacidadOperativa),
                        $("<td>").text(item.capacidadIntrinseca),
                        $("<td>").text(item.ponderado1N),
                        $("<td>").text(item.subclasificacion2),
                        $("<td>").text(item.ponderado2Nivel),
                        $("<td>").text(item.subclasificacion3),
                        $("<td>").text(item.ponderado3Nivel),
                        $("<td>").text(item.requerido),
                        $("<td>").text(item.operativo),
                        $("<td>").text(item.porcentajeOperatividad),
                    )
                )
            })
        })

}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("CombasnaiAlistamientoMaterial/EnviarDatos", {
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
    $.getJSON('/CombasnaiAlistamientoMaterial/cargaCombs', [], function (Json) {
        var UnidadNaval = Json["data1"];
        var CapacidadOperativa = Json["data2"];
        var AlistamientoMaterialRequerido3N = Json["data3"];

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

        $("select#cbCapacidadOperativa").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativa").append(RowContent);
        });
        $("select#cbCapacidadOperativae").html("");
        $.each(CapacidadOperativa, function () {
            var RowContent = '<option value=' + this.capacidadOperativaId + '>' + this.descCapacidadOperativa + '</option>'
            $("select#cbCapacidadOperativae").append(RowContent);
        });


        $("select#cbAlistamientoMaterialRequerido3N").html("");
        $.each(AlistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.alistamientoMaterialRequerido3NId + '>' + this.descAlistamientoMaterialRequerido3N + '</option>'
            $("select#cbAlistamientoMaterialRequerido3N").append(RowContent);
        });
        $("select#cbAlistamientoMaterialRequerido3Ne").html("");
        $.each(AlistamientoMaterialRequerido3N, function () {
            var RowContent = '<option value=' + this.alistamientoMaterialRequerido3NId + '>' + this.descAlistamientoMaterialRequerido3N + '</option>'
            $("select#cbAlistamientoMaterialRequerido3Ne").append(RowContent);
        }); 

    });
}

