namespace HttpClientSample.Clients
{
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;
    using HttpClientSample.Models;

    public class RocketClient : IRocketClient
    {
        private readonly HttpClient httpClient;

        public RocketClient(HttpClient httpClient) => this.httpClient = httpClient;

        public async Task<TakeoffStatus> GetStatus(bool working)
        {
            var response = await this.httpClient.GetAsync(working ? "status-working" : "status-failing");
            response.EnsureSuccessStatusCode();

            var res = await JsonSerializer.DeserializeAsync<TakeoffStatus>(await response.Content.ReadAsStreamAsync());
            return res;
            //return await response.Content.ReadAsAsync<TakeoffStatus>();
        }
    }
}
