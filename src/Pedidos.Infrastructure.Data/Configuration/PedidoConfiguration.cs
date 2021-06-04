using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Pedidos.Domain.Models;

namespace Pedidos.Infrastructure.Data.Configuration
{
    public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
    {
        public void Configure(EntityTypeBuilder<Pedido> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasMany(x => x.Itens).WithOne()
                .HasForeignKey(x => x.PedidoId);
        }
    }
}
