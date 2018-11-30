using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public class ParcelaDAO : IDao<Parcela>
    {
        public Parcela Alterar(Parcela t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "UPDATE parcela set status = 1, data_pagamento = now() where id = @id";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@id", t.Id);

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

        public Parcela BuscarPorId(int id)
        {
            throw new NotImplementedException();
        }

        public Parcela Deletar(Parcela t)
        {
            throw new NotImplementedException();
        }

        public Parcela Inserir(Parcela t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "INSERT INTO parcela(data_vencimento, status, valor, emprestimo_id) VALUES (@data, 0, @valor, @emprestimo);";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@data", t.DataVencimento);
                conexao.Comando.Parameters.AddWithValue("@valor", t.Valor);
                conexao.Comando.Parameters.AddWithValue("@emprestimo", t.Emprestimo.Id);

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

        public List<Parcela> ListarTodos()
        {
            throw new NotImplementedException();
        }

        public List<Parcela> ListarTodosID()
        {
            Conexao conexao = new Conexao();
            try
            {

                List<Models.Parcela> parcelas = new List<Models.Parcela> { };


                string comando = "SELECT p.data_vencimento AS data_vencimento, p.valor AS valor, p.status as status FROM parcela p inner JOIN emprestimo e ON p.emprestimo_id = e.id where e.conta_id = 7";
                conexao.Comando.CommandText = comando;
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Parcela p = new Models.Parcela
                        {
                            DataVencimento = Convert.ToDateTime(reader["data_vencimento"]),
                            Status = (reader["status"].ToString().Equals("1")) ? true : false,
                            Valor = Convert.ToDouble(reader["valor"])
                        };
                        parcelas.Add(p);
                    }

                }
                return parcelas;

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
    }
}
