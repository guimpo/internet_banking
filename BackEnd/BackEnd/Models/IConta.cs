using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public interface IConta
    {
        int IdConta { get; }
        int NumeroConta { get; }
        string AgenciaConta { get; }
        float SaldoAtual { get; set; }
    }
}
