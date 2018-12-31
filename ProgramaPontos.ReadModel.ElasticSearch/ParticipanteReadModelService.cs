using Nest;
using ProgramaPontos.ReadModel.Core;
using ProgramaPontos.ReadModel.ElasticSearch.Extensions;
using ProgramaPontos.ReadModel.Participante;
using System;
using System.Linq;

namespace ProgramaPontos.ReadModel.ElasticSearch
{
    public class ParticipanteReadModelService : IParticipanteReadModelService
    {
        private readonly ElasticSearchContext context;

        public ParticipanteReadModelService(ElasticSearchContext context)
        {
            this.context = context;
        }

        public void AlterarNomeParticipante(Guid participanteId, string nome)
        {

            var participante = RetornarParticipanteReadModelPeloId(participanteId);
            participante.Nome = nome;

            var update = new UpdateRequest<ParticipanteReadModel, object>(participante);
            update.Doc = participante;
            var response = context.Client.Update(update);
            response.ThrowIfNotValid();

        }

        public void InserirParticipanteReadModel(ParticipanteReadModel participanteReadModel)
        {
            context.Client.IndexDocument(participanteReadModel)
                 .ThrowIfNotValid();



        }

        private ParticipanteReadModel RetornarParticipanteReadModelPeloId(Guid id)
        {
            var response = context.Client.Search<ParticipanteReadModel>(
               s => s.
                   Query(q => q
                       .Match(m => m
                           .Field(f => f.Id)
                           .Query(id.ToString())
                           .Operator(Nest.Operator.And)
                       )
                  )
               );

            response.ThrowIfNotValid();

            return response.Documents.FirstOrDefault();
        }

        public ParticipanteReadModel RetornarParticipanteReadModelPeloEmail(string email)
        {
            var response = context.Client.Search<ParticipanteReadModel>(
               s => s
                    
                   .Query(q => q
                        .QueryString(qs=>qs
                            .Query($"{nameof(ParticipanteReadModel.Email).ToLower()}:\"{email}\"")    
                       )
                  )
               );

            response.ThrowIfNotValid();

            return response.Documents.FirstOrDefault();
        }

        public void AlterarEmailParticipante(Guid participanteId, string email)
        {
            var participante = RetornarParticipanteReadModelPeloId(participanteId);
            participante.Email = email;

            var update = new UpdateRequest<ParticipanteReadModel, object>(participante);
            update.Doc = participante;
            var response = context.Client.Update(update);

            response.ThrowIfNotValid();
        }
    }
}
