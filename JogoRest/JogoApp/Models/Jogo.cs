using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoApp.Models
{
   public class Jogo
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string ano { get; set; }
        public string sinopse { get; set; }
        public string desenvolvedora { get; set; }
        public string notaMedia { get; set; }
        public string img { get; set; }
        public int idgenero { get; set; }
    }
}
