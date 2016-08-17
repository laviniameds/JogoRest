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
        public IEnumerable<Models.Jogo> Get()
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from j in dc.Jogos select j;
            return r.ToList();
        }
    }
}
