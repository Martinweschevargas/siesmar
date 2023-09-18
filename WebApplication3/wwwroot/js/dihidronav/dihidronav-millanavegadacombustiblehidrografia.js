var tblDihidronavMillaNavegadaCombustibleHidrografia;

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
                                url: '/DihidronavMillaNavegadaCombustibleHidrografia/Insertar',
                                data: {
                                    'NumeroOrden': $('#txtOrden').val(),
                                    'CodigoUnidadNaval': $('#cbUnidad').val(),
                                    'NumeroCascoUnidad': $('#txtCasco').val(),
                                    'NumeroMes': $('#cbMes').val(),
                                    'Milla': $('#txtMilla').val(),
                                    'Hora': $('#txtHora').val(),
                                    'CombustibleGalon': $('#txtCombustible').val(), 
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
                                    $('#tblDihidronavMillaNavegadaCombustibleHidrografia').DataTable().ajax.reload();
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
                                url: '/DihidronavMillaNavegadaCombustibleHidrografia/Actualizar',
                                data: {

                                    'MillaNavegadaCombustibleHidrografiaId': $('#txtCodigo').val(),
                                    'NumeroOrden': $('#txtOrdene').val(),
                                    'CodigoUnidadNaval': $('#cbUnidade').val(),
                                    'NumeroCascoUnidad': $('#txtCascoe').val(),
                                    'NumeroMes': $('#cbMese').val(),
                                    'Milla': $('#txtMillae').val(),
                                    'Hora': $('#txtHorae').val(),
                                    'CombustibleGalon': $('#txtCombustiblee').val(), 
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
                                    $('#tblDihidronavMillaNavegadaCombustibleHidrografia').DataTable().ajax.reload();
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

  tblDihidronavMillaNavegadaCombustibleHidrografia =  $('#tblDihidronavMillaNavegadaCombustibleHidrografia').DataTable({
        ajax: {
            "url": '/DihidronavMillaNavegadaCombustibleHidrografia/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "millaNavegadaCombustibleHidrografiaId" },
            { "data": "numeroOrden" },
            { "data": "descUnidadNaval" },
            { "data": "numeroCascoUnidad" },
            { "data": "descMes" },
            { "data": "milla" },
            { "data": "hora" },  
            { "data": "combustibleGalon" },
            { "data": "cargaId" },
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.millaNavegadaCombustibleHidrografiaId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.millaNavegadaCombustibleHidrografiaId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Dihidronav - Millas navegadas y consumo de combustible de las unidades hidrográficas',
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
                filename: 'Dihidronav - Millas navegadas y consumo de combustible de las unidades hidrográficas',
                title: 'Dihidronav - Millas navegadas y consumo de combustible de las unidades hidrográficas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Dihidronav - Millas navegadas y consumo de combustible de las unidades hidrográficas',
                title: 'Dihidronav - Millas navegadas y consumo de combustible de las unidades hidrográficas',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Dihidronav - Millas navegadas y consumo de combustible de las unidades hidrográficas',
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
    tblDihidronavMillaNavegadaCombustibleHidrografia.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {

    tblDihidronavMillaNavegadaCombustibleHidrografia.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/DihidronavMillaNavegadaCombustibleHidrografia/Mostrar?Id=' + Id, [], function (MillaNavegadaCombustibleHidrografiaDTO) {
        $('#txtCodigo').val(MillaNavegadaCombustibleHidrografiaDTO.millaNavegadaCombustibleHidrografiaId);
        $('#txtOrdene').val(MillaNavegadaCombustibleHidrografiaDTO.numeroOrden);
        $('#cbUnidade').val(MillaNavegadaCombustibleHidrografiaDTO.codigoUnidadNaval);
        $('#txtCascoe').val(MillaNavegadaCombustibleHidrografiaDTO.numeroCascoUnidad);
        $('#cbMese').val(MillaNavegadaCombustibleHidrografiaDTO.numeroMes);
        $('#txtMillae').val(MillaNavegadaCombustibleHidrografiaDTO.milla);
        $('#txtHorae').val(MillaNavegadaCombustibleHidrografiaDTO.hora);
        $('#txtCombustiblee').val(MillaNavegadaCombustibleHidrografiaDTO.combustibleGalon); 
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
                url: '/DihidronavMillaNavegadaCombustibleHidrografia/Eliminar',
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
                    $('#tblDihidronavMillaNavegadaCombustibleHidrografia').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaDihidronavMillaNavegadaCombustibleHidrografia() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'DihidronavMillaNavegadaCombustibleHidrografia/MostrarDatos',
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
                            $("<td>").text(item.numeroOrden),
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.numeroCascoUnidad),
                            $("<td>").text(item.numeroMes),
                            $("<td>").text(item.milla),
                            $("<td>").text(item.hora),
                            $("<td>").text(item.combustibleGalon)
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
    fetch("DihidronavMillaNavegadaCombustibleHidrografia/EnviarDatos", {
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
    $.getJSON('/DihidronavMillaNavegadaCombustibleHidrografia/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var mes = Json["data2"];
        var listaCargas = Json["data3"];


        $("select#cbUnidad").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidad").append(RowContent);
        });
        $("select#cbUnidade").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidade").append(RowContent);
        });

        $("select#cbMes").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMes").append(RowContent);
        });
        $("select#cbMese").html("");
        $.each(mes, function () {
            var RowContent = '<option value=' + this.numeroMes + '>' + this.descMes + '</option>'
            $("select#cbMese").append(RowContent);
        });

        $("select#cargasR").html("");
        $("select#cargas").html("");
        $.each(listaCargas, function () {
            var RowContent = '<option value=' + this.codigoCarga + '>Fecha Carga : ' + this.fechaCarga + '</option>'
            $("select#cargasR").append(RowContent);
            $("select#cargas").append(RowContent);
        });
    }) 
}

