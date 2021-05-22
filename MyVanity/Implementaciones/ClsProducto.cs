using MyVanity.Datos;
using MyVanity.Interfaces;
using MyVanity.Modelos;
using System;
using System.Collections.Generic;

namespace MyVanity.Implementaciones
{
    class ClsProducto : InterfaceProducto
    {
        private ProductoCrud crud = new ProductoCrud();
        public void crearProducto(Producto producto)
        {
            crud.crearProducto(producto);
        }

        public void actualizarProducto(Producto producto)
        {
            crud.actualizarProducto(producto);
        }

        public void borrarProductoPorId(string id)
        {
            crud.eliminarProductoPorId(id);
        }

        public List<Producto> listarProductos()
        {
           return crud.listarProductos();
        }

        public List<Producto> buscarProducto(string parametro, String inicio, String fin)
        {
            return crud.buscarProductos(parametro, inicio, fin);
        }

        Producto InterfaceProducto.verProductoPorId(string id)
        {
            throw new System.NotImplementedException();
        }
    }
}
