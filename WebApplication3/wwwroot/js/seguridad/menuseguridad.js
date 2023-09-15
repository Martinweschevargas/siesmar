'use strict';

$(document).ready(function () {
    crearMenuSeguridad();
});

function crearMenuSeguridad() {
    $.getJSON('/Home/cargarMenuSeguridad', [], function (lst) {
        var contentMenu = '<li>' +
            '<label for="folder1">Seguridad</label><input type="checkbox" checked id="folder1" />' +
            '<ol>';
        $.each(lst, function () {
            contentMenu += '<li class="file"><a href="' + this.menu + '">' + this.nombreFormatoReporte + '</a></li>';
        });
        contentMenu += '</ol></li>';
        $('#menumgp').append(contentMenu);
    });
}