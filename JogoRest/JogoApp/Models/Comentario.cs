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
    }
}
