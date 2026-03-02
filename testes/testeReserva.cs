
using Xunit;
using Microsoft.EntityFrameworkCore;
using biblioteca.Controllers;
using biblioteca.Models;
using biblioteca.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;

namespace biblioteca.testes
{
    public class testeReserva
    {
        [Fact]
        public void PostReserva_ValidData_ReturnsCreatedAtActionResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "PostReserva_ValidData_ReturnsCreatedAtActionResult")
                .Options;

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new ReservaController(context);
                var reserva = new Reserva
                {
                    Id = 1,
                    ClienteId = 1,
                    LivroId = 1,
                    DataReserva = DateTime.Now
                };

                // Act
                var result = controller.PostReserva(reserva);

                // Assert
                var createdAtActionResult = Assert.IsType<CreatedAtActionResult>(result);
                Assert.Equal("GetReserva", createdAtActionResult.ActionName);
            }
        }

        [Fact]
        public void GetReserva_Exists_ReturnsOkResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "GetReserva_Exists_ReturnsOkResult")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BibliotecaContext(options))
            {
                context.Reservas.Add(new Reserva { Id = 1, ClienteId = 1, LivroId = 1, DataReserva = DateTime.Now });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new ReservaController(context);

                // Act
                var result = controller.GetReserva(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var reserva = Assert.IsType<Reserva>(okResult.Value);
                Assert.Equal(1, reserva.Id);
            }
        }

        [Fact]
        public void GetReserva_NotExists_ReturnsNotFoundResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "GetReserva_NotExists_ReturnsNotFoundResult")
                .Options;

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new ReservaController(context);

                // Act
                var result = controller.GetReserva(1);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }

        [Fact]
        public void GetReservasPorCliente_Exists_ReturnsOkResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "GetReservasPorCliente_Exists_ReturnsOkResult")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BibliotecaContext(options))
            {
                context.Reservas.Add(new Reserva { Id = 1, ClienteId = 1, LivroId = 1, DataReserva = DateTime.Now });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new ReservaController(context);

                // Act
                var result = controller.GetReservasPorCliente(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var reservas = Assert.IsType<List<object>>(okResult.Value);
                Assert.Single(reservas);
            }
        }

        [Fact]
        public void GetReservasPorCliente_NotExists_ReturnsNotFoundResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "GetReservasPorCliente_NotExists_ReturnsNotFoundResult")
                .Options;

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new ReservaController(context);

                // Act
                var result = controller.GetReservasPorCliente(1);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }
    }
}
