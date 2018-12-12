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

        public int BuscarIdTipoEmprestimo(int id)
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

                    int Id = Convert.ToInt32(reader["tipo_emprestimo_pessoal_id"]);

                    return Id;
                }
                else
                {
                    return 0;
                }
            }
            catch (MySqlException e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                return 0;
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
                string comand = "INSERT INTO emprestimo(valor, data_solicitacao, tipo_emprestimo_pessoal_id, conta_contabil_emprestimo_id, conta_id, parcelas, metodo_pagamento, garantia) VALUES (@valor, now(), @tipo, @conta_contabil, 7, @parcelas, @pagamento, @garantia);";

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@valor", t.Valor);
                conexao.Comando.Parameters.AddWithValue("@parcelas", t.Parcelas);
                conexao.Comando.Parameters.AddWithValue("@pagamento", t.MetodoPagamento);
                conexao.Comando.Parameters.AddWithValue("@tipo", 1);
                conexao.Comando.Parameters.AddWithValue("@conta_contabil", t.ContaContabil.Id);
                conexao.Comando.Parameters.AddWithValue("@garantia", t.Garantia);

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
