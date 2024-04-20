using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TradeApp.Domain.Entities;

namespace TradeApp.Infrastructure.Config
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasKey(c => c.Id);
            builder.HasOne(c => c.Portfolio).WithOne(p => p.Client).OnDelete(DeleteBehavior.Cascade);
        }
    }
}