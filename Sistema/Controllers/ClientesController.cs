using Sistema.BLL;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace Sistema.Controllers
{

    public class ClientesController : Controller
    {
        BLL_Clientes bllClientes = new BLL_Clientes();

        // GET: Clientes
        public ActionResult Clientes()
        {
            ViewBag.UserLogado = Session["usuario"];

            DateTime DiaAtual = DateTime.Now;
            string Dia = DiaAtual.ToLongDateString();
            ViewBag.Dia = Dia;
            return View();
        }



        [HttpPost]
        public ActionResult GravarClientePF(Clientes ClientePF)
        {

            var retorno = bllClientes.CadastroPF(ClientePF);

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonCad = jsonSerialiser.Serialize(retorno);
            return Json(new
            {
                mensagem = jsonCad
            });



        }

        [HttpPost]
        public ActionResult GravarClientePJ(Clientes ClientePJ)
        {

            var retorno = bllClientes.CadastroPJ(ClientePJ);

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonCad = jsonSerialiser.Serialize(retorno);
            return Json(new
            {
                mensagem = jsonCad
            });



        }


        [HttpPost]
        public ActionResult ObterListaClientes()
        {

            var retorno = bllClientes.ObterListaClientes();

            var jsonSerializer = new JavaScriptSerializer();
            var jsonListaClientes = jsonSerializer.Serialize(retorno);

            return Json(new
            {
                ListaClientes = jsonListaClientes

            });
        }


        [HttpPost]
        public ActionResult ExcluirCliente(FlagCliente InativadorCliente)
        {
            var listaClientesAtualizada = bllClientes.ExcluirCliente(InativadorCliente);


            var jsonSerialiser = new JavaScriptSerializer();
            var jsonListaClientes = jsonSerialiser.Serialize(listaClientesAtualizada);
            return Json(new
            {

                ListaClientes = jsonListaClientes
            });

        }

    }
}

