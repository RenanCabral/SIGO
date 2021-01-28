using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.RegulatoryNorms.Application.Services.Messaging
{
    public class QueuePublisher: IQueuePublisher
    {
        public void SendMessage()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };

            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "hello",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                string message = "Hello World!";
                var body = Encoding.UTF8.GetBytes(message);

                channel.BasicPublish(exchange: "",
                                             routingKey: "hello",
                                             basicProperties: null,
                                             body: body);
            }
        }
    }
}
