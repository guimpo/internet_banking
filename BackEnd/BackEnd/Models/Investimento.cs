﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public class Investimento 
    {
        public int Id { get; set; }
        public DateTime DataAplicacao { get; set; }
        public double Valor { get; set; }
        public Boolean status { get; set; }
        public TipoInvestimento TipoInvestimento { get; set; }
        public Conta Conta { get; set; }
    }
}
