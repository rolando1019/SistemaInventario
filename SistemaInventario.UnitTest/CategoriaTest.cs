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
    public class CategoriaTest
    {
        private readonly CategoriaRepository _categoriaRepository;

        public CategoriaTest()
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseSqlServer("Data Source = DESKTOP-9S2PS8B\\SQLEXPRES; Initial Catalog=Sistema_Inventario; Integrated Security = True; Trust Server Certificate = True;").Options;

            var dbContext = new ApplicationDbContext(options);

            var configurations = new MapperConfiguration(cfg
                =>
            {
                cfg.AddProfile<MappingProfiles>();
            });

            var mapper = configurations.CreateMapper();

            _categoriaRepository = new CategoriaRepository(dbContext, mapper);
        }

        [Fact]

        public async void TestCrear()
        {
            //Arrange(Prepara)
            var objeto = new CategoriaDTO();
            objeto.Nombre = "Producto electronicos";
            objeto.Descripcion = "productos varios";

            //Act (Actuar)
            int resultado = await _categoriaRepository.Crear(objeto);

            //Assert(Afirmar)
            Assert.True(resultado == 1);
        }

        [Fact]
        public async void TestObtener()
        {
            //Arrange(Prepara)

            //Act (Actuar)
            var categorias = await _categoriaRepository.Categorias();

            //Assert(Afirmar)
            Assert.True(categorias.Count > 0);
        }

        [Fact]
        public async void TestObtenerPorId()
        {
            //Arrange(Prepara)
            int id = 3;

            //Act (Actuar)
            var categoria = await _categoriaRepository.Categoria(id);

            //Assert(Afirmar)
            Assert.NotNull(categoria);
        }

        [Fact]
        public async void TestModificar()
        {
            //Arrange(Prepara)
            int id = 1;
            var objeto = new CategoriaDTO();
            objeto.IdCategoria = id;
            objeto.Nombre = "Licuadora";

            //Act (Actuar)
            int resultado = await _categoriaRepository.Modificar(id, objeto);

            //Assert(Afirmar)
            Assert.Equal(1, resultado);
        }

        [Fact]
        public async void TestEliminar()
        {
            //Arrange(Prepara)
            int id = 6;

            //Act (Actuar)
            int resultado = await _categoriaRepository.Eliminar(id);

            //Assert(Afirmar)
            Assert.Equal(1, resultado);
        }
    }
}
