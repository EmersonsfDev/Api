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
    public class PersonMap: IEntityTypeConfiguration <Person>
    {
        //mapear tabela do banco de dados
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Pessoa");
            
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id)
                   .HasColumnName("IDPessoa")
                   .ValueGeneratedOnAdd();
           
            builder.Property(x => x.Name)
                .HasColumnName("Nome");

            builder.Property(x => x.Document)
                .HasColumnName("Documento");

            builder.Property(x => x.Phone)
                .HasColumnName("Phone");

            //mapear tipo de relacionamento entre as tabelas pessoas e compras 1:1, 1:N, N:N 

            builder.HasMany(x => x.Purchases)
                .WithOne(p => p.Person)
                .HasForeignKey(x=> x.PersonID);


        }
    }
}
