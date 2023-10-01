using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.Entities
{
    public class Categoria
    {
        [Key]
        public int IdCategoria { get; set; }
        public string Nombre { get; set;}
        public string Descripcion { get;set; }
    }
}
