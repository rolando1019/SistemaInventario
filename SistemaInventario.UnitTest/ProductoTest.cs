using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.DTOs;
using Sistema_Inventario.Mappings;
using Sistema_Inventario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SinstemaInventario.UnitTest
    {
        public class ProductoTest
        {
            private readonly ProductoRepository _productoRepository;
            public ProductoTest()
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer("Data Source = DESKTOP-RS7J03N; Initial Catalog = Sistema_Inventario; Integrated Security = True; Trust Server Certificate = True")
                    .Options;

                var dbContext = new ApplicationDbContext(options);

                var configuartion = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfiles>();

                });

                var mapper = configuartion.CreateMapper();
                _productoRepository = new ProductoRepository(dbContext, mapper);
            }

            [Fact]
            public async void TestCrear()
            {
                //Arrange (Preparar)

                var objeto = new ProductoDTO();
                objeto.Nombre = "MicrohondaS";
                objeto.Desripcion = "Marca LG";
                objeto.Stock = 2;
                objeto.Precio = 10;
                objeto.IdProveedor = 1;
                objeto.IdCategoria = 1;

                //Act ( Actuar)

                int resultado = await _productoRepository.Crear(objeto);

                //Assert (Afirmar)

                Assert.True(resultado == 1);

            }
            [Fact]
            public async void TestObtener()
            {
                //Arrange(Prepara)

                //Act (Actuar)
                var productos = await _productoRepository.productos();

                //Assert(Afirmar)
                Assert.True(productos.Count > 0);
            }
            [Fact]
            public async void TestObtenerPorId()
            {
                //Arrange(Prepara)
                int id = 2;

                //Act (Actuar)
                var producto = await _productoRepository.Producto(id);

                //Assert(Afirmar)
                Assert.NotNull(producto);
            }
            [Fact]
            public async void TestModificar()
            {
                //Arrange(Prepara)
                int id = 7;
                var objeto = new ProductoDTO();
                objeto.Nombre = "Freidora de Aire";
                objeto.Desripcion = "Marca JC, Color blanco ";
                objeto.Stock = 5;
                objeto.Precio = 150;
                objeto.IdProveedor = 1;
                objeto.IdCategoria = 1;

                //Act (Actuar)
                int resultado = await _productoRepository.Modificar(id, objeto);

                //Assert(Afirmar)
                Assert.Equal(1, resultado);
            }

            [Fact]
            public async void TestEliminar()
            {
                //Arrange(Prepara)
                int id = 5;

                //Act (Actuar)
                int resultado = await _productoRepository.Eliminar(id);

                //Assert(Afirmar)
                Assert.Equal(1, resultado);
            }
        }
}
