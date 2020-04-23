using Sistema.DAL;
using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.BLL
{
    public class BLL_Login
    {
        DAL_Login dalLogin = new DAL_Login();
        public USUARIO ConsultarLogin(USUARIO usuario)
        {
            var retorno = dalLogin.ConsultarLogin(usuario);
            return retorno;
        }

    }
}