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
    public class InvestimentoController : Controller
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

        [HttpPut("resgatar")]
        public bool putResgatar([FromBody] Investimento inves)
        {

            //inserir no conta contabil
            ContaContabilDao daoContabil = new ContaContabilDao();
            ContaContabil contabil = new ContaContabil();
            contabil.Valor = -inves.Valor;
            contabil = daoContabil.InserirContaContabil(contabil, inves.TipoInvestimento.Id_tipo_investimento);


            //preparando transacao
            TransacaoDao t = new TransacaoDao();
            ContaCorrenteDao conta = new ContaCorrenteDao();
            InvestimentoDao invesDao = new InvestimentoDao();
            Transacao transacao = new Transacao();
            if (invesDao.AlterarResgatar(inves.TipoInvestimento.Id, inves.Valor))
            {
                transacao.Conta = inves.Conta;
                transacao.tipo_transacao_id = 2;
                transacao.valor = inves.Valor;
            }
            t.Inserir(transacao);

            //inserir na table tipo investimento poupanca
            TipoInvestimentoDao dao = new TipoInvestimentoDao();
            TipoInvestimentoPoupanca poupanca = new TipoInvestimentoPoupanca();
            inves.Id = inves.TipoInvestimento.Id;
            poupanca.ContaContabil = contabil;
            poupanca.Investimento = inves;
            poupanca = dao.Inserir(poupanca);

            if (poupanca == null)
            {
                return false;
            }
           
            //alterar saldo da conta ----soma
            Conta c = new Conta();
            c = conta.Alterar(transacao);
            if (c.Id.Equals(0))
                return true;
            else
                return false;
        }

        [HttpGet("bloqueado/{id}")]
        public double getInvestido(int id)
        {
            return (new TipoEmprestimoDAO().valorBloqueado(id));
        }

        // POST: api/Investimento/Poupanca
        [HttpPost]
        [HttpPost("poupanca")]
        public bool Post([FromBody] Investimento investimento)
        {

            //inserir no conta contabil
            ContaContabilDao daoContabil = new ContaContabilDao();
            ContaContabil contabil = new ContaContabil();
            contabil.Valor = investimento.Valor;
            contabil = daoContabil.InserirContaContabil(contabil, investimento.TipoInvestimento.Id_tipo_investimento);

            if (contabil == null)
            {
                return false;
            }

            //alterar saldo da conta
            ContaCorrenteDao contaCorrente = new ContaCorrenteDao();
            Conta conta = new Conta();
            investimento.Conta.Saldo = investimento.Conta.Saldo - investimento.Valor;
            conta = investimento.Conta;
            contaCorrente.Alterar(conta);

            if (conta == null)
            {
                return false;
            }


            //preparando transacao
            TransacaoDao t = new TransacaoDao();
            InvestimentoDao invesDao = new InvestimentoDao();
            Transacao transacao = new Transacao();
            if (invesDao.AlterarResgatar(investimento.TipoInvestimento.Id, investimento.Valor))
            {
                transacao.Conta = investimento.Conta;
                transacao.tipo_transacao_id = 3;
                transacao.valor = investimento.Valor;
            }
            t.Inserir(transacao);

            //verificar se tem dados no investimento e alterar ou inserir
            InvestimentoDao daoInvestimento = new InvestimentoDao();
            if (daoInvestimento.verificarNoInvesPoupanca(investimento.Conta.Id))
            {
                //alterar investimento- valor
                investimento.Id = investimento.TipoInvestimento.Id;
                investimento = daoInvestimento.AlterarAplicar(investimento);
            }
            else
            {
                //inserir investimento
                investimento = daoInvestimento.Inserir(investimento);
            }

            

            if (investimento == null)
            {
                return false;
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
                    return false;
                }
                else
                {
                    return true;
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

        // POST api/<controller>
        [HttpPost("aplicar-selic")]
        public JsonResult Post([FromBody] TipoInvestimentoSelic aplicacao)
        {
            return Json(new TipoInvestimentoDao().AplicarSelic(aplicacao,7));
        }

        // POST api/<controller>
        [HttpPost("resgatar-selic")]
        public JsonResult PostResgate([FromBody] TipoInvestimentoSelic aplicacao)
        {
            return Json(new TipoInvestimentoDao().AplicarSelic(aplicacao, 7));
        }


    }
}
