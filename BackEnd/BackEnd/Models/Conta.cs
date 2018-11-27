using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Conta : IConta
    {
        public int id { get; set; }
        public int id_tipo_conta { get; set; }
        public Pessoa id_pessoa { get; set; }
        public float saldo { get; set; }

        public int NumeroConta => 123456;

        public string AgenciaConta => "654321-x";

        public float SaldoAtual {
            get => saldo;
            set => saldo = value;
        }

        public int IdConta => id;
    }
}
