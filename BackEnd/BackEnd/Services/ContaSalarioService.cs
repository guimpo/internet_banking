using BackEnd.Dao;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ContaSalarioService : ITransferencia<IConta>
    {
        public IConta Transferir(IConta contaOrigem, IConta contaDestino, float valor)
        {
            var daoSalario = new ContaSalarioDao();
            var daoCorrente = new ContaCorrenteDao();
            var _contaOrigem = daoSalario.BuscarPorId(contaOrigem.IdConta);
            var _contaDestino = daoCorrente.BuscarPorId(contaDestino.IdConta);

            if(_contaOrigem == null || _contaDestino == null)
            {
                return null;
            }

            if(_contaOrigem.Saldo >= valor)
            {
                _contaOrigem.Saldo -= valor;
                _contaDestino.saldo += valor;
                _contaOrigem = daoSalario.Alterar(_contaOrigem);
                _contaDestino = daoCorrente.Alterar(_contaDestino);

                var daoContabil = new ContaContabilDao();
                var contaContabil = new ContaContabil()
                {
                    Pessoa = _contaOrigem.Pessoa,
                    Produto = _contaOrigem,
                    TipoTransacao = 1,
                    Saldo = valor
                };
                if (daoContabil.Inserir(contaContabil) == null) return null;

                var daoTransacao = new TransacaoDao();
                var transacao = new Transacao()
                {
                    id_tipo_transacao = 2,
                    valor = valor
                };
                if (daoTransacao.Inserir(transacao) == null) return null;
                return _contaOrigem;
            }
            return null;
        }
    }
}
