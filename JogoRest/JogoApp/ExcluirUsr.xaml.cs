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
    /// Interaction logic for ExcluirUsr.xaml
    /// </summary>
    public partial class ExcluirUsr : Window
    {
        public ExcluirUsr()
        {
            InitializeComponent();
        }

        private string ip = "http://localhost:52874/";

        private async void btnExcluir_Click(object sender, RoutedEventArgs e)
        {
            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri(ip);
            var response = await httpClient.GetAsync("/api/Usuario/");
            var str = response.Content.ReadAsStringAsync().Result;
            List<Models.Usuario> obj = JsonConvert.DeserializeObject<List<Models.Usuario>>(str);
            Models.Usuario usr = obj.Find(x => x.Nome == txtNome.Text);
            if (usr != null)
            {
                if (usr.Senha == txtSenha.Text)
                {
                    await httpClient.DeleteAsync("/api/Usuario/" + usr.Nome);
                    MessageBox.Show("Deletado com sucesso!");
                }
            }
        }
    }
}
