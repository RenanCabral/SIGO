using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using SIGO.IndustrialProcess.DataContracts;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace SIGO.IndustrialProcess.QueueConsumer.Messaging
{
    public class QueueReceiver : IQueueReceiver
    {
        public List<EmployeeReportItem> ReadEmployeeMessages()
        {
            var regulatoryNormUpdate = new List<EmployeeReportItem>();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "employees",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = JsonConvert.DeserializeObject<List<EmployeeReportItem>>(Encoding.UTF8.GetString(body));

                        regulatoryNormUpdate.AddRange(message);
                    };

                    channel.BasicConsume(queue: "employees", autoAck: true, consumer: consumer);
                }
            }
            Thread.Sleep(1200);
            return regulatoryNormUpdate;
        }

        public List<LogisticReportItem> ReadLogisticMessages()
        {
            var regulatoryNormUpdate = new List<LogisticReportItem>();

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "logistic",
                                         durable: false,
                                         exclusive: false,
                                         autoDelete: false,
                                         arguments: null);

                    var consumer = new EventingBasicConsumer(channel);

                    consumer.Received += (model, ea) =>
                    {
                        var body = ea.Body.ToArray();
                        var message = JsonConvert.DeserializeObject<List<LogisticReportItem>>(Encoding.UTF8.GetString(body));
                        regulatoryNormUpdate.AddRange(message);
                    };

                    channel.BasicConsume(queue: "logistic", autoAck: true, consumer: consumer);
                }
            }
            
            Thread.Sleep(1500);
            return regulatoryNormUpdate;
        }
    }
}
