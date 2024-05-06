// See https://aka.ms/new-console-template for more information
using System.Collections.Generic;
using BibliotecaService.Entidades;

public class Program
{
    static void Main(string[] args)
    {
        Livro livro = new Livro();
        Usuario usuario = new Usuario();

        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("OPÇÕES PARA LIVROS:");
            Console.WriteLine("1 - Cadastrar livro");
            Console.WriteLine("2 - Mostrar todos os livros");
            Console.WriteLine("3 - Consultar livro por ID");
            Console.WriteLine("4 - Remover livro");
            Console.WriteLine();
            Console.WriteLine("OPÇÕES PARA USUÁRIOS:");
            Console.WriteLine("5 - Cadastrar usuário");
            Console.WriteLine("6 - Mostrar todos os usuários");
            Console.WriteLine("7 - Consultar usuário por ID");
            Console.WriteLine("8 - Remover usuário");
            Console.WriteLine();
            Console.WriteLine("OPÇÕES PARA EMPRÉSTIMO:");
            Console.WriteLine("9 - Realizar empréstimo");
            Console.WriteLine("10 - Realizar devolução");
            Console.WriteLine();
            Console.WriteLine("0 - Sair");
            Console.WriteLine();
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            Console.Clear();

            switch (opcao)
            {
                case "1":
                    livro.CadastrarLivro();
                    break;
                case "2":
                    livro.ConsultarTodosLivros();
                    break;
                case "3":
                    livro.ConsultarLivroPorID();
                    break;
                case "4":
                    livro.RemoverLivro();
                    break;
                case "5":
                    usuario.CadastrarUsuario();
                    break;
                case "6":
                    usuario.ConsultarTodosUsuarios();
                    break;
                case "7":
                    usuario.ConsultarUsuarioPorID();
                    break;
                case "8":
                    usuario.RemoverUsuario();
                    break;
                case "9":
                    livro.RealizarEmprestimo();

                    break;
                case "10":
                    livro.RealizarDevolucao();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida. Tente novamente.");
                    break;
            }
        }

    }
}
