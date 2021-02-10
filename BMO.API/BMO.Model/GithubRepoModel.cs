using System;

namespace BMO.Model
{
    public class GithubRepoModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
        public GithubRepoOwnerModel Owner { get; set; }
    }
}
