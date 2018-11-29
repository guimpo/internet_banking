using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Conta 
    {


        public int Id { get; set; }
        public int Numero { get; set; }
        public string Agencia { get; set; }
        public double Saldo { get; set; }
        public int TipoConta { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}
