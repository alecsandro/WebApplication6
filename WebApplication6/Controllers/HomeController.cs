using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication6.Models;

namespace WebApplication6.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            pedidos p = new pedidos();            
            return View(p);
        }


        public ActionResult RetornaCep(FormCollection form )
        {

            var endereco = form["endereco"];
            var cidade = form["CIDADE"];
            var rua = form["RUA"];

            //var tipo = controles["tipo"];

            string address = string.Format("https://viacep.com.br/ws/{0}/json/", endereco);
            var result = new System.Net.WebClient().DownloadString(address);
            ViaCEp dadosJSON = JsonConvert.DeserializeObject<ViaCEp>(result);
            //string Bairro = dadosJSON.localidade;
            return View(dadosJSON);

        }

        public ActionResult RETORNO(pedidos p)
        {

          
            return View(p);
        }


    }
}