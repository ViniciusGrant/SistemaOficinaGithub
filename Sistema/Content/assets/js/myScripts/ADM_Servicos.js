$(document).ready(function () {

    path = $(location).attr('pathname');

    if (path == '/Servicos/Servicos') {

        ListaServiçosEmAberto();
        ObterClientesCadastrados();
        botoes();

    }

});


function ListaServiçosEmAberto() {
    var retorno = capturarRetornoDeReqSinc('POST', 'ConsultaServicos', '', erroServicosCadastrados);
    var objretServico = JSON.parse(retorno.CadastroServico);

    //var crtBtnCrud = []
    var conteudotblServico = '';
    var cabecalhotblServico = '';

    $("#headTblservico").html("");
    cabecalhotblServico = '<tr  > ' +


        '<th hidden="hidden">Id Servico</th>' +
        '<th>Nome</th>' +
        '<th>Cpf / Cnpj</th>' +
        '<th>Valor do Serviço</th>' +
        '<th>Tipo de Pagamento</th>' +
        '<th>Descrição </th>' +
        '<th hidden="hidden">Flag</th>' +


        '</tr > ';
    $("#headTblservico").append(cabecalhotblServico);

    var tblRegistroServico = $(".datatable-servico").dataTable();

    tblRegistroServico.fnClearTable(this);

    $.each(objretServico, function (i, obj) {
        var pagamento;
        if (obj.PagamentoTipo == "False") {
            pagamento = 'Á vista';
        } else {
            pagamento = 'A prazo'
        }

        conteudotblServico = conteudotblServico +

            '<tr>' +


            '<td hidden="hidden">' + obj.IdServico + '</td>' +
            '<td>' + obj.Nome + '</td>' +
            '<td>' + obj.IdentifCliente + '</td>' +
            '<td>' + "R$ " + obj.ValorServico + '</td>' +
            '<td>' + pagamento + '</td>' +
            '<td style="min-width: 400px !important">' + obj.DescricaoServico + '</td>' +
            '<td hidden="hidden">' + obj.flagServico + '</td>' +


            '</tr>';
    });

    tblRegistroServico.fnDestroy();
    $("#bodyTblservico").append(conteudotblServico);
    ConfigTbl(tblRegistroServico);


};





function botoes() {

    $(document).on('change', '#drw-selectCliente', function (e) {
        var Cliente = $('#drw-selectCliente').val();
        gerarServiçoComCliente(Cliente)

    });

    $("#btn-cadastrarServico").unbind("click").click(function () {
        alert();
        gerarServiçoSemCliente();

    });

    $("#btn-cadastrarClienteServico").unbind("click").click(function () {
        window.location.href = "../Clientes/Clientes"
    }); 

}






function ObterClientesCadastrados() {
    //requisicaoAssincrona("POST", "../Servicos/ObterClientesCadastrados", "", resultClientesCadastrados, erroClientesCadastrados);
    var retorno = capturarRetornoDeReqSinc('POST', 'ObterClientesCadastrados', '', erroClientesCadastrados);
    
    var objretClientesCadastrados = JSON.parse(retorno.listaClientesCadastrados);
    $("#drw-selectCliente").empty();
    var selectCliente = '<option value=""> SELECIONE... </option>' + " ";

    $.each(objretClientesCadastrados, function (i, obj) {

        selectCliente = selectCliente +

            '<option value="' + obj.ID_Cliente + '">' + obj.Nome_pessoa + '</option>'

    });

    $("#drw-selectCliente").append(selectCliente);

};





function gerarServiçoComCliente(Cliente) {

    var IdCliente = {
        ID_Cliente: Cliente
    }
    $("#painelSelCliente").hide('slow');
    $("#painelCadastrarService").show('slow');

    var retorno = capturarRetornoDeReqSinc('POST', 'ObterDadosClienteSel', IdCliente, erroClientesCadastrados);
    var objretDadosCliente = JSON.parse(retorno.listaClientesCadastrados);

    $.each(objretDadosCliente, function (i, obj) {


        $("#txt-nomeService").val(obj.Nome_pessoa);
        $("#txt-DocService").val(obj.CPF_pessoa);

    });

    $("#btn-cadastrarService").unbind("click").click(function () {


        var Servico = {
            IdentifCliente: parseInt($("#txt-DocService").val()),
            Nome: $("#txt-nomeService").val().toUpperCase(),
            IdCliente: Cliente,
            ValorServico: $("#txt-ValorServiço").val(),
            PagamentoTipo: $("#drw-tipoPagamento").val(),
            teste: parseInt($("#txt-DocService").val()),
            DescricaoServico: $("#DescricaoServico").val()
        }

        var retorno = capturarRetornoDeReqSinc('POST', 'GravarServico', Servico, erroCCadastrarServico);
        var objretCadastroServico = JSON.parse(retorno.CadastroServico);

        if (objretCadastroServico == '1') {
            limpaCamposervico()
            ObterClientesCadastrados()
            ListaServiçosEmAberto()
            $("#painelSelCliente").show('slow');
            $("#painelCadastrarService").hide('slow');
            alert("sucesso");

        } else {
            alert("erro")
        }

    })

}


function gerarServiçoSemCliente() {
    

    $("#painelSelCliente").hide('slow');
    $("#painelCadastrarService").show('slow');
    $("#dadosCliente").hide('fast');


    $("#btn-cadastrarService").unbind("click").click(function () {


        var Servico = {
            IdentifCliente: '',
            Nome: '',
            IdCliente: '',
            ValorServico: $("#txt-ValorServiço").val(),
            PagamentoTipo: $("#drw-tipoPagamento").val(),
            teste: $("#txt-DocService").val(),
            DescricaoServico: $("#DescricaoServico").val()
        }

        var retorno = capturarRetornoDeReqSinc('POST', 'GravarServico', Servico, erroCCadastrarServico);
        var objretCadastroServico = JSON.parse(retorno.CadastroServico);

        if (objretCadastroServico == '1') {
            limpaCamposervico()
            ListaServiçosEmAberto()
            $("#painelSelCliente").show('slow');
            $("#painelCadastrarService").hide('slow');
            alert("sucesso");

        } else {
            alert("erro")
        }

    })
}



function erroCCadastrarServico() {

};

function limpaCamposervico() {

    $("#txt-DocService").val("");
    $("#txt-nomeService").val("");
    $("#txt-ValorServiço").val('')
    $("#drw-tipoPagamento").val('')
    $("#txt-DocService").val('')
    $("#DescricaoServico").val('')


}



function erroClientesCadastrados(Json) {

};
function erroServicosCadastrados(Json) {

};