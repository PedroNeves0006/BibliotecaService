using BibliotecaService.Entidades;
using System;
using System.Collections.Generic;

namespace BibliotecaService.Entidades
{
    public class Emprestimo
    {
        public int Id { get; set; }
        public Usuario IdUsuario { get; set; }
        public Livro IdLivro { get; set; }
        public DateTime DataEmprestimo { get; set; }
        public DateTime? DataDevolucao { get; set; }

        public Emprestimo()
        {
        }

        public Emprestimo(Livro idLivro)
        {
            IdLivro = idLivro;
            DataEmprestimo = DateTime.Now;
            DataDevolucao = null;
        }
    }
}

