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
        private static Models.MeuJogo meu { get; set; }

        private int media;

        public JogoDetalhes(Models.Jogo j)
        {
            InitializeComponent();
            jogo = new Models.Jogo();
            meu = new Models.MeuJogo();
            jogo = j;
            PopularPag();
            SetGenero(j.IdGenero);
            SetPlataforma(j.Id);
        }

        private void PopularPag()
        {
            img.Source = new BitmapImage(new Uri(jogo.Imagem, UriKind.RelativeOrAbsolute));
            tbSinopse.Text = jogo.Sinopse;
            lblAno.Content = jogo.Ano;
            lblMedia.Content = jogo.NotaMedia;
            lblDesenvolvedora.Content = jogo.Desenvolvedora;
            lblNomeJogo.Content = jogo.Nome;
        }

        private string ip = "http://localhost:52874/";

        private async void SetGenero(int IdGenero)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Genero/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Genero> obj = JsonConvert.DeserializeObject<List<Models.Genero>>(str);
            Models.Genero g = obj.Find(x => x.Id == IdGenero);
            lblGenero.Content = g.Descricao;
        }

        private async void SetPlataforma(int idJogo)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Plataforma/");
            var str = response.Content.ReadAsStringAsync().Result;
            var response2 = await httpClient.GetAsync("/api/PlataformaJogo/");
            var str2 = response2.Content.ReadAsStringAsync().Result;
            List<Models.Plataforma> obj = JsonConvert.DeserializeObject<List<Models.Plataforma>>(str);
            List<Models.PlataformaJogo> obj2 = JsonConvert.DeserializeObject<List<Models.PlataformaJogo>>(str2);
            foreach (Models.PlataformaJogo pj in obj2)
            {
                if (pj.IdJogo == idJogo)
                {
                    Models.Plataforma p = obj.Find(x => x.Id == pj.IdPlataforma);
                    lbPlataforma.Items.Add(p.Descricao);
                }
            }
        }
            
        private async void SetMeuJogo(int idJogo, string status)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.EstaAutenticado == true);

            meu.IdUsuario = usr.Id;
            meu.IdJogo = idJogo;
            meu.Status = status;
            meu.Classificacao = media.ToString();
        }

        private void btnQueroJogar_Click(object sender, RoutedEventArgs e)
        {
            SetMeuJogo(jogo.Id, "Quero Jogar");
        }

        private void btnJogando_Click(object sender, RoutedEventArgs e)
        {
            SetMeuJogo(jogo.Id, "Jogando");
        }

        private void btnJaJoguei_Click(object sender, RoutedEventArgs e)
        {
            SetMeuJogo(jogo.Id, "Já Joguei");
        }

        private void btnAvaliar_Click(object sender, RoutedEventArgs e)
        {
            if (radioButton1.IsChecked == true) media = 1;
            if (radioButton2.IsChecked == true) media = 2;
            if (radioButton3.IsChecked == true) media = 3;
            if (radioButton4.IsChecked == true) media = 4;
            if (radioButton5.IsChecked == true) media = 5;
        }
    }
}
