using System;

namespace TakeBlip.API.Models
{
    public class GitHubModel
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public string Linguagem { get; set; }
        public DateTime DtCriacao { get; set; }
        public string UrlAvatar { get; set; }
    }
}
