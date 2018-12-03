using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class TipoInvestimentoDao : IDao<TipoInvestimento>
    {
        public TipoInvestimento Alterar(TipoInvestimento t)
        {
            throw new NotImplementedException();
        }

        public TipoInvestimento BuscarPorId(int id)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from tipo_investimento where id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    TipoInvestimento tipoinvestimento = new TipoInvestimento()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Descricao = reader["descricao"].ToString(),
                        Liquidez = reader["liquidez"].ToString(),
                        Rentabilidade = Convert.ToDouble(reader["rentabilidade"])

                    };

                    return tipoinvestimento;
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

        public TipoInvestimento Deletar(TipoInvestimento t)
        {
            throw new NotImplementedException();
        }

        public TipoInvestimento Inserir(TipoInvestimento t)
        {
            throw new NotImplementedException();
        }

        public List<TipoInvestimento> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
