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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Net.Http;
using Newtonsoft.Json;

namespace JogoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private string ip = "http://localhost:52874/";

        private async void Autenticar()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.Nome == txtNome.Text);
            Models.Usuario usr2 = new Models.Usuario
            {
                Nome = usr.Nome,
                Id = usr.Id,
                Email = usr.Email,
                Senha = usr.Senha,
                Imagem = "",
                EstaAutenticado = true
            };
            string s = "=" + JsonConvert.SerializeObject(usr2);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PutAsync("/api/Usuario/" + usr2.Id, content);
        }

        private async void Logar()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.Nome == txtNome.Text);
            if (usr != null)
            {
                if (usr.Senha == txtSenha.Password)
                {
                    Autenticar();
                    (new PagInicial()).Show();
                }
                else MessageBox.Show("Senha Incorreta!");
            }
            else MessageBox.Show("Usuário Inválido!");
            this.Close();
        }

        private void CadUsr_Click(object sender, RoutedEventArgs e)
        {
            (new CadastrarUsr()).Show();
        }

        private void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            Logar();
        }
    }
}
