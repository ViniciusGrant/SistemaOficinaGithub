using Sistema.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace Sistema.DAL
{
    public class DAL_Servicos
    {
        string conexao = WebConfigurationManager.ConnectionStrings["DB_TURNERY"].ConnectionString;

        public List<Object> ObterClientesCadastrados()
        {

            var sql = "SELECT [ID_cliente], [Nome_razaoSocial] FROM [DB_TURNERY].[dbo].[CLIENTE]";

            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sql, conn);
                try
                {
                    List<Object> listaClientesCadastrados = new List<Object>();
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        var item = new
                        {
                            idCliente = reader["ID_cliente"].ToString(),
                            nome = reader["Nome_razaoSocial"].ToString()

                        };

                        listaClientesCadastrados.Add(item);
                    }
                    return listaClientesCadastrados;
                }

                catch (Exception e)
                {
                    throw e;
                }
            }

        }
    }
}