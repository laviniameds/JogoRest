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
    /// Interaction logic for MeusJogosPerfil.xaml
    /// </summary>
    public partial class MeusJogosPerfil : Window
    {
        public MeusJogosPerfil()
        {
            InitializeComponent();
        }

        private static Models.Usuario usr;

        public MeusJogosPerfil(Models.Usuario u)
        {
            InitializeComponent();
            usr = u;
            PopulateGrid(u);
        }

        private string ip = "http://localhost:52874/";

        private async void PopulateGrid(Models.Usuario u)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);            
            var response = await httpClient.GetAsync("/api/UsrJogo/" + u.Id);
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.MeuJogo> obj = JsonConvert.DeserializeObject<List<Models.MeuJogo>>(str);
            List<Models.MeuJogo> mj = obj.FindAll(x => x.IdUsuario == u.Id);

            List<Models.Jogo> jogoq = new List<Models.Jogo>();

            var response2 = await httpClient.GetAsync("/api/Jogo/");
            var str2 = response2.Content.ReadAsStringAsync().Result;
            List<Models.Jogo> obj2 = JsonConvert.DeserializeObject<List<Models.Jogo>>(str2);

            foreach (Models.MeuJogo mygame in obj)
                foreach (Models.Jogo jogo in obj2)
                {
                    if (mygame.IdJogo == jogo.Id)
                    {
                        jogoq.Add(jogo);
                    }                       
                }
            dataGridMeusJogos.ItemsSource = jogoq;
        }

        private void detalhes_Click(object sender, RoutedEventArgs e)
        {
            object myobject = ((Button)sender).CommandParameter;
            Models.Jogo j = new Models.Jogo();
            if (myobject is Models.Jogo) { j = (Models.Jogo)myobject; }
            (new JogoDetalhes(j, usr)).Show();
        }
    }
}
