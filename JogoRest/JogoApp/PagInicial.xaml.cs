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
        }

        private void btnPerfil_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
