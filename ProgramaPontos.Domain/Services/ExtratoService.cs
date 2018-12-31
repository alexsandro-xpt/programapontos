using ProgramaPontos.Domain.Aggregates.ExtratoAggregate;
using ProgramaPontos.Domain.Core.Events;
using ProgramaPontos.Domain.Core.Exceptions;
using ProgramaPontos.Domain.Repository;
using System;

namespace ProgramaPontos.Domain.Services
{
    public class ExtratoService : IExtratoService
    {
        private readonly IEventStoreService eventStoreService;
        private readonly IExtratoParticipanteRepository extratoRepository;

        public ExtratoService(
            IEventStoreService eventStoreService,
            IExtratoParticipanteRepository extratoRepository
            )
        {
            this.eventStoreService = eventStoreService;
            this.extratoRepository = extratoRepository;
        }

        public Extrato RetornarExtrato(Guid id)
        {
            return eventStoreService.LoadAggregate<Extrato>(id);
        }

        public void CriarExtrato(Guid extratoId, Guid participanteId)
        {

            if (extratoRepository.ExisteExtratoParticipante(participanteId))
                throw new DomainException("O participante já possui extrato.");

            var extrato = new Extrato(extratoId, participanteId);


            eventStoreService.SaveAggregate(extrato);
        }

        

        public void AdicionarPontos(Guid extratoId, int pontos)
        {
            var extrato = eventStoreService.LoadAggregate<Extrato>(extratoId);
            extrato.AdicionarPontos(pontos);
            eventStoreService.SaveAggregate(extrato);
        }

        public void RemoverPontos(Guid extratoId, int pontos)
        {
            var extrato = eventStoreService.LoadAggregate<Extrato>(extratoId);

            if (extrato.Saldo < pontos)
                throw new DomainException("Quantidade de pontos maior do que o saldo");

            extrato.RemoverPontos(pontos);
            eventStoreService.SaveAggregate(extrato);

        }

        public void EfetuarQuebraPontos(Guid extratoId, int pontos)
        {
            var extrato = eventStoreService.LoadAggregate<Extrato>(extratoId);
            extrato.EfetuarQuebra(pontos);
            eventStoreService.SaveAggregate(extrato);

        }



    }
}
