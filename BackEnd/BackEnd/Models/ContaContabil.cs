using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class ContaContabil
    {
        public int Id { get; set; } 
        public Pessoa Pessoa { get; set; }
        public Produto Produto { get; set; }
        public DateTime DataHora { get; set; }
        public int TipoTransacao { get; set; }
        public float Saldo { get; set; }
    }
}
