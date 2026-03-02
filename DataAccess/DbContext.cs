using System;
using Microsoft.EntityFrameworkCore;
using biblioteca.Models;

namespace biblioteca.DataAccess
{
    public class BibliotecaContext : DbContext
    {
        public BibliotecaContext(DbContextOptions<BibliotecaContext> options) : base(options) { }

        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Livro> Livros { get; set; }
        public DbSet<Reserva> Reservas { get; set; }
    }
}