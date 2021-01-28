using SIGO.Consulting.DataContracts;
using SIGO.Consulting.QueueConsumer.Messaging;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consulting.Application.Services.External
{
    public class RegulatoryNormsService : IRegulatoryNormsService
    {
        public RegulatoryNormsService(IQueueReceiver queueReceiver)
        {
            this._queueReceiver = queueReceiver;
        }

        private readonly IQueueReceiver _queueReceiver;

        public async Task<List<RegulatoryNormUpdate>> GetRegulatoryNormsUpdatesAsync()
        {
            return await Task.FromResult(this._queueReceiver.ReadMessages());
        }
    }
}