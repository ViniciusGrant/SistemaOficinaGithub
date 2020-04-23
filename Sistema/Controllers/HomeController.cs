using Sistema.BLL;
using Sistema.Models;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sistema.Controllers
{
    public class HomeController : Controller
    {
        BLL_Login bllLogin = new BLL_Login();

        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ConsultarLogin(USUARIO usuario)
        {

            if (usuario.CPF_usuario != null && usuario.Senha_usuario != null)
            {
                var retorno = bllLogin.ConsultarLogin(usuario);
                USUARIO usrLogado = new USUARIO();

                usrLogado = retorno;
                Session["usuario"] = usrLogado;

                var jsonSerialiser = new JavaScriptSerializer();
                var jsonLogin = jsonSerialiser.Serialize(retorno);
                return Json(new
                {
                    usuarioLogado = jsonLogin
                });
            }
            return null;
        }




    }
}