using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System.Collections.Generic;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Paciente
        : Entity, IAggregateRoot
    {
        public Pessoa Pessoa { get; private set; }
        public Nacionalidade Nacionalidade { get; private set; }
        public Naturalidade Naturalidade { get; private set; }
        public Naturalizacao Naturalizacao { get; private set; }
        public TipoSanguineo TipoSanguineo { get; private set; }
        public Cor Cor { get; private set; }
        public Sexo Sexo { get; private set; }
        public Endereco Endereco { get; private set; }
        public EtiniaIndigena EtiniaIndigena { get; private set; }
        public Obito Obito { get; private set; }
        public Meta Meta { get; private set; }

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

        public Paciente(Pessoa pessoa, Nacionalidade nacionalidade, Naturalidade naturalidade, Naturalizacao naturalizacao,
            TipoSanguineo tipoSanguineo, Cor cor, Sexo sexo, Endereco endereco, EtiniaIndigena etiniaIndigena, Obito obito, Meta meta)
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
            Meta = meta;
        }

        //atributos criados proximo, falta adicionar as regras de negocio
    }
}
