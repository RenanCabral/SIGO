using SIGO.IndustrialProcess.DataContracts;
using SIGO.IndustrialProcess.QueueConsumer.Messaging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.IndustrialProcess.Application.Services.External
{
    public class LogisticService : ILogisticService
    {
        private static List<LogisticReportItem> _logisticReportData = new List<LogisticReportItem>();

        public LogisticService(IQueueReceiver queueReceiver)
        {
            this._queueReceiver = queueReceiver;
        }

        private readonly IQueueReceiver _queueReceiver;

        public List<LogisticReportItem> GetLogisticReportAsync()
        {
            var responseMessages = this._queueReceiver.ReadLogisticMessages();
            
            if (responseMessages.Any()) {
                _logisticReportData.AddRange(responseMessages);
            }

            return _logisticReportData;
        }
    }
}
