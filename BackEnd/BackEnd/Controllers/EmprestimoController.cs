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

            emprestimo = emprestimoDao.Inserir(emprestimo);

            double valorParcela = (emprestimo.Valor / emprestimo.Parcelas) * 1.045;

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
        }

        [Route("simular")]
        [HttpPost]
        public List<Parcela> Simular([FromBody] Emprestimo emprestimo)
        {
            List<Parcela> parcelas = new List<Parcela>();

            double valorParcela = (emprestimo.Valor / emprestimo.Parcelas) * 1.045;

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
    }
}