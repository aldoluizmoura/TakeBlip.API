using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TakeBlip.API.Models;

namespace TakeBlip.API.Interfaces
{
    public interface IGitHubService
    {
        Task<List<GitHubModel>> ConsultarRepositorios();
        Task<GitHubModel> ObterPorId(long id);
    }
}
