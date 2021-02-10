using BMO.Model;
using BMO.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BMO.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly GithubService _service;

        public GithubController(GithubService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            try
            {
                List<GithubRepoModel> result = await _service.Find5TakeOlderRepos();
                return Ok(result);
            }
            catch(Exception e)
            {
                return this.StatusCode(500, e);
            }
        }
    }
}
