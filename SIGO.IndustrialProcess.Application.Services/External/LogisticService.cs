using SIGO.IndustrialProcess.DataContracts;
using SIGO.IndustrialProcess.QueueConsumer.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.IndustrialProcess.Application.Services.External
{
    public class LogisticService: ILogisticService
    {

        public LogisticService(IQueueReceiver queueReceiver)
        {
            this._queueReceiver = queueReceiver;
        }

        private readonly IQueueReceiver _queueReceiver;

        public List<LogisticReportItem> GetLogisticReportAsync()
        {
            return this._queueReceiver.ReadLogisticMessages();
        }
    }
}
