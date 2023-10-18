using Sistema_Inventario.dtos;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Endpoints
{
    public static class UsuarioEndpoints
    {
        public static void Add(this WebApplication app)
        {
            app.MapGet("api/usuarios", async (IUsuario _usuario) =>
            {
                var usuarios = await _usuario.Usuarios();
                //200 ok, la solictud se realizo correctamente y se devuelve la lista

                return Results.Ok(usuarios);

            }).WithTags("Usuario");

            app.MapGet("api/usuarios/{id}", async (int id, IUsuario _usuario) =>
            {
                var usuario = await _usuario.Usuario(id);
                if (usuario == null)

                    return Results.NotFound(); // 404 not foud el recurso solicitado no existe
                else
                    return Results.Ok(usuario);  //200 ok, la solictud se realizo correctamente

            }).WithTags("Usuario");

            app.MapPost("api/usuarios", async (UsuarioDTO usuario, IUsuario _usuario) =>
            {
                if (usuario == null)
                    return Results.BadRequest(); // 400 Bad request la solictud no se pudo procesar, debido a un error de formato.

                await _usuario.Crear(usuario);
                // 201 Created . El recurso se creo con exito. y se devuelve la ubucacion del recurso creado
                return Results.Created("api/usuarios/{usuario.id}", usuario);

            }).WithTags("Usuario");

            app.MapPut("api/usuario/{id}", async (int id, UsuarioDTO usuario, IUsuario _usuario) =>
            {
                var resultado = await _usuario.Modificar(id, usuario);
                if (resultado == 0)
                    return Results.NotFound(); // 404 not foud , el recurso solicitado no existe.
                else
                    return Results.Ok(resultado);// 200 ok, la solIcitud se realizo correctamente.

            }).WithTags("Usuario");

            app.MapDelete("api/usuario/{id}", async (int id, IUsuario _usuario) =>
            {
                var resultado = await _usuario.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound(); // 404 Not found, El recurso solicitado no existe.
                else
                    return Results.NoContent(); // 204 Not content  Recurso eliminado
            }).WithTags("Usuario");

        }
    }
    
} 
  