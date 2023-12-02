using Microsoft.AspNetCore.Mvc.Testing;
using Sistema_Inventario.dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Sistema_Inventario.DTOs;

namespace SistemaInventarioAPI.IntegracionTest
{
    [TestClass]
    public class Proveedores_Test
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

        public async Task ObtenerProveedores()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");
            var respuesta = await cliente.GetFromJsonAsync<List<ProveedorDTO>>("api/proveedores");
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task ObtenerProveedorPorId()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");
            var respuesta = await cliente.GetFromJsonAsync<ProveedorDTO>("api/proveedores/1");
           
            Assert.IsTrue(respuesta != null);
        }

        [TestMethod]

        public async Task GuardarProveedor()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var objeto = new ProveedorDTO { Nombre = "Carlos Linares", Empresa = "Electronica" , Correo = "carlos@hotmail.com", Direccion = "Izalco", Telefono = "1234-5678"};
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");

            var respuesta = await cliente.PostAsJsonAsync("api/proveedor", objeto);

            Assert.AreEqual(HttpStatusCode.Created, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task ModificarProveedor()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            var objeto = new ProveedorDTO { IdProveedor = 6, Nombre = "Sofá Alarcon", Empresa = "Electronica", Correo = "alarcon@hotmail.com", Direccion = "Izalco", Telefono = "0000-0000" };
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");

            var respuesta = await cliente.PutAsJsonAsync("api/proveedor/2", objeto);

            Assert.AreEqual(HttpStatusCode.OK, respuesta.StatusCode);
        }

        [TestMethod]

        public async Task EliminarProveedor()
        {
            using var application = new WebApplicationFactory<Program>();
            using var cliente = application.CreateClient();
            cliente.DefaultRequestHeaders.Add("Authorization", "Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjEiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1lIjoiSnVhbiIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL21vYmlsZXBob25lIjoiNzMwMjU5ODgiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9zdHJlZXRhZGRyZXNzIjoiTGEgUGF6IiwiZXhwIjoxNzAxNzM3MTQyLCJpc3MiOiJodHRwczovL2xvY2FsaG9zdDo3MDExLyIsImF1ZCI6ImxvY2FsaG9zdCJ9.7F5GXB3RnotbyK0jitbcRQ1B3Y77x1FsT502_gZBlec");

            var respuesta = await cliente.DeleteAsync("api/proveedor/7");

            Assert.AreEqual(HttpStatusCode.NoContent, respuesta.StatusCode);
        }


        public class UsuarioLogin
        {

            public string Nombre { get; set; }
            public string Clave { get; set; }

        }

    }
}
