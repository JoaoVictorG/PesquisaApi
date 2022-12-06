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
        public string GetPesquisa(string nome)
        {
            //string nomeFormat = nome.Replace(" ", "+");
            string link = $"https://www.google.com/search?q={nome}";
            using (var client = new WebClient())
            {
                var response = client.DownloadString(link);

                int first = response.IndexOf("<div class=\"BNeawe UPmit AP7Wnd lRVwie\">") + "<div class=\"BNeawe UPmit AP7Wnd lRVwie\">".Length;
                int last = response.LastIndexOf("</div>");
                string title = response.Substring(first, last - first);
                return title;
            }

        }

    }
}

