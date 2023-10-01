using Sistema_Inventario.dtos;
using Sistema_Inventario.DTOs;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;


namespace Sistema_Inventario.Endpoints
{
    public static class CategoriaEndpoints
    {
        public static void Add(this WebApplication app) {
            app.MapGet("api/categorias", async (ICategoria _categoria) => {
                var categorias = await _categoria.Categorias();
                //200 ok, la solictud se realizo correctamente y se devuelve la lista

                return Results.Ok(categorias);

            }).WithTags("Categoria");

            app.MapGet("api/categorias/{IdCategoria}", async (int id, ICategoria _categoria) => {
                var categoria = await _categoria.Categoria(id);
                if (categoria == null)

                    return Results.NotFound(); // 404 not foud el recurso solicitado no existe
                else
                    return Results.Ok(categoria);  //200 ok, la solictud se realizo correctamente

            }).WithTags("Categoria");

            app.MapPost("api/categoria", async (CategoriaDTO categoria, ICategoria _categoria) => {
                if (categoria == null)
                    return Results.BadRequest(); // 400 Bad request la solictud no se pudo procesar, debido a un error de formato.

                await _categoria.Crear(categoria);
                // 201 Created . El recurso se creo con exito. y se devuelve la ubucacion del recurso creado
                return Results.Created("api/categorias/{categoria.IdCategoria}", categoria);

            }).WithTags("Categoria");

            app.MapPut("api/categoria/{IdCategoria}", async (int id, CategoriaDTO categoria, ICategoria _categoria) => {
                var resultado = await _categoria.Modificar(id, categoria);
                if (resultado == 0)
                    return Results.NotFound(); // 404 not foud , el recurso solicitado no existe.
                else
                    return Results.Ok(resultado);// 200 ok, la solIcitud se realizo correctamente.

            }).WithTags("Categoria");

            app.MapDelete("api/categoria/{IdCategoria}", async (int id, ICategoria _categoria) => {
                var resultado = await _categoria.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound(); // 404 Not found, El recurso solicitado no existe.
                else
                    return Results.NoContent(); // 204 Not content  Recurso eliminado

            }).WithTags("Categoria");
        }
    }
}
