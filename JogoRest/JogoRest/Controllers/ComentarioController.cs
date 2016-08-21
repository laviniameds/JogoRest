using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace JogoRest.Controllers
{
    public class ComentarioController : ApiController
    {
        [Route("api/ComentJogo/{jID:int}")]
        [HttpGet]
        public IEnumerable<Models.Comentario> GetFiltro(int jID)
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from u in dc.Comentarios where u.IdJogo == jID select u;
            r.OrderBy(x => x.Data);
            return r.ToList();
        }
        [Route("api/ComentPost")]
        [HttpPost]
        public void Post([FromBody] string value)
        {
            List<Models.Comentario> x = JsonConvert.DeserializeObject<List<Models.Comentario>>(value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            dc.Comentarios.InsertAllOnSubmit(x);
            dc.SubmitChanges();
        }
        [Route("api/ComentPut/{ID:int}")]
        [HttpPut]
        public void Put(int id, [FromBody] string value)
        {
            Models.Comentario x = JsonConvert.DeserializeObject<Models.Comentario>(value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.Comentario mj = (from u in dc.Comentarios
                                 where u.ID == id
                                 select u).Single();
            mj.IdJogo = x.IdJogo;
            mj.IdUsr = x.IdUsr;
            mj.Data = x.Data;
            mj.Descricao = x.Descricao;

            dc.SubmitChanges();
        }
        [Route("api/ComentDelSingle/id:{int}")]
        [HttpDelete]
        public void Delete(int id)
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.Comentario usr = (from u in dc.Comentarios
                                  where u.ID == id
                                  select u).Single();
            dc.Comentarios.DeleteOnSubmit(usr);
            dc.SubmitChanges();
        }
        [Route("api/ComentDelMyGame/id:{int}")]
        [HttpDelete]
        public void DeleteMyGame(int id)
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.Comentario usr = (from u in dc.Comentarios
                                     where u.IdMeuJogo == id
                                     select u).Single();
            dc.Comentarios.DeleteOnSubmit(usr);
            dc.SubmitChanges();
        }
    }
}
