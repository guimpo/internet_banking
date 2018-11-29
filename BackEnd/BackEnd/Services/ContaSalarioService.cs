using BackEnd.Dao;
using BackEnd.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public class ContaSalarioService : ITransferencia<Conta>
    {
        public Conta Transferir(Conta contaOrigem, Conta contaDestino, double valor)
        {
            //var daoSalario = new ContaDao();
            //var daoCorrente = new ContaCorrenteDao();
            //var _contaOrigem = daoSalario.BuscarPorId(contaOrigem.Id);
            //var _contaDestino = daoCorrente.BuscarPorId(contaDestino.Id);

            //if(_contaOrigem == null || _contaDestino == null)
            //{
            //    return null;
            //}

            //if(_contaOrigem.Saldo >= valor)
            //{
            //    _contaOrigem.Saldo -= valor;
            //    _contaDestino.Saldo += valor;
            //    _contaOrigem = daoSalario.Alterar(_contaOrigem);
            //    _contaDestino = daoCorrente.Alterar(_contaDestino);

            //    var daoContabil = new ContaContabilDao();
            //    var contaContabil = new ContaContabil()
            //    {
            //        Pessoa = _contaOrigem.Pessoa,
            //        Produto = _contaOrigem,
            //        TipoTransacao = 1,
            //        Saldo = valor
            //    };
            //    if (daoContabil.Inserir(contaContabil) == null) return null;

            //    var daoTransacao = new TransacaoDao();
            //    var transacao = new Transacao()
            //    {
            //        id_tipo_transacao = 2,
            //        valor = valor
            //    };
            //    if (daoTransacao.Inserir(transacao) == null) return null;
            //    return _contaOrigem;
            //}
            return null;
        }

        public Conta Saque(Conta conta, float valor)
        {
            //var daoSalario = new ContaDao();
            //var _conta = daoSalario.BuscarPorId(conta.Id);
            //if (_conta != null && _conta.Saldo >= valor)
            //{
            //    _conta.Saldo -= valor;
            //    if (daoSalario.Alterar(_conta) != null)
            //    {
            //        var daoContabil = new ContaContabilDao();
            //        var contaContabil = new ContaContabil()
            //        {
            //            Pessoa = _conta.Pessoa,
            //            Produto = _conta,
            //            TipoTransacao = 1,
            //            Saldo = valor
            //        };
            //        if(daoContabil.Inserir(contaContabil) != null)
            //        {
            //            return _conta;
            //        }
            //    }
            //}
            return null;
        }

        public Conta Deposito(Conta conta, float valor)
        {
            //var daoSalario = new ContaDao();
            //var _conta = daoSalario.BuscarPorId(conta.Id);
            //if (_conta != null && valor > 0)
            //{
            //    _conta.Saldo += valor;
            //    if (daoSalario.Alterar(_conta) != null)
            //    {
            //        var daoContabil = new ContaContabilDao();
            //        var contaContabil = new ContaContabil()
            //        {
            //            Pessoa = _conta.Pessoa,
            //            Produto = _conta,
            //            TipoTransacao = 2,
            //            Saldo = valor
            //        };
            //        if (daoContabil.Inserir(contaContabil) != null)
            //        {
            //            return _conta;
            //        }
            //    }
            //}
            return null;
        }
    }
}
