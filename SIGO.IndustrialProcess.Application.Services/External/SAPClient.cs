using SAP.Middleware.Connector;

namespace SIGO.IndustrialProcess.Application.Services.External
{
    public class SAPClient : ISAPClient
    {
        private readonly RfcConfigParameters config;

        public SAPClient()
        {
            config = GetRfcConfigParameters();
        }

        public object Invoke(string @function)
        {
            RfcDestination destination = RfcDestinationManager.GetDestination(config);
            RfcRepository repository = destination.Repository;
            
            IRfcFunction rfcFunction = repository.CreateFunction(@function);
            rfcFunction.SetValue("I_CARRID", "ZZZ");
            try
            {
                rfcFunction.Invoke(destination);
                string name = rfcFunction.GetString("E_CARRNAME");
            }
            catch (RfcAbapException ex)
            {
                if (ex.Key == "CARR_NOT_FOUND")
                {
                    //TODO: log this exception somewhere
                }
                    
            }
            return null;
        }

        private RfcConfigParameters GetRfcConfigParameters()
        {
            RfcConfigParameters config = new RfcConfigParameters();

            //TODO: Get config from app settings
            config.Add(RfcConfigParameters.Name, "SAP");
            config.Add(RfcConfigParameters.AppServerHost, "sap-vm");
            config.Add(RfcConfigParameters.SystemNumber, "00");
            config.Add(RfcConfigParameters.User, "bcuser");
            config.Add(RfcConfigParameters.Password, "sapadmin2");
            config.Add(RfcConfigParameters.Client, "001");
            config.Add(RfcConfigParameters.Language, "EN");

            return config;
        }
    }
}
