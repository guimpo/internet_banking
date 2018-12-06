using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Route("api/investimento/[controller]")]
    [ApiController]
    public class TesouroPrefixadoLtnController : ControllerBase
    {
        // GET: api/investimento/tesouroprefixadoltn
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "Controller", "works!" };
        }
    }
}