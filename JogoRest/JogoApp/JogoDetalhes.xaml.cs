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
        private static Models.Usuario usr { get; set; }

        private int media;
        private int jID;
        private int meid;

        public JogoDetalhes(Models.Jogo j, Models.Usuario u)
        {
            InitializeComponent();
            jogo = new Models.Jogo();
            usr = new Models.Usuario();
            jogo = j;
            usr = u;
            PopularPag();
            SetGenero(j.IdGenero);
            SetPlataforma(j.Id);
            VerificarJogo(j.Id);




        }
        

        private void PopularPag()
        {
            img.Source = new BitmapImage(new Uri(jogo.Imagem, UriKind.RelativeOrAbsolute));
            tbSinopse.Text = jogo.Sinopse;
            lblAno.Content = jogo.Ano;
            lblMedia.Content = jogo.NotaMedia;
            lblDesenvolvedora.Content = jogo.Desenvolvedora;
            lblNomeJogo.Content = jogo.Nome;
            jID = jogo.Id;
        }

        private string ip = "http://localhost:52874/";

        private async void VerificarJogo(int JogoID)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/UsrJogo/" + usr.Id);
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.MeuJogo> obj = JsonConvert.DeserializeObject<List<Models.MeuJogo>>(str);
            Models.MeuJogo mej = obj.Find(x => x.IdJogo == JogoID);
            if (mej != null)
            {
                meid = mej.IdJogo;
                string status = mej.Status;
                if (meid == jID)
                {
                    if (status == "Quero Jogar")
                    {
                        btnQueroJogar.IsEnabled = false;
                    }
                    if (status == "Jogando")
                    {
                        btnJogando.IsEnabled = false;
                    }
                    if (status == "Já Joguei")
                    {
                        btnJaJoguei.IsEnabled = false;
                    }

                }
            }

        }
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
            var response = await httpClient.GetAsync("/api/UsrJogo/" + usr.Id);
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.MeuJogo> obj = JsonConvert.DeserializeObject<List<Models.MeuJogo>>(str);
            Models.MeuJogo mej = obj.Find(x => x.IdJogo == idJogo);
            if (mej == null)
            {
            Models.MeuJogo mj = new Models.MeuJogo
            {
                Status = status,
                Comentario = "",
                Classificacao = media.ToString(),
                IdJogo = idJogo,
                IdUsuario = usr.Id
            };
            
                List<Models.MeuJogo> list = new List<Models.MeuJogo>();
                list.Add(mj);
                string s = "=" + JsonConvert.SerializeObject(list);
                var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
                await httpClient.PostAsync("/api/MeuJogo/", content);
                MessageBox.Show("Adicionado com sucesso!");
            }
            if(mej!= null) {
                Models.MeuJogo mj2 = new Models.MeuJogo
                {
                    Id = mej.Id,
                    Status = status,
                    Comentario = "",
                    Classificacao = media.ToString(),
                    IdJogo = idJogo,
                    IdUsuario = usr.Id

                };
                string s = "=" + JsonConvert.SerializeObject(mj2);
                var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
                await httpClient.PutAsync("/api/MeuJogoPut/" + mj2.Id, content);
                MessageBox.Show("Atualizado com sucesso!");
            
            }
            
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

        private async void  btnAvaliar_Click(object sender, RoutedEventArgs e)
        {
            //if (radioButton1.IsChecked == true) media = 1;
            if (radioButton2.IsChecked == true) media = 2;
            if (radioButton3.IsChecked == true) media = 3;
            if (radioButton4.IsChecked == true) media = 4;
            if (radioButton5.IsChecked == true) media = 5;
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Jogo game = new Models.Jogo
            {
                Id = jogo.Id,
                Nome = jogo.Nome,
                Ano = jogo.Ano,
                Sinopse= jogo.Sinopse,
                Desenvolvedora= jogo.Desenvolvedora,
                Imagem = jogo.Imagem
            };
            string s = "=" + JsonConvert.SerializeObject(game);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PutAsync("/api/MediaPut/" + game.Id, content);
            MessageBox.Show("Avaliado com sucesso!");
        }
    }
}
