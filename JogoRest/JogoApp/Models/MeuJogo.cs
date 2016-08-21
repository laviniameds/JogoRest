using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JogoApp.Models
{
    class MeuJogo
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string Classificacao { get; set; }
        public int IdJogo { get; set; }
        public int IdUsuario { get; set; }
    }
}
