using Dll.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Dll.Infra.Data.Mapping
{
    public class LogMapping : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.Property(e => e.DataLog).HasColumnType("datetime");

            builder.Property(e => e.Descricao)
                    .HasColumnType("varchar(1000)")
                    .IsRequired()
                    .IsUnicode(false);

            builder.Property(e => e.IP)
                    .HasColumnType("varchar(50)")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

            builder.Property(e => e.Navegador)
                    .HasColumnType("varchar(50)")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
        }
    }
}
