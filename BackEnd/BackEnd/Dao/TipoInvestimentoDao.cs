using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class TipoInvestimentoDao 
    {
        public TipoInvestimento Alterar(TipoInvestimento t)
        {
            throw new NotImplementedException();
        }

        public TipoInvestimentoSelic BuscarPorId(int id_conta)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "SELECT i.id, i.data_aplicacao, SUM(i.valor) valor, count(i.id) quantidade, ti.id id_tipo_investimento, ti.descricao, ti.liquidez, ti.rentabilidade, tis.id id_tipo_investimento_selic, tis.vencimento FROM `investimento` i JOIN tipo_investimento ti ON ti.id = i.tipo_investimento_id JOIN tipo_investimento_selic tis ON tis.investimento_id = i.id WHERE i.tipo_investimento_id = 2 and i.conta_id = @id_conta";

                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id_conta", id_conta);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();

                if (reader.HasRows)
                {
                    reader.Read();
                    TipoInvestimentoSelic tipoinvestimentoSelic = new TipoInvestimentoSelic()
                    {
                        //investimento
                        Id = Convert.ToInt32(reader["id"]),
                        DataAplicacao = Convert.ToDateTime(reader["data_aplicacao"]),
                        Valor = Convert.ToDouble(reader["valor"]),
                        //tipo investimento
                        Id_tipo_investimento = Convert.ToInt32(reader["id_tipo_investimento"]),
                        Descricao = reader["descricao"].ToString(),
                        Liquidez = reader["liquidez"].ToString(),
                        Rentabilidade = Convert.ToDouble(reader["rentabilidade"]),
                        //tipo investimento selic
                        Id_tipo_investimento_selic = Convert.ToInt32(reader["id_tipo_investimento_selic"]),
                        Quantidade = Convert.ToInt32(reader["quantidade"]),
                        Vencimento = Convert.ToDateTime(reader["vencimento"])

                    };

                    return tipoinvestimentoSelic;

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

        public Boolean AplicarSelic(TipoInvestimentoSelic aplicacao)
        {
            Conexao conexao = new Conexao();
            try
            {

                double valor = aplicacao.Quantidade * 100;

                string comand = "UPDATE `investimento` SET `valor` = @valor WHERE id = 2";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@valor", valor);
                //conexao.Comando.Parameters.AddWithValue("@saldo", c.Saldo);

                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (MySqlException e)
            {
                return false;
            }
            finally
            {
                conexao.Fechar();
            }
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
