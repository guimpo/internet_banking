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
                conexao.Comando.Parameters.AddWithValue("@id", c.id);
                conexao.Comando.Parameters.AddWithValue("@saldo", c.saldo);

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
                string comando = "update conta set saldo = saldo + @valor where id_pessoa = 2;";
                conexao.Comando.CommandText = comando;
                if (t.id_tipo_transacao == 2)
                    conexao.Comando.Parameters.AddWithValue("@valor", t.valor);
                else
                    conexao.Comando.Parameters.AddWithValue("@valor", -t.valor);

                if (conexao.Comando.ExecuteNonQuery() > 0)
                {

                    return null;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException e)
            {

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
                        Pessoa pessoa = new Pessoa
                        {
                            id = Convert.ToInt32(reader["id_pessoa"])
                        };

                        Conta conta = new Conta()
                        {
                            id = Convert.ToInt32(reader["id"]),
                            id_tipo_conta = Convert.ToInt32(reader["id_tipo_conta"]),
                            id_pessoa = pessoa,
                            saldo = (float) Convert.ToDouble(reader["saldo"])
                        };
                        return conta;
                    } 
                }
                return null;
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

        public Conta BuscarPorId(Pessoa p)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from conta where id_pessoa = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", p.id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Conta conta = new Conta()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        id_tipo_conta = Convert.ToInt32(reader["id_tipo_conta"]),
                        id_pessoa = p,
                        saldo = (float)Convert.ToDouble(reader["saldo"])

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
                string comando = "select saldo from conta where id_pessoa = 2;";
                conexao.Comando.CommandText = comando;
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                reader.Read();
                return Convert.ToDouble(reader["saldo"].ToString());
            }
            catch (MySqlException e)
            {
                return 0;
            }
            finally
            {
                conexao.Fechar();
            }
        }
    }
}
