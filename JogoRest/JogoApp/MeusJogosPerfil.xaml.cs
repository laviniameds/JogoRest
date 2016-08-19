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

        public MeusJogosPerfil(Models.Usuario u)
        {
            InitializeComponent();
            PopulateGrid(u);
        }

        private string ip = "http://localhost:52874/";

        private async void PopulateGrid(Models.Usuario u)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);            
            var response = await httpClient.GetAsync("/api/MeuJogo/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.MeuJogo> obj = JsonConvert.DeserializeObject<List<Models.MeuJogo>>(str);
            List<Models.MeuJogo> mj = obj.FindAll(x => x.IdUsuario == u.Id);
            dataGridMeusJogos.ItemsSource = mj;
        }
    }
}
