using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity;
using Business;
using System.Collections.ObjectModel;

namespace Semana_06.Model
{
    public class ProductoModel
    {
        public ObservableCollection<Producto> Productos { get; set; }
        public bool Insertar(Producto producto)
        {
            return (new BProducto()).Insertar(producto);
        }

        public bool Actualizar(Producto producto)
        {
            return (new BProducto()).Actualizar(producto);
        }

        public bool Eliminar(int IdProducto)
        {
            return (new BProducto()).Eliminar(IdProducto);
        }

        public ProductoModel()
        {
            var lista = (new BProducto().Listar(0));
            Productos = new ObservableCollection<Producto>(lista);
        }

    }
}
