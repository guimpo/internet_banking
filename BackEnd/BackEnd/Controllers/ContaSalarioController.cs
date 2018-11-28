using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Dao;
using BackEnd.Dto;
using BackEnd.Models;
using BackEnd.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/contasalario")]
    public class ContaSalarioController : Controller
    {
        // GET: api/<controller>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        [HttpGet("{id}")]
        public JsonResult Get(int id)
        {
            return Json(new ContaSalarioDao().BuscarPorId(id));
        }

        // POST api/<controller>
        [HttpPost("saque")]
        public JsonResult Post([FromBody] SaqueDto saque)
        {
            var conta = new ContaSalario() { Id = saque.IdContaSalario};
            return Json(new ContaSalarioService().Saque(conta, saque.Valor));
        }

        // POST api/<controller>
        [HttpPost("deposito")]
        public JsonResult Post([FromBody] DepositoDto saque)
        {
            var conta = new ContaSalario() { Id = saque.IdContaSalario };
            return Json(new ContaSalarioService().Deposito(conta, saque.Valor));
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }

        // POST api/<controller>
        [HttpPost("transferencia")]
        public JsonResult Transferencia([FromBody] TransferenciaDto t)
        {
            var salario = new ContaSalario() { Id = t.ContaSalarioId };
            var corrente = new Conta() { id = t.ContaCorrenteId };
            // idContaSalario = 2
            // idContaCorrente = 1
            // valor 2
            return Json(new ContaSalarioService().Transferir(salario, corrente, t.Valor));
        }

    }
}
