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
using Microsoft.Win32;

namespace JogoApp
{
    /// <summary>
    /// Interaction logic for CadastrarUsr.xaml
    /// </summary>
    public partial class CadastrarUsr : Window
    {
        public CadastrarUsr()
        {
            InitializeComponent();
        }

        private string ip = "http://localhost:52874/";

        private async void ChecarNome()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.Nome == txtNome.Text);
            if (usr == null) Cadastrar();
            else MessageBox.Show("Nome de usuário já existe!");
        }

        private async void Cadastrar()
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            Models.Usuario u = new Models.Usuario
            {
                Nome = txtNome.Text,
                Email = txtEmail.Text,
                Senha = txtSenha.Password,
                Imagem = "",
                EstaAutenticado = false
            };
            List<Models.Usuario> list = new List<Models.Usuario>();
            list.Add(u);
            string s = "=" + JsonConvert.SerializeObject(list);
            var content = new StringContent(s, Encoding.UTF8, "application/x-www-form-urlencoded");
            await httpClient.PostAsync("/api/Usuario/", content);
            MessageBox.Show("Cadastrado com sucesso!");
        }

        private void btnCad_Click(object sender, RoutedEventArgs e)
        {
            ChecarNome();
        }
    }
}
