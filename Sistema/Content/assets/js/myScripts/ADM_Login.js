$(document).ready(function () {

    Entrar();
    deromanize();

});




function Entrar() {

    $("#btnEntrarLogin").on("click", function () {


        let login = $("#txtUser").val();

        let senha = $("#txtSenha").val();


        let usuario = {

            CPF_usuario: login,
            Senha_usuario: senha
        }
        requisicaoAssincrona("POST", "../Home/ConsultarLogin", usuario, sucessoConsulta, erroConsulta);


    });

};


function sucessoConsulta(Json) {
    var objUsuario = JSON.parse(Json.usuarioLogado);

    if (objUsuario != null) {
        window.location.href = "../Inicial/Inicio";
    }
    else {
        (objUsuario == null)

        swal({
            icon: "error",
            tittle: "ERRO!",
            text: "Erro de usuário ou seha"
        })
        window.location.href = "../Home/Index";

    }

};


function erroConsulta(Json) {

    swal({
        icon: "error",
        title: 'ERRO!',
        text: 'Erro de usuário e senha',

    })

};

