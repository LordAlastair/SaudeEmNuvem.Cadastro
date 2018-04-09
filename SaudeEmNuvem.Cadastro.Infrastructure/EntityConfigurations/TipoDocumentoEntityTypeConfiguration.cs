using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;

namespace SaudeEmNuvem.Cadastro.Infrastructure.EntityConfigurations
{
    public class TipoDocumentoEntityTypeConfiguration : IEntityTypeConfiguration<TipoDocumento>
    {
        public static void Configure(EntityTypeBuilder<TipoDocumento> conf)
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

        void IEntityTypeConfiguration<TipoDocumento>
            .Configure(EntityTypeBuilder<TipoDocumento> builder) => Configure(builder);

    }
}
