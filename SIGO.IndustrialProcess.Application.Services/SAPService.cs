using SAP.Middleware.Connector;
using SIGO.IndustrialProcess.Application.Services.External;
using System;
using System.Collections.Generic;

namespace SIGO.IndustrialProcess.Application.Services
{
    public class SAPService
    {
        private readonly ISAPClient _sapClient;

        public SAPService(ISAPClient sapClient)
        {
            _sapClient = sapClient;
        }

        public object GetEmployeesData()
        {
            return _sapClient.Invoke("GET_EMPLOYEES_DATA");
        }
    }
}
