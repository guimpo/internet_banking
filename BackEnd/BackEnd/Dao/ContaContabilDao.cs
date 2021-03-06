﻿using BackEnd.Models;
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

        public ContaContabil Inserir(ContaContabil t)
        {
            throw new NotImplementedException();
        }

        public ContaContabil InserirContaContabil(ContaContabil c, int tipo)//1 pra investimento e 2 pra emprestimo?
        {
            Conexao conexao = new Conexao();
            try
            {
                string comand = (tipo == 1) ? "INSERT INTO conta_contabil_investimento_poupanca(valor) VALUES (@valor);" : "INSERT INTO conta_contabil_emprestimo(valor) VALUES (@valor);";              

                conexao.Comando.CommandText = comand;
                conexao.Comando.Parameters.AddWithValue("@valor", c.Valor);

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
