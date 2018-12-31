using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ProgramaPontos.Domain.Core.Events;
using ProgramaPontos.EventHandler.Sinc;
using ProgramaPontos.Infra.Bus.EventBusRabbitMQ.Core;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading.Tasks;

namespace ProgramaPontos.Infra.Bus.EventBusRabbitMQ
{
    public class RabbitMQEventBus : IEventBus
    {
        private readonly RabbitMQSettings settings;

        public Action<IDomainEvent> OnRaiseEvent { get; set; }

        public RabbitMQEventBus(RabbitMQSettings settings)
        {
            
            this.settings = settings;
            
        }

  
        public void PublishEvent<T>(T @event) where T : IDomainEvent
        {
            var factory = new ConnectionFactory() { HostName = settings.Hostname };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: settings.Queue,
                                     durable: true,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                var message = JsonConvert.SerializeObject(new RabbitMQMessage(@event));
                var body = Encoding.UTF8.GetBytes(message);


                channel.BasicPublish(exchange: "",
                                     routingKey: settings.Queue,
                                     basicProperties: null,
                                     body: body);

            }

        }

        

        public void Consume()
        {
            Task.Run(() =>
            {

                var factory = new ConnectionFactory() { HostName = settings.Hostname };
                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: settings.Queue,
                                         durable: true,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);
                    consumer.Received += (model, ea) =>
                    {

                        DoRaiseEvent(ea.Body);
                    };


                    channel.BasicConsume(queue: settings.Queue,
                                         autoAck: true,
                                         consumer: consumer);

                    while (true) { }

                }
            });
        }

        private void DoRaiseEvent(byte[] body)
        {
            var json = Encoding.UTF8.GetString(body);

            var jsonObject = (JObject)JsonConvert.DeserializeObject(json);

            var eventType = Type.GetType(jsonObject.GetValue(nameof(RabbitMQMessage.Type)).ToString());
            var eventJson = jsonObject.GetValue(nameof(RabbitMQMessage.Event)).ToString();
            var domainEvent = (IDomainEvent)JsonConvert.DeserializeObject(eventJson, eventType);

            OnRaiseEvent?.Invoke(domainEvent);

           
        }
    }
}
