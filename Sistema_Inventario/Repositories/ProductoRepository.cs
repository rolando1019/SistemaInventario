using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.DTOs;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;
using Sistema_Inventario.dtos;

namespace Sistema_Inventario.Repositories
{
    public class ProductoRepository : IProducto
    {
                private readonly ApplicationDbContext _db;
                private readonly IMapper _mapper;

                public ProductoRepository(ApplicationDbContext db, IMapper mapper)
                {
                    _db = db;
                    _mapper = mapper;
                }
        public async Task<ProductoDTO> Producto(int id)
        {
            var entidad = await _db.Productos.FindAsync(id);
            var producto = _mapper.Map<Producto, ProductoDTO>(entidad);

            return producto;
        }

        public async Task<ICollection<ProductoDTO>> productos()
        {
            var entidades = await _db.Productos.ToListAsync();
            var productos = _mapper.Map<ICollection<Producto>, ICollection<ProductoDTO>>(entidades);

            return productos;
        }
        public async Task<int> Crear(ProductoDTO producto)
        {
            var entidad = _mapper.Map<ProductoDTO, Producto>(producto);
             await _db.Productos.AddAsync(_mapper.Map<ProductoDTO, Producto>(producto));

                    return await Guardar();
        }

        public async Task<int> Eliminar(int id)
        {
            var producto = await _db.Productos.FindAsync(id);
            if (producto == null)
                return 0;

            _db.Productos.Remove(producto);
            return await Guardar();
        }

        public async Task<int> Guardar()
        {
            return await _db.SaveChangesAsync();
        }

        public async Task<int> Modificar(int id, ProductoDTO producto)
        {
            var entidad = await _db.Productos.FindAsync(id);
            if (entidad == null)
                return 0;

            entidad.Nombre = producto.Nombre;

            entidad.Desripcion = producto.Desripcion;

            entidad.Precio = producto.Precio;

            entidad.Stock = producto.Stock;

            _db.Productos.Update(entidad);


            return await Guardar();

        }

       
    }
}

