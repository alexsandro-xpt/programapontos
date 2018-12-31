using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Infra.EventStore.MongoDB
{
   public class MongoDBEventStoreSettings
    {
        public string ConnectionString { get; set; }
        public string DatabaseName { get; set; }
    }
}
