using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JogoRest.Controllers
{
    public class PlataformaJogoController : ApiController
    {
        public IEnumerable<Models.PlataformaJogo> Get()
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from pj in dc.PlataformaJogos select pj;
            return r.ToList();
        }
    }
}
