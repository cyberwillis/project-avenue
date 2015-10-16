﻿/*
Metodo responsavel por criar um numero de incremento para impedir links em cache
*/
function gettick() {
    return (new Date()).getTime();
}

/*
Metodo responsavel por abrir formulario de Modal e carregar o conteudo para inclusao ou alteracao
*/
function ajaxModalFormOpenHandler(obj) {

    var $button = obj;
    $($button).off('click'); //remover o comportamento para novo carregamento

    var $url = $button.getAttribute('data-url') + '?t=' + gettick();
    var $updateContent = $('#myModal');
    var $urlAfter = $button.getAttribute('data-url-content-update') + '?t=' + gettick();
    var $updateContentNext = $($button.getAttribute('data-content-update-id'));

    $updateContent.modal({ keyboard: false, backdrop: 'static' })
        .on('shown.bs.modal', function () {

            var options = {
                url: $url,
                type: "get"
            };

            $.ajax(options).done(function (data) {
                $updateContent.html(data);
            });

            $updateContent.off('shown');

        })
        .on('hidden.bs.modal', function () {

            var options = {
                url: $urlAfter,
                type: "get"
            };

            $.ajax(options).done(function (data) {
                $updateContentNext.html(data);
            });

            var loading = '<div class="modal-dialog"><div class="modal-content"><div class="modal-header"><button type="button" class="close" data-dismiss="modal"><span aria-hidden="true">&times;</span><span class="sr-only">Close</span></button><h4 id="myModalLabel" class="modal-title">&nbsp;</h4></div><div id="myModalBody" class="modal-body"><div id="conteudo-modal"></div><div id="barra" class="progress progress-striped active"><div class="progress-bar" style="width: 100%;"></div></div></div><div class="modal-footer form-horizontal"><button type="button" class="btn btn-default btn-sm" data-dismiss="modal" aria-hidden="true">Cancelar</button></div></div></div>';
            $updateContent.html(loading);
            //$updateContent.off('hidden');
            //$($button).on("click", ajaxModalFormOpenHandler);
        });
}

function ajaxUpdateContent(obj) {

    var $button = obj;

    var $urlAfter = $button.getAttribute('data-url-content-update') + '?t=' + gettick();
    var $updateContentNext = $($button.getAttribute('data-content-update-id'));

    var options = {
        url: $urlAfter,
        type: "get"
    };

    $.ajax(options).done(function (data) {
        $updateContentNext.html(data);
    });
}

/*
Metodo responsavel por fazer o submit do formulario de inclusao ou alteracao
*/
function ajaxFormSubmit(targetAfterClose) {
    //alert();
    var $form = $('#form0');

    var options = {
        url: $form.attr("action"),
        type: $form.attr("method"),
        data: $form.serialize()
    };

    $.ajax(options).done(function (data) {
        var $target = $($form.attr("data-ajax-update"));
        $target.html(data);


    });
};