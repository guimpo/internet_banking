using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dto
{
    public class TransferenciaDto
    {
        public int ContaSalarioId { get; set; }
        public int ContaCorrenteId { get; set; }
        public float Valor { get; set; }
    }
}
