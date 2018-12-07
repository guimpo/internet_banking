using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class TipoInvestimentoPoupanca
    {
        public int Id { get; set; }
        public Boolean bloqueado { get; set; }
        public Investimento Investimento { get; set; }
        public ContaContabil ContaContabil { get; set; }
    }
}
