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
using Business;
using Entity;

namespace Semana_06
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public void Cargar()
        {
            BProducto BProducto = null;
            try
            {
                BProducto = new BProducto();
                dgvProducto.ItemsSource = BProducto.Listar(0);

            }
            catch (Exception)
            {
                MessageBox.Show("Ha ocurrido un error. Debe comunicarse con el Administrador");
            }
            finally
            {
                BProducto= null;
            }
        }

        private void BtnNuevo_Click(object sender, RoutedEventArgs e)
        {
            ManProducto manProducto = new ManProducto(0);
            manProducto.ShowDialog();
            Cargar();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            Cargar();

        }

        private void DgvProducto_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            int idProducto;
            var item = (Producto)dgvProducto.SelectedItem;
            if (item == null) return;
            idProducto = Convert.ToInt32(item.IdProducto);
            ManProducto manProducto = new ManProducto(idProducto);
            manProducto.ShowDialog();
            Cargar();

        }
    }
}
