using System;
using Semana_06.ViewModel;
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

namespace Semana_06.View
{
    /// <summary>
    /// Lógica de interacción para ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        ManProductoViewModel viewModel;
        public int ID { get; set; }
        public ManProducto()
        {
            InitializeComponent();
            viewModel = new ManProductoViewModel();
            this.DataContext = viewModel;

        }
    }
}
