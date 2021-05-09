using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using TakeBlip.API.Interfaces;
using TakeBlip.API.Models;

namespace TakeBlip.API.Services
{
    public class GitHubService : IGitHubService
    {
        HttpClient cliente = new HttpClient();
        private static string Endpoint;
        public GitHubService()
        {
            Endpoint = "https://api.github.com/users/takenet/repos?per_page=100";
        }        
        public async Task<GitHubModel> ObterPorId(long id)
        {
            var lista = await ConsultarRepositorios();
            return lista.FirstOrDefault(x => x.Id == id);
        }
        public async Task<List<GitHubModel>> ConsultarRepositorios()
        {
            List<GitHubModel> Listarepositorios = new List<GitHubModel>();

            cliente.BaseAddress = new Uri(Endpoint);

            cliente.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
            System.Net.ServicePointManager.SecurityProtocol = System.Net.SecurityProtocolType.Tls12;
            cliente.DefaultRequestHeaders.Add("User-Agent", "request");

            var retorno = await cliente.GetAsync(Endpoint);

            if (retorno.IsSuccessStatusCode)
            {
                var response = retorno.Content.ReadAsStringAsync().Result.ToString();
                List<dynamic> repositoriosAPI = JsonConvert.DeserializeObject<List<dynamic>>(response);
                foreach (var item in repositoriosAPI)
                {
                    var objeto = new GitHubModel();
                    if (item.language == "C#")
                    {
                        objeto.Id = item.id;
                        objeto.UrlAvatar = item.owner.avatar_url;
                        objeto.DtCriacao = item.created_at;
                        objeto.Descricao = item.description;
                        objeto.Linguagem = item.language;
                        objeto.Nome = item.name;
                        Listarepositorios.Add(objeto);
                    }
                }
                return Listarepositorios.OrderBy(x => x.DtCriacao).Take(5).ToList();
            }
            else
            {
                return Listarepositorios;
            }            
        }       
    }
}
