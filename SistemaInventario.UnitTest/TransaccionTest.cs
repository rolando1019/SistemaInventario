using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Context;
using Sistema_Inventario.dtos;
using Sistema_Inventario.Entities;
using Sistema_Inventario.Mappings;
using Sistema_Inventario.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SistemaInventario.UnitTest
{
    public class TransaccionesTest
    {

            private readonly TransaccionRepository _TransaccionRepository;
            public TransaccionesTest()
            {
                var options = new DbContextOptionsBuilder<ApplicationDbContext>()  
                    .UseSqlServer("Data Source = Marilis; Initial Catalog = Sistema_Inventario; Integrated Security = True; Trust Server Certificate = True")
                    .Options;

                var dbContext = new ApplicationDbContext(options);

                var configuartion = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile<MappingProfiles>();

                });

                var mapper = configuartion.CreateMapper();
                _TransaccionRepository = new TransaccionRepository(dbContext, mapper);
            }

            [Fact]
            public async void TestCrear()
            {
                //Arrange (Preparar)

                var objeto = new GuardarTransaccion();
                objeto.IdProducto = 4;
                objeto.Fechayhora = DateTime.Now;
                objeto.TipoTransaccion = "Traslado";
                objeto.Cantidad = 2;
                objeto.IdUsuario = 1;


                //Act ( Actuar)
                int resultado = await _TransaccionRepository.Crear(objeto);
                //Assert (Afirmar)

                Assert.True(resultado == 1);

            }
            [Fact]
            public async void TestObtener()
            {
                //Arrange(Prepara)

                //Act (Actuar)
                var transaccion = await _TransaccionRepository.Transaccion();

                //Assert(Afirmar)
                Assert.True(transaccion.Count > 0);
            }

            [Fact]
            public async void TestObtenerPorId()
            {
                //Arrange(Prepara)
                int id = 9;

                //Act (Actuar)
                var transaccion = await _TransaccionRepository.Transaccion(id);

                //Assert(Afirmar)
                Assert.NotNull(transaccion);
            }
            [Fact]
            public async void TestModificar()
            {
                //Arrange(Prepara)
                int id = 8;
                var objeto = new TransaccionDTO();
                // objeto.Fechayhora = ";
                objeto.TipoTransaccion = "Compra";
                objeto.Cantidad = 10;
                objeto.IdUsuario = 1;

                //Act (Actuar)
                int resultado = await _TransaccionRepository.Modificar(id, objeto);

                //Assert(Afirmar)
                Assert.Equal(1, resultado);
            }

            [Fact]
            public async void TestEliminar()
            {
                //Arrange(Prepara )
                int id = 9;

                //Act (Actuar)

                int resultado = await _TransaccionRepository.Eliminar(id);

                //Assert(Afirmar)
                Assert.Equal(1, resultado);

                //subir archivo de transacciones
            }
        }


}


