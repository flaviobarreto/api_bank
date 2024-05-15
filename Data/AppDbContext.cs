using api_bank.Models;
using Microsoft.EntityFrameworkCore;

namespace api_bank.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Ativo> Ativos  { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<ClienteAtivo> ClienteAtivos{ get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
            => optionsBuilder.UseSqlite(connectionString: "DataSource=app.db;Cache=Shared");
    }
}
