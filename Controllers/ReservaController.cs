using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using biblioteca.DataAccess; 
using biblioteca.Models;
using biblioteca;

namespace biblioteca.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaController : ControllerBase
    {
        private readonly BibliotecaContext _context;

        public ReservaController(BibliotecaContext context)
        {
           _context = context;
        }

        [HttpPost]
        public ActionResult PostReserva(Reserva reserva)
        {
            if (reserva.Id != 0)
            {
                                            
                return BadRequest("Id should not be provided for a new reservation.");
            }

            var cliente = _context.Cliente.Find(reserva.ClienteId);
            var livro = _context.Livros.Find(reserva.LivroId);

            if (cliente == null || livro == null)
            {
                return BadRequest("Cliente or Livro not found.");
            }

            reserva.Cliente = cliente;
            reserva.Livro = livro;

     
            _context.Reservas.Add(reserva);
            _context.SaveChanges();

            return CreatedAtAction("GetReserva", new { id = reserva.Id }, reserva);
        }


        [HttpGet("{id}")]
        public ActionResult<Reserva> GetReserva(int id)
        {
            var reserva = _context.Reservas
                .Include(r => r.Cliente)
                .Include(r => r.Livro)
                .FirstOrDefault(r => r.Id == id);

            if (reserva == null)
            {
                return NotFound();
            }

            return reserva;
        }
        // DELETE: api/Reserva/
        [HttpDelete("{id}")]
        public ActionResult DeleteReserva(int id)
        {
            var reserva = _context.Reservas.Find(id);

            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reservas.Remove(reserva);
            _context.SaveChanges();

            return NoContent();
        }
        [HttpGet("{idCliente}/Livros")]
        public ActionResult<IEnumerable<object>> GetReservasPorCliente(int idCliente)
        {
            var reservas = _context.Reservas
                .Where(r => r.ClienteId == idCliente)
                .Select(r => new
                {
                    TituloLivro = r.Livro != null ? r.Livro.Titulo : null,
                    AutorLivro = r.Livro != null ? r.Livro.Autor : null,
                    DataReserva = r.DataReserva
                })
                .ToList();

            return reservas;
        }

    }
}
