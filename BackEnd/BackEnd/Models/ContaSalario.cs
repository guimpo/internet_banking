namespace BackEnd.Models
{
    public class ContaSalario : Produto, IConta
    {
        public override int Id { get => base.Id; set => base.Id = value; }
        public override string Descricao { get => base.Descricao; set => base.Descricao = value; }
        public int Numero { get; set; }
        public string Agencia { get; set; }
        public int TipoConta { get; set; }
        public Pessoa Pessoa { get; set; }
        public float Saldo { get; set; }
        public ContaContabil ContaContabil { get; set; }

        public int NumeroConta => Numero;

        public string AgenciaConta => Agencia;

        public int IdConta => Id;

        public float SaldoAtual { get => Saldo; set => Saldo = value; }
    }
}
