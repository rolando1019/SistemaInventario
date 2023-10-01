using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.dtos;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Repositories
{
    public class ProveedorRepository : IProveedor
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;

        public ProveedorRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        public async Task<ProveedorDTO> Proveedor(int id)
        {
            var entidad = await _db.Proveedores.FindAsync(id);
            var proveedor = _mapper.Map<Proveedor, ProveedorDTO>(entidad);

            return proveedor;
        }

        public async Task<ICollection<ProveedorDTO>> Proveedor()
        {
            var entidades = await _db.Proveedores.ToListAsync();
            var proveedores = _mapper.Map<ICollection<Proveedor>, ICollection<ProveedorDTO>>(entidades);

            return proveedores;
        }

       
        public async Task<int> Crear(ProveedorDTO proveedor)
        {
            var entidad = _mapper.Map<ProveedorDTO, Proveedor>(proveedor);
            await _db.Proveedores.AddAsync(entidad);
            return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var proveedor = await _db.Proveedores.FindAsync(id);
            if (proveedor == null)
                return 0;

            _db.Proveedores.Remove(proveedor);
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, ProveedorDTO proveedor)
        {
            var entidad = await _db.Proveedores.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = proveedor.Nombre;
            entidad.Empresa = proveedor.Empresa;
            entidad.Direccion = proveedor.Direccion;
            entidad.Correo = proveedor.Correo;
            entidad.Telefono = proveedor.Telefono;

            _db.Proveedores.Update(entidad);

            return await Guardar();
        }

            
    }
}
