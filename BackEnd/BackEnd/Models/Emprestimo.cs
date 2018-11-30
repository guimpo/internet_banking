using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public double Valor { get; set; }
        public DateTime DataSolicitacao { get; set; }
        public TipoEmprestimo TipoEmprestimo { get; set; }
        public ContaContabil ContaContabil { get; set; }
        public Conta Conta { get; set; }
    }
}
