using MyVanity.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyVanity.Interfaces
{
    interface InterfaceProducto
    {
        public void crearProducto(Producto vanity);
        public void actualizarProducto(Producto producto);
        public List<Producto> listarProductos();
        public List<Producto> buscarProducto(String parametro, String inicio, String fin);
        public Producto verProductoPorId(string id);
        public void borrarProductoPorId(string id);

    }
}
