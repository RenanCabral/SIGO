using SIGO.Consulting.DataContracts;
using System.Collections.Generic;

namespace SIGO.Consulting.QueueConsumer.Messaging
{
    public interface IQueueReceiver
    {
        List<RegulatoryNormUpdate> ReadMessages();
    }
}
