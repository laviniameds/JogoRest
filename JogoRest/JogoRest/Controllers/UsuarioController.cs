using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace JogoRest.Controllers
{
    public class UsuarioController : ApiController
    {
        // GET api/usuario
        public IEnumerable<Models.Usuario> Get()
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            var r = from u in dc.Usuarios select u;
            return r.ToList();
        }

        // POST api/usuario
        public void Post([FromBody] string value)
        {
            List<Models.Usuario> x = JsonConvert.DeserializeObject< List < Models.Usuario>> (value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            dc.Usuarios.InsertAllOnSubmit(x);
            dc.SubmitChanges();
        }

        // PUT api/usuario
        public void Put(int id, [FromBody] string value)
        {
            Models.Usuario x = JsonConvert.DeserializeObject< Models.Usuario> (value);
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.Usuario usr = (from u in dc.Usuarios where u.Id == id select u).Single();
            usr.Nome = x.Nome;
            usr.Senha = x.Senha;
            usr.Email = x.Email;
            usr.Imagem = x.Imagem;
            dc.SubmitChanges();
        }

        // DELETE api/usuario
        public void Delete(int id)
        {
            Models.JogoDataContext dc = new Models.JogoDataContext();
            Models.Usuario usr = (from u in dc.Usuarios where u.Id == id select u).Single();
            dc.Usuarios.DeleteOnSubmit(usr);
            dc.SubmitChanges();
        }
    }
}
