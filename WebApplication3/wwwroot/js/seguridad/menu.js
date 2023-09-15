'use strict';

$(document).ready(function () {
    crearMenu();
});

function crearMenu() {
    var contentMenu = "";
    $.getJSON('/Home/getDependencias', [], function (Grupos) {
        var Subordinado = "";
        var Periodo = "";
        contentMenu += '<li>' +
            '<label for="folder1">Jemgemar</label> <input type="checkbox" checked id="folder1" />' +
            '<ol>';
        $.each(Grupos, function (key, value) {
            Subordinado = key;
            var lst = this;
            contentMenu += '<li>' +
                '<label for="subfolder1">' + key + '</label><input type="checkbox" id="subfolder1" />' +
                '<ol>';
            var lstLast = this;
            var periodo3 = "";
            $.each(lstLast, function () {
                var periodo4 = this.nombrePeriodo;
                if (this.nombrePeriodo != periodo3 && this.dependencia.trim() == key.trim()) {
                    contentMenu += '<li>' +
                        '<label for="subsubfolder2">' + this.nombrePeriodo.trim() + '</label> <input type="checkbox" id="subsubfolder2"/>' +
                        '<ol>';
                    $.each(lstLast, function () {
                        if (this.dependencia.trim() == key.trim() && this.nombrePeriodo == periodo4) {
                            contentMenu += '<li class="file"><a href="' + this.menu + '">' + this.nombreFormatoReporte + '</a></li>';
                        }
                    });
                    contentMenu += '</ol>';
                }
                periodo3 = this.nombrePeriodo;
            });
            $.each(lst, function () {
                var periodo3 = ""; 
                lstLast = lst;
                if (this.dependencia != Subordinado) {
                    var SubordinadaDependencia=this.dependencia;
                    contentMenu += '<li>' +
                        '<label for="subsubfolder1">' + this.dependencia + '</label> <input type="checkbox" id="subsubfolder1" />' +
                        '<ol>';
                                
                    $.each(lstLast, function () {
                        var periodo4 = this.nombrePeriodo;
                        if (this.nombrePeriodo != periodo3 && this.dependencia == SubordinadaDependencia) {
                            contentMenu += '<li>' +
                                '<label for="subsubfolder2">' + this.nombrePeriodo.trim() + '</label> <input type="checkbox" id="subsubfolder2"/>' +
                                '<ol>';
                            $.each(lstLast, function () {
                                if (this.dependencia == SubordinadaDependencia && this.nombrePeriodo == periodo4) {
                                    contentMenu += '<li class="file"><a href="' + this.menu + '">' + this.nombreFormatoReporte + '</a></li>';
                                }
                            });
                            contentMenu += '</ol>';
                            periodo3 = this.nombrePeriodo;
                        }
                    });
                    
                    contentMenu += '</ol></li>';                
                }
                contentMenu += '</li>';
                Subordinado = this.dependencia;
            });
            contentMenu += '</ol></li>';
        });
        contentMenu += '</ol></li>';
        $('#menumgp').append(contentMenu);
    });
}