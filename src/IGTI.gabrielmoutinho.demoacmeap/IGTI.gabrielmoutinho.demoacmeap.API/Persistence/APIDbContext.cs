using IGTI.gabrielmoutinho.demoacmeap.API.Models;
using Microsoft.EntityFrameworkCore;

namespace IGTI.gabrielmoutinho.demoacmeap.API.Persistence
{
    public class APIDbContext : DbContext
    {
        public APIDbContext(DbContextOptions<APIDbContext> options) : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Fatura> Faturas { get; set; }
        public DbSet<Instalacao> Instalacoes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Endereco>().HasKey(m => m.Id);
            builder.Entity<Cliente>().HasKey(m => m.Id);
            builder.Entity<Fatura>().HasKey(m => m.Id);
            builder.Entity<Instalacao>().HasKey(m => m.Id);

            builder.Entity<Cliente>().HasOne(c => c.Endereco);
            builder.Entity<Cliente>().HasMany(c => c.Instalacao).WithOne(i => i.Cliente).HasForeignKey("Id_Cliente");
            builder.Entity<Instalacao>().HasOne(i => i.Endereco);
            builder.Entity<Instalacao>().HasMany(i => i.Fatura).WithOne(f => f.Instalacao);

            base.OnModelCreating(builder);
        }
    }
}
