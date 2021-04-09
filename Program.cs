using System;
using DIO.Livros.Repositorios;
using DIO.Livros.Enum;
using DIO.Livros.Entidades;

namespace DIO.Livros
{
    class Program
    {
		static LivroRepositorio repositorio = LivroRepositorio.Instancia();

		static void Main(string[] args)
        {
			string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario!="X")
            {
				switch (opcaoUsuario)
				{
					case "1":
						ListarLivros();
						break;
					case "2":
						InserirLivro();
						break;
                    case "3":
                        AtualizarLivro();
                        break;
                    case "4":
                        ExcluirLivro();
                        break;
                    case "5":
                        VisualizarLivro();
                        break;
                    case "C":
						Console.Clear();
						break;
					default:
						throw new ArgumentOutOfRangeException();
				}

				opcaoUsuario = ObterOpcaoUsuario();
			}

			Console.WriteLine("Até a próxima");
			Console.ReadLine();


		}

        private static void AtualizarLivro()
        {
			GeraDivisao();
			Console.WriteLine("Atualizar Livro");

			Console.Write("Digite o id do Livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			Livro livro = repositorio.buscaPorId(indiceLivro);
			if(livro==null)
            {
				Console.WriteLine("Nenhum livro encontrado.");
				return;
			}

			foreach (int i in System.Enum.GetValues(typeof(GeneroLivro)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(GeneroLivro), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Autor do Livro: ");
			string entradaAutor = Console.ReadLine();

			repositorio.Atualiza(indiceLivro, new Livro(
				titulo: entradaTitulo,
				genero: (GeneroLivro)entradaGenero,
				autor: entradaAutor
				));
		}

		private static void ExcluirLivro()
        {
			Console.Write("Digite o id do Livro: ");
			int indiceLivro = int.Parse(Console.ReadLine());

			repositorio.Exclui(indiceLivro);
		}

        private static void VisualizarLivro()
        {
			GeraDivisao();
			Console.Write("Digite o id do Livro: ");
			int idLivro = int.Parse(Console.ReadLine());

			var livro = repositorio.buscaPorId(idLivro);

			Console.WriteLine(livro);
		}

        private static void InserirLivro()
        {
			GeraDivisao();
			Console.WriteLine("Inserir nova livro");

			foreach (int i in System.Enum.GetValues(typeof(GeneroLivro)))
			{
				Console.WriteLine("{0}-{1}", i, System.Enum.GetName(typeof(GeneroLivro), i));
			}
			Console.Write("Digite o gênero entre as opções acima: ");
			int entradaGenero = int.Parse(Console.ReadLine());

			Console.Write("Digite o Título do Livro: ");
			string entradaTitulo = Console.ReadLine();

			Console.Write("Digite o Autor do Livro: ");
			string entradaAutor = Console.ReadLine();

			repositorio.Insere(new Livro(
				titulo: entradaTitulo,
				genero: (GeneroLivro)entradaGenero,
				autor: entradaAutor
				));
		}

		private static void GeraDivisao()
        {
			Console.WriteLine(new String('-', 50));
		}

		private static void ListarLivros()
        {
			GeraDivisao();
			Console.WriteLine("Listar livros");

			var lista = repositorio.buscaTodos();

			if (lista.Count == 0)
			{
				Console.WriteLine("Nenhum livro cadastrado.");
				return;
			}

			foreach (var livro in lista)
			{
				Console.WriteLine("ID {0}: - {1}", livro.Id, livro.retornaTitulo());
			}

		}

		private static string ObterOpcaoUsuario()
		{
			GeraDivisao();
			Console.WriteLine();
			Console.WriteLine("DIO Livros");
			Console.WriteLine("Informe a opção desejada:");

			Console.WriteLine("1- Listar livros");
			Console.WriteLine("2- Inserir novo livro");
			Console.WriteLine("3- Atualizar livro");
			Console.WriteLine("4- Excluir livro");
			Console.WriteLine("5- Visualizar livro");
			Console.WriteLine("C- Limpar Tela");
			Console.WriteLine("X- Sair");
			Console.WriteLine();

			string opcaoUsuario = Console.ReadLine().ToUpper();
			Console.WriteLine();
			return opcaoUsuario;
		}

	}
}
