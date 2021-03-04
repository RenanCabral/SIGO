using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SIGO.Consulting.DataContracts;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SIGO.Consulting.QueueConsumer.Messaging
{
    public class QueueReceiver : IQueueReceiver
    {
        public List<RegulatoryNormUpdate> ReadMessages()
        {
            var regulatoryNormUpdate = new List<RegulatoryNormUpdate>();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "regulatory-norms",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = JsonConvert.DeserializeObject<List<RegulatoryNormUpdate>>(Encoding.UTF8.GetString(body));

                        regulatoryNormUpdate.AddRange(message);
                    };

                    channel.BasicConsume(queue: "regulatory-norms", autoAck: true, consumer: consumer);
                }
            }
            Thread.Sleep(1200);
            return regulatoryNormUpdate;
        }
    }
}
