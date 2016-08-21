using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoApp.Models
{
    class Comentario
    {
        public int ID { get; set; }
        public string Descricao { get; set; }
        public int IdUsr { get; set; }
        public int IdMeuJogo { get; set; }
        public DateTime Data { get; set; }
        public int IdJogo { get; set; }
        public string Autor { get; set; }

        public override string ToString()
        {
            return String.Format(Autor + " :" + " " + Descricao);
        }
    }
}
