using System.Data.Entity;

namespace WebApiContatos.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("ContatoContext") { }

        public DbSet<Contato> Contatos { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }
    }
}