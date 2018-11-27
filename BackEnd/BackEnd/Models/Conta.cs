using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Conta
    {
        public int id { get; set; }
        public int id_tipo_conta { get; set; }
        public Pessoa id_pessoa { get; set; }
        public float saldo { get; set; }
    }
}
