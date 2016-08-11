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
        public AtualizarUsr()
        {
            InitializeComponent();
        }

        private string ip = "http://localhost:52874/";

        private async void btnAtualizar_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.Nome == txtNome.Text);
            Models.Usuario usr2 = new Models.Usuario
            {
                Id = usr.Id,
                Nome = usr.Nome,
                Email = txtEmail.Text,
                Senha = txtSenha.Text,
                Imagem = ""
            };
            string s = "=" + JsonConvert.SerializeObject(usr2);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PutAsync("/api/Usuario/" + usr2.Id, content);
            MessageBox.Show("Atualizado com sucesso!");
        }
    }
}
