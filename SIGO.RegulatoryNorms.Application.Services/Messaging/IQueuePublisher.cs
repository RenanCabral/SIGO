using System;
using System.Collections.Generic;
using System.Text;

namespace SIGO.RegulatoryNorms.Application.Services.Messaging
{
    public interface IQueuePublisher
    {
        void SendMessage();
    }
}
