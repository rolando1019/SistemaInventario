using Sistema_Inventario.dtos;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Endpoints
{
    public static class ProveedorEndPoints
    {
        public static void Add(this WebApplication app){
            app.MapGet("api/proveedores", async (IProveedor _proveedor ) =>{
                var proveedores = await _proveedor.Proveedor();
                //200 ok, la solictud se realizo correctamente y se devuelve la lista

                return Results.Ok(proveedores);

            }).WithTags("Proveedor").RequireAuthorization();

            app.MapGet("api/proveedores/{id}", async (int id, IProveedor _proveedor) =>
            {
                var proveedor = await _proveedor.Proveedor(id);
                if (proveedor == null)

                    return Results.NotFound(); // 404 not foud el recurso solicitado no existe
                else
                    return Results.Ok(proveedor);  //200 ok, la solictud se realizo correctamente

            }).WithTags("Proveedor").RequireAuthorization();

            app.MapPost("api/proveedor", async (ProveedorDTO proveedor, IProveedor _proveedor) =>
            {
                if (proveedor == null)
                    return Results.BadRequest(); // 400 Bad request la solictud no se pudo procesar, debido a un error de formato.

                await _proveedor.Crear(proveedor);
                // 201 Created . El recurso se creo con exito. y se devuelve la ubucacion del recurso creado
                return Results.Created("api/proveedores/{proveedor.id}", proveedor);

            }).WithTags("Proveedor").RequireAuthorization();

            app.MapPut("api/proveedor/{id}", async (int id, ProveedorDTO proveedor, IProveedor _proveedor) =>
            {
                var resultado = await _proveedor.Modificar(id, proveedor);
                if (resultado == 0)
                    return Results.NotFound(); // 404 not foud , el recurso solicitado no existe.
                else
                    return Results.Ok(resultado);// 200 ok, la solIcitud se realizo correctamente.

            }).WithTags("Proveedor").RequireAuthorization();

            app.MapDelete("api/proveedor/{id}", async (int id, IProveedor _proveedor) =>
            {
                var resultado = await _proveedor.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound(); // 404 Not found, El recurso solicitado no existe.
                else
                    return Results.NoContent(); // 204 Not content  Recurso eliminado
            }).WithTags("Proveedor").RequireAuthorization();
        }
    
    }
}
