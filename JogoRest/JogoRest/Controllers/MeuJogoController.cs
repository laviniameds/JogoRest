using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace JogoRest.Controllers
{
    public class MeuJogoController : ApiController
    {
        // GET api/meujogo
        public IEnumerable<Models.MeuJogo> Get()
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from u in dc.MeuJogos select u;
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
        public void Put(int id, [FromBody] string value)
        {
            Models.MeuJogo x = JsonConvert.DeserializeObject<Models.MeuJogo>(value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.MeuJogo mj = (from u in dc.MeuJogos
                                 where u.Id == id
                                 select u).Single();
            mj.IdJogo = x.IdJogo;
            mj.IdUsuario = x.IdUsuario;
            mj.Comentario = x.Comentario;
            mj.Status = x.Status;
            mj.Classificacao = x.Classificacao;

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
