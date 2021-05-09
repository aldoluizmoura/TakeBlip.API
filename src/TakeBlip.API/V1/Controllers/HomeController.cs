using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeBlip.API.Interfaces;
using TakeBlip.API.Models;

namespace TakeBlip.API.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/Home")]
    public class HomeController : Controller
    {
        private readonly IGitHubService _gitHubService;

        public HomeController(IGitHubService gitHubService)
        {
            _gitHubService = gitHubService;
        }
        
        [HttpGet]
        public async Task<IEnumerable<GitHubModel>> MostrarRepositorios()
        {
            return await _gitHubService.ConsultarRepositorios();            
        }
        [HttpGet("obter-por-id")]
        public async Task<GitHubModel> obterPorId(long id)
        {
            return await _gitHubService.ObterPorId(id);
        }
    }
}
