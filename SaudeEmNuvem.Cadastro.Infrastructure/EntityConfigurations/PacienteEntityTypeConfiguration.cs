using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using System;

namespace SaudeEmNuvem.Cadastro.Infrastructure.EntityConfigurations
{
    public class PacienteEntityTypeConfiguration : IEntityTypeConfiguration<Paciente>
    {
        public void Configure(EntityTypeBuilder<Paciente> conf)
        {
            conf.ToTable("paciente", CadastroContext.DEFAULT_SCHEMA);

            conf.HasKey(x => x.Id);

            conf.Ignore(x => x.DomainEvents);

            conf.Property(o => o.Id)
                .ForSqlServerUseSequenceHiLo("pacienteSeq", CadastroContext.DEFAULT_SCHEMA);

            conf.Property(x => x.Id)
                .HasDefaultValue(0)
                .ValueGeneratedNever()
                .IsRequired();

            conf.Property<string>("ChaveNatural").IsRequired(false);
            conf.Property<string>("Nome").IsRequired();
            conf.Property<string>("Apelido").IsRequired(false);
            conf.Property<string>("NomePai").IsRequired(false);
            conf.Property<string>("NomeMae").IsRequired(false);
            conf.Property<string>("Obito").IsRequired(false);
            conf.Property<string>("MunicipioNascimento").IsRequired(false);
            conf.Property<string>("PaisNascimento").IsRequired(false);
            conf.Property<bool>("Nomade").IsRequired(false);
            conf.Property<DateTime>("DataNascimento").IsRequired();

            conf.HasOne(x => x.Cor).WithOne().HasForeignKey("CorId").IsRequired(false);
            conf.HasMany(x => x.Documentos).WithOne().HasForeignKey("DocumentoId").IsRequired(false);
            conf.HasMany(x => x.Emails).WithOne().HasForeignKey("EmailId").IsRequired(false);
            conf.HasOne(x => x.Endereco).WithOne().HasForeignKey("EnderecoId").IsRequired(false);
            conf.HasOne(x => x.EtiniaIndigena).WithOne().HasForeignKey("EtiniaIndigenaId").IsRequired(false);
            conf.HasOne(x => x.Nacionalidade).WithOne().HasForeignKey("NacionalidadeId").IsRequired(false);
            conf.HasOne(x => x.Naturalizacao).WithOne().HasForeignKey("NaturalizacaoId").IsRequired(false);
            conf.HasOne(x => x.Sexo).WithOne().HasForeignKey("SexoId").IsRequired(false);
            conf.HasMany(x => x.Telefones).WithOne().HasForeignKey("TelefonesId").IsRequired(false);
            conf.HasOne(x => x.TipoSanguineo).WithOne().HasForeignKey("TipoSanguineoId").IsRequired(false);
        }
    }
}
