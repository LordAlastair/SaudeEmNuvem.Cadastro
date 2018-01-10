using SaudeEmNuvem.Cadastro.Domain.SeedWork;
using System;
using System.Collections.Generic;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;

namespace SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate
{
    public class Paciente
        : Entity, IAggregateRoot
    {
        private string _chaveNatural;
        private string _nome;
        private string _apelido;
        private string _nomeMae;
        private string _nomePai;
        private string _obito;
        private string _municipioNascimento;
        private string _pais;
        private bool? _nomade;
        private DateTime? _dataNascimento;

        public Nacionalidade Nacionalidade { get; private set; }
        public TipoSanguineo TipoSanguineo { get; private set; }
        public Cor Cor { get; private set; }
        public Sexo Sexo { get; private set; }
        public Endereco Endereco { get; private set; }
        public Naturalizacao Naturalizacao { get; private set; }

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

        public Paciente(string chaveNatural, string nome, string apelido, string nomeMae, string nomePai,
            string obito, string municipioNascimento, string pais, bool? nomade, DateTime? dataNascimento,
            Nacionalidade nacionalidade, TipoSanguineo tipoSanguineo, Cor cor, Sexo sexo, Endereco endereco,
            Naturalizacao naturalizacao)
        {
            _chaveNatural = chaveNatural;
            _nome = nome;
            _apelido = apelido;
            _nomeMae = nomeMae;
            _nomePai = nomePai;
            _obito = obito;
            _municipioNascimento = municipioNascimento;
            _pais = pais;
            _nomade = nomade;
            _dataNascimento = dataNascimento;
            Nacionalidade = nacionalidade;
            TipoSanguineo = tipoSanguineo;
            Cor = cor;
            Sexo = sexo;
            Endereco = endereco;
            Naturalizacao = naturalizacao;
        }

        //atributos criados proximo, falta adicionar as regras de negocio
    }
}
