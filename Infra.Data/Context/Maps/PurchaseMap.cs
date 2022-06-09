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

    public class PurchaseMap : IEntityTypeConfiguration<Purchase>
    {

        public void Configure(EntityTypeBuilder<Purchase> builder)
        {
            builder.ToTable("Compra");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                .HasColumnName("IdCompra")
                 .ValueGeneratedOnAdd();

            builder.Property(x => x.PersonID)
              .HasColumnName("Idpessoa");

            builder.Property(x => x.ProductID)
                .HasColumnName("Idproduto");

            builder.Property(x => x.Date)
               .HasColumnName("Data");



            builder.HasOne(x => x.Person)
                .WithMany(x => x.Purchases);

            builder.HasOne(x => x.Product)
               .WithMany(x => x.Purchases);
        }
    }
}
