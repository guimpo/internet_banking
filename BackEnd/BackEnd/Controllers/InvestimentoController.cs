using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Dao;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class InvestimentoController : ControllerBase
    {
        // GET: api/Investimento
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "ControllerIvestimento", "works!" };
        }

        // GET: api/Investimento/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        //[HttpGet("investido/{id_conta}")]
        //public Double getInvestido(int id_conta)
        //{

        //}

        // POST: api/Investimento/Poupanca
        [HttpPost]
        [HttpPost("poupanca")]
        public Investimento Post([FromBody] Investimento investimento)
        {

            //inserir no conta contabil
            ContaContabilDao daoContabil = new ContaContabilDao();
            ContaContabil contabil = new ContaContabil();
            contabil.Valor = investimento.Valor;
            contabil = daoContabil.InserirContaContabil(contabil, investimento.TipoInvestimento.Id_tipo_investimento);

            if (contabil == null)
            {
                return null;
            }

            //alterar saldo da conta
            ContaCorrenteDao contaCorrente = new ContaCorrenteDao();
            Conta conta = new Conta();
            investimento.Conta.Saldo = investimento.Conta.Saldo - investimento.Valor;
            conta = investimento.Conta;
            contaCorrente.Alterar(conta);

            if (conta == null)
            {
                return null;
            }

            //inserir investimento
            InvestimentoDao daoInvestimento = new InvestimentoDao();
            investimento = daoInvestimento.Inserir(investimento);

            if (investimento == null)
            {
                return null;
            }
            else
            {
                TipoInvestimentoDao dao = new TipoInvestimentoDao();
                TipoInvestimentoPoupanca poupanca = new TipoInvestimentoPoupanca();
                poupanca.ContaContabil = contabil;
                poupanca.Investimento = investimento;
                poupanca = dao.Inserir(poupanca);

                if (poupanca == null)
                {
                    return null;
                }
                else
                {
                    return investimento;
                }   
            }

            
        }

        // PUT: api/Investimento/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        //GET: api/investimento/popança/id
        [HttpGet("poupanca/{id_conta}")]
        public TipoInvestimento getPopanca(int id_conta)
        {
            return (new TipoInvestimentoDao().PoupancaBuscarPorId(id_conta));
        }

        //GET: api/investimento/selic
        [HttpGet("selic")]
        public TipoInvestimento getSelic()
        {
            
            return (new TipoInvestimentoDao().BuscarPorId(7));
        }
    }
}
