using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Transacao
    {
        public int id { get; set; }
        public int tipo_transacao_id { get; set; }
        public string tipo_transacao_descricao { get; set; }
        public DateTime data { get; set; }
        public DateTime hora { get; set; }
        public double valor { get; set; }
        public Conta Conta { get; set; }

        public static implicit operator List<object>(Transacao v)
        {
            throw new NotImplementedException();
        }
    }
}
