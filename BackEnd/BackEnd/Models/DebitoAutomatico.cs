using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class DebitoAutomatico
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public int Codigo { get; set; }
        public int Conta { get; set; }
    }
}
