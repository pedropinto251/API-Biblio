using System;
using System.Collections.Generic;

namespace biblioteca.Models
{
    public class Reserva
    {
        public int Id { get; set; }
        public int ClienteId { get; set; }
        public int LivroId { get; set; }
        public DateTime DataReserva { get; set; }

        public Cliente? Cliente { get; set; }
        public Livro? Livro { get; set; }
    }
}