using Microsoft.AspNetCore.Mvc.Testing;
using Sistema_Inventario.dtos;
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
    public class Roll_Test
    {
            [TestMethod]
            public async Task ObtenerTokenUsuario()
            {
                using var application = new WebApplicationFactory<Program>();
                using var cliente = application.CreateClient();
                var respuesta = await cliente.PostAsJsonAsync("api/login",
                    new UsuarioLogin { Nombre = "juan", Clave = "34" });
                var token = await respuesta.Content.ReadAsStringAsync();

                Assert.IsNotNull(token);
            }

            [TestMethod]

            public async Task ObtenerRoles()
            {
                using var application = new WebApplicationFactory<Program>();
                using var cliente = application.CreateClient();
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMTUxNS0xNTE1IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6IlNhbnRhIElzYWJlbCIsImV4cCI6MTY5ODcxMzU1NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.ieE2o01TCiIgekWIslXe7jD2r91tS9RZwoqxJxaFOno");
                var respuesta = await cliente.GetFromJsonAsync<List<RolDTO>>("api/roles");
                Assert.IsTrue(respuesta != null);
            }

            [TestMethod]

            public async Task ObtenerRolPorId()
            {
                using var application = new WebApplicationFactory<Program>();
                using var cliente = application.CreateClient();
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMTUxNS0xNTE1IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6IlNhbnRhIElzYWJlbCIsImV4cCI6MTY5ODcxMzU1NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.ieE2o01TCiIgekWIslXe7jD2r91tS9RZwoqxJxaFOno");
                var respuesta = await cliente.GetFromJsonAsync<RolDTO>("api/roles/4");
                Assert.IsTrue(respuesta != null);
            }

            [TestMethod]

            public async Task GuardarRol()
            {
                using var application = new WebApplicationFactory<Program>();
                using var cliente = application.CreateClient();
                var objeto = new RolDTO { Nombre = "vendedor" };
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMTUxNS0xNTE1IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6IlNhbnRhIElzYWJlbCIsImV4cCI6MTY5ODcxMzU1NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.ieE2o01TCiIgekWIslXe7jD2r91tS9RZwoqxJxaFOno");

                var respuesta = await cliente.PostAsJsonAsync("api/rol", objeto);

                Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
            }

            [TestMethod]

            public async Task ModificarRol()
            {
                using var application = new WebApplicationFactory<Program>();
                using var cliente = application.CreateClient();
                var objeto = new CategoriaDTO { IdCategoria = 2, Nombre = "Vendedor"};
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMTUxNS0xNTE1IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6IlNhbnRhIElzYWJlbCIsImV4cCI6MTY5ODcxMzU1NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.ieE2o01TCiIgekWIslXe7jD2r91tS9RZwoqxJxaFOno");

                var respuesta = await cliente.PutAsJsonAsync("api/roles/4", objeto);

                Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
            }

            [TestMethod]

            public async Task EliminarRol()
            {
                using var application = new WebApplicationFactory<Program>();
                using var cliente = application.CreateClient();
                cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjciLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiMTUxNS0xNTE1IiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvc3RyZWV0YWRkcmVzcyI6IlNhbnRhIElzYWJlbCIsImV4cCI6MTY5ODcxMzU1NSwiaXNzIjoiaHR0cHM6Ly9sb2NhbGhvc3Q6NzAxMS8iLCJhdWQiOiJsb2NhbGhvc3QifQ.ieE2o01TCiIgekWIslXe7jD2r91tS9RZwoqxJxaFOno");

                var respuesta = await cliente.DeleteAsync("api/rol/4");

                Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
            }


            public class UsuarioLogin
            {

                public string Nombre { get; set; }
                public string Clave { get; set; }

            }
        
    }

}

