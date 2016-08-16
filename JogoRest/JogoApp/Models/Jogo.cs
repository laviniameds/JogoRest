using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoApp.Models
{
   public class Jogo
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ano { get; set; }
        public string Sinopse { get; set; }
        public string Desenvolvedora { get; set; }
        public string NotaMedia { get; set; }
        public string Img { get; set; }
        public int IdGenero { get; set; }
    }
}
