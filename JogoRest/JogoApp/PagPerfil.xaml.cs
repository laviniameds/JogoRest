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
    /// Interaction logic for PagPerfil.xaml
    /// </summary>
    public partial class PagPerfil : Window
    {
        public PagPerfil()
        {
            InitializeComponent();
            Exibir();
        }

        private string ip = "http://localhost:52874/";

        private async void Exibir()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.EstaAutenticado == true);
            txtNome.Text = usr.Nome;
            txtEmail.Text = usr.Email;
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            (new AtualizarUsr()).Show();
        }
    }
}
