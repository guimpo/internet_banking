using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class PessoaDao : IDao<Pessoa>
    {
        public Pessoa Alterar(Pessoa t)
        {
            throw new NotImplementedException();
        }

        public Pessoa BuscarPorId(int id)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from pessoa where id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Pessoa pessoa = new Pessoa()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        nome = reader["nome"].ToString()

                    };

                    return pessoa;
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

        public Pessoa Deletar(Pessoa t)
        {
            throw new NotImplementedException();
        }

        public Pessoa Inserir(Pessoa t)
        {
            throw new NotImplementedException();
        }

        public List<Pessoa> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
