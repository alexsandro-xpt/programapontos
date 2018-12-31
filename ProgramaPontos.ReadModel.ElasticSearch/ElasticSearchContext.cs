using Nest;
using ProgramaPontos.ReadModel.Core;
using ProgramaPontos.ReadModel.ElasticSearch.Extensions;
using ProgramaPontos.ReadModel.Extrato;
using ProgramaPontos.ReadModel.Participante;
using System;

namespace ProgramaPontos.ReadModel.ElasticSearch
{
    public class ElasticSearchContext
    {
        private readonly ElasticSearchSettings settings;

        internal ElasticClient Client { get; }

        public ElasticSearchContext(ElasticSearchSettings settings)
        {

            this.settings = settings;
            var connectionSettings = new ConnectionSettings(new Uri(settings.Url));
            ApplyDefaultMappings(connectionSettings);

            Client = new ElasticClient(connectionSettings);

            CreateIndicesIfNotExists();
        }

        private void CreateIndicesIfNotExists()
        {
            CreateIndexIfNotExists<ParticipanteReadModel>();
            CreateIndexIfNotExists<ExtratoParticipanteReadModel>();
            CreateIndexIfNotExists<ExtratoParticipanteSaldoReadModel>();
        }

        private void CreateIndexIfNotExists<T>() where T : IReadModel
        {
            if (!Client.IndexExists(new IndexExistsRequest(GetIndexName<T>().Name)).Exists)
                Client.CreateIndex(GetIndexName<T>().Name);


        }

        private void ApplyDefaultMappings(ConnectionSettings connectionSettings)
        {

            connectionSettings.MappingFor<ParticipanteReadModel>();
            connectionSettings.MappingFor<ExtratoParticipanteReadModel>();
            connectionSettings.MappingFor<ExtratoParticipanteSaldoReadModel>();
        }

        public IndexName GetIndexName<T>() where T : IReadModel
        {
            return typeof(T).Name.ToLower();
        }

    }
}
