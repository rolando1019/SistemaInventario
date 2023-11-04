using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.dtos;
using Sistema_Inventario.Mappings;
using Sistema_Inventario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaInventario.UnitTest
{
    public class ProveedorTest
    {
        private readonly ProveedorRepository _proveedorRepository;
        public ProveedorTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Data Source = DESKTOP-RS7J03N; Initial Catalog = Sistema_Inventario; Integrated Security = True; Trust Server Certificate = True").Options;
            var dbContext = new ApplicationDbContext(options);

            var configurations = new MapperConfiguration(cfg
                =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            var mapper = configurations.CreateMapper();

            _proveedorRepository = new ProveedorRepository(dbContext, mapper);
        }

        [Fact]

        public async void TestCrear()
        {
            //Arrange(Prepara)
            var objeto = new ProveedorDTO();
            objeto.Nombre = "Juan";
            objeto.Empresa = "Profesa";
            objeto.Direccion = "Sonsonate";
            objeto.Correo = "juan@ejemplo.com";
            objeto.Telefono = "12316540";

            //Act (Actuar)
            int resultado = await _proveedorRepository.Crear(objeto);

            //Assert(Afirmar)
            Assert.True(resultado == 1);
        }

        [Fact]
        public async void TestObtener()
        {
            //Arrange(Prepara)

            //Act (Actuar)
            var proveedores = await _proveedorRepository.Proveedor();

            //Assert(Afirmar)
            Assert.True(proveedores.Count > 0);
        }

        [Fact]
        public async void TestObtenerPorId()
        {
            //Arrange(Prepara)
            int id = 2;

            //Act (Actuar)
            var proveedor = await _proveedorRepository.Proveedor(id);

            //Assert(Afirmar)
            Assert.NotNull(proveedor);
        }

        [Fact]
        public async void TestModificar()
        {
            //Arrange(Prepara)
            int id = 2;
            var objeto = new ProveedorDTO();
            objeto.IdProveedor = id;
            objeto.Nombre = "José";
            objeto.Empresa = "Security";
            objeto.Direccion = "Santa Ana";
            objeto.Correo = "jose@ejemplo.com";
            objeto.Telefono = "89754822";

            //Act (Actuar)
            int resultado = await _proveedorRepository.Modificar(id, objeto);

            //Assert(Afirmar)
            Assert.Equal(1, resultado);
        }

        [Fact]
        public async void TestEliminar()
        {
            //Arrange(Prepara)
            int id = 1002;

            //Act (Actuar)
            int resultado = await _proveedorRepository.Eliminar(id);

            //Assert(Afirmar)
            Assert.Equal(1, resultado);
        }
    }
}
