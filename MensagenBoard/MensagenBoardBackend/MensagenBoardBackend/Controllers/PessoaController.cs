using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MensagenBoardBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/pessoa")]
    [ApiController]
    public class PessoaController
    {
        static List<Models.Pessoa> messages = new List<Models.Pessoa> {
                 new Models.Pessoa
                {
                    id=1,
                    nome="yuy"
                },
                new Models.Pessoa
                {
                    id=2,
                    nome="lugar"
                }
        };
        public IEnumerable<Models.Pessoa> Get()
        {
            return messages;
        }
        //adiciona dado
        [HttpPost]
        public void Post([FromBody] Models.Pessoa pessoa)
        {
            messages.Add(pessoa);
        }
    }
}
