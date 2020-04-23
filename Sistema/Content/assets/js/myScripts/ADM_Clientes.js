$(document).ready(function () {

    path = $(location).attr('pathname');

    if (path == '/Clientes/Clientes') {


        Botoes();
        GravarClientePF();
        GravarClientePJ();


    }

});




function Botoes() {
    $("#btn-CadastroCliente").on("click", function () {
        $("#divCadastroClientes").show('slow');
    });

    $("#btn-ConsultarClientes").on("click", function () {
        ObterListaClientes();
        $("#divbtn-ExcluirClientes").hide();

    });

    $("#btn-ExcluirClientes").on("click", function () {
        ObterClientesParaInativacao();
        $("#divbtn-ExcluirClientes").show();
       
    });

    
    $("#btn_pessoaFisica").on("click", function () {
        $("#divPessoaFisica").show('slow');
    });

    $("#btn_pessoajuridica").on("click", function () {
  
        $("#divPessoaJuridica").show('slow');
    });

    $("#fecharTabelaClientes").on("click", function () {
        $("#divTabelaClientes").hide('slow');
    });
    $("#btn-FecharTblClientes").on("click", function () {
        $("#divTabelaClientes").hide('slow');
    });

    $("#fechardivPessoaJuridica").on("click", function () {
        $("#divPessoaJuridica").hide('slow');
    });

    $("#fechardivPessoaFisica").on("click", function () {
        $("#divPessoaFisica").hide('slow');
    });

    $("#fechardivCadastroClientes").on("click", function () {
        $("#divCadastroClientes").hide('slow');
    });







    $('#btn-ExcluirClientesSelec').on('click', function () {
        var FlagInativacaoCliente = 0
        var ClienteSelecionado = []



        $("input[type=checkbox][name='selectCliente[]']:checked").each(function () {

            ClienteSelecionado.push($(this).closest('tr').find('td').eq(1).text())


        })

        if (ClienteSelecionado[0] != null) {

            var InativadorCliente = {

                IdCliente: ClienteSelecionado,
                NovaSitCliente: FlagInativacaoCliente,

            }

                        requisicaoAssincrona("POST", "../Clientes/ExcluirCliente", InativadorCliente, successExcluirClientes, erroExcluirClientes);
     
        }


    })
    
};

function LimparCampos() {

    $("#txt-nomePF").val("");
    $("#txt-CPF").val("");
    $("#txt-celPF").val("");
    $("#txt-telPF").val("");
    $("#txt-cmlPF").val("");
    $("#txt-ruaPF").val("");
    $("#txt-nPF").val("");
    $("#txt-bairro").val("");
    $("#txt-cidade").val("");
    $("#sel-ufPF").val("SELECIONE..");
    $("#txt-razaoSocial").val("")
    $("#txt-nomeFantasia").val("")
    $("#txt-CNPJ").val("");
    $("#txt-celPJ").val("");
    $("#txt-telPJ").val("");
    $("#txt-cmlPJ").val("");
    $("#txt-ruaPJ").val("");
    $("#txt-nPJ").val("");
    $("#txt-bairroPJ").val("");
    $("#txt-cidadePJ").val("");
    $("#sel-ufPJ").val("SELECIONE..");
};


function GravarClientePF() {

    $("#btn-cadastrarPF").on("click", function () {

        var idtipoCliente = 1
        var flagCliente = 1

        var nome = $("#txt-nomePF").val().toUpperCase();
        var cpf = $("#txt-CPF").val();
        var celular = $("#txt-celPF").val();
        var telefone = $("#txt-telPF").val();
        var telcomercial = $("#txt-cmlPF").val();
        var ruaPF = $("#txt-ruaPF").val().toUpperCase();
        var numPF = $("#txt-nPF").val();
        var bairroPF = $("#txt-bairro").val().toUpperCase();
        var cidadePF = $("#txt-cidade").val().toUpperCase();
        var ufPF = $("#sel-ufPF").val().toUpperCase();


        var ClientePF = {

            ID_tipocliente: idtipoCliente,
            Flag_cliente: flagCliente,
            Nome_pessoa: nome,
            CPF_pessoa: cpf,
            Cel_cliente: celular,
            Tel_cliente: telefone,
            TelComercial_cliente: telcomercial,
            Rua: ruaPF,
            Numero: numPF,
            Bairro: bairroPF,
            Cidade: cidadePF,
            UF: ufPF


        }
        requisicaoAssincrona("POST", "../Clientes/GravarClientePF", ClientePF, salvaClientePF, erroClientePF);

    })

};

function salvaClientePF(Json) {
    let objClientePF = JSON.parse(Json.mensagem);
    if (objClientePF == "1") {



        swal({
            title: "Cadastrado com sucesso!",
            text: "Deseja realizar outro cadastro?",
            icon: "success",
            buttons: true,
            buttons: ["Não", "Sim"],
            dangerMode: false,
        })
            .then((Cancelar) => {
                if (Cancelar) {

                    LimparCampos()

                }
                else {
                    LimparCampos()
                    $("#divPessoaFisica").hide(1000);

                }

            });
    }
};

function erroClientePF(Json) {
    swal({
        title: "ERRO!",
        text: "Não foi possível realizar o cadastro. Tente Novamente",
        icon: "error",
    });
};


function GravarClientePJ() {


    $("#btn-cadastrarPJ").on("click", function () {
        alert('CHEGOU');
        var idtipoCliente = 2
        var flagCliente = 1

        var razaosocial = $("#txt-razaoSocial").val().toUpperCase();
        var nomefant = $("#txt-nomeFantasia").val().toUpperCase();
        var cnpj = $("#txt-CNPJ").val();
        var celularPj = $("#txt-celPJ").val();
        var telefonePj = $("#txt-telPJ").val();
        var telcomercialPj = $("#txt-cmlPJ").val();
        var ruaPj = $("#txt-ruaPJ").val().toUpperCase();
        var numPj = $("#txt-nPJ").val();
        var bairroPj = $("#txt-bairroPJ").val().toUpperCase();
        var cidadePj = $("#txt-cidadePJ").val().toUpperCase();
        var ufPj = $("#sel-ufPJ").val();


        var ClientePJ = {

            ID_tipocliente: idtipoCliente,
            Flag_cliente: flagCliente,
            RazaoSocial: razaosocial,
            NomeFantasia: nomefant,
            CNPJ: cnpj,
            Cel_cliente: celularPj,
            Tel_cliente: telefonePj,
            TelComercial_cliente: telcomercialPj,
            Rua: ruaPj,
            Numero: numPj,
            Bairro: bairroPj,
            Cidade: cidadePj,
            UF: ufPj


        }

        requisicaoAssincrona("POST", "../Clientes/GravarClientePJ", ClientePJ, salvaClientePJ, erroClientePJ);

    })

};

function salvaClientePJ(Json) {
    let objClientePJ = JSON.parse(Json.mensagem);
    if (objClientePJ == "1") {



        swal({
            title: "Cadastrado com sucesso!",
            text: "Deseja realizar outro cadastro?",
            icon: "success",
            buttons: true,
            buttons: ["Não", "Sim"],
            dangerMode: false,
        })
            .then((Cancelar) => {
                if (Cancelar) {

                    LimparCampos()

                }
                else {
                    LimparCampos()
                    $("#divPessoaJuridica").hide(1000);

                }

            });
    }
};

function erroClientePJ(Json) {
    swal({
        title: "ERRO!",
        text: "Não foi possível realizar o cadastro. Tente Novamente",
        icon: "error",
    });
};


function ObterListaClientes() {

    requisicaoAssincrona("POST", "../Clientes/ObterListaClientes", "", successListaClientes, erroListaClientes);

};

function successListaClientes(Json) {


    var objListaClientes = JSON.parse(Json.ListaClientes);
    //var crtBtnCrud = []
    var conteudotblClientes = '';
    var cabecalhotblClientes = '';
    var iteracaoAtiv = '';

    $("#headTblclientes").html("");
    cabecalhotblClientes = '<tr  > ' +

       
        '<th>Id Cliente</th>' +
        '<th>Nome</th>' +
        '<th>Cpf / Cnpj</th>' +
        '<th>Celular</th>' +
        '<th>Telefone</th>' +
        '<th>Telefone comercial</th>' +

        '</tr > ';
        $("#headTblclientes").append(cabecalhotblClientes);

    var tblRegistroClientes = $(".datatable-clientes").dataTable();

    tblRegistroClientes.fnClearTable(this);

    $.each(objListaClientes, function (i, obj) {

        conteudotblClientes = conteudotblClientes +

        '<tr>' +

           
            '<td>' + obj.ID_Cliente + '</td>' +
            '<td>' + obj.RazaoSocial + '</td>' +
            '<td>' + obj.CPF_pessoa + '</td>' +
            '<td>' + obj.Cel_cliente + '</td>' +
            '<td>' + obj.Tel_cliente + '</td>' +
            '<td>' + obj.TelComercial_cliente + '</td>' +

            '</tr>';
    });

    var inserirBtnTbl = [BtnTblCtrlColunas()]

    tblRegistroClientes.fnDestroy();
    $("#bodyTblclientes").append(conteudotblClientes);
    ConfigTbl(tblRegistroClientes, inserirBtnTbl);


    $("#divTabelaClientes").show(1000);
    

};




function erroListaClientes(Json) {

};



function ObterClientesParaInativacao() {

    requisicaoAssincrona("POST", "../Clientes/ObterListaClientes", "", successObterClientesParaInativacao, erroObterClientesParaInativacao);

};

function successObterClientesParaInativacao(Json) {


    var objListaClientes = JSON.parse(Json.ListaClientes);
    //var crtBtnCrud = []
    var conteudotblClientes = '';
    var cabecalhotblClientes = '';
    var iteracaoAtiv = '';

    $("#headTblclientes").html("");
    cabecalhotblClientes = '<tr  > ' +

        '<th>Seletor</th>' +
        '<th>Id Cliente</th>' +
        '<th>Nome</th>' +
        '<th>Cpf / Cnpj</th>' +
        '<th>Celular</th>' +
        '<th>Telefone</th>' +
        '<th>Telefone comercial</th>' +

        '</tr > ';
    $("#headTblclientes").append(cabecalhotblClientes);

    var tblRegistroClientes = $(".datatable-clientes").dataTable();

    tblRegistroClientes.fnClearTable(this);

    $.each(objListaClientes, function (i, obj) {

        conteudotblClientes = conteudotblClientes +

            '<tr>' +

            '<td><input type="checkbox" class="switchery" name="selectCliente[]"/></td>' +
            '<td>' + obj.ID_Cliente + '</td>' +
            '<td>' + obj.RazaoSocial + '</td>' +
            '<td>' + obj.CPF_pessoa + '</td>' +
            '<td>' + obj.Cel_cliente + '</td>' +
            '<td>' + obj.Tel_cliente + '</td>' +
            '<td>' + obj.TelComercial_cliente + '</td>' +

            '</tr>';
    });

    var inserirBtnTbl = [BtnTblCtrlColunas()]

    tblRegistroClientes.fnDestroy();
    $("#bodyTblclientes").append(conteudotblClientes);
    ConfigTbl(tblRegistroClientes, inserirBtnTbl);


    $("#divTabelaClientes").show(1000);


};

function erroObterClientesParaInativacao(Json) {

};

function successExcluirClientes(Json) {
    alert("Cliente excluido com sucesso!");
    successObterClientesParaInativacao(Json)
};

function erroExcluirClientes(Json) {

};
