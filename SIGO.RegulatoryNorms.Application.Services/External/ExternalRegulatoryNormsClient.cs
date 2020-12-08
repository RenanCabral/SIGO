using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace SIGO.RegulatoryNorms.Application.Services.External
{
	public class ExternalRegulatoryNormsClient
    {
        HttpClient client;
        const string baseUri = "http://regulatorynorms/";

        public ExternalRegulatoryNormsClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(baseUri);
        }

        public async Task<HttpResponseMessage> GetNormsAsync()
        {
            HttpResponseMessage response = new HttpResponseMessage();

			// TODO: fake content for testing proporses
            response.Content = new StringContent(GetFakeRegulatoryNormsResponse());

			// TODO: uncomment this line in case of real usage of external norms api
            //response = await client.GetAsync("GetNorms");

            return await Task.FromResult(response);
        }

        private string GetFakeRegulatoryNormsResponse()
        {
			return @"{
						[
							{
								'Code': '0001',
								'Description': 'A seguinte norma regulatória na área de segurança do trabalho, determina que os funcionários estejam com uso obrigatório de EPis.',
								'ReleaseDate': '08/12/2020',
								'DueDate': '01/04/2021',
								'Category': 'WorkSafety'
							},
							{
								'Code': '0002',
								'Description': 'A seguinte norma regulatória na industrial, determina que equimamentos industriais com mais de 20 anos de uso sejam vistoriados regularmente ....',
								'ReleaseDate': '20/12/2020',
								'DueDate': '01/08/2021',
								'Category': 'Industrial'
							},
							{
								'Code': '0003',
								'Description': 'A seguinte norma regulatória na ambiental, determina que o descarte de resíduos seja  ....',
								'ReleaseDate': '01/02/2021',
								'DueDate': '01/10/2021',
								'Category': 'Environmental'
							}
						]
					}";
        }
    }
}
