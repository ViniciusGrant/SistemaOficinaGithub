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
    public class ServicosController : Controller
    {
        BLL_Servicos bllservicos = new BLL_Servicos();
        // GET: Servicos
        public ActionResult Servicos()
        {
            return View();
        }
        public ActionResult ServicosConsulta()
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


        [HttpPost]
        public ActionResult ObterDadosClienteSel(Clientes IdCliente)
        {
            var listaClientesCadastrados = bllservicos.ObterDadosClienteSel(IdCliente);

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonlistaClientesCadastrados = jsonSerialiser.Serialize(listaClientesCadastrados);
            return Json(new
            {

                listaClientesCadastrados = jsonlistaClientesCadastrados
            });

        }

        [HttpPost]
        public ActionResult GravarServico(Servico Pedido)
        {
            var CadastroServico = bllservicos.GravarServico(Pedido);

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonCadastroServico = jsonSerialiser.Serialize(CadastroServico);
            return Json(new
            {

                CadastroServico = jsonCadastroServico
            });

        }

        [HttpPost]
        public ActionResult ConsultaServicos(Servico flagServico)
        {
            var ConsultaServico = bllservicos.ConsultaServicos(flagServico);

            var jsonSerialiser = new JavaScriptSerializer();
            var jsonConsultaServico = jsonSerialiser.Serialize(ConsultaServico);
            return Json(new
            {

                CadastroServico = jsonConsultaServico
            });

        }
    }
}