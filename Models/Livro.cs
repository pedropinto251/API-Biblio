using System;
using System.Collections.Generic;

namespace biblioteca.Models
{
	public class Livro
	{
		public int Id { get; set; }
		public string? Titulo { get; set; }
		public string? Autor { get; set; }
		public int AnoPublicacao { get; set; }

		//public List<Reserva>? Reservas { get; set; }
	}
}