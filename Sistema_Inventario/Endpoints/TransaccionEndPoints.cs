using Sistema_Inventario.dtos;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Repositories.Interfaces;

namespace Sistema_Inventario.Endpoints
{
    public static class TransaccionEndPoints
    {
        public static void Add(this WebApplication app)
        {
            app.MapGet("api/transacciones", async (ITransaccion _transaccion) => {
                var trasacciones = await _transaccion.Transaccion();
                //200 ok, la solictud se realizo correctamente y se devuelve la lista

                return Results.Ok(trasacciones);

            }).WithTags("Transacciones");

            app.MapGet("api/transacciones/{IdTransaccion}", async (int id, ITransaccion _transaccion) => {
                var transaccion = await _transaccion.Transaccion(id);
                if (transaccion == null)

                    return Results.NotFound(); // 404 not foud el recurso solicitado no existe
                else
                    return Results.Ok(transaccion);  //200 ok, la solictud se realizo correctamente

            }).WithTags("Transacciones");

            app.MapPost("api/transacciones", async (GuardarTransaccion guardarTransaccion, ITransaccion _transaccion) => {
                if (guardarTransaccion == null)
                    return Results.BadRequest(); // 400 Bad request la solictud no se pudo procesar, debido a un error de formato.

                await _transaccion.Crear(guardarTransaccion);
                // 201 Created . El recurso se creo con exito. y se devuelve la ubucacion del recurso creado
                return Results.Created("api/transaccion/{transaccion.IdTransaccion}", guardarTransaccion);

            }).WithTags("Transacciones");

            app.MapPut("api/transacciones/{IdTransaccion}", async (int id, TransaccionDTO transaccion, ITransaccion _transaccion) => {
                var resultado = await _transaccion.Modificar(id, transaccion);
                if (resultado == 0)
                    return Results.NotFound(); // 404 not foud , el recurso solicitado no existe.
                else
                    return Results.Ok(resultado);// 200 ok, la solIcitud se realizo correctamente.

            }).WithTags("Transacciones");

            app.MapDelete("api/transacciones/{IdTransaccion}", async (int id, ITransaccion _transaccion) => {
                var resultado = await _transaccion.Eliminar(id);
                if (resultado == 0)
                    return Results.NotFound(); // 404 Not found, El recurso solicitado no existe.
                else
                    return Results.NoContent(); // 204 Not content  Recurso eliminado

            }).WithTags("Transacciones");
        }
    }
}
 