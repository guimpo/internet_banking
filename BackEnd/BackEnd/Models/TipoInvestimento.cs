namespace BackEnd.Models
{
    public class TipoInvestimento : Investimento
    {
        public int Id_tipo_investimento { get; set; }
        public string Descricao { get; set; }
        public string Liquidez { get; set; }
        public double Rentabilidade { get; set; }
    }
}