using BackEnd.Dao;
using BackEnd.Models;
using System;
using Xunit;

namespace XUnitTestProject
{
    public class ContaCorrenteDaoTest
    {
        //(8, '2018-11-01', '22:18:53', 1000, 2, 7),
        //(9, '2018-11-30', '13:18:53', 100, 3, 7);
        [Fact]
        public void AlterarTest()
        {
            // Criar transacao
            var dataHora = new DateTime(2018, 11, 1, 22, 18, 53);
            var conta = new Conta();
            conta.Id = 7;

            Transacao transacaoEsperada = new Transacao()
            {
                id = 8,
                data = dataHora.Date,
                hora = dataHora,
                valor = 1000.0,
                tipo_transacao_id = 2,
                Conta = conta
            };

            // buscar id 8
            var idBuscado = 8;
            var transacaoDao = new TransacaoDao();
            var retorno = transacaoDao.BuscarPorId(idBuscado);

            Assert.NotNull(retorno);
            Assert.Equal(transacaoEsperada.id, retorno.id);
            Assert.True(transacaoEsperada.data.Date.Equals(retorno.data.Date));
            Assert.Equal(transacaoEsperada.valor, retorno.valor);
        }
    }
}
