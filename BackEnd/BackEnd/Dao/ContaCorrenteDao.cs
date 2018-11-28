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
    }
}
