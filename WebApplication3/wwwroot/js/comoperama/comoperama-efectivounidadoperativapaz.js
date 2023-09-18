var tblComoperamaEfectivoUnidadOperativaPaz;

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
                                url: '/ComoperamaEfectivoUnidadOperativaPaz/Insertar',
                                data: {
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDependencia').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoGradoPersonal': $('#cbGradoPersonal').val(),
                                    'NumeroEfectivosRequeridos': $('#txtNumeroEfectivosRequeridos').val(),
                                    'NumeroEfectivosAsignados': $('#txtNumeroEfectivosAsignados').val(), 
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
                                    $('#tblComoperamaEfectivoUnidadOperativaPaz').DataTable().ajax.reload();
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
                                url: '/ComoperamaEfectivoUnidadOperativaPaz/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoComandanciaDependencia': $('#cbComandanciaDependenciae').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoGradoPersonal': $('#cbGradoPersonale').val(),
                                    'NumeroEfectivosRequeridos': $('#txtNumeroEfectivosRequeridose').val(),
                                    'NumeroEfectivosAsignados': $('#txtNumeroEfectivosAsignadose').val(), 
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
                                    $('#tblComoperamaEfectivoUnidadOperativaPaz').DataTable().ajax.reload();
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

 tblComoperamaEfectivoUnidadOperativaPaz =   $('#tblComoperamaEfectivoUnidadOperativaPaz').DataTable({
        ajax: {
            "url": '/ComoperamaEfectivoUnidadOperativaPaz/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "efectivoUnidadOperativaPazId" },
            { "data": "descComandanciaDependencia" },
            { "data": "nombreDependencia" },
            { "data": "descCodigoGradoPerson" },
            { "data": "numeroEfectivosRequeridos" },
            { "data": "numeroEfectivosAsignados" }, 
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.efectivoUnidadOperativaPazId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.efectivoUnidadOperativaPazId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperama - Efectivos por Unidades Operativas en Tiempo de Paz',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperama - Efectivos por Unidades Operativas en Tiempo de Paz',
                title: 'Comoperama - Efectivos por Unidades Operativas en Tiempo de Paz',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperama - Efectivos por Unidades Operativas en Tiempo de Paz',
                title: 'Comoperama - Efectivos por Unidades Operativas en Tiempo de Paz',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperama - Efectivos por Unidades Operativas en Tiempo de Paz',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5]
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
    cargaBusqueda();
});

$('#btn_search').click(function () {
    cargaBusqueda();
});


$('#btn_all').click(function () {
    mostrarTodos();
});


function cargaBusqueda() {
    var CodigoCarga = $('#cargas').val();
    tblComoperamaEfectivoUnidadOperativaPaz.columns(6).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComoperamaEfectivoUnidadOperativaPaz.columns(6).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComoperamaEfectivoUnidadOperativaPaz/Mostrar?Id=' + Id, [], function (EfectivoUnidadOperativaPazDTO) {
        $('#txtCodigo').val(EfectivoUnidadOperativaPazDTO.efectivoUnidadOperativaPazId);
        $('#cbComandanciaDependenciae').val(EfectivoUnidadOperativaPazDTO.codigoComandanciaDependencia);
        $('#cbDependenciae').val(EfectivoUnidadOperativaPazDTO.codigoDependencia);
        $('#cbGradoPersonale').val(EfectivoUnidadOperativaPazDTO.codigoGradoPersonal);
        $('#txtNumeroEfectivosRequeridose').val(EfectivoUnidadOperativaPazDTO.numeroEfectivosRequeridos);
        $('#txtNumeroEfectivosAsignadose').val(EfectivoUnidadOperativaPazDTO.numeroEfectivosAsignados); 
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
                url: '/ComoperamaEfectivoUnidadOperativaPaz/Eliminar',
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
                    $('#tblComoperamaEfectivoUnidadOperativaPaz').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperamaEfectivoUnidadOperativaPaz() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComoperamaEfectivoUnidadOperativaPaz/MostrarDatos',
        data: formData,
        processData: false,
        contentType: false,
        beforeSend: function () {
            $('#loader-6').show();
        },
        success: function (dataJson) {
            console.log(dataJson);
            if (dataJson["data"] == "1") {
                dataJson["data1"].forEach((item) => {
                    $("#tbData tbody").append(
                        $("<tr>").append(
                            $("<td>").text(item.codigoComandanciaDependencia),
                            $("<td>").text(item.codigoDependencia),
                            $("<td>").text(item.codigoGradoPersonal),
                            $("<td>").text(item.numeroEfectivosRequeridos),
                            $("<td>").text(item.numeroEfectivosAsignados)
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
    fetch("ComoperamaEfectivoUnidadOperativaPaz/EnviarDatos", {
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
    $.getJSON('/ComoperamaEfectivoUnidadOperativaPaz/cargaCombs', [], function (Json) {
        var ComandanciaDependencia = Json["data1"];
        var Dependencia = Json["data2"];
        var GradoPersonal = Json["data3"];
        var listaCargas = Json["data4"];


        $("select#cbComandanciaDependencia").html("");
        $.each(ComandanciaDependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDependencia").append(RowContent);
        });
        $("select#cbComandanciaDependenciae").html("");
        $.each(ComandanciaDependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDependenciae").append(RowContent);
        });


        $("select#cbDependencia").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(Dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.descDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbGradoPersonal").html("");
        $.each(GradoPersonal, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonal + '>' + this.descGradoPersonal + '</option>'
            $("select#cbGradoPersonal").append(RowContent);
        });
        $("select#cbGradoPersonale").html("");
        $.each(GradoPersonal, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonal + '>' + this.descGradoPersonal + '</option>'
            $("select#cbGradoPersonale").append(RowContent);
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

