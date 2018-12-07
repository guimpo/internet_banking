using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class TransacaoDao : IDao<Transacao>
    {
        public Transacao Alterar(Transacao t)
        {
            throw new NotImplementedException();
        }

        public Transacao BuscarPorId(int id)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from trasacao where id = @id;";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        var data = DateTime.Parse(reader["data"].ToString());
                        var hora = DateTime.Parse(reader["hora"].ToString());
                        var conta = new Conta();
                        conta.Id = Convert.ToInt32(reader["conta_id1"]);

                        Transacao transacao = new Transacao()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            data = data,
                            hora = hora,
                            valor = Convert.ToDouble(reader["valor"]),
                            tipo_transacao_id = Convert.ToInt32(reader["tipo_transacao_id"]),
                            Conta = conta
                        };
                        return transacao;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
            finally
            {
                conexao.Fechar();
            }
        }

        public Transacao Deletar(Transacao t)
        {
            throw new NotImplementedException();
        }

        public Transacao Inserir(Transacao t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string sql = "insert into trasacao (data, hora, valor, tipo_transacao_id, conta_id1) values (now(), now(), @valor, @tipo, 7);";
                conexao.Comando.CommandText = sql;
                conexao.Comando.Parameters.AddWithValue("@tipo", t.tipo_transacao_id);
                conexao.Comando.Parameters.AddWithValue("@valor", t.valor);

                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    return t;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {

                return null;
            }
            finally
            {
                conexao.Fechar();
            }
        }

        public List<Transacao> ListarTodos()
        {
            Conexao conexao = new Conexao();
            try
            {

                List<Models.Transacao> transacoes = new List<Models.Transacao> { };


                string comando = "select t.*, tt.descricao tipo_transacao_descricao from trasacao t join tipo_transacao tt ON t.tipo_transacao_id = tt.id where conta_id1 = 7 ORDER BY id DESC;";  
                conexao.Comando.CommandText = comando;
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Transacao t = new Models.Transacao
                        {
                            id = Convert.ToInt32(reader["id"]),
                            tipo_transacao_id = Convert.ToInt32(reader["tipo_transacao_id"]),
                            tipo_transacao_descricao = (reader["tipo_transacao_descricao"].ToString()),
                            data = Convert.ToDateTime(reader["data"]),
                            //hora = Convert.ToDateTime(reader["hora"]),
                            hora = DateTime.ParseExact((reader["hora"]).ToString(), "HH:mm:ss", CultureInfo.InvariantCulture),
                            valor = Convert.ToDouble(reader["valor"])
                        };
                        transacoes.Add(t);
                    }

                }
                return transacoes;

            }
            catch (Exception e)
            {
                return null;
            }
            finally
            {
                conexao.Fechar();
            }
        }
    }
}
