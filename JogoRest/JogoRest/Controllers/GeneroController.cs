using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JogoRest.Controllers
{
    public class GeneroController : ApiController
    {
        // GET api/genero
        public Models.Genero Get(int IdJogo)
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = (from g in dc.Generos
                     join j in dc.Jogos on g.Id equals j.IdGenero
                     select new Models.Genero { Descricao = g.Descricao }).Single();
            return r;
        }
    }
}
