using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.dtos
{
    public class UsuarioDTO
    {
        [Key]
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public string Telefono { get; set; }
        public int IdRol { get; set; }
        public string Clave { get; set; }

       
    }

    public class UsuarioLogin
    {
        
        
        public string Nombre { get; set; }
        public string Clave { get; set; }

        
    }


}
