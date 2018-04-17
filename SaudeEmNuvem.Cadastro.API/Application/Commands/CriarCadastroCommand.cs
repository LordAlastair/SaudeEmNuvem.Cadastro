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
        public string Numero { get; private set; }

        [DataMember]
        public string Portaria { get; private set; }
        [DataMember]
        public string Pais { get; private set; }

        [DataMember]
        public DateTime DataEntrada { get; private set; }

        [DataMember]
        public DateTime? DataNaturalizacao { get; private set; }
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
        public int Medico { get; private set; }

        [DataMember]
        public DateTime Horario { get; private set; }

        [DataMember]
        public string Descricao { get; private set; }
        #endregion
        #region Meta
        public string ChaveNaturalPaciente { get; private set; }
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
        private readonly List<DocumentoDTO> _documentos;

        [DataMember]
        public IReadOnlyCollection<DocumentoDTO> Documentos => _documentos;

        [DataMember]
        private readonly List<EmailDTO> _emails;

        [DataMember]
        public IReadOnlyCollection<EmailDTO> Emails => _emails;

        [DataMember]
        private readonly List<TelefoneDTO> _telefones;

        [DataMember]
        public IReadOnlyCollection<TelefoneDTO> Telefones => _telefones;
        #endregion

        public CriarCadastroCommand()
        {
            _documentos = new List<DocumentoDTO>();
            _emails = new List<EmailDTO>();
            _telefones = new List<TelefoneDTO>();
        }

        public CriarCadastroCommand(string nome, string apelido, string nomeMae, string nomePai,
            DateTime dataNascimento, string municipioNascimento, string paisNascimento, bool? nomade,
            string numero, string portaria, string pais, DateTime dataEntrada, DateTime? dataNaturalizacao,
            string cep, int numeroEndereco, int chaveNaturalEtiniaIndigena, string etnia, int medico,
            DateTime horario, string descricao, string chaveNaturalPaciente, int nacionalidade,
            int tipoSanguineo, int cor, int sexo, List<DocumentoDTO> documentos, List<EmailDTO> emails,
            List<TelefoneDTO> telefones)
        {
            Nome = nome;
            Apelido = apelido;
            NomeMae = nomeMae;
            NomePai = nomePai;
            DataNascimento = dataNascimento;
            MunicipioNascimento = municipioNascimento;
            PaisNascimento = paisNascimento;
            Nomade = nomade;
            Numero = numero;
            Portaria = portaria;
            Pais = pais;
            DataEntrada = dataEntrada;
            DataNaturalizacao = dataNaturalizacao;
            Cep = cep;
            NumeroEndereco = numeroEndereco;
            ChaveNaturalEtiniaIndigena = chaveNaturalEtiniaIndigena;
            Etnia = etnia;
            Medico = medico;
            Horario = horario;
            Descricao = descricao;
            ChaveNaturalPaciente = chaveNaturalPaciente;
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
