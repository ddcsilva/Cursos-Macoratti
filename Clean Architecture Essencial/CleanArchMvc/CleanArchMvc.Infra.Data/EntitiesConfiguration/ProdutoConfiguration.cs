using CleanArchMvc.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchMvc.Infra.Data.EntitiesConfiguration
{
    public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(p => p.Nome).HasMaxLength(100).IsRequired();
            builder.Property(p => p.Descricao).HasMaxLength(200).IsRequired();

            builder.Property(p => p.Preco).HasPrecision(10, 2);

            builder.HasOne(p => p.Categoria).WithMany(p => p.Produtos).HasForeignKey(p => p.CategoriaId);
        }
    }
}
