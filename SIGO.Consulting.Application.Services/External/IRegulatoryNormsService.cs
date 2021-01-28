using System;
using SIGO.Consulting.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.Consulting.Application.Services.External
{
    public interface IRegulatoryNormsService
    {
        Task<List<RegulatoryNormUpdate>> GetRegulatoryNormsUpdatesAsync();
    }
}
