using API.Sistema.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace API.Sistema.Infra.CrossCutting.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasKey(u => u.Id);

           builder.HasIndex(c => c.CPF)
            .IsUnique();

           builder.Property(c => c.CPF)
                .IsRequired().HasMaxLength(15);

            builder.Property(c => c.Nome).IsRequired()
            .HasMaxLength(50);

            builder.Property(c => c.UF).IsRequired()
            .HasMaxLength(2);

            builder.Property(c => c.OrGaoExpedicao).IsRequired()
                .HasMaxLength(10);

            builder.Property(c => c.DataExpedicao).IsRequired();

            builder.Property(c => c.DataNascimento).IsRequired();

            builder.Property(c => c.Sexo).IsRequired()
           .HasMaxLength(10);

            builder.Property(c => c.EstadoCivil).IsRequired()
            .HasMaxLength(15);

            builder
           .HasOne(e => e.Endereco)
           .WithOne(e => e.Usuario)
           .HasForeignKey<Endereco>(e => e.IdUsuario)
           .IsRequired().Metadata.DeleteBehavior = DeleteBehavior.Cascade;
        }
    }
}
