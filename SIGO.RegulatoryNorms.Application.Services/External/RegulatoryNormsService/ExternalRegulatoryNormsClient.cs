using SIGO.RegulatoryNorms.DataContracts;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services.External
{
	public class ExternalRegulatoryNormsClient : IExternalRegulatoryNormsClient
	{
        HttpClient client;
        const string baseUri = "http://regulatorynorms/";

        public ExternalRegulatoryNormsClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
        }

        public async Task<HttpResponseMessage> GetNormsAsync(RegulatoryNormCategory category)
        {
            HttpResponseMessage response = new HttpResponseMessage();
			
			// TODO: fake content for testing proporses
            response.Content = new StringContent(GetFakeRegulatoryNormsResponse());
			response.StatusCode = System.Net.HttpStatusCode.OK;

			// TODO: uncomment this line in case of real usage of external norms api
            //response = await client.GetAsync("GetNorms");

            return await Task.FromResult(response);
        }

        private string GetFakeRegulatoryNormsResponse()
        {
			FileStream fileStream = new FileStream("ExternalRegulatoryNormsBase/ExternalRegulatoryNormsBase.json", FileMode.Open);
			using (StreamReader reader = new StreamReader(fileStream))
			{
				string content = reader.ReadToEnd();
				return content;
			}
        }
	}
}
