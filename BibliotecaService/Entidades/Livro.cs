using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaService.Entidades
{
    public class Livro : Emprestimo
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Isbn { get; set; }
        public int Ano { get; set; }
        public bool Disponivel { get; set; }

        public int proximoID = 1;

        public List<Livro> livros = new List<Livro>();
        public List<Emprestimo> emprestimos = new List<Emprestimo>();

        public Livro()
        {
            this.Id = proximoID;
            proximoID++;
            Disponivel = true;
        }

        public void CadastrarLivro()
        {
            Livro livro = new Livro();
            Console.WriteLine("informe os dados do livro para cadastro: ");

            Console.Write("Titulo: ");
            livro.Titulo = Console.ReadLine();
            Console.Write("Id: ");
            livro.Id = int.Parse(Console.ReadLine());
            Console.Write("Autor: ");
            livro.Autor = Console.ReadLine();
            Console.Write("Ano de publicação: ");
            livro.Ano = int.Parse(Console.ReadLine());
            Console.Write("ISBN: ");
            livro.Isbn = Console.ReadLine();

            while (livros.Any(c => c.Id == livro.Id))
            {
                Console.WriteLine("ID já existe. Digite outro ID:");
                livro.Id = int.Parse(Console.ReadLine());
            }
            while (livros.Any(c => c.Isbn == livro.Isbn))
            {
                Console.WriteLine("ISBN já existe. Digite outro ISBN:");
                livro.Isbn = Console.ReadLine();
            }
            livros.Add(livro);

            Console.WriteLine($"Livro cadastrado com sucesso!");

            Console.ReadLine();
            Console.Clear();
        }

        public void RemoverLivro()
        {
            Console.WriteLine("Digite o ID do livro que deseja remover:");
            int id = int.Parse(Console.ReadLine());

            Livro LivroParaRemover = livros.Find(t => t.Id == id);
            Console.Clear();
            if (LivroParaRemover != null)
            {
                Console.WriteLine($"ID: {LivroParaRemover.Id}, Nome: {LivroParaRemover.Titulo}, Autor: {LivroParaRemover.Autor}, Data de publicação: {LivroParaRemover.Ano}, ISBN: {LivroParaRemover.Isbn}");
                Console.WriteLine("Pressione: ");
                Console.WriteLine("1 - Confirmar");
                Console.WriteLine("2 - Cancelar");
                string opcao = Console.ReadLine();
                bool continuar = true;
                switch (opcao)
                {
                    case "1":
                        livros.Remove(LivroParaRemover);
                        Console.Clear();
                        Console.WriteLine("Livro removido com sucesso.");
                        Console.ReadLine();
                        break;
                    case "2":
                        continuar = false;
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        Console.ReadLine();
                        break;
                }
            }
            else
            {
                Console.WriteLine($"Livro com ID {id} não encontrado.");
                Console.ReadLine();
            }
            Console.Clear();
        }

        public void ConsultarLivroPorID()
        {
            Console.WriteLine("Digite o ID do livro que deseja encontrar:");
            int id = int.Parse(Console.ReadLine());

            Livro LivroConsultado = livros.Find(t => t.Id == id);

            if (LivroConsultado != null)
            {

                Console.WriteLine($"Livro encontrado: ID {LivroConsultado.Id}, Nome: {LivroConsultado.Titulo}, Autor: {LivroConsultado.Autor}, Data de publicação: {LivroConsultado.Ano}, ISBN: {LivroConsultado.Isbn}.");
            }
            else
            {
                Console.WriteLine($"Livro com ID {id} não encontrado.");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void ConsultarTodosLivros()
        {
            if (livros.Count == 0)
            {
                Console.WriteLine("Nenhum livro cadastrado.");
            }
            else
            {
                Console.WriteLine("Lista de livros:");
                foreach (var livro in livros)
                {
                    Console.WriteLine($"ID: {livro.Id}, Nome: {livro.Titulo}, Autor: {livro.Autor}, Data de publicação: {livro.Ano}, ISBN: {livro.Isbn}");
                }
            }
            Console.ReadLine();
            Console.Clear();
        }


        public void RealizarEmprestimo()
        {
            Console.WriteLine("Digite o ID do livro:");
            int livroID = int.Parse(Console.ReadLine());

            Livro livro = livros.Find(l => l.Id == livroID);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (!livro.Disponivel)
            {
                Console.WriteLine("Livro já está emprestado.");
                return;
            }

            livro.Disponivel = false;

            Console.WriteLine($"Empréstimo realizado com sucesso para o cliente.");
            Console.ReadLine();
            Console.Clear();
        }
        public void RealizarDevolucao()
        {
            Console.WriteLine("Digite o ID do livro que deseja devolver:");
            int livroID = int.Parse(Console.ReadLine());

            Livro livro = livros.Find(l => l.Id == livroID);

            if (livro == null)
            {
                Console.WriteLine("Livro não encontrado.");
                return;
            }

            if (livro.Disponivel)
            {
                Console.WriteLine("Este livro não está emprestado.");
                return;
            }

            livro.Disponivel = true;

            Console.WriteLine("Digite a data de devolução (dd/mm/aaaa):");
            DateTime dataDevolucao;
            if (!DateTime.TryParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dataDevolucao))
            {
                Console.WriteLine("Data inválida.");
                return;
            }

            TimeSpan atraso = DateTime.Now.Date - dataDevolucao.Date;
            if (atraso.TotalDays > 0)
            {
                Console.WriteLine($"Livro devolvido com atraso de {atraso.TotalDays} dia(s).");
            }
            else
            {
                Console.WriteLine("Livro devolvido no prazo.");
            }
            Console.ReadLine();
            Console.Clear();
        }
    }
}


