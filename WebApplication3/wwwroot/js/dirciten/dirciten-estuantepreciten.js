var tblDircitenEstudiantesPreCiten;

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
                                url: '/DircitenEstudiantesPreCiten/Insertar',
                                data: {
                                    'DNIEstudiantePreCiten': $('#txtDNI').val(),
                                    'GeneroEstudiantePreCiten': $('#txtGenero').val(),
                                    'FechaNacimiento': $('#txtFechaNacimiento').val(),
                                    'DistritoUbigeoDomicilio': $('#cbLugarDomicilio').val(),
                                    'TipoColegioProcedencia': $('#txtTipoColegioProcedencia').val(),
                                    'ColegioProcedencia': $('#txtColegioProcedencia').val(),
                                    'DistritoUbigeoColegio': $('#cbLugarColegio').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'Fecha': $('#txtFecha').val()

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
                                    $('#tblDircitenEstudiantesPreCiten').DataTable().ajax.reload();
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
                                url: '/DircitenEstudiantesPreCiten/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'DNIEstudiantePreCiten': $('#txtDNIe').val(),
                                    'GeneroEstudiantePreCiten': $('#txtGeneroe').val(),
                                    'FechaNacimiento': $('#txtFechaNacimientoe').val(),
                                    'LugarDomicilio': $('#cbLugarDomicilioe').val(),
                                    'TipoColegioProcedencia': $('#txtTipoColegioProcedenciae').val(),
                                    'ColegioProcedencia': $('#txtColegioProcedenciae').val(),
                                    'LugarColegio': $('#cbLugarColegioe').val(),
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
                                    $('#tblDircitenEstudiantesPreCiten').DataTable().ajax.reload();
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

   tblDircitenEstudiantesPreCiten =  $('#tblDircitenEstudiantesPreCiten').DataTable({
        ajax: {
            "url": '/DircitenEstudiantesPreCiten/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "estudiantePreCitenId" },
            { "data": "dniEstudiantePreCiten" },
            { "data": "generoEstudiantePreCiten" },
            { "data": "fechaNacimiento" },
            { "data": "lugarDomicilio" },
            { "data": "tipoColegioProcedencia" },
            { "data": "colegioProcedencia" },
            { "data": "lugarColegio" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.estudiantePreCitenId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.estudiantePreCitenId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirciten - Estudiantes del Pre CITEN',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirciten - Estudiantes del Pre CITEN',
                title: 'Dirciten - Estudiantes del Pre CITEN',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirciten - Estudiantes del Pre CITEN',
                title: 'Dirciten - Estudiantes del Pre CITEN',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirciten - Estudiantes del Pre CITEN',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
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

});

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DircitenEstudiantesPreCiten/Mostrar?Id=' + Id, [], function (EstudiantesPreCitenDTO) {
        $('#txtCodigo').val(EstudiantesPreCitenDTO.estudiantePreCitenId);
        $('#txtDNIe').val(EstudiantesPreCitenDTO.dniEstudiantePreCiten);
        $('#txtGeneroe').val(EstudiantesPreCitenDTO.generoEstudiantePreCiten);
        $('#txtFechaNacimientoe').val(EstudiantesPreCitenDTO.fechaNacimiento);
        $('#cbLugarDomicilioe').val(EstudiantesPreCitenDTO.lugarDomicilio);
        $('#txtTipoColegioProcedenciae').val(EstudiantesPreCitenDTO.tipoColegioProcedencia);
        $('#txtColegioProcedenciae').val(EstudiantesPreCitenDTO.colegioProcedencia);
        $('#cbLugarColegioe').val(EstudiantesPreCitenDTO.lugarColegio);
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
                url: '/DircitenEstudiantesPreCiten/Eliminar',
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
                    $('#tblDircitenEstudiantesPreCiten').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function eliminarCarga() {
    var id = $('select#cargas').val();
    Swal.fire({
        title: 'Estas seguro?',
        text: "No podras revertir!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si,borralo!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: "POST",
                url: '/DircitenEstudiantesPreCiten/EliminarCarga',
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
                    cargaDatos();
                    $('#tblDircitenEstudiantesPreCiten').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaDircitenEstudiantesPreCiten() {
    $('#listar').hide();
    $('#nuevo').show();
}



function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DircitenEstudiantesPreCiten/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.dniEstudiantePreCiten),
                            $("<td>").text(item.generoEstudiantePreCiten),
                            $("<td>").text(item.fechaNacimiento),
                            $("<td>").text(item.distritoUbigeoDomicilio),
                            $("<td>").text(item.tipoColegioProcedencia),
                            $("<td>").text(item.colegioProcedencia),
                            $("<td>").text(item.distritoUbigeoColegio)

                        )
                    )
                })
                Swal.fire(
                    'Cargado!',
                    'Vista previa con éxito.',
                    'success'
                )
            } else {
                Swal.fire(
                    'Atención!',
                    'Ocurrio un problema.',
                    'error'
                )
            }
        },
        complete: function () {
            $('#loader-6').hide();
        }
    });
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    formData.append("Fecha", $('#txtFecha').val())
    fetch("DircitenEstudiantesPreCiten/EnviarDatos", {
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
                    'Ocurrio un problema. ' + mensaje,
                    'error'
                )
            }
        })
}

function cargaDatos() {
    $.getJSON('/DircitenEstudiantesPreCiten/cargaCombs', [], function (Json) {
        var Distrito = Json["data1"];
        var listaCargas = Json["data2"];

        $("select#cbLugarDomicilio").html("");
        $("select#cbLugarDomicilioe").html("");
        $("select#cbLugarColegio").html("");
        $("select#cbLugarColegioe").html("");
        $.each(Distrito, function () {
            var RowContent = '<option value=' + this.distritoUbigeo + '>' + this.descDistrito + '</option>'
            $("select#cbLugarColegio").append(RowContent);
            $("select#cbLugarColegioe").append(RowContent);
            $("select#cbLugarDomicilio").append(RowContent);
            $("select#cbLugarDomicilioe").append(RowContent);
        });


        $("select#cargasR").html("");
        $("select#cargas").html("");
        $("select#cargas").append('<option value=0>Seleccione Carga...</option>');
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    });
}