using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BackEnd.Dao;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BackEnd.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController
    {
        [HttpPost]
        public void Post([FromBody] Emprestimo emprestimo)
        {
            EmprestimoDAO emprestimoDao = new EmprestimoDAO();
            ParcelaDAO parcelaDao = new ParcelaDAO();
            ContaContabilDao ccDao = new ContaContabilDao();
            InvestimentoDao investimentoDao = new InvestimentoDao();

            ContaContabil cc = new ContaContabil
            {
                Valor = -emprestimo.Valor
            };
            cc = ccDao.InserirContaContabil(cc, 2);

            emprestimo.ContaContabil = cc;
            emprestimo = emprestimoDao.Inserir(emprestimo);

            double valorParcela = CalculaParcela(emprestimo);

            DateTime date = DateTime.Now;
            for (int i = 1; i <= emprestimo.Parcelas; i++)
            {
                date = date.AddMonths(1);
                Parcela p = new Parcela();
                p.DataVencimento = date;
                p.Valor = valorParcela;
                p.Emprestimo = emprestimo;
                parcelaDao.Inserir(p);
            }
            if(emprestimo.Garantia > 0)
            {
                investimentoDao.Bloqueia();
            }
        }

        [Route("simular")]
        [HttpPost]
        public List<Parcela> Simular([FromBody] Emprestimo emprestimo)
        {
            List<Parcela> parcelas = new List<Parcela>();

            double valorParcela = CalculaParcela(emprestimo);

            DateTime date = DateTime.Now;
            for (int i = 1; i <= emprestimo.Parcelas; i++)
            {
                date = date.AddMonths(1);
                Parcela p = new Parcela();
                p.DataVencimento = date;
                p.Valor = valorParcela;
                parcelas.Add(p);
            }

            return parcelas;
        }

        [HttpGet]
        public IEnumerable<Models.Parcela> Get()
        {
            return new ParcelaDAO().ListarTodos();
        }

        [Route("boleto")]
        [HttpPost]
        public Double Boleto([FromBody] Parcela parcela)
        {
            ParcelaDAO parceladao = new ParcelaDAO();
            int i = 0;
            DateTime aux = parcela.DataVencimento;

            while (aux <= DateTime.Now)
            {
                aux = aux.AddMonths(1);
                i++;
            }

            // teria que chamar o juros do tipo_emprestimo

            EmprestimoDAO emprestimodao = new EmprestimoDAO();
            TipoEmprestimoDAO tipoemprestimodao = new TipoEmprestimoDAO();

            //acha primeiro id do emprestimo, depois pega o tipo_emprestimo_pessoal_id, e o conta_id
            //(uma chamada cada, pq é objeto), depois procura infos do cara usando o conta_id, e infos do juros usando
            //o tipo_emprestimo_id


            TipoEmprestimo juros = tipoemprestimodao.BuscarPorId(emprestimodao.BuscarIdTipoEmprestimo(parceladao.BuscarIdEmprestimo(parcela.Id)));

            
            

            return (parcela.Valor * i * (juros.Juros_Atrasado/100));
        }

        [Route("codigo")]
        [HttpPost]
        public String Codigo([FromBody] Parcela parcela)
        {
            int aux = parcela.Id;

            //algum jeito de gera código
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            var random = new Random();
            var result = new string(
                Enumerable.Repeat(chars, 12)
                          .Select(s => s[random.Next(s.Length)])
                          .ToArray());
            return result;

        }

        [Route("poupanca")]
        [HttpGet]
        public Investimento GetSaldoPoupanca()
        {
            Investimento investimento = new Investimento();
            InvestimentoDao investimentoDao = new InvestimentoDao();
            investimento.Valor = investimentoDao.ValorInvestido(7, 1);
            return investimento;
        }

        public double CalculaParcela(Emprestimo emprestimo)
        {
            TipoEmprestimoDAO teDao = new TipoEmprestimoDAO();
            emprestimo.TipoEmprestimo = teDao.BuscarPorId(1);
            double juros = emprestimo.TipoEmprestimo.Juros_Total;
            double aux = emprestimo.Garantia / emprestimo.Valor;

            juros = juros - (3 * aux);
            if (juros < 1.5)
                juros = 1.5;

            aux = (juros / 100) + 1;
            double valorParcela = (emprestimo.Valor / emprestimo.Parcelas) * aux;

            return valorParcela;
        }
    }
}