using System;

namespace SIGO.IndustrialProcess.DataContracts
{
    public class LogisticReportItem
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int Fuel { get; set; }

        public int Charge { get; set; }
    }
}
