using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entities
{
    public class Transaccion
    {
        [Key]
        public int IdTransaccion { get; set; }

        [ForeignKey(nameof(Producto))]
        public int IdProducto { get; set; }
        public DateTime Fechayhora { get; set; }
        public string TipoTransaccion { get; set; }
        public int Cantidad { get; set; }
               
        [ForeignKey(nameof(Usuario))]
        public int IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
        public Producto Producto { get; set; }
    }
}
