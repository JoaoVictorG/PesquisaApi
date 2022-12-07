using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using PesquisaApi.Model;
using System.Net;
using HtmlAgilityPack;

namespace PesquisaApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PesquisaController : ControllerBase
    {
        [HttpGet("{nome}")]
        public async Task<ActionResult<Pesquisa>> GetPesquisa(string nome)
        {
            string linkPesquisa = $"https://www.google.com/search?q={nome}";
            Pesquisa pesquisa = new Pesquisa();
            using (var client = new WebClient())
            {
                string response = client.DownloadString(linkPesquisa);
                int firstLink = response.IndexOf("<div class=\"BNeawe UPmit AP7Wnd lRVwie\">") + "<div class=\"BNeawe UPmit AP7Wnd lRVwie\">".Length;
                int lastLink = response.IndexOf("</div>", firstLink);
                string link = response.Substring(firstLink, lastLink - firstLink);

                int firstTitle = response.IndexOf("<div class=\"BNeawe vvjwJb AP7Wnd\">") + "<div class=\"BNeawe vvjwJb AP7Wnd\">".Length;
                int lastTitle = response.IndexOf("</div>", firstTitle);
                string title = response.Substring(firstTitle, lastTitle - firstTitle);

                pesquisa.Link = link;
                pesquisa.Titulo = title;

                return pesquisa;
            }

        }
        //[HttpGet("{nome}")]
        //public string GetPesquisa(string nome)
        //{
        //    //string nomeFormat = nome.Replace(" ", "+");
        //    string link = $"https://www.google.com/search?q={nome}";
        //    using (var client = new WebClient())
        //    {
        //        var response = client.DownloadString(link);
        //        return response;
        //    }

        //}

    }
}

