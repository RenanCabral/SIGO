using SIGO.IndustrialProcess.DataContracts;
using SIGO.IndustrialProcess.QueueConsumer.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SIGO.IndustrialProcess.Application.Services.External
{
    public class LogisticService : ILogisticService
    {
        private static List<LogisticReportItem> _logisticReportData = new List<LogisticReportItem>() { 
            new LogisticReportItem() {
                                       StartDate = Convert.ToDateTime("2021-01-01"), 
                                       EndDate = Convert.ToDateTime("2021-01-31"),
                                       Fuel = 179,
                                       Charge = 270
                                     }
        };

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
