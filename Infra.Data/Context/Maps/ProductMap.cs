using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Context.Maps
{
    public class ProductMap : IEntityTypeConfiguration<Product>
    {

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Produto");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IDProduto")
                 .ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
              .HasColumnName("Nome");

            builder.Property(x => x.CodeERP)
                .HasColumnName("CodeErp");

            builder.Property(x => x.Price)
               .HasColumnName("Preco");

            //mapear tipo de relacionamento entre as tabelas produto e compras 1:1, 1:N, N:N 

            builder.HasMany(x => x.Purchases)
                .WithOne(p => p.Product)
                .HasForeignKey(x => x.ProductID); 
        }
    }
}
