using System;
using System.Collections.Generic;
using System.Text;

namespace ProgramaPontos.Infra.Bus.EventBusRabbitMQ.Core
{
    public class RabbitMQSettings
    {
        public string Hostname { get; set; }
        public string Queue { get; set; }
 
    }
}
