using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using SaudeEmNuvem.Cadastro.API.Infrastructure.Services;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using SaudeEmNuvem.Cadastro.Infrastructure.Idempotency;

namespace SaudeEmNuvem.Cadastro.API.Application.Commands.Handler
{
    public class CriarCadastroCommandHandler
        : IRequestHandler<CriarCadastroCommand, bool>
    {
        private readonly IPacienteRepository _pacienteRepository;
        private readonly IIdentityService _identityService;
        private readonly IMediator _mediator;

        public CriarCadastroCommandHandler(IPacienteRepository pacienteRepository, IMediator mediator,
            IIdentityService identityService)
        {
            _pacienteRepository = pacienteRepository ?? throw new ArgumentNullException(nameof(pacienteRepository));
            _identityService = identityService ?? throw new ArgumentNullException(nameof(identityService));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        public async Task<bool> Handle(CriarCadastroCommand command, CancellationToken cancellationToken)
        {

            var pessoa = new Pessoa(command.Nome, command.Apelido, command.NomeMae, command.NomePai,
                command.DataNascimento);
            var naturalidade = new Naturalidade(command.MunicipioNascimento, command.PaisNascimento, command.Nomade);
            var naturalizacao = new Naturalizacao(command.NumeroNaturalizacao, command.Portaria, command.PaisOrigem,
                command.DataEntradaPais, command.DataNaturalizacaoPais);
            var endereco = new Endereco(command.Cep, command.NumeroEndereco);
            var etiniaIndigena = new EtiniaIndigena(command.ChaveNaturalEtiniaIndigena, command.Etnia);
            var obito = new Obito(command.Medico, command.HorarioObito, command.DescricaoObito);
            var nacionalidade = Nacionalidade.BuscarPeloCodigo(command.Nacionalidade);
            var tipoSanguineo = TipoSanguineo.BuscarPeloCodigo(command.TipoSanguineo);
            var cor = Cor.BuscarPeloCodigo(command.Cor);
            var sexo = Sexo.BuscarPeloCodigo(command.Sexo);

            var telefones = command.Telefones.Select(telefone => new Telefone(telefone.Ddd,
                telefone.Numero, TipoTelefone.BuscarPeloCodigo(telefone.TipoTelefone))).ToList();

            var documentos = (List<Documento>)command.Documentos.Select(documento =>
                new Documento(TipoDocumento.BuscarPeloCodigo(documento.TipoDocumento), documento.NumeroDocumento,
                    documento.Image, documento.Meta)).ToList();

            var emails = command.Emails.Select(email => new Email(email.EnderecoEmail, email.Principal)).ToList();

            var paciente = new Paciente(pessoa, nacionalidade, naturalidade, naturalizacao, tipoSanguineo,
                cor, sexo, endereco, etiniaIndigena, obito, documentos, emails, telefones);

            _pacienteRepository.Adicionar(paciente);

            return await _pacienteRepository.UnitOfWork
                .SaveEntitiesAsync(cancellationToken);
        }

        public class CriarCadastroIdentificadorDeComandoHandler : IdentificadorDeComandosHandler<CriarCadastroCommand, bool>
        {
            public CriarCadastroIdentificadorDeComandoHandler(IMediator mediator, IRequestManager requestManager) : base(mediator, requestManager)
            {
            }

            protected override bool RespostaParaRequisicaoDuplicada()
            {
                return true;
            }
        }
    }
}
