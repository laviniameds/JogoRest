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
        private static Models.Usuario u;

        public PagInicial(Models.Usuario usr)
        {
            InitializeComponent();
            u = new Models.Usuario();
            u = usr;
            lblBemVindo.Content = "Bem-Vindo, " + u.Nome + "!";
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
            (new PagPerfil(u)).Show();
        }
                
        private void detalhes_Click(object sender, RoutedEventArgs e)
        {
            object myobject = ((Button)sender).CommandParameter;
            Models.Jogo j = new Models.Jogo();
            if (myobject is Models.Jogo) { j = (Models.Jogo)myobject; }
            JogoDetalhes jogo = new JogoDetalhes(j);
            jogo.Show();
        }

        private void btnMeusJogos_Click(object sender, RoutedEventArgs e)
        {
            (new MeusJogosPerfil(u)).Show();
        }
    }
}
