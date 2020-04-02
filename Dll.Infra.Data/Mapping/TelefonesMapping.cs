using Dll.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Infra.Data.Mapping
{
    public class TelefonesMapping : IEntityTypeConfiguration<Telefones>
    {
        public void Configure(EntityTypeBuilder<Telefones> builder)
        {

            builder.Property(e => e.Telefone)
                    .IsRequired()
                    .HasColumnType("varchar(11)")
                    .IsUnicode(false);

            builder.Property(e => e.Celular)
                    .IsRequired()
                    .HasColumnType("varchar(11)")
                    .IsUnicode(false);

            builder.HasOne(d => d.IdUsuaruioNavigation)
                    .WithMany(p => p.Telefones)
                    .HasForeignKey(d => d.IdUsuaruio)
                    .OnDelete(DeleteBehavior.ClientSetNull)

                    .HasConstraintName("fk_UsuarioTelefone");
            builder.Ignore(c => c.validateResult);
        }
    }
}
