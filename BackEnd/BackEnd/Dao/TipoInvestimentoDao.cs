﻿using BackEnd.Models;
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

                    Double valor = Convert.ToDouble(reader["valor"]);
                    DateTime data_aplicacao = Convert.ToDateTime(reader["data_aplicacao"]);
                    Double juros = Convert.ToDouble(reader["rentabilidade"]);
                    Double valor_liquido = calculoJutosSelic(valor,data_aplicacao,juros);

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
                        Vencimento = Convert.ToDateTime(reader["vencimento"]),
                        Valor_liquido = valor_liquido

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

        private double calculoJutosSelic(double valor, DateTime data_aplicacao, Double taxajuros)
        {

            int dias = (DateTime.Now - data_aplicacao).Days;

            taxajuros = taxajuros * dias;

            Double valorComJuros = valor * taxajuros;

            return valorComJuros;

        }

        public Double getSaldo(int id_conta)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand_0 = "SELECT saldo FROM conta WHERE id = @id_conta";
                conexao.Comando.CommandText = comand_0;
                conexao.Comando.Parameters.AddWithValue("@id_conta", id_conta);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();

                reader.Read();
                Double saldo = Convert.ToDouble(reader["saldo"]);

                return saldo;

            }
            catch (MySqlException e)
            {
                return 0;
            }
            finally
            {
                conexao.Fechar();
            }

        }

        public int createInvestimento( int id_conta, Double valor )
        {
            Conexao conexao = new Conexao();

            try
            {
                string comand_1 = "INSERT INTO investimento (data_aplicacao, valor, tipo_investimento_id, conta_id) VALUES (now(), @valor, 2, @id_conta)";

                conexao.Comando.CommandText = comand_1;
                conexao.Comando.Parameters.AddWithValue("@id_conta", id_conta);
                conexao.Comando.Parameters.AddWithValue("@valor", valor);
                conexao.Comando.ExecuteNonQuery();

                int id_investimento = Convert.ToInt32(conexao.Comando.LastInsertedId.ToString());

                return id_investimento;
            }
            catch (MySqlException e)
            {
                return 0;
            }
            finally
            {
                conexao.Fechar();
            }

        }

        public Boolean createInvestimentoSelic(int id_invertimento, Double quantidade)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand_2 = "INSERT INTO `tipo_investimento_selic`(`investimento_id`, `vencimento`, `quantidade`, `conta_contabil_investimento_selic_id`) VALUES (@id_investimento, '2023-03-01', @quantidade, 1)";
                conexao.Comando.CommandText = comand_2;
                conexao.Comando.Parameters.AddWithValue("@id_investimento", id_invertimento);
                conexao.Comando.Parameters.AddWithValue("@quantidade", quantidade);

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

        public Boolean AplicarSelic(TipoInvestimentoSelic aplicacao, int id_conta)
        {
            try
            {
                double valor = aplicacao.Quantidade * 100;

                if(getSaldo(id_conta) > valor)
                {
                    int id_investimento = createInvestimento(id_conta, valor);

                    if (id_investimento > 0)
                    {
                        if (createInvestimentoSelic(id_investimento, aplicacao.Quantidade)){
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return false;
                    } 
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
