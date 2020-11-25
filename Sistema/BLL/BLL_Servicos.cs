using Sistema.DAL;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.BLL
{
    public class BLL_Servicos
    {
        DAL_Servicos dalServicos = new DAL_Servicos();


        public List<Clientes> ObterClientesCadastrados()
        {
            var retorno = dalServicos.ObterClientesCadastrados();
            return retorno;
        }

        public List<Clientes> ObterDadosClienteSel(Clientes IdCliente)
        {
            var retorno = dalServicos.ObterDadosClienteSel(IdCliente);
            return retorno;
        }

        public string GravarServico(Servico Pedido)
        {

            var retorno = dalServicos.GravarServico(Pedido);
            return retorno;
        }

        public List<Servico> ConsultaServicos(Servico flagServico)
        {

            var retorno = dalServicos.ConsultaServicos(flagServico);
            return retorno;
        }
    }
}



