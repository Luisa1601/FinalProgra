
using MyVanity.Implementaciones;
using MyVanity.Modelos;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Input;

namespace MyVanity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Colores> colores = new List<Colores>();
        ClsProducto crud = new ClsProducto();
        String idActualizar = "";
        public MainWindow()
        {
            InitializeComponent();
            listarProductos();
        }

        public void llenarColores()
        {
            colores.Add(new Colores("Negro"));
            colores.Add(new Colores("Azul"));
        }

        public object VanityImplements { get; private set; }

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {

            var producto = new Producto();

            string nombre = txtProductoNombre.Text;
            string descripcion = txtProductoDescripcion.Text;
            string categoria = txtCategoria.Text;

            if (nombre.Equals("")  || categoria.Equals(""))
            {
                MessageBox.Show("Campos vacíos");
                return;
            }

            if (!(txtProductoPrecio.Text.Equals("") || txtProductoCantidad.Text.Equals("")))
            {

                double precio = double.Parse(txtProductoPrecio.Text);
                int cantidad = int.Parse(txtProductoCantidad.Text);
                double total = precio * cantidad;
                string tonoPiel = txtTonoPiel.Text;
                string color = txtColor.Text;

                
                producto = new Producto(nombre, descripcion, precio, cantidad, total, tonoPiel, categoria, color, DateTime.Now); 

            } else
            {
                MessageBox.Show("Unidades o precio vacío");

                return;
            }

           

            if(btnGuardar.Content.ToString() == "Guardar")
            {   
                crud.crearProducto(producto);
                MessageBox.Show("Producto guardado con éxito");
            } else
            {
                producto.Id = idActualizar;
                crud.actualizarProducto(producto);
                MessageBox.Show("Producto actualizado con éxito");
                
            }



            // MessageBox.Show(nombre + " guardado");
            listarProductos();
            limpiarCampos();
        }

        private void limpiarCampos()
        {
            txtProductoNombre.Text = "";
            txtProductoDescripcion.Text = "";
            txtCategoria.Text = "";
            txtProductoPrecio.Text = "";
            txtProductoCantidad.Text = "";
            txtTonoPiel.Text = "";
            txtColor.Text = "";

            btnGuardar.Content = "Guardar";
        }

        private void listarProductos()
        {
            var productos = crud.listarProductos();

            tableProductos.DataContext = productos;
            //return crud.listarProductos();
        }

        private void tableProductos_MouseClick(object sender, MouseButtonEventArgs e)
        {
            funcionEditar();
        }

        private void funcionEditar()
        {
            Producto producto = (Producto)tableProductos.SelectedItem;

            txtProductoNombre.Text = producto.Nombre;
            txtCategoria.Text = producto.Categoria;
            txtProductoPrecio.Text = producto.Precio.ToString();
            txtProductoCantidad.Text = producto.Cantidad.ToString();
            txtColor.Text = producto.Color;
            txtTonoPiel.Text = producto.TonoPiel;
            txtProductoDescripcion.Text = producto.Descripcion;

            idActualizar = producto.Id;
            btnGuardar.Content = "Actualizar";
            btnGuardar.ToolTip = "Actualizar";
        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            limpiarCampos();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            tableProductos.DataContext = null;

            var parametro = txtProductoBuscar.Text;
            String inicio = dpDesde.SelectedDate.Value.Date.ToString("yyyy-MM-dd");
            String fin = dpHasta.SelectedDate.Value.Date.ToString("yyyy-MM-dd");

            var productos = crud.buscarProducto(parametro, inicio, fin);

            MessageBox.Show(inicio.ToString());

           
            tableProductos.DataContext = productos;
           

            
        }

        private void btnMember_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            funcionEditar();
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            Producto producto = null;
            try
            {
                producto = (Producto)tableProductos.SelectedItem;
                if(!(producto == null))
                {
                    crud.borrarProductoPorId(producto.Id);
                    MessageBox.Show("Eliminado correctamente");
                    listarProductos();
                } else
                {
                    MessageBox.Show("Seleccione un producto");
                }
            } catch(Exception ex)
            {
                MessageBox.Show("Seleccione un producto");
            }
           

           
        }

        private void btnDescargar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnVer_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
