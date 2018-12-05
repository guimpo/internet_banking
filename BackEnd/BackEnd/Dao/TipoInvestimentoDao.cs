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
        public TipoInvestimento PoupancaBuscarPorId(int id_conta)
        {
            Conexao conexao = new Conexao();
            try
            {

                string comando = "SELECT i.id, i.data_aplicacao, sum(i.valor) valor, ti.id id_tipo_investimento, ti.descricao, ti.liquidez, ti.rentabilidade" +
                   " FROM `investimento` i" +
                   " JOIN tipo_investimento ti" +
                   " ON ti.id = i.tipo_investimento_id" +
                   " WHERE i.tipo_investimento_id = 1 and i.conta_id = @id;";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id_conta);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    TipoInvestimento tipo = new TipoInvestimento()
                    {
                        Id_tipo_investimento = Convert.ToInt32(reader["id"]),
                        Descricao = reader["descricao"].ToString(),
                        Liquidez = reader["liquidez"].ToString(),
                        Rentabilidade = Convert.ToDouble(reader["rentabilidade"]),
                        Valor = Convert.ToDouble(reader["valor"])
                    };
                    return tipo;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e )
            {

                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
            finally
            {
                conexao.Fechar();
            }
        }
        public TipoInvestimentoSelic BuscarPorId(int id_conta)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "SELECT i.id, i.data_aplicacao, i.valor, count(i.id) quantidade, ti.id id_tipo_investimento, ti.descricao, ti.liquidez, ti.rentabilidade, tis.id id_tipo_investimento_selic,  tis.vencimento FROM `investimento` i JOIN tipo_investimento ti ON ti.id = i.tipo_investimento_id JOIN tipo_investimento_selic tis ON tis.tipo_investimento_id = ti.id WHERE i.tipo_investimento_id = 2 and i.conta_id = @id_conta";

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

        public TipoInvestimento Deletar(TipoInvestimento t)
        {
            throw new NotImplementedException();
        }

        public TipoInvestimentoPoupanca Inserir(TipoInvestimentoPoupanca t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "INSERT INTO tipo_investimento_poupanca(investimento_id, contacontabil_investimento_poupanca_id) VALUES (@inves, @contabil);";
                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@inves", t.Investimento.Id);
                conexao.Comando.Parameters.AddWithValue("@contabil", t.ContaContabil.Id);
                if (conexao.Comando.ExecuteNonQuery() > 0)
                {
                    t.Id = Convert.ToInt32(conexao.Comando.LastInsertedId.ToString());
                    return t;
                }
                return null;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e);
                return null;
            }
            finally
            {
                conexao.Fechar();
            }
        }

        public List<TipoInvestimento> ListarTodos()
        {
            throw new NotImplementedException();
        }
    }
}
