using System;
using System.Collections.Generic;
using Business;
using Entity;
using System.Windows;
namespace Semana_06
{
    /// <summary>
    /// Lógica de interacción para ManProducto.xaml
    /// </summary>
    public partial class ManProducto : Window
    {
        public int ID { get; set; }
        public ManProducto(int Id)
        {
            InitializeComponent();
            ID = Id;
            if (ID > 0)
            {
                BtnEliminar.Opacity = 100;
                BtnEliminar.IsEnabled = true;

                BProducto bProducto = new BProducto();
                List<Producto> productos = new List<Producto>();
                productos = bProducto.Listar(ID);
                if (productos.Count > 0)
                {
                    lblID.Content = productos[0].IdProducto;
                    txtnombre.Text = productos[0].NombreProducto;
                    txtidproveedor.Text = productos[0].IdProveedor.ToString();
                    txtidcategoria.Text = productos[0].IdCategoria.ToString();
                    txtcantidad.Text = productos[0].CantidadPorUnidad;
                    txtprecio.Text = productos[0].PrecioUnidad.ToString();
                    txtexistentes.Text = productos[0].UnidadesEnExistencia.ToString();
                    txtiunipedido.Text = productos[0].UnidadesEnPedido.ToString();
                    txtnivel.Text = productos[0].NivelNuevoPedido.ToString();
                    txtsuspendido.Text = productos[0].Suspendido.ToString();
                    txtcategoria.Text = productos[0].CategoriaProducto;

                }

            }
        }

        private void BtnGrabar_Click(object sender, RoutedEventArgs e)
        {

            BProducto BProducto = null;
            bool result = true;
            try
            {
                BProducto = new BProducto();
                if (this.ID > 0)
                {
                    result = BProducto.Actualizar(new Producto { IdProducto = this.ID, NombreProducto = txtnombre.Text, IdProveedor = Convert.ToInt32(txtidproveedor.Text ), IdCategoria = Convert.ToInt32(txtidcategoria.Text), CantidadPorUnidad = txtcantidad.Text, PrecioUnidad = Convert.ToInt32(txtprecio.Text), UnidadesEnExistencia = Convert.ToInt32(txtexistentes.Text), UnidadesEnPedido = Convert.ToInt32(txtiunipedido.Text), NivelNuevoPedido = Convert.ToInt32(txtnivel.Text),Suspendido = Convert.ToInt32(txtsuspendido.Text), CategoriaProducto = txtcategoria.Text });
                }
                else
                {
                    result = BProducto.Insertar(new Producto { NombreProducto = txtnombre.Text, IdProveedor = Convert.ToInt32(txtidproveedor.Text), IdCategoria = Convert.ToInt32(txtidcategoria.Text), CantidadPorUnidad = txtcantidad.Text, PrecioUnidad = Convert.ToInt32(txtprecio.Text), UnidadesEnExistencia = Convert.ToInt32(txtexistentes.Text), UnidadesEnPedido = Convert.ToInt32(txtiunipedido.Text), NivelNuevoPedido = Convert.ToInt32(txtnivel.Text), Suspendido = Convert.ToInt32(txtsuspendido.Text), CategoriaProducto = txtcategoria.Text });
                }

                if (!result)
                {
                    MessageBox.Show("Error");
                }

                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Ha ocurrido un error. Debe Comunicarse con el administrador");
            }
            finally
            {
                BProducto = null;
            }

        }

        private void BtnCerrar_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnEliminar_Click(object sender, RoutedEventArgs e)
        {

            BProducto BProducto = null;
            bool result = true;
            try
            {
                BProducto = new BProducto();
                if (this.ID > 0)
                {
                    result = BProducto.Eliminar(this.ID);
                }

                if (!result)
                {
                    MessageBox.Show("Error al eliminar");
                }

                Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Comunicarse con el administrador");
            }
            finally
            {
                BProducto = null;
            }

        }
    }
}
