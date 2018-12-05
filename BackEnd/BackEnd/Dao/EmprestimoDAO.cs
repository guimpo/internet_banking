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
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from emprestimo where id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Emprestimo emprestimo = new Emprestimo()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        Valor = Convert.ToDouble(reader["valor"]),
                        DataSolicitacao = Convert.ToDateTime(reader["data_solicitacao"])
                    };

                    return emprestimo;
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

        public Emprestimo Deletar(Emprestimo t)
        {
            throw new NotImplementedException();
        }

        public Emprestimo Inserir(Emprestimo t)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = "INSERT INTO emprestimo(valor, data_solicitacao, tipo_emprestimo_pessoal_id, conta_contabil_emprestimo_id, conta_id, parcelas, metodo_pagamento) VALUES (@valor, now(), @tipo, @conta_contabil, 7, @parcelas, @pagamento);";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@valor", t.Valor);
                conexao.Comando.Parameters.AddWithValue("@parcelas", t.Parcelas);
                conexao.Comando.Parameters.AddWithValue("@pagamento", t.MetodoPagamento);
                conexao.Comando.Parameters.AddWithValue("@tipo", 1);
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
