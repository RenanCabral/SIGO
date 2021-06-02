using Newtonsoft.Json;
using RabbitMQ.Client;
using SIGO.RegulatoryNorms.DataContracts;
using System.Collections.Generic;
using System.Text;

namespace SIGO.RegulatoryNorms.Application.Services.Messaging
{
    public class QueuePublisher : IQueuePublisher
    {
        public void SendMessage(List<RegulatoryNormUpdate> regulatoryNormsUpdate)
        {
            try
            {
                var factory = new ConnectionFactory()
                {
                    HostName = "fly.rmq.cloudamqp.com",
                    UserName = "ajwmzqvb",
                    Password = "ez1ywHLbWgfaH3g9Jnb3vneb9h7hGQ24",
                    Port = 5672,
                    VirtualHost = "ajwmzqvb"
                };

                using (var connection = factory.CreateConnection())
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "regulatory-norms",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var body = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(regulatoryNormsUpdate));

                    channel.BasicPublish(exchange: "", routingKey: "regulatory-norms", basicProperties: null, body: body);
                }

            }
            catch (System.Exception ex)
            {

                throw;
            }
        }
    }
}
