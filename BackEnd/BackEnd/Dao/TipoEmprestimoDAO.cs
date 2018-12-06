using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class TipoEmprestimoDAO : IDao<TipoEmprestimo>
    {
        public TipoEmprestimo Alterar(TipoEmprestimo t)
        {
            throw new NotImplementedException();
        }

        public TipoEmprestimo BuscarPorId(int id)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from tipo_emprestimo where id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    TipoEmprestimo tipoemprestimo = new TipoEmprestimo()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Juros_Atrasado = Convert.ToDouble(reader["juros_atrasado"]),
                        Juros_Total = Convert.ToDouble(reader["juros_total"])

                    };

                    return tipoemprestimo;
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

        public TipoEmprestimo Deletar(TipoEmprestimo t)
        {
            throw new NotImplementedException();
        }

        public TipoEmprestimo Inserir(TipoEmprestimo t)
        {
            throw new NotImplementedException();
        }

        public List<TipoEmprestimo> ListarTodos()
        {
            throw new NotImplementedException();
        }
        public double valorBloqueado(int id)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from tipo_investimento_poupanca where investimento_id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    double bloqueado = 0;
                    bloqueado = Convert.ToDouble(reader["valor_bloqueado"]);
                    if (bloqueado == null)
                        return 0;
                    else
                        return bloqueado;
                }
                return 0;
            }
            catch (Exception e )
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
