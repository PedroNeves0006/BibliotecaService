using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaService.Entidades
{
    public class Usuario : Livro
    {
        public string Nome { get; set; }
        public int Id { get; private set; }
        public string Email { get; set; }
        private int proximoID = 1;
        public bool Disponivel { get; set; }
        public List<Usuario> usuarios = new List<Usuario>();
        public Usuario()
        {
            this.Id = proximoID;
            proximoID++;
            Disponivel = true;
        }

        public void CadastrarUsuario()
        {
            Usuario usuario = new Usuario();

            Console.WriteLine("informe os dados do usuario para cadastro: ");
            Console.Write("Nome: ");
            usuario.Nome = Console.ReadLine();
            Console.Write("Id: ");
            usuario.Id = int.Parse(Console.ReadLine());
            Console.Write("Email: ");
            usuario.Email = Console.ReadLine();

            while (usuarios.Any(c => c.Id == usuario.Id))
            {
                Console.WriteLine("ID já existe. Digite outro ID:");
                usuario.Id = int.Parse(Console.ReadLine());
            }

            usuarios.Add(usuario);

            Console.WriteLine($"Usuário cadastrado com sucesso! ID: {usuario.Id}");
            Console.ReadLine();
            Console.Clear();
        }

        public void RemoverUsuario()
        {
            Console.WriteLine("Digite o ID do usuário que deseja remover:");
            int id = int.Parse(Console.ReadLine());

            Usuario UsuarioParaRemover = usuarios.Find(t => t.Id == id);
            Console.Clear();
            if (UsuarioParaRemover != null)
            {
                Console.WriteLine($"ID: {UsuarioParaRemover.Id}, Nome: {UsuarioParaRemover.Nome}, Email: {UsuarioParaRemover.Email}");
                Console.WriteLine("Pressione: ");
                Console.WriteLine("1 - Confirmar");
                Console.WriteLine("2 - Cancelar");
                string opcao = Console.ReadLine();
                bool continuar = true;
                switch (opcao)
                {
                    case "1":
                        usuarios.Remove(UsuarioParaRemover);
                        Console.Clear();
                        Console.WriteLine("Usuário removido com sucesso.");
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

        public void ConsultarUsuarioPorID()
        {
            Console.WriteLine("Digite o ID do usuário que deseja encontrar:");
            int id = int.Parse(Console.ReadLine());

            Usuario UsuarioConsultado = usuarios.Find(t => t.Id == id);

            if (UsuarioConsultado != null)
            {

                Console.WriteLine($"Usuário encontrado: ID {UsuarioConsultado.Id}, Nome: {UsuarioConsultado.Nome}, Email: {UsuarioConsultado.Email}");
            }
            else
            {
                Console.WriteLine($"Usuário com ID {id} não encontrado.");
            }

            Console.ReadLine();
            Console.Clear();
        }

        public void ConsultarTodosUsuarios()
        {
            if (usuarios.Count == 0)
            {
                Console.WriteLine("Nenhum usuário cadastrado.");
            }
            else
            {
                Console.WriteLine("Lista de usuários:");
                foreach (var usuario in usuarios)
                {
                    Console.WriteLine($"ID: {usuario.Id}, Nome: {usuario.Nome}, Email: {usuario.Email}");
                }
            }
            Console.ReadLine();
            Console.Clear();
        }


    }
}


