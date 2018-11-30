using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class EmprestimoDAO : IDao<Emprestimo>
    {
        public Emprestimo Alterar(Emprestimo t)
        {
            throw new NotImplementedException();
        }

        public Emprestimo BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Emprestimo Deletar(Emprestimo t)
        {
            throw new NotImplementedException();
        }

        public Emprestimo Inserir(Emprestimo t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "INSERT INTO emprestimo(valor, data_solicitacao, tipo_emprestimo_id, conta_contabil_emprestimo_id, conta_id) VALUES (@valor, now(), @tipo, @conta_contabil, 7);";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@valor", t.Valor);
                conexao.Comando.Parameters.AddWithValue("@tipo", t.TipoEmprestimo);
                conexao.Comando.Parameters.AddWithValue("@conta_contabil", t.ContaContabil.Id);

                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    t.Id = Convert.ToInt32(conexao.Comando.LastInsertedId.ToString());
                    return t;
                }
                return null;
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }
            finally
            {
                conexao.Fechar();
            }
            return null;
        }

        public List<Emprestimo> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
