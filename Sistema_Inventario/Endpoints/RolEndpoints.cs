using Sistema_Inventario.dtos;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Endpoints
{
    public static class RolEndpoints
    {
        public static void Add(this WebApplication app) { 
            app.MapGet("api/roles", async (IRol _rol) => {
                var roles = await _rol.Roles();
                //200 OK - La solicitud se realizó correctamente
                //y se devuelve una lista
                return Results.Ok(roles);
            }).WithTags("Rol");

            app.MapGet("api/roles/{IdRol}", async (int IdRol, IRol _rol) => {
                var rol = await _rol.Rol(IdRol);
                if (rol == null)
                    return Results.NotFound();//404 Not Found - El recurso solicitado no existe
                else 
                    return Results.Ok(rol);//200 OK -La solicitud se realizó correctamente
            }).WithTags("Rol");

            app.MapPost("api/rol", async (RolDTO rol, IRol _rol) => {
                if (rol == null)
                    return Results.BadRequest(); // 400 Bad request la solictud no se pudo procesar, debido a un error de formato.

                await _rol.Crear(rol);
                // 201 Created . El recurso se creo con exito. y se devuelve la ubucacion del recurso creado
                return Results.Created("api/roles/{rol.IdRol}", rol);

            }).WithTags("Rol");

            app.MapPut("api/roles/{IdRol}", async (int IdRol, RolDTO rol, IRol _rol) => { 
                var resultado = await _rol.Modificar(IdRol, rol);
                if(resultado == 0)
                    return Results.NotFound(); //404 - NotFound - El recurso solicitado no existe
                else
                    return Results.Ok(resultado); //200 OK - La solicitud se realizó correctamente
            }).WithTags("Rol");

            app.MapDelete("api/rol/{IdRol}", async (int IdRol, IRol _rol) => {
                var resultado = await _rol.Eliminar(IdRol);
                if (resultado == 0)
                    return Results.NotFound(); //404 - NotFound - El recurso solicitado no existe
                else
                    return Results.NoContent(); //204 No Content - Recurso eliminado
            }).WithTags("Rol");
        }
    }
}
