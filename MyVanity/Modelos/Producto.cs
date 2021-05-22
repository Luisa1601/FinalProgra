using System;


namespace MyVanity.Modelos
{
    class Producto
    {
        private string id;
        private String nombre;
        private String descripcion;
        private Double precio;
        private int cantidad;
        private Double total;
        private String tonoPiel;
        private String categoria;
        private String color;
        private DateTime fechaCompra;
       
        public Producto()
        {
        }
        public Producto(string nombre, string descripcion , double precio, int cantidad, double total, string tonoPiel, string categoria, string color, DateTime fechaCompra)
        {
            this.Nombre = nombre;
            this.Descripcion = descripcion;
            this.Precio = precio;
            this.Cantidad = cantidad;
            this.Total = total;
            this.TonoPiel = tonoPiel;
            this.Categoria = categoria;
            this.Color = color;
            this.FechaCompra = fechaCompra;
        }

        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public double Precio { get => precio; set => precio = value; }
        public int Cantidad { get => cantidad; set => cantidad = value; }
        public double Total { get => total; set => total = value; }
        public string TonoPiel { get => tonoPiel; set => tonoPiel = value; }
        public string Categoria { get => categoria; set => categoria = value; }
        public string Color { get => color; set => color = value; }
        public DateTime FechaCompra { get => fechaCompra; set => fechaCompra = value; }
    }
}
