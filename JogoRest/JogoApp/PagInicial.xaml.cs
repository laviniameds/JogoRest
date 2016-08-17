using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Net.Http;
using Newtonsoft.Json;

namespace JogoApp
{
    /// <summary>
    /// Interaction logic for PagInicial.xaml
    /// </summary>
    public partial class PagInicial : Window
    {
        private string ip = "http://localhost:52874/";

        private async void VerificarUsr()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.EstaAutenticado == true);
            lblBemVindo.Content = "Bem-Vindo, " + usr.Nome + "!";
        }
        public PagInicial()
        {
            InitializeComponent();
            VerificarUsr();
            PopularGrid();
        }

        private async void PopularGrid()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Jogo/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Jogo> obj = JsonConvert.DeserializeObject<List<Models.Jogo>>(str);
            gridJogos.ItemsSource = obj;
        }

        private void btnPerfil_Click(object sender, RoutedEventArgs e)
        {
            (new PagPerfil()).Show();
        }

        private async void Sair()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.EstaAutenticado == true);
            Models.Usuario usr2 = new Models.Usuario
            {
                Nome = usr.Nome,
                Id = usr.Id,
                Email = usr.Email,
                Senha = usr.Senha,
                Imagem = "",
                EstaAutenticado = false
            };
            string s = "=" + JsonConvert.SerializeObject(usr2);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PutAsync("/api/Usuario/" + usr2.Id, content);
        }

        private void btnSair_Click(object sender, RoutedEventArgs e)
        {
            Sair();
            //this.Close();
        }

        private void detalhes_Click(object sender, RoutedEventArgs e)
        {
            //
        }
    }
}
