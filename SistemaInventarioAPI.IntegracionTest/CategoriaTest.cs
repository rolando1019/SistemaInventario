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
    public class CategoriaTest
    {
        [TestMethod]
        public async Task ObtenerTokenUsuario()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var respuesta = await cliente.PostAsJsonAsync("api/login",
                new UsuarioLogin { Nombre = "Juan", Clave = "123" });
            var token = await respuesta.Content.ReadAsStringAsync();

            Assert.IsNotNull(token);
        }

        [TestMethod]

        public async Task ObtenerCategorias()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");
            var respuesta = await cliente.GetFromJsonAsync<List<CategoriaDTO>>("api/categorias");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task ObtenerCategoriaPorId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");
            var respuesta = await cliente.GetFromJsonAsync<CategoriaDTO>("api/categorias/1");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task GuardarCategoria()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var objeto = new CategoriaDTO { Nombre = "Colchones", Descripcion = "Algodon"};
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");

            var respuesta = await cliente.PostAsJsonAsync("api/categoria", objeto);

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task ModificarCategoria()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var objeto = new CategoriaDTO { IdCategoria = 3, Nombre = "Sofá" , Descripcion = " plastico"};
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");

            var respuesta = await cliente.PutAsJsonAsync("api/categoria/2", objeto);

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task EliminarCategoria()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");

            var respuesta = await cliente.DeleteAsync("api/categoria/4");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }


        public class UsuarioLogin
        {

            public string Nombre { get; set; }
            public string Clave { get; set; }

        }
    }
}

