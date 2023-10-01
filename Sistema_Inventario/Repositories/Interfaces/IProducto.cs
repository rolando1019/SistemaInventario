using Sistema_Inventario.DTOs;
using Sistema_Inventario.dtos;
namespace Sistema_Inventario.Repositories.Interfaces
{
    public interface IProducto  {
        Task<int> Crear(ProductoDTO producto);

        Task<ICollection<ProductoDTO>> productos();

        Task<ProductoDTO> Producto(int id);
        
        Task<int> Modificar(int id, ProductoDTO producto);
        Task<int> Eliminar(int id);

         Task<int> Guardar();
        
    }
}
