﻿using BackEnd.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Globalization;
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
            Conexao conexao = new Conexao();
            try
            {

                List<Models.Transacao> transacoes = new List<Models.Transacao> { };


                string comando = "select * from trasacao ;";
                conexao.Comando.CommandText = comando;
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {

                    while (reader.Read())
                    {
                        Transacao t = new Models.Transacao
                        {
                            id = Convert.ToInt32(reader["id"]),
                            id_tipo_transacao = Convert.ToInt32(reader["id_tipo_transacao"]),
                            data = Convert.ToDateTime(reader["data"]),
                            //hora = Convert.ToDateTime(reader["hora"]),
                            hora = DateTime.ParseExact((reader["hora"]).ToString(), "HH:mm:ss", CultureInfo.InvariantCulture),
                            valor = Convert.ToDouble(reader["valor"])
                        };
                        transacoes.Add(t);
                    }

                }
                return transacoes;

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
