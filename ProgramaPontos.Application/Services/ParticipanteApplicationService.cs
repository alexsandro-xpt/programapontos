
using ProgramaPontos.Application.CommandStack.AggregateCommands.Participante.Commands;
using ProgramaPontos.Application.CommandStack.Core;
using ProgramaPontos.Application.DTO;
using ProgramaPontos.Application.Extensions;
using ProgramaPontos.Application.Services.Interfaces;
using ProgramaPontos.ReadModel.Core;
using System;
using System.Threading.Tasks;

namespace ProgramaPontos.Application.Services
{
    public class ParticipanteApplicationService : IParticipanteApplicationService
    {
        private readonly ICommandBus commandBus;
        private readonly IParticipanteReadModelService participanteReadModelService;

        public ParticipanteApplicationService(ICommandBus commandBus,
            IParticipanteReadModelService participanteReadModelService
            )
        {
            this.commandBus = commandBus;
            this.participanteReadModelService = participanteReadModelService;
        }
        public Task<Resultado> CriarParticipante(ParticipanteDTO participante)
        {
            return commandBus.EnviarCommandoRetornaResultadoAsync(new CriarParticipanteCommand(participante.Id, participante.Nome, participante.Email));
        }

        public Task<Resultado> AlterarNomeParticipante(Guid participanteId, string nome)
        {
            return commandBus.EnviarCommandoRetornaResultadoAsync(new AlterarNomeParticipanteCommand(participanteId, nome));
        }

        public Task<Resultado<ParticipanteDTO>> RetornarParticipantePorEmail(string email)
        {

            return Task.Run(() =>
            {
                var participante = participanteReadModelService.RetornarParticipanteReadModelPeloEmail(email);

                if (participante == null)
                    return new Resultado<ParticipanteDTO>(default(ParticipanteDTO));

                var resultado = new ParticipanteDTO()
                {
                    Id = participante.Id,
                    Nome = participante.Nome,
                    Email = participante.Email
                };

                return new Resultado<ParticipanteDTO>(resultado);


            });

        }

        public Task<Resultado> AlterarEmailParticipante(Guid participanteId, string email)
        {
            return commandBus.EnviarCommandoRetornaResultadoAsync(new AlterarEmailParticipanteCommand(participanteId, email));
        }
    }
}
