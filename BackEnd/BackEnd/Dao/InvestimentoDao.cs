﻿using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class InvestimentoDao : IDao<Investimento>
    {
        public Double ValorInvestido(int id_conta)
        {
            Double valor = 0;
            Conexao conexao = new Conexao();
            try
            {
   
    

    

    

               
                //conexao.Comando.CommandText = comando;
                //conexao.Comando.Parameters.AddWithValue("@id", id_conta);
                //MySqlDataReader reader = conexao.Comando.ExecuteReader();
                //if (reader.HasRows)
                //{
                //    reader.Read();
                //    valor = Convert.ToDouble(reader["valor"]);
                //}
                //return valor;
            }
            catch (Exception e)
            {

                System.Diagnostics.Debug.WriteLine(e);
                return valor;
            }
            finally
            {
                conexao.Fechar();
            }
            return valor;
        }


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
                string comand = "INSERT INTO investimento(data_aplicacao, valor, tipo_investimento_id,  conta_id) VALUES (now(), @valor, @tipo_investimento, @conta_id);";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@valor", t.Valor);
                conexao.Comando.Parameters.AddWithValue("@tipo_investimento", t.TipoInvestimento.Id_tipo_investimento);
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
