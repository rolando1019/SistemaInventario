using Sistema_Inventario.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.dtos
{
    public class TransaccionDTO
    {
        public int IdTransaccion { get; set; }
        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        public DateTime Fechayhora { get; set; }
        public string TipoTransaccion { get; set; }
        public decimal Cantidad { get; set; }
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public Producto Producto { get; set; }
    }
}
