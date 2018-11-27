using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class ContaSalarioDao : IDao<ContaSalario>
    {
        public ContaSalario Alterar(ContaSalario t)
        {
            throw new NotImplementedException();
        }

        public ContaSalario BuscarPorId(int id)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "SELECT c.id, c.numero, c.agencia, c.id_tipo_conta, t.descricao, c.saldo, c.id_pessoa, p.nome FROM banco.conta_salario c JOIN banco.pessoa p ON c.id_pessoa = p.id JOIN banco.tipo_conta t ON c.id_tipo_conta = t.id WHERE c.id = @id;";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Pessoa pessoa = new Pessoa
                    {
                        id = Convert.ToInt32(reader["id_pessoa"]),
                        nome = reader["nome"].ToString()
                    };

                    ContaSalario contaSalario = new ContaSalario()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Numero = Convert.ToInt32(reader["numero"]),
                        Agencia = reader["agencia"].ToString(),
                        TipoConta = Convert.ToInt32(reader["id_tipo_conta"]),
                        Pessoa = pessoa,
                        Saldo = (float) Convert.ToDouble(reader["saldo"])
                    };
                    return contaSalario;
                }
                else
                {
                    return null;
                }
            }
            catch (MySqlException e)
            {
                
            }
            finally
            {
                conexao.Fechar();
            }
            return null;
        }

        public ContaSalario Deletar(ContaSalario t)
        {
            throw new NotImplementedException();
        }

        public ContaSalario Inserir(ContaSalario t)
        {
            throw new NotImplementedException();
        }

        public List<ContaSalario> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
