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

namespace JogoApp
{
    /// <summary>
    /// Interaction logic for JogoDetalhes.xaml
    /// </summary>
    public partial class JogoDetalhes : Window
    {
        public JogoDetalhes(Models.Jogo j)
        {
            InitializeComponent();
        }
    }
}
