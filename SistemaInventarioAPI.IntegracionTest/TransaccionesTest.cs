using Microsoft.AspNetCore.Mvc.Testing;
using Sistema_Inventario.dtos;
using Sistema_Inventario.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioAPI.IntegracionTest
{
    [TestClass]
    public class TransaccionesTest
    {
      
          [TestMethod]
            public async Task ObtenerTokenUsuario()
            {
                using var application = new WebApplicationFactory<Program>();
                using var cliente = application.CreateClient();

                var respuesta = await cliente.PostAsJsonAsync("api/login",
                    new UsuarioLogin { Nombre = "Iris", Clave = "1234" });

                var token = await respuesta.Content.ReadAsStringAsync();

                Assert.IsNotNull(token);
            }

            [TestMethod]
            public async Task ObtenerTransaccion()
            {
                using var application = new WebApplicationFactory<Program>();
                using var cliente = application.CreateClient();
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " +
                    "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMjQ1MTM0NTMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiaXphbGNvIiwiZXhwIjoxNjk5MjE4OTAzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.B-RyRHeQMBtJJ1iq_IJrtcq4K2o8rE7ca1Gw_ZgPiA4");

                var respuesta = await cliente.GetFromJsonAsync<List<TransaccionDTO>>("api/transacciones");
                Assert.IsTrue(respuesta != null);

            }

         [TestMethod]

        public async Task ObtenerTransaccionPorId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMjQ1MTM0NTMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiaXphbGNvIiwiZXhwIjoxNjk5MjE4OTAzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.B-RyRHeQMBtJJ1iq_IJrtcq4K2o8rE7ca1Gw_ZgPiA4");

            var respuesta = await cliente.GetFromJsonAsync<TransaccionDTO>("api/transacciones/2004");

            Assert.IsTrue(respuesta != null);

        }


        [TestMethod]
        public async Task GuardarTransaccion()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var objeto = new TransaccionDTO { IdProducto = 1, Fechayhora = DateTime.Now, TipoTransaccion = "Traslado", Cantidad = 2, IdUsuario = 1 };
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMjQ1MTM0NTMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiaXphbGNvIiwiZXhwIjoxNjk5MjE4OTAzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.B-RyRHeQMBtJJ1iq_IJrtcq4K2o8rE7ca1Gw_ZgPiA4");
            var respuesta = await cliente.PostAsJsonAsync("api/transacciones", objeto);

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);

        }

        [TestMethod]
        public async Task ModificarTransaccion()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var objeto = new TransaccionDTO { IdProducto = 1, Fechayhora = DateTime.Now, TipoTransaccion = "Traslado", Cantidad = 2, IdUsuario = 1 };

            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMjQ1MTM0NTMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiaXphbGNvIiwiZXhwIjoxNjk5MjE4OTAzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.B-RyRHeQMBtJJ1iq_IJrtcq4K2o8rE7ca1Gw_ZgPiA4");
            var respuesta = await cliente.PutAsJsonAsync("api/transacciones/2008", objeto);

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);

        }

        [TestMethod]
        public async Task EliminarTransaccionPorId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMjQ1MTM0NTMiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiaXphbGNvIiwiZXhwIjoxNjk5MjE4OTAzLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.B-RyRHeQMBtJJ1iq_IJrtcq4K2o8rE7ca1Gw_ZgPiA4");
            var respuesta = await cliente.DeleteAsync("api/transacciones/3003");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);

        }



    }
}

