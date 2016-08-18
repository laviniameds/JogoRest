using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace JogoApp
{
    /// <summary>
    /// Interaction logic for JogoDetalhes.xaml
    /// </summary>
    public partial class JogoDetalhes : Window
    {
        private static Models.Jogo jogo { get; set; }

        public JogoDetalhes(Models.Jogo j)
        {
            InitializeComponent();
            jogo = new Models.Jogo();
            jogo = j;
            PopularPag();
            SetGenero(j.IdGenero);
        }

        private void PopularPag()
        {
            img.Source = new BitmapImage(new Uri(jogo.Imagem, UriKind.RelativeOrAbsolute));
            tbSinopse.Text = jogo.Sinopse;
            lblAno.Content = jogo.Ano;
            lblMedia.Content = jogo.NotaMedia;
            lblDesenvolvedora.Content = jogo.Desenvolvedora;
            lblNomeJogo.Content = jogo.Nome;
            //lblPlataforma.Content = jogo.
        }

        private string ip = "http://localhost:52874/";

        private async void SetGenero(int IdGenero)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Genero/" + IdGenero);
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Genero> obj = JsonConvert.DeserializeObject<List<Models.Genero>>(str);
            Models.Genero g = obj.Find(x => x.Id == IdGenero);
            lblGenero.Content = g.Descricao;
        }
    }
}
