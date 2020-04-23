using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Web.Script.Serialization;
using Sistema.Models;

namespace Sistema.DAL
{
    public class DAL_Clientes
    {


        string conexao = WebConfigurationManager.ConnectionStrings["DB_TURNERY"].ConnectionString;


        public String CadastroPF(Clientes ClientePF)
        {
            using (var sqlConn = new SqlConnection(conexao))
            {
                sqlConn.Open();
                SqlTransaction sTrans = sqlConn.BeginTransaction("DP");
                var sql = "INSERT INTO [dbo].[CLIENTE] ([Nome_razaoSocial],[CPF_CNPJ],[Celular],[TelFixo],[TelComercial], "+
                    "[Rua],[Numero],[Bairro],[Cidade],[UF],[Flag_cliente]) VALUES "+
                    "(" +"'" + Convert.ToString(ClientePF.Nome_pessoa) +"'" + "," + Convert.ToInt64(ClientePF.CPF_pessoa) + "," 
                    + "" + Convert.ToInt64(ClientePF.Cel_cliente) + "," 
                    + "" + Convert.ToInt64(ClientePF.Tel_cliente) + "," + Convert.ToInt64(ClientePF.TelComercial_cliente) + ","
                    + "'" + Convert.ToString(ClientePF.Rua) + "'" + "," + Convert.ToString(ClientePF.Numero) + ","
                    + "'" + Convert.ToString(ClientePF.Bairro) + "'"+ "," + "'" + Convert.ToString(ClientePF.Cidade)+ "'" + "," 
                    + "'" + Convert.ToString(ClientePF.UF) + "'" + "," + Convert.ToInt32(ClientePF.Flag_cliente) + " )";


                try
                {


                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    cmd.Transaction = sTrans;
                    SqlDataReader reader = cmd.ExecuteReader();


                }
                catch (Exception e)

                {
                    sTrans.Rollback();
                    throw e;
                }

                sTrans.Commit();
                sqlConn.Close();

               

            }
            return "1";

        }


        public String CadastroPJ(Clientes ClientePJ)
        {
            using (var sqlConn = new SqlConnection(conexao))
            {
                sqlConn.Open();
                SqlTransaction sTrans = sqlConn.BeginTransaction("DP");
                var sql = "INSERT INTO [dbo].[CLIENTE] ([Nome_razaoSocial],[CPF_CNPJ],[Nome_fantasia],[Celular],[TelFixo],[TelComercial],[Rua],[Numero],[Bairro],[Cidade],[UF],[Flag_cliente]) VALUES " +
                    "(" + "'" + Convert.ToString(ClientePJ.RazaoSocial) + "'" + "," + Convert.ToInt64(ClientePJ.CNPJ) + ","
                    + "'" + Convert.ToString(ClientePJ.NomeFantasia) + "'" +","+ "" + Convert.ToInt64(ClientePJ.Cel_cliente) + ","
                    + "" + Convert.ToInt64(ClientePJ.Tel_cliente) + "," + Convert.ToInt64(ClientePJ.TelComercial_cliente) + ","
                    + "'" + Convert.ToString(ClientePJ.Rua) + "'" + "," + Convert.ToString(ClientePJ.Numero) + ","
                    + "'" + Convert.ToString(ClientePJ.Bairro) + "'" + "," + "'" + Convert.ToString(ClientePJ.Cidade) + "'" + ","
                    + "'" + Convert.ToString(ClientePJ.UF) + "'" + "," + Convert.ToInt32(ClientePJ.Flag_cliente) + " )";


                try
                {


                    SqlCommand cmd = new SqlCommand(sql, sqlConn);
                    cmd.Transaction = sTrans;
                    SqlDataReader reader = cmd.ExecuteReader();


                }
                catch (Exception e)

                {
                    sTrans.Rollback();
                    throw e;
                }

                sTrans.Commit();
                sqlConn.Close();



            }
            return "1";

        }




        public List<Clientes> ObterListaClientes()
        {
            var sql = "SELECT [ID_cliente],[Nome_razaoSocial],[CPF_CNPJ],[Celular],[TelFixo],[TelComercial] FROM [DB_TURNERY].[dbo].[CLIENTE] where [Flag_cliente] = 1";

            using (var conn = new SqlConnection(conexao))
            {
                var cmd = new SqlCommand(sql, conn);
                try
                {
                    List<Clientes> listacompleta = new List<Clientes>();
                    conn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        Clientes obj = new Clientes();

                        obj.ID_Cliente = reader["ID_cliente"].ToString();
                        obj.CPF_pessoa = reader["CPF_CNPJ"].ToString();
                        obj.RazaoSocial = reader["Nome_razaoSocial"].ToString();
                        obj.Cel_cliente = reader["Celular"].ToString();
                        obj.Tel_cliente = reader["TelFixo"].ToString();
                        obj.TelComercial_cliente = reader["TelComercial"].ToString();

                        listacompleta.Add(obj);
                    }
                    return listacompleta;
                }
                catch (Exception e)
                {
                    throw e;
                }
            }

        }





        public List<Clientes> ExcluirCliente(FlagCliente InativadorCliente)
        {


            using (var sqlConn = new SqlConnection(conexao))
            {


                sqlConn.Open();
                SqlTransaction sTrans = sqlConn.BeginTransaction("DB_TURNERY");

                try
                {



                    foreach (var obj in InativadorCliente.idCliente)
                    {
                        //SqlCommand sCom = sqlConn.CreateCommand();
                        var updateClientes = "UPDATE [DB_TURNERY].[dbo].[CLIENTE] SET [Flag_cliente] = " + InativadorCliente.NovaSitCliente + "  where [ID_cliente] IN (" + obj + ") ";
                        SqlCommand cmd = new SqlCommand(updateClientes, sqlConn);
                        //var linhasAfetadas = sCom.ExecuteNonQuery();
                        cmd.Transaction = sTrans;
                        SqlDataReader reader = cmd.ExecuteReader();

                    }

                   

                }
                catch (Exception e)

                {
                    sTrans.Rollback();
                    throw e;
                }

                sTrans.Commit();
                sqlConn.Close();

               


                using (var conn = new SqlConnection(conexao))
                {
                    List<Clientes> listaClientesAtualizada = new List<Clientes>();

                    var sql = "SELECT [ID_cliente],[Nome_razaoSocial],[CPF_CNPJ],[Celular],[TelFixo],[TelComercial] FROM [DB_TURNERY].[dbo].[CLIENTE] where [Flag_cliente] = 1";
                    var cmd = new SqlCommand(sql, conn);
                    try
                    {



                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            Clientes obj = new Clientes();

                            obj.ID_Cliente = reader["ID_cliente"].ToString();
                            obj.CPF_pessoa = reader["CPF_CNPJ"].ToString();
                            obj.RazaoSocial = reader["Nome_razaoSocial"].ToString();
                            obj.Cel_cliente = reader["Celular"].ToString();
                            obj.Tel_cliente = reader["TelFixo"].ToString();
                            obj.TelComercial_cliente = reader["TelComercial"].ToString();

                            listaClientesAtualizada.Add(obj);
                        }

                    }

                    catch (Exception e)
                    {
                        throw e;
                    }

                    return listaClientesAtualizada;
                }
            }

        }




    }
}