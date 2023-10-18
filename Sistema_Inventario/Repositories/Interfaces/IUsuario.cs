using Sistema_Inventario.dtos;

namespace Sistema_Inventario.Repositories.Interfaces
{
    public interface IUsuario
    {
        Task<int> Crear(UsuarioDTO usuario);
        Task<ICollection<UsuarioDTO>> Usuarios();
        Task<UsuarioDTO> Usuario(int id);

        Task<int> Modificar(int id, UsuarioDTO usuario);

        Task<int> Eliminar(int id);

        Task<int> Guardar();
    }
}
