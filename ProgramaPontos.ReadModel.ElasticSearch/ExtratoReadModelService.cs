using Nest;
using ProgramaPontos.ReadModel.Core;
using ProgramaPontos.ReadModel.ElasticSearch.Extensions;
using ProgramaPontos.ReadModel.Extrato;
using System;
using System.Linq;

namespace ProgramaPontos.ReadModel.ElasticSearch
{
    public class ExtratoReadModelService : IExtratoReadModelService
    {
        private readonly ElasticSearchContext context;

        public ExtratoReadModelService(ElasticSearchContext context)
        {
            this.context = context;

        }



        public void InserirExtratoReadModel(ExtratoParticipanteReadModel extratoParticipanteReadModel)
        {


            context.Client.IndexDocument(extratoParticipanteReadModel)
                .ThrowIfNotValid();

        }

        public void AdicionarPontosExtrato(Guid extratoId, DateTime data, int pontos)
        {
            AdicionarMovimentacao(extratoId, data, pontos, "Pontos adicionados");
        }
        public void QuebraPontosExtrato(Guid extratoId, DateTime data, int pontos)
        {
            AdicionarMovimentacao(extratoId, data, pontos, "Quebra de pontos");
        }

        private void AdicionarMovimentacao(Guid extratoId, DateTime data, int pontos, string tipo)
        {
            var extrato = RetornarExtrato(extratoId);
            extrato.Movimentacoes.Add(new MovimentacaoExtratoReadModel()
            {
                Data = data,
                Pontos = pontos,
                Tipo = tipo
            });

            AtualizarMovimentacaoExtrato(extrato);
        }


        public void AtualizarSaldoExtratoParticipante(Guid extratoId, int saldo)
        {
            var saldoParticipante = RetornarSaldoExtratoParticipante(extratoId);

            saldoParticipante.Saldo = saldo;

            var update = new UpdateRequest<ExtratoParticipanteSaldoReadModel, object>(saldoParticipante);
            update.Doc = new { saldoParticipante.Saldo };

            var response = context.Client.Update(update);
            response.ThrowIfNotValid();


        }
        private void AtualizarMovimentacaoExtrato(ExtratoParticipanteReadModel extrato)
        {

            var update = new UpdateRequest<ExtratoParticipanteReadModel, object>(extrato);
            update.Doc = extrato;

            var response = context.Client.Update(update);
            response.ThrowIfNotValid();
        }
    

        private void InserirSaldoParticipante(Guid extratoId, Guid participanteId, int saldo)
        {
            var indexResponse = context.Client.IndexDocument(new ExtratoParticipanteSaldoReadModel()
            {
                Id = Guid.NewGuid(),
                ParticipanteId = participanteId,
                ExtratoId = extratoId,
                Saldo = saldo
            });

            indexResponse.ThrowIfNotValid();
        }

        private ExtratoParticipanteSaldoReadModel RetornarSaldoExtratoParticipante(Guid participanteId)
        {
            var searchResponse = context.Client.Search<ExtratoParticipanteSaldoReadModel>(s => s
                          .Query(q => q
                              .Match(m => m
                                  .Field(f => f.ExtratoId)
                                  .Query(participanteId.ToString())
                                  .Operator(Operator.And)
                              )
                          )
                       );

            searchResponse.ThrowIfNotValid();

            return searchResponse.Documents.FirstOrDefault();
        }

        

        public void RemoverPontosExtrato(Guid aggregateId, DateTime data, int pontos)
        {
            AdicionarMovimentacao(aggregateId, data, pontos, "Pontos removidos");
        }

        public ExtratoParticipanteReadModel RetornarExtrato(Guid extratoId)
        {
            var response = context.Client.Search<ExtratoParticipanteReadModel>(
                          s => s
                              .Query(q => q
                                  .Match(m => m
                                      .Field(f => f.ExratoId)
                                      .Query(extratoId.ToString())
                                      .Operator(Nest.Operator.And)
                                   )
                              )

                          );


            response.ThrowIfNotValid();

            if (response.Documents.Count == 0)
                return null;

            return response.Documents.First();

        }

        public Guid? RetornarIdExtrato(Guid participanteId)
        {



            var response = context.Client.Search<ExtratoParticipanteReadModel>(
                            s => s
                                .Query(q => q
                                    .Match(m => m
                                        .Field(f => f.ParticipanteId)
                                        .Query(participanteId.ToString())
                                        .Operator(Nest.Operator.And)
                                     )
                                )

                            );


            response.ThrowIfNotValid();

            if (response.Documents.Count == 0)
                return null;

            return response.Documents.First().ExratoId;


        }

        

        public void InserirExtratoParticipanteSaldoReadModel(ExtratoParticipanteSaldoReadModel extratoParticipanteSaldoReadModel)
        {
            var response = context.Client.IndexDocument(extratoParticipanteSaldoReadModel);

            response.ThrowIfNotValid();
        }

        public int RetornarSaldoParticipante(Guid participanteId)
        {
            var response = context.Client.Search<ExtratoParticipanteSaldoReadModel>(
                s => s
                    .Query(q => q
                        .Match(m => m
                            .Field(f => f.ParticipanteId)
                            .Query(participanteId.ToString())
                            .Operator(Operator.And)
                        )
                    )
                );

            response.ThrowIfNotValid();

            if (response.Documents.Count == 0)
                throw new Exception("Participante sem saldo criado");

            return response.Documents.First().Saldo;
        }
    }
}
