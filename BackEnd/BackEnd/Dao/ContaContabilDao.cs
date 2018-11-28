using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class ContaContabilDao : IDao<ContaContabil>
    {
        public ContaContabil Alterar(ContaContabil t)
        {
            throw new NotImplementedException();
        }

        public ContaContabil BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public ContaContabil Deletar(ContaContabil t)
        {
            throw new NotImplementedException();
        }

        public ContaContabil Inserir(ContaContabil c)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "INSERT INTO conta_contabil(pessoa_id, produto_id, data, hora, tipo_transacao_id, saldo) VALUES (@idPessoa, @idProduto, now(), now(), @idTipoTransacao, @saldo);";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@idPessoa", c.Pessoa.id);
                conexao.Comando.Parameters.AddWithValue("@idProduto", c.Produto.Id);
                conexao.Comando.Parameters.AddWithValue("@idTipoTransacao", c.TipoTransacao);
                conexao.Comando.Parameters.AddWithValue("@saldo", c.Saldo);

                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    c.Id = Convert.ToInt32(conexao.Comando.LastInsertedId.ToString());
                    return c;
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

        public List<ContaContabil> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
