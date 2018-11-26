using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MensagenBoardBackend.Controllers
{
    [Produces("application/json")]
    [Route("api/mensagens")]
    [ApiController]
    public class MensagemController : ControllerBase
    {
        static List<Models.Mensagem> messages = new List<Models.Mensagem> {
                 new Models.Mensagem
                {
                    nome="kaoo",
                    sobrenome="yuy"
                },
                new Models.Mensagem
                {
                    nome="Luiz",
                    sobrenome="lugar"
                }
        };

        public IEnumerable<Models.Mensagem> Get()
        {
            return messages;
        }

        //adiciona dado
        [HttpPost]
        public void Post([FromBody] Models.Mensagem message)
        {
            messages.Add(message);
        }
    }
}