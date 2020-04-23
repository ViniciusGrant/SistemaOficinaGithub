$(document).ready(function () {

    path = $(location).attr('pathname');

    if (path == '/Servicos/Servicos') {

        ObterClientesCadastrados();



    }

});


function ObterClientesCadastrados() {

    requisicaoAssincrona("POST", "../Servicos/ObterClientesCadastrados", "", resultClientesCadastrados, erroClientesCadastrados);

};
function resultClientesCadastrados(Json) {

    var objretClientesCadastrados = JSON.parse(Json.listaClientesCadastrados);
    var selectCliente = '<option value=""> SELECIONE... </option>' + " ";

    $.each(objretClientesCadastrados, function (i, obj) {

        selectCliente = selectCliente +

            '<option value="' + obj.idCliente + '">' + obj.nome + '</option>'

    });

    $("#drw-selectCliente").append(selectCliente);
};
function erroClientesCadastrados(Json) {

};



