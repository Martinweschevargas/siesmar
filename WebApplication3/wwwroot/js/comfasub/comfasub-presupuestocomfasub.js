﻿var tblComfasubPresupuestoComfasub;

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
                                url: '/ComfasubPresupuestoComfasub/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidad').val(),
                                    'CodigoSistemaPropulsion': $('#cbSistema').val(),
                                    'CodigoSubSistemaPropulsion': $('#cbSubSistema').val(),
                                    'PresupuestoAsignado': $('#txtPresupuesto').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuente').val(),
                                    'CodigoSubUnidadEjecutora': $('#cbSubUnidad').val(),
                                    'CodigoCentroGasto': $('#cbCentro').val(),
                                    'CodigoPartida': $('#cbPartida').val(),
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
                                    $('#tblComfasubPresupuestoComfasub').DataTable().ajax.reload();
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
                                url: '/ComfasubPresupuestoComfasub/Actualizar',
                                data: {

                                    'PresupuestoComfasubId': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidade').val(),
                                    'CodigoSistemaPropulsion': $('#cbSistemae').val(),
                                    'CodigoSubSistemaPropulsion': $('#cbSubSistemae').val(),
                                    'PresupuestoAsignado': $('#txtPresupuestoe').val(),
                                    'CodigoFuenteFinanciamiento': $('#cbFuentee').val(),
                                    'CodigoSubUnidadEjecutora': $('#cbSubUnidade').val(),
                                    'CodigoCentroGasto': $('#cbCentroe').val(),
                                    'CodigoPartida': $('#cbPartidae').val(), 
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
                                    $('#tblComfasubPresupuestoComfasub').DataTable().ajax.reload();
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

    tblComfasubPresupuestoComfasub = $('#tblComfasubPresupuestoComfasub').DataTable({
        ajax: {
            "url": '/ComfasubPresupuestoComfasub/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "presupuestoComfasubId" },
            { "data": "descUnidadNaval" },
            { "data": "descSistemaPropulsion" },
            { "data": "descSubSistemaPropulsion" },
            { "data": "presupuestoAsignado" },
            { "data": "descFuenteFinanciamiento" },
            { "data": "descSubUnidadEjecutora" },  
            { "data": "descCentroGasto" },
            { "data": "descPartida" },
            { "data": "cargaId" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.presupuestoComfasubId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.presupuestoComfasubId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Comfasub - Presupuesto',
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
                filename: 'Comfasub - Presupuesto',
                title: 'Comfasub - Presupuesto',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Comfasub - Presupuesto',
                title: 'Comfasub - Presupuesto',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Comfasub - Presupuesto',
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
    tblComfasubPresupuestoComfasub.columns(9).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblComfasubPresupuestoComfasub.columns(9).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/ComfasubPresupuestoComfasub/Mostrar?Id=' + Id, [], function (PresupuestoComfasubDTO) {
        $('#txtCodigo').val(PresupuestoComfasubDTO.presupuestoComfasubId);
        $('#cbUnidade').val(PresupuestoComfasubDTO.codigoUnidadNaval);
        $('#cbSistemae').val(PresupuestoComfasubDTO.codigoSistemaPropulsion);
        $('#cbSubSistemae').val(PresupuestoComfasubDTO.codigoSubSistemaPropulsion);
        $('#txtPresupuestoe').val(PresupuestoComfasubDTO.presupuestoAsignado);
        $('#cbFuentee').val(PresupuestoComfasubDTO.codigoFuenteFinanciamiento);
        $('#cbSubUnidade').val(PresupuestoComfasubDTO.codigoSubUnidadEjecutora);
        $('#cbCentroe').val(PresupuestoComfasubDTO.codigoCentroGasto);
        $('#cbPartidae').val(PresupuestoComfasubDTO.codigoPartida); 
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
                url: '/ComfasubPresupuestoComfasub/Eliminar',
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
                    $('#tblComfasubPresupuestoComfasub').DataTable().ajax.reload();
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
                url: '/ComfasubPresupuestoComfasub/EliminarCarga',
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
                    $('#tblComfasubPresupuestoComfasub').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });
        }
    })
}

function nuevaComfasubPresupuestoComfasub() {
    $('#listar').hide();
    $('#nuevo').show();
}

function mostrarDatos() {
    const input = document.getElementById("inputExcel");
    const formData = new FormData();
    formData.append("ArchivoExcel", input.files[0]);
    $.ajax({
        type: "POST",
        url: 'ComfasubPresupuestoComfasub/MostrarDatos',
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
                            $("<td>").text(item.codigoUnidadNaval),
                            $("<td>").text(item.codigoSistemaPropulsion),
                            $("<td>").text(item.codigoSubSistemaPropulsion),
                            $("<td>").text(item.presupuestoAsignado),
                            $("<td>").text(item.codigoFuenteFinanciamiento),
                            $("<td>").text(item.codigoSubUnidadEjecutora),
                            $("<td>").text(item.codigoCentroGasto),
                            $("<td>").text(item.codigoPartida)

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
    fetch("ComfasubPresupuestoComfasub/EnviarDatos", {
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
    $.getJSON('/ComfasubPresupuestoComfasub/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var sistemaPropulsion = Json["data2"];
        var subSistemaPropulsion = Json["data3"];
        var fuenteFinanciamiento = Json["data4"];
        var subUnidadEjecutora = Json["data5"];
        var centroGasto = Json["data6"];
        var partida = Json["data7"];
        var listaCargas = Json["data8"];


        $("select#cbUnidad").html("");
        $("select#cbUnidade").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.codigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidad").append(RowContent);
            $("select#cbUnidade").append(RowContent);
        });

        $("select#cbSistema").html("");
        $("select#cbSistemae").html("");
        $.each(sistemaPropulsion, function () {
            var RowContent = '<option value=' + this.codigoSistemaPropulsion + '>' + this.descSistemaPropulsion + '</option>'
            $("select#cbSistema").append(RowContent);
            $("select#cbSistemae").append(RowContent);
        });

        $("select#cbSubSistema").html("");
        $("select#cbSubSistemae").html("");
        $.each(subSistemaPropulsion, function () {
            var RowContent = '<option value=' + this.codigoSubSistemaPropulsion + '>' + this.descSubSistemaPropulsion + '</option>'
            $("select#cbSubSistema").append(RowContent);
            $("select#cbSubSistemae").append(RowContent);
        });

        $("select#cbFuente").html("");
        $("select#cbFuentee").html("");
        $.each(fuenteFinanciamiento, function () {
            var RowContent = '<option value=' + this.codigoFuenteFinanciamiento + '>' + this.descFuenteFinanciamiento + '</option>'
            $("select#cbFuente").append(RowContent);
            $("select#cbFuentee").append(RowContent);
        });

        $("select#cbSubUnidad").html("");
        $("select#cbSubUnidade").html("");
        $.each(subUnidadEjecutora, function () {
            var RowContent = '<option value=' + this.codigoSubUnidadEjecutora + '>' + this.descSubUnidadEjecutora + '</option>'
            $("select#cbSubUnidad").append(RowContent);
            $("select#cbSubUnidade").append(RowContent);
        });

        $("select#cbCentro").html("");
        $("select#cbCentroe").html("");
        $.each(centroGasto, function () {
            var RowContent = '<option value=' + this.codigoCentroGasto + '>' + this.descCentroGasto + '</option>'
            $("select#cbCentro").append(RowContent);
            $("select#cbCentroe").append(RowContent);
        });

        $("select#cbPartida").html("");
        $("select#cbPartidae").html("");
        $.each(partida, function () {
            var RowContent = '<option value=' + this.codigoPartida + '>' + this.descPartida + '</option>'
            $("select#cbPartida").append(RowContent);
            $("select#cbPartidae").append(RowContent);
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

