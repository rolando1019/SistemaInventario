namespace Sistema_Inventario.DTOs
{
    public class ProductoDTO
    {
        public int IdProducto { get; set; }

        public string Nombre { get; set; }

        public string Desripcion { get; set; }

        public int IdCategoria { get; set; }

        public decimal Precio { get; set; }

        public int Stock { get; set; }

        public int IdProveedor { get; set; }
    
}
}
