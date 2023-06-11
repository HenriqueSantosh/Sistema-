using API.Sistema.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace API.Sistema.Infra.CrossCutting.Data.Mappings
{
    public class EnderecoMap : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {
            builder.HasKey(u => u.Id);

            builder.Property(c => c.Cep).IsRequired()
            .HasMaxLength(9);

            builder.Property(c => c.UF).IsRequired()
            .HasMaxLength(2);

            builder.Property(c => c.Bairro).IsRequired()
            .HasMaxLength(50);

            builder.Property(c => c.Logradouro).IsRequired()
               .HasMaxLength(100);

            builder.Property(c => c.Cidade).IsRequired()
               .HasMaxLength(100);

            builder.Property(c => c.Complemento).IsRequired()
               .HasMaxLength(10);

            builder.Property(c => c.Numero).
                HasMaxLength(6).IsRequired();

            builder
          .HasOne(e => e.Usuario)
          .WithOne(e => e.Endereco)
          .HasForeignKey<Endereco>(e => e.IdUsuario)
          .IsRequired().Metadata.DeleteBehavior = DeleteBehavior.Cascade;

        }
    }
}
