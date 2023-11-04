using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Sistema_Inventario.Context;
using Sistema_Inventario.dtos;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;
using Sistema_Inventario.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Sistema_Inventario.Repositories
{
    public class UsuarioRepository : IUsuario
    {
        private readonly ApplicationDbContext _db;
        private readonly IMapper _mapper;
        private readonly TokenSetting _tokenSetting;
        public UsuarioRepository(ApplicationDbContext db, IMapper mapper, IOptions<TokenSetting> tokenSetting)
        {
            _db = db;
            _mapper = mapper;
            _tokenSetting = tokenSetting.Value;
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

        
        public string GenerarToken(UsuarioDTO usuario)
        {
            var claveSimetrica = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_tokenSetting.Key));
            var credenciales = new SigningCredentials(claveSimetrica, SecurityAlgorithms.HmacSha256);
            var ClaimsUsuario = new List<Claim>
            { 
            new Claim("id",usuario.IdUsuario.ToString()),
            new Claim(ClaimTypes.Name, usuario.Nombre),
            new Claim(ClaimTypes.MobilePhone, usuario.Telefono),
            new Claim(ClaimTypes.StreetAddress,usuario.Direccion),
            };
            var jwt = new JwtSecurityToken(
                issuer: _tokenSetting.Issuer,
                audience: _tokenSetting.Audience,
                expires: DateTime.Now.AddHours(72),//TIEMPO DE DURACION DEL TOKEN
                signingCredentials: credenciales,
                claims: ClaimsUsuario
                );
            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public async Task<UsuarioDTO> Login(UsuarioLogin login)
        {
            var entidad = await _db.Usuarios.FirstOrDefaultAsync(x => x.Nombre == login.Nombre && x.Clave ==login.Clave);
            var usuario = _mapper.Map<Usuario, UsuarioDTO>(entidad);
            return usuario;
        }
    }
}
