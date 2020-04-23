using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Sistema.Controllers
{
    public class UsuariosController : Controller
    {
        // GET: Usuarios
        public ActionResult Usuarios()
        {
            ViewBag.UserLogado = Session["usuario"];

            DateTime DiaAtual = DateTime.Now;
            string Dia = DiaAtual.ToLongDateString();
            ViewBag.Dia = Dia;
            return View();
        }
    }
}