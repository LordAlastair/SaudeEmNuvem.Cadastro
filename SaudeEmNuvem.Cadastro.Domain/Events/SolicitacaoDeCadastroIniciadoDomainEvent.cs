using System;
using MediatR;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;

namespace SaudeEmNuvem.Cadastro.Domain.Events
{
    public class SolicitacaoDeCadastroIniciadoDomainEvent : INotification
    {
        public SolicitacaoDeCadastroIniciadoDomainEvent(Paciente paciente, DateTime dataSolicitacao, string nomeAtendente)
        {
            Paciente = paciente;
            DataSolicitacao = dataSolicitacao;
            NomeAtendente = nomeAtendente;
        }

        public Paciente Paciente { get; private set; }
        public DateTime DataSolicitacao { get; private set; }
        public String NomeAtendente { get; private set; }
    }
}
