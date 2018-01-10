using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;

namespace SaudeEmNuvem.Cadastro.Infrastructure.EntityConfigurations
{
    public class TipoDocumentoEntityTypeConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public void Configure(EntityTypeBuilder<TipoDocumento> conf)
        {
            conf.ToTable("TipoDocumento", CadastroContext.DEFAULT_SCHEMA);

            conf.HasKey(x => x.Id);

            conf.Property(x => x.Id)
                .HasDefaultValue(0)
                .ValueGeneratedNever()
                .IsRequired();

            conf.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}