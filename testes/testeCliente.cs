
using Xunit;
using Microsoft.EntityFrameworkCore;
using biblioteca.Controllers;
using biblioteca.Models;
using biblioteca.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;

namespace biblioteca.testes
{
    public class testeCliente
    {
        [Fact]
        public void GetCliente_Exists_ReturnsOkResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "GetCliente_Exists_ReturnsOkResult")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BibliotecaContext(options))
            {
                context.Cliente.Add(new Cliente { Id = 1, Nome = "Cliente Teste", Endereco = "Endereço Teste", Contato = "Contato Teste" });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new ClienteController(context);

                // Act
                var result = controller.GetCliente(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var cliente = Assert.IsType<Cliente>(okResult.Value);
                Assert.Equal(1, cliente.Id);
            }
        }

        [Fact]
        public void GetCliente_NotExists_ReturnsNotFoundResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "GetCliente_NotExists_ReturnsNotFoundResult")
                .Options;

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new ClienteController(context);

                // Act
                var result = controller.GetCliente(1);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }
    }
}
