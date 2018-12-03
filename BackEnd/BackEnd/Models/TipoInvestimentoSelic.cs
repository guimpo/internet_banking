using System;

namespace BackEnd.Models
{
    public class TipoInvestimentoSelic : TipoInvestimento
    {
        public int Id_tipo_investimento_selic { get; set; }
        public int Quantidade { get; set; }
        public DateTime Vencimento { get; set; }
    }
}