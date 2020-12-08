using SIGO.RegulatoryNorms.DataContracts;
using System.Net.Http;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services.External
{
    public interface IExternalRegulatoryNormsClient
    {
        Task<HttpResponseMessage> GetNormsAsync(RegulatoryNormCategory category);
    }
}
