using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class TransacaoDao : IDao<Transacao>
    {
        public Transacao Alterar(Transacao t)
        {
            throw new NotImplementedException();
        }

        public Transacao BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Transacao Deletar(Transacao t)
        {
            throw new NotImplementedException();
        }

        public Transacao Inserir(Transacao t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string sql = "insert into trasacao (  id_tipo_transacao, data, hora, valor ) values ( @tipo,  now(),   now(), @valor);";
                conexao.Comando.CommandText = sql;
                conexao.Comando.Parameters.AddWithValue("@tipo", t.id_tipo_transacao);
                conexao.Comando.Parameters.AddWithValue("@valor", t.valor);

                if (conexao.Comando.ExecuteNonQuery() > 0)
                {


                    return t;
                }
                else
                {
                    return null;
                }
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

        public List<Transacao> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
