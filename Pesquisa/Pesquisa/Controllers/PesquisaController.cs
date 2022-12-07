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
            string linkPesquisa = $"https://www.google.com/search?q={nome}";
            using (var client = new WebClient())
            {
                string response = client.DownloadString(linkPesquisa);
                int first = response.IndexOf("<div class=\"BNeawe UPmit AP7Wnd lRVwie\">") + "<div class=\"BNeawe UPmit AP7Wnd lRVwie\">".Length;
                int last = response.IndexOf("</div>", first);
                string link = response.Substring(first, last - first);
                string linkFinal = $"Link: {link}";


                //string textoTeste = "<div class=\"BNeawe UPmit AP7Wnd lRVwie\">Testando escolha</div>";

                //int first = textoTeste.IndexOf("<div class=\"BNeawe UPmit AP7Wnd lRVwie\">") + "<div class=\"BNeawe UPmit AP7Wnd lRVwie\">".Length;
                //int last = textoTeste.IndexOf("</div>");
                //string link = textoTeste.Substring(first, last - first);
                //string linkFinal = $"Link:{link}";
                return linkFinal;
            }

        }

    }
}

