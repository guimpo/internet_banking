using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Models
{
    public abstract class Produto
    {
        public virtual int Id { get; set; }
        public virtual string Descricao { get; set; }
    }
}
