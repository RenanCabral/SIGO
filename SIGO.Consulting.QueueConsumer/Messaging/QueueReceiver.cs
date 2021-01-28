using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SIGO.Consulting.DataContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.Consulting.QueueConsumer.Messaging
{
    public class QueueReceiver: IQueueReceiver
    {
        public List<RegulatoryNormUpdate> ReadMessages()
        {
            var regulatoryNormUpdate = new List<RegulatoryNormUpdate>();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
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

                    channel.BasicConsume(queue: "hello",
                                         autoAck: true,
                                         consumer: consumer);

                }
            }

            return regulatoryNormUpdate;
        }
    }
}
