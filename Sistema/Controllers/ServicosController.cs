using Sistema.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sistema.Controllers
{
    public class ServicosController : Controller
    {
        BLL_Servicos bllservicos = new BLL_Servicos();
        // GET: Servicos
        public ActionResult Servicos()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ObterClientesCadastrados()
        {
            var listaClientesCadastrados = bllservicos.ObterClientesCadastrados();

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonlistaClientesCadastrados = jsonSerialiser.Serialize(listaClientesCadastrados);
            return Json(new
            {

                listaClientesCadastrados = jsonlistaClientesCadastrados
            });

        }
    }
}