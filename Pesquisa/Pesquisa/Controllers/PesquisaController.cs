using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using PesquisaApi.Model;
using System.Net;

namespace PesquisaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        [HttpGet("{nome}")]
        public string GetPesquisa(string nome)
        {
            //string nomeFormat = nome.Replace(" ", "+");
            string link = $"https://www.google.com/search?q={nome}";
            using (var client = new WebClient())
            {
                var response = client.DownloadString(link);
                return response;
            }
            
        }

    }
}
