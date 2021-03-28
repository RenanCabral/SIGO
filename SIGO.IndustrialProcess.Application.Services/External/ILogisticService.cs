using SIGO.IndustrialProcess.DataContracts;
using System.Collections.Generic;

namespace SIGO.IndustrialProcess.Application.Services.External
{
    public interface ILogisticService
    {
        public List<LogisticReportItem> GetLogisticReportAsync();
    }
}
