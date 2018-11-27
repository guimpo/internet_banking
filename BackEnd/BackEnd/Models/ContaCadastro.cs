using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class ContaCadastro
    {
        public int id { get; set; }
        public int id_conta { get; set; }
        public string descricao { get; set; }
        public string codigo { get; set; }
    }
}
