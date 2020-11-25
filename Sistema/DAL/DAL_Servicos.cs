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

        public List<Clientes> ObterClientesCadastrados()
        {

            var sql = "SELECT [ID_cliente], [Nome_razaoSocial], [CPF_CNPJ]  FROM [DB_TURNERY].[dbo].[CLIENTE] WHERE Flag_cliente = 1";

            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sql, conn);
                try
                {
                    List<Clientes> listaClientesCadastrados = new List<Clientes>();
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Clientes obj = new Clientes();

                        obj.ID_Cliente = reader["ID_cliente"].ToString();
                        obj.Nome_pessoa = reader["Nome_razaoSocial"].ToString();
                        obj.CPF_pessoa = reader["CPF_CNPJ"].ToString();



                        listaClientesCadastrados.Add(obj);
                    }
                    return listaClientesCadastrados;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }


        }




        public List<Clientes> ObterDadosClienteSel(Clientes IdCliente)
        {
            var sql = "SELECT [Nome_razaoSocial],[CPF_CNPJ],[Nome_fantasia],[Celular],[TelFixo]"
            + " FROM[DB_TURNERY].[dbo].[CLIENTE]WHERE ID_cliente =" + IdCliente.ID_Cliente + " ";

            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sql, conn);
                try
                {
                    List<Clientes> listaClientesCadastrados = new List<Clientes>();
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Clientes obj = new Clientes();


                        obj.Nome_pessoa = reader["Nome_razaoSocial"].ToString();
                        obj.CPF_pessoa = reader["CPF_CNPJ"].ToString();
                        obj.NomeFantasia = reader["Nome_fantasia"].ToString();
                        obj.Cel_cliente = reader["Celular"].ToString();
                        obj.Tel_cliente = reader["TelFixo"].ToString();

                        listaClientesCadastrados.Add(obj);

                    }
                    return listaClientesCadastrados;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }

        public string GravarServico(Servico Pedido)
        {

            var retorno = "";
            using (var sqlConn = new SqlConnection(conexao))
            {

                var doc = Pedido.IdentifCliente;

                sqlConn.Open();
                SqlTransaction sTrans = sqlConn.BeginTransaction("DP");


                var sql1 = "INSERT INTO [dbo].[SERVICO]([NomeCliente],[DocCliente],[ValorServico],[PagAvista],[Descricao],[DataInclus],[Flag]) " +
                 "VALUES (" + "'" +
                  Pedido.Nome + "'" + "," +
                  doc + "," +
                  Pedido.ValorServico + "," +
                  Pedido.PagamentoTipo + "," + "'" +
                  Pedido.DescricaoServico + "'," +
                  "'" + Pedido.data + "'" + "," +
                  0 + ")";

                var sql2 = "INSERT INTO [dbo].[SERVICO]([ValorServico],[PagAvista],[Descricao],[DataInclus],[Flag]) " +
                 "VALUES (" +
                  Pedido.ValorServico + "," +
                  Pedido.PagamentoTipo + "," + "'" +
                  Pedido.DescricaoServico + "'," +
                  "'" + Pedido.data + "'" + ","+
                  0 +")";



                try
                {
                    if (Pedido.Nome == null)
                    {
                        SqlCommand cmd = new SqlCommand(sql2, sqlConn);
                        cmd.Transaction = sTrans;
                        SqlDataReader reader = cmd.ExecuteReader();
                        retorno = "1";

                    }
                    else
                    {
                        SqlCommand cmd = new SqlCommand(sql1, sqlConn);
                        cmd.Transaction = sTrans;
                        SqlDataReader reader = cmd.ExecuteReader();
                        retorno = "1";
                    }
                }
                catch (Exception e)

                {
                    sTrans.Rollback();
                    throw e;
                }

                sTrans.Commit();
                sqlConn.Close();



            }
            return retorno;


        }



        public List<Servico> ConsultaServicos(Servico flagServico)

        {

            var sql = "SELECT[IdServico],[NomeCliente],[DocCliente],[ValorServico],[PagAvista],[Descricao],[DataInclus],[Flag]" +
                        "FROM [DB_TURNERY].[dbo].[SERVICO]";

            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sql, conn);
                try
                {
                    List<Servico> listaServicosCadastrados = new List<Servico>();
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Servico obj = new Servico();

                        obj.IdServico = reader["IdServico"].ToString();
                        obj.Nome = reader["NomeCliente"].ToString();
                        obj.IdentifCliente = reader["DocCliente"].ToString();
                        obj.ValorServico = reader["ValorServico"].ToString();
                        obj.PagamentoTipo = reader["PagAvista"].ToString();
                        obj.DescricaoServico = reader["Descricao"].ToString();
                        obj.flagServico = reader["Flag"].ToString();
                        obj.data = reader["DataInclus"].ToString();






                        listaServicosCadastrados.Add(obj);
                    }
                    return listaServicosCadastrados;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }


        }

    }
}