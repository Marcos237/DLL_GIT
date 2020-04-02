using Dll.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Infra.Data.Mapping
{
    public class EnderecoMapping : IEntityTypeConfiguration<Endereco>
    {
        public void Configure(EntityTypeBuilder<Endereco> builder)
        {

            builder.Property(e => e.Cep)
                    .IsRequired()
                    .HasColumnType("varchar(8)")
                    .IsUnicode(false);

            builder.Property(e => e.Logradouro)
                    .IsRequired()
                    .HasColumnType("varchar(250)")
                    .IsUnicode(false);

            builder.HasOne(d => d.IdUsuaruioNavigation)
                    .WithMany(p => p.Endereco)
                    .HasForeignKey(d => d.IdUsuaruio)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fk_UsuarioEndereco");
        }
    }
}
