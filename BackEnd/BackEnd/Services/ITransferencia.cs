using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Services
{
    public interface ITransferencia<T>
    {
        T Transferir(T origem, T destino, float valor);
    }
}
