using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class ContaCorrenteDao : IDao<Conta>
    {
        public Conta Alterar(Conta c)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "UPDATE conta SET saldo = @saldo WHERE id = @id";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@id", c.Id);
                conexao.Comando.Parameters.AddWithValue("@saldo", c.Saldo);

                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    return c;
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

        public Conta Alterar(Transacao t)
        {
            Conexao conexao = new Conexao();

            try
            {
                string comando = "update conta set saldo = saldo + @valor where id = @id;";
                conexao.Comando.CommandText = comando;
                if (t.tipo_transacao_id == 2 || t.tipo_transacao_id == 4)
                    conexao.Comando.Parameters.AddWithValue("@valor", t.valor);
                else
                    conexao.Comando.Parameters.AddWithValue("@valor", -t.valor);

                //conexao.Comando.Parameters.AddWithValue("@id", t.Conta.Id);
                conexao.Comando.Parameters.AddWithValue("@id", 7);
                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    Conta conta = new Conta();
                    return conta;
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

        public Conta BuscarPorId(int id)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from conta where id = @id;";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Conta conta = new Conta()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            TipoConta = Convert.ToInt32(reader["tipo_conta_id"]),
                            Saldo = Convert.ToDouble(reader["saldo"])
                        };
                        return conta;
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

        public Conta BuscarPorId(Pessoa p)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from conta where pessoa_id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", p.id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Conta conta = new Conta()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Numero = Convert.ToInt32(reader["numero"]),
                        Agencia = (reader["agencia"].ToString()),
                        TipoConta = Convert.ToInt32(reader["tipo_conta_id"]),
                        Saldo = Convert.ToDouble(reader["saldo"])
                        
                    };

                    return conta;
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

        public Conta Deletar(Conta t)
        {
            throw new NotImplementedException();
        }

        public Conta Inserir(Conta t)
        {
            throw new NotImplementedException();
        }

        public List<Conta> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public double GetSaldo()
        {
            Conexao conexao = new Conexao();

            try
            {
                string comando = "select saldo from conta where id_pessoa = 1;";
                conexao.Comando.CommandText = comando;
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                reader.Read();
                return Convert.ToDouble(reader["saldo"].ToString());
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return 0;
            }
            finally
            {
                conexao.Fechar();
            }
        }
    }
}
