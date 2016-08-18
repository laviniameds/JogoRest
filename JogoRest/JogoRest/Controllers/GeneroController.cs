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
        public IEnumerable<Models.Genero> Get()
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from g in dc.Generos select g;
            return r.ToList();
        }
    }
}
