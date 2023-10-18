using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.dtos;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public UsuarioRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<UsuarioDTO> Usuario(int id)
        {
            var entidad = await _db.Usuarios.FindAsync(id);
            var usuario = _mapper.Map<Usuario, UsuarioDTO>(entidad);

            return usuario;
        }

        public async Task<ICollection<UsuarioDTO>> Usuarios()
        {
            var entidades = await _db.Usuarios.ToListAsync();
            var usuarios = _mapper.Map<ICollection<Usuario>, ICollection<UsuarioDTO>>(entidades);

            return usuarios;
        }
        public async Task<int> Crear(UsuarioDTO usuario)
        {
            await _db.Usuarios.AddAsync(_mapper.Map<UsuarioDTO, Usuario>(usuario));

            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var usuario = await _db.Usuarios.FindAsync(id);
            if (usuario == null)
                return 0;

            _db.Usuarios.Remove(usuario);
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, UsuarioDTO usuario)
        {
            var entidad = await _db.Usuarios.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = usuario.Nombre;

            entidad.Direccion = usuario.Direccion;

            entidad.Telefono = usuario.Telefono;

            entidad.Clave = usuario.Clave;

            _db.Usuarios.Update(entidad);


            return await Guardar();
        }

       
    }
}
