using CopyData.Models.PostgreSQL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CopyData.Mapping.PostgreSQL
{
    public class ContatoMap : IEntityTypeConfiguration<Contato>
    {

        public void Configure(EntityTypeBuilder<Contato> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Nome).HasColumnName("nome").HasMaxLength(200);
            builder.Property(x => x.Telefone).HasColumnName("telefone").HasMaxLength(200);
            builder.Property(x => x.Email).HasColumnName("email").HasMaxLength(200);
            builder.ToTable("contatos");
        }
    }
}
