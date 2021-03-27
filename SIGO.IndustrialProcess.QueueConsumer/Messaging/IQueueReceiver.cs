using SIGO.IndustrialProcess.DataContracts;
using System.Collections.Generic;

namespace SIGO.IndustrialProcess.QueueConsumer.Messaging
{
    public interface IQueueReceiver
    {
        List<LogisticReportItem> ReadLogisticMessages();

        List<EmployeeReportItem> ReadEmployeeMessages();
    }
}
