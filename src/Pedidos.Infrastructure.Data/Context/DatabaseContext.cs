using Microsoft.EntityFrameworkCore;
using Pedidos.Domain.Models;
using Pedidos.Infrastructure.Data.Configuration;

namespace Pedidos.Infrastructure.Data.Context
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<Pedido> Pedidos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("PedidosDB");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PedidoConfiguration());
            modelBuilder.ApplyConfiguration(new ItemConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
