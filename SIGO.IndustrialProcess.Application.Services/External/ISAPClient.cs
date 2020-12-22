using SAP.Middleware.Connector;

namespace SIGO.IndustrialProcess.Application.Services.External
{
    public interface ISAPClient
    {
        object Invoke(string @function);
    }
}
