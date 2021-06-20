using System.Data.Entity;

namespace ProjetoMvcEntity.Models
{
    public class ClienteContext : DbContext
    {
        public ClienteContext() : base ("ClienteContext")
        {
            Database.SetInitializer<ClienteContext>(null);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tipo> Tipos { get; set; }
    }
}