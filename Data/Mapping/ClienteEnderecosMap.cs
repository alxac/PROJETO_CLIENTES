using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Data.Mapping
{
    public class ClienteEnderecosMap : IEntityTypeConfiguration<ClienteEnderecos>
    {
        public void Configure(EntityTypeBuilder<ClienteEnderecos> builder)
        {
            builder.Property(e => e.DatInclusao).HasDefaultValueSql("(getdate())");

            builder.HasOne(d => d.IdClienteNavigation)
                .WithMany(p => p.ClienteEnderecos)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CLIENTE_CLIENTE_ENDERECOS");
        }
    }
}
