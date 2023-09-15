var tblComoperamaEfectivoNivelEntrenamientoUnidad;

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
                                url: '/ComoperamaEfectivoNivelEntrenamientoUnidad/Insertar',
                                data: {
                                    'CodigoComandanciaDependencia ': $('#cbComandanciaDependencia').val(),
                                    'CodigoDependencia': $('#cbDependencia').val(),
                                    'CodigoGradoPersonal': $('#cbGradoPersonal').val(),
                                    'NivelElemental': $('#txtNivelElemental').val(),
                                    'NivelBasico': $('#txtNivelBasico').val(),
                                    'NivelIntermedio': $('#txtNivelIntermedio').val(),
                                    'NivelAvanzado': $('#txtNivelAvanzado').val(),
                                    'NivelConjunto': $('#txtNivelConjunto').val(), 
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
                                    $('#tblComoperamaEfectivoNivelEntrenamientoUnidad').DataTable().ajax.reload();
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
                                url: '/ComoperamaEfectivoNivelEntrenamientoUnidad/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoComandanciaDependencia ': $('#cbComandanciaDependenciae').val(),
                                    'CodigoDependencia': $('#cbDependenciae').val(),
                                    'CodigoGradoPersonal': $('#cbGradoPersonale').val(),
                                    'NivelElemental': $('#txtNivelElementale').val(),
                                    'NivelBasico': $('#txtNivelBasicoe').val(),
                                    'NivelIntermedio': $('#txtNivelIntermedioe').val(),
                                    'NivelAvanzado': $('#txtNivelAvanzadoe').val(),
                                    'NivelConjunto': $('#txtNivelConjuntoe').val(), 
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
                                    $('#tblComoperamaEfectivoNivelEntrenamientoUnidad').DataTable().ajax.reload();
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

 tblComoperamaEfectivoNivelEntrenamientoUnidad =   $('#tblComoperamaEfectivoNivelEntrenamientoUnidad').DataTable({
        ajax: {
            "url": '/ComoperamaEfectivoNivelEntrenamientoUnidad/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "efectivoNivelEntrenamientoUnidadId" },
            { "data": "descComandanciaDependencia" },
            { "data": "nombreDependencia" },
            { "data": "descGradoPersonal" },
            { "data": "nivelElemental" },
            { "data": "nivelBasico" },
            { "data": "nivelIntermedio" },
            { "data": "nivelAvanzado" },
            { "data": "nivelConjunto" },
            { "data": "cargaId" },

            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.efectivoNivelEntrenamientoUnidadId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.efectivoNivelEntrenamientoUnidadId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comoperama - Efectivos de la Marina Según Nivel de Entrenamiento por Unidades',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Comoperama - Efectivos de la Marina Según Nivel de Entrenamiento por Unidades',
                title: 'Comoperama - Efectivos de la Marina Según Nivel de Entrenamiento por Unidades',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comoperama - Efectivos de la Marina Según Nivel de Entrenamiento por Unidades',
                title: 'Comoperama - Efectivos de la Marina Según Nivel de Entrenamiento por Unidades',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comoperama - Efectivos de la Marina Según Nivel de Entrenamiento por Unidades',
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
    tblComoperamaEfectivoNivelEntrenamientoUnidad.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblComoperamaEfectivoNivelEntrenamientoUnidad.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComoperamaEfectivoNivelEntrenamientoUnidad/Mostrar?Id=' + Id, [], function (EfectivoNivelEntrenamientoUnidadDTO) {
        $('#txtCodigo').val(EfectivoNivelEntrenamientoUnidadDTO.efectivoNivelEntrenamientoUnidadId);
        $('#cbComandanciaDependenciae').val(EfectivoNivelEntrenamientoUnidadDTO.codigoComandanciaDependencia);
        $('#cbDependenciae').val(EfectivoNivelEntrenamientoUnidadDTO.codigoDependencia);
        $('#cbGradoPersonale').val(EfectivoNivelEntrenamientoUnidadDTO.codigoGradoPersonal);
        $('#txtNivelElementale').val(EfectivoNivelEntrenamientoUnidadDTO.nivelElemental);
        $('#txtNivelBasicoe').val(EfectivoNivelEntrenamientoUnidadDTO.nivelBasico);
        $('#txtNivelIntermedioe').val(EfectivoNivelEntrenamientoUnidadDTO.nivelIntermedio);
        $('#txtNivelAvanzadoe').val(EfectivoNivelEntrenamientoUnidadDTO.nivelAvanzado);
        $('#txtNivelConjuntoe').val(EfectivoNivelEntrenamientoUnidadDTO.nivelConjunto); 
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
                url: '/ComoperamaEfectivoNivelEntrenamientoUnidad/Eliminar',
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
                    $('#tblComoperamaEfectivoNivelEntrenamientoUnidad').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaComoperamaEfectivoNivelEntrenamientoUnidad() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComoperamaEfectivoNivelEntrenamientoUnidad/MostrarDatos',
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
                            $("<td>").text(item.nivelElemental),
                            $("<td>").text(item.nivelBasico),
                            $("<td>").text(item.nivelIntermedio),
                            $("<td>").text(item.nivelAvanzado),
                            $("<td>").text(item.nivelConjunto)
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
    fetch("ComoperamaEfectivoNivelEntrenamientoUnidad/EnviarDatos", {
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
    $.getJSON('/ComoperamaEfectivoNivelEntrenamientoUnidad/cargaCombs', [], function (Json) {
        var comandanciaDependencia = Json["data1"];
        var dependencia = Json["data2"];
        var gradoPersonal = Json["data3"];
        var listaCargas = Json["data4"];
        $("select#cbComandanciaDependencia").html("");
        $.each(comandanciaDependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDependencia").append(RowContent);
        });
        $("select#cbComandanciaDependenciae").html("");
        $.each(comandanciaDependencia, function () {
            var RowContent = '<option value=' + this.codigoComandanciaDependencia + '>' + this.descComandanciaDependencia + '</option>'
            $("select#cbComandanciaDependenciae").append(RowContent);
        });


        $("select#cbDependencia").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependencia").append(RowContent);
        });
        $("select#cbDependenciae").html("");
        $.each(dependencia, function () {
            var RowContent = '<option value=' + this.codigoDependencia + '>' + this.nombreDependencia + '</option>'
            $("select#cbDependenciae").append(RowContent);
        });


        $("select#cbGradoPersonal").html("");
        $.each(gradoPersonal, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonal + '>' + this.descGrado + '</option>'
            $("select#cbGradoPersonal").append(RowContent);
        });
        $("select#cbGradoPersonale").html("");
        $.each(gradoPersonal, function () {
            var RowContent = '<option value=' + this.codigoGradoPersonal + '>' + this.descGrado + '</option>'
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

