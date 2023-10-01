using Sistema_Inventario.dtos;

namespace Sistema_Inventario.Repositories.Interfaces
{
    public interface IRol
    {
        Task<int> Crear(RolDTO rol);
        Task<ICollection<RolDTO>> Roles();
        Task<RolDTO> Rol(int id);
        Task <int> Modificar(int id, RolDTO rol);
        Task <int> Eliminar(int id);
        Task<int> Guardar();
    }
}
