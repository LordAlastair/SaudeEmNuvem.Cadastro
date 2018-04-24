using MediatR;
using SaudeEmNuvem.Cadastro.API.Dto;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SaudeEmNuvem.Cadastro.API.Application.Commands
{
    public class CriarCadastroCommand : IRequest<bool>
    {
        #region Pessoa
        [DataMember]
        public string Nome { get; private set; }

        [DataMember]
        public string Apelido { get; private set; }

        [DataMember]
        public string NomeMae { get; private set; }

        [DataMember]
        public string NomePai { get; private set; }

        [DataMember]
        public DateTime DataNascimento { get; private set; }
        #endregion
        #region Naturalidade
        [DataMember]
        public string MunicipioNascimento { get; private set; }

        [DataMember]
        public string PaisNascimento { get; private set; }

        [DataMember]
        public bool? Nomade { get; private set; }
        #endregion
        #region Naturalizacao
        [DataMember]
        public string NumeroNaturalizacao { get; private set; }

        [DataMember]
        public string Portaria { get; private set; }
        [DataMember]
        public string PaisOrigem { get; private set; }

        [DataMember]
        public DateTime DataEntradaPais { get; private set; }

        [DataMember]
        public DateTime? DataNaturalizacaoPais { get; private set; }
        #endregion
        #region Endereco
        [DataMember]
        public string Cep { get; private set; }

        [DataMember]
        public int NumeroEndereco { get; private set; }
        #endregion
        #region EtiniaIndigena
        [DataMember]
        public int ChaveNaturalEtiniaIndigena { get; private set; }

        [DataMember]
        public string Etnia { get; private set; }
        #endregion
        #region Obito
        [DataMember]
        public string Medico { get; private set; }

        [DataMember]
        public DateTime HorarioObito { get; private set; }

        [DataMember]
        public string DescricaoObito { get; private set; }
        #endregion
        #region Enumerations
        [DataMember]
        public int Nacionalidade { get; private set; }

        [DataMember]
        public int TipoSanguineo { get; private set; }

        [DataMember]
        public int Cor { get; private set; }

        [DataMember]
        public int Sexo { get; private set; }
        #endregion
        #region Listas de VOs
        [DataMember]
        private readonly List<DocumentoDto> _documentos;

        [DataMember]
        public IReadOnlyCollection<DocumentoDto> Documentos => _documentos;

        [DataMember]
        private readonly List<EmailDto> _emails;

        [DataMember]
        public IReadOnlyCollection<EmailDto> Emails => _emails;

        [DataMember]
        private readonly List<TelefoneDto> _telefones;

        [DataMember]
        public IReadOnlyCollection<TelefoneDto> Telefones => _telefones;
        #endregion

        public CriarCadastroCommand()
        {
            _documentos = new List<DocumentoDto>();
            _emails = new List<EmailDto>();
            _telefones = new List<TelefoneDto>();
        }

        public CriarCadastroCommand(string nome, string apelido, string nomeMae, string nomePai,
            DateTime dataNascimento, string municipioNascimento, string paisNascimento, bool? nomade,
            string numero, string portaria, string pais, DateTime dataEntrada, DateTime? dataNaturalizacao,
            string cep, int numeroEndereco, int chaveNaturalEtiniaIndigena, string etnia, string medico,
            DateTime horario, string descricao, int nacionalidade, int tipoSanguineo, int cor, int sexo,
            List<DocumentoDto> documentos, List<EmailDto> emails, List<TelefoneDto> telefones)
        {
            Nome = nome;
            Apelido = apelido;
            NomeMae = nomeMae;
            NomePai = nomePai;
            DataNascimento = dataNascimento;
            MunicipioNascimento = municipioNascimento;
            PaisNascimento = paisNascimento;
            Nomade = nomade;
            NumeroNaturalizacao = numero;
            Portaria = portaria;
            PaisOrigem = pais;
            DataEntradaPais = dataEntrada;
            DataNaturalizacaoPais = dataNaturalizacao;
            Cep = cep;
            NumeroEndereco = numeroEndereco;
            ChaveNaturalEtiniaIndigena = chaveNaturalEtiniaIndigena;
            Etnia = etnia;
            Medico = medico;
            HorarioObito = horario;
            DescricaoObito = descricao;
            Nacionalidade = nacionalidade;
            TipoSanguineo = tipoSanguineo;
            Cor = cor;
            Sexo = sexo;
            _documentos = documentos;
            _emails = emails;
            _telefones = telefones;
        }
    }
}
