﻿using BackEnd.Dao;
using BackEnd.Models;

using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController : IDao<Transacao>
    {


        public List<Models.Transacao> ListarToDos()
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
                            hora = Convert.ToDateTime(reader["hora"]),
                            valor = Convert.ToInt32(reader["valor"])
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

        public Transacao Alterar(Transacao t)
        {
            Conexao conexao = new Conexao();

            try
            {
                string comando = "update conta set saldo = saldo + @valor where id_pessoa = 2;";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@valor", t.valor);
                if (conexao.Comando.ExecuteNonQuery() > 0)
                {

                    return null;
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
        public Transacao BuscarPonrId(int id)
        { throw new NotImplementedException(); }

        public Conta BuscarConta(Pessoa pessoa)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from conta where id_pessoa = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", pessoa.id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Conta conta = new Conta()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        id_tipo_conta = Convert.ToInt32(reader["id_tipo_conta"]),
                        id_pessoa = pessoa,
                        saldo = Convert.ToInt32(reader["saldo"])

                    };

                    return conta;
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

        public Pessoa Longin(int id)
        {
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from pessoa where id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Pessoa pessoa = new Pessoa()
                    {
                        id = Convert.ToInt32(reader["id"]),
                        nome = reader["nome"].ToString()

                    };

                    return pessoa;
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


        // GET popular
        [HttpGet]
        public IEnumerable<Models.Transacao> Get()
        {

            
            return ListarToDos();
        }


        // GET Login
        [HttpGet("login/{id:int}")]
        public Models.Conta GetLogin(int id)
        {
            Pessoa pessoa = new Pessoa();
            pessoa = Longin(id);
            Conta conta = new Conta();
            conta = BuscarConta(pessoa);
            return conta;
        }
       

        //adiciona dado
        [HttpPost]
        public void Post([FromBody] Models.Transacao transacao)
        {
           
            Inserir(transacao);
            Alterar(transacao);
        }
    }
}
