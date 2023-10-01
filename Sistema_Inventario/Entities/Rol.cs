using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.Entities
{
    public class Rol
    {
        [Key]
        public int IdRol { get; set; }
        public string Nombre { get; set; }
    }
}
