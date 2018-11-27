using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Dao
{
    public interface IDao<T>
    {
        List<T> ListarTodos();
        T BuscarPorId(int id);
        T Inserir(T t);
        T Alterar(T t);
        T Deletar(T t);
    }
}
