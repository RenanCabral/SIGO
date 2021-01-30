using SIGO.RegulatoryNorms.DataContracts;
using System.Collections.Generic;

namespace SIGO.RegulatoryNorms.Application.Services.Messaging
{
    public interface IQueuePublisher
    {
        void SendMessage(List<RegulatoryNormUpdate> regulatoryNormsUpdate);
    }
}
