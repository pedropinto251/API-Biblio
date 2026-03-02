using Microsoft.AspNetCore.Mvc;
using System.Linq;
using biblioteca.Models;
using biblioteca;
using biblioteca.DataAccess;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public LivroController(BibliotecaContext context)
        {
            _context = context;
        }
        [HttpPost]
        public ActionResult PostLivro([FromBody] Livro novoLivro)
        {

            if (novoLivro.Id != 0)
            {
                return BadRequest("Id should not be provided for a new book.");
            }


            _context.Livros.Add(novoLivro);
            _context.SaveChanges();

            return CreatedAtAction("GetLivro", new { id = novoLivro.Id }, novoLivro);
        }

        // DELETE: api/Livro/
        [HttpDelete("{id}")]
        public ActionResult<Livro> DeleteLivro(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null)
            {
                return NotFound();
            }

            _context.Livros.Remove(livro);
            _context.SaveChanges();

            return livro;
        }

        [HttpGet("{id}")]
        public ActionResult<Livro> GetLivro(int id)
        {
            var livro = _context.Livros.Find(id);

            if (livro == null)
            {
                return NotFound();
            }

            return livro;
        }
    }
}
