
using Xunit;
using Microsoft.EntityFrameworkCore;
using biblioteca.Controllers;
using biblioteca.Models;
using biblioteca.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;

namespace biblioteca.testes
{
    public class testeLivros
    {
        [Fact]
        public void GetLivro_Exists_ReturnsOkResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "GetLivro_Exists_ReturnsOkResult")
                .Options;

            // Insert seed data into the database using one instance of the context
            using (var context = new BibliotecaContext(options))
            {
                context.Livros.Add(new Livro { Id = 1, Titulo = "Livro Teste", Autor = "Autor Teste", AnoPublicacao = 2022 });
                context.SaveChanges();
            }

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new LivroController(context);

                // Act
                var result = controller.GetLivro(1);

                // Assert
                var okResult = Assert.IsType<OkObjectResult>(result.Result);
                var livro = Assert.IsType<Livro>(okResult.Value);
                Assert.Equal(1, livro.Id);
            }
        }

        [Fact]
        public void GetLivro_NotExists_ReturnsNotFoundResult()
        {
            // Arrange
            var options = new DbContextOptionsBuilder<BibliotecaContext>()
                .UseInMemoryDatabase(databaseName: "GetLivro_NotExists_ReturnsNotFoundResult")
                .Options;

            // Use a clean instance of the context to run the test
            using (var context = new BibliotecaContext(options))
            {
                var controller = new LivroController(context);

                // Act
                var result = controller.GetLivro(1);

                // Assert
                Assert.IsType<NotFoundResult>(result.Result);
            }
        }
    }
}
