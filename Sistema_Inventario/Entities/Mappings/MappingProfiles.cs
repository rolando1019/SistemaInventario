using AutoMapper;
using Sistema_Inventario.dtos;
using Sistema_Inventario.DTOs;
using Sistema_Inventario.Entities;

namespace Sistema_Inventario.Mappings
{
    public class MappingProfiles : Profile
    {
            public MappingProfiles()
            {
                //Entidad -> DTO mapeo de clase con clase auxiliar DTO
                CreateMap<Producto, ProductoDTO>();
                CreateMap<Categoria, CategoriaDTO>();
                CreateMap<Rol,RolDTO>();
                CreateMap<Proveedor, ProveedorDTO>();
                CreateMap<Transaccion, TransaccionDTO>();
                CreateMap<Transaccion, GuardarTransaccion>();
                CreateMap<Usuario, UsuarioDTO>();

            //DTO -> Entidad
            CreateMap<ProductoDTO, Producto>();
                CreateMap<CategoriaDTO, Categoria>();
                CreateMap<RolDTO, Rol>();
                CreateMap<ProveedorDTO, Proveedor>();
                CreateMap<TransaccionDTO,Transaccion>();
                CreateMap<GuardarTransaccion,Transaccion>();
                CreateMap<UsuarioDTO, Usuario>();
        }
        }
}
