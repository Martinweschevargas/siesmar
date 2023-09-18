//var tblDialiLicArmasMenoresMilitar;
//var licenciaArmasMenoresMilitarId;

//var modalConfirm = function (callback) {
//    $("#modal-btn-si").on("click", function () {
//        callback(true);
//        $("#mi-modal").modal('hide');
//    });
//    $("#modal-btn-no").on("click", function () {
//        callback(false);
//        $("#mi-modal").modal('hide');
//    });
//};

//modalConfirm(function (confirm) {
//    if (confirm) {
//        $.ajax({
//            type: "POST",
//            url: '/DialiLicArmasMenoresMilitar/Eliminar',
//            data: {
//                'Id': licenciaArmasMenoresMilitarId
//            },
//            beforeSend: function () {
//                $('#loader-6').show();
//            },
//            success: function (mensaje) {
//                if (mensaje == "1") {
//                    $('#alertsuccess').show();
//                    $('#mensajesuccess').text("Se elimino la Licencia Arma Menor Militar");
//                    $('#alertsuccess').hide(5000);
//                } else {
//                    $('#alerterror').show();
//                    $('#mensajeerror').text("Ocurrio un error!");
//                    $('#alerterror').hide(5000);
//                }
//                $('#listar').show();
//                $('#nuevo').hide();
//                $('#tblDialiLicArmasMenoresMilitar').DataTable().ajax.reload();
//            },
//            complete: function () {
//                $('#loader-6').hide();
//            }
//        });
//    }
//});

//$(document).ready(function () {
//    var forms = document.querySelectorAll('.needs-validation')
//    Array.prototype.slice.call(forms)
//        .forEach(function (form) {
//            form.addEventListener('submit', function (event) {
//                if (!form.checkValidity()) {
//                    event.preventDefault()
//                    event.stopPropagation()
//                } else {
//                    event.preventDefault();
//                    $.ajax({
//                        type: "POST",
//                        url: '/DialiLicArmasMenoresMilitar/Insertar',
//                        data: {
//                            'CodigoDocumentoArmaMenor': $('#txtCodigoD').val(),
//                            'SolDocumentoArmaMenor': $('#txtSolicitud').val(),
//                            'FechaSolicitudLicArmaMenor': $('#txtFechaS').val(),
//                            'TramiteArmaMenorId': $('#txtTramiteA').val(),
//                            'SituacionPersonalSolId': $('#txtSituacionP').val(),
//                            'CondicionAprobLicArmaMenor': $('#txtCondicionAprov').val(),
//                            'FechaOtorgamientoLicArmaMenor': $('#txtFechaO').val(),
//                            'NroLicenciaArmaMenor': $('#txtNlicencia').val(),
//                            'year': $('#txtyear').val(),
//                            'mes': $('#txtMes').val(),
//                            'dia': $('#txtDia').val()
//                        },
//                        beforeSend: function () {
//                            $('#loader-6').show();
//                        },
//                        success: function (mensaje) {
//                            if (mensaje == "1") {
//                                $('#alertsuccess').show();
//                                $('#mensajesuccess').text("Se registro la Licencia Arma Menor Militar");
//                                $('#alertsuccess').hide(5000);
//                            } else {
//                                $('#alerterror').show();
//                                $('#mensajeerror').text(mensaje);
//                                $('#alerterror').hide(5000);
//                            }
//                            $('#listar').show();
//                            $('#nuevo').hide();
//                            $('#tblDialiLicArmasMenoresMilitar').DataTable().ajax.reload();
//                        },
//                        complete: function () {
//                            $('#loader-6').hide();
//                        }
//                    });
//                }
//                form.classList.add('was-validated')
//            }, false)
//        })

//    var forms = document.querySelectorAll('.form-actualizacion')
//    Array.prototype.slice.call(forms)
//        .forEach(function (form) {
//            form.addEventListener('submit', function (event) {
//                if (!form.checkValidity()) {
//                    event.preventDefault()
//                    event.stopPropagation()
//                } else {
//                    event.preventDefault();
//                    $.ajax({
//                        type: "POST",
//                        url: '/DialiLicArmasMenoresMilitar/Actualizar',
//                        data: {
//                            'Id': $('#txtCodigo').val(),
//                            'CodigoDocumentoArmaMenor': $('#txtCodigoDe').val(),
//                            'SolDocumentoArmaMenor': $('#txtSolicitude').val(),
//                            'FechaSolicitudLicArmaMenor': $('#txtFechaSe').val(),
//                            'TramiteArmaMenorId': $('#txtTramiteAe').val(),
//                            'SituacionPersonalSolId': $('#txtSituacionPe').val(),
//                            'CondicionAprobLicArmaMenor': $('#txtCondicionAprove').val(),
//                            'FechaOtorgamientoLicArmaMenor': $('#txtFechaOe').val(),
//                            'NroLicenciaArmaMenor': $('#txtNlicenciae').val(),
//                        },
//                        beforeSend: function () {
//                            $('#loader-6').show();
//                        },
//                        success: function (mensaje) {
//                            if (mensaje == "1") {
//                                $('#alertsuccess').show();
//                                $('#mensajesuccess').text("Se actualizo la Licencia Arma Menor Militar");
//                                $('#alertsuccess').hide(5000);
//                            } else {
//                                $('#alerterror').show();
//                                $('#mensajeerror').text(mensaje);
//                                $('#alerterror').hide(5000);
//                            }
//                            $('#listar').show();
//                            $('#editar').hide();
//                            $('#tblDialiLicArmasMenoresMilitar').DataTable().ajax.reload();
//                        },
//                        complete: function () {
//                            $('#loader-6').hide();
//                        }
//                    });
//                }
//                form.classList.add('was-validated')
//            }, false)
//        })

//    $('#tblDialiLicArmasMenoresMilitar').DataTable({
//        ajax: {
//            "url": '/DialiLicArmasMenoresMilitar/CargaTabla',
//            "type": "GET",
//            "datatype": "json"
//        },
//        "columns": [
//            { "data": "licenciaArmaMenorId" },
//            { "data": "codigoDocumentoArmaMenor" },
//            { "data": "solDocumentoArmaMenor" },
//            { "data": "fechaSolicitudLicArmaMenor" },
//            { "data": "tramiteArmaMenorId" },
//            { "data": "situacionPersonalSolId" },
//            { "data": "condicionAprobLicArmaMenor" },
//            { "data": "fechaOtorgamientoLicArmaMenor" },
//            { "data": "nroLicenciaArmaMenor" },  
//            {
//                "render": function (data, type, row) {
//                    return '<a class="txt" onclick=edit(' + row.licenciaArmaMenorId + ') title="Actualizar"><i class="fa fa-check-square-o" aria-hidden="true" style="color:black; padding-right:5px"></i>Editar</a>';
//                }
//            },
//            {
//                "render": function (data, type, row) {
//                    return '<a class="txt btnconfirmation" onclick=eliminar(' + row.licenciaArmaMenorId + ') title="Eliminar"><i class="fa fa-minus-square-o red" aria-hidden="true" style="color:red; padding-right:5px"></i>Eliminar</a>';
//                }
//            }
//        ],
//        language: {
//            url: "https://cdn.datatables.net/plug-ins/1.11.5/i18n/es-ES.json"
//        },
//        columnDefs: [
//            {
//                "targets": "_all",
//                "className": "text-center",
//            },
//            {
//                "targets": "[7,8]",
//                "width": "180px",
//            }
//        ]
//    });

//});

//function edit(Id) {
//    $('#listar').hide();
//    $('#editar').show();
//    $.getJSON('/DialiLicArmasMenoresMilitar/Mostrar?Id=' + Id , [], function (LicenciaArmasMenoresMilitarDTO) {
//        $('#txtCodigo').val(LicenciaArmasMenoresMilitarDTO.licenciaArmaMenorId);
//        $('#txtCodigoDe').val(LicenciaArmasMenoresMilitarDTO.codigoDocumentoArmaMenor);
//        $('#txtSolicitude').val(LicenciaArmasMenoresMilitarDTO.solDocumentoArmaMenor);
//        $('#txtFechaSe').val(LicenciaArmasMenoresMilitarDTO.fechaSolicitudLicArmaMenor);
//        $('#txtTramiteAe').val(LicenciaArmasMenoresMilitarDTO.tramiteArmaMenorId);
//        $('#txtSituacionPe').val(LicenciaArmasMenoresMilitarDTO.situacionPersonalSolId);
//        $('#txtCondicionAprove').val(LicenciaArmasMenoresMilitarDTO.condicionAprobLicArmaMenor);
//        $('#txtFechaOe').val(LicenciaArmasMenoresMilitarDTO.fechaOtorgamientoLicArmaMenor);
//        $('#txtNlicenciae').val(LicenciaArmasMenoresMilitarDTO.nroLicenciaArmaMenor);
//    });
//}

//function eliminar(id) {
//    licenciaArmasMenoresMilitarId = id;
//    $("#mi-modal").modal('show');
//}

//function nuevaDialiLicArmasMenoresMilitar() {
//    $('#listar').hide();
//    $('#nuevo').show();
//}
///*
//function cargaDatos() {
//    $.getJSON('/ActividadCultural/CargarCombo', [], function (Json) {
//        var TipoTema = Json["data1"];
//        //Foreach
//        //$().append(ddd);
//        //append(22);
//    });0
//}
//*/
