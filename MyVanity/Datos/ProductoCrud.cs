using MySql.Data.MySqlClient;
using MyVanity.Modelos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVanity.Datos
{
    class ProductoCrud
    {
        public ProductoCrud()
        {
        }

        public void crearProducto(Producto producto)
        {
            string query = "INSERT INTO PRODUCTOS (nombre, descripcion, precio, cantidad, total, tono_piel, categoria, color, fecha_compra) " +
                "VALUES ('" + producto.Nombre + 
                "', '" + producto.Descripcion + 
                "', '" + producto.Precio + 
                "', '" + producto.Cantidad + 
                "', '" + producto.Total + 
                "', '" + producto.TonoPiel + 
                "', '" + producto.Categoria + 
                "', '" + producto.Color + 
                "', '" + producto.FechaCompra + "')";

            MySqlConnection conexionDb = Conexion.conexion();
            conexionDb.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionDb);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                conexionDb.Close();
            }
        }

        public List<Producto> listarProductos()
        {
            string query = "SELECT * FROM PRODUCTOS";
            List<Producto> productos = new List<Producto>();

            MySqlConnection conexionDb = Conexion.conexion();
            conexionDb.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionDb);
                //comando.ExecuteNonQuery();

                using(MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Producto();
                        producto.Id = reader["id"].ToString();
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Descripcion = reader["descripcion"].ToString();
                        producto.Precio = Convert.ToDouble(reader["precio"].ToString());
                        producto.Cantidad = int.Parse(reader["cantidad"].ToString());
                        producto.Total = double.Parse(reader["total"].ToString());
                        producto.TonoPiel = reader["tono_piel"].ToString();
                        producto.Categoria = reader["categoria"].ToString();
                        producto.Color = reader["color"].ToString();
                        producto.FechaCompra = Convert.ToDateTime(reader["fecha_compra"].ToString());
                        productos.Add(producto);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            finally
            {
                conexionDb.Close();
            }

            return productos;
        }

        public void actualizarProducto(Producto producto)
        {
            string query = "UPDATE PRODUCTOS SET nombre = '"
                +producto.Nombre+"' , descripcion = '"
                +producto.Descripcion+"' , precio = "
                +producto.Precio+" , cantidad = "
                +producto.Cantidad+" , total = "
                +(producto.Precio * producto.Cantidad)+" , tono_piel = '"
                +producto.TonoPiel+"' , categoria = '"
                +producto.Categoria+"' , color = '"
                +producto.Color+"' , fecha_compra = '"
                +producto.FechaCompra+"' WHERE id = '" + producto.Id + "'";

            MySqlConnection conexionDb = Conexion.conexion();
            conexionDb.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionDb);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                conexionDb.Close();
            }
        }

        public List<Producto> buscarProductos(String parametro, String inicio, String fin)
        {
            string query = "SELECT * FROM PRODUCTOS WHERE (nombre LIKE '%" + parametro + "%'" +
                " OR categoria LIKE '%" + parametro + "%'" +
                " OR tono_piel LIKE '%" + parametro + "%'" +
                " OR color LIKE '%" + parametro + "%') AND (fecha_compra BETWEEN '"+inicio+"' AND '"+fin+"')";
            List<Producto> productos = new List<Producto>();

            MySqlConnection conexionDb = Conexion.conexion();
            conexionDb.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionDb);
                //comando.ExecuteNonQuery();

                using (MySqlDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var producto = new Producto();
                        producto.Nombre = reader["nombre"].ToString();
                        producto.Descripcion = reader["descripcion"].ToString();
                        producto.Precio = Convert.ToDouble(reader["precio"].ToString());
                        producto.Cantidad = int.Parse(reader["cantidad"].ToString());
                        producto.Total = double.Parse(reader["total"].ToString());
                        producto.TonoPiel = reader["tono_piel"].ToString();
                        producto.Categoria = reader["categoria"].ToString();
                        producto.Color = reader["color"].ToString();
                        producto.FechaCompra = Convert.ToDateTime(reader["fecha_compra"].ToString());
                        productos.Add(producto);
                    }
                }
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

            finally
            {
                conexionDb.Close();
            }

            return productos;
        }

        public void eliminarProductoPorId(string id)
        {
            string query = "DELETE FROM PRODUCTOS WHERE id = " + id;
            MySqlConnection conexionDb = Conexion.conexion();
            conexionDb.Open();

            try
            {
                MySqlCommand comando = new MySqlCommand(query, conexionDb);
                comando.ExecuteNonQuery();
            }
            catch (MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                conexionDb.Close();
            }
        }

    }
}
