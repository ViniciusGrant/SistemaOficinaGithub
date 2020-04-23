using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sistema.DAL
{
    public class DAL_Login

    {
        DB_TURNERYEntities context = new DB_TURNERYEntities();

        public USUARIO ConsultarLogin(USUARIO usuario)
        {

            var validar = (from e in context.USUARIO
                           where e.CPF_usuario == usuario.CPF_usuario && e.Senha_usuario == usuario.Senha_usuario
                           select e).FirstOrDefault<USUARIO>();
            return validar;
        }

    }
}