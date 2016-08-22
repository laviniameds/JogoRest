using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using System.Text;

namespace JogoRest.Controllers
{
    public class MeuJogoController : ApiController
    {
        //from u in dc.MeuJogos select u
        // GET api/meujogo
        public IEnumerable<Models.MeuJogo> Get()
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from u in dc.MeuJogos select u;
            return r.ToList();
        }

        // GET api/meujogo
        [Route("api/MeuJogo/{IdJogo:int}")]
        [HttpGet]
        public List<Models.MeuJogo> GetFiltroJogo(int IdJogo)
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from u in dc.MeuJogos where u.IdJogo == IdJogo select u;
            return r.ToList();
        }

        [Route("api/UsrJogo/{uID:int}")]
        [HttpGet]
        public IEnumerable<Models.MeuJogo> GetFiltro(int uID)
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from u in dc.MeuJogos where u.IdUsuario == uID select u;
            return r.ToList();
        }
        // POST api/meujogo
        public void Post([FromBody] string value)
        {
            List<Models.MeuJogo> x = JsonConvert.DeserializeObject<List<Models.MeuJogo>>(value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            dc.MeuJogos.InsertAllOnSubmit(x);
            dc.SubmitChanges();
        }

        // PUT api/meujogo
        [Route("api/MeuJogoPut/{ID:int}")]
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
            Models.MeuJogo x = JsonConvert.DeserializeObject<Models.MeuJogo>(value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.MeuJogo mj = (from u in dc.MeuJogos
                                 where u.Id == id
                                 select u).Single();
            mj.IdJogo = x.IdJogo;
            mj.IdUsuario = x.IdUsuario;
            mj.Status = x.Status;
            mj.Classificacao = x.Classificacao;

            dc.SubmitChanges();
        }

        // SET avalicao
        [Route("api/Avaliar/{ID:int}/{A:int}")]
        [HttpPut]
        public void Avaliar(int id, [FromBody] string value, int a)
        {
            Models.MeuJogo x = JsonConvert.DeserializeObject<Models.MeuJogo>(value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.MeuJogo mj = (from u in dc.MeuJogos
                                 where u.Id == id
                                 select u).Single();
            mj.IdJogo = x.IdJogo;
            mj.IdUsuario = x.IdUsuario;
            mj.Status = x.Status;
            mj.Classificacao = a.ToString();
            dc.SubmitChanges();
        }
        /*// DELETE api/meujogo
        public void Delete(int id)
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.MeuJogo usr = (from u in dc.MeuJogos
                                  where u.Id == id
                                  select u).Single();
            dc.MeuJogos.DeleteOnSubmit(usr);
            dc.SubmitChanges();
        }*/
    }
}
