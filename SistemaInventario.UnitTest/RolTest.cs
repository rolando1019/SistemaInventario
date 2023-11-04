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
    public class RolTest
    {
        private readonly RolRepository _rolRepository;

        public RolTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Data Source = DESKTOP-9S2PS8B\\SQLEXPRES; Initial Catalog = Sistema_Inventario; Integrated Security = True; Trust Server Certificate = True").Options;

            var dbContext = new ApplicationDbContext(options);

            var configurations = new MapperConfiguration(cfg
                =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            var mapper = configurations.CreateMapper();

            _rolRepository = new RolRepository(dbContext, mapper);
        }

        [Fact]

        public async void TestCrear()
        {
            //Arrange(Prepara)
            var objeto = new RolDTO();
            objeto.Nombre = "Programador";

            //Act (Actuar)
            int resultado = await _rolRepository.Crear(objeto);

            //Assert(Afirmar)
            Assert.True(resultado == 1);
        }

        [Fact]
        public async void TestObtener()
        {
            //Arrange(Prepara)

            //Act (Actuar)
            var roles = await _rolRepository.Roles();

            //Assert(Afirmar)
            Assert.True(roles.Count > 0);
        }

        [Fact]
        public async void TestObtenerPorId()
        {
            //Arrange(Prepara)
            int id = 2;

            //Act (Actuar)
            var rol = await _rolRepository.Rol(id);

            //Assert(Afirmar)
            Assert.NotNull(rol);
        }

        [Fact]
        public async void TestModificar()
        {
            //Arrange(Prepara)
            int id = 2;
            var objeto = new RolDTO();
            objeto.IdRol = id;
            objeto.Nombre = "Vendedor";

            //Act (Actuar)
            int resultado = await _rolRepository.Modificar(id, objeto);

            //Assert(Afirmar)
            Assert.Equal(1, resultado);
        }

        [Fact]
        public async void TestEliminar()
        {
            //Arrange(Prepara)
            int id = 5;

            //Act (Actuar)
            int resultado = await _rolRepository.Eliminar(id);

            //Assert(Afirmar)
            Assert.Equal(1, resultado);
        }
    }
}
