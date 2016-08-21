using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JogoRest.Controllers
{
    public class JogoController : ApiController
    {
        // GET api/jogo
        [Route("API/JogoGet")]
        [HttpGet]
        public IEnumerable<Models.Jogo> Get()
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from j in dc.Jogos select j;
            return r.ToList();
        }

        // Média
        private int Media(int id) {
            MeuJogoController a= new MeuJogoController();
            Models.MeuJogo[] listajogo = a.GetFiltroJogo(id).ToArray();
            int media = 0;
            int valor = 0;
            foreach (Models.MeuJogo mj in listajogo)
            {
                media += Convert.ToInt32(mj.Classificacao);
                valor++;
            }
            int div = media / valor;
            return div;
        }
        [Route("api/MediaPut/{ID:int}")]
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
            Models.Jogo x = JsonConvert.DeserializeObject<Models.Jogo>(value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.Jogo game= (from f in dc.Jogos
                                     where f.Id == id
                                     select f).Single();

            game.NotaMedia = Media(id).ToString();
            dc.SubmitChanges();

        }
    }
}
