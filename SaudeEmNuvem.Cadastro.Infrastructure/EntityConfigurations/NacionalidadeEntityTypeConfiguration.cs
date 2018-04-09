using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;

namespace SaudeEmNuvem.Cadastro.Infrastructure.EntityConfigurations
{
    public class NacionalidadeEntityTypeConfiguration : IEntityTypeConfiguration<Nacionalidade>
    {
        public static void Configure(EntityTypeBuilder<Nacionalidade> conf)
        {
            conf.ToTable("Cor", CadastroContext.DEFAULT_SCHEMA);

            conf.HasKey(x => x.Id);

            conf.Property(x => x.Id)
                .HasDefaultValue(0)
                .ValueGeneratedNever()
                .IsRequired();

            conf.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();
        }

        void IEntityTypeConfiguration<Nacionalidade>
            .Configure(EntityTypeBuilder<Nacionalidade> builder) => Configure(builder);
    }
}
