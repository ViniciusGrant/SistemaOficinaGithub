using Sistema.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.BLL
{
    public class BLL_Servicos
    {
        DAL_Servicos dalServicos = new DAL_Servicos();


        public List<Object> ObterClientesCadastrados()
        {
            var retorno = dalServicos.ObterClientesCadastrados();
            return retorno;
        }


    }
}