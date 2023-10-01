using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.dtos;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Repositories
{
    public class RolRepository : IRol
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public RolRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<int> Crear(RolDTO rol)
        {
            await _db.Roles.AddAsync(_mapper.Map<RolDTO, Rol>(rol));

            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var rol = await _db.Roles.FindAsync(id);
            if (rol == null) 
                return 0;
            _db.Roles.Remove(rol);
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, RolDTO rol)
        {
            var entidad = await _db.Roles.FindAsync(id);
            if (entidad == null)
            return 0;

            entidad.Nombre = rol.Nombre;
            _db.Roles.Update(entidad);
            return await Guardar();
        }

        public async Task<RolDTO> Rol(int id)
        {
            var entidad = await _db.Roles.FindAsync(id);
            var rol = _mapper.Map<Rol, RolDTO>(entidad);

            return rol;
        }

        public async Task<ICollection<RolDTO>> Roles()
        {
            var entidades = await _db.Roles.ToListAsync();
            var roles = _mapper.Map<ICollection<Rol>, ICollection <RolDTO>>(entidades);

            return roles;
        }
    }
}
