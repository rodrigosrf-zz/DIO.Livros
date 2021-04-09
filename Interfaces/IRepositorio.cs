using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIO.Livros.Interfaces
{
    public interface IRepositorio<T>
    {
        List<T> buscaTodos();
        T buscaPorId(int id);
        void Insere(T livro);
        void Exclui(int id);
        void Atualiza(int id, T livro);
        int ProximoId();
    }
}
