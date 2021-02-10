using System.Net.Http;
using System.Threading.Tasks;

namespace BMO.Repository
{
    public class GithubRepository
    {
        private const string TAKE_REPO_URL = "https://api.github.com/users/takenet/repos";
        
        private readonly IHttpClientFactory _clientFactory;
        public GithubRepository(IHttpClientFactory clientFactory)
        {
            this._clientFactory = clientFactory;
        }

        public async Task<HttpResponseMessage> FindRepos()
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, TAKE_REPO_URL);
            request.Headers.Add("User-Agent", "request");
            HttpClient client = this._clientFactory.CreateClient();
            HttpResponseMessage response = await client.SendAsync(request);
            return response;       
        }
    }
}
