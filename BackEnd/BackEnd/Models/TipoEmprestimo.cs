using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class TipoEmprestimo
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Juros_Total { get; set; }
        public double Juros_Atrasado { get; set; }
    }
}
