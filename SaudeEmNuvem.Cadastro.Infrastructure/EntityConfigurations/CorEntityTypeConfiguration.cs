using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;

namespace SaudeEmNuvem.Cadastro.Infrastructure.EntityConfigurations
{
    public class CorEntityTypeConfiguration : IEntityTypeConfiguration<Cor>
    {
        public static void Configure(EntityTypeBuilder<Cor> conf)
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

        void IEntityTypeConfiguration<Cor>.Configure(EntityTypeBuilder<Cor> builder) => Configure(builder);
    }
}
