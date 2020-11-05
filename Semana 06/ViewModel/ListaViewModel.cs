using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Entity;
using System.Windows;

namespace Semana_06.ViewModel
{
    public class ListaProductoViewModel : ViewModelBase
    {
        public ObservableCollection<Producto> Productos { get; set; }
        public ICommand NuevoCommand { set; get; }
        public ICommand ConsultarCommand { set; get; }
        public ListaProductoViewModel()
        {
            Productos = new Model.ProductoModel().Productos;
            NuevoCommand = new RelayCommand<Window>(
                param => Abrir()
                );
            ConsultarCommand = new RelayCommand<object>(
                o => { Productos= (new Model.ProductoModel()).Productos; });
            void Abrir()
            {
                View.ManProducto window = new View.ManProducto();
                window.ShowDialog();
            }
        }
    }
}