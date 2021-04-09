using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DIO.Livros.Enum;

namespace DIO.Livros.Entidades
{
    public class Livro: BaseEntidade
    {

        private string _titulo;
        private GeneroLivro _genero;
        private string _autor;

        public Livro(string titulo, GeneroLivro genero, string autor)
        {
            _titulo = titulo;
            _genero = genero;
            _autor = autor;
        }

        public string retornaTitulo()
        {
            return _titulo;
        }

        public override string ToString()
        {
            StringBuilder retorno = new StringBuilder();

            retorno.Append($"Titulo: {_titulo}" + Environment.NewLine);
            retorno.Append($"Genero: {_genero}" + Environment.NewLine);
            retorno.Append($"Autor: {_autor}" + Environment.NewLine);

            return retorno.ToString();
        }
    }
}
