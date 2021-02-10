using BMO.Model;
using BMO.Repository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BMO.Service
{
    public class GithubService
    {
        private readonly GithubRepository _repository;

        public GithubService(GithubRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GithubRepoModel>> Find5TakeOlderRepos()
        {
            try
            {
                HttpResponseMessage response = await this._repository.FindTakeRepos();
                HttpContent content = response.Content;
                string jsonContent = content.ReadAsStringAsync().Result;

                List<GithubRepoModel> result = JsonConvert.DeserializeObject<List<GithubRepoModel>>(jsonContent);

                return result.OrderBy(x => x.Created_at).Take(5).ToList();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}
