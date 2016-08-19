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
        private static Models.Usuario u;

        public PagPerfil(Models.Usuario usr)
        {
            InitializeComponent();
            u = new Models.Usuario();
            u = usr;
            Exibir();
        }

        private string ip = "http://localhost:52874/";

        private void Exibir()
        {
            txtNome.Text = u.Nome;
            txtEmail.Text = u.Email;
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            (new AtualizarUsr(u)).Show();
        }

        private async void Deletar()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            await httpClient.DeleteAsync("/api/Usuario/" + u.Id);
            MessageBox.Show("Deletado com sucesso!");
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
            FecharJanelas();
        }

        private void FecharJanelas()
        {
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Title != "Rede de Jogos" && w.Title != "") w.Close();
            }
        }

        private void btnDeletar_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Você tem certeza?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Deletar();
                FecharJanelas();
            }
        }
    }
}
