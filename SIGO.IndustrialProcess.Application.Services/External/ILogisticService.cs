using SIGO.IndustrialProcess.DataContracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SIGO.IndustrialProcess.Application.Services.External
{
    public interface ILogisticService
    {
        public Task<List<LogisticReportItem>> GetLogisticReportAsync();
    }
}
