using Sistema.DAL;
using System;
using Sistema.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.BLL
{
    public class BLL_Clientes
    {
        DAL_Clientes dalClientes = new DAL_Clientes();

        public String CadastroPF(Clientes ClientePF)
        {

            var retorno = dalClientes.CadastroPF(ClientePF);

            return retorno;
        }

        public String CadastroPJ(Clientes ClientePJ)
        {

            var retorno = dalClientes.CadastroPJ(ClientePJ);

            return retorno;
        }

        public List<Clientes> ObterListaClientes()
        {

            var retorno = dalClientes.ObterListaClientes();

            return retorno;
        }


        public List<Clientes> ExcluirCliente(FlagCliente InativadorCliente)
        {

            var retorno = dalClientes.ExcluirCliente(InativadorCliente);

            return retorno;
        }
    }
}

