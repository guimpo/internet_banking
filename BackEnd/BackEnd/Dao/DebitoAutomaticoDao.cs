using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class DebitoAutomaticoDao
    {
        public DebitoAutomatico Alterar(DebitoAutomatico t)
        {
            throw new NotImplementedException();
        }

        public DebitoAutomatico BuscarPonrId(int id)
        {
            throw new NotImplementedException();
        }

        public string Deletar(int t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "delete from debito_automatico where id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", t);
                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    return "sucesso";
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
            finally
            {
                conexao.Fechar();
            }
        }

        public string Inserir(DebitoAutomatico t)
        {
            Conexao conecxao = new Conexao();
            try
            {
                string sql = "insert into debito_automatico ( descricao, numero_conta, conta_id  ) values ( @descricao,  @numero,  @id_conta);";
                conecxao.Comando.CommandText = sql;
                conecxao.Comando.Parameters.AddWithValue("@descricao", t.Descricao);
                conecxao.Comando.Parameters.AddWithValue("@numero", t.Codigo);
                conecxao.Comando.Parameters.AddWithValue("@id_conta", t.Conta);

                if (conecxao.Comando.ExecuteNonQuery() > 0)
                {


                    return "sucesso";
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
            finally
            {
                conecxao.Fechar();
            }
        }

        public List<DebitoAutomatico> ListarToDos()
        {
            Conexao conecxao = new Conexao();
            try
            {

                List<Models.DebitoAutomatico> contas = new List<Models.DebitoAutomatico> { };


                string comando = "select * from debito_automatico ;";
                conecxao.Comando.CommandText = comando;
                MySqlDataReader reader = conecxao.Comando.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        DebitoAutomatico t = new Models.DebitoAutomatico
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Descricao = reader["descricao"].ToString(),
                            Codigo = Convert.ToInt32(reader["numero_conta"])
                        };
                        contas.Add(t);
                    }

                }
                return contas;

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
            finally
            {
                conecxao.Fechar();
            }
        }
    }
}
