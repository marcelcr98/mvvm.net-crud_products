using Semana_06.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Semana_06.ViewModel
{
    public class ManProductoViewModel : ViewModelBase
    {
        #region propiedades
        int _ID;
        public int ID
        {
            get { return _ID; }
            set
            {
                if (_ID != value)
                {
                    _ID = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Nombre;
        public string Nombre
        {

            get { return _Nombre; }
            set
            {
                if (_Nombre != value)
                {
                    _Nombre = value;
                    OnPropertyChanged();
                }
            }
        }

        int _Proveedor;
        public int Proveedor
        {
            get { return _Proveedor; }
            set
            {
                if (_Proveedor != value)
                {
                    _Proveedor = value;
                    OnPropertyChanged();
                }
            }
        }

        int _Categoria;
        public int Categoria
        {
            get { return _Categoria; }
            set
            {
                if (_Categoria != value)
                {
                    _Categoria = value;
                    OnPropertyChanged();
                }
            }
        }

        string _Cantidad;
        public string Cantidad
        {

            get { return _Cantidad; }
            set
            {
                if (_Cantidad != value)
                {
                    _Cantidad = value;
                    OnPropertyChanged();
                }
            }
        }

        int _Precio;
        public int Precio
        {
            get { return _Precio; }
            set
            {
                if (_Precio != value)
                {
                    _Precio = value;
                    OnPropertyChanged();
                }
            }
        }


        int _Pedido;
        public int Pedido
        {
            get { return _Pedido; }
            set
            {
                if (_Pedido != value)
                {
                    _Pedido = value;
                    OnPropertyChanged();
                }
            }
        }

        int _Existencia;
        public int Existencia
        {
            get { return _Existencia; }
            set
            {
                if (_Existencia != value)
                {
                    _Existencia = value;
                    OnPropertyChanged();
                }
            }
        }

        int _UPedido;
        public int UPedido
        {
            get { return _UPedido; }
            set
            {
                if (_UPedido != value)
                {
                    _UPedido = value;
                    OnPropertyChanged();
                }
            }
        }

        int _NPedido;
        public int NPedido
        {
            get { return _NPedido; }
            set
            {
                if (_NPedido != value)
                {
                    _NPedido = value;
                    OnPropertyChanged();
                }
            }
        }

        int _Suspendido;
        public int Suspendido
        {
            get { return _Suspendido; }
            set
            {
                if (_Suspendido != value)
                {
                    _Suspendido = value;
                    OnPropertyChanged();
                }
            }
        }

        string _CategoriaP;
        public string CategoriaP
        {

            get { return _CategoriaP; }
            set
            {
                if (_CategoriaP != value)
                {
                    _CategoriaP = value;
                    OnPropertyChanged();
                }
            }
        }



        #endregion
        public ICommand GrabarCommand { set; get; }
        public ICommand CerrarCommand { set; get; }
        public ICommand EliminarCommand { set; get; }
        public ManProductoViewModel()
        {
            GrabarCommand = new RelayCommand<object>(
                o =>
                {
                    if (ID > 0)
                        new ProductoModel().Actualizar(new Entity.Producto
                        {
                            IdProducto = ID,
                            NombreProducto = Nombre,
                            IdProveedor =Proveedor,
                            IdCategoria = Categoria,
                            CantidadPorUnidad = Cantidad,
                            PrecioUnidad=Precio,
                            UnidadesEnExistencia=Existencia,
                            UnidadesEnPedido=UPedido,
                            NivelNuevoPedido=NPedido,
                            Suspendido=Suspendido,
                            CategoriaProducto=CategoriaP
                            
                        });
                    else
                        new ProductoModel().Insertar(new Entity.Producto
                        {
                            NombreProducto = Nombre,
                            IdProveedor = Proveedor,
                            IdCategoria = Categoria,
                            CantidadPorUnidad = Cantidad,
                            PrecioUnidad = Precio,
                            UnidadesEnExistencia = Existencia,
                            UnidadesEnPedido = UPedido,
                            NivelNuevoPedido = NPedido,
                            Suspendido = Suspendido,
                            CategoriaProducto = CategoriaP
                        });
                });
            CerrarCommand = new RelayCommand<Window>(
                param => Cerrar(param)
                );

            EliminarCommand = new RelayCommand<object>(
                  o =>
                  {
                      if (ID > 0)
                          new ProductoModel().Eliminar(ID);

                      else
                          MessageBox.Show("Error al eliminar");


                  });
        }
        void Cerrar(Window window)
        {
            window.Close();
        }


    }
}