using Microsoft.AspNetCore.Mvc;
using System.Linq;
using biblioteca.Models;
using biblioteca;
using biblioteca.DataAccess;


namespace biblioteca.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ClienteController : ControllerBase
	{
		private readonly BibliotecaContext _context;

		public ClienteController(BibliotecaContext context)
		{
			_context = context;
		}
        [HttpPost]
        public ActionResult PostCliente([FromBody] Cliente novoCliente)
        {
       
            if (novoCliente.Id != 0)
            {
                return BadRequest("Id should not be provided for a new client.");
            }

      
            _context.Cliente.Add(novoCliente);
            _context.SaveChanges();

            return CreatedAtAction("GetCliente", new { id = novoCliente.Id }, novoCliente);
        }

        // DELETE: api/Cliente/
        [HttpDelete("{id}")]
        public ActionResult<Cliente> DeleteCliente(int id)
        {
            var cliente = _context.Cliente.Find(id);

            if (cliente == null)
            {
                return NotFound();
            }

            _context.Cliente.Remove(cliente);
            _context.SaveChanges();

            return cliente;
        }

        [HttpGet("{id}")]
		public ActionResult<Cliente> GetCliente(int id)
		{
			var cliente = _context.Cliente.Find(id);

			if (cliente == null)
			{
				return NotFound();
			}

			return cliente;
		}
	}
}