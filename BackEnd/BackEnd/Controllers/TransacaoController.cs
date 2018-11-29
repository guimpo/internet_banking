using BackEnd.Dao;
using BackEnd.Models;

using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TransacaoController
    {


        public List<Models.Transacao> ListarTodos()
        {
            TransacaoDao transacaoDao = new TransacaoDao();
            return transacaoDao.ListarTodos();
        }

        public void Alterar(Transacao t)
        {
            ContaCorrenteDao ccDao = new ContaCorrenteDao();
            ccDao.Alterar(t);
        }
        

        public Conta BuscarConta(Pessoa pessoa)
        {
            ContaCorrenteDao ccDao = new ContaCorrenteDao();
            Conta conta = ccDao.BuscarPorId(pessoa);
            return conta;
            Conexao conexao = new Conexao();
            try
            {
                string comando = "select * from conta where pessoa_id = @id";
                conexao.Comando.CommandText = comando;
                conexao.Comando.Parameters.AddWithValue("@id", pessoa.id);
                MySqlDataReader reader = conexao.Comando.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    Conta conta = new Conta()
                    {
                        Id = Convert.ToInt32(reader["id"]),
                        TipoConta = Convert.ToInt32(reader["tipo_conta_id"]),
                        Pessoa = pessoa,
                        Saldo = Convert.ToDouble(reader["saldo"])

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

        public Pessoa Login(int id)
        {
            PessoaDao pessoaDao = new PessoaDao();
            return pessoaDao.BuscarPorId(id);
        }

      
        public Transacao Inserir(Transacao t)
        {
            TransacaoDao transacaoDao = new TransacaoDao();
            return transacaoDao.Inserir(t);
        }

        public double GetSaldo()
        {
            ContaCorrenteDao ccDao = new ContaCorrenteDao();
            return ccDao.GetSaldo();
        }

        // GET popular
        [HttpGet]
        public IEnumerable<Models.Transacao> Get()
        {

            
            return ListarTodos();
        }


        // GET Login
        [HttpGet("login/{id:int}")]
        public Models.Conta GetLogin(int id)
        {
            Pessoa pessoa = new Pessoa();
            pessoa = Login(id);
            Conta conta = new Conta();
            conta = BuscarConta(pessoa);
            return conta;
        }
       

        //adiciona dado
        [HttpPost]
        public Bool Post([FromBody] Models.Transacao transacao)
        {
            Bool b = new Bool();
            Transacao t = new Transacao();
            t = Inserir(transacao);

            if (!t.Equals(null))
            {
                b.boolean = true;
                Alterar(t);
            }
            else
            {
                b.boolean = false;
            }

            return b;
        }

        [Route("valida/{valor}")]
        [HttpGet]
        public Bool valida(double valor)
        {
            Bool b = new Bool();
            double saldo = GetSaldo();
            if (valor <= saldo)
                b.boolean = true;
            else
                b.boolean = false;

            return b;
        }
    }
}
