using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EJ4_I.Models
{
    public class Reserva
    {
        public string DNI { get; set; }
        public char NumSerie { get; set; }
        public DateTime Comienzo { get; set; }
        public DateTime Fin { get; set; }

        public virtual Investigadores Investigadores { get; set; }
        public virtual Equipos Equipos { get; set; }
    }
}
