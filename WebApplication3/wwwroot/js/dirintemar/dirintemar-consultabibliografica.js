var tblDirintemarConsultaBibliograficas;
var ConsultaBibliograficasId;

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
                                url: '/DirintemarConsultaBibliograficas/Insertar',
                                data: {
                                    'FechaConsultaBibliografica': $('#txtFechaConsulta').val(),
                                    'LibroPrestadoConsultaB': $('#txtLibroPrestado').val(),
                                    'PublicacionPrestadaConsultaB': $('#txtPublicacionesP').val(),
                                    'RevistaPrestada': $('#txtRevistaPrestada').val(),
                                    'FolletoPrestado': $('#txtFolletoPrestado').val(),
                                    'LecturaInterna': $('#txtLecturaInterna').val(),
                                    'ReferenciaBibliografica': $('#txtReferenciaBibli').val(),
                                    'BusquedaEnSistema': $('#txtBusquedaSistema').val(),
                                    'TotalConsultaBibliografica': $('#txtConsultaBibli').val(),
                                    'UsuariosLectoresConsultasB': $('#txtUsuariosLectores').val(),
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
                                    $('#tblDirintemarConsultaBibliograficas').DataTable().ajax.reload();
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
                                url: '/DirintemarConsultaBibliograficas/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'FechaConsultaBibliografica': $('#txtFechaConsultae').val(),
                                    'LibroPrestadoConsultaB': $('#txtLibroPrestadoe').val(),
                                    'PublicacionePrestadaConsultaB': $('#txtPublicacionesPe').val(),
                                    'RevistaPrestada': $('#txtRevistaPrestadae').val(),
                                    'FolletoPrestado': $('#txtFolletoPrestadoe').val(),
                                    'LecturaInterna': $('#txtLecturaInternae').val(),
                                    'ReferenciaBibliografica': $('#txtReferenciaBiblie').val(),
                                    'BusquedaEnSistema': $('#txtBusquedaSistemae').val(),
                                    'TotalConsultaBibliografica': $('#txtConsultaBiblie').val(),
                                    'UsuariosLectoresConsultasB': $('#txtUsuariosLectorese').val(),
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
                                    $('#tblDirintemarConsultaBibliograficas').DataTable().ajax.reload();
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

    $('#tblDirintemarConsultaBibliograficas').DataTable({
        ajax: {
            "url": '/DirintemarConsultaBibliograficas/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "consultaBibliograficaId" },
            { "data": "fechaConsultaBibliografica" },
            { "data": "libroPrestadoConsultaB" },
            { "data": "publicacionePrestadaConsultaB" },
            { "data": "revistaPrestada" },
            { "data": "folletoPrestado" },
            { "data": "lecturaInterna" },
            { "data": "referenciaBibliografica" },
            { "data": "busquedaEnSistema" },  
            { "data": "totalConsultaBibliografica" },  
            { "data": "usuariosLectoresConsultasB" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.consultaBibliograficaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.consultaBibliograficaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dirintemar - Consultas Bibliográficas (Biblioteca)',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Dirintemar - Consultas Bibliográficas (Biblioteca)',
                title: 'Dirintemar - Consultas Bibliográficas (Biblioteca)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dirintemar - Consultas Bibliográficas (Biblioteca)',
                title: 'Dirintemar - Consultas Bibliográficas (Biblioteca)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dirintemar - Consultas Bibliográficas (Biblioteca)',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10]
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
    $.getJSON('/DirintemarConsultaBibliograficas/Mostrar?Id=' + Id , [], function (ConsultaBibliograficasDTO) {
        $('#txtCodigo').val(ConsultaBibliograficasDTO.consultaBibliograficaId);
        $('#txtFechaConsultae').val(ConsultaBibliograficasDTO.fechaConsultaBibliografica);
        $('#txtLibroPrestadoe').val(ConsultaBibliograficasDTO.libroPrestadoConsultaB);
        $('#txtPublicacionesPe').val(ConsultaBibliograficasDTO.publicacionePrestadaConsultaB);
        $('#txtRevistaPrestadae').val(ConsultaBibliograficasDTO.revistaPrestada);
        $('#txtFolletoPrestadoe').val(ConsultaBibliograficasDTO.folletoPrestado);
        $('#txtLecturaInternae').val(ConsultaBibliograficasDTO.lecturaInterna);
        $('#txtReferenciaBiblie').val(ConsultaBibliograficasDTO.referenciaBibliografica);
        $('#txtBusquedaSistemae').val(ConsultaBibliograficasDTO.busquedaEnSistema);
        $('#txtConsultaBiblie').val(ConsultaBibliograficasDTO.totalConsultaBibliografica);
        $('#txtUsuariosLectorese').val(ConsultaBibliograficasDTO.usuariosLectoresConsultasB);
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
                url: '/DirintemarConsultaBibliograficas/Eliminar',
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
                    $('#tblDirintemarConsultaBibliograficas').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
           
            callback(true);
        }
    })
}

function nuevaDirintemarConsultaBibliograficas() {
    $('#listar').hide();
    $('#nuevo').show();
}


function mostrarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()
    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarConsultaBibliograficas/MostrarDatos", {
        method: "POST",
        body: formData
    })
        .then((response) => { return response.json() })
        .then((dataJson) => {
            $('#NumRegistros').text(dataJson.length);
            dataJson.forEach((item) => {
                $("#tbData tbody").append(
                    $("<tr>").append(
                        $("<td>").text(item.consultaBibliograficaId),
                        $("<td>").text(item.fechaConsultaBibliografica),
                        $("<td>").text(item.libroPrestadoConsultaB),
                        $("<td>").text(item.publicacionePrestadaConsultaB),
                        $("<td>").text(item.revistaPrestada),
                        $("<td>").text(item.folletoPrestado),
                        $("<td>").text(item.lecturaInterna),
                        $("<td>").text(item.referenciaBibliografica),
                        $("<td>").text(item.busquedaEnSistema),
                        $("<td>").text(item.totalConsultaBibliografica),
                        $("<td>").text(item.usuariosLectoresConsultasB)
                    )
                )
            })
        })
}

function enviarDatos() {
    const input = document.getElementById("inputExcel")
    const formData = new FormData()

    formData.append("ArchivoExcel", input.files[0])
    fetch("DirintemarConsultaBibliograficas/EnviarDatos", {
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