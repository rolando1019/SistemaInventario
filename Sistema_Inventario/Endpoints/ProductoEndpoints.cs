using Sistema_Inventario.DTOs;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Endpoints
{
    public static class ProductoEndpoints
    {
        public static void Add(this WebApplication app)
        {
            app.MapGet("api/productos", async (IProducto _producto) =>
            {
                var productos = await _producto.productos();
                //200 ok, la solictud se realizo correctamente y se devuelve la lista

                return Results.Ok(productos);

            }).WithTags("Producto").RequireAuthorization();

            app.MapGet("api/productos/{IdProducto}", async (int id, IProducto _producto) =>
            {
                var producto = await _producto.Producto(id);
                if (producto == null)

                    return Results.NotFound(); // 404 not foud el recurso solicitado no existe
                else
                    return Results.Ok(producto);  //200 ok, la solictud se realizo correctamente

            }).WithTags("Producto").RequireAuthorization();

            app.MapPost("api/productos", async (ProductoDTO producto, IProducto _producto) =>
            {
                if (producto == null)
                    return Results.BadRequest(); // 400 Bad request la solictud no se pudo procesar, debido a un error de formato.

                await _producto.Crear(producto);
                // 201 Created . El recurso se creo con exito. y se devuelve la ubucacion del recurso creado
                return Results.Created("api/productos/{producto.id}", producto);

            }).WithTags("Producto").RequireAuthorization();

            app.MapPut("api/producto/{id}", async (int id, ProductoDTO producto, IProducto _producto) =>
            {
                var resultado = await _producto.Modificar(id, producto);
                if (resultado == 0)
                    return Results.NotFound(); // 404 not foud , el recurso solicitado no existe.
                else
                    return Results.Ok(resultado);// 200 ok, la solIcitud se realizo correctamente.

            }).WithTags("Producto").RequireAuthorization();

            app.MapDelete("api/producto/{id}", async (int id, IProducto _producto) =>
            {
                var resultado = await _producto.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound(); // 404 Not found, El recurso solicitado no existe.
                else
                    return Results.NoContent(); // 204 Not content  Recurso eliminado
            }).WithTags("Producto").RequireAuthorization();

        }
    }
}
