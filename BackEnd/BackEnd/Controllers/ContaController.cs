
using BackEnd.Dao;
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
    public class ContaController 
    {
      
        

        // GET popular
        [HttpGet]
        public IEnumerable<Models.DebitoAutomatico> Get()
        {
            return new DebitoAutomaticoDao().ListarToDos();
        }

        //adiciona dado
        [HttpPost]
        public Bool Post([FromBody] Models.DebitoAutomatico conta)
        {
            Bool b = new Bool();
            string s = new DebitoAutomaticoDao().Inserir(conta);
            if (s.Equals("sucesso"))
                b.boolean = true;
            else
                b.boolean = false;
            return b;
            
            
        }
        //delete 
        [HttpDelete("{id:int}")]
        public Bool Delet(Int32 id)
        {
            Bool b = new Bool();
            string s = new DebitoAutomaticoDao().Deletar(id);
            if (s.Equals("sucesso"))
                b.boolean = true;
            else
                b.boolean = false;
            return b;
        }
    }
}
