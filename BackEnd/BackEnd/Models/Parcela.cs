using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Parcela
    {
        public int Id { get; set; }
        public DateTime DataVencimento { get; set; }
        public DateTime DataPagamento { get; set; }
        public bool Status { get; set; }
        public double Valor { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}
