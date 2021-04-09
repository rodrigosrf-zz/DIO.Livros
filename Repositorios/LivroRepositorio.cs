using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIO.Livros.Interfaces;
using DIO.Livros.Entidades;

namespace DIO.Livros.Repositorios
{
    public class LivroRepositorio : IRepositorio<Livro>
    {

        private static LivroRepositorio _livroRepositorio;

        public static LivroRepositorio Instancia()
        {
            if (_livroRepositorio == null) _livroRepositorio = new LivroRepositorio();
            return _livroRepositorio;
        }

        List<Livro> listaLivro = new List<Livro>();
        int proximoCodigo = 0;

        public void Atualiza(int id, Livro livro)
        {
            for (int i = 0; i < listaLivro.Count(); i++)
            {
                if(listaLivro[i].Id==id)
                {
                    livro.Id = id;
                    listaLivro[i] = livro;
                }
            }
        }

        public Livro buscaPorId(int id)
        {
            return listaLivro.Find(item => item.Id == id);
        }

        public List<Livro> buscaTodos()
        {
            return listaLivro;
        }

        public void Exclui(int id)
        {
            Livro livro = buscaPorId(id);
            if (livro != null) listaLivro.Remove(livro);
        }

        public void Insere(Livro livro)
        {
            livro.Id = ProximoId();
            listaLivro.Add(livro);
            proximoCodigo++;
        }

        public int ProximoId()
        {
            return proximoCodigo+1;
        }
    }
}
