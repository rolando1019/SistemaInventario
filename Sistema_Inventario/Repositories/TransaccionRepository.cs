using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.dtos;
using Sistema_Inventario.DTOs;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Repositories
{
    public class TransaccionRepository : ITransaccion
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public TransaccionRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<TransaccionDTO> Transaccion(int id)
        {
            var entidad = await _db.Transacciones.FindAsync(id);
            var transaccion = _mapper.Map<Transaccion, TransaccionDTO>(entidad);

            return transaccion;
        }
        public async Task<ICollection<TransaccionDTO>> Transaccion()
        {
            var entidades = await _db.Transacciones.ToListAsync();
            var transaccion = _mapper.Map<ICollection<Transaccion>, ICollection<TransaccionDTO>>(entidades);

            return transaccion;
        }

        public async Task<int> Crear(GuardarTransaccion guardarTransaccion)
        {
            var entidad = _mapper.Map<GuardarTransaccion, Transaccion>(guardarTransaccion);
            await _db.Transacciones.AddAsync(_mapper.Map<GuardarTransaccion, Transaccion>(guardarTransaccion));

            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var transaccion = await _db.Transacciones.FindAsync(id);
            if (transaccion == null)
                return 0;

            _db.Transacciones.Remove(transaccion);
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, TransaccionDTO transaccion)
        {
            var entidad = await _db.Transacciones.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.TipoTransaccion = transaccion.TipoTransaccion;

            entidad.Cantidad = transaccion.Cantidad;

           _db.Transacciones.Update(entidad);


            return await Guardar();

        }


    }
}
