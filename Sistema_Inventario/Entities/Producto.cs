using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entities
{
    public class Producto { 

    [Key]
    public int IdProducto { get; set; }

    public string Nombre { get; set; }

    public string Desripcion { get; set; }
    
    [ForeignKey(nameof(Categoria))]
    public int IdCategoria {  get; set; }

    public Decimal Precio { get; set; }

    public int Stock { get; set; }

    [ForeignKey(nameof(Proveedor))]
    public int IdProveedor { get; set; }

        // Definir relaciones con otras tablas

       public Categoria Categoria { get; set; }
       public Proveedor Proveedor { get; set; }

    }
    
    
}

