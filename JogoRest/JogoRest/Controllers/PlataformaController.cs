using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JogoRest.Controllers
{
    public class PlataformaController : ApiController
    {
        public IEnumerable<Models.Plataforma> Get()
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from p in dc.Plataformas select p;
            return r.ToList();
        }
    }
}
