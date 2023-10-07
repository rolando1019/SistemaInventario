using Sistema_Inventario.dtos;
using Sistema_Inventario.DTOs;

namespace Sistema_Inventario.Repositories.Interfaces
{
    public interface ITransaccion
    {
        Task<int> Crear(GuardarTransaccion guardarTransaccion);

        Task<ICollection<TransaccionDTO>> Transaccion();

        Task<TransaccionDTO> Transaccion(int id);

        Task<int> Modificar(int id, TransaccionDTO transaccion);
        Task<int> Eliminar(int id);

        Task<int> Guardar();

        
    }
}
