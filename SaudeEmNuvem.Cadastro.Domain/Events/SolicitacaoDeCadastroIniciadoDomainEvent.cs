using MediatR;
using SaudeEmNuvem.Cadastro.Domain.AggregatesModel.PacienteAggregate;
using System;

namespace SaudeEmNuvem.Cadastro.Domain.Events
{
    public class CriarCadastroIniciadoDomainEvent : INotification
    {
        public CriarCadastroIniciadoDomainEvent(Paciente paciente, DateTime dataSolicitacao, string nomeAtendente)
        {
            Paciente = paciente;
            DataSolicitacao = dataSolicitacao;
            NomeAtendente = nomeAtendente;
        }

        public Paciente Paciente { get; }
        public DateTime DataSolicitacao { get; }
        public String NomeAtendente { get; }
    }
}
