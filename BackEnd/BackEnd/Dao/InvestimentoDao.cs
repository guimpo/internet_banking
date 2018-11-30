using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class InvestimentoDao : IDao<Investimento>
    {
        public Investimento Alterar(Investimento t)
        {
            throw new NotImplementedException();
        }

        public Investimento BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Investimento Deletar(Investimento t)
        {
            throw new NotImplementedException();
        }

        public Investimento Inserir(Investimento t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "INSERT INTO investimento(data_aplicacao, valor, tipo_investimento_id, conta_contabil_investimento_id, conta_id) VALUES (@data_aplicacao, @valor, @tipo_investimento, @conta_contabil_investimento_id, @conta_id);";

                conexao.Comando.CommandText = comand;
                // (@data_aplicacao, @valor, @tipo_investimento, @conta_contabil_investimento_id, @conta_id)
                conexao.Comando.Parameters.AddWithValue("@data_aplicacao", t.DataAplicacao);
                conexao.Comando.Parameters.AddWithValue("@valor", t.Valor);
                conexao.Comando.Parameters.AddWithValue("@tipo_investimento", t.TipoInvestimento.Id);
                conexao.Comando.Parameters.AddWithValue("@conta_contabil_investimento_id", t.ContaContabil.Id);
                conexao.Comando.Parameters.AddWithValue("@conta_id", t.Conta.Id);

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

        public List<Investimento> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
