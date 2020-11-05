using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Security.Cryptography.X509Certificates;

namespace Data
{
    public class DProducto
    {
        public List<Producto> Listar(Producto producto)
        {
            SqlParameter[] parameters = null;

            string comandText = string.Empty;
            List<Producto> productos = null;

            try
            {
                comandText = "USP_GetProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = producto.IdProducto;
                productos = new List<Producto>();

                using (SqlDataReader reader = SqlHelper.ExecuteReader(SqlHelper.Connection, comandText, System.Data.CommandType.StoredProcedure, parameters))
                {

                    while (reader.Read())
                    {
                        productos.Add(new Producto
                        {
                            IdProducto = reader["IdProducto"] != null ? Convert.ToInt32(reader["IdProducto"]) : 0,
                            NombreProducto= reader["nombreProducto"] != null ? Convert.ToString(reader["nombreProducto"]) : string.Empty,
                            IdProveedor = reader["IdProveedor"] != null ? Convert.ToInt32(reader["IdProveedor"]) : 0,
                            IdCategoria = reader["IdCategoria"] != null ? Convert.ToInt32(reader["IdCategoria"]) : 0,
                            CantidadPorUnidad = reader["cantidadPorUnidad"] != null ? Convert.ToString(reader["cantidadPorUnidad"]) : string.Empty,
                            PrecioUnidad = reader["precioUnidad"] != null ? Convert.ToInt32(reader["precioUnidad"]) :0,
                            UnidadesEnExistencia = reader["unidadesEnExistencia"] != null ? Convert.ToInt32(reader["unidadesEnExistencia"]) : 0,
                            UnidadesEnPedido = reader["unidadesEnPedido"] != null ? Convert.ToInt32(reader["unidadesEnPedido"]) : 0,
                            NivelNuevoPedido = reader["nivelNuevoPedido"] != null ? Convert.ToInt32(reader["nivelNuevoPedido"]) : 0,
                            Suspendido = reader["suspendido"] != null ? Convert.ToInt32(reader["suspendido"]) : 0,
                            CategoriaProducto = reader["categoriaProducto"] != null ? Convert.ToString(reader["categoriaProducto"]) : string.Empty,
                        }); ;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;

            }
            return productos;
        }


        public void Insertar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;

            try
            {
                comandText = "USP_InsProducto";
                parameters = new SqlParameter[10];
                parameters[0] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@idProveedor", SqlDbType.Int);
                parameters[1].Value = producto.IdProveedor;
                parameters[2] = new SqlParameter("@idCategoria", SqlDbType.Int);
                parameters[2].Value = producto.IdCategoria;
                parameters[3] = new SqlParameter("@cantidadPorUnidad", SqlDbType.Int);
                parameters[3].Value = producto.CantidadPorUnidad;
                parameters[4] = new SqlParameter("@precioUnidad", SqlDbType.VarChar);
                parameters[4].Value = producto.PrecioUnidad;
                parameters[5] = new SqlParameter("@unidadesEnExitencia", SqlDbType.Int);
                parameters[5].Value = producto.UnidadesEnExistencia;
                parameters[6] = new SqlParameter("@unidadesEnPedido", SqlDbType.Int);
                parameters[6].Value = producto.UnidadesEnPedido;
                parameters[7] = new SqlParameter("@nivelNuevoPedido", SqlDbType.Int);
                parameters[7].Value = producto.NivelNuevoPedido;
                parameters[8] = new SqlParameter("@suspendido", SqlDbType.VarChar);
                parameters[8].Value = producto.NivelNuevoPedido;
                parameters[9] = new SqlParameter("@categoriaProducto", SqlDbType.VarChar);
                parameters[9].Value = producto.CategoriaProducto;


                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Actualizar(Producto producto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_UpdProducto";
                parameters = new SqlParameter[10];
                parameters[0] = new SqlParameter("@nombreProducto", SqlDbType.VarChar);
                parameters[0].Value = producto.NombreProducto;
                parameters[1] = new SqlParameter("@idProveedor", SqlDbType.Int);
                parameters[1].Value = producto.IdProveedor;
                parameters[2] = new SqlParameter("@idCategoria", SqlDbType.Int);
                parameters[2].Value = producto.IdCategoria;
                parameters[3] = new SqlParameter("@cantidadPorUnidad", SqlDbType.VarChar);
                parameters[3].Value = producto.CantidadPorUnidad;
                parameters[4] = new SqlParameter("@precioUnidad", SqlDbType.Int);
                parameters[4].Value = producto.PrecioUnidad;
                parameters[5] = new SqlParameter("@unidadesEnExitencia", SqlDbType.Int);
                parameters[5].Value = producto.UnidadesEnExistencia;
                parameters[6] = new SqlParameter("@unidadesEnPedido", SqlDbType.Int);
                parameters[6].Value = producto.UnidadesEnPedido;
                parameters[7] = new SqlParameter("@nivelNuevoPedido", SqlDbType.Int);
                parameters[7].Value = producto.NivelNuevoPedido;
                parameters[8] = new SqlParameter("@suspendido", SqlDbType.VarChar);
                parameters[8].Value = producto.NivelNuevoPedido;
                parameters[9] = new SqlParameter("@categoriaProducto", SqlDbType.VarChar);
                parameters[9].Value = producto.CategoriaProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);

            }

            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void Eliminar(int IdProducto)
        {
            SqlParameter[] parameters = null;
            string comandText = string.Empty;
            try
            {
                comandText = "USP_DelProducto";
                parameters = new SqlParameter[1];
                parameters[0] = new SqlParameter("@idproducto", SqlDbType.Int);
                parameters[0].Value = IdProducto;
                SqlHelper.ExecuteNonQuery(SqlHelper.Connection, comandText, CommandType.StoredProcedure, parameters);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
