using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Paciente
        : Entity, IAggregateRoot
    {
        public Pessoa Pessoa { get; }
        public Nacionalidade Nacionalidade { get; }
        public Naturalidade Naturalidade { get; }
        public Naturalizacao Naturalizacao { get; }
        public TipoSanguineo TipoSanguineo { get; }
        public Cor Cor { get; }
        public Sexo Sexo { get; }
        public Endereco Endereco { get; }
        public EtiniaIndigena EtiniaIndigena { get; }
        public Obito Obito { get; }
        public Meta Meta { get; }

        //https://visualstudiomagazine.com/articles/2015/06/03/c-sharp-6-expression-bodied-properties-dictionary-initializer.aspx
        private readonly List<Documento> _documentos;
        public IReadOnlyCollection<Documento> Documentos => _documentos;

        private readonly List<Email> _emails;
        public IReadOnlyCollection<Email> Emails => _emails;

        private readonly List<Telefone> _telefones;
        public IReadOnlyCollection<Telefone> Telefones => _telefones;

        protected Paciente()
        {
            _emails = new List<Email>();
            _telefones = new List<Telefone>();
            _documentos = new List<Documento>();
        }

        public Paciente(Pessoa pessoa, Nacionalidade nacionalidade,
            Naturalidade naturalidade, Naturalizacao naturalizacao,
            TipoSanguineo tipoSanguineo, Cor cor, Sexo sexo, Endereco endereco,
            EtiniaIndigena etiniaIndigena, Obito obito, List<Documento> documentos,
            List<Email> emails, List<Telefone> telefones)
        {
            Pessoa = pessoa;
            Nacionalidade = nacionalidade;
            Naturalidade = naturalidade;
            Naturalizacao = naturalizacao;
            TipoSanguineo = tipoSanguineo;
            Cor = cor;
            Sexo = sexo;
            Endereco = endereco;
            EtiniaIndigena = etiniaIndigena;
            Obito = obito;
            _documentos = documentos;
            _emails = emails;
            _telefones = telefones;
        }


        //atributos criados, falta adicionar as regras de negocio
    }
}
