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



        // POST: api/Investimento/Poupanca
        [HttpPost]
        [HttpPost("poupanca")]
        public Investimento Post([FromBody] Investimento investimento)
        {

            ContaContabilDao daoContabil = new ContaContabilDao();
            ContaContabil contabil = new ContaContabil();
            contabil.Valor = investimento.Valor;
            contabil = daoContabil.InserirContaContabil(contabil, investimento.TipoInvestimento.Id);

            if (contabil == null)
            {
                return null;
            }

            InvestimentoDao daoInvestimento = new InvestimentoDao();
            investimento = daoInvestimento.Inserir(investimento);

            if (investimento == null)
            {
                return null;
            }
            else
            {
                return investimento;
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

        //GET: api/investimento/popança
        [HttpGet("poupanca")]
        public TipoInvestimento getPopanca()
        {
            return (new TipoInvestimentoDao().BuscarPorId(1));
        }

        //GET: api/investimento/selic
        [HttpGet("selic")]
        public TipoInvestimento getSelic()
        {
            return (new TipoInvestimentoDao().BuscarPorId(7));
        }
    }
}
