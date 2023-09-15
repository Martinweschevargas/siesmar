var tblJesernavimarServicioPrestado;

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
                                url: '/JesernavimarServicioPrestado/Insertar',
                                data: {
                                    'CodigoUnidadNaval': $('#cbUnidadNaval').val(),
                                    'DocumentoServicio': $('#txtDocumentoServicio').val(),
                                    'FechaServicioPrestado': $('#txtFechaServicioPrestado').val(),
                                    'UnidadAuxiliarNaval': $('#cbUnidadAuxiliarNaval').val(),
                                    'NroViajeComercial': $('#txtNroViajeComercial').val(),
                                    'PuertoPeruZarpe': $('#cbPuertoPeruZarpe').val(),
                                    'DepartamentoZarpe': $('#cbDepartamentoZarpe').val(),
                                    'ProvinciaZarpe': $('#cbProvinciaZarpe').val(),
                                    'DistritoZarpe': $('#cbDistritoZarpe').val(),
                                    'FechaHoraZarpe': $('#txtFechaHoraZarpe').val(),
                                    'Ocurrencia': $('#txtOcurrencia').val(),
                                    'PuertoPeruArribo': $('#cbPuertoPeruArribo').val(),
                                    'DepartamentoArribo': $('#cbDepartamentoArribo').val(),
                                    'ProvinciaArribo': $('#cbProvinciaArribo').val(),
                                    'DistritoArribo': $('#cbDistritoArribo').val(),
                                    'FechaHoraArribo': $('#txtFechaHoraArribo').val(),
                                    'EmpresaReceptoraServicio': $('#txtEmpresaReceptoraServicio').val(),
                                    'CargaId': $('#cargasR').val(),
                                    'mes': $('select#cbMes').val(),
                                    'anio': $('select#cbAnio').val()
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
                                    $('#tblJesernavimarServicioPrestado').DataTable().ajax.reload();
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
                                url: '/JesernavimarServicioPrestado/Actualizar',
                                data: {
                                    'Id': $('#txtCodigo').val(),
                                    'CodigoUnidadNaval': $('#cbUnidadNavale').val(),
                                    'DocumentoServicio': $('#txtDocumentoServicioe').val(),
                                    'FechaServicioPrestado': $('#txtFechaServicioPrestadoe').val(),
                                    'UnidadAuxiliarNaval': $('#cbUnidadAuxiliarNavale').val(),
                                    'NroViajeComercial': $('#txtNroViajeComerciale').val(),
                                    'PuertoPeruZarpe': $('#cbPuertoPeruZarpee').val(),
                                    'DepartamentoZarpe': $('#cbDepartamentoZarpee').val(),
                                    'ProvinciaZarpe': $('#cbProvinciaZarpee').val(),
                                    'DistritoZarpe': $('#cbDistritoZarpee').val(),
                                    'FechaHoraZarpe': $('#txtFechaHoraZarpee').val(),
                                    'Ocurrencia': $('#txtOcurrenciae').val(),
                                    'PuertoPeruArribo': $('#cbPuertoPeruArriboe').val(),
                                    'DepartamentoArribo': $('#cbDepartamentoArriboe').val(),
                                    'ProvinciaArribo': $('#cbProvinciaArriboe').val(),
                                    'DistritoArribo': $('#cbDistritoArriboe').val(),
                                    'FechaHoraArribo': $('#txtFechaHoraArriboe').val(),
                                    'EmpresaReceptoraServicio': $('#txtEmpresaReceptoraServicioe').val(),  
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
                                    $('#tblJesernavimarServicioPrestado').DataTable().ajax.reload();
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

    $('#tblJesernavimarServicioPrestado').DataTable({
        ajax: {
            "url": '/JesernavimarServicioPrestado/CargaTabla',
            "type": "GET",
            "datatype": "json"
        },
        "columns": [
            { "data": "servicioPrestadoId" },
            { "data": "descUnidadNaval" },
            { "data": "documentoServicio" },
            { "data": "fechaServicioPrestado" },
            { "data": "descUnidadAuxiliarNaval" },
            { "data": "nroViajeComercial" },
            { "data": "descPuertoPeruZarpe" },
            { "data": "descDepartamentoZarpe" },
            { "data": "descProvinciaZarpe" },
            { "data": "descDistritoZarpe" },
            { "data": "fechaHoraZarpe" },
            { "data": "ocurrencia" },
            { "data": "descPuertoPeruArribo" },
            { "data": "descDepartamentoArribo" },
            { "data": "descProvinciaArribo" },
            { "data": "descDistritoArribo" },
            { "data": "fechaHoraArribo" },
            { "data": "empresaReceptoraServicio" }, 
            {
                "render": function (data, type, row) {
                    return '<a class="txt" onclick=edit(' + row.servicioPrestadoId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
                }
            },
            {
                "render": function (data, type, row) {
                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.servicioPrestadoId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
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
                filename: 'Jesernavimar - Servicios prestados',
                title: '',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-csv',
            },
            //'excel',
            {
                extend: 'excelHtml5',
                text: 'Exportar Excel',
                filename: 'Jesernavimar - Servicios prestados',
                title: 'Jesernavimar - Servicios prestados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-excel',
            },
            //'pdf',
            {
                extend: 'pdfHtml5',
                text: 'Exportar PDF',
                filename: 'Jesernavimar - Servicios prestados',
                title: 'Jesernavimar - Servicios prestados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
                },
                className: 'btn-exportar-pdf',
            },
            //'print'
            {
                extend: 'print',
                title: 'Jesernavimar - Servicios prestados',
                exportOptions: {
                    columns: [0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17]
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
    tblJesernavimarServicioPrestado.columns(18).search(CodigoCarga).draw();
}

function mostrarTodos() {
    tblJesernavimarServicioPrestado.columns(18).search('').draw();
}

function edit(Id) {
    $('#listar').hide();
    $('#editar').show();
    $.getJSON('/JesernavimarServicioPrestado/Mostrar?Id=' + Id, [], function (RegistroEgresoHospitalario) {
        $('#txtCodigo').val(RegistroEgresoHospitalario.servicioPrestadoId);
        $('#cbUnidadNavale').val(ServicioPrestadoDTO.codigoUnidadNaval);
        $('#txtDocumentoServicioe').val(ServicioPrestadoDTO.documentoServicio);
        $('#txtFechaServicioPrestadoe').val(ServicioPrestadoDTO.fechaServicioPrestado);
        $('#cbUnidadAuxiliarNavale').val(ServicioPrestadoDTO.unidadAuxiliarNaval);
        $('#txtNroViajeComerciale').val(ServicioPrestadoDTO.nroViajeComercial);
        $('#cbPuertoPeruZarpee').val(ServicioPrestadoDTO.puertoPeruZarpe);
        $('#cbDepartamentoZarpee').val(ServicioPrestadoDTO.departamentoZarpe);
        $('#cbProvinciaZarpee').val(ServicioPrestadoDTO.provinciaZarpe);
        $('#cbDistritoZarpee').val(ServicioPrestadoDTO.distritoZarpe);
        $('#txtFechaHoraZarpee').val(ServicioPrestadoDTO.fechaHoraZarpe);
        $('#txtOcurrenciae').val(ServicioPrestadoDTO.ocurrencia);
        $('#cbPuertoPeruArriboe').val(ServicioPrestadoDTO.puertoPeruArribo);
        $('#cbDepartamentoArriboe').val(ServicioPrestadoDTO.departamentoArribo);
        $('#cbProvinciaArriboe').val(ServicioPrestadoDTO.provinciaArribo);
        $('#cbDistritoArriboe').val(ServicioPrestadoDTO.distritoArribo);
        $('#txtFechaHoraArriboe').val(ServicioPrestadoDTO.fechaHoraArribo);
        $('#txtEmpresaReceptoraServicioe').val(ServicioPrestadoDTO.empresaReceptoraServicio); 
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
                url: '/JesernavimarServicioPrestado/Eliminar',
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
                    $('#tblJesernavimarServicioPrestado').DataTable().ajax.reload();
                },
                complete: function () {
                    $('#loader-6').hide();
                }
            });

            callback(true);
        }
    })
}

function nuevaJesernavimarServicioPrestado() {
    $('#listar').hide();
    $('#nuevo').show();
}

function cargaDatos() {
    $.getJSON('/JesernavimarServicioPrestado/cargaCombs', [], function (Json) {
        var unidadNaval = Json["data1"];
        var puertoPeru = Json["data2"];
        var departamentoUbigeo = Json["data3"];
        var provinciaUbigeo = Json["data4"];
        var distritoUbigeo = Json["data5"];





        $("select#cbUnidadNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.CodigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNaval").append(RowContent);
        });
        $("select#cbUnidadNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.CodigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadNavale").append(RowContent);
        });


        $("select#cbUnidadAuxiliarNaval").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.CodigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadAuxiliarNaval").append(RowContent);
        });
        $("select#cbUnidadAuxiliarNavale").html("");
        $.each(unidadNaval, function () {
            var RowContent = '<option value=' + this.CodigoUnidadNaval + '>' + this.descUnidadNaval + '</option>'
            $("select#cbUnidadAuxiliarNavale").append(RowContent);
        });


        $("select#cbPuertoPeruZarpe").html("");
        $.each(puertoPeru, function () {
            var RowContent = '<option value=' + this.puertoPeruId + '>' + this.descPuertoPeru + '</option>'
            $("select#cbPuertoPeruZarpe").append(RowContent);
        });
        $("select#cbPuertoPeruZarpee").html("");
        $.each(puertoPeru, function () {
            var RowContent = '<option value=' + this.puertoPeruId + '>' + this.descPuertoPeru + '</option>'
            $("select#cbPuertoPeruZarpee").append(RowContent);
        });


        $("select#cbDepartamentoZarpe").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoZarpe").append(RowContent);
        });
        $("select#cbDepartamentoZarpee").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoZarpee").append(RowContent);
        });


        $("select#cbProvinciaZarpe").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaZarpe").append(RowContent);
        });
        $("select#cbProvinciaZarpee").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaZarpee").append(RowContent);
        });


        $("select#cbDistritoZarpe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoZarpe").append(RowContent);
        });
        $("select#cbDistritoZarpee").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoZarpee").append(RowContent);
        });


        $("select#cbPuertoPeruArribo").html("");
        $.each(puertoPeru, function () {
            var RowContent = '<option value=' + this.puertoPeruId + '>' + this.descPuertoPeru + '</option>'
            $("select#cbPuertoPeruArribo").append(RowContent);
        });
        $("select#cbPuertoPeruArriboe").html("");
        $.each(puertoPeru, function () {
            var RowContent = '<option value=' + this.puertoPeruId + '>' + this.descPuertoPeru + '</option>'
            $("select#cbPuertoPeruArriboe").append(RowContent);
        });


        $("select#cbDepartamentoArribo").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento+ '</option>'
            $("select#cbDepartamentoArribo").append(RowContent);
        });
        $("select#cbDepartamentoArriboe").html("");
        $.each(departamentoUbigeo, function () {
            var RowContent = '<option value=' + this.departamentoUbigeoId + '>' + this.descDepartamento + '</option>'
            $("select#cbDepartamentoArriboe").append(RowContent);
        });


        $("select#cbProvinciaArribo").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaArribo").append(RowContent);
        });
        $("select#cbProvinciaArriboe").html("");
        $.each(provinciaUbigeo, function () {
            var RowContent = '<option value=' + this.provinciaUbigeoId + '>' + this.descProvincia + '</option>'
            $("select#cbProvinciaArriboe").append(RowContent);
        });


        $("select#cbDistritoArribo").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoArribo").append(RowContent);
        });
        $("select#cbDistritoArriboe").html("");
        $.each(distritoUbigeo, function () {
            var RowContent = '<option value=' + this.distritoUbigeoId + '>' + this.descDistrito + '</option>'
            $("select#cbDistritoArriboe").append(RowContent);
        }); 


    });
}

