using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public Double valor { get; set; }
        public DateTime data_solicitacao { get; set; }
        public TipoEmprestimo TipoEmprestimo { get; set; }
        public ContaContabilEmprestimo ContaContabilEmprestimo { get; set; }
        public Conta Conta { get; set; }
    }
}
