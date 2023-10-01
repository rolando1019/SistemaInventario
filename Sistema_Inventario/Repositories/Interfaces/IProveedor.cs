using Sistema_Inventario.dtos;

namespace Sistema_Inventario.Repositories.Interfaces
{
    public interface IProveedor
    {
        Task<int> Crear(ProveedorDTO proveedor);

        Task<ICollection<ProveedorDTO>> Proveedor();

        Task<ProveedorDTO> Proveedor(int id);

        Task<int> Modificar(int id, ProveedorDTO proveedor);
        Task<int> Eliminar(int id);

        Task<int> Guardar();
    }
}
