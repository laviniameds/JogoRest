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
    /// Interaction logic for AtualizarUsr.xaml
    /// </summary>
    public partial class AtualizarUsr : Window
    {
        public AtualizarUsr(Models.Usuario usr)
        {
            InitializeComponent();
            u = new Models.Usuario();
            u = usr;
        }

        private static Models.Usuario u;

        private string ip = "http://localhost:52874/";

        private async void Atualizar()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Usuario usr2 = new Models.Usuario
            {
                Id = u.Id,
                Nome = u.Nome,
                Email = txtEmail.Text,
                Senha = txtSenha.Password,
                EstaAutenticado = true,
                Imagem = ""
            };
            string s = "=" + JsonConvert.SerializeObject(usr2);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PutAsync("/api/Usuario/" + usr2.Id, content);
            MessageBox.Show("Atualizado com sucesso!");
        }

        private void FecharJanelas()
        {
            foreach (Window w in Application.Current.Windows)
            {
                if (w.Title != "Rede de Jogos" && w.Title != "") w.Close();
            }
        }

        private void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            Atualizar();
            FecharJanelas();
        }
    }
}
