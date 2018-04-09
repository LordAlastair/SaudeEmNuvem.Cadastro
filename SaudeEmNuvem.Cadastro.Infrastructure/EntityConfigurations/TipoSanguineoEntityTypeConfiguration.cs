using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;

namespace SaudeEmNuvem.Cadastro.Infrastructure.EntityConfigurations
{
    public class TipoSanguineoEntityTypeConfiguration : IEntityTypeConfiguration<TipoSanguineo>
    {
        public static void Configure(EntityTypeBuilder<TipoSanguineo> conf)
        {
            conf.ToTable("TipoSanguineo", CadastroContext.DEFAULT_SCHEMA);

            conf.HasKey(x => x.Id);

            conf.Property(x => x.Id)
                .HasDefaultValue(0)
                .ValueGeneratedNever()
                .IsRequired();

            conf.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }

        void IEntityTypeConfiguration<TipoSanguineo>
            .Configure(EntityTypeBuilder<TipoSanguineo> builder) => Configure(builder);

    }
}
