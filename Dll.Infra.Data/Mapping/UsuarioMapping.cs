using Dll.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Infra.Data.Mapping
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {

            builder.OwnsOne(e => e.Cpf, cpf =>
                {
                    cpf.Property(x => x.Codigo)
                   .HasColumnName("CPF")
                    .IsRequired()
                    .HasColumnType("varchar(11)")
                    .IsUnicode(false);

                });

            builder.Property(e => e.Imagem)
                    .HasColumnType("varchar(100)");

            builder.Property(e => e.IdUser)
                    .IsRequired()
                    .HasMaxLength(450);

            builder.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_AspNetUsers");
            builder.Ignore(c => c.validateResult);
        }
    }
}
