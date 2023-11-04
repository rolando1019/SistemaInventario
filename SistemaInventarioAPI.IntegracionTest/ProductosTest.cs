using Microsoft.AspNetCore.Mvc.Testing;
using Sistema_Inventario.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventarioAPI.IntegracionTest
{
    [TestClass]
    public class ProductosTest
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
        public async Task ObtenerProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer " +
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzk4OC02NzM0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6Ikl6YWxjbyIsImV4cCI6MTY5ODU0OTM4NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.TQBccua0Vv4eucSBzjwzS2dTu2d4ByUwAbTOS9sDd0w");

            var respuesta = await cliente.GetFromJsonAsync<List<ProductoDTO>>("api/productos");
            Assert.IsTrue(respuesta != null);

        }

        [TestMethod]
        public async Task ObtenerProductoPorId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzk4OC02NzM0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6Ikl6YWxjbyIsImV4cCI6MTY5ODU0OTM4NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.TQBccua0Vv4eucSBzjwzS2dTu2d4ByUwAbTOS9sDd0w");

            var respuesta = await cliente.GetFromJsonAsync<ProductoDTO>("api/productos/7");

            Assert.IsTrue(respuesta != null);

        }


        [TestMethod]
        public async Task GuardarProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var objeto = new ProductoDTO { Nombre = "desayunador", Desripcion = "Madera", IdCategoria = 1, Precio = 50, Stock = 25, IdProveedor = 1 };
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzk4OC02NzM0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6Ikl6YWxjbyIsImV4cCI6MTY5ODU1MzA1MywiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.c2a9e32xOs3opxSl99AONVzqVlEXmplsUFapMKVjpq4");
            var respuesta = await cliente.PostAsJsonAsync("api/productos", objeto);

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);

        }

        [TestMethod]
        public async Task ModificarProducto()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var objeto = new ProductoDTO { IdProducto = 4, Nombre = "Juego de sala", Desripcion = "Madera ", IdCategoria = 1, Precio = 50, Stock = 25, IdProveedor = 1 };

            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzk4OC02NzM0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6Ikl6YWxjbyIsImV4cCI6MTY5ODU0OTM4NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.TQBccua0Vv4eucSBzjwzS2dTu2d4ByUwAbTOS9sDd0w");
            var respuesta = await cliente.PutAsJsonAsync("api/producto/4", objeto);

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);

        }


        [TestMethod]
        public async Task EliminarProductoPorId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSXJpcyIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzk4OC02NzM0IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6Ikl6YWxjbyIsImV4cCI6MTY5ODU0OTM4NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.TQBccua0Vv4eucSBzjwzS2dTu2d4ByUwAbTOS9sDd0w");
            var respuesta = await cliente.DeleteAsync("api/producto/10");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);

        }

        public class UsuarioLogin
        {

            public string Nombre { get; set; }
            public string Clave { get; set; }


        }
    }
}
    
